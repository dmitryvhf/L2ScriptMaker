using L2ScriptMaker.Extensions.VbCompatibleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2ScriptMaker.Modules.Others
{
	public partial class SQLForms : Form
	{
		public SQLForms()
		{
			InitializeComponent();
		}

		private string sQueryFile;

		private void CheckConnButton_Click(object sender, EventArgs e)
		{
			var sqlcon = new System.Data.SqlClient.SqlConnection();
			bool CheckFlag = true;

			if (IntegratedSecurityCheckBox.Checked == true)
				sqlcon.ConnectionString = "Data Source=" + SQLSrvNameTextBox.Text + ";Integrated Security=true;";
			else
				sqlcon.ConnectionString = "Data Source=" + SQLSrvNameTextBox.Text + ";User ID =" + SQLUserTextBox.Text + ";Password=" + SQLPasswordMaskedTextBox.Text + ";";

			try
			{
				sqlcon.Open();
			}
			catch (Exception ex)
			{
				sqlcon.Close();
				MessageBox.Show(ex.Message);
				CheckFlag = false;
			}

			MessageBox.Show("Connection to server '" + SQLSrvNameTextBox.Text.ToUpper() + "' - " + (CheckFlag == true, "Success", "Failed"),
				"Checking result", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void QueryButton_Click(object sender, EventArgs e)
		{
			var sqlcon = new System.Data.SqlClient.SqlConnection();
			string sqlqueryString;
			System.Data.SqlClient.SqlCommand sqlcommand;
			System.Data.SqlClient.SqlDataReader reader;

			if (IntegratedSecurityCheckBox.Checked == true)
				sqlcon.ConnectionString = "Data Source=" + SQLSrvNameTextBox.Text + ";Database=" + SQLDBNameTextBox.Text + ";Integrated Security=true;";
			else
				sqlcon.ConnectionString = "Data Source=" + SQLSrvNameTextBox.Text + ";Database=" + SQLDBNameTextBox.Text + ";User ID =" + SQLUserTextBox.Text + ";Password=" + SQLPasswordMaskedTextBox.Text + ";";

			if (string.IsNullOrEmpty(SQLQueryTextBox.Text.Trim()))
			{
				MessageBox.Show("Must have any SQL query in query window and try again.", "No query", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


			// Query rebuilding
			int iDataGrid;
			string sSQLQuery = SQLQueryTextBox.Text;
			var loopTo = DataGridView1.RowCount - 2;
			// '[{account_name}]
			for (iDataGrid = 0; iDataGrid <= loopTo; iDataGrid++)
				sSQLQuery = sSQLQuery.Replace(DataGridView1[0, iDataGrid].Value.ToString(), DataGridView1[1, iDataGrid].Value.ToString());

			// sqlqueryString = SQLQueryTextBox.Text
			sqlqueryString = sSQLQuery;
			sqlcommand = new System.Data.SqlClient.SqlCommand(sqlqueryString, sqlcon);

			// SQLQueryTextBox.Text = ""
			try
			{
				sqlcon.Open();
			}
			catch (Exception ex)
			{
				sqlcon.Close();
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				reader = sqlcommand.ExecuteReader();
				reader.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "Your query is:" + Constants.vbNewLine + sSQLQuery);
				return;
			}


			QueryResultTextBox.Clear();
			QueryResultTextBox.AppendText("ServerVersion: " + sqlcon.ServerVersion + Constants.vbNewLine);
			QueryResultTextBox.AppendText("DataSource: " + sqlcon.DataSource + Constants.vbNewLine);
			QueryResultTextBox.AppendText("Database: " + sqlcon.Database + Constants.vbNewLine);
			QueryResultTextBox.AppendText(Constants.vbNewLine);

			int ReadCount = 0;
			if (reader.RecordsAffected == -1)
			{
				var QueryData = new DataTable();
				var QueryDA = new System.Data.SqlClient.SqlDataAdapter(sSQLQuery, sqlcon);
				try
				{
					ReadCount = QueryDA.Fill(QueryData);
				}
				catch (Exception ex)
				{
					sqlcon.Close();
					MessageBox.Show(ex.Message + "Your query is:" + Constants.vbNewLine + sSQLQuery);
					sqlcon.Close();
					return;
				}
				SQLDataGridView.DataSource = QueryData;
			}

			sqlcon.Close();
			QueryResultTextBox.AppendText(Constants.vbNewLine);
			QueryResultTextBox.AppendText("Readed of '" + Conversions.ToString(ReadCount) + "' lines" + Constants.vbNewLine + "Affected of '" + Conversions.ToString(reader.RecordsAffected) + "' lines");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void IntegratedSecurityCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (IntegratedSecurityCheckBox.Checked == true)
			{
				SQLUserTextBox.ReadOnly = true;
				SQLPasswordMaskedTextBox.ReadOnly = true;
			}
			else
			{
				SQLUserTextBox.ReadOnly = false;
				SQLPasswordMaskedTextBox.ReadOnly = false;
			}
		}

		private void LoadQueryButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog.Filter = "L2ScriptMaker SQL Query (*.l2smsql)|*.l2smsql|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			string sTemp;
			string[] aTemp;
			SQLQueryTextBox.Text = "";
			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			DataGridView1.Rows.Clear();

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
				{
					if (sTemp.StartsWith("[Values]") == true)
					{
						sTemp = inFile.ReadLine();
						while ((sTemp ?? "") != "[ValuesEnd]")
						{
							if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
							{
								aTemp = sTemp.Split((char)9);
								DataGridView1.Rows.Add(aTemp[0], aTemp[1]);
								sTemp = inFile.ReadLine();
							}
						}
					}

					if (sTemp.StartsWith("[Query]") == true)
					{
						sTemp = inFile.ReadLine();
						while ((sTemp ?? "") != "[QueryEnd]")
						{
							// If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then
							SQLQueryTextBox.AppendText(sTemp + Constants.vbNewLine);
							sTemp = inFile.ReadLine();
						}
					}
				}
			}
			inFile.Close();

			sQueryFile = OpenFileDialog.FileName;
		}

		private void SaveQueryButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog.Title = "Save current query to file...";
			SaveFileDialog.FileName = sQueryFile;
			SaveFileDialog.Filter = "L2ScriptMaker SQL Query (*.l2smsql)|*.l2smsql|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode, 1);

			int iDataGrid;

			outFile.WriteLine("L2ScriptMaker: SQL Query Template Manager");
			outFile.WriteLine("Generated at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine);

			outFile.WriteLine("[Values]");
			var loopTo = DataGridView1.RowCount - 2;
			for (iDataGrid = 0; iDataGrid <= loopTo; iDataGrid++)
				outFile.WriteLine(DataGridView1[0, iDataGrid].Value.ToString() + Constants.vbTab + DataGridView1[1, iDataGrid].Value.ToString());
			outFile.WriteLine("[ValuesEnd]");
			outFile.WriteLine();
			outFile.WriteLine("[Query]");
			outFile.WriteLine(SQLQueryTextBox.Text);
			outFile.WriteLine("[QueryEnd]");

			outFile.Close();

			MessageBox.Show("New SQL Query script saved success.");
			sQueryFile = SaveFileDialog.FileName;
		}


		private void LoadConSetButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog.Filter = "L2ScriptMaker SQL Query Connection Settings (*.l2smsqlini)|*.l2smsqlini|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			string sTemp;
			string[] aTemp;
			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			if ((inFile.ReadLine() ?? "") != "[L2ScriptMaker SQL Query Connection Settings]")
			{
				MessageBox.Show("File is not 'L2ScriptMaker SQL Query Connection Settings' file.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				inFile.Close();
				return;
			}

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
				{
					aTemp = sTemp.Split(Conversions.ToChar("="));
					if (aTemp.Length < 2)
					{
						MessageBox.Show("File is not 'L2ScriptMaker SQL Query Connection Settings' file.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error);
						inFile.Close();
						return;
					}
					try
					{
						switch (aTemp[0])
						{
							case "SQLServerAddress":
								{
									SQLSrvNameTextBox.Text = aTemp[1];
									break;
								}

							case "IntegratedSecurity":
								{
									IntegratedSecurityCheckBox.Checked = Conversions.ToBoolean(aTemp[1]);
									break;
								}

							case "SQLUserName":
								{
									SQLUserTextBox.Text = aTemp[1];
									break;
								}

							case "SQLUserPassword":
								{
									SQLPasswordMaskedTextBox.Text = aTemp[1];
									break;
								}

							case "Database":
								{
									SQLDBNameTextBox.Text = aTemp[1];
									break;
								}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("File is not 'L2ScriptMaker SQL Query Connection Settings' file.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error);
						inFile.Close();
						return;
					}
				}
			}
			inFile.Close();
		}

		private void SaveConSetButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog.Filter = "L2ScriptMaker SQL Query Connection Settings (*.l2smsqlini)|*.l2smsqlini|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode, 1);
			outFile.WriteLine("[L2ScriptMaker SQL Query Connection Settings]");
			outFile.WriteLine("SQLServerAddress=" + SQLSrvNameTextBox.Text);
			outFile.WriteLine("IntegratedSecurity=" + IntegratedSecurityCheckBox.Checked.ToString());
			outFile.WriteLine("SQLUserName=" + SQLUserTextBox.Text);
			outFile.WriteLine("SQLUserPassword=" + SQLPasswordMaskedTextBox.Text);
			outFile.WriteLine("Database=" + SQLDBNameTextBox.Text);
			outFile.Close();
			MessageBox.Show("New SQL Query Connection Settings saved success.");
		}
	}
}
