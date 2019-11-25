namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcDataChecker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcDataChecker));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.CheckBoxZzoldagu74 = new System.Windows.Forms.CheckBox();
			this.NoWarriorUndCheckBox = new System.Windows.Forms.CheckBox();
			this.NoWarriorCheckBox = new System.Windows.Forms.CheckBox();
			this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel1});
			this.StatusStrip.Location = new System.Drawing.Point(0, 179);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(494, 22);
			this.StatusStrip.TabIndex = 64;
			this.StatusStrip.Text = "StatusStrip";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(300, 16);
			// 
			// ToolStripStatusLabel1
			// 
			this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
			this.ToolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(404, 83);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 63;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(404, 54);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 62;
			this.StartButton.Text = "Scanning...";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 159);
			this.PictureBox1.TabIndex = 61;
			this.PictureBox1.TabStop = false;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(366, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(113, 13);
			this.Label3.TabIndex = 66;
			this.Label3.Text = "(support all Chronicles)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(300, 6);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(179, 16);
			this.Label2.TabIndex = 65;
			this.Label2.Text = "NpcData Analyser and Fixer";
			// 
			// CheckBoxZzoldagu74
			// 
			this.CheckBoxZzoldagu74.AutoSize = true;
			this.CheckBoxZzoldagu74.Location = new System.Drawing.Point(304, 142);
			this.CheckBoxZzoldagu74.Name = "CheckBoxZzoldagu74";
			this.CheckBoxZzoldagu74.Size = new System.Drawing.Size(133, 17);
			this.CheckBoxZzoldagu74.TabIndex = 70;
			this.CheckBoxZzoldagu74.Text = "Zzoldagu74+ like Boss";
			this.CheckBoxZzoldagu74.UseVisualStyleBackColor = true;
			// 
			// NoWarriorUndCheckBox
			// 
			this.NoWarriorUndCheckBox.AutoSize = true;
			this.NoWarriorUndCheckBox.Location = new System.Drawing.Point(303, 114);
			this.NoWarriorUndCheckBox.Name = "NoWarriorUndCheckBox";
			this.NoWarriorUndCheckBox.Size = new System.Drawing.Size(96, 17);
			this.NoWarriorUndCheckBox.TabIndex = 69;
			this.NoWarriorUndCheckBox.Text = "except \'warrior\'";
			this.NoWarriorUndCheckBox.UseVisualStyleBackColor = true;
			// 
			// NoWarriorCheckBox
			// 
			this.NoWarriorCheckBox.AutoSize = true;
			this.NoWarriorCheckBox.Location = new System.Drawing.Point(303, 54);
			this.NoWarriorCheckBox.Name = "NoWarriorCheckBox";
			this.NoWarriorCheckBox.Size = new System.Drawing.Size(96, 17);
			this.NoWarriorCheckBox.TabIndex = 68;
			this.NoWarriorCheckBox.Text = "except \'warrior\'";
			this.NoWarriorCheckBox.UseVisualStyleBackColor = true;
			// 
			// CheckedListBox
			// 
			this.CheckedListBox.FormattingEnabled = true;
			this.CheckedListBox.Items.AddRange(new object[] {
            "acquire_exp_rate, acquire_sp",
            "unsowing",
            "slot_rhand, base_attack_type",
            "agro_range",
            "no_sleep_mode",
            "undying, can_be_attacked",
            "npc active skill",
            "castle bowguard range",
            "npc race",
            "stats (str,int,dex,wit,con,men)"});
			this.CheckedListBox.Location = new System.Drawing.Point(128, 6);
			this.CheckedListBox.Name = "CheckedListBox";
			this.CheckedListBox.Size = new System.Drawing.Size(169, 154);
			this.CheckedListBox.TabIndex = 67;
			// 
			// NpcDataChecker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 201);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.CheckBoxZzoldagu74);
			this.Controls.Add(this.NoWarriorUndCheckBox);
			this.Controls.Add(this.NoWarriorCheckBox);
			this.Controls.Add(this.CheckedListBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcDataChecker";
			this.Text = "NpcDataChecker";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.CheckBox CheckBoxZzoldagu74;
		internal System.Windows.Forms.CheckBox NoWarriorUndCheckBox;
		internal System.Windows.Forms.CheckBox NoWarriorCheckBox;
		internal System.Windows.Forms.CheckedListBox CheckedListBox;
	}
}