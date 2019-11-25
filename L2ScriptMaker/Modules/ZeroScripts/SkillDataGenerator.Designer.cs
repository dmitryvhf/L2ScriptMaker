namespace L2ScriptMaker.Modules.ZeroScripts
{
	partial class SkillDataGenerator
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillDataGenerator));
			this.ExistPchCheckBox = new System.Windows.Forms.CheckBox();
			this.DontDescCheckBox = new System.Windows.Forms.CheckBox();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.Label4 = new System.Windows.Forms.Label();
			this.AllPassiveCheckBox = new System.Windows.Forms.CheckBox();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.Label1 = new System.Windows.Forms.Label();
			this.Shema2RadioButton = new System.Windows.Forms.RadioButton();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.Shema1RadioButton = new System.Windows.Forms.RadioButton();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// ExistPchCheckBox
			// 
			this.ExistPchCheckBox.AutoSize = true;
			this.ExistPchCheckBox.Location = new System.Drawing.Point(129, 174);
			this.ExistPchCheckBox.Name = "ExistPchCheckBox";
			this.ExistPchCheckBox.Size = new System.Drawing.Size(188, 17);
			this.ExistPchCheckBox.TabIndex = 87;
			this.ExistPchCheckBox.Text = "use exist skill names from skill_pch";
			this.ExistPchCheckBox.UseVisualStyleBackColor = true;
			// 
			// DontDescCheckBox
			// 
			this.DontDescCheckBox.AutoSize = true;
			this.DontDescCheckBox.Location = new System.Drawing.Point(129, 151);
			this.DontDescCheckBox.Name = "DontDescCheckBox";
			this.DontDescCheckBox.Size = new System.Drawing.Size(172, 17);
			this.DontDescCheckBox.TabIndex = 85;
			this.DontDescCheckBox.Text = "dont transfer description /* [] */";
			this.DontDescCheckBox.UseVisualStyleBackColor = true;
			// 
			// ToolStripStatusLabel
			// 
			this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
			this.ToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(300, 16);
			this.ToolStripProgressBar.Step = 1;
			this.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(126, 109);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(54, 13);
			this.Label4.TabIndex = 86;
			this.Label4.Text = "Options:";
			// 
			// AllPassiveCheckBox
			// 
			this.AllPassiveCheckBox.AutoSize = true;
			this.AllPassiveCheckBox.Location = new System.Drawing.Point(129, 128);
			this.AllPassiveCheckBox.Name = "AllPassiveCheckBox";
			this.AllPassiveCheckBox.Size = new System.Drawing.Size(149, 17);
			this.AllPassiveCheckBox.TabIndex = 83;
			this.AllPassiveCheckBox.Text = "create all skill as (P)assive";
			this.AllPassiveCheckBox.UseVisualStyleBackColor = true;
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 209);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(469, 22);
			this.StatusStrip.TabIndex = 84;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(126, 50);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(175, 13);
			this.Label1.TabIndex = 82;
			this.Label1.Text = "Skillname generation shemas:";
			// 
			// Shema2RadioButton
			// 
			this.Shema2RadioButton.AutoSize = true;
			this.Shema2RadioButton.Location = new System.Drawing.Point(129, 89);
			this.Shema2RadioButton.Name = "Shema2RadioButton";
			this.Shema2RadioButton.Size = new System.Drawing.Size(207, 17);
			this.Shema2RadioButton.TabIndex = 80;
			this.Shema2RadioButton.Text = "\'s_%skill_id%_%skill_level%\'  (s_458_1)";
			this.Shema2RadioButton.UseVisualStyleBackColor = true;
			// 
			// Shema1RadioButton
			// 
			this.Shema1RadioButton.AutoSize = true;
			this.Shema1RadioButton.Checked = true;
			this.Shema1RadioButton.Location = new System.Drawing.Point(129, 66);
			this.Shema1RadioButton.Name = "Shema1RadioButton";
			this.Shema1RadioButton.Size = new System.Drawing.Size(327, 17);
			this.Shema1RadioButton.TabIndex = 81;
			this.Shema1RadioButton.TabStop = true;
			this.Shema1RadioButton.Text = "generate name like \'s_%skill_id%%skill_level%\' (s_power_strike1)";
			this.Shema1RadioButton.UseVisualStyleBackColor = true;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(260, 36);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(196, 13);
			this.Label3.TabIndex = 79;
			this.Label3.Text = "(support all scripts and L2Disasm format)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(145, 4);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(270, 32);
			this.Label2.TabIndex = 78;
			this.Label2.Text = "clean Skilldata.txt and skillenchantdata.txt\r\nGenerator from client .dat side";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 7);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 158);
			this.PictureBox1.TabIndex = 77;
			this.PictureBox1.TabStop = false;
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(381, 142);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 76;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(381, 109);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 75;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// SkillDataGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 231);
			this.Controls.Add(this.ExistPchCheckBox);
			this.Controls.Add(this.DontDescCheckBox);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.AllPassiveCheckBox);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Shema2RadioButton);
			this.Controls.Add(this.Shema1RadioButton);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SkillDataGenerator";
			this.Text = "Lineage II Cronicles 4 SkillData and SkillEnchantData Generator";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.CheckBox ExistPchCheckBox;
		internal System.Windows.Forms.CheckBox DontDescCheckBox;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.CheckBox AllPassiveCheckBox;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.RadioButton Shema2RadioButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.RadioButton Shema1RadioButton;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
	}
}