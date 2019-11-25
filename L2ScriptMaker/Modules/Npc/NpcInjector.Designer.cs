namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcInjector
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcInjector));
			this.Label2 = new System.Windows.Forms.Label();
			this.StatusBox = new System.Windows.Forms.TextBox();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.TargetFile = new System.Windows.Forms.TextBox();
			this.OverwriteBox = new System.Windows.Forms.CheckBox();
			this.SplitButton = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SourceFile = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Quit = new System.Windows.Forms.Button();
			this.Inject = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.MergeButton = new System.Windows.Forms.Button();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(118, 147);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(47, 13);
			this.Label2.TabIndex = 50;
			this.Label2.Text = "Status:";
			// 
			// StatusBox
			// 
			this.StatusBox.Location = new System.Drawing.Point(119, 163);
			this.StatusBox.Name = "StatusBox";
			this.StatusBox.ReadOnly = true;
			this.StatusBox.Size = new System.Drawing.Size(311, 20);
			this.StatusBox.TabIndex = 49;
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(119, 189);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(312, 23);
			this.ProgressBar.TabIndex = 48;
			// 
			// TargetFile
			// 
			this.TargetFile.Location = new System.Drawing.Point(119, 69);
			this.TargetFile.Name = "TargetFile";
			this.TargetFile.ReadOnly = true;
			this.TargetFile.Size = new System.Drawing.Size(312, 20);
			this.TargetFile.TabIndex = 47;
			// 
			// OverwriteBox
			// 
			this.OverwriteBox.AutoSize = true;
			this.OverwriteBox.Location = new System.Drawing.Point(200, 99);
			this.OverwriteBox.Name = "OverwriteBox";
			this.OverwriteBox.Size = new System.Drawing.Size(71, 17);
			this.OverwriteBox.TabIndex = 54;
			this.OverwriteBox.Text = "Overwrite";
			// 
			// SplitButton
			// 
			this.SplitButton.Location = new System.Drawing.Point(119, 95);
			this.SplitButton.Name = "SplitButton";
			this.SplitButton.Size = new System.Drawing.Size(75, 23);
			this.SplitButton.TabIndex = 51;
			this.SplitButton.Text = "Split";
			this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.FileName = "OpenFileDialog1";
			// 
			// SourceFile
			// 
			this.SourceFile.Location = new System.Drawing.Point(119, 30);
			this.SourceFile.Name = "SourceFile";
			this.SourceFile.ReadOnly = true;
			this.SourceFile.Size = new System.Drawing.Size(312, 20);
			this.SourceFile.TabIndex = 46;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(118, 53);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(36, 13);
			this.Label4.TabIndex = 45;
			this.Label4.Text = "Vien:";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(118, 14);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(60, 13);
			this.Label1.TabIndex = 44;
			this.Label1.Text = "Injection:";
			// 
			// Quit
			// 
			this.Quit.Location = new System.Drawing.Point(356, 122);
			this.Quit.Name = "Quit";
			this.Quit.Size = new System.Drawing.Size(75, 23);
			this.Quit.TabIndex = 43;
			this.Quit.Text = "Quit";
			this.Quit.Click += new System.EventHandler(this.Quit_Click);
			// 
			// Inject
			// 
			this.Inject.Location = new System.Drawing.Point(355, 93);
			this.Inject.Name = "Inject";
			this.Inject.Size = new System.Drawing.Size(75, 23);
			this.Inject.TabIndex = 42;
			this.Inject.Text = "Inject fix";
			this.Inject.Click += new System.EventHandler(this.Inject_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.InitialImage = null;
			this.PictureBox1.Location = new System.Drawing.Point(13, 14);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(89, 198);
			this.PictureBox1.TabIndex = 53;
			this.PictureBox1.TabStop = false;
			// 
			// MergeButton
			// 
			this.MergeButton.Location = new System.Drawing.Point(119, 121);
			this.MergeButton.Name = "MergeButton";
			this.MergeButton.Size = new System.Drawing.Size(75, 23);
			this.MergeButton.TabIndex = 52;
			this.MergeButton.Text = "Merge";
			this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
			// 
			// FolderBrowserDialog
			// 
			this.FolderBrowserDialog.SelectedPath = "FolderBrowserDialog1";
			// 
			// NpcInjector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 226);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.StatusBox);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.TargetFile);
			this.Controls.Add(this.OverwriteBox);
			this.Controls.Add(this.SplitButton);
			this.Controls.Add(this.SourceFile);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Quit);
			this.Controls.Add(this.Inject);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.MergeButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcInjector";
			this.Text = "NpcInjector";
			this.Load += new System.EventHandler(this.AiInjector_Load);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox StatusBox;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.TextBox TargetFile;
		internal System.Windows.Forms.CheckBox OverwriteBox;
		internal System.Windows.Forms.Button SplitButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.TextBox SourceFile;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button Quit;
		internal System.Windows.Forms.Button Inject;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button MergeButton;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
	}
}