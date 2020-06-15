using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Core.Collections;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.Forms.Models.AiDecompilerPack;

namespace L2ScriptMaker.Forms.Modules.AI
{
	public partial class AiDecompilerPack : Form
	{
		#region Nested classes
		private sealed class EnabledNotificator : INotifyPropertyChanged
		{
			private bool _enabled { get; set; }
			public bool Enabled
			{
				get => _enabled;
				set
				{
					_enabled = value;
					OnPropertyChanged();
				}
			}

			public event PropertyChangedEventHandler PropertyChanged;

			// [NotifyPropertyChangedInvocator]
			private void OnPropertyChanged([CallerMemberName] string propertyName = null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		//private EnabledNotificator Busy { get; set; }
		private readonly char[] _splitChars = new char[] { ' ', '\t' };

		public AiDecompilerPack()
		{
			InitializeComponent();
			Load += OnLoad;
		}

		private void OnLoad(object sender, EventArgs e)
		{
			//Busy = new EnabledNotificator { Enabled = true };

			////btnAiSelect.DataBindings.Add("Enabled", Busy, "Enabled");

			//CollectHandlerButton.DataBindings.Add("Enabled", Busy, "Enabled");
			//CollectFetchButton.DataBindings.Add("Enabled", Busy, "Enabled");
			//CollectFuncButton.DataBindings.Add("Enabled", Busy, "Enabled");
			//CollectEventButton.DataBindings.Add("Enabled", Busy, "Enabled");

			clbCollect.Items.AddRange(
				new object[]
				{
					new ListItem{ Text = "handler", Value  = "handler", Selected = true},
					new ListItem{ Text = "push_event", Value  = "push_event", Selected = true},
					new ListItem{ Text = "fetch_i", Value  = "fetch_i", Selected = true},
					new ListItem{ Text = "func_call", Value  = "func_call", Selected = true}
				});
			// clbCollect.SetItemCheckState(0, CheckState.Checked);
			clbCollect.ValueMember = "Value";
			clbCollect.DisplayMember = "Text";
		}

		private void ProgressBarUpdater(int value)
		{
			ProgressBar.Invoker(() => { ProgressBar.Value = value; });
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (TrySelectAi(out string aiFile) == false) return;

			// Busy.Enabled = false;
			btnStart.Enabled = false;
			QuitButton.Enabled = false;

			IProgress<int> progress = new Progress<int>(ProgressBarUpdater);
			Task.Run(() => CollectProcess(aiFile, progress))
				.ContinueWith(task =>
				{
					this.Invoker(() =>
					{
						// Busy.Enabled = true;
						ProgressBar.Value = 0;

						btnStart.Enabled = true;
						QuitButton.Enabled = true;
					});
				});
		}

		private bool TrySelectAi(out string file)
		{
			file = txbAiFile.Text;
			if (File.Exists(file))
			{
				//file = file;
				//txbAiFile.Text = file;
				return true;
			}

			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) return false;

			file = OpenFileDialog.FileName;
			txbAiFile.Text = file;
			return true;
		}

