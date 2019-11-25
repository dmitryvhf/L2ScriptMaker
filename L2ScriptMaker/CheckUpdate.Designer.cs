namespace L2ScriptMaker
{
	partial class CheckUpdate
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckUpdate));
			this.Label2 = new System.Windows.Forms.Label();
			this.MailFromTextBox = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.MailSrvTextBox = new System.Windows.Forms.TextBox();
			this.TextBox = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.CheckStatLinkLabel = new System.Windows.Forms.LinkLabel();
			this.CheckStatLabel = new System.Windows.Forms.Label();
			this.SendMailButton = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.SubjectTextBox = new System.Windows.Forms.TextBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.StartButton = new System.Windows.Forms.Button();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.QuitButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(214, 46);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(33, 13);
			this.Label2.TabIndex = 10;
			this.Label2.Text = "From:";
			// 
			// MailFromTextBox
			// 
			this.MailFromTextBox.Location = new System.Drawing.Point(217, 63);
			this.MailFromTextBox.Name = "MailFromTextBox";
			this.MailFromTextBox.Size = new System.Drawing.Size(148, 20);
			this.MailFromTextBox.TabIndex = 9;
			this.MailFromTextBox.Text = "tooluser@mailservername";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(214, 6);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(63, 13);
			this.Label1.TabIndex = 8;
			this.Label1.Text = "Mail Server:";
			// 
			// MailSrvTextBox
			// 
			this.MailSrvTextBox.Location = new System.Drawing.Point(217, 23);
			this.MailSrvTextBox.Name = "MailSrvTextBox";
			this.MailSrvTextBox.Size = new System.Drawing.Size(148, 20);
			this.MailSrvTextBox.TabIndex = 7;
			this.MailSrvTextBox.Text = "mailservername";
			// 
			// TextBox
			// 
			this.TextBox.Location = new System.Drawing.Point(6, 32);
			this.TextBox.Multiline = true;
			this.TextBox.Name = "TextBox";
			this.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TextBox.Size = new System.Drawing.Size(205, 125);
			this.TextBox.TabIndex = 5;
			this.TextBox.Text = "Hi :)";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(6, 80);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(117, 13);
			this.Label4.TabIndex = 5;
			this.Label4.Text = "Information about build:";
			// 
			// CheckStatLinkLabel
			// 
			this.CheckStatLinkLabel.AutoSize = true;
			this.CheckStatLinkLabel.Location = new System.Drawing.Point(6, 93);
			this.CheckStatLinkLabel.Name = "CheckStatLinkLabel";
			this.CheckStatLinkLabel.Size = new System.Drawing.Size(0, 13);
			this.CheckStatLinkLabel.TabIndex = 4;
			this.CheckStatLinkLabel.Click += new System.EventHandler(this.CheckStatLinkLabel_Click);
			// 
			// CheckStatLabel
			// 
			this.CheckStatLabel.AutoSize = true;
			this.CheckStatLabel.Location = new System.Drawing.Point(6, 67);
			this.CheckStatLabel.Name = "CheckStatLabel";
			this.CheckStatLabel.Size = new System.Drawing.Size(90, 13);
			this.CheckStatLabel.TabIndex = 3;
			this.CheckStatLabel.Text = "Version detected:";
			// 
			// SendMailButton
			// 
			this.SendMailButton.Location = new System.Drawing.Point(217, 89);
			this.SendMailButton.Name = "SendMailButton";
			this.SendMailButton.Size = new System.Drawing.Size(100, 39);
			this.SendMailButton.TabIndex = 11;
			this.SendMailButton.Text = "Send Mail to tool owner";
			this.SendMailButton.UseVisualStyleBackColor = true;
			this.SendMailButton.Click += new System.EventHandler(this.SendMailButton_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(6, 54);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(85, 13);
			this.Label3.TabIndex = 2;
			this.Label3.Text = "Check status:";
			// 
			// SubjectTextBox
			// 
			this.SubjectTextBox.Location = new System.Drawing.Point(6, 6);
			this.SubjectTextBox.Name = "SubjectTextBox";
			this.SubjectTextBox.Size = new System.Drawing.Size(205, 20);
			this.SubjectTextBox.TabIndex = 6;
			this.SubjectTextBox.Text = "L2ScriptMaker";
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(125, 11);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(379, 189);
			this.TabControl1.TabIndex = 6;
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.Label4);
			this.TabPage1.Controls.Add(this.CheckStatLinkLabel);
			this.TabPage1.Controls.Add(this.CheckStatLabel);
			this.TabPage1.Controls.Add(this.Label3);
			this.TabPage1.Controls.Add(this.StartButton);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(371, 163);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Updates";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(6, 6);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(143, 45);
			this.StartButton.TabIndex = 1;
			this.StartButton.Text = "I want to check, maybe HF\r\nmade new release...";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.SendMailButton);
			this.TabPage2.Controls.Add(this.Label2);
			this.TabPage2.Controls.Add(this.MailFromTextBox);
			this.TabPage2.Controls.Add(this.Label1);
			this.TabPage2.Controls.Add(this.MailSrvTextBox);
			this.TabPage2.Controls.Add(this.SubjectTextBox);
			this.TabPage2.Controls.Add(this.TextBox);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(371, 163);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Feedback";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(31, 177);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 5;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(10, 11);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(109, 160);
			this.PictureBox1.TabIndex = 4;
			this.PictureBox1.TabStop = false;
			// 
			// CheckUpdate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 211);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "CheckUpdate";
			this.Text = "Update support tool";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox MailFromTextBox;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox MailSrvTextBox;
		internal System.Windows.Forms.TextBox TextBox;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.LinkLabel CheckStatLinkLabel;
		internal System.Windows.Forms.Label CheckStatLabel;
		internal System.Windows.Forms.Button SendMailButton;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox SubjectTextBox;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}