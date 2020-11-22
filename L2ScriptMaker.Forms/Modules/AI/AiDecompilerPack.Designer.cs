namespace L2ScriptMaker.Forms.Modules.AI
{
	partial class AiDecompilerPack
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AiDecompilerPack));
			this.QuitButton = new System.Windows.Forms.Button();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.clbCollect = new System.Windows.Forms.CheckedListBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.txbAiFile = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(277, 146);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 17;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(110, 160);
			this.PictureBox1.TabIndex = 23;
			this.PictureBox1.TabStop = false;
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(12, 179);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(340, 23);
			this.ProgressBar.TabIndex = 18;
			// 
			// clbCollect
			// 
			this.clbCollect.CheckOnClick = true;
			this.clbCollect.FormattingEnabled = true;
			this.clbCollect.Location = new System.Drawing.Point(128, 76);
			this.clbCollect.Name = "clbCollect";
			this.clbCollect.Size = new System.Drawing.Size(224, 64);
			this.clbCollect.TabIndex = 26;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(128, 146);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 27;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// txbAiFile
			// 
			this.txbAiFile.Location = new System.Drawing.Point(128, 50);
			this.txbAiFile.Name = "txbAiFile";
			this.txbAiFile.ReadOnly = true;
			this.txbAiFile.Size = new System.Drawing.Size(224, 20);
			this.txbAiFile.TabIndex = 28;
			this.txbAiFile.Text = "ai.obj";
			// 
			// AiDecompilerPack
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 212);
			this.Controls.Add(this.txbAiFile);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.clbCollect);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.ProgressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AiDecompilerPack";
			this.Text = "AI.obj Decompiler Tool Pack";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.CheckedListBox clbCollect;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.TextBox txbAiFile;
		private System.Windows.Forms.Button QuitButton;
		private System.Windows.Forms.PictureBox PictureBox1;
	}
}