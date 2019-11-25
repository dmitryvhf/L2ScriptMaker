namespace L2ScriptMaker.Modules.AI
{
	partial class AiFixer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AiFixer));
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.IncreaseQuestListButton = new System.Windows.Forms.Button();
			this.IncQuestTextBox = new System.Windows.Forms.TextBox();
			this.LogOverwriteCheckBox = new System.Windows.Forms.CheckBox();
			this.ComboBoxFixType = new System.Windows.Forms.ComboBox();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.CheckBoxIgnoreAlredy = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(116, 155);
			this.PictureBox1.TabIndex = 13;
			this.PictureBox1.TabStop = false;
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(134, 151);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 12;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar});
			this.StatusStrip.Location = new System.Drawing.Point(0, 179);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(284, 22);
			this.StatusStrip.TabIndex = 19;
			this.StatusStrip.Text = "StatusStrip1";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(250, 16);
			// 
			// IncreaseQuestListButton
			// 
			this.IncreaseQuestListButton.Location = new System.Drawing.Point(134, 105);
			this.IncreaseQuestListButton.Name = "IncreaseQuestListButton";
			this.IncreaseQuestListButton.Size = new System.Drawing.Size(111, 23);
			this.IncreaseQuestListButton.TabIndex = 18;
			this.IncreaseQuestListButton.Text = "Increase Quest List";
			this.IncreaseQuestListButton.UseVisualStyleBackColor = true;
			this.IncreaseQuestListButton.Click += new System.EventHandler(this.IncreaseQuestListButton_Click);
			// 
			// IncQuestTextBox
			// 
			this.IncQuestTextBox.Location = new System.Drawing.Point(134, 79);
			this.IncQuestTextBox.Name = "IncQuestTextBox";
			this.IncQuestTextBox.Size = new System.Drawing.Size(100, 20);
			this.IncQuestTextBox.TabIndex = 17;
			this.IncQuestTextBox.Text = "9";
			// 
			// LogOverwriteCheckBox
			// 
			this.LogOverwriteCheckBox.AutoSize = true;
			this.LogOverwriteCheckBox.Location = new System.Drawing.Point(215, 39);
			this.LogOverwriteCheckBox.Name = "LogOverwriteCheckBox";
			this.LogOverwriteCheckBox.Size = new System.Drawing.Size(63, 30);
			this.LogOverwriteCheckBox.TabIndex = 16;
			this.LogOverwriteCheckBox.Text = "Append\r\nLog";
			this.LogOverwriteCheckBox.UseVisualStyleBackColor = true;
			// 
			// ComboBoxFixType
			// 
			this.ComboBoxFixType.FormattingEnabled = true;
			this.ComboBoxFixType.Items.AddRange(new object[] {
            "func_call",
            "push_event",
            "fetch_i",
            "handler"});
			this.ComboBoxFixType.Location = new System.Drawing.Point(134, 12);
			this.ComboBoxFixType.Name = "ComboBoxFixType";
			this.ComboBoxFixType.Size = new System.Drawing.Size(144, 21);
			this.ComboBoxFixType.TabIndex = 15;
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(134, 39);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 14;
			this.ButtonStart.Text = "Fix";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonFetch_Click);
			// 
			// CheckBoxIgnoreAlredy
			// 
			this.CheckBoxIgnoreAlredy.AutoSize = true;
			this.CheckBoxIgnoreAlredy.Checked = true;
			this.CheckBoxIgnoreAlredy.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxIgnoreAlredy.Location = new System.Drawing.Point(134, 134);
			this.CheckBoxIgnoreAlredy.Name = "CheckBoxIgnoreAlredy";
			this.CheckBoxIgnoreAlredy.Size = new System.Drawing.Size(123, 17);
			this.CheckBoxIgnoreAlredy.TabIndex = 20;
			this.CheckBoxIgnoreAlredy.Text = "Ignore If already >30";
			this.CheckBoxIgnoreAlredy.UseVisualStyleBackColor = true;
			// 
			// AiFixer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 201);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.IncreaseQuestListButton);
			this.Controls.Add(this.IncQuestTextBox);
			this.Controls.Add(this.LogOverwriteCheckBox);
			this.Controls.Add(this.ComboBoxFixType);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.CheckBoxIgnoreAlredy);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AiFixer";
			this.Text = "AiFixer";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.StatusStrip StatusStrip;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.Button IncreaseQuestListButton;
		internal System.Windows.Forms.TextBox IncQuestTextBox;
		internal System.Windows.Forms.CheckBox LogOverwriteCheckBox;
		internal System.Windows.Forms.ComboBox ComboBoxFixType;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.CheckBox CheckBoxIgnoreAlredy;
	}
}