		private void CollectProcess(string aiFile, IProgress<int> progress)
		{
			var checkedItems = clbCollect.CheckedItems.Cast<ListItem>().ToArray();
			if (checkedItems.Length == 0)
			{
				MessageBox.Show("No one analysist selected", "Collect", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			bool checkHandlers = checkedItems.Any(a => a.Value == "handler");
			bool checkPushEvents = checkedItems.Any(a => a.Value == "push_event");
			bool checkFetchs = checkedItems.Any(a => a.Value == "fetch_i");
			bool checkFuncs = checkedItems.Any(a => a.Value == "func_call");

			// --- Select ai.obj ---
			if (!File.Exists(aiFile))
			{
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) return;
				aiFile = OpenFileDialog.FileName;
			}
			// --- Select ai.obj ---

			// string currentClass = String.Empty;
			string currentClassType = String.Empty;
			string currentHandler = String.Empty;
			string currentEventName = String.Empty;

			// int collected = 0;
			List<AiHandler> handlers = new List<AiHandler>();
			List<AiEvent> events = new List<AiEvent>();
			List<AiFetch> fetches = new List<AiFetch>();
			List<AiFunc> funcs = new List<AiFunc>();

			int cacheLimit = 3;
			ReadableLimitedSizeStack<string> cache = new ReadableLimitedSizeStack<string>(cacheLimit);

			IEnumerable<string> aiData = FileUtils.Read(aiFile, progress);
			using (var dataEnumerator = aiData.GetEnumerator())
			{
				while (dataEnumerator.MoveNext())
				{
					string row = dataEnumerator.Current;
					if (row == null) continue;

					cache.Push(row);

					if (row.StartsWith("class "))
					{
						string[] tmpSplit = row.Split(_splitChars, StringSplitOptions.RemoveEmptyEntries);
						if (tmpSplit.Length < 3) continue;

						// currentClass = tmpSplit[2];
						currentClassType = tmpSplit[1];
						continue;
					}

					if (row.StartsWith("handler "))
					{
						string[] tmpSplit = row.Split(_splitChars, StringSplitOptions.RemoveEmptyEntries);
						if (tmpSplit.Length < 3) continue;

						currentHandler = tmpSplit[4];
						if (checkHandlers)
						{
							if (!handlers.Any(a => a.ClassType == currentClassType && a.Id == tmpSplit[1] && a.Name == currentHandler))
							{
								handlers.Add(new AiHandler { ClassType = currentClassType, Id = tmpSplit[1], Name = currentHandler });
							}
						}
						continue;
					}

					if (row.StartsWith("push_const "))
					{
						string[] tmpSplit = row.Split(_splitChars, StringSplitOptions.RemoveEmptyEntries);
						string pushValue = tmpSplit[1];
						string[] previousRow = cache.GetPrevious().Split(_splitChars, StringSplitOptions.RemoveEmptyEntries);

						if (previousRow[0] == "push_event" && previousRow.Length == 3)
						{
							currentEventName = previousRow[2];
							if (checkPushEvents)
							{
								if (events.All(a => a.Id != pushValue))
								{
									events.Add(new AiEvent { Id = pushValue, Name = currentEventName, Handler = "default" });
								}
								else
								{
									List<AiEvent> eventCandidates = events
										.Where(a => a.Id == pushValue && a.Name == currentEventName && (a.Handler == currentHandler || a.Handler == "default"))
										.ToList();
									if (eventCandidates.Count == 0)
									{
										events.Add(new AiEvent { Id = pushValue, Name = currentEventName, Handler = currentHandler });
									}
								}
							}
						}

						if (previousRow[0] == "fetch_i" && previousRow.Length == 3)
						{
							if (checkFetchs)
							{
								if (fetches.All(a => a.Id != pushValue))
								{
									fetches.Add(new AiFetch { Id = pushValue, Name = previousRow[2], Handler = "default" });
								}
								else
								{
									List<AiFetch> fetchCandidates = fetches
										.Where(a => a.Id == pushValue && a.Name == previousRow[2] && (a.Handler == currentEventName || a.Handler == "default"))
										.ToList();
									if (fetchCandidates.Count == 0)
									{
										fetches.Add(new AiFetch { Id = pushValue, Name = previousRow[2], Handler = currentEventName });
									}
								}
							}
						}
					}

					// func_call 184549715     //  func[GetSSQStatus]
					if (row.StartsWith("func_call "))
					{
						if (checkFuncs)
						{
							string[] tmpSplit = row.Split(_splitChars, StringSplitOptions.RemoveEmptyEntries);
							if (funcs.All(a => a.Id != tmpSplit[1]))
							{
								funcs.Add(new AiFunc { Id = tmpSplit[1], Name = NormalizeFuncName(tmpSplit[3]) });
							}
						}
					}

					if (row.StartsWith("shift_sp "))
					{
						if (checkFuncs)
						{
							string[] tmpSplit = row.Split(_splitChars, StringSplitOptions.RemoveEmptyEntries);
							string[] previousRow = cache.GetPrevious().Split(_splitChars, StringSplitOptions.RemoveEmptyEntries);

							if (previousRow[0] == "func_call")
							{
								var updatedFunc = funcs.Single(a => a.Id == previousRow[1]);
								updatedFunc.Params = Convert.ToInt32(tmpSplit[1].Replace("-", ""));
							}
						}
					}
				}
			}

			string summary = "Collecting completed.";
			if (checkHandlers)
			{
				summary += $"\r\nFound {handlers.Count} handlers.";
			}
			if (checkPushEvents)
			{
				summary += $"\r\nFound {events.Count} push_events.";
			}
			if (checkFetchs)
			{
				summary += $"\r\nFound {fetches.Count} fetches.";
			}
			if (checkFuncs)
			{
				summary += $"\r\nFound {funcs.Count} functions.";
			}
			MessageBox.Show(summary, "Collecting", MessageBoxButtons.OK, MessageBoxIcon.Information);

			// --- HANDLER SAVING
			WriteHandlers(handlers, "ai_handlers.txt");
			WriteEvents(events, "ai_events.txt");
			WriteFetches(fetches, "ai_fetch_i.txt");
			WriteFuncs(funcs, "ai_functions.txt");
			// --- HANDLER SAVING
		}

		private void WriteHandlers(List<AiHandler> handlers, string handlerFile)
		{
			if (!handlers.Any()) return;

			using (var outFile = new StreamWriter(handlerFile, false, Encoding.Default))
			{
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)");
				outFile.WriteLine("// AI Decompiler 'HANDLER' list");
				outFile.WriteLine("// updated: " + DateTime.Now);
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// format:");
				outFile.WriteLine("// id|class type|name");

				// 0|1|NO_DESIRE
				foreach (AiHandler handler in handlers.OrderBy(a => a.ClassType).ThenBy(a => Int32.Parse(a.Id)))
				{
					outFile.WriteLine($"{handler.Id}|{handler.ClassType}|{handler.Name}");
				}
			}
		}

