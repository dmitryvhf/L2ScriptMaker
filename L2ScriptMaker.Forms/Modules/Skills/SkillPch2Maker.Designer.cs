namespace L2ScriptMaker.Forms.Modules.Skills
{
	partial class SkillPch2Maker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillPch2Maker));
			this.AbnormalListTextBox = new System.Windows.Forms.TextBox();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.LoadAbListButton = new System.Windows.Forms.Button();
			this.La2GuardAttrCheckBox = new System.Windows.Forms.CheckBox();
			this.CheckBoxAsIs = new System.Windows.Forms.CheckBox();
			this.CheckBoxKamaelIDStandart = new System.Windows.Forms.CheckBox();
			this.IgnoreCustomAbnormalsCheckBox = new System.Windows.Forms.CheckBox();
			this.UseCustomAbnormalsCheckBox = new System.Windows.Forms.CheckBox();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.StartButton = new System.Windows.Forms.Button();
			this.SkillCacheScript = new System.Windows.Forms.Button();
			this.IgnoreCustomSkillBox = new System.Windows.Forms.CheckBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.QuitButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.TabPage2.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// AbnormalListTextBox
			// 
			this.AbnormalListTextBox.Location = new System.Drawing.Point(6, 6);
			this.AbnormalListTextBox.Multiline = true;
			this.AbnormalListTextBox.Name = "AbnormalListTextBox";
			this.AbnormalListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.AbnormalListTextBox.Size = new System.Drawing.Size(236, 93);
			this.AbnormalListTextBox.TabIndex = 0;
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.LoadAbListButton);
			this.TabPage2.Controls.Add(this.AbnormalListTextBox);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(329, 105);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Custom AbNormal/Attribute List";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// LoadAbListButton
			// 
			this.LoadAbListButton.Location = new System.Drawing.Point(248, 6);
			this.LoadAbListButton.Name = "LoadAbListButton";
			this.LoadAbListButton.Size = new System.Drawing.Size(75, 23);
			this.LoadAbListButton.TabIndex = 1;
			this.LoadAbListButton.Text = "Load List";
			this.LoadAbListButton.UseVisualStyleBackColor = true;
			this.LoadAbListButton.Click += new System.EventHandler(this.LoadAbListButton_Click);
			// 
			// La2GuardAttrCheckBox
			// 
			this.La2GuardAttrCheckBox.AutoSize = true;
			this.La2GuardAttrCheckBox.Checked = true;
			this.La2GuardAttrCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.La2GuardAttrCheckBox.Location = new System.Drawing.Point(6, 33);
			this.La2GuardAttrCheckBox.Name = "La2GuardAttrCheckBox";
			this.La2GuardAttrCheckBox.Size = new System.Drawing.Size(119, 17);
			this.La2GuardAttrCheckBox.TabIndex = 52;
			this.La2GuardAttrCheckBox.Text = "La2Guard attributes";
			this.La2GuardAttrCheckBox.UseVisualStyleBackColor = true;
			// 
			// CheckBoxAsIs
			// 
			this.CheckBoxAsIs.AutoSize = true;
			this.CheckBoxAsIs.Checked = true;
			this.CheckBoxAsIs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxAsIs.Location = new System.Drawing.Point(142, 56);
			this.CheckBoxAsIs.Name = "CheckBoxAsIs";
			this.CheckBoxAsIs.Size = new System.Drawing.Size(110, 17);
			this.CheckBoxAsIs.TabIndex = 51;
			this.CheckBoxAsIs.Text = "Use name \"As-Is\"";
			this.CheckBoxAsIs.UseVisualStyleBackColor = true;
			// 
			// CheckBoxKamaelIDStandart
			// 
			this.CheckBoxKamaelIDStandart.AutoSize = true;
			this.CheckBoxKamaelIDStandart.Checked = true;
			this.CheckBoxKamaelIDStandart.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxKamaelIDStandart.Location = new System.Drawing.Point(142, 33);
			this.CheckBoxKamaelIDStandart.Name = "CheckBoxKamaelIDStandart";
			this.CheckBoxKamaelIDStandart.Size = new System.Drawing.Size(116, 17);
			this.CheckBoxKamaelIDStandart.TabIndex = 50;
			this.CheckBoxKamaelIDStandart.Text = "Kamael ID standart";
			this.CheckBoxKamaelIDStandart.UseVisualStyleBackColor = true;
			// 
			// IgnoreCustomAbnormalsCheckBox
			// 
			this.IgnoreCustomAbnormalsCheckBox.AutoSize = true;
			this.IgnoreCustomAbnormalsCheckBox.Location = new System.Drawing.Point(142, 79);
			this.IgnoreCustomAbnormalsCheckBox.Name = "IgnoreCustomAbnormalsCheckBox";
			this.IgnoreCustomAbnormalsCheckBox.Size = new System.Drawing.Size(159, 17);
			this.IgnoreCustomAbnormalsCheckBox.TabIndex = 49;
			this.IgnoreCustomAbnormalsCheckBox.Text = "Set unknown abnormal to -1";
			this.IgnoreCustomAbnormalsCheckBox.UseVisualStyleBackColor = true;
			// 
			// UseCustomAbnormalsCheckBox
			// 
			this.UseCustomAbnormalsCheckBox.AutoSize = true;
			this.UseCustomAbnormalsCheckBox.Checked = true;
			this.UseCustomAbnormalsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.UseCustomAbnormalsCheckBox.Enabled = false;
			this.UseCustomAbnormalsCheckBox.Location = new System.Drawing.Point(142, 10);
			this.UseCustomAbnormalsCheckBox.Name = "UseCustomAbnormalsCheckBox";
			this.UseCustomAbnormalsCheckBox.Size = new System.Drawing.Size(143, 17);
			this.UseCustomAbnormalsCheckBox.TabIndex = 48;
			this.UseCustomAbnormalsCheckBox.Text = "Use custom abnormal list";
			this.UseCustomAbnormalsCheckBox.UseVisualStyleBackColor = true;
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.La2GuardAttrCheckBox);
			this.TabPage1.Controls.Add(this.CheckBoxAsIs);
			this.TabPage1.Controls.Add(this.CheckBoxKamaelIDStandart);
			this.TabPage1.Controls.Add(this.IgnoreCustomAbnormalsCheckBox);
			this.TabPage1.Controls.Add(this.UseCustomAbnormalsCheckBox);
			this.TabPage1.Controls.Add(this.StartButton);
			this.TabPage1.Controls.Add(this.SkillCacheScript);
			this.TabPage1.Controls.Add(this.IgnoreCustomSkillBox);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(329, 105);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Use Page";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(6, 6);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(127, 23);
			this.StartButton.TabIndex = 2;
			this.StartButton.Text = "Generate Pch/Pch2";
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// SkillCacheScript
			// 
			this.SkillCacheScript.Location = new System.Drawing.Point(6, 52);
			this.SkillCacheScript.Name = "SkillCacheScript";
			this.SkillCacheScript.Size = new System.Drawing.Size(127, 23);
			this.SkillCacheScript.TabIndex = 45;
			this.SkillCacheScript.Text = "Generate CacheScript";
			this.SkillCacheScript.Click += new System.EventHandler(this.SkillCacheScript_Click);
			// 
			// IgnoreCustomSkillBox
			// 
			this.IgnoreCustomSkillBox.AutoSize = true;
			this.IgnoreCustomSkillBox.Location = new System.Drawing.Point(7, 79);
			this.IgnoreCustomSkillBox.Name = "IgnoreCustomSkillBox";
			this.IgnoreCustomSkillBox.Size = new System.Drawing.Size(118, 17);
			this.IgnoreCustomSkillBox.TabIndex = 47;
			this.IgnoreCustomSkillBox.Text = "Ignore custom skills";
			this.IgnoreCustomSkillBox.UseVisualStyleBackColor = true;
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(127, 41);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(337, 131);
			this.TabControl1.TabIndex = 55;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(319, 25);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 53;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(319, 9);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(141, 16);
			this.Label2.TabIndex = 52;
			this.Label2.Text = "Skill Pch/Pch2 Maker";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(11, 178);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(352, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 50;
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(369, 178);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(91, 23);
			this.QuitButton.TabIndex = 51;
			this.QuitButton.Text = "Exit";
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(11, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(110, 160);
			this.PictureBox1.TabIndex = 54;
			this.PictureBox1.TabStop = false;
			// 
			// SkillPch2Maker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 211);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SkillPch2Maker";
			this.Text = "Skill Pch/Pch2 Maker";
			this.Load += new System.EventHandler(this.SkillPch2Maker_Load);
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.TextBox AbnormalListTextBox;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Button LoadAbListButton;
		internal System.Windows.Forms.CheckBox La2GuardAttrCheckBox;
		internal System.Windows.Forms.CheckBox CheckBoxAsIs;
		internal System.Windows.Forms.CheckBox CheckBoxKamaelIDStandart;
		internal System.Windows.Forms.CheckBox IgnoreCustomAbnormalsCheckBox;
		internal System.Windows.Forms.CheckBox UseCustomAbnormalsCheckBox;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.Button SkillCacheScript;
		internal System.Windows.Forms.CheckBox IgnoreCustomSkillBox;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
	}
}