namespace L2ScriptMaker.Modules.AI
{
	partial class AiInjector
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AiInjector));
			this.ButtonFindExact = new System.Windows.Forms.Button();
			this.Label7 = new System.Windows.Forms.Label();
			this.TextBoxFindSelect = new System.Windows.Forms.TextBox();
			this.ButtonFindSelect = new System.Windows.Forms.Button();
			this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.ButtonLoadClassList = new System.Windows.Forms.Button();
			this.CheckBoxUseList = new System.Windows.Forms.CheckBox();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Inject = new System.Windows.Forms.Button();
			this.SplitClassTextBox = new System.Windows.Forms.TextBox();
			this.MergeCheckBox1 = new System.Windows.Forms.CheckBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.MergeCheckBox2 = new System.Windows.Forms.CheckBox();
			this.AiFile = new System.Windows.Forms.TextBox();
			this.FixFile = new System.Windows.Forms.TextBox();
			this.SplitButton = new System.Windows.Forms.Button();
			this.FixOneClassBox = new System.Windows.Forms.CheckBox();
			this.MergeButton = new System.Windows.Forms.Button();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.Label2 = new System.Windows.Forms.Label();
			this.StatusBox = new System.Windows.Forms.TextBox();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.Quit = new System.Windows.Forms.Button();
			this.TabPage2.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// ButtonFindExact
			// 
			this.ButtonFindExact.Location = new System.Drawing.Point(334, 128);
			this.ButtonFindExact.Name = "ButtonFindExact";
			this.ButtonFindExact.Size = new System.Drawing.Size(96, 23);
			this.ButtonFindExact.TabIndex = 5;
			this.ButtonFindExact.Text = "Find Exact";
			this.ButtonFindExact.UseVisualStyleBackColor = true;
			this.ButtonFindExact.Click += new System.EventHandler(this.ButtonFindExact_Click);
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(6, 162);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(82, 13);
			this.Label7.TabIndex = 4;
			this.Label7.Text = "Find and select:";
			// 
			// TextBoxFindSelect
			// 
			this.TextBoxFindSelect.Location = new System.Drawing.Point(95, 159);
			this.TextBoxFindSelect.Name = "TextBoxFindSelect";
			this.TextBoxFindSelect.Size = new System.Drawing.Size(232, 20);
			this.TextBoxFindSelect.TabIndex = 3;
			// 
			// ButtonFindSelect
			// 
			this.ButtonFindSelect.Location = new System.Drawing.Point(333, 157);
			this.ButtonFindSelect.Name = "ButtonFindSelect";
			this.ButtonFindSelect.Size = new System.Drawing.Size(97, 23);
			this.ButtonFindSelect.TabIndex = 2;
			this.ButtonFindSelect.Text = "Find and Select";
			this.ButtonFindSelect.UseVisualStyleBackColor = true;
			this.ButtonFindSelect.Click += new System.EventHandler(this.ButtonFindSelect_Click);
			// 
			// CheckedListBox
			// 
			this.CheckedListBox.FormattingEnabled = true;
			this.CheckedListBox.Location = new System.Drawing.Point(6, 6);
			this.CheckedListBox.Name = "CheckedListBox";
			this.CheckedListBox.Size = new System.Drawing.Size(321, 139);
			this.CheckedListBox.TabIndex = 0;
			this.CheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.ButtonFindExact);
			this.TabPage2.Controls.Add(this.Label7);
			this.TabPage2.Controls.Add(this.TextBoxFindSelect);
			this.TabPage2.Controls.Add(this.ButtonFindSelect);
			this.TabPage2.Controls.Add(this.ButtonLoadClassList);
			this.TabPage2.Controls.Add(this.CheckedListBox);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(436, 185);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Classes List";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// ButtonLoadClassList
			// 
			this.ButtonLoadClassList.Location = new System.Drawing.Point(333, 6);
			this.ButtonLoadClassList.Name = "ButtonLoadClassList";
			this.ButtonLoadClassList.Size = new System.Drawing.Size(100, 23);
			this.ButtonLoadClassList.TabIndex = 1;
			this.ButtonLoadClassList.Text = "Analysing AI.obj";
			this.ButtonLoadClassList.UseVisualStyleBackColor = true;
			this.ButtonLoadClassList.Click += new System.EventHandler(this.ButtonLoadClassList_Click);
			// 
			// CheckBoxUseList
			// 
			this.CheckBoxUseList.AutoSize = true;
			this.CheckBoxUseList.Enabled = false;
			this.CheckBoxUseList.Location = new System.Drawing.Point(324, 99);
			this.CheckBoxUseList.Name = "CheckBoxUseList";
			this.CheckBoxUseList.Size = new System.Drawing.Size(103, 17);
			this.CheckBoxUseList.TabIndex = 62;
			this.CheckBoxUseList.Text = "Use Classes List";
			this.CheckBoxUseList.UseVisualStyleBackColor = true;
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.CheckBoxUseList);
			this.TabPage1.Controls.Add(this.Label1);
			this.TabPage1.Controls.Add(this.Label3);
			this.TabPage1.Controls.Add(this.Inject);
			this.TabPage1.Controls.Add(this.SplitClassTextBox);
			this.TabPage1.Controls.Add(this.MergeCheckBox1);
			this.TabPage1.Controls.Add(this.Label4);
			this.TabPage1.Controls.Add(this.MergeCheckBox2);
			this.TabPage1.Controls.Add(this.AiFile);
			this.TabPage1.Controls.Add(this.FixFile);
			this.TabPage1.Controls.Add(this.SplitButton);
			this.TabPage1.Controls.Add(this.FixOneClassBox);
			this.TabPage1.Controls.Add(this.MergeButton);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(436, 185);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Control Panel";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(6, 14);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(44, 13);
			this.Label1.TabIndex = 5;
			this.Label1.Text = "AI file:";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(85, 100);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(41, 13);
			this.Label3.TabIndex = 61;
			this.Label3.Text = "Class:";
			// 
			// Inject
			// 
			this.Inject.Location = new System.Drawing.Point(7, 150);
			this.Inject.Name = "Inject";
			this.Inject.Size = new System.Drawing.Size(75, 23);
			this.Inject.TabIndex = 2;
			this.Inject.Text = "Inject fix";
			this.Inject.Click += new System.EventHandler(this.Inject_Click);
			// 
			// SplitClassTextBox
			// 
			this.SplitClassTextBox.Location = new System.Drawing.Point(132, 97);
			this.SplitClassTextBox.Name = "SplitClassTextBox";
			this.SplitClassTextBox.Size = new System.Drawing.Size(186, 20);
			this.SplitClassTextBox.TabIndex = 60;
			// 
			// MergeCheckBox1
			// 
			this.MergeCheckBox1.AutoSize = true;
			this.MergeCheckBox1.Location = new System.Drawing.Point(88, 127);
			this.MergeCheckBox1.Name = "MergeCheckBox1";
			this.MergeCheckBox1.Size = new System.Drawing.Size(163, 17);
			this.MergeCheckBox1.TabIndex = 59;
			this.MergeCheckBox1.Text = "Write class w/o dependence";
			this.MergeCheckBox1.UseVisualStyleBackColor = true;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(6, 53);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(48, 13);
			this.Label4.TabIndex = 7;
			this.Label4.Text = "Fix file:";
			// 
			// MergeCheckBox2
			// 
			this.MergeCheckBox2.AutoSize = true;
			this.MergeCheckBox2.Location = new System.Drawing.Point(252, 127);
			this.MergeCheckBox2.Name = "MergeCheckBox2";
			this.MergeCheckBox2.Size = new System.Drawing.Size(68, 17);
			this.MergeCheckBox2.TabIndex = 57;
			this.MergeCheckBox2.Text = "Write log";
			this.MergeCheckBox2.UseVisualStyleBackColor = true;
			// 
			// AiFile
			// 
			this.AiFile.Location = new System.Drawing.Point(7, 30);
			this.AiFile.Name = "AiFile";
			this.AiFile.ReadOnly = true;
			this.AiFile.Size = new System.Drawing.Size(420, 20);
			this.AiFile.TabIndex = 8;
			// 
			// FixFile
			// 
			this.FixFile.Location = new System.Drawing.Point(7, 69);
			this.FixFile.Name = "FixFile";
			this.FixFile.ReadOnly = true;
			this.FixFile.Size = new System.Drawing.Size(420, 20);
			this.FixFile.TabIndex = 9;
			// 
			// SplitButton
			// 
			this.SplitButton.Location = new System.Drawing.Point(7, 95);
			this.SplitButton.Name = "SplitButton";
			this.SplitButton.Size = new System.Drawing.Size(75, 23);
			this.SplitButton.TabIndex = 13;
			this.SplitButton.Text = "Split";
			this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
			// 
			// FixOneClassBox
			// 
			this.FixOneClassBox.AutoSize = true;
			this.FixOneClassBox.Location = new System.Drawing.Point(88, 154);
			this.FixOneClassBox.Name = "FixOneClassBox";
			this.FixOneClassBox.Size = new System.Drawing.Size(89, 17);
			this.FixOneClassBox.TabIndex = 48;
			this.FixOneClassBox.Text = "Fix One class";
			this.FixOneClassBox.UseVisualStyleBackColor = true;
			// 
			// MergeButton
			// 
			this.MergeButton.Location = new System.Drawing.Point(7, 121);
			this.MergeButton.Name = "MergeButton";
			this.MergeButton.Size = new System.Drawing.Size(75, 23);
			this.MergeButton.TabIndex = 14;
			this.MergeButton.Text = "Merge";
			this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(112, 12);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(444, 211);
			this.TabControl1.TabIndex = 70;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label5.Location = new System.Drawing.Point(9, 245);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(97, 13);
			this.Label5.TabIndex = 69;
			this.Label5.Text = "(support C4 scripts)";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label6.Location = new System.Drawing.Point(9, 229);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(94, 16);
			this.Label6.TabIndex = 68;
			this.Label6.Text = "AI.obj Builder";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.InitialImage = null;
			this.PictureBox1.Location = new System.Drawing.Point(9, 9);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(89, 198);
			this.PictureBox1.TabIndex = 67;
			this.PictureBox1.TabStop = false;
			// 
			// FolderBrowserDialog
			// 
			this.FolderBrowserDialog.SelectedPath = "FolderBrowserDialog";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(116, 226);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(47, 13);
			this.Label2.TabIndex = 66;
			this.Label2.Text = "Status:";
			// 
			// StatusBox
			// 
			this.StatusBox.Location = new System.Drawing.Point(116, 242);
			this.StatusBox.Name = "StatusBox";
			this.StatusBox.ReadOnly = true;
			this.StatusBox.Size = new System.Drawing.Size(436, 20);
			this.StatusBox.TabIndex = 65;
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(116, 268);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(436, 23);
			this.ProgressBar.Step = 1;
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 64;
			// 
			// Quit
			// 
			this.Quit.Location = new System.Drawing.Point(17, 268);
			this.Quit.Name = "Quit";
			this.Quit.Size = new System.Drawing.Size(75, 23);
			this.Quit.TabIndex = 63;
			this.Quit.Text = "Quit";
			this.Quit.Click += new System.EventHandler(this.Quit_Click);
			// 
			// AiInjector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 301);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.StatusBox);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.Quit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AiInjector";
			this.Text = "Lineage II Intelligence class Builder";
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button ButtonFindExact;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TextBox TextBoxFindSelect;
		internal System.Windows.Forms.Button ButtonFindSelect;
		internal System.Windows.Forms.CheckedListBox CheckedListBox;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Button ButtonLoadClassList;
		internal System.Windows.Forms.CheckBox CheckBoxUseList;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button Inject;
		internal System.Windows.Forms.TextBox SplitClassTextBox;
		internal System.Windows.Forms.CheckBox MergeCheckBox1;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.CheckBox MergeCheckBox2;
		internal System.Windows.Forms.TextBox AiFile;
		internal System.Windows.Forms.TextBox FixFile;
		internal System.Windows.Forms.Button SplitButton;
		internal System.Windows.Forms.CheckBox FixOneClassBox;
		internal System.Windows.Forms.Button MergeButton;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox StatusBox;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Button Quit;
	}
}