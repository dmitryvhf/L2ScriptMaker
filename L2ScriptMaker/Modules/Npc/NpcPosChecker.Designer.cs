namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcPosChecker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcPosChecker));
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.QuotButton = new System.Windows.Forms.Button();
			this.DBNameButton = new System.Windows.Forms.Button();
			this.AiPrivatesButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.MakerNameButton = new System.Windows.Forms.Button();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.OutsiderOffsetTextBox = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.OutsiderButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(138, 20);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 61;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(138, 4);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(109, 16);
			this.Label2.TabIndex = 60;
			this.Label2.Text = "Npcpos Checker";
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(23, 193);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 59;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(125, 36);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(126, 35);
			this.StartButton.TabIndex = 58;
			this.StartButton.Text = "NpcPos Privates Checker";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// QuotButton
			// 
			this.QuotButton.Location = new System.Drawing.Point(125, 164);
			this.QuotButton.Name = "QuotButton";
			this.QuotButton.Size = new System.Drawing.Size(126, 23);
			this.QuotButton.TabIndex = 66;
			this.QuotButton.Text = "Quot Checker";
			this.QuotButton.UseVisualStyleBackColor = true;
			this.QuotButton.Click += new System.EventHandler(this.QuotButton_Click);
			// 
			// DBNameButton
			// 
			this.DBNameButton.Location = new System.Drawing.Point(125, 135);
			this.DBNameButton.Name = "DBNameButton";
			this.DBNameButton.Size = new System.Drawing.Size(126, 23);
			this.DBNameButton.TabIndex = 65;
			this.DBNameButton.Text = "DBName Checker";
			this.DBNameButton.UseVisualStyleBackColor = true;
			this.DBNameButton.Click += new System.EventHandler(this.DBNameButton_Click);
			// 
			// AiPrivatesButton
			// 
			this.AiPrivatesButton.Location = new System.Drawing.Point(125, 77);
			this.AiPrivatesButton.Name = "AiPrivatesButton";
			this.AiPrivatesButton.Size = new System.Drawing.Size(126, 23);
			this.AiPrivatesButton.TabIndex = 64;
			this.AiPrivatesButton.Text = "AI.obj Privates Checker";
			this.AiPrivatesButton.UseVisualStyleBackColor = true;
			this.AiPrivatesButton.Click += new System.EventHandler(this.AiPrivatesButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(6, 27);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(110, 160);
			this.PictureBox1.TabIndex = 63;
			this.PictureBox1.TabStop = false;
			// 
			// MakerNameButton
			// 
			this.MakerNameButton.Location = new System.Drawing.Point(125, 106);
			this.MakerNameButton.Name = "MakerNameButton";
			this.MakerNameButton.Size = new System.Drawing.Size(126, 23);
			this.MakerNameButton.TabIndex = 62;
			this.MakerNameButton.Text = "MakerName Checker";
			this.MakerNameButton.UseVisualStyleBackColor = true;
			this.MakerNameButton.Click += new System.EventHandler(this.MakerNameButton_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar});
			this.StatusStrip.Location = new System.Drawing.Point(0, 249);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(259, 22);
			this.StatusStrip.TabIndex = 67;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(240, 16);
			// 
			// OutsiderOffsetTextBox
			// 
			this.OutsiderOffsetTextBox.Location = new System.Drawing.Point(207, 219);
			this.OutsiderOffsetTextBox.Name = "OutsiderOffsetTextBox";
			this.OutsiderOffsetTextBox.Size = new System.Drawing.Size(40, 20);
			this.OutsiderOffsetTextBox.TabIndex = 70;
			this.OutsiderOffsetTextBox.Text = "300";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(126, 222);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(75, 13);
			this.Label1.TabIndex = 69;
			this.Label1.Text = "Outsider grow:";
			// 
			// OutsiderButton
			// 
			this.OutsiderButton.Location = new System.Drawing.Point(125, 193);
			this.OutsiderButton.Name = "OutsiderButton";
			this.OutsiderButton.Size = new System.Drawing.Size(126, 23);
			this.OutsiderButton.TabIndex = 68;
			this.OutsiderButton.Text = "Outsider Checker";
			this.OutsiderButton.UseVisualStyleBackColor = true;
			this.OutsiderButton.Click += new System.EventHandler(this.OutsiderButton_Click);
			// 
			// NpcPosChecker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(259, 271);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.QuotButton);
			this.Controls.Add(this.DBNameButton);
			this.Controls.Add(this.AiPrivatesButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.MakerNameButton);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.OutsiderOffsetTextBox);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.OutsiderButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcPosChecker";
			this.Text = "NpcPosChecker";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Button QuotButton;
		internal System.Windows.Forms.Button DBNameButton;
		internal System.Windows.Forms.Button AiPrivatesButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button MakerNameButton;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.TextBox OutsiderOffsetTextBox;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button OutsiderButton;
	}
}