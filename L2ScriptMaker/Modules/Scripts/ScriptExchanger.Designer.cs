namespace L2ScriptMaker.Modules.Scripts
{
	partial class ScriptExchanger
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptExchanger));
			this.IsSkillAquire = new System.Windows.Forms.ComboBox();
			this.DuplicateCheckBox = new System.Windows.Forms.CheckBox();
			this.DoIgnore = new System.Windows.Forms.CheckBox();
			this.DoSkill = new System.Windows.Forms.CheckBox();
			this.DoNpc = new System.Windows.Forms.CheckBox();
			this.DoItem = new System.Windows.Forms.CheckBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.TimeEnd = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.TimeStart = new System.Windows.Forms.TextBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.ButtonImport = new System.Windows.Forms.Button();
			this.ButtonExport = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.FilePos = new System.Windows.Forms.ProgressBar();
			this.ButtonLoadItem = new System.Windows.Forms.Button();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.StatusBox = new System.Windows.Forms.TextBox();
			this.ButtonQuit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// IsSkillAquire
			// 
			this.IsSkillAquire.FormattingEnabled = true;
			this.IsSkillAquire.Items.AddRange(new object[] {
            "Is Another script",
            "Is SkillData"});
			this.IsSkillAquire.Location = new System.Drawing.Point(262, 210);
			this.IsSkillAquire.Name = "IsSkillAquire";
			this.IsSkillAquire.Size = new System.Drawing.Size(121, 21);
			this.IsSkillAquire.TabIndex = 54;
			this.IsSkillAquire.Text = "Is Another script";
			// 
			// DuplicateCheckBox
			// 
			this.DuplicateCheckBox.AutoSize = true;
			this.DuplicateCheckBox.Location = new System.Drawing.Point(186, 154);
			this.DuplicateCheckBox.Name = "DuplicateCheckBox";
			this.DuplicateCheckBox.Size = new System.Drawing.Size(104, 17);
			this.DuplicateCheckBox.TabIndex = 53;
			this.DuplicateCheckBox.Text = "Duplicate check";
			this.DuplicateCheckBox.UseVisualStyleBackColor = true;
			// 
			// DoIgnore
			// 
			this.DoIgnore.AutoSize = true;
			this.DoIgnore.Location = new System.Drawing.Point(262, 183);
			this.DoIgnore.Name = "DoIgnore";
			this.DoIgnore.Size = new System.Drawing.Size(80, 17);
			this.DoIgnore.TabIndex = 52;
			this.DoIgnore.Text = "Ignore error";
			this.DoIgnore.UseVisualStyleBackColor = true;
			// 
			// DoSkill
			// 
			this.DoSkill.AutoSize = true;
			this.DoSkill.Checked = true;
			this.DoSkill.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DoSkill.Location = new System.Drawing.Point(186, 215);
			this.DoSkill.Name = "DoSkill";
			this.DoSkill.Size = new System.Drawing.Size(52, 17);
			this.DoSkill.TabIndex = 51;
			this.DoSkill.Text = "Skill\'s";
			this.DoSkill.UseVisualStyleBackColor = true;
			// 
			// DoNpc
			// 
			this.DoNpc.AutoSize = true;
			this.DoNpc.Checked = true;
			this.DoNpc.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DoNpc.Location = new System.Drawing.Point(186, 199);
			this.DoNpc.Name = "DoNpc";
			this.DoNpc.Size = new System.Drawing.Size(53, 17);
			this.DoNpc.TabIndex = 50;
			this.DoNpc.Text = "Npc\'s";
			this.DoNpc.UseVisualStyleBackColor = true;
			// 
			// DoItem
			// 
			this.DoItem.AutoSize = true;
			this.DoItem.Checked = true;
			this.DoItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DoItem.Location = new System.Drawing.Point(186, 183);
			this.DoItem.Name = "DoItem";
			this.DoItem.Size = new System.Drawing.Size(53, 17);
			this.DoItem.TabIndex = 49;
			this.DoItem.Text = "Item\'s";
			this.DoItem.UseVisualStyleBackColor = true;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(364, 181);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(51, 13);
			this.Label4.TabIndex = 48;
			this.Label4.Text = "End time:";
			// 
			// TimeEnd
			// 
			this.TimeEnd.Location = new System.Drawing.Point(424, 178);
			this.TimeEnd.Name = "TimeEnd";
			this.TimeEnd.ReadOnly = true;
			this.TimeEnd.Size = new System.Drawing.Size(140, 20);
			this.TimeEnd.TabIndex = 47;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(364, 155);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(54, 13);
			this.Label3.TabIndex = 46;
			this.Label3.Text = "Start time:";
			// 
			// TimeStart
			// 
			this.TimeStart.Location = new System.Drawing.Point(424, 152);
			this.TimeStart.Name = "TimeStart";
			this.TimeStart.ReadOnly = true;
			this.TimeStart.Size = new System.Drawing.Size(140, 20);
			this.TimeStart.TabIndex = 45;
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(10, 8);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(87, 201);
			this.PictureBox1.TabIndex = 44;
			this.PictureBox1.TabStop = false;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(105, 14);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(118, 13);
			this.Label2.TabIndex = 43;
			this.Label2.Text = "Current text in progress:";
			// 
			// ButtonImport
			// 
			this.ButtonImport.Location = new System.Drawing.Point(105, 179);
			this.ButtonImport.Name = "ButtonImport";
			this.ButtonImport.Size = new System.Drawing.Size(75, 23);
			this.ButtonImport.TabIndex = 42;
			this.ButtonImport.Text = "Import";
			this.ButtonImport.UseVisualStyleBackColor = true;
			this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
			// 
			// ButtonExport
			// 
			this.ButtonExport.Location = new System.Drawing.Point(105, 208);
			this.ButtonExport.Name = "ButtonExport";
			this.ButtonExport.Size = new System.Drawing.Size(75, 23);
			this.ButtonExport.TabIndex = 41;
			this.ButtonExport.Text = "Export";
			this.ButtonExport.UseVisualStyleBackColor = true;
			this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(105, 120);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(51, 13);
			this.Label1.TabIndex = 40;
			this.Label1.Text = "Progress:";
			// 
			// FilePos
			// 
			this.FilePos.Location = new System.Drawing.Point(162, 120);
			this.FilePos.Name = "FilePos";
			this.FilePos.Size = new System.Drawing.Size(402, 23);
			this.FilePos.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.FilePos.TabIndex = 38;
			// 
			// ButtonLoadItem
			// 
			this.ButtonLoadItem.Location = new System.Drawing.Point(105, 150);
			this.ButtonLoadItem.Name = "ButtonLoadItem";
			this.ButtonLoadItem.Size = new System.Drawing.Size(75, 23);
			this.ButtonLoadItem.TabIndex = 36;
			this.ButtonLoadItem.Text = "Load Pch";
			this.ButtonLoadItem.UseVisualStyleBackColor = true;
			this.ButtonLoadItem.Click += new System.EventHandler(this.ButtonLoadItem_Click);
			// 
			// StatusBox
			// 
			this.StatusBox.Location = new System.Drawing.Point(105, 30);
			this.StatusBox.Multiline = true;
			this.StatusBox.Name = "StatusBox";
			this.StatusBox.Size = new System.Drawing.Size(459, 84);
			this.StatusBox.TabIndex = 39;
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(489, 208);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 37;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ScriptExchanger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 241);
			this.Controls.Add(this.IsSkillAquire);
			this.Controls.Add(this.DuplicateCheckBox);
			this.Controls.Add(this.DoIgnore);
			this.Controls.Add(this.DoSkill);
			this.Controls.Add(this.DoNpc);
			this.Controls.Add(this.DoItem);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.TimeEnd);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.TimeStart);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ButtonImport);
			this.Controls.Add(this.ButtonExport);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.FilePos);
			this.Controls.Add(this.ButtonLoadItem);
			this.Controls.Add(this.StatusBox);
			this.Controls.Add(this.ButtonQuit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ScriptExchanger";
			this.Text = "ScriptExchanger";
			this.Load += new System.EventHandler(this.ScriptExchanger_Load);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ComboBox IsSkillAquire;
		internal System.Windows.Forms.CheckBox DuplicateCheckBox;
		internal System.Windows.Forms.CheckBox DoIgnore;
		internal System.Windows.Forms.CheckBox DoSkill;
		internal System.Windows.Forms.CheckBox DoNpc;
		internal System.Windows.Forms.CheckBox DoItem;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox TimeEnd;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox TimeStart;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button ButtonImport;
		internal System.Windows.Forms.Button ButtonExport;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ProgressBar FilePos;
		internal System.Windows.Forms.Button ButtonLoadItem;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.TextBox StatusBox;
		internal System.Windows.Forms.Button ButtonQuit;
	}
}