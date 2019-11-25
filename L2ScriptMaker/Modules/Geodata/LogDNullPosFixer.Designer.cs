namespace L2ScriptMaker.Modules.Geodata
{
	partial class LogDNullPosFixer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogDNullPosFixer));
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.Label1 = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.ApplyPatchButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(132, 132);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(93, 23);
			this.QuitButton.TabIndex = 61;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(132, 50);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(93, 35);
			this.StartButton.TabIndex = 60;
			this.StartButton.Text = "Load errors from err\\*.logs";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(128, 26);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 59;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(128, 10);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(153, 16);
			this.Label4.TabIndex = 58;
			this.Label4.Text = "AI.obj teleport pos fixer";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(14, 10);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 161);
			this.PictureBox1.TabIndex = 57;
			this.PictureBox1.TabStop = false;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(128, 158);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(47, 13);
			this.Label1.TabIndex = 65;
			this.Label1.Text = "Status:";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(14, 177);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(407, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.TabIndex = 64;
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Location = new System.Drawing.Point(181, 158);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 13);
			this.StatusLabel.TabIndex = 63;
			// 
			// ApplyPatchButton
			// 
			this.ApplyPatchButton.Location = new System.Drawing.Point(132, 90);
			this.ApplyPatchButton.Name = "ApplyPatchButton";
			this.ApplyPatchButton.Size = new System.Drawing.Size(93, 36);
			this.ApplyPatchButton.TabIndex = 62;
			this.ApplyPatchButton.Text = "Load Patch data and Fix";
			this.ApplyPatchButton.UseVisualStyleBackColor = true;
			this.ApplyPatchButton.Click += new System.EventHandler(this.ApplyPatchButton_Click);
			// 
			// LogDNullPosFixer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 211);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.StatusLabel);
			this.Controls.Add(this.ApplyPatchButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "LogDNullPosFixer";
			this.Text = "Fixer for: container NULL pos[123126, 79699] at file [.\\world_server.cpp]";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Label StatusLabel;
		internal System.Windows.Forms.Button ApplyPatchButton;
	}
}