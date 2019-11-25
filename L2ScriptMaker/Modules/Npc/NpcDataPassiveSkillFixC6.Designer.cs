namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcDataPassiveSkillFixC6
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
			this.CheckBoxStopActive = new System.Windows.Forms.CheckBox();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.CheckBoxSaveActive = new System.Windows.Forms.CheckBox();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.AutosetToBossCheckBox = new System.Windows.Forms.CheckBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.CustomNameTextBox = new System.Windows.Forms.TextBox();
			this.MagicDefCheckBox = new System.Windows.Forms.CheckBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// CheckBoxStopActive
			// 
			this.CheckBoxStopActive.AutoSize = true;
			this.CheckBoxStopActive.Location = new System.Drawing.Point(278, 141);
			this.CheckBoxStopActive.Name = "CheckBoxStopActive";
			this.CheckBoxStopActive.Size = new System.Drawing.Size(131, 17);
			this.CheckBoxStopActive.TabIndex = 83;
			this.CheckBoxStopActive.Text = "Stop after save Active";
			this.CheckBoxStopActive.UseVisualStyleBackColor = true;
			this.CheckBoxStopActive.Visible = false;
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
			// 
			// CheckBoxSaveActive
			// 
			this.CheckBoxSaveActive.AutoSize = true;
			this.CheckBoxSaveActive.Location = new System.Drawing.Point(278, 126);
			this.CheckBoxSaveActive.Name = "CheckBoxSaveActive";
			this.CheckBoxSaveActive.Size = new System.Drawing.Size(108, 17);
			this.CheckBoxSaveActive.TabIndex = 82;
			this.CheckBoxSaveActive.Text = "Save active skills";
			this.CheckBoxSaveActive.UseVisualStyleBackColor = true;
			this.CheckBoxSaveActive.Visible = false;
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 219);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(424, 22);
			this.StatusStrip.TabIndex = 81;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(255, 180);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(105, 13);
			this.Label5.TabIndex = 80;
			this.Label5.Text = "skill_id=4045 level=1";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(255, 165);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(105, 13);
			this.Label4.TabIndex = 79;
			this.Label4.Text = "skill_id=4121 level=1";
			// 
			// AutosetToBossCheckBox
			// 
			this.AutosetToBossCheckBox.AutoSize = true;
			this.AutosetToBossCheckBox.Checked = true;
			this.AutosetToBossCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AutosetToBossCheckBox.Location = new System.Drawing.Point(15, 113);
			this.AutosetToBossCheckBox.Name = "AutosetToBossCheckBox";
			this.AutosetToBossCheckBox.Size = new System.Drawing.Size(257, 30);
			this.AutosetToBossCheckBox.TabIndex = 78;
			this.AutosetToBossCheckBox.Text = "Use autoset to \'boss\' type\r\n(default, apply \'@s_full_magic_defence\' to \'boss\')";
			this.AutosetToBossCheckBox.UseVisualStyleBackColor = true;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(12, 146);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(157, 13);
			this.Label1.TabIndex = 77;
			this.Label1.Text = "Custom names for autoset skills:";
			// 
			// CustomNameTextBox
			// 
			this.CustomNameTextBox.Location = new System.Drawing.Point(15, 162);
			this.CustomNameTextBox.Multiline = true;
			this.CustomNameTextBox.Name = "CustomNameTextBox";
			this.CustomNameTextBox.Size = new System.Drawing.Size(234, 37);
			this.CustomNameTextBox.TabIndex = 76;
			this.CustomNameTextBox.Text = "s_summon_magic_defence\r\ns_full_magic_defence";
			// 
			// MagicDefCheckBox
			// 
			this.MagicDefCheckBox.AutoSize = true;
			this.MagicDefCheckBox.Checked = true;
			this.MagicDefCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MagicDefCheckBox.Location = new System.Drawing.Point(15, 64);
			this.MagicDefCheckBox.Name = "MagicDefCheckBox";
			this.MagicDefCheckBox.Size = new System.Drawing.Size(345, 43);
			this.MagicDefCheckBox.TabIndex = 71;
			this.MagicDefCheckBox.Text = "Autoset skills:\r\n- @s_summon_magic_defence on \'pet\' and \'summon\'\r\n- @s_full_magic" +
    "_defence on all types except \'warrior\' and \'zzoldagu\'";
			this.MagicDefCheckBox.UseVisualStyleBackColor = true;
			this.MagicDefCheckBox.CheckedChanged += new System.EventHandler(this.MagicDefCheckBox_CheckedChanged);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(12, 38);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(196, 13);
			this.Label3.TabIndex = 75;
			this.Label3.Text = "(support all scripts and L2Disasm format)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(9, 6);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(145, 32);
			this.Label2.TabIndex = 74;
			this.Label2.Text = "NpcData Passive Skill \r\n(\'skill_list\') fix";
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(285, 3);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 73;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(204, 3);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 72;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// NpcDataPassiveSkillFixC6
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 241);
			this.Controls.Add(this.CheckBoxStopActive);
			this.Controls.Add(this.CheckBoxSaveActive);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.AutosetToBossCheckBox);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.CustomNameTextBox);
			this.Controls.Add(this.MagicDefCheckBox);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcDataPassiveSkillFixC6";
			this.Text = "NpcData Passive Skill fixer ";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.CheckBox CheckBoxStopActive;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.CheckBox CheckBoxSaveActive;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.CheckBox AutosetToBossCheckBox;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox CustomNameTextBox;
		internal System.Windows.Forms.CheckBox MagicDefCheckBox;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
	}
}