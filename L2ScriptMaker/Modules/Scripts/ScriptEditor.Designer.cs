namespace L2ScriptMaker.Modules.Scripts
{
	partial class ScriptEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptEditor));
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.DataGridView = new System.Windows.Forms.DataGridView();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ButtonSaveFile = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ButtonClear = new System.Windows.Forms.Button();
			this.ButtonLoadFile = new System.Windows.Forms.Button();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonGenerate = new System.Windows.Forms.Button();
			this.ButtonConfig = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.TabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
			this.TabPage2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(531, 24);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(226, 15);
			this.Label2.TabIndex = 23;
			this.Label2.Text = "(support universal configs for any script file)";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(513, 6);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(247, 19);
			this.Label1.TabIndex = 22;
			this.Label1.Text = "L2ScriptMaker Visual Script Editor";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(10, 13);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 162);
			this.PictureBox1.TabIndex = 21;
			this.PictureBox1.TabStop = false;
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.DataGridView);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(633, 172);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Working place";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// DataGridView
			// 
			this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView.Location = new System.Drawing.Point(6, 6);
			this.DataGridView.Name = "DataGridView";
			this.DataGridView.Size = new System.Drawing.Size(621, 160);
			this.DataGridView.TabIndex = 0;
			this.DataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridView_RowsAdded);
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.TextBox1);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(633, 172);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Generate result";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// TextBox1
			// 
			this.TextBox1.Location = new System.Drawing.Point(6, 6);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBox1.Size = new System.Drawing.Size(621, 160);
			this.TextBox1.TabIndex = 4;
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(124, 33);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(641, 198);
			this.TabControl1.TabIndex = 20;
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(343, 237);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(229, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 13;
			// 
			// ButtonSaveFile
			// 
			this.ButtonSaveFile.Location = new System.Drawing.Point(28, 237);
			this.ButtonSaveFile.Name = "ButtonSaveFile";
			this.ButtonSaveFile.Size = new System.Drawing.Size(75, 23);
			this.ButtonSaveFile.TabIndex = 19;
			this.ButtonSaveFile.Text = "Save file...";
			this.ButtonSaveFile.UseVisualStyleBackColor = true;
			this.ButtonSaveFile.Click += new System.EventHandler(this.ButtonSaveFile_Click);
			// 
			// ButtonClear
			// 
			this.ButtonClear.Location = new System.Drawing.Point(205, 237);
			this.ButtonClear.Name = "ButtonClear";
			this.ButtonClear.Size = new System.Drawing.Size(75, 23);
			this.ButtonClear.TabIndex = 17;
			this.ButtonClear.Text = "Clear";
			this.ButtonClear.UseVisualStyleBackColor = true;
			this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
			// 
			// ButtonLoadFile
			// 
			this.ButtonLoadFile.Location = new System.Drawing.Point(28, 208);
			this.ButtonLoadFile.Name = "ButtonLoadFile";
			this.ButtonLoadFile.Size = new System.Drawing.Size(75, 23);
			this.ButtonLoadFile.TabIndex = 18;
			this.ButtonLoadFile.Text = "Load file...";
			this.ButtonLoadFile.UseVisualStyleBackColor = true;
			this.ButtonLoadFile.Click += new System.EventHandler(this.ButtonLoadFile_Click);
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(690, 237);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 16;
			this.ButtonQuit.Text = "Exit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonGenerate
			// 
			this.ButtonGenerate.Location = new System.Drawing.Point(124, 237);
			this.ButtonGenerate.Name = "ButtonGenerate";
			this.ButtonGenerate.Size = new System.Drawing.Size(75, 23);
			this.ButtonGenerate.TabIndex = 15;
			this.ButtonGenerate.Text = "Generate";
			this.ButtonGenerate.UseVisualStyleBackColor = true;
			this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
			// 
			// ButtonConfig
			// 
			this.ButtonConfig.Location = new System.Drawing.Point(28, 179);
			this.ButtonConfig.Name = "ButtonConfig";
			this.ButtonConfig.Size = new System.Drawing.Size(75, 23);
			this.ButtonConfig.TabIndex = 14;
			this.ButtonConfig.Text = "Load Config";
			this.ButtonConfig.UseVisualStyleBackColor = true;
			this.ButtonConfig.Click += new System.EventHandler(this.ButtonConfig_Click);
			// 
			// ScriptEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 266);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.ButtonSaveFile);
			this.Controls.Add(this.ButtonClear);
			this.Controls.Add(this.ButtonLoadFile);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonGenerate);
			this.Controls.Add(this.ButtonConfig);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ScriptEditor";
			this.Text = "ScriptMaker Visual Script Editor ";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.TabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.DataGridView DataGridView;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Button ButtonSaveFile;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Button ButtonClear;
		internal System.Windows.Forms.Button ButtonLoadFile;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonGenerate;
		internal System.Windows.Forms.Button ButtonConfig;
	}
}