namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	partial class L2J_DoorData
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(L2J_DoorData));
			this.ButtonPTS2L2J = new System.Windows.Forms.Button();
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.Label2 = new System.Windows.Forms.Label();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ButtonQuit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonPTS2L2J
			// 
			this.ButtonPTS2L2J.Location = new System.Drawing.Point(128, 36);
			this.ButtonPTS2L2J.Name = "ButtonPTS2L2J";
			this.ButtonPTS2L2J.Size = new System.Drawing.Size(75, 23);
			this.ButtonPTS2L2J.TabIndex = 63;
			this.ButtonPTS2L2J.Text = "PTS -> L2J";
			this.ButtonPTS2L2J.UseVisualStyleBackColor = true;
			this.ButtonPTS2L2J.Click += new System.EventHandler(this.ButtonPTS2L2J_Click);
			// 
			// ToolStripStatusLabel
			// 
			this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
			this.ToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(200, 16);
			this.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(125, 2);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(211, 16);
			this.Label2.TabIndex = 67;
			this.Label2.Text = "MultiSell Generator from L2J file";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 2);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(107, 157);
			this.PictureBox1.TabIndex = 65;
			this.PictureBox1.TabStop = false;
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 174);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(354, 22);
			this.StatusStrip.TabIndex = 66;
			this.StatusStrip.Text = "StatusStrip";
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(208, 117);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 64;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// L2J_DoorData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 196);
			this.Controls.Add(this.ButtonPTS2L2J);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.ButtonQuit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "L2J_DoorData";
			this.Text = "L2J_DoorData";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button ButtonPTS2L2J;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.Button ButtonQuit;
	}
}