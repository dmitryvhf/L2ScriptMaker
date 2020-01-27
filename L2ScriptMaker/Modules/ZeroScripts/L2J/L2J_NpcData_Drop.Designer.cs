namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	partial class L2J_NpcData_Drop
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(L2J_NpcData_Drop));
			this.TextBoxRateDropRB = new System.Windows.Forms.TextBox();
			this.RadioButtonRateChanceOnly = new System.Windows.Forms.RadioButton();
			this.Label7 = new System.Windows.Forms.Label();
			this.RadioButtonIgnoreDropNpc = new System.Windows.Forms.RadioButton();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.CheckBoxSpecNpcList = new System.Windows.Forms.CheckBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.TextBoxRateDrop = new System.Windows.Forms.TextBox();
			this.TextBoxRateHerb = new System.Windows.Forms.TextBox();
			this.TextBoxRateAdena = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.TextBoxRateSpoil = new System.Windows.Forms.TextBox();
			this.TextBoxRateSealstones = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.ButtonDropChanceUpdate = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonStartL2JPTS = new System.Windows.Forms.Button();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ButtonStartPTSL2J = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.GroupBox1.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// TextBoxRateDropRB
			// 
			this.TextBoxRateDropRB.Enabled = false;
			this.TextBoxRateDropRB.Location = new System.Drawing.Point(142, 42);
			this.TextBoxRateDropRB.Name = "TextBoxRateDropRB";
			this.TextBoxRateDropRB.Size = new System.Drawing.Size(43, 20);
			this.TextBoxRateDropRB.TabIndex = 85;
			this.TextBoxRateDropRB.Text = "1";
			// 
			// RadioButtonRateChanceOnly
			// 
			this.RadioButtonRateChanceOnly.AutoSize = true;
			this.RadioButtonRateChanceOnly.Location = new System.Drawing.Point(9, 129);
			this.RadioButtonRateChanceOnly.Name = "RadioButtonRateChanceOnly";
			this.RadioButtonRateChanceOnly.Size = new System.Drawing.Size(184, 17);
			this.RadioButtonRateChanceOnly.TabIndex = 83;
			this.RadioButtonRateChanceOnly.Text = "Rate Chance only for npc from list";
			this.RadioButtonRateChanceOnly.UseVisualStyleBackColor = true;
			this.RadioButtonRateChanceOnly.CheckedChanged += new System.EventHandler(this.RadioButtonRateChanceOnly_CheckedChanged);
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(96, 45);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(48, 13);
			this.Label7.TabIndex = 84;
			this.Label7.Text = "Drop RB";
			// 
			// RadioButtonIgnoreDropNpc
			// 
			this.RadioButtonIgnoreDropNpc.AutoSize = true;
			this.RadioButtonIgnoreDropNpc.Checked = true;
			this.RadioButtonIgnoreDropNpc.Location = new System.Drawing.Point(9, 111);
			this.RadioButtonIgnoreDropNpc.Name = "RadioButtonIgnoreDropNpc";
			this.RadioButtonIgnoreDropNpc.Size = new System.Drawing.Size(186, 17);
			this.RadioButtonIgnoreDropNpc.TabIndex = 82;
			this.RadioButtonIgnoreDropNpc.TabStop = true;
			this.RadioButtonIgnoreDropNpc.Text = "Ignore drop modify for npc from list";
			this.RadioButtonIgnoreDropNpc.UseVisualStyleBackColor = true;
			this.RadioButtonIgnoreDropNpc.CheckedChanged += new System.EventHandler(this.RadioButtonIgnoreDropNpc_CheckedChanged);
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.TextBoxRateDropRB);
			this.GroupBox1.Controls.Add(this.RadioButtonRateChanceOnly);
			this.GroupBox1.Controls.Add(this.Label7);
			this.GroupBox1.Controls.Add(this.CheckBoxSpecNpcList);
			this.GroupBox1.Controls.Add(this.RadioButtonIgnoreDropNpc);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.Label3);
			this.GroupBox1.Controls.Add(this.TextBoxRateDrop);
			this.GroupBox1.Controls.Add(this.TextBoxRateHerb);
			this.GroupBox1.Controls.Add(this.TextBoxRateAdena);
			this.GroupBox1.Controls.Add(this.Label6);
			this.GroupBox1.Controls.Add(this.TextBoxRateSpoil);
			this.GroupBox1.Controls.Add(this.TextBoxRateSealstones);
			this.GroupBox1.Controls.Add(this.Label4);
			this.GroupBox1.Controls.Add(this.Label5);
			this.GroupBox1.Location = new System.Drawing.Point(125, 64);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(200, 151);
			this.GroupBox1.TabIndex = 89;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Rate Options";
			// 
			// CheckBoxSpecNpcList
			// 
			this.CheckBoxSpecNpcList.AutoSize = true;
			this.CheckBoxSpecNpcList.Checked = true;
			this.CheckBoxSpecNpcList.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxSpecNpcList.Location = new System.Drawing.Point(9, 94);
			this.CheckBoxSpecNpcList.Name = "CheckBoxSpecNpcList";
			this.CheckBoxSpecNpcList.Size = new System.Drawing.Size(123, 17);
			this.CheckBoxSpecNpcList.TabIndex = 81;
			this.CheckBoxSpecNpcList.Text = "Use special Npc List";
			this.CheckBoxSpecNpcList.UseVisualStyleBackColor = true;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(6, 19);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(38, 13);
			this.Label1.TabIndex = 71;
			this.Label1.Text = "Adena";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(96, 16);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(40, 26);
			this.Label3.TabIndex = 73;
			this.Label3.Text = "Seal\r\nStones";
			// 
			// TextBoxRateDrop
			// 
			this.TextBoxRateDrop.Location = new System.Drawing.Point(47, 42);
			this.TextBoxRateDrop.Name = "TextBoxRateDrop";
			this.TextBoxRateDrop.Size = new System.Drawing.Size(43, 20);
			this.TextBoxRateDrop.TabIndex = 78;
			this.TextBoxRateDrop.Text = "1";
			// 
			// TextBoxRateHerb
			// 
			this.TextBoxRateHerb.Location = new System.Drawing.Point(142, 68);
			this.TextBoxRateHerb.Name = "TextBoxRateHerb";
			this.TextBoxRateHerb.Size = new System.Drawing.Size(43, 20);
			this.TextBoxRateHerb.TabIndex = 76;
			this.TextBoxRateHerb.Text = "1";
			// 
			// TextBoxRateAdena
			// 
			this.TextBoxRateAdena.Location = new System.Drawing.Point(47, 16);
			this.TextBoxRateAdena.Name = "TextBoxRateAdena";
			this.TextBoxRateAdena.Size = new System.Drawing.Size(43, 20);
			this.TextBoxRateAdena.TabIndex = 70;
			this.TextBoxRateAdena.Text = "1";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(6, 71);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(30, 13);
			this.Label6.TabIndex = 79;
			this.Label6.Text = "Spoil";
			// 
			// TextBoxRateSpoil
			// 
			this.TextBoxRateSpoil.Location = new System.Drawing.Point(47, 68);
			this.TextBoxRateSpoil.Name = "TextBoxRateSpoil";
			this.TextBoxRateSpoil.Size = new System.Drawing.Size(43, 20);
			this.TextBoxRateSpoil.TabIndex = 74;
			this.TextBoxRateSpoil.Text = "1";
			// 
			// TextBoxRateSealstones
			// 
			this.TextBoxRateSealstones.Location = new System.Drawing.Point(142, 16);
			this.TextBoxRateSealstones.Name = "TextBoxRateSealstones";
			this.TextBoxRateSealstones.Size = new System.Drawing.Size(43, 20);
			this.TextBoxRateSealstones.TabIndex = 72;
			this.TextBoxRateSealstones.Text = "1";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(6, 45);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(30, 13);
			this.Label4.TabIndex = 75;
			this.Label4.Text = "Drop";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(96, 71);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(30, 13);
			this.Label5.TabIndex = 77;
			this.Label5.Text = "Herb";
			// 
			// ButtonDropChanceUpdate
			// 
			this.ButtonDropChanceUpdate.Location = new System.Drawing.Point(32, 163);
			this.ButtonDropChanceUpdate.Name = "ButtonDropChanceUpdate";
			this.ButtonDropChanceUpdate.Size = new System.Drawing.Size(75, 23);
			this.ButtonDropChanceUpdate.TabIndex = 88;
			this.ButtonDropChanceUpdate.Text = "DropRate";
			this.ButtonDropChanceUpdate.UseVisualStyleBackColor = true;
			this.ButtonDropChanceUpdate.Click += new System.EventHandler(this.ButtonDropChanceUpdate_Click);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(159, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(127, 32);
			this.Label2.TabIndex = 86;
			this.Label2.Text = "NpcDrop Generator\r\nL2J and PTS";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(32, 192);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 83;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonStartL2JPTS
			// 
			this.ButtonStartL2JPTS.Location = new System.Drawing.Point(147, 35);
			this.ButtonStartL2JPTS.Name = "ButtonStartL2JPTS";
			this.ButtonStartL2JPTS.Size = new System.Drawing.Size(75, 23);
			this.ButtonStartL2JPTS.TabIndex = 82;
			this.ButtonStartL2JPTS.Text = "L2J->PTS";
			this.ButtonStartL2JPTS.UseVisualStyleBackColor = true;
			this.ButtonStartL2JPTS.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 229);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(334, 22);
			this.StatusStrip.TabIndex = 85;
			this.StatusStrip.Text = "StatusStrip";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(200, 16);
			this.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// ToolStripStatusLabel
			// 
			this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
			this.ToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// ButtonStartPTSL2J
			// 
			this.ButtonStartPTSL2J.Location = new System.Drawing.Point(228, 35);
			this.ButtonStartPTSL2J.Name = "ButtonStartPTSL2J";
			this.ButtonStartPTSL2J.Size = new System.Drawing.Size(75, 23);
			this.ButtonStartPTSL2J.TabIndex = 87;
			this.ButtonStartPTSL2J.Text = "PTS->L2J";
			this.ButtonStartPTSL2J.UseVisualStyleBackColor = true;
			this.ButtonStartPTSL2J.Click += new System.EventHandler(this.ButtonStartPTSL2J_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 0);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(107, 157);
			this.PictureBox1.TabIndex = 84;
			this.PictureBox1.TabStop = false;
			// 
			// L2J_NpcData_Drop
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 251);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.ButtonDropChanceUpdate);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonStartL2JPTS);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.ButtonStartPTSL2J);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "L2J_NpcData_Drop";
			this.Text = "L2J_NpcData_Drop";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.TextBox TextBoxRateDropRB;
		internal System.Windows.Forms.RadioButton RadioButtonRateChanceOnly;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.RadioButton RadioButtonIgnoreDropNpc;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.CheckBox CheckBoxSpecNpcList;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox TextBoxRateDrop;
		internal System.Windows.Forms.TextBox TextBoxRateHerb;
		internal System.Windows.Forms.TextBox TextBoxRateAdena;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox TextBoxRateSpoil;
		internal System.Windows.Forms.TextBox TextBoxRateSealstones;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Button ButtonDropChanceUpdate;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonStartL2JPTS;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.Button ButtonStartPTSL2J;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}