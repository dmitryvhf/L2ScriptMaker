
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
			this.ckbValidFixPath = new System.Windows.Forms.CheckBox();
			this.txbLogsFolder = new System.Windows.Forms.TextBox();
			this.lblLogs = new System.Windows.Forms.Label();
			this.txbWorkFolder = new System.Windows.Forms.TextBox();
			this.lblWorkFolder = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ckbValidFixPath);
			this.groupBox1.Controls.Add(this.txbLogsFolder);
			this.groupBox1.Controls.Add(this.lblLogs);
			this.groupBox1.Controls.Add(this.txbWorkFolder);
			this.groupBox1.Controls.Add(this.lblWorkFolder);
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.groupBox1.Location = new System.Drawing.Point(14, 14);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox1.Size = new System.Drawing.Size(514, 122);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Folders";
			// 
			// ckbValidFixPath
			// 
			this.ckbValidFixPath.AutoSize = true;
			this.ckbValidFixPath.Checked = true;
			this.ckbValidFixPath.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbValidFixPath.Location = new System.Drawing.Point(10, 93);
			this.ckbValidFixPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.ckbValidFixPath.Name = "ckbValidFixPath";
			this.ckbValidFixPath.Size = new System.Drawing.Size(189, 17);
			this.ckbValidFixPath.TabIndex = 4;
			this.ckbValidFixPath.Text = "Validate and fix path on save";
			this.ckbValidFixPath.UseVisualStyleBackColor = true;
			// 
			// txbLogsFolder
			// 
			this.txbLogsFolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txbLogsFolder.Location = new System.Drawing.Point(56, 47);
			this.txbLogsFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txbLogsFolder.Name = "txbLogsFolder";
			this.txbLogsFolder.Size = new System.Drawing.Size(447, 21);
			this.txbLogsFolder.TabIndex = 3;
			// 
			// lblLogs
			// 
			this.lblLogs.AutoSize = true;
			this.lblLogs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblLogs.Location = new System.Drawing.Point(7, 51);
			this.lblLogs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblLogs.Name = "lblLogs";
			this.lblLogs.Size = new System.Drawing.Size(33, 13);
			this.lblLogs.TabIndex = 2;
			this.lblLogs.Text = "Logs:";
			// 
			// txbWorkFolder
			// 
			this.txbWorkFolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txbWorkFolder.Location = new System.Drawing.Point(56, 16);
			this.txbWorkFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txbWorkFolder.Name = "txbWorkFolder";
			this.txbWorkFolder.Size = new System.Drawing.Size(447, 21);
			this.txbWorkFolder.TabIndex = 1;
			// 
			// lblWorkFolder
			// 
			this.lblWorkFolder.AutoSize = true;
			this.lblWorkFolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblWorkFolder.Location = new System.Drawing.Point(7, 20);
			this.lblWorkFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblWorkFolder.Name = "lblWorkFolder";
			this.lblWorkFolder.Size = new System.Drawing.Size(36, 13);
			this.lblWorkFolder.TabIndex = 0;
			this.lblWorkFolder.Text = "Work:";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(441, 143);
			this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(88, 27);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Save&&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 140);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 30);
			this.label1.TabIndex = 1;
			this.label1.Text = "Double click - open folder select dialog.\r\nConfig file will autosave on closing.";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(539, 183);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "SettingsForm";
			this.Text = "Application settings";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txbWorkFolder;
		private System.Windows.Forms.Label lblWorkFolder;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox txbLogsFolder;
		private System.Windows.Forms.Label lblLogs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox ckbValidFixPath;
	}
}