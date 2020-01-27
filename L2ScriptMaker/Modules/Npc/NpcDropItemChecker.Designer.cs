namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcDropItemChecker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcDropItemChecker));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.CheckBoxIgnoreSpoil = new System.Windows.Forms.CheckBox();
			this.ClearBadParamCheckBox = new System.Windows.Forms.CheckBox();
			this.StopOnErrorCheckBox = new System.Windows.Forms.CheckBox();
			this.AdenaSkipCheckBox = new System.Windows.Forms.CheckBox();
			this.ItemChanceRateTextBox = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar});
			this.StatusStrip.Location = new System.Drawing.Point(0, 209);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(354, 22);
			this.StatusStrip.TabIndex = 62;
			this.StatusStrip.Text = "StatusStrip";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(300, 16);
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(243, 172);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(86, 23);
			this.QuitButton.TabIndex = 61;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(130, 172);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(86, 23);
			this.StartButton.TabIndex = 60;
			this.StartButton.Text = "<=100% check";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(109, 160);
			this.PictureBox1.TabIndex = 59;
			this.PictureBox1.TabStop = false;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(240, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(94, 13);
			this.Label3.TabIndex = 64;
			this.Label3.Text = "(support all scripts)";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(127, 6);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(179, 16);
			this.Label4.TabIndex = 63;
			this.Label4.Text = "Npcdata Drop Checker Tool";
			// 
			// CheckBoxIgnoreSpoil
			// 
			this.CheckBoxIgnoreSpoil.AutoSize = true;
			this.CheckBoxIgnoreSpoil.Location = new System.Drawing.Point(267, 77);
			this.CheckBoxIgnoreSpoil.Name = "CheckBoxIgnoreSpoil";
			this.CheckBoxIgnoreSpoil.Size = new System.Drawing.Size(82, 17);
			this.CheckBoxIgnoreSpoil.TabIndex = 70;
			this.CheckBoxIgnoreSpoil.Text = "Ignore Spoil";
			this.CheckBoxIgnoreSpoil.UseVisualStyleBackColor = true;
			// 
			// ClearBadParamCheckBox
			// 
			this.ClearBadParamCheckBox.AutoSize = true;
			this.ClearBadParamCheckBox.Location = new System.Drawing.Point(130, 100);
			this.ClearBadParamCheckBox.Name = "ClearBadParamCheckBox";
			this.ClearBadParamCheckBox.Size = new System.Drawing.Size(160, 30);
			this.ClearBadParamCheckBox.TabIndex = 69;
			this.ClearBadParamCheckBox.Text = "Clear bad param (spoil, drop)\r\nWrite to file and Continue";
			this.ClearBadParamCheckBox.UseVisualStyleBackColor = true;
			this.ClearBadParamCheckBox.CheckedChanged += new System.EventHandler(this.ClearBadParamCheckBox_CheckedChanged);
			// 
			// StopOnErrorCheckBox
			// 
			this.StopOnErrorCheckBox.AutoSize = true;
			this.StopOnErrorCheckBox.Location = new System.Drawing.Point(130, 136);
			this.StopOnErrorCheckBox.Name = "StopOnErrorCheckBox";
			this.StopOnErrorCheckBox.Size = new System.Drawing.Size(183, 30);
			this.StopOnErrorCheckBox.TabIndex = 68;
			this.StopOnErrorCheckBox.Text = "stop on Parsing Error\r\n(or write error to file and continue)";
			this.StopOnErrorCheckBox.UseVisualStyleBackColor = true;
			this.StopOnErrorCheckBox.CheckedChanged += new System.EventHandler(this.StopOnErrorCheckBox_CheckedChanged);
			// 
			// AdenaSkipCheckBox
			// 
			this.AdenaSkipCheckBox.AutoSize = true;
			this.AdenaSkipCheckBox.Checked = true;
			this.AdenaSkipCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AdenaSkipCheckBox.Location = new System.Drawing.Point(130, 77);
			this.AdenaSkipCheckBox.Name = "AdenaSkipCheckBox";
			this.AdenaSkipCheckBox.Size = new System.Drawing.Size(131, 17);
			this.AdenaSkipCheckBox.TabIndex = 67;
			this.AdenaSkipCheckBox.Text = "Ignore [adena] for rate";
			this.AdenaSkipCheckBox.UseVisualStyleBackColor = true;
			// 
			// ItemChanceRateTextBox
			// 
			this.ItemChanceRateTextBox.Location = new System.Drawing.Point(130, 51);
			this.ItemChanceRateTextBox.Name = "ItemChanceRateTextBox";
			this.ItemChanceRateTextBox.Size = new System.Drawing.Size(100, 20);
			this.ItemChanceRateTextBox.TabIndex = 66;
			this.ItemChanceRateTextBox.Text = "1";
			this.ItemChanceRateTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ItemChanceRateTextBox_Validating);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(127, 35);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(96, 13);
			this.Label1.TabIndex = 65;
			this.Label1.Text = "Item Chance Rate:";
			// 
			// NpcDropItemChecker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 231);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.CheckBoxIgnoreSpoil);
			this.Controls.Add(this.ClearBadParamCheckBox);
			this.Controls.Add(this.StopOnErrorCheckBox);
			this.Controls.Add(this.AdenaSkipCheckBox);
			this.Controls.Add(this.ItemChanceRateTextBox);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcDropItemChecker";
			this.Text = "NpcDropItemChecker";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.CheckBox CheckBoxIgnoreSpoil;
		internal System.Windows.Forms.CheckBox ClearBadParamCheckBox;
		internal System.Windows.Forms.CheckBox StopOnErrorCheckBox;
		internal System.Windows.Forms.CheckBox AdenaSkipCheckBox;
		internal System.Windows.Forms.TextBox ItemChanceRateTextBox;
		internal System.Windows.Forms.Label Label1;
	}
}