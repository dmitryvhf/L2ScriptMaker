namespace L2ScriptMaker.Modules.ZeroScripts
{
	partial class RecipeGenerator
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeGenerator));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.CheckBoxDevnextSupport = new System.Windows.Forms.CheckBox();
			this.IgnoreUnknownCheckBox = new System.Windows.Forms.CheckBox();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar});
			this.StatusStrip.Location = new System.Drawing.Point(0, 184);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(334, 22);
			this.StatusStrip.TabIndex = 66;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(300, 16);
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(189, 143);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 65;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(189, 53);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 64;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 8);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(106, 158);
			this.PictureBox1.TabIndex = 63;
			this.PictureBox1.TabStop = false;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label5.Location = new System.Drawing.Point(152, 37);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(172, 13);
			this.Label5.TabIndex = 68;
			this.Label5.Text = "(support C6 and L2Ddisam formats)";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label6.Location = new System.Drawing.Point(124, 5);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(200, 32);
			this.Label6.TabIndex = 67;
			this.Label6.Text = "new clean Recipe.txt Generator\r\nfrom client Recipe-e.txt file";
			// 
			// CheckBoxDevnextSupport
			// 
			this.CheckBoxDevnextSupport.AutoSize = true;
			this.CheckBoxDevnextSupport.Location = new System.Drawing.Point(167, 118);
			this.CheckBoxDevnextSupport.Name = "CheckBoxDevnextSupport";
			this.CheckBoxDevnextSupport.Size = new System.Drawing.Size(144, 17);
			this.CheckBoxDevnextSupport.TabIndex = 70;
			this.CheckBoxDevnextSupport.Text = "create in DevNext format";
			this.CheckBoxDevnextSupport.UseVisualStyleBackColor = true;
			// 
			// IgnoreUnknownCheckBox
			// 
			this.IgnoreUnknownCheckBox.AutoSize = true;
			this.IgnoreUnknownCheckBox.Location = new System.Drawing.Point(167, 82);
			this.IgnoreUnknownCheckBox.Name = "IgnoreUnknownCheckBox";
			this.IgnoreUnknownCheckBox.Size = new System.Drawing.Size(118, 30);
			this.IgnoreUnknownCheckBox.TabIndex = 69;
			this.IgnoreUnknownCheckBox.Text = "Set empty \'material\'\r\nfor unknown item id";
			this.IgnoreUnknownCheckBox.UseVisualStyleBackColor = true;
			// 
			// RecipeGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 206);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.CheckBoxDevnextSupport);
			this.Controls.Add(this.IgnoreUnknownCheckBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "RecipeGenerator";
			this.Text = "Recipe.txt Generator";
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
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.CheckBox CheckBoxDevnextSupport;
		internal System.Windows.Forms.CheckBox IgnoreUnknownCheckBox;
	}
}