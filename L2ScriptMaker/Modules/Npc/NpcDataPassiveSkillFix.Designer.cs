namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcDataPassiveSkillFix
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcDataPassiveSkillFix));
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.LvlSklBox = new System.Windows.Forms.CheckBox();
			this.SFullMagicDefBox = new System.Windows.Forms.CheckBox();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.SkillIgnorListBox = new System.Windows.Forms.TextBox();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(10, 40);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 61;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(10, 8);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(145, 32);
			this.Label2.TabIndex = 60;
			this.Label2.Text = "NpcData Passive Skill \r\n(\'skill_list\') fix";
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(265, 8);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 59;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(184, 8);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 58;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(13, 56);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(331, 162);
			this.TabControl1.TabIndex = 63;
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.LvlSklBox);
			this.TabPage1.Controls.Add(this.SFullMagicDefBox);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(323, 136);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Inherits options";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// LvlSklBox
			// 
			this.LvlSklBox.AutoSize = true;
			this.LvlSklBox.Checked = true;
			this.LvlSklBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.LvlSklBox.Location = new System.Drawing.Point(6, 6);
			this.LvlSklBox.Name = "LvlSklBox";
			this.LvlSklBox.Size = new System.Drawing.Size(125, 17);
			this.LvlSklBox.TabIndex = 55;
			this.LvlSklBox.Text = "Do Inherits skill_level";
			this.LvlSklBox.UseVisualStyleBackColor = true;
			// 
			// SFullMagicDefBox
			// 
			this.SFullMagicDefBox.AutoSize = true;
			this.SFullMagicDefBox.Checked = true;
			this.SFullMagicDefBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.SFullMagicDefBox.Location = new System.Drawing.Point(6, 29);
			this.SFullMagicDefBox.Name = "SFullMagicDefBox";
			this.SFullMagicDefBox.Size = new System.Drawing.Size(140, 17);
			this.SFullMagicDefBox.TabIndex = 56;
			this.SFullMagicDefBox.Text = "Do Inherits skills from list";
			this.SFullMagicDefBox.UseVisualStyleBackColor = true;
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.SkillIgnorListBox);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(323, 136);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Inherits skills";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// SkillIgnorListBox
			// 
			this.SkillIgnorListBox.Location = new System.Drawing.Point(6, 6);
			this.SkillIgnorListBox.Multiline = true;
			this.SkillIgnorListBox.Name = "SkillIgnorListBox";
			this.SkillIgnorListBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.SkillIgnorListBox.Size = new System.Drawing.Size(311, 124);
			this.SkillIgnorListBox.TabIndex = 0;
			this.SkillIgnorListBox.Text = resources.GetString("SkillIgnorListBox.Text");
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(13, 220);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(331, 23);
			this.ProgressBar.TabIndex = 62;
			// 
			// NpcDataPassiveSkillFix
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 251);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.ProgressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcDataPassiveSkillFix";
			this.Text = "NpcData Passive Skill fixer ";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.CheckBox LvlSklBox;
		internal System.Windows.Forms.CheckBox SFullMagicDefBox;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.TextBox SkillIgnorListBox;
		internal System.Windows.Forms.ProgressBar ProgressBar;
	}
}