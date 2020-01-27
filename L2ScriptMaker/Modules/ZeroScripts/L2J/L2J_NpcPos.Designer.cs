namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	partial class L2J_NpcPos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(L2J_NpcPos));
			this.Label2 = new System.Windows.Forms.Label();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.CheckBoxSaveEventNpc = new System.Windows.Forms.CheckBox();
			this.CheckBoxShowNpcName = new System.Windows.Forms.CheckBox();
			this.CheckBoxShowAll = new System.Windows.Forms.CheckBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.TextBoxL2JMaxLines = new System.Windows.Forms.TextBox();
			this.ButtonPTStoL2J = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(125, 2);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(201, 16);
			this.Label2.TabIndex = 73;
			this.Label2.Text = "NpcPos Generator from L2J file";
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 164);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(369, 22);
			this.StatusStrip.TabIndex = 72;
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
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(128, 136);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 70;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(128, 30);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 69;
			this.ButtonStart.Text = "L2J->PTS";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// CheckBoxSaveEventNpc
			// 
			this.CheckBoxSaveEventNpc.AutoSize = true;
			this.CheckBoxSaveEventNpc.Location = new System.Drawing.Point(229, 88);
			this.CheckBoxSaveEventNpc.Name = "CheckBoxSaveEventNpc";
			this.CheckBoxSaveEventNpc.Size = new System.Drawing.Size(107, 17);
			this.CheckBoxSaveEventNpc.TabIndex = 79;
			this.CheckBoxSaveEventNpc.Text = "Save events npc";
			this.CheckBoxSaveEventNpc.UseVisualStyleBackColor = true;
			// 
			// CheckBoxShowNpcName
			// 
			this.CheckBoxShowNpcName.AutoSize = true;
			this.CheckBoxShowNpcName.Location = new System.Drawing.Point(128, 112);
			this.CheckBoxShowNpcName.Name = "CheckBoxShowNpcName";
			this.CheckBoxShowNpcName.Size = new System.Drawing.Size(103, 17);
			this.CheckBoxShowNpcName.TabIndex = 78;
			this.CheckBoxShowNpcName.Text = "Show npc name";
			this.CheckBoxShowNpcName.UseVisualStyleBackColor = true;
			// 
			// CheckBoxShowAll
			// 
			this.CheckBoxShowAll.AutoSize = true;
			this.CheckBoxShowAll.Location = new System.Drawing.Point(128, 88);
			this.CheckBoxShowAll.Name = "CheckBoxShowAll";
			this.CheckBoxShowAll.Size = new System.Drawing.Size(95, 17);
			this.CheckBoxShowAll.TabIndex = 77;
			this.CheckBoxShowAll.Text = "Show all errors";
			this.CheckBoxShowAll.UseVisualStyleBackColor = true;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(209, 64);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(51, 13);
			this.Label1.TabIndex = 76;
			this.Label1.Text = "Max lines";
			// 
			// TextBoxL2JMaxLines
			// 
			this.TextBoxL2JMaxLines.Location = new System.Drawing.Point(266, 61);
			this.TextBoxL2JMaxLines.Name = "TextBoxL2JMaxLines";
			this.TextBoxL2JMaxLines.Size = new System.Drawing.Size(35, 20);
			this.TextBoxL2JMaxLines.TabIndex = 75;
			this.TextBoxL2JMaxLines.Text = "100";
			// 
			// ButtonPTStoL2J
			// 
			this.ButtonPTStoL2J.Location = new System.Drawing.Point(128, 59);
			this.ButtonPTStoL2J.Name = "ButtonPTStoL2J";
			this.ButtonPTStoL2J.Size = new System.Drawing.Size(75, 23);
			this.ButtonPTStoL2J.TabIndex = 74;
			this.ButtonPTStoL2J.Text = "PTS->L2J";
			this.ButtonPTStoL2J.UseVisualStyleBackColor = true;
			this.ButtonPTStoL2J.Click += new System.EventHandler(this.ButtonPTStoL2J_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 2);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(107, 157);
			this.PictureBox1.TabIndex = 71;
			this.PictureBox1.TabStop = false;
			// 
			// L2J_NpcPos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 186);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.CheckBoxSaveEventNpc);
			this.Controls.Add(this.CheckBoxShowNpcName);
			this.Controls.Add(this.CheckBoxShowAll);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.TextBoxL2JMaxLines);
			this.Controls.Add(this.ButtonPTStoL2J);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "L2J_NpcPos";
			this.Text = "L2J_NpcPos";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.CheckBox CheckBoxSaveEventNpc;
		internal System.Windows.Forms.CheckBox CheckBoxShowNpcName;
		internal System.Windows.Forms.CheckBox CheckBoxShowAll;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox TextBoxL2JMaxLines;
		internal System.Windows.Forms.Button ButtonPTStoL2J;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}