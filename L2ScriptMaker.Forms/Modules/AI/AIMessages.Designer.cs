
namespace L2ScriptMaker.Forms.Modules.AI
{
	partial class AIMessages
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIMessages));
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonExport = new System.Windows.Forms.Button();
			this.ButtonImport = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ButtonAbout = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(145, 131);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 3;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonExport
			// 
			this.ButtonExport.Location = new System.Drawing.Point(145, 73);
			this.ButtonExport.Name = "ButtonExport";
			this.ButtonExport.Size = new System.Drawing.Size(75, 23);
			this.ButtonExport.TabIndex = 1;
			this.ButtonExport.Text = "Export";
			this.ButtonExport.UseVisualStyleBackColor = true;
			this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
			// 
			// ButtonImport
			// 
			this.ButtonImport.Location = new System.Drawing.Point(145, 102);
			this.ButtonImport.Name = "ButtonImport";
			this.ButtonImport.Size = new System.Drawing.Size(75, 23);
			this.ButtonImport.TabIndex = 2;
			this.ButtonImport.Text = "Import";
			this.ButtonImport.UseVisualStyleBackColor = true;
			this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
			// 
			// ButtonAbout
			// 
			this.ButtonAbout.Location = new System.Drawing.Point(145, 32);
			this.ButtonAbout.Name = "ButtonAbout";
			this.ButtonAbout.Size = new System.Drawing.Size(75, 23);
			this.ButtonAbout.TabIndex = 0;
			this.ButtonAbout.Text = "About";
			this.ButtonAbout.UseVisualStyleBackColor = true;
			this.ButtonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(111, 170);
			this.PictureBox1.TabIndex = 13;
			this.PictureBox1.TabStop = false;
			// 
			// AIMessages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(241, 199);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonExport);
			this.Controls.Add(this.ButtonImport);
			this.Controls.Add(this.ButtonAbout);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AIMessages";
			this.Text = "Import/Export messages in Ai.obj";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonExport;
		internal System.Windows.Forms.Button ButtonImport;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Button ButtonAbout;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}