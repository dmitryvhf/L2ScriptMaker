namespace L2ScriptMaker.Modules.ZeroScripts
{
	partial class ScriptFromDat
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptFromDat));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
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
			this.StatusStrip.Size = new System.Drawing.Size(354, 22);
			this.StatusStrip.TabIndex = 65;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(300, 16);
			this.ToolStripProgressBar.Step = 1;
			this.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label5.Location = new System.Drawing.Point(249, 38);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(97, 13);
			this.Label5.TabIndex = 64;
			this.Label5.Text = "(support C4 scripts)";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label6.Location = new System.Drawing.Point(126, 6);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(220, 32);
			this.Label6.TabIndex = 63;
			this.Label6.Text = "Generator new clean Server Script\r\nFile from Client .Dat file";
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(162, 100);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 62;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(162, 71);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 61;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 158);
			this.PictureBox1.TabIndex = 60;
			this.PictureBox1.TabStop = false;
			// 
			// ScriptFromDat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 201);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ScriptFromDat";
			this.Text = "Generator Script From Client Dat";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
	}
}