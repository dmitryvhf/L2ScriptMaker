namespace L2ScriptMaker.Modules.ZeroScripts
{
	partial class ItemDataGenerator
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDataGenerator));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.GenerateEnch6CheckBox = new System.Windows.Forms.CheckBox();
			this.EnchCropCheckBox = new System.Windows.Forms.CheckBox();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.ToolStripStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 189);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(379, 22);
			this.StatusStrip.TabIndex = 60;
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
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(143, 77);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 59;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(143, 48);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 58;
			this.StartButton.Text = "Generate...";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(107, 157);
			this.PictureBox1.TabIndex = 57;
			this.PictureBox1.TabStop = false;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(232, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(141, 13);
			this.Label3.TabIndex = 62;
			this.Label3.Text = "(support L2Disasm client file)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(125, 6);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(248, 16);
			this.Label2.TabIndex = 61;
			this.Label2.Text = "ItemData Generator from client .Dat file";
			// 
			// GenerateEnch6CheckBox
			// 
			this.GenerateEnch6CheckBox.AutoSize = true;
			this.GenerateEnch6CheckBox.Location = new System.Drawing.Point(143, 136);
			this.GenerateEnch6CheckBox.Name = "GenerateEnch6CheckBox";
			this.GenerateEnch6CheckBox.Size = new System.Drawing.Size(220, 30);
			this.GenerateEnch6CheckBox.TabIndex = 64;
			this.GenerateEnch6CheckBox.Text = "Generate param for enchant+6 set\r\n(Note! Only for modded server or for info.)";
			this.GenerateEnch6CheckBox.UseVisualStyleBackColor = true;
			// 
			// EnchCropCheckBox
			// 
			this.EnchCropCheckBox.AutoSize = true;
			this.EnchCropCheckBox.Checked = true;
			this.EnchCropCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.EnchCropCheckBox.Location = new System.Drawing.Point(143, 106);
			this.EnchCropCheckBox.Name = "EnchCropCheckBox";
			this.EnchCropCheckBox.Size = new System.Drawing.Size(177, 30);
			this.EnchCropCheckBox.TabIndex = 63;
			this.EnchCropCheckBox.Text = "Use internal engine for generate\r\nenchant scrolls and crop items?";
			this.EnchCropCheckBox.UseVisualStyleBackColor = true;
			// 
			// ItemDataGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 211);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.GenerateEnch6CheckBox);
			this.Controls.Add(this.EnchCropCheckBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ItemDataGenerator";
			this.Text = "ItemData Generator from client .Dat file";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.CheckBox GenerateEnch6CheckBox;
		internal System.Windows.Forms.CheckBox EnchCropCheckBox;
	}
}