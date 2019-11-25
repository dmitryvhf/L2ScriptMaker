namespace L2ScriptMaker.Modules.Others
{
	partial class ExecL2AuthKey
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecL2AuthKey));
			this.KeyLoadBox = new System.Windows.Forms.TextBox();
			this.LoadButton = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.ButtonExit = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.WriteButton = new System.Windows.Forms.Button();
			this.LoadKeyHexBox = new System.Windows.Forms.TextBox();
			this.CopyButton = new System.Windows.Forms.Button();
			this.NewKeyBox = new System.Windows.Forms.TextBox();
			this.LoadKeyLabel = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// KeyLoadBox
			// 
			this.KeyLoadBox.Location = new System.Drawing.Point(129, 87);
			this.KeyLoadBox.Name = "KeyLoadBox";
			this.KeyLoadBox.ReadOnly = true;
			this.KeyLoadBox.Size = new System.Drawing.Size(131, 20);
			this.KeyLoadBox.TabIndex = 72;
			this.KeyLoadBox.TextChanged += new System.EventHandler(this.KeyLoadBox_TextChanged);
			// 
			// LoadButton
			// 
			this.LoadButton.Location = new System.Drawing.Point(129, 58);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(124, 23);
			this.LoadButton.TabIndex = 71;
			this.LoadButton.Text = "Load BlowFish Key";
			this.LoadButton.UseVisualStyleBackColor = true;
			this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(126, 29);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(97, 13);
			this.Label1.TabIndex = 70;
			this.Label1.Text = "(support C4 scripts)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(126, 13);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(245, 16);
			this.Label2.TabIndex = 69;
			this.Label2.Text = "Authentifycation Blowfish Change Key";
			// 
			// ButtonExit
			// 
			this.ButtonExit.Location = new System.Drawing.Point(533, 140);
			this.ButtonExit.Name = "ButtonExit";
			this.ButtonExit.Size = new System.Drawing.Size(75, 23);
			this.ButtonExit.TabIndex = 68;
			this.ButtonExit.Text = "Exit";
			this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(11, 13);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(109, 160);
			this.PictureBox1.TabIndex = 67;
			this.PictureBox1.TabStop = false;
			// 
			// WriteButton
			// 
			this.WriteButton.Location = new System.Drawing.Point(390, 140);
			this.WriteButton.Name = "WriteButton";
			this.WriteButton.Size = new System.Drawing.Size(124, 23);
			this.WriteButton.TabIndex = 78;
			this.WriteButton.Text = "Write BlowFish Key";
			this.WriteButton.UseVisualStyleBackColor = true;
			this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
			// 
			// LoadKeyHexBox
			// 
			this.LoadKeyHexBox.Location = new System.Drawing.Point(266, 87);
			this.LoadKeyHexBox.Name = "LoadKeyHexBox";
			this.LoadKeyHexBox.ReadOnly = true;
			this.LoadKeyHexBox.Size = new System.Drawing.Size(342, 20);
			this.LoadKeyHexBox.TabIndex = 77;
			// 
			// CopyButton
			// 
			this.CopyButton.Location = new System.Drawing.Point(129, 113);
			this.CopyButton.Name = "CopyButton";
			this.CopyButton.Size = new System.Drawing.Size(75, 23);
			this.CopyButton.TabIndex = 76;
			this.CopyButton.Text = "Copy key";
			this.CopyButton.UseVisualStyleBackColor = true;
			this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
			// 
			// NewKeyBox
			// 
			this.NewKeyBox.Location = new System.Drawing.Point(129, 142);
			this.NewKeyBox.Name = "NewKeyBox";
			this.NewKeyBox.Size = new System.Drawing.Size(131, 20);
			this.NewKeyBox.TabIndex = 75;
			this.NewKeyBox.TextChanged += new System.EventHandler(this.NewKeyBox_TextChanged);
			// 
			// LoadKeyLabel
			// 
			this.LoadKeyLabel.AutoSize = true;
			this.LoadKeyLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LoadKeyLabel.Location = new System.Drawing.Point(338, 63);
			this.LoadKeyLabel.Name = "LoadKeyLabel";
			this.LoadKeyLabel.Size = new System.Drawing.Size(13, 14);
			this.LoadKeyLabel.TabIndex = 74;
			this.LoadKeyLabel.Text = "0";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(264, 63);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(68, 14);
			this.Label3.TabIndex = 73;
			this.Label3.Text = "Key length:";
			// 
			// ExecL2AuthKey
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(619, 186);
			this.Controls.Add(this.KeyLoadBox);
			this.Controls.Add(this.LoadButton);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ButtonExit);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.WriteButton);
			this.Controls.Add(this.LoadKeyHexBox);
			this.Controls.Add(this.CopyButton);
			this.Controls.Add(this.NewKeyBox);
			this.Controls.Add(this.LoadKeyLabel);
			this.Controls.Add(this.Label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ExecL2AuthKey";
			this.Text = "ExecL2AuthKey";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.TextBox KeyLoadBox;
		internal System.Windows.Forms.Button LoadButton;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button ButtonExit;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Button WriteButton;
		internal System.Windows.Forms.TextBox LoadKeyHexBox;
		internal System.Windows.Forms.Button CopyButton;
		internal System.Windows.Forms.TextBox NewKeyBox;
		internal System.Windows.Forms.Label LoadKeyLabel;
		internal System.Windows.Forms.Label Label3;
	}
}