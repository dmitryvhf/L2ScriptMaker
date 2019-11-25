namespace L2ScriptMaker.Modules.Others
{
	partial class ExecInjector
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
			this.RecoveryBox = new System.Windows.Forms.CheckBox();
			this.FixName = new System.Windows.Forms.TextBox();
			this.QuitButton = new System.Windows.Forms.Button();
			this.InjectButton = new System.Windows.Forms.Button();
			this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.ExecName = new System.Windows.Forms.TextBox();
			this.Help = new System.Windows.Forms.Button();
			this.Button1 = new System.Windows.Forms.Button();
			this.IsOffset = new System.Windows.Forms.CheckBox();
			this.HelpButton2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// RecoveryBox
			// 
			this.RecoveryBox.AutoSize = true;
			this.RecoveryBox.Location = new System.Drawing.Point(317, 24);
			this.RecoveryBox.Name = "RecoveryBox";
			this.RecoveryBox.Size = new System.Drawing.Size(88, 17);
			this.RecoveryBox.TabIndex = 16;
			this.RecoveryBox.Text = "Recovery Fix";
			// 
			// FixName
			// 
			this.FixName.Location = new System.Drawing.Point(11, 69);
			this.FixName.Name = "FixName";
			this.FixName.ReadOnly = true;
			this.FixName.Size = new System.Drawing.Size(300, 20);
			this.FixName.TabIndex = 11;
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(337, 92);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 10;
			this.QuitButton.Text = "Quit";
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// InjectButton
			// 
			this.InjectButton.Location = new System.Drawing.Point(11, 95);
			this.InjectButton.Name = "InjectButton";
			this.InjectButton.Size = new System.Drawing.Size(75, 23);
			this.InjectButton.TabIndex = 9;
			this.InjectButton.Text = "Inject";
			this.InjectButton.Click += new System.EventHandler(this.InjectButton_Click);
			// 
			// OpenFileDialog1
			// 
			this.OpenFileDialog1.FileName = "OpenFileDialog1";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(11, 53);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(63, 13);
			this.Label2.TabIndex = 14;
			this.Label2.Text = "Fix data file:";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(11, 8);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(75, 13);
			this.Label1.TabIndex = 13;
			this.Label1.Text = "Exec file to fix:";
			// 
			// ExecName
			// 
			this.ExecName.Location = new System.Drawing.Point(11, 24);
			this.ExecName.Name = "ExecName";
			this.ExecName.ReadOnly = true;
			this.ExecName.Size = new System.Drawing.Size(300, 20);
			this.ExecName.TabIndex = 12;
			// 
			// Help
			// 
			this.Help.Location = new System.Drawing.Point(12, 95);
			this.Help.Name = "Help";
			this.Help.Size = new System.Drawing.Size(75, 23);
			this.Help.TabIndex = 17;
			this.Help.Text = "Help";
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(12, 95);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 18;
			this.Button1.Text = "Help";
			// 
			// IsOffset
			// 
			this.IsOffset.AutoSize = true;
			this.IsOffset.Location = new System.Drawing.Point(317, 47);
			this.IsOffset.Name = "IsOffset";
			this.IsOffset.Size = new System.Drawing.Size(101, 17);
			this.IsOffset.TabIndex = 19;
			this.IsOffset.Text = "is 40000h offset";
			// 
			// HelpButton2
			// 
			this.HelpButton2.Location = new System.Drawing.Point(236, 92);
			this.HelpButton2.Name = "HelpButton2";
			this.HelpButton2.Size = new System.Drawing.Size(75, 23);
			this.HelpButton2.TabIndex = 15;
			this.HelpButton2.Text = "Help";
			this.HelpButton2.Click += new System.EventHandler(this.HelpButton_Click);
			// 
			// ExecInjector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 126);
			this.Controls.Add(this.RecoveryBox);
			this.Controls.Add(this.FixName);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.InjectButton);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.ExecName);
			this.Controls.Add(this.Help);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.IsOffset);
			this.Controls.Add(this.HelpButton2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ExecInjector";
			this.Text = "ExecInjector";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.CheckBox RecoveryBox;
		internal System.Windows.Forms.TextBox FixName;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button InjectButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox ExecName;
		internal System.Windows.Forms.Button Help;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.CheckBox IsOffset;
		internal System.Windows.Forms.Button HelpButton2;
	}
}