namespace L2ScriptMaker.Modules.Skills
{
	partial class SkillInjector
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillInjector));
			this.Label2 = new System.Windows.Forms.Label();
			this.StatusBox = new System.Windows.Forms.TextBox();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.TargetFile = new System.Windows.Forms.TextBox();
			this.SourceFile = new System.Windows.Forms.TextBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.CheckBoxWriteNew = new System.Windows.Forms.CheckBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Quit = new System.Windows.Forms.Button();
			this.Inject = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.MergeButton = new System.Windows.Forms.Button();
			this.OverwriteBox = new System.Windows.Forms.CheckBox();
			this.SplitButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(118, 149);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(47, 13);
			this.Label2.TabIndex = 64;
			this.Label2.Text = "Status:";
			// 
			// StatusBox
			// 
			this.StatusBox.Location = new System.Drawing.Point(119, 165);
			this.StatusBox.Name = "StatusBox";
			this.StatusBox.ReadOnly = true;
			this.StatusBox.Size = new System.Drawing.Size(311, 20);
			this.StatusBox.TabIndex = 63;
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(119, 191);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(312, 23);
			this.ProgressBar.TabIndex = 62;
			// 
			// TargetFile
			// 
			this.TargetFile.Location = new System.Drawing.Point(119, 71);
			this.TargetFile.Name = "TargetFile";
			this.TargetFile.ReadOnly = true;
			this.TargetFile.Size = new System.Drawing.Size(312, 20);
			this.TargetFile.TabIndex = 61;
			// 
			// SourceFile
			// 
			this.SourceFile.Location = new System.Drawing.Point(119, 32);
			this.SourceFile.Name = "SourceFile";
			this.SourceFile.ReadOnly = true;
			this.SourceFile.Size = new System.Drawing.Size(312, 20);
			this.SourceFile.TabIndex = 60;
			// 
			// CheckBoxWriteNew
			// 
			this.CheckBoxWriteNew.AutoSize = true;
			this.CheckBoxWriteNew.Checked = true;
			this.CheckBoxWriteNew.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxWriteNew.Location = new System.Drawing.Point(358, 101);
			this.CheckBoxWriteNew.Name = "CheckBoxWriteNew";
			this.CheckBoxWriteNew.Size = new System.Drawing.Size(71, 30);
			this.CheckBoxWriteNew.TabIndex = 69;
			this.CheckBoxWriteNew.Text = "Write\r\nnew skills";
			this.CheckBoxWriteNew.UseVisualStyleBackColor = true;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(118, 55);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(36, 13);
			this.Label4.TabIndex = 59;
			this.Label4.Text = "Vien:";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(118, 16);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(60, 13);
			this.Label1.TabIndex = 58;
			this.Label1.Text = "Injection:";
			// 
			// Quit
			// 
			this.Quit.Location = new System.Drawing.Point(277, 123);
			this.Quit.Name = "Quit";
			this.Quit.Size = new System.Drawing.Size(75, 23);
			this.Quit.TabIndex = 57;
			this.Quit.Text = "Quit";
			this.Quit.Click += new System.EventHandler(this.Quit_Click);
			// 
			// Inject
			// 
			this.Inject.Location = new System.Drawing.Point(277, 97);
			this.Inject.Name = "Inject";
			this.Inject.Size = new System.Drawing.Size(75, 23);
			this.Inject.TabIndex = 56;
			this.Inject.Text = "Inject fix";
			this.Inject.Click += new System.EventHandler(this.Inject_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.InitialImage = null;
			this.PictureBox1.Location = new System.Drawing.Point(13, 16);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(89, 198);
			this.PictureBox1.TabIndex = 67;
			this.PictureBox1.TabStop = false;
			// 
			// MergeButton
			// 
			this.MergeButton.Location = new System.Drawing.Point(119, 123);
			this.MergeButton.Name = "MergeButton";
			this.MergeButton.Size = new System.Drawing.Size(75, 23);
			this.MergeButton.TabIndex = 66;
			this.MergeButton.Text = "Merge";
			this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
			// 
			// OverwriteBox
			// 
			this.OverwriteBox.AutoSize = true;
			this.OverwriteBox.Location = new System.Drawing.Point(200, 101);
			this.OverwriteBox.Name = "OverwriteBox";
			this.OverwriteBox.Size = new System.Drawing.Size(71, 17);
			this.OverwriteBox.TabIndex = 68;
			this.OverwriteBox.Text = "Overwrite";
			// 
			// SplitButton
			// 
			this.SplitButton.Location = new System.Drawing.Point(119, 97);
			this.SplitButton.Name = "SplitButton";
			this.SplitButton.Size = new System.Drawing.Size(75, 23);
			this.SplitButton.TabIndex = 65;
			this.SplitButton.Text = "Split";
			this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
			// 
			// SkillInjector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 231);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.StatusBox);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.TargetFile);
			this.Controls.Add(this.SourceFile);
			this.Controls.Add(this.CheckBoxWriteNew);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Quit);
			this.Controls.Add(this.Inject);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.MergeButton);
			this.Controls.Add(this.OverwriteBox);
			this.Controls.Add(this.SplitButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SkillInjector";
			this.Text = "SkillInjector";
			this.Load += new System.EventHandler(this.AiInjector_Load);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox StatusBox;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.TextBox TargetFile;
		internal System.Windows.Forms.TextBox SourceFile;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.CheckBox CheckBoxWriteNew;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button Quit;
		internal System.Windows.Forms.Button Inject;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button MergeButton;
		internal System.Windows.Forms.CheckBox OverwriteBox;
		internal System.Windows.Forms.Button SplitButton;
	}
}