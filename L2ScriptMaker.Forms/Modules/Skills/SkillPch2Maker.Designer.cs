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
			this.La2GuardAttrCheckBox = new System.Windows.Forms.CheckBox();
			this.CheckBoxAsIs = new System.Windows.Forms.CheckBox();
			this.CheckBoxKamaelIDStandart = new System.Windows.Forms.CheckBox();
			this.IgnoreCustomAbnormalsCheckBox = new System.Windows.Forms.CheckBox();
			this.UseCustomAbnormalsCheckBox = new System.Windows.Forms.CheckBox();
			this.StartButton = new System.Windows.Forms.Button();
			this.SkillCacheScriptButton = new System.Windows.Forms.Button();
			this.IgnoreCustomSkillBox = new System.Windows.Forms.CheckBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.QuitButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// La2GuardAttrCheckBox
			// 
			this.La2GuardAttrCheckBox.AutoSize = true;
			this.La2GuardAttrCheckBox.Enabled = false;
			this.La2GuardAttrCheckBox.Location = new System.Drawing.Point(127, 109);
			this.La2GuardAttrCheckBox.Name = "La2GuardAttrCheckBox";
			this.La2GuardAttrCheckBox.Size = new System.Drawing.Size(119, 17);
			this.La2GuardAttrCheckBox.TabIndex = 52;
			this.La2GuardAttrCheckBox.Text = "La2Guard attributes";
			this.La2GuardAttrCheckBox.UseVisualStyleBackColor = true;
			// 
			// CheckBoxAsIs
			// 
			this.CheckBoxAsIs.AutoSize = true;
			this.CheckBoxAsIs.Enabled = false;
			this.CheckBoxAsIs.Location = new System.Drawing.Point(263, 132);
			this.CheckBoxAsIs.Name = "CheckBoxAsIs";
			this.CheckBoxAsIs.Size = new System.Drawing.Size(110, 17);
			this.CheckBoxAsIs.TabIndex = 51;
			this.CheckBoxAsIs.Text = "Use name \"As-Is\"";
			this.CheckBoxAsIs.UseVisualStyleBackColor = true;
			// 
			// CheckBoxKamaelIDStandart
			// 
			this.CheckBoxKamaelIDStandart.AutoSize = true;
			this.CheckBoxKamaelIDStandart.Enabled = false;
			this.CheckBoxKamaelIDStandart.Location = new System.Drawing.Point(263, 109);
			this.CheckBoxKamaelIDStandart.Name = "CheckBoxKamaelIDStandart";
			this.CheckBoxKamaelIDStandart.Size = new System.Drawing.Size(116, 17);
			this.CheckBoxKamaelIDStandart.TabIndex = 50;
			this.CheckBoxKamaelIDStandart.Text = "Kamael ID standart";
			this.CheckBoxKamaelIDStandart.UseVisualStyleBackColor = true;
			// 
			// IgnoreCustomAbnormalsCheckBox
			// 
			this.IgnoreCustomAbnormalsCheckBox.AutoSize = true;
			this.IgnoreCustomAbnormalsCheckBox.Enabled = false;
			this.IgnoreCustomAbnormalsCheckBox.Location = new System.Drawing.Point(263, 155);
			this.IgnoreCustomAbnormalsCheckBox.Name = "IgnoreCustomAbnormalsCheckBox";
			this.IgnoreCustomAbnormalsCheckBox.Size = new System.Drawing.Size(159, 17);
			this.IgnoreCustomAbnormalsCheckBox.TabIndex = 49;
			this.IgnoreCustomAbnormalsCheckBox.Text = "Set unknown abnormal to -1";
			this.IgnoreCustomAbnormalsCheckBox.UseVisualStyleBackColor = true;
			// 
			// UseCustomAbnormalsCheckBox
			// 
			this.UseCustomAbnormalsCheckBox.AutoSize = true;
			this.UseCustomAbnormalsCheckBox.Enabled = false;
			this.UseCustomAbnormalsCheckBox.Location = new System.Drawing.Point(263, 86);
			this.UseCustomAbnormalsCheckBox.Name = "UseCustomAbnormalsCheckBox";
			this.UseCustomAbnormalsCheckBox.Size = new System.Drawing.Size(143, 17);
			this.UseCustomAbnormalsCheckBox.TabIndex = 48;
			this.UseCustomAbnormalsCheckBox.Text = "Use custom abnormal list";
			this.UseCustomAbnormalsCheckBox.UseVisualStyleBackColor = true;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(127, 82);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(127, 23);
			this.StartButton.TabIndex = 2;
			this.StartButton.Text = "Generate Pch/Pch2";
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// SkillCacheScriptButton
			// 
			this.SkillCacheScriptButton.Location = new System.Drawing.Point(127, 128);
			this.SkillCacheScriptButton.Name = "SkillCacheScriptButton";
			this.SkillCacheScriptButton.Size = new System.Drawing.Size(127, 23);
			this.SkillCacheScriptButton.TabIndex = 45;
			this.SkillCacheScriptButton.Text = "Generate CacheScript";
			this.SkillCacheScriptButton.Click += new System.EventHandler(this.SkillCacheScript_Click);
			// 
			// IgnoreCustomSkillBox
			// 
			this.IgnoreCustomSkillBox.AutoSize = true;
			this.IgnoreCustomSkillBox.Enabled = false;
			this.IgnoreCustomSkillBox.Location = new System.Drawing.Point(128, 155);
			this.IgnoreCustomSkillBox.Name = "IgnoreCustomSkillBox";
			this.IgnoreCustomSkillBox.Size = new System.Drawing.Size(118, 17);
			this.IgnoreCustomSkillBox.TabIndex = 47;
			this.IgnoreCustomSkillBox.Text = "Ignore custom skills";
			this.IgnoreCustomSkillBox.UseVisualStyleBackColor = true;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(281, 25);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 53;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(281, 9);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(141, 16);
			this.Label2.TabIndex = 52;
			this.Label2.Text = "Skill Pch/Pch2 Maker";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(11, 178);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(314, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 50;
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(331, 178);
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
			this.ClientSize = new System.Drawing.Size(430, 210);
			this.Controls.Add(this.La2GuardAttrCheckBox);
			this.Controls.Add(this.CheckBoxAsIs);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.CheckBoxKamaelIDStandart);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.IgnoreCustomAbnormalsCheckBox);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.UseCustomAbnormalsCheckBox);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.SkillCacheScriptButton);
			this.Controls.Add(this.IgnoreCustomSkillBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SkillPch2Maker";
			this.Text = "Skill Pch/Pch2 Maker";
			this.Load += new System.EventHandler(this.SkillPch2Maker_Load);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.CheckBox La2GuardAttrCheckBox;
		internal System.Windows.Forms.CheckBox CheckBoxAsIs;
		internal System.Windows.Forms.CheckBox CheckBoxKamaelIDStandart;
		internal System.Windows.Forms.CheckBox IgnoreCustomAbnormalsCheckBox;
		internal System.Windows.Forms.CheckBox UseCustomAbnormalsCheckBox;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.Button SkillCacheScriptButton;
		internal System.Windows.Forms.CheckBox IgnoreCustomSkillBox;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
	}
}