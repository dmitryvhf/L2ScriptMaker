namespace L2ScriptMaker.Modules.AI
{
	partial class AIRaidPosGenerator
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIRaidPosGenerator));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.GenPosCheckBox = new System.Windows.Forms.CheckBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.GenPrivatesCheckBox = new System.Windows.Forms.CheckBox();
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
			this.StatusStrip.Size = new System.Drawing.Size(339, 22);
			this.StatusStrip.TabIndex = 58;
			this.StatusStrip.Text = "StatusStrip";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(300, 16);
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(129, 117);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 57;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(129, 88);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 56;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 159);
			this.PictureBox1.TabIndex = 55;
			this.PictureBox1.TabStop = false;
			// 
			// GenPosCheckBox
			// 
			this.GenPosCheckBox.AutoSize = true;
			this.GenPosCheckBox.Checked = true;
			this.GenPosCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.GenPosCheckBox.Location = new System.Drawing.Point(210, 92);
			this.GenPosCheckBox.Name = "GenPosCheckBox";
			this.GenPosCheckBox.Size = new System.Drawing.Size(108, 17);
			this.GenPosCheckBox.TabIndex = 61;
			this.GenPosCheckBox.Text = "Generate npcpos";
			this.GenPosCheckBox.UseVisualStyleBackColor = true;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(177, 38);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(141, 13);
			this.Label3.TabIndex = 60;
			this.Label3.Text = "(support L2Disasm client file)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(126, 6);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(201, 32);
			this.Label2.TabIndex = 59;
			this.Label2.Text = "Raid Boss Position AI class and\r\nsimple Npcpos Generator";
			// 
			// GenPrivatesCheckBox
			// 
			this.GenPrivatesCheckBox.AutoSize = true;
			this.GenPrivatesCheckBox.Checked = true;
			this.GenPrivatesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.GenPrivatesCheckBox.Location = new System.Drawing.Point(210, 115);
			this.GenPrivatesCheckBox.Name = "GenPrivatesCheckBox";
			this.GenPrivatesCheckBox.Size = new System.Drawing.Size(111, 17);
			this.GenPrivatesCheckBox.TabIndex = 62;
			this.GenPrivatesCheckBox.Text = "Generate Privates";
			this.GenPrivatesCheckBox.UseVisualStyleBackColor = true;
			// 
			// AIRaidPosGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 201);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.GenPosCheckBox);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.GenPrivatesCheckBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AIRaidPosGenerator";
			this.Text = "Raid Boss Position and simple Npcpos Generator";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.CheckBox GenPosCheckBox;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.CheckBox GenPrivatesCheckBox;
	}
}