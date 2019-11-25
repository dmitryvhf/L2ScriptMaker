namespace L2ScriptMaker.Modules.AI
{
	partial class AIDecompilerPack
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIDecompilerPack));
			this.QuitButton = new System.Windows.Forms.Button();
			this.CollectFuncButton = new System.Windows.Forms.Button();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.FetchDefaultCopyCheckBox = new System.Windows.Forms.CheckBox();
			this.CollectFetchButton = new System.Windows.Forms.Button();
			this.CollectEventButton = new System.Windows.Forms.Button();
			this.CollectHandlerButton = new System.Windows.Forms.Button();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(277, 12);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 9;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// CollectFuncButton
			// 
			this.CollectFuncButton.Location = new System.Drawing.Point(128, 12);
			this.CollectFuncButton.Name = "CollectFuncButton";
			this.CollectFuncButton.Size = new System.Drawing.Size(109, 23);
			this.CollectFuncButton.TabIndex = 8;
			this.CollectFuncButton.Text = "Collect Func_call\'s";
			this.CollectFuncButton.UseVisualStyleBackColor = true;
			this.CollectFuncButton.Click += new System.EventHandler(this.CollectFuncButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(110, 160);
			this.PictureBox1.TabIndex = 15;
			this.PictureBox1.TabStop = false;
			// 
			// FetchDefaultCopyCheckBox
			// 
			this.FetchDefaultCopyCheckBox.AutoSize = true;
			this.FetchDefaultCopyCheckBox.Location = new System.Drawing.Point(150, 127);
			this.FetchDefaultCopyCheckBox.Name = "FetchDefaultCopyCheckBox";
			this.FetchDefaultCopyCheckBox.Size = new System.Drawing.Size(161, 30);
			this.FetchDefaultCopyCheckBox.TabIndex = 14;
			this.FetchDefaultCopyCheckBox.Text = "Write record for defaut value\r\nas additional record";
			this.FetchDefaultCopyCheckBox.UseVisualStyleBackColor = true;
			// 
			// CollectFetchButton
			// 
			this.CollectFetchButton.Location = new System.Drawing.Point(128, 98);
			this.CollectFetchButton.Name = "CollectFetchButton";
			this.CollectFetchButton.Size = new System.Drawing.Size(109, 23);
			this.CollectFetchButton.TabIndex = 13;
			this.CollectFetchButton.Text = "Collect fetch_i";
			this.CollectFetchButton.UseVisualStyleBackColor = true;
			this.CollectFetchButton.Click += new System.EventHandler(this.CollectFetchButton_Click);
			// 
			// CollectEventButton
			// 
			this.CollectEventButton.Location = new System.Drawing.Point(128, 69);
			this.CollectEventButton.Name = "CollectEventButton";
			this.CollectEventButton.Size = new System.Drawing.Size(109, 23);
			this.CollectEventButton.TabIndex = 12;
			this.CollectEventButton.Text = "Collect push_event";
			this.CollectEventButton.UseVisualStyleBackColor = true;
			this.CollectEventButton.Click += new System.EventHandler(this.CollectEventButton_Click);
			// 
			// CollectHandlerButton
			// 
			this.CollectHandlerButton.Location = new System.Drawing.Point(128, 41);
			this.CollectHandlerButton.Name = "CollectHandlerButton";
			this.CollectHandlerButton.Size = new System.Drawing.Size(109, 22);
			this.CollectHandlerButton.TabIndex = 11;
			this.CollectHandlerButton.Text = "Collect Handler\'s";
			this.CollectHandlerButton.UseVisualStyleBackColor = true;
			this.CollectHandlerButton.Click += new System.EventHandler(this.CollectHandlerButton_Click);
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(12, 178);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(340, 23);
			this.ProgressBar.TabIndex = 10;
			// 
			// AIDecompilerPack
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 209);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.CollectFuncButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.FetchDefaultCopyCheckBox);
			this.Controls.Add(this.CollectFetchButton);
			this.Controls.Add(this.CollectEventButton);
			this.Controls.Add(this.CollectHandlerButton);
			this.Controls.Add(this.ProgressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AIDecompilerPack";
			this.Text = "L2ScriptMaker: Lineage II AI.obj Decompiler Tool Pack";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button CollectFuncButton;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.CheckBox FetchDefaultCopyCheckBox;
		internal System.Windows.Forms.Button CollectFetchButton;
		internal System.Windows.Forms.Button CollectEventButton;
		internal System.Windows.Forms.Button CollectHandlerButton;
		internal System.Windows.Forms.ProgressBar ProgressBar;
	}
}