namespace L2ScriptMaker.Modules.Skills
{
	partial class SkillDataParser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillDataParser));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.QuitButton = new System.Windows.Forms.Button();
			this.ScanButton = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ScanParamComboBox = new System.Windows.Forms.ComboBox();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar});
			this.StatusStrip.Location = new System.Drawing.Point(0, 179);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(324, 22);
			this.StatusStrip.TabIndex = 62;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(300, 16);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 158);
			this.PictureBox1.TabIndex = 61;
			this.PictureBox1.TabStop = false;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(174, 38);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(97, 13);
			this.Label4.TabIndex = 60;
			this.Label4.Text = "(support C4 scripts)";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label5.Location = new System.Drawing.Point(126, 6);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(174, 32);
			this.Label5.TabIndex = 59;
			this.Label5.Text = "Lineage II Cronicles 4\r\nSkilldata Effect Researcher";
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(177, 132);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 64;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// ScanButton
			// 
			this.ScanButton.Location = new System.Drawing.Point(177, 103);
			this.ScanButton.Name = "ScanButton";
			this.ScanButton.Size = new System.Drawing.Size(75, 23);
			this.ScanButton.TabIndex = 63;
			this.ScanButton.Text = "Scan";
			this.ScanButton.UseVisualStyleBackColor = true;
			this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
			// 
			// ScanParamComboBox
			// 
			this.ScanParamComboBox.FormattingEnabled = true;
			this.ScanParamComboBox.Items.AddRange(new object[] {
            "effect",
            "main_effect",
            "start_effect",
            "end_effect",
            "operate_cond"});
			this.ScanParamComboBox.Location = new System.Drawing.Point(159, 76);
			this.ScanParamComboBox.Name = "ScanParamComboBox";
			this.ScanParamComboBox.Size = new System.Drawing.Size(121, 21);
			this.ScanParamComboBox.TabIndex = 65;
			this.ScanParamComboBox.Text = "effect";
			// 
			// SkillDataParser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 201);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.ScanButton);
			this.Controls.Add(this.ScanParamComboBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SkillDataParser";
			this.Text = "Lineage II Cronicles 4 Skilldata Effect Researcher";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button ScanButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.ComboBox ScanParamComboBox;
	}
}