namespace L2ScriptMaker.Modules.Skills
{
	partial class SkillAcquireEditor
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
			this.skill_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.lv_up_sp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.auto_get = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.AutoSortComboBox = new System.Windows.Forms.ComboBox();
			this.AutoSortCheckBox = new System.Windows.Forms.CheckBox();
			this.AddDownButton = new System.Windows.Forms.Button();
			this.CloneDownButton = new System.Windows.Forms.Button();
			this.CloneUpButton = new System.Windows.Forms.Button();
			this.CopyDownButton = new System.Windows.Forms.Button();
			this.CopyUpButton = new System.Windows.Forms.Button();
			this.MoveDownButton = new System.Windows.Forms.Button();
			this.item_needed1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.item_needed1_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.item_needed2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.MoveUpButton = new System.Windows.Forms.Button();
			this.CopyPasteComboBox = new System.Windows.Forms.ComboBox();
			this.CopyPasteSkillButton = new System.Windows.Forms.Button();
			this.CopyPasteTextBox = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.get_lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.item_needed2_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Label4 = new System.Windows.Forms.Label();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.Label2 = new System.Windows.Forms.Label();
			this.AddRowBeforeButton = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.InheritsComboBox = new System.Windows.Forms.ComboBox();
			this.SaveSkillAcquireButton = new System.Windows.Forms.Button();
			this.LoadSkillAcquireButton = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ClassListBox = new System.Windows.Forms.ListBox();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.DataGridView = new System.Windows.Forms.DataGridView();
			this.QuitButton = new System.Windows.Forms.Button();
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// skill_name
			// 
			this.skill_name.HeaderText = "skill_name";
			this.skill_name.Name = "skill_name";
			this.skill_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.skill_name.Width = 200;
			// 
			// lv_up_sp
			// 
			dataGridViewCellStyle69.NullValue = "0";
			this.lv_up_sp.DefaultCellStyle = dataGridViewCellStyle69;
			this.lv_up_sp.HeaderText = "lv_up_sp";
			this.lv_up_sp.Name = "lv_up_sp";
			// 
			// auto_get
			// 
			dataGridViewCellStyle70.NullValue = "False";
			this.auto_get.DefaultCellStyle = dataGridViewCellStyle70;
			this.auto_get.HeaderText = "auto_get";
			this.auto_get.Items.AddRange(new object[] {
            "False",
            "True"});
			this.auto_get.Name = "auto_get";
			this.auto_get.Width = 60;
			// 
			// AutoSortComboBox
			// 
			this.AutoSortComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "skill_name",
            "get_lv",
            "lv_up_sp",
            "auto_get"});
			this.AutoSortComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.AutoSortComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.AutoSortComboBox.Items.AddRange(new object[] {
            "skill_name",
            "get_lv",
            "lv_up_sp",
            "auto_get"});
			this.AutoSortComboBox.Location = new System.Drawing.Point(2, 258);
			this.AutoSortComboBox.Name = "AutoSortComboBox";
			this.AutoSortComboBox.Size = new System.Drawing.Size(121, 21);
			this.AutoSortComboBox.TabIndex = 68;
			this.AutoSortComboBox.Text = "skill_name";
			// 
			// AutoSortCheckBox
			// 
			this.AutoSortCheckBox.AutoSize = true;
			this.AutoSortCheckBox.Location = new System.Drawing.Point(3, 241);
			this.AutoSortCheckBox.Name = "AutoSortCheckBox";
			this.AutoSortCheckBox.Size = new System.Drawing.Size(96, 17);
			this.AutoSortCheckBox.TabIndex = 67;
			this.AutoSortCheckBox.Text = "Auto sorting by";
			this.AutoSortCheckBox.UseVisualStyleBackColor = true;
			this.AutoSortCheckBox.CheckedChanged += new System.EventHandler(this.AutoSortCheckBox_CheckedChanged);
			// 
			// AddDownButton
			// 
			this.AddDownButton.Location = new System.Drawing.Point(3, 215);
			this.AddDownButton.Name = "AddDownButton";
			this.AddDownButton.Size = new System.Drawing.Size(75, 23);
			this.AddDownButton.TabIndex = 66;
			this.AddDownButton.Text = "Add Down";
			this.AddDownButton.UseVisualStyleBackColor = true;
			this.AddDownButton.Click += new System.EventHandler(this.AddDownButton_Click);
			// 
			// CloneDownButton
			// 
			this.CloneDownButton.Location = new System.Drawing.Point(3, 186);
			this.CloneDownButton.Name = "CloneDownButton";
			this.CloneDownButton.Size = new System.Drawing.Size(75, 23);
			this.CloneDownButton.TabIndex = 65;
			this.CloneDownButton.Text = "CloneDown";
			this.CloneDownButton.UseVisualStyleBackColor = true;
			this.CloneDownButton.Click += new System.EventHandler(this.CloneDownButton_Click);
			// 
			// CloneUpButton
			// 
			this.CloneUpButton.Location = new System.Drawing.Point(3, 41);
			this.CloneUpButton.Name = "CloneUpButton";
			this.CloneUpButton.Size = new System.Drawing.Size(75, 23);
			this.CloneUpButton.TabIndex = 64;
			this.CloneUpButton.Text = "CloneUp";
			this.CloneUpButton.UseVisualStyleBackColor = true;
			this.CloneUpButton.Click += new System.EventHandler(this.CloneUpButton_Click);
			// 
			// CopyDownButton
			// 
			this.CopyDownButton.Location = new System.Drawing.Point(3, 157);
			this.CopyDownButton.Name = "CopyDownButton";
			this.CopyDownButton.Size = new System.Drawing.Size(75, 23);
			this.CopyDownButton.TabIndex = 63;
			this.CopyDownButton.Text = "CopyDown";
			this.CopyDownButton.UseVisualStyleBackColor = true;
			this.CopyDownButton.Click += new System.EventHandler(this.CopyDownButton_Click);
			// 
			// CopyUpButton
			// 
			this.CopyUpButton.Location = new System.Drawing.Point(3, 70);
			this.CopyUpButton.Name = "CopyUpButton";
			this.CopyUpButton.Size = new System.Drawing.Size(75, 23);
			this.CopyUpButton.TabIndex = 62;
			this.CopyUpButton.Text = "CopyUp";
			this.CopyUpButton.UseVisualStyleBackColor = true;
			this.CopyUpButton.Click += new System.EventHandler(this.CopyUpButton_Click);
			// 
			// MoveDownButton
			// 
			this.MoveDownButton.Location = new System.Drawing.Point(3, 128);
			this.MoveDownButton.Name = "MoveDownButton";
			this.MoveDownButton.Size = new System.Drawing.Size(75, 23);
			this.MoveDownButton.TabIndex = 61;
			this.MoveDownButton.Text = "MoveDown";
			this.MoveDownButton.UseVisualStyleBackColor = true;
			this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
			// 
			// item_needed1
			// 
			this.item_needed1.HeaderText = "item_needed1";
			this.item_needed1.Name = "item_needed1";
			this.item_needed1.Width = 150;
			// 
			// item_needed1_value
			// 
			dataGridViewCellStyle71.NullValue = "0";
			this.item_needed1_value.DefaultCellStyle = dataGridViewCellStyle71;
			this.item_needed1_value.HeaderText = "item_needed1_value";
			this.item_needed1_value.Name = "item_needed1_value";
			this.item_needed1_value.Width = 30;
			// 
			// item_needed2
			// 
			this.item_needed2.HeaderText = "item_needed";
			this.item_needed2.Name = "item_needed2";
			// 
			// MoveUpButton
			// 
			this.MoveUpButton.Location = new System.Drawing.Point(3, 99);
			this.MoveUpButton.Name = "MoveUpButton";
			this.MoveUpButton.Size = new System.Drawing.Size(75, 23);
			this.MoveUpButton.TabIndex = 60;
			this.MoveUpButton.Text = "MoveUp";
			this.MoveUpButton.UseVisualStyleBackColor = true;
			this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
			// 
			// CopyPasteComboBox
			// 
			this.CopyPasteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.CopyPasteComboBox.FormattingEnabled = true;
			this.CopyPasteComboBox.Items.AddRange(new object[] {
            "skill_name",
            "item_needed1",
            "item_needed2",
            "note"});
			this.CopyPasteComboBox.Location = new System.Drawing.Point(415, 283);
			this.CopyPasteComboBox.Name = "CopyPasteComboBox";
			this.CopyPasteComboBox.Size = new System.Drawing.Size(140, 21);
			this.CopyPasteComboBox.TabIndex = 59;
			this.CopyPasteComboBox.Text = "skill_name";
			// 
			// CopyPasteSkillButton
			// 
			this.CopyPasteSkillButton.Location = new System.Drawing.Point(295, 281);
			this.CopyPasteSkillButton.Name = "CopyPasteSkillButton";
			this.CopyPasteSkillButton.Size = new System.Drawing.Size(114, 23);
			this.CopyPasteSkillButton.TabIndex = 55;
			this.CopyPasteSkillButton.Text = "Copy/Paste to";
			this.CopyPasteSkillButton.UseVisualStyleBackColor = true;
			this.CopyPasteSkillButton.Click += new System.EventHandler(this.CopyPasteSkillButton_Click);
			// 
			// CopyPasteTextBox
			// 
			this.CopyPasteTextBox.Location = new System.Drawing.Point(295, 257);
			this.CopyPasteTextBox.Name = "CopyPasteTextBox";
			this.CopyPasteTextBox.Size = new System.Drawing.Size(260, 20);
			this.CopyPasteTextBox.TabIndex = 53;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(675, 255);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 52;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// get_lv
			// 
			dataGridViewCellStyle72.NullValue = "0";
			this.get_lv.DefaultCellStyle = dataGridViewCellStyle72;
			this.get_lv.HeaderText = "get_lv";
			this.get_lv.Name = "get_lv";
			this.get_lv.Width = 40;
			// 
			// item_needed2_value
			// 
			this.item_needed2_value.HeaderText = "item_needed2_value";
			this.item_needed2_value.Name = "item_needed2_value";
			// 
			// note
			// 
			this.note.HeaderText = "note";
			this.note.Name = "note";
			this.note.Width = 200;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(292, 241);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(130, 13);
			this.Label4.TabIndex = 54;
			this.Label4.Text = "Pch name for copy/paste:";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(675, 239);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(121, 16);
			this.Label2.TabIndex = 51;
			this.Label2.Text = "SkillAquire Editor";
			// 
			// AddRowBeforeButton
			// 
			this.AddRowBeforeButton.Location = new System.Drawing.Point(3, 12);
			this.AddRowBeforeButton.Name = "AddRowBeforeButton";
			this.AddRowBeforeButton.Size = new System.Drawing.Size(75, 23);
			this.AddRowBeforeButton.TabIndex = 7;
			this.AddRowBeforeButton.Text = "Add Up";
			this.AddRowBeforeButton.UseVisualStyleBackColor = true;
			this.AddRowBeforeButton.Click += new System.EventHandler(this.AddRowBeforeButton_Click);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(136, 242);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(116, 13);
			this.Label1.TabIndex = 6;
			this.Label1.Text = "Include main class:";
			// 
			// InheritsComboBox
			// 
			this.InheritsComboBox.FormattingEnabled = true;
			this.InheritsComboBox.Items.AddRange(new object[] {
            "fighter_begin",
            "warrior_begin"});
			this.InheritsComboBox.Location = new System.Drawing.Point(139, 258);
			this.InheritsComboBox.Name = "InheritsComboBox";
			this.InheritsComboBox.Size = new System.Drawing.Size(121, 21);
			this.InheritsComboBox.TabIndex = 5;
			this.InheritsComboBox.Validated += new System.EventHandler(this.InheritsComboBox_Validated);
			// 
			// SaveSkillAcquireButton
			// 
			this.SaveSkillAcquireButton.Location = new System.Drawing.Point(561, 281);
			this.SaveSkillAcquireButton.Name = "SaveSkillAcquireButton";
			this.SaveSkillAcquireButton.Size = new System.Drawing.Size(102, 23);
			this.SaveSkillAcquireButton.TabIndex = 4;
			this.SaveSkillAcquireButton.Text = "Save SkillAcquire";
			this.SaveSkillAcquireButton.UseVisualStyleBackColor = true;
			this.SaveSkillAcquireButton.Click += new System.EventHandler(this.SaveSkillAquireButton_Click);
			// 
			// LoadSkillAcquireButton
			// 
			this.LoadSkillAcquireButton.Location = new System.Drawing.Point(3, 281);
			this.LoadSkillAcquireButton.Name = "LoadSkillAcquireButton";
			this.LoadSkillAcquireButton.Size = new System.Drawing.Size(102, 23);
			this.LoadSkillAcquireButton.TabIndex = 3;
			this.LoadSkillAcquireButton.Text = "Load SkillAcquire";
			this.LoadSkillAcquireButton.UseVisualStyleBackColor = true;
			this.LoadSkillAcquireButton.Click += new System.EventHandler(this.LoadSkillAcquireButton_Click);
			// 
			// ClassListBox
			// 
			this.ClassListBox.FormattingEnabled = true;
			this.ClassListBox.Items.AddRange(new object[] {
            "fighter_begin",
            "warrior_begin"});
			this.ClassListBox.Location = new System.Drawing.Point(12, 12);
			this.ClassListBox.Name = "ClassListBox";
			this.ClassListBox.Size = new System.Drawing.Size(113, 264);
			this.ClassListBox.TabIndex = 2;
			this.ClassListBox.SelectedValueChanged += new System.EventHandler(this.ClassListBox_SelectedValueChanged);
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(12, 281);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(113, 23);
			this.ProgressBar.TabIndex = 2;
			// 
			// DataGridView
			// 
			this.DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.skill_name,
            this.get_lv,
            this.lv_up_sp,
            this.auto_get,
            this.item_needed1,
            this.item_needed1_value,
            this.item_needed2,
            this.item_needed2_value,
            this.note});
			this.DataGridView.Location = new System.Drawing.Point(84, 12);
			this.DataGridView.Name = "DataGridView";
			this.DataGridView.Size = new System.Drawing.Size(714, 224);
			this.DataGridView.TabIndex = 1;
			this.DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(721, 281);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 0;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// SplitContainer1
			// 
			this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer1.Name = "SplitContainer1";
			// 
			// SplitContainer1.Panel1
			// 
			this.SplitContainer1.Panel1.Controls.Add(this.ClassListBox);
			this.SplitContainer1.Panel1.Controls.Add(this.ProgressBar);
			// 
			// SplitContainer1.Panel2
			// 
			this.SplitContainer1.Panel2.Controls.Add(this.AutoSortComboBox);
			this.SplitContainer1.Panel2.Controls.Add(this.AutoSortCheckBox);
			this.SplitContainer1.Panel2.Controls.Add(this.AddDownButton);
			this.SplitContainer1.Panel2.Controls.Add(this.CloneDownButton);
			this.SplitContainer1.Panel2.Controls.Add(this.CloneUpButton);
			this.SplitContainer1.Panel2.Controls.Add(this.CopyDownButton);
			this.SplitContainer1.Panel2.Controls.Add(this.CopyUpButton);
			this.SplitContainer1.Panel2.Controls.Add(this.MoveDownButton);
			this.SplitContainer1.Panel2.Controls.Add(this.MoveUpButton);
			this.SplitContainer1.Panel2.Controls.Add(this.CopyPasteComboBox);
			this.SplitContainer1.Panel2.Controls.Add(this.CopyPasteSkillButton);
			this.SplitContainer1.Panel2.Controls.Add(this.Label4);
			this.SplitContainer1.Panel2.Controls.Add(this.CopyPasteTextBox);
			this.SplitContainer1.Panel2.Controls.Add(this.Label3);
			this.SplitContainer1.Panel2.Controls.Add(this.Label2);
			this.SplitContainer1.Panel2.Controls.Add(this.AddRowBeforeButton);
			this.SplitContainer1.Panel2.Controls.Add(this.Label1);
			this.SplitContainer1.Panel2.Controls.Add(this.InheritsComboBox);
			this.SplitContainer1.Panel2.Controls.Add(this.SaveSkillAcquireButton);
			this.SplitContainer1.Panel2.Controls.Add(this.LoadSkillAcquireButton);
			this.SplitContainer1.Panel2.Controls.Add(this.DataGridView);
			this.SplitContainer1.Panel2.Controls.Add(this.QuitButton);
			this.SplitContainer1.Size = new System.Drawing.Size(949, 311);
			this.SplitContainer1.SplitterDistance = 134;
			this.SplitContainer1.TabIndex = 1;
			// 
			// SkillAcquireEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(949, 311);
			this.Controls.Add(this.SplitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SkillAcquireEditor";
			this.Text = "SkillAcquire Editor";
			this.Load += new System.EventHandler(this.SkillAquireEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
			this.SplitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.DataGridViewComboBoxColumn skill_name;
		internal System.Windows.Forms.DataGridViewTextBoxColumn lv_up_sp;
		internal System.Windows.Forms.DataGridViewComboBoxColumn auto_get;
		internal System.Windows.Forms.ComboBox AutoSortComboBox;
		internal System.Windows.Forms.CheckBox AutoSortCheckBox;
		internal System.Windows.Forms.Button AddDownButton;
		internal System.Windows.Forms.Button CloneDownButton;
		internal System.Windows.Forms.Button CloneUpButton;
		internal System.Windows.Forms.Button CopyDownButton;
		internal System.Windows.Forms.Button CopyUpButton;
		internal System.Windows.Forms.Button MoveDownButton;
		internal System.Windows.Forms.DataGridViewComboBoxColumn item_needed1;
		internal System.Windows.Forms.DataGridViewTextBoxColumn item_needed1_value;
		internal System.Windows.Forms.DataGridViewComboBoxColumn item_needed2;
		internal System.Windows.Forms.Button MoveUpButton;
		internal System.Windows.Forms.ComboBox CopyPasteComboBox;
		internal System.Windows.Forms.Button CopyPasteSkillButton;
		internal System.Windows.Forms.TextBox CopyPasteTextBox;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.DataGridViewTextBoxColumn get_lv;
		internal System.Windows.Forms.DataGridViewTextBoxColumn item_needed2_value;
		internal System.Windows.Forms.DataGridViewTextBoxColumn note;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button AddRowBeforeButton;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ComboBox InheritsComboBox;
		internal System.Windows.Forms.Button SaveSkillAcquireButton;
		internal System.Windows.Forms.Button LoadSkillAcquireButton;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.ListBox ClassListBox;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.DataGridView DataGridView;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
	}
}