namespace L2ScriptMaker.Modules.Scripts
{
	partial class ScriptLeecherOld
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptLeecherOld));
			this.RadioButton1 = new System.Windows.Forms.RadioButton();
			this.SrcSkilldataEButton = new System.Windows.Forms.RadioButton();
			this.SrcSkillgrpButton = new System.Windows.Forms.RadioButton();
			this.ButtonImportList = new System.Windows.Forms.Button();
			this.ButtonDeChkAll = new System.Windows.Forms.Button();
			this.ButtonChkAll = new System.Windows.Forms.Button();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.NpcParam = new System.Windows.Forms.CheckedListBox();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ButtonOpen2 = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.File2 = new System.Windows.Forms.TextBox();
			this.File1 = new System.Windows.Forms.TextBox();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.ButtonOpen1 = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// RadioButton1
			// 
			this.RadioButton1.AutoSize = true;
			this.RadioButton1.Location = new System.Drawing.Point(11, 271);
			this.RadioButton1.Name = "RadioButton1";
			this.RadioButton1.Size = new System.Drawing.Size(87, 17);
			this.RadioButton1.TabIndex = 36;
			this.RadioButton1.TabStop = true;
			this.RadioButton1.Text = "Normal mode";
			this.RadioButton1.UseVisualStyleBackColor = true;
			// 
			// SrcSkilldataEButton
			// 
			this.SrcSkilldataEButton.AutoSize = true;
			this.SrcSkilldataEButton.Location = new System.Drawing.Point(218, 271);
			this.SrcSkilldataEButton.Name = "SrcSkilldataEButton";
			this.SrcSkilldataEButton.Size = new System.Drawing.Size(123, 17);
			this.SrcSkilldataEButton.TabIndex = 35;
			this.SrcSkilldataEButton.TabStop = true;
			this.SrcSkilldataEButton.Text = "Source is SkillData-e";
			this.ToolTip.SetToolTip(this.SrcSkilldataEButton, "Use it only for correct transferring\r\nfull skill names from skilldata-e.");
			this.SrcSkilldataEButton.UseVisualStyleBackColor = true;
			// 
			// SrcSkillgrpButton
			// 
			this.SrcSkillgrpButton.AutoSize = true;
			this.SrcSkillgrpButton.Location = new System.Drawing.Point(104, 271);
			this.SrcSkillgrpButton.Name = "SrcSkillgrpButton";
			this.SrcSkillgrpButton.Size = new System.Drawing.Size(108, 17);
			this.SrcSkillgrpButton.TabIndex = 34;
			this.SrcSkillgrpButton.TabStop = true;
			this.SrcSkillgrpButton.Text = "Source is SkillGrp";
			this.ToolTip.SetToolTip(this.SrcSkillgrpButton, "Use this for correct transferring\r\nmana use params (mp_consume).");
			this.SrcSkillgrpButton.UseVisualStyleBackColor = true;
			// 
			// ButtonImportList
			// 
			this.ButtonImportList.Location = new System.Drawing.Point(391, 97);
			this.ButtonImportList.Name = "ButtonImportList";
			this.ButtonImportList.Size = new System.Drawing.Size(75, 23);
			this.ButtonImportList.TabIndex = 33;
			this.ButtonImportList.Text = "Import List";
			this.ButtonImportList.UseVisualStyleBackColor = true;
			this.ButtonImportList.Click += new System.EventHandler(this.ButtonImportList_Click);
			// 
			// ButtonDeChkAll
			// 
			this.ButtonDeChkAll.Location = new System.Drawing.Point(392, 177);
			this.ButtonDeChkAll.Name = "ButtonDeChkAll";
			this.ButtonDeChkAll.Size = new System.Drawing.Size(75, 23);
			this.ButtonDeChkAll.TabIndex = 32;
			this.ButtonDeChkAll.Text = "Deselect All";
			this.ButtonDeChkAll.UseVisualStyleBackColor = true;
			this.ButtonDeChkAll.Click += new System.EventHandler(this.ButtonDeChkAll_Click);
			// 
			// ButtonChkAll
			// 
			this.ButtonChkAll.Location = new System.Drawing.Point(392, 149);
			this.ButtonChkAll.Name = "ButtonChkAll";
			this.ButtonChkAll.Size = new System.Drawing.Size(75, 23);
			this.ButtonChkAll.TabIndex = 31;
			this.ButtonChkAll.Text = "Checked All";
			this.ButtonChkAll.UseVisualStyleBackColor = true;
			this.ButtonChkAll.Click += new System.EventHandler(this.ButtonChkAll_Click);
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(11, 242);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(455, 23);
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 30;
			// 
			// NpcParam
			// 
			this.NpcParam.FormattingEnabled = true;
			this.NpcParam.Location = new System.Drawing.Point(113, 97);
			this.NpcParam.Name = "NpcParam";
			this.NpcParam.Size = new System.Drawing.Size(273, 139);
			this.NpcParam.TabIndex = 21;
			// 
			// ButtonOpen2
			// 
			this.ButtonOpen2.Location = new System.Drawing.Point(421, 63);
			this.ButtonOpen2.Name = "ButtonOpen2";
			this.ButtonOpen2.Size = new System.Drawing.Size(45, 23);
			this.ButtonOpen2.TabIndex = 29;
			this.ButtonOpen2.Text = "Select";
			this.ButtonOpen2.UseVisualStyleBackColor = true;
			this.ButtonOpen2.Click += new System.EventHandler(this.ButtonOpen2_Click);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(110, 50);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(65, 13);
			this.Label2.TabIndex = 28;
			this.Label2.Text = "Where suck";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(110, 12);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(58, 13);
			this.Label1.TabIndex = 27;
			this.Label1.Text = "Original file";
			// 
			// File2
			// 
			this.File2.Location = new System.Drawing.Point(113, 66);
			this.File2.Name = "File2";
			this.File2.Size = new System.Drawing.Size(303, 20);
			this.File2.TabIndex = 26;
			// 
			// File1
			// 
			this.File1.Location = new System.Drawing.Point(113, 27);
			this.File1.Name = "File1";
			this.File1.Size = new System.Drawing.Size(303, 20);
			this.File1.TabIndex = 25;
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(392, 213);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 24;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(11, 213);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 23;
			this.ButtonStart.Text = "Leaching...";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// ButtonOpen1
			// 
			this.ButtonOpen1.Location = new System.Drawing.Point(421, 24);
			this.ButtonOpen1.Name = "ButtonOpen1";
			this.ButtonOpen1.Size = new System.Drawing.Size(45, 23);
			this.ButtonOpen1.TabIndex = 22;
			this.ButtonOpen1.Text = "Select";
			this.ButtonOpen1.UseVisualStyleBackColor = true;
			this.ButtonOpen1.Click += new System.EventHandler(this.ButtonOpen1_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(11, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(96, 195);
			this.PictureBox1.TabIndex = 20;
			this.PictureBox1.TabStop = false;
			// 
			// ScriptLeecherOld
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 301);
			this.Controls.Add(this.RadioButton1);
			this.Controls.Add(this.SrcSkilldataEButton);
			this.Controls.Add(this.SrcSkillgrpButton);
			this.Controls.Add(this.ButtonImportList);
			this.Controls.Add(this.ButtonDeChkAll);
			this.Controls.Add(this.ButtonChkAll);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.NpcParam);
			this.Controls.Add(this.ButtonOpen2);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.File2);
			this.Controls.Add(this.File1);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.ButtonOpen1);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ScriptLeecherOld";
			this.Text = "Lineage II Script C4 Data Leecher";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.RadioButton RadioButton1;
		internal System.Windows.Forms.RadioButton SrcSkilldataEButton;
		internal System.Windows.Forms.ToolTip ToolTip;
		internal System.Windows.Forms.RadioButton SrcSkillgrpButton;
		internal System.Windows.Forms.Button ButtonImportList;
		internal System.Windows.Forms.Button ButtonDeChkAll;
		internal System.Windows.Forms.Button ButtonChkAll;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.CheckedListBox NpcParam;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Button ButtonOpen2;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox File2;
		internal System.Windows.Forms.TextBox File1;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.Button ButtonOpen1;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}