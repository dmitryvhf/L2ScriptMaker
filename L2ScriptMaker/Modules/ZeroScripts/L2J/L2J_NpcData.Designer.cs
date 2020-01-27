namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	partial class L2J_NpcData
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(L2J_NpcData));
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.Label2 = new System.Windows.Forms.Label();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.CheckBoxZzoldagu74 = new System.Windows.Forms.CheckBox();
			this.CheckBoxFixStats = new System.Windows.Forms.CheckBox();
			this.ButtonExpSP = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// ToolStripStatusLabel
			// 
			this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
			this.ToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(125, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(206, 16);
			this.Label2.TabIndex = 80;
			this.Label2.Text = "NpcData Generator from L2J file";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(200, 16);
			this.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// CheckBoxZzoldagu74
			// 
			this.CheckBoxZzoldagu74.AutoSize = true;
			this.CheckBoxZzoldagu74.Location = new System.Drawing.Point(212, 59);
			this.CheckBoxZzoldagu74.Name = "CheckBoxZzoldagu74";
			this.CheckBoxZzoldagu74.Size = new System.Drawing.Size(136, 17);
			this.CheckBoxZzoldagu74.TabIndex = 83;
			this.CheckBoxZzoldagu74.Text = "Zzoldagu 74+ like Boss";
			this.CheckBoxZzoldagu74.UseVisualStyleBackColor = true;
			// 
			// CheckBoxFixStats
			// 
			this.CheckBoxFixStats.AutoSize = true;
			this.CheckBoxFixStats.Location = new System.Drawing.Point(212, 36);
			this.CheckBoxFixStats.Name = "CheckBoxFixStats";
			this.CheckBoxFixStats.Size = new System.Drawing.Size(121, 17);
			this.CheckBoxFixStats.TabIndex = 82;
			this.CheckBoxFixStats.Text = "Fix STATs (str,dex..)";
			this.CheckBoxFixStats.UseVisualStyleBackColor = true;
			// 
			// ButtonExpSP
			// 
			this.ButtonExpSP.Location = new System.Drawing.Point(128, 103);
			this.ButtonExpSP.Name = "ButtonExpSP";
			this.ButtonExpSP.Size = new System.Drawing.Size(75, 23);
			this.ButtonExpSP.TabIndex = 81;
			this.ButtonExpSP.Text = "Exp/SP Fix";
			this.ButtonExpSP.UseVisualStyleBackColor = true;
			this.ButtonExpSP.Click += new System.EventHandler(this.ButtonExpSP_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 0);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(107, 157);
			this.PictureBox1.TabIndex = 78;
			this.PictureBox1.TabStop = false;
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(128, 132);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 77;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(128, 32);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 76;
			this.ButtonStart.Text = "Generate...";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 184);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(359, 22);
			this.StatusStrip.TabIndex = 79;
			this.StatusStrip.Text = "StatusStrip";
			// 
			// L2J_NpcData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 206);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.CheckBoxZzoldagu74);
			this.Controls.Add(this.CheckBoxFixStats);
			this.Controls.Add(this.ButtonExpSP);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.StatusStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "L2J_NpcData";
			this.Text = "L2J_NpcData";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.CheckBox CheckBoxZzoldagu74;
		internal System.Windows.Forms.CheckBox CheckBoxFixStats;
		internal System.Windows.Forms.Button ButtonExpSP;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.StatusStrip StatusStrip;
	}
}