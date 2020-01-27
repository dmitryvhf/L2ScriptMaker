namespace L2ScriptMaker.Modules.AI
{
	partial class AIMessageTeleportImporter
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIMessageTeleportImporter));
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ButtonAbout = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonExport = new System.Windows.Forms.Button();
			this.ButtonImport = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.AiImportBox = new System.Windows.Forms.TextBox();
			this.StatusText = new System.Windows.Forms.Label();
			this.AiFileBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(14, 207);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(374, 23);
			this.ProgressBar.TabIndex = 58;
			// 
			// ButtonAbout
			// 
			this.ButtonAbout.Location = new System.Drawing.Point(131, 159);
			this.ButtonAbout.Name = "ButtonAbout";
			this.ButtonAbout.Size = new System.Drawing.Size(75, 23);
			this.ButtonAbout.TabIndex = 57;
			this.ButtonAbout.Text = "About";
			this.ButtonAbout.UseVisualStyleBackColor = true;
			this.ButtonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(14, 11);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(111, 170);
			this.PictureBox1.TabIndex = 56;
			this.PictureBox1.TabStop = false;
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(313, 158);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 55;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonExport
			// 
			this.ButtonExport.Location = new System.Drawing.Point(131, 86);
			this.ButtonExport.Name = "ButtonExport";
			this.ButtonExport.Size = new System.Drawing.Size(75, 23);
			this.ButtonExport.TabIndex = 54;
			this.ButtonExport.Text = "Export";
			this.ButtonExport.UseVisualStyleBackColor = true;
			this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
			// 
			// ButtonImport
			// 
			this.ButtonImport.Location = new System.Drawing.Point(131, 115);
			this.ButtonImport.Name = "ButtonImport";
			this.ButtonImport.Size = new System.Drawing.Size(75, 23);
			this.ButtonImport.TabIndex = 53;
			this.ButtonImport.Text = "Import";
			this.ButtonImport.UseVisualStyleBackColor = true;
			this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(291, 118);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 63;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(244, 86);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(144, 32);
			this.Label2.TabIndex = 62;
			this.Label2.Text = "Import/Export teleport\r\nname in Ai.obj";
			// 
			// AiImportBox
			// 
			this.AiImportBox.Location = new System.Drawing.Point(131, 37);
			this.AiImportBox.Name = "AiImportBox";
			this.AiImportBox.ReadOnly = true;
			this.AiImportBox.Size = new System.Drawing.Size(257, 20);
			this.AiImportBox.TabIndex = 61;
			// 
			// StatusText
			// 
			this.StatusText.AutoSize = true;
			this.StatusText.Location = new System.Drawing.Point(11, 191);
			this.StatusText.Name = "StatusText";
			this.StatusText.Size = new System.Drawing.Size(0, 13);
			this.StatusText.TabIndex = 60;
			// 
			// AiFileBox
			// 
			this.AiFileBox.Location = new System.Drawing.Point(131, 11);
			this.AiFileBox.Name = "AiFileBox";
			this.AiFileBox.ReadOnly = true;
			this.AiFileBox.Size = new System.Drawing.Size(257, 20);
			this.AiFileBox.TabIndex = 59;
			// 
			// AIMessageTeleportImporter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 241);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.ButtonAbout);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonExport);
			this.Controls.Add(this.ButtonImport);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.AiImportBox);
			this.Controls.Add(this.StatusText);
			this.Controls.Add(this.AiFileBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AIMessageTeleportImporter";
			this.Text = "Import/Export teleport name in Ai.obj";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Button ButtonAbout;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonExport;
		internal System.Windows.Forms.Button ButtonImport;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox AiImportBox;
		internal System.Windows.Forms.Label StatusText;
		internal System.Windows.Forms.TextBox AiFileBox;
	}
}