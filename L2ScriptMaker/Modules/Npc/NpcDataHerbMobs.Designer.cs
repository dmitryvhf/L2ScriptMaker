namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcDataHerbMobs
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcDataHerbMobs));
			this.RaduisZTextBox = new System.Windows.Forms.TextBox();
			this.RaduisXYTextBox = new System.Windows.Forms.TextBox();
			this.CheckBoxDungeon = new System.Windows.Forms.CheckBox();
			this.CheckBoxLa2Herb = new System.Windows.Forms.CheckBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.HerbMobMinLvlTextBox = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.HerbMobTypeTextBox = new System.Windows.Forms.TextBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// RaduisZTextBox
			// 
			this.RaduisZTextBox.Location = new System.Drawing.Point(278, 123);
			this.RaduisZTextBox.Name = "RaduisZTextBox";
			this.RaduisZTextBox.Size = new System.Drawing.Size(100, 20);
			this.RaduisZTextBox.TabIndex = 84;
			this.RaduisZTextBox.Text = "1000";
			// 
			// RaduisXYTextBox
			// 
			this.RaduisXYTextBox.Location = new System.Drawing.Point(278, 97);
			this.RaduisXYTextBox.Name = "RaduisXYTextBox";
			this.RaduisXYTextBox.Size = new System.Drawing.Size(100, 20);
			this.RaduisXYTextBox.TabIndex = 83;
			this.RaduisXYTextBox.Text = "13000";
			// 
			// CheckBoxDungeon
			// 
			this.CheckBoxDungeon.AutoSize = true;
			this.CheckBoxDungeon.Location = new System.Drawing.Point(267, 61);
			this.CheckBoxDungeon.Name = "CheckBoxDungeon";
			this.CheckBoxDungeon.Size = new System.Drawing.Size(111, 17);
			this.CheckBoxDungeon.TabIndex = 82;
			this.CheckBoxDungeon.Text = "Enable Dungeons";
			this.CheckBoxDungeon.UseVisualStyleBackColor = true;
			// 
			// CheckBoxLa2Herb
			// 
			this.CheckBoxLa2Herb.AutoSize = true;
			this.CheckBoxLa2Herb.Checked = true;
			this.CheckBoxLa2Herb.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxLa2Herb.Location = new System.Drawing.Point(142, 61);
			this.CheckBoxLa2Herb.Name = "CheckBoxLa2Herb";
			this.CheckBoxLa2Herb.Size = new System.Drawing.Size(106, 17);
			this.CheckBoxLa2Herb.TabIndex = 81;
			this.CheckBoxLa2Herb.Text = "La2Guard Param";
			this.CheckBoxLa2Herb.UseVisualStyleBackColor = true;
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label6.Location = new System.Drawing.Point(139, 120);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(119, 13);
			this.Label6.TabIndex = 80;
			this.Label6.Text = "Herb mob min level:";
			// 
			// HerbMobMinLvlTextBox
			// 
			this.HerbMobMinLvlTextBox.Location = new System.Drawing.Point(142, 136);
			this.HerbMobMinLvlTextBox.Name = "HerbMobMinLvlTextBox";
			this.HerbMobMinLvlTextBox.Size = new System.Drawing.Size(100, 20);
			this.HerbMobMinLvlTextBox.TabIndex = 79;
			this.HerbMobMinLvlTextBox.Text = "1";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label5.Location = new System.Drawing.Point(139, 81);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(186, 13);
			this.Label5.TabIndex = 78;
			this.Label5.Text = "dVampire Herb mob type name:";
			// 
			// HerbMobTypeTextBox
			// 
			this.HerbMobTypeTextBox.Location = new System.Drawing.Point(142, 97);
			this.HerbMobTypeTextBox.Name = "HerbMobTypeTextBox";
			this.HerbMobTypeTextBox.Size = new System.Drawing.Size(100, 20);
			this.HerbMobTypeTextBox.TabIndex = 77;
			this.HerbMobTypeTextBox.Text = "herb_warrior";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(250, 16);
			this.ToolStripProgressBar.Step = 1;
			this.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 209);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(399, 22);
			this.StatusStrip.TabIndex = 76;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// ToolStripStatusLabel
			// 
			this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
			this.ToolStripStatusLabel.Size = new System.Drawing.Size(66, 17);
			this.ToolStripStatusLabel.Text = "Welcome...";
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(231, 162);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 75;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(129, 162);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 74;
			this.ButtonStart.Text = "Start";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(126, 6);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(132, 16);
			this.Label2.TabIndex = 72;
			this.Label2.Text = "Herb Mob generator";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 159);
			this.PictureBox1.TabIndex = 71;
			this.PictureBox1.TabStop = false;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(139, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(176, 26);
			this.Label3.TabIndex = 73;
			this.Label3.Text = "(support L2Disasm client file\r\nsupport La2Guard Herb mob option)";
			// 
			// NpcDataHerbMobs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 231);
			this.Controls.Add(this.RaduisZTextBox);
			this.Controls.Add(this.RaduisXYTextBox);
			this.Controls.Add(this.CheckBoxDungeon);
			this.Controls.Add(this.CheckBoxLa2Herb);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.HerbMobMinLvlTextBox);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.HerbMobTypeTextBox);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Label3);
			this.Name = "NpcDataHerbMobs";
			this.Text = "NpcDataHerbMobs";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.TextBox RaduisZTextBox;
		internal System.Windows.Forms.TextBox RaduisXYTextBox;
		internal System.Windows.Forms.CheckBox CheckBoxDungeon;
		internal System.Windows.Forms.CheckBox CheckBoxLa2Herb;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox HerbMobMinLvlTextBox;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox HerbMobTypeTextBox;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Label Label3;
	}
}