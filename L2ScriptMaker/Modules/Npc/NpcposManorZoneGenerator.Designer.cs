namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcposManorZoneGenerator
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcposManorZoneGenerator));
			this.Label1 = new System.Windows.Forms.Label();
			this.DoUnknownCheckBox = new System.Windows.Forms.CheckBox();
			this.MetodCheckBox = new System.Windows.Forms.CheckBox();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.LoadCastleControlButton = new System.Windows.Forms.Button();
			this.CastleName = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.LocY = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LocX = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SafeRangeTextBox = new System.Windows.Forms.TextBox();
			this.DataGridView = new System.Windows.Forms.DataGridView();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.QuitButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(139, 271);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(124, 13);
			this.Label1.TabIndex = 73;
			this.Label1.Text = "\"Safe\" range for territory:";
			// 
			// DoUnknownCheckBox
			// 
			this.DoUnknownCheckBox.AutoSize = true;
			this.DoUnknownCheckBox.Location = new System.Drawing.Point(142, 245);
			this.DoUnknownCheckBox.Name = "DoUnknownCheckBox";
			this.DoUnknownCheckBox.Size = new System.Drawing.Size(295, 17);
			this.DoUnknownCheckBox.TabIndex = 71;
			this.DoUnknownCheckBox.Text = "Generate location without castle control like domain_id=0";
			this.DoUnknownCheckBox.UseVisualStyleBackColor = true;
			// 
			// MetodCheckBox
			// 
			this.MetodCheckBox.AutoSize = true;
			this.MetodCheckBox.Location = new System.Drawing.Point(142, 222);
			this.MetodCheckBox.Name = "MetodCheckBox";
			this.MetodCheckBox.Size = new System.Drawing.Size(221, 17);
			this.MetodCheckBox.TabIndex = 70;
			this.MetodCheckBox.Text = "Use real spawn locations from Npcpos.txt";
			this.MetodCheckBox.UseVisualStyleBackColor = true;
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(400, 16);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar});
			this.StatusStrip.Location = new System.Drawing.Point(0, 299);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(444, 22);
			this.StatusStrip.TabIndex = 69;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// LoadCastleControlButton
			// 
			this.LoadCastleControlButton.Location = new System.Drawing.Point(29, 179);
			this.LoadCastleControlButton.Name = "LoadCastleControlButton";
			this.LoadCastleControlButton.Size = new System.Drawing.Size(75, 37);
			this.LoadCastleControlButton.TabIndex = 68;
			this.LoadCastleControlButton.Text = "Load Castle Control";
			this.LoadCastleControlButton.UseVisualStyleBackColor = true;
			// 
			// CastleName
			// 
			this.CastleName.HeaderText = "Castle Control";
			this.CastleName.Items.AddRange(new object[] {
            "Gludio",
            "Dion",
            "Giran",
            "Oren",
            "Aden",
            "Heine",
            "Goddard",
            "Rune",
            "Schuttgart",
            "Kamael"});
			this.CastleName.Name = "CastleName";
			this.CastleName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// LocY
			// 
			this.LocY.HeaderText = "LocY";
			this.LocY.Name = "LocY";
			this.LocY.Width = 50;
			// 
			// LocX
			// 
			this.LocX.HeaderText = "LocX";
			this.LocX.Name = "LocX";
			this.LocX.Width = 50;
			// 
			// SafeRangeTextBox
			// 
			this.SafeRangeTextBox.Location = new System.Drawing.Point(263, 268);
			this.SafeRangeTextBox.Name = "SafeRangeTextBox";
			this.SafeRangeTextBox.Size = new System.Drawing.Size(100, 20);
			this.SafeRangeTextBox.TabIndex = 72;
			this.SafeRangeTextBox.Text = "2000";
			// 
			// DataGridView
			// 
			this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocX,
            this.LocY,
            this.CastleName});
			this.DataGridView.Location = new System.Drawing.Point(130, 59);
			this.DataGridView.Name = "DataGridView";
			this.DataGridView.Size = new System.Drawing.Size(307, 157);
			this.DataGridView.TabIndex = 67;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(139, 38);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(151, 13);
			this.Label3.TabIndex = 66;
			this.Label3.Text = "(support C4 scripts and above)";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(127, 6);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(153, 32);
			this.Label2.TabIndex = 65;
			this.Label2.Text = "Manor zones Generator\r\nfor Npcpos.txt";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 6);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(109, 160);
			this.PictureBox1.TabIndex = 64;
			this.PictureBox1.TabStop = false;
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(29, 251);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 63;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(29, 222);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 62;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			// 
			// NpcposManorZoneGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 321);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.DoUnknownCheckBox);
			this.Controls.Add(this.MetodCheckBox);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.LoadCastleControlButton);
			this.Controls.Add(this.SafeRangeTextBox);
			this.Controls.Add(this.DataGridView);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcposManorZoneGenerator";
			this.Text = "Npcpos Manor zones Generator";
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.CheckBox DoUnknownCheckBox;
		internal System.Windows.Forms.CheckBox MetodCheckBox;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.Button LoadCastleControlButton;
		internal System.Windows.Forms.DataGridViewComboBoxColumn CastleName;
		internal System.Windows.Forms.DataGridViewTextBoxColumn LocY;
		internal System.Windows.Forms.DataGridViewTextBoxColumn LocX;
		internal System.Windows.Forms.TextBox SafeRangeTextBox;
		internal System.Windows.Forms.DataGridView DataGridView;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
	}
}