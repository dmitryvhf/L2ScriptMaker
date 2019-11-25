namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcPosShifter
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcPosShifter));
			this.Label3 = new System.Windows.Forms.Label();
			this.ZShift = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.YShift = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.XShift = new System.Windows.Forms.TextBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(141, 95);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(50, 13);
			this.Label3.TabIndex = 29;
			this.Label3.Text = "Z-shifting";
			// 
			// ZShift
			// 
			this.ZShift.Location = new System.Drawing.Point(141, 111);
			this.ZShift.Name = "ZShift";
			this.ZShift.Size = new System.Drawing.Size(100, 20);
			this.ZShift.TabIndex = 28;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(141, 56);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(50, 13);
			this.Label2.TabIndex = 27;
			this.Label2.Text = "Y-shifting";
			// 
			// YShift
			// 
			this.YShift.Location = new System.Drawing.Point(141, 72);
			this.YShift.Name = "YShift";
			this.YShift.Size = new System.Drawing.Size(100, 20);
			this.YShift.TabIndex = 26;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(141, 17);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(50, 13);
			this.Label1.TabIndex = 25;
			this.Label1.Text = "X-shifting";
			// 
			// XShift
			// 
			this.XShift.Location = new System.Drawing.Point(141, 33);
			this.XShift.Name = "XShift";
			this.XShift.Size = new System.Drawing.Size(100, 20);
			this.XShift.TabIndex = 24;
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(14, 14);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(90, 200);
			this.PictureBox1.TabIndex = 23;
			this.PictureBox1.TabStop = false;
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(14, 220);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(227, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 21;
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(166, 149);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 20;
			this.ButtonStart.Text = "Start";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(166, 191);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 22;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// NpcPosShifter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(254, 256);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.ZShift);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.YShift);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.XShift);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.ButtonQuit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcPosShifter";
			this.Text = "NpcPosShifter";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox ZShift;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox YShift;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox XShift;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
	}
}