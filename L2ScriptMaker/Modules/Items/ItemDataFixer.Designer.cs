namespace L2ScriptMaker.Modules.Items
{
	partial class ItemDataFixer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDataFixer));
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.StartButton = new System.Windows.Forms.Button();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.CheckFilesBox = new System.Windows.Forms.TextBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(295, 10);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(102, 16);
			this.Label2.TabIndex = 58;
			this.Label2.Text = "Item_type Fixer";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(296, 26);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(97, 13);
			this.Label1.TabIndex = 59;
			this.Label1.Text = "(support C4 scripts)";
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(188, 18);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(91, 23);
			this.StartButton.TabIndex = 49;
			this.StartButton.Text = "Check and Fix";
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(188, 47);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(91, 23);
			this.ButtonQuit.TabIndex = 50;
			this.ButtonQuit.Text = "Exit";
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(6, 111);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(273, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 1;
			// 
			// CheckedListBox
			// 
			this.CheckedListBox.FormattingEnabled = true;
			this.CheckedListBox.Items.AddRange(new object[] {
            "duplicate names",
            "item_type=",
            "add q_ for questitems",
            "remove q_ from non-questitems",
            "action_capsule items",
            "dual_fhit_rate",
            "polearm multitarget"});
			this.CheckedListBox.Location = new System.Drawing.Point(6, 6);
			this.CheckedListBox.Name = "CheckedListBox";
			this.CheckedListBox.Size = new System.Drawing.Size(176, 94);
			this.CheckedListBox.TabIndex = 55;
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(114, 45);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(292, 166);
			this.TabControl1.TabIndex = 61;
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.CheckedListBox);
			this.TabPage1.Controls.Add(this.StartButton);
			this.TabPage1.Controls.Add(this.ButtonQuit);
			this.TabPage1.Controls.Add(this.ProgressBar);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(284, 140);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Check options";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.CheckFilesBox);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(284, 140);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Config list";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// CheckFilesBox
			// 
			this.CheckFilesBox.Location = new System.Drawing.Point(6, 6);
			this.CheckFilesBox.Multiline = true;
			this.CheckFilesBox.Name = "CheckFilesBox";
			this.CheckFilesBox.Size = new System.Drawing.Size(275, 128);
			this.CheckFilesBox.TabIndex = 0;
			this.CheckFilesBox.Text = "dyedata.txt\r\nfishingdata.txt\r\nmanordata.txt\r\nmultisell.txt\r\nrecipe.txt\r\nsetting.t" +
    "xt\r\nskillacquire.txt\r\nskillenchantdata.txt\r\nvehicledata.txt";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(8, 13);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(100, 198);
			this.PictureBox1.TabIndex = 60;
			this.PictureBox1.TabStop = false;
			// 
			// ItemDataFixer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(414, 221);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ItemDataFixer";
			this.Text = "ItemDataFixer";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button StartButton;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.CheckedListBox CheckedListBox;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.TextBox CheckFilesBox;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}