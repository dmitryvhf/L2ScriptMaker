namespace L2ScriptMaker.Modules.Others
{
	partial class HtmlMissedFinder
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtmlMissedFinder));
			this.CreateHtmBox = new System.Windows.Forms.CheckBox();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.HtmlDirCheckBox = new System.Windows.Forms.CheckBox();
			this.WriteFullCheckBox = new System.Windows.Forms.CheckBox();
			this.IgnoreMissDupCheckBox = new System.Windows.Forms.CheckBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.CurActionLabel = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.TabPage1.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// CreateHtmBox
			// 
			this.CreateHtmBox.AutoSize = true;
			this.CreateHtmBox.Location = new System.Drawing.Point(6, 61);
			this.CreateHtmBox.Name = "CreateHtmBox";
			this.CreateHtmBox.Size = new System.Drawing.Size(114, 17);
			this.CreateHtmBox.TabIndex = 67;
			this.CreateHtmBox.Text = "Create missed html";
			this.CreateHtmBox.UseVisualStyleBackColor = true;
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.CheckedListBox);
			this.TabPage1.Controls.Add(this.HtmlDirCheckBox);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(148, 81);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Check items";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// CheckedListBox
			// 
			this.CheckedListBox.FormattingEnabled = true;
			this.CheckedListBox.Items.AddRange(new object[] {
            "ai.obj",
            "npcdata.txt",
            "itemdata.txt"});
			this.CheckedListBox.Location = new System.Drawing.Point(6, 9);
			this.CheckedListBox.Name = "CheckedListBox";
			this.CheckedListBox.Size = new System.Drawing.Size(89, 49);
			this.CheckedListBox.TabIndex = 63;
			// 
			// HtmlDirCheckBox
			// 
			this.HtmlDirCheckBox.AutoSize = true;
			this.HtmlDirCheckBox.Location = new System.Drawing.Point(9, 61);
			this.HtmlDirCheckBox.Name = "HtmlDirCheckBox";
			this.HtmlDirCheckBox.Size = new System.Drawing.Size(79, 17);
			this.HtmlDirCheckBox.TabIndex = 64;
			this.HtmlDirCheckBox.Text = "Html Folder";
			this.HtmlDirCheckBox.UseVisualStyleBackColor = true;
			// 
			// WriteFullCheckBox
			// 
			this.WriteFullCheckBox.AutoSize = true;
			this.WriteFullCheckBox.Location = new System.Drawing.Point(6, 6);
			this.WriteFullCheckBox.Name = "WriteFullCheckBox";
			this.WriteFullCheckBox.Size = new System.Drawing.Size(120, 17);
			this.WriteFullCheckBox.TabIndex = 65;
			this.WriteFullCheckBox.Text = "Write full debug info";
			this.WriteFullCheckBox.UseVisualStyleBackColor = true;
			// 
			// IgnoreMissDupCheckBox
			// 
			this.IgnoreMissDupCheckBox.AutoSize = true;
			this.IgnoreMissDupCheckBox.Checked = true;
			this.IgnoreMissDupCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.IgnoreMissDupCheckBox.Location = new System.Drawing.Point(6, 25);
			this.IgnoreMissDupCheckBox.Name = "IgnoreMissDupCheckBox";
			this.IgnoreMissDupCheckBox.Size = new System.Drawing.Size(102, 30);
			this.IgnoreMissDupCheckBox.TabIndex = 66;
			this.IgnoreMissDupCheckBox.Text = "Ignore duplicate\r\nmissed html";
			this.IgnoreMissDupCheckBox.UseVisualStyleBackColor = true;
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(126, 40);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(156, 107);
			this.TabControl1.TabIndex = 76;
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.CreateHtmBox);
			this.TabPage2.Controls.Add(this.WriteFullCheckBox);
			this.TabPage2.Controls.Add(this.IgnoreMissDupCheckBox);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(148, 81);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Options";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// CurActionLabel
			// 
			this.CurActionLabel.AutoSize = true;
			this.CurActionLabel.Location = new System.Drawing.Point(12, 192);
			this.CurActionLabel.Name = "CurActionLabel";
			this.CurActionLabel.Size = new System.Drawing.Size(0, 13);
			this.CurActionLabel.TabIndex = 75;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(12, 179);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(91, 13);
			this.Label1.TabIndex = 74;
			this.Label1.Text = "Current action:";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(12, 208);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(270, 23);
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 69;
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(207, 153);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 73;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(126, 153);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 72;
			this.ButtonStart.Text = "Start";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(154, 21);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 71;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(154, 5);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(128, 16);
			this.Label2.TabIndex = 70;
			this.Label2.Text = "Missed Html Finder";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 18);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 158);
			this.PictureBox1.TabIndex = 68;
			this.PictureBox1.TabStop = false;
			// 
			// HtmlMissedFinder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 236);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.CurActionLabel);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "HtmlMissedFinder";
			this.Text = "Html Missed Finder";
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.CheckBox CreateHtmBox;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.CheckedListBox CheckedListBox;
		internal System.Windows.Forms.CheckBox HtmlDirCheckBox;
		internal System.Windows.Forms.CheckBox WriteFullCheckBox;
		internal System.Windows.Forms.CheckBox IgnoreMissDupCheckBox;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Label CurActionLabel;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}