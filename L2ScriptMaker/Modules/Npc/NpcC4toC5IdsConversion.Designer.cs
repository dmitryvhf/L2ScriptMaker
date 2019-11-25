namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcC4toC5IdsConversion
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcC4toC5IdsConversion));
			this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.C6TextBox = new System.Windows.Forms.TextBox();
			this.C4TextBox = new System.Windows.Forms.TextBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.DisableCheckBox = new System.Windows.Forms.CheckBox();
			this.ReloadButton = new System.Windows.Forms.Button();
			this.InverseDirectionCheckBox = new System.Windows.Forms.CheckBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.StatusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusStrip1
			// 
			this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar1});
			this.StatusStrip1.Location = new System.Drawing.Point(0, 179);
			this.StatusStrip1.Name = "StatusStrip1";
			this.StatusStrip1.Size = new System.Drawing.Size(369, 22);
			this.StatusStrip1.TabIndex = 61;
			this.StatusStrip1.Text = "StatusStrip";
			// 
			// ToolStripProgressBar1
			// 
			this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
			this.ToolStripProgressBar1.Size = new System.Drawing.Size(340, 16);
			// 
			// C6TextBox
			// 
			this.C6TextBox.Location = new System.Drawing.Point(168, 77);
			this.C6TextBox.Name = "C6TextBox";
			this.C6TextBox.Size = new System.Drawing.Size(100, 20);
			this.C6TextBox.TabIndex = 60;
			this.C6TextBox.TextChanged += new System.EventHandler(this.C6TextBox_Validated);
			// 
			// C4TextBox
			// 
			this.C4TextBox.Location = new System.Drawing.Point(168, 51);
			this.C4TextBox.Name = "C4TextBox";
			this.C4TextBox.Size = new System.Drawing.Size(100, 20);
			this.C4TextBox.TabIndex = 59;
			this.C4TextBox.TextChanged += new System.EventHandler(this.C4TextBox_Validated);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(107, 159);
			this.PictureBox1.TabIndex = 58;
			this.PictureBox1.TabStop = false;
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(278, 135);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 57;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(278, 106);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 56;
			this.StartButton.Text = "Fix NpcData";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(125, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 63;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(125, 6);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(242, 16);
			this.Label4.TabIndex = 62;
			this.Label4.Text = "Npcdata C4 to C5 IDs Conversion Tool";
			// 
			// DisableCheckBox
			// 
			this.DisableCheckBox.AutoSize = true;
			this.DisableCheckBox.Checked = true;
			this.DisableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DisableCheckBox.Location = new System.Drawing.Point(146, 135);
			this.DisableCheckBox.Name = "DisableCheckBox";
			this.DisableCheckBox.Size = new System.Drawing.Size(122, 17);
			this.DisableCheckBox.TabIndex = 68;
			this.DisableCheckBox.Text = "Disable Unknown Id";
			this.DisableCheckBox.UseVisualStyleBackColor = true;
			// 
			// ReloadButton
			// 
			this.ReloadButton.Location = new System.Drawing.Point(278, 49);
			this.ReloadButton.Name = "ReloadButton";
			this.ReloadButton.Size = new System.Drawing.Size(75, 23);
			this.ReloadButton.TabIndex = 67;
			this.ReloadButton.Text = "Reload IDs";
			this.ReloadButton.UseVisualStyleBackColor = true;
			this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
			// 
			// InverseDirectionCheckBox
			// 
			this.InverseDirectionCheckBox.AutoSize = true;
			this.InverseDirectionCheckBox.Location = new System.Drawing.Point(146, 112);
			this.InverseDirectionCheckBox.Name = "InverseDirectionCheckBox";
			this.InverseDirectionCheckBox.Size = new System.Drawing.Size(104, 17);
			this.InverseDirectionCheckBox.TabIndex = 66;
			this.InverseDirectionCheckBox.Text = "Inverse direction";
			this.InverseDirectionCheckBox.UseVisualStyleBackColor = true;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(125, 80);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(37, 13);
			this.Label2.TabIndex = 65;
			this.Label2.Text = "C6 ID:";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(125, 54);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(37, 13);
			this.Label1.TabIndex = 64;
			this.Label1.Text = "C4 ID:";
			// 
			// NpcC4toC5IdsConversion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 201);
			this.Controls.Add(this.StatusStrip1);
			this.Controls.Add(this.C6TextBox);
			this.Controls.Add(this.C4TextBox);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.DisableCheckBox);
			this.Controls.Add(this.ReloadButton);
			this.Controls.Add(this.InverseDirectionCheckBox);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcC4toC5IdsConversion";
			this.Text = "Npcdata C4 to C5 Ids Conversion Tool";
			this.Load += new System.EventHandler(this.NpcC4toC5IdsConversion_Load);
			this.StatusStrip1.ResumeLayout(false);
			this.StatusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.StatusStrip StatusStrip1;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar1;
		internal System.Windows.Forms.TextBox C6TextBox;
		internal System.Windows.Forms.TextBox C4TextBox;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.CheckBox DisableCheckBox;
		internal System.Windows.Forms.Button ReloadButton;
		internal System.Windows.Forms.CheckBox InverseDirectionCheckBox;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
	}
}