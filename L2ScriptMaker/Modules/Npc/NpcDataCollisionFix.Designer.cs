namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcDataCollisionFix
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcDataCollisionFix));
			this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.ExportButton = new System.Windows.Forms.Button();
			this.ImportButton = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.QuitButton = new System.Windows.Forms.Button();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.UseFirstCheckBox = new System.Windows.Forms.CheckBox();
			this.StatusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip1
			// 
			this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar});
			this.StatusStrip1.Location = new System.Drawing.Point(0, 179);
			this.StatusStrip1.Name = "StatusStrip1";
			this.StatusStrip1.Size = new System.Drawing.Size(304, 22);
			this.StatusStrip1.TabIndex = 62;
			this.StatusStrip1.Text = "StatusStrip";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(280, 16);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 158);
			this.PictureBox1.TabIndex = 61;
			this.PictureBox1.TabStop = false;
			// 
			// ExportButton
			// 
			this.ExportButton.Location = new System.Drawing.Point(172, 112);
			this.ExportButton.Name = "ExportButton";
			this.ExportButton.Size = new System.Drawing.Size(75, 23);
			this.ExportButton.TabIndex = 60;
			this.ExportButton.Text = "Export";
			this.ExportButton.UseVisualStyleBackColor = true;
			this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
			// 
			// ImportButton
			// 
			this.ImportButton.Location = new System.Drawing.Point(172, 56);
			this.ImportButton.Name = "ImportButton";
			this.ImportButton.Size = new System.Drawing.Size(75, 23);
			this.ImportButton.TabIndex = 59;
			this.ImportButton.Text = "Import";
			this.ImportButton.UseVisualStyleBackColor = true;
			this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(141, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(106, 13);
			this.Label3.TabIndex = 65;
			this.Label3.Text = "(support all cronicles)";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(124, 6);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(172, 16);
			this.Label4.TabIndex = 64;
			this.Label4.Text = "NpcData.txt Collision Fixer";
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(172, 141);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 63;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// UseFirstCheckBox
			// 
			this.UseFirstCheckBox.AutoSize = true;
			this.UseFirstCheckBox.Location = new System.Drawing.Point(157, 89);
			this.UseFirstCheckBox.Name = "UseFirstCheckBox";
			this.UseFirstCheckBox.Size = new System.Drawing.Size(120, 17);
			this.UseFirstCheckBox.TabIndex = 66;
			this.UseFirstCheckBox.Text = "Load only first value";
			this.UseFirstCheckBox.UseVisualStyleBackColor = true;
			// 
			// NpcDataCollisionFix
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(304, 201);
			this.Controls.Add(this.StatusStrip1);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.ExportButton);
			this.Controls.Add(this.ImportButton);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.UseFirstCheckBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcDataCollisionFix";
			this.Text = "NpcData Collision Fixer";
			this.StatusStrip1.ResumeLayout(false);
			this.StatusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.StatusStrip StatusStrip1;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button ExportButton;
		internal System.Windows.Forms.Button ImportButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.CheckBox UseFirstCheckBox;
	}
}