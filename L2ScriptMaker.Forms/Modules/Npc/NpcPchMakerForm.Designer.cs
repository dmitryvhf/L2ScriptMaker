namespace L2ScriptMaker.Forms.Modules.Npc
{
	partial class NpcPchMakerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.StopError = new System.Windows.Forms.CheckBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.Label1 = new System.Windows.Forms.Label();
			this.NpcCacheScript = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// StopError
			// 
			this.StopError.AutoSize = true;
			this.StopError.Checked = true;
			this.StopError.CheckState = System.Windows.Forms.CheckState.Checked;
			this.StopError.Location = new System.Drawing.Point(178, 16);
			this.StopError.Name = "StopError";
			this.StopError.Size = new System.Drawing.Size(87, 17);
			this.StopError.TabIndex = 51;
			this.StopError.Text = "Stop on error";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(241, 55);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(97, 13);
			this.Label1.TabIndex = 54;
			this.Label1.Text = "(support C4 scripts)";
			// 
			// NpcCacheScript
			// 
			this.NpcCacheScript.Location = new System.Drawing.Point(12, 41);
			this.NpcCacheScript.Name = "NpcCacheScript";
			this.NpcCacheScript.Size = new System.Drawing.Size(160, 23);
			this.NpcCacheScript.TabIndex = 53;
			this.NpcCacheScript.Text = "Generate CacheScript";
			this.NpcCacheScript.Click += new System.EventHandler(this.NpcCacheScript_Click);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(241, 42);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(141, 16);
			this.Label2.TabIndex = 52;
			this.Label2.Text = "NPC_Pch/Pch2 Maker";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(12, 69);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(369, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 48;
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(290, 12);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(91, 23);
			this.ButtonQuit.TabIndex = 50;
			this.ButtonQuit.Text = "Exit";
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(12, 12);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(160, 23);
			this.StartButton.TabIndex = 49;
			this.StartButton.Text = "Generate Pch/Pch2";
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// NpcPchMaker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(393, 105);
			this.Controls.Add(this.StopError);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.NpcCacheScript);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.StartButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcPchMaker";
			this.Text = "NpcPchMaker";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.CheckBox StopError;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button NpcCacheScript;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button StartButton;
	}
}