		private void WriteEvents(List<AiEvent> events, string eventsFile)
		{
			if (!events.Any()) return;

			using (var outFile = new StreamWriter(eventsFile, false, Encoding.Default))
			{
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)");
				outFile.WriteLine("// AI Decompiler 'push_event' list");
				outFile.WriteLine("// updated: " + DateTime.Now);
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// format:");
				outFile.WriteLine("// id|handler|name");

				foreach (AiEvent aiEvent in events.OrderBy(a => int.Parse(a.Id)))
				{
					outFile.WriteLine($"{aiEvent.Id}|{aiEvent.Handler}|{aiEvent.Name}");
				}
			}
		}

		private void WriteFetches(List<AiFetch> fetches, string fetchesFile)
		{
			if (!fetches.Any()) return;

			using (var outFile = new StreamWriter(fetchesFile, false, Encoding.Default))
			{
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)");
				outFile.WriteLine("// AI Decompiler 'fetch_i' list");
				outFile.WriteLine("// updated: " + DateTime.Now);
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// format:");
				outFile.WriteLine("// id|event|name");

				foreach (AiFetch aiFetch in fetches.OrderBy(a => Int32.Parse(a.Id)))
				{
					outFile.WriteLine($"{aiFetch.Id}|{aiFetch.Handler}|{aiFetch.Name}");
				}
			}
		}

		private void WriteFuncs(List<AiFunc> funcs, string funcsFile)
		{
			if (!funcs.Any()) return;

			using (var outFile = new StreamWriter(funcsFile, false, Encoding.Default, 1))
			{
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)");
				outFile.WriteLine("// AI Decompiler 'FUNC' list");
				outFile.WriteLine("// updated: " + DateTime.Now);
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// format:");
				outFile.WriteLine("// id|name|incoming_params_value");

				// 167837696|GetSpawnDefine|1
				foreach (AiFunc func in funcs.OrderBy(a => Int32.Parse(a.Id)))
				{
					outFile.WriteLine($"{func.Id}|{func.Name},{func.Params}");
				}
			}
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private static string NormalizeFuncName(string raw)
		{
			return raw.Replace("func[", "").Replace("]", "");
		}

		private class ReadableLimitedSizeStack<T> : LimitedSizeStack<T>
		{
			public ReadableLimitedSizeStack(int limit) : base(limit)
			{
			}

			public IEnumerable<T> GetLast(int amount)
			{
				int availableItems = base.Count > amount ? amount : base.Count;
				StackItem<T> current = null;
				for (int i = availableItems - 1; i >= 0; i--)
				{
					current = current == null ? base.Last : current.Before;
					yield return current.Value;
				}
			}

			public T GetPrevious()
			{
				return GetLast(2).Skip(1).First();
			}
		}
	}
}