namespace L2ScriptMaker.Modules.Scripts
{
	partial class ScriptParamSearcher
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptParamSearcher));
			this.SearchParamTextBox = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.SummaryTextBox = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// SearchParamTextBox
			// 
			this.SearchParamTextBox.Location = new System.Drawing.Point(135, 54);
			this.SearchParamTextBox.Name = "SearchParamTextBox";
			this.SearchParamTextBox.Size = new System.Drawing.Size(302, 20);
			this.SearchParamTextBox.TabIndex = 75;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(132, 38);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(104, 13);
			this.Label3.TabIndex = 74;
			this.Label3.Text = "Param for searching:";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(11, 178);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(426, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 73;
			// 
			// SummaryTextBox
			// 
			this.SummaryTextBox.Location = new System.Drawing.Point(135, 80);
			this.SummaryTextBox.Multiline = true;
			this.SummaryTextBox.Name = "SummaryTextBox";
			this.SummaryTextBox.ReadOnly = true;
			this.SummaryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.SummaryTextBox.Size = new System.Drawing.Size(302, 63);
			this.SummaryTextBox.TabIndex = 72;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(343, 26);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(94, 13);
			this.Label1.TabIndex = 71;
			this.Label1.Text = "(support all scripts)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(222, 10);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(215, 16);
			this.Label2.TabIndex = 70;
			this.Label2.Text = "Searcher all definitions for param";
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(362, 149);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 69;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(134, 149);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 68;
			this.ButtonStart.Text = "Start";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(11, 10);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 162);
			this.PictureBox1.TabIndex = 67;
			this.PictureBox1.TabStop = false;
			// 
			// ScriptParamSearcher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 211);
			this.Controls.Add(this.SearchParamTextBox);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.SummaryTextBox);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ScriptParamSearcher";
			this.Text = "Script Param Searcher";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.TextBox SearchParamTextBox;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.TextBox SummaryTextBox;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
	}
}