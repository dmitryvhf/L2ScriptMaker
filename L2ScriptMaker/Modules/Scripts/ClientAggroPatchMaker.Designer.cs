namespace L2ScriptMaker.Modules.Scripts
{
	partial class ClientAggroPatchMaker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientAggroPatchMaker));
			this.Label8 = new System.Windows.Forms.Label();
			this.Tag2TextBox = new System.Windows.Forms.TextBox();
			this.Tag1TextBox = new System.Windows.Forms.TextBox();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.MaskAggrTextBox = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.ExampleTextBox = new System.Windows.Forms.TextBox();
			this.MaskPassTextBox = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.Label7 = new System.Windows.Forms.Label();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.Label5 = new System.Windows.Forms.Label();
			this.QuitButton = new System.Windows.Forms.Button();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.StartButton = new System.Windows.Forms.Button();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(6, 41);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(139, 13);
			this.Label8.TabIndex = 3;
			this.Label8.Text = "NpcName-e description tag:";
			// 
			// Tag2TextBox
			// 
			this.Tag2TextBox.Location = new System.Drawing.Point(6, 57);
			this.Tag2TextBox.Name = "Tag2TextBox";
			this.Tag2TextBox.Size = new System.Drawing.Size(100, 20);
			this.Tag2TextBox.TabIndex = 2;
			this.Tag2TextBox.Text = "description";
			// 
			// Tag1TextBox
			// 
			this.Tag1TextBox.Location = new System.Drawing.Point(3, 19);
			this.Tag1TextBox.Name = "Tag1TextBox";
			this.Tag1TextBox.Size = new System.Drawing.Size(100, 20);
			this.Tag1TextBox.TabIndex = 0;
			this.Tag1TextBox.Text = "id";
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.MaskAggrTextBox);
			this.TabPage1.Controls.Add(this.Label6);
			this.TabPage1.Controls.Add(this.ExampleTextBox);
			this.TabPage1.Controls.Add(this.MaskPassTextBox);
			this.TabPage1.Controls.Add(this.Label1);
			this.TabPage1.Controls.Add(this.Label2);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(224, 93);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Settings";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// MaskAggrTextBox
			// 
			this.MaskAggrTextBox.Location = new System.Drawing.Point(112, 21);
			this.MaskAggrTextBox.Name = "MaskAggrTextBox";
			this.MaskAggrTextBox.Size = new System.Drawing.Size(100, 20);
			this.MaskAggrTextBox.TabIndex = 53;
			this.MaskAggrTextBox.Text = "*";
			this.MaskAggrTextBox.TextChanged += new System.EventHandler(this.MaskAggrTextBox_TextChanged);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(109, 44);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(50, 13);
			this.Label6.TabIndex = 58;
			this.Label6.Text = "Example:";
			// 
			// ExampleTextBox
			// 
			this.ExampleTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ExampleTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.ExampleTextBox.Location = new System.Drawing.Point(112, 60);
			this.ExampleTextBox.Name = "ExampleTextBox";
			this.ExampleTextBox.ReadOnly = true;
			this.ExampleTextBox.Size = new System.Drawing.Size(100, 23);
			this.ExampleTextBox.TabIndex = 57;
			this.ExampleTextBox.Text = "Level: 75*";
			// 
			// MaskPassTextBox
			// 
			this.MaskPassTextBox.Location = new System.Drawing.Point(6, 21);
			this.MaskPassTextBox.Name = "MaskPassTextBox";
			this.MaskPassTextBox.Size = new System.Drawing.Size(100, 20);
			this.MaskPassTextBox.TabIndex = 51;
			this.MaskPassTextBox.Text = "Level: $lvl";
			this.MaskPassTextBox.TextChanged += new System.EventHandler(this.MaskPassTextBox_TextChanged);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(3, 5);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(36, 13);
			this.Label1.TabIndex = 52;
			this.Label1.Text = "Mask:";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(109, 5);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(89, 13);
			this.Label2.TabIndex = 54;
			this.Label2.Text = "Aggressive suffix:";
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.Label8);
			this.TabPage2.Controls.Add(this.Tag2TextBox);
			this.TabPage2.Controls.Add(this.Label7);
			this.TabPage2.Controls.Add(this.Tag1TextBox);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(224, 93);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Client format settings";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(3, 3);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(99, 13);
			this.Label7.TabIndex = 1;
			this.Label7.Text = "NpcName-e ID tag:";
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(130, 45);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(232, 119);
			this.TabControl1.TabIndex = 67;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label5.Location = new System.Drawing.Point(126, 22);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(59, 13);
			this.Label5.TabIndex = 65;
			this.Label5.Text = "Idea by k1\'";
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(368, 137);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 66;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(207, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(121, 13);
			this.Label3.TabIndex = 64;
			this.Label3.Text = "(support all client format)";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(126, 6);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(236, 16);
			this.Label4.TabIndex = 63;
			this.Label4.Text = "Npcname-e client aggro patch maker";
			// 
			// ToolStripStatusLabel
			// 
			this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
			this.ToolStripStatusLabel.Size = new System.Drawing.Size(66, 17);
			this.ToolStripStatusLabel.Text = "Welcome...";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(250, 16);
			this.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(368, 108);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 61;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 184);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(454, 22);
			this.StatusStrip.TabIndex = 62;
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 158);
			this.PictureBox1.TabIndex = 60;
			this.PictureBox1.TabStop = false;
			// 
			// ClientAggroPatchMaker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 206);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ClientAggroPatchMaker";
			this.Text = "Npcname-e client aggro patch maker";
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.TextBox Tag2TextBox;
		internal System.Windows.Forms.TextBox Tag1TextBox;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TextBox MaskAggrTextBox;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox ExampleTextBox;
		internal System.Windows.Forms.TextBox MaskPassTextBox;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}