namespace L2ScriptMaker.Modules.Geodata
{
	partial class GeoGetTestPoint
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeoGetTestPoint));
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.QuitButton = new System.Windows.Forms.Button();
			this.ScanButton = new System.Windows.Forms.Button();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.Label1 = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 160);
			this.PictureBox1.TabIndex = 57;
			this.PictureBox1.TabStop = false;
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(176, 89);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 56;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// ScanButton
			// 
			this.ScanButton.Location = new System.Drawing.Point(176, 60);
			this.ScanButton.Name = "ScanButton";
			this.ScanButton.Size = new System.Drawing.Size(75, 23);
			this.ScanButton.TabIndex = 55;
			this.ScanButton.Text = "Scan";
			this.ScanButton.UseVisualStyleBackColor = true;
			this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1});
			this.StatusStrip.Location = new System.Drawing.Point(0, 184);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(319, 22);
			this.StatusStrip.TabIndex = 58;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// ToolStripStatusLabel1
			// 
			this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
			this.ToolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(126, 127);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(51, 13);
			this.Label1.TabIndex = 62;
			this.Label1.Text = "Progress:";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(129, 143);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(172, 23);
			this.ProgressBar.TabIndex = 61;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(189, 38);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(112, 13);
			this.Label4.TabIndex = 60;
			this.Label4.Text = "(support all chronicles)";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label5.Location = new System.Drawing.Point(126, 6);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(174, 32);
			this.Label5.TabIndex = 59;
			this.Label5.Text = "GetTestPoint Finder and \r\nGeodata Bug file gererator.";
			// 
			// GeoGetTestPoint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 206);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.ScanButton);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "GeoGetTestPoint";
			this.Text = "GetTestPoint Scanner";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button ScanButton;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
	}
}