
namespace L2ScriptMaker.Forms.Modules
{
	partial class SettingsForm
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txbWorkFolder = new System.Windows.Forms.TextBox();
			this.lblWorkFolder = new System.Windows.Forms.Label();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.btnClose = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnClose);
			this.groupBox1.Controls.Add(this.txbWorkFolder);
			this.groupBox1.Controls.Add(this.lblWorkFolder);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(470, 93);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Global";
			// 
			// txbWorkFolder
			// 
			this.txbWorkFolder.Location = new System.Drawing.Point(77, 30);
			this.txbWorkFolder.Name = "txbWorkFolder";
			this.txbWorkFolder.Size = new System.Drawing.Size(384, 20);
			this.txbWorkFolder.TabIndex = 1;
			this.txbWorkFolder.DoubleClick += new System.EventHandler(this.txbWorkFolder_DoubleClick);
			// 
			// lblWorkFolder
			// 
			this.lblWorkFolder.AutoSize = true;
			this.lblWorkFolder.Location = new System.Drawing.Point(6, 33);
			this.lblWorkFolder.Name = "lblWorkFolder";
			this.lblWorkFolder.Size = new System.Drawing.Size(65, 13);
			this.lblWorkFolder.TabIndex = 0;
			this.lblWorkFolder.Text = "Work folder:";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(386, 56);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 115);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SettingsForm";
			this.Text = "Application settings";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txbWorkFolder;
		private System.Windows.Forms.Label lblWorkFolder;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button btnClose;
	}
}