namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	partial class L2J_MultiSell
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(L2J_MultiSell));
			this.Label2 = new System.Windows.Forms.Label();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(125, 3);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(211, 16);
			this.Label2.TabIndex = 62;
			this.Label2.Text = "MultiSell Generator from L2J file";
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 174);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(344, 22);
			this.StatusStrip.TabIndex = 61;
			this.StatusStrip.Text = "StatusStrip";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(200, 16);
			this.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// ToolStripStatusLabel
			// 
			this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
			this.ToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(166, 67);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 59;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(166, 37);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 58;
			this.ButtonStart.Text = "Generate...";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 3);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(107, 157);
			this.PictureBox1.TabIndex = 60;
			this.PictureBox1.TabStop = false;
			// 
			// L2J_MultiSell
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 196);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "L2J_MultiSell";
			this.Text = "L2J_MultiSell";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
	}
}