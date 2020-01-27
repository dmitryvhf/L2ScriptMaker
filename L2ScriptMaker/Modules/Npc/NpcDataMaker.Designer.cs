namespace L2ScriptMaker.Modules.Npc
{
	partial class NpcDataMaker
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcDataMaker));
			this.ButtonClear = new System.Windows.Forms.Button();
			this.ButtonGenerate = new System.Windows.Forms.Button();
			this.FinalTextBox = new System.Windows.Forms.TextBox();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.CommonStatTextBox = new System.Windows.Forms.TextBox();
			this.NpcTypeComboBox = new System.Windows.Forms.ComboBox();
			this.base_magic_defend = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.base_defend = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.base_magic_attack = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.base_physical_attack = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.org_mp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.org_hp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGridView1 = new System.Windows.Forms.DataGridView();
			this.base_attack_speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.Label1 = new System.Windows.Forms.Label();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
			this.TabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.TabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonClear
			// 
			this.ButtonClear.Location = new System.Drawing.Point(30, 207);
			this.ButtonClear.Name = "ButtonClear";
			this.ButtonClear.Size = new System.Drawing.Size(75, 23);
			this.ButtonClear.TabIndex = 23;
			this.ButtonClear.Text = "Clear";
			this.ButtonClear.UseVisualStyleBackColor = true;
			this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
			// 
			// ButtonGenerate
			// 
			this.ButtonGenerate.Location = new System.Drawing.Point(30, 176);
			this.ButtonGenerate.Name = "ButtonGenerate";
			this.ButtonGenerate.Size = new System.Drawing.Size(75, 23);
			this.ButtonGenerate.TabIndex = 21;
			this.ButtonGenerate.Text = "Generate";
			this.ButtonGenerate.UseVisualStyleBackColor = true;
			this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
			// 
			// FinalTextBox
			// 
			this.FinalTextBox.Location = new System.Drawing.Point(6, 6);
			this.FinalTextBox.Multiline = true;
			this.FinalTextBox.Name = "FinalTextBox";
			this.FinalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.FinalTextBox.Size = new System.Drawing.Size(621, 160);
			this.FinalTextBox.TabIndex = 4;
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.FinalTextBox);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(633, 172);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Generate result";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// CommonStatTextBox
			// 
			this.CommonStatTextBox.Location = new System.Drawing.Point(104, 7);
			this.CommonStatTextBox.Name = "CommonStatTextBox";
			this.CommonStatTextBox.ReadOnly = true;
			this.CommonStatTextBox.Size = new System.Drawing.Size(480, 20);
			this.CommonStatTextBox.TabIndex = 1;
			// 
			// NpcTypeComboBox
			// 
			this.NpcTypeComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "warrior",
            "boss"});
			this.NpcTypeComboBox.FormattingEnabled = true;
			this.NpcTypeComboBox.Items.AddRange(new object[] {
            "warrior",
            "boss"});
			this.NpcTypeComboBox.Location = new System.Drawing.Point(6, 6);
			this.NpcTypeComboBox.Name = "NpcTypeComboBox";
			this.NpcTypeComboBox.Size = new System.Drawing.Size(92, 21);
			this.NpcTypeComboBox.TabIndex = 0;
			this.NpcTypeComboBox.TextChanged += new System.EventHandler(this.NpcTypeComboBox_TextChanged);
			// 
			// base_magic_defend
			// 
			dataGridViewCellStyle50.Format = "N2";
			dataGridViewCellStyle50.NullValue = "NULL";
			this.base_magic_defend.DefaultCellStyle = dataGridViewCellStyle50;
			this.base_magic_defend.HeaderText = "base_magic_defend";
			this.base_magic_defend.Name = "base_magic_defend";
			// 
			// base_defend
			// 
			dataGridViewCellStyle51.Format = "N2";
			dataGridViewCellStyle51.NullValue = "NULL";
			this.base_defend.DefaultCellStyle = dataGridViewCellStyle51;
			this.base_defend.HeaderText = "base_defend";
			this.base_defend.Name = "base_defend";
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(690, 215);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 22;
			this.ButtonQuit.Text = "Exit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// base_magic_attack
			// 
			dataGridViewCellStyle52.Format = "N2";
			dataGridViewCellStyle52.NullValue = "NULL";
			this.base_magic_attack.DefaultCellStyle = dataGridViewCellStyle52;
			this.base_magic_attack.HeaderText = "base_magic_attack";
			this.base_magic_attack.Name = "base_magic_attack";
			// 
			// base_physical_attack
			// 
			dataGridViewCellStyle53.Format = "N2";
			dataGridViewCellStyle53.NullValue = "NULL";
			this.base_physical_attack.DefaultCellStyle = dataGridViewCellStyle53;
			this.base_physical_attack.HeaderText = "base_physical_attack";
			this.base_physical_attack.Name = "base_physical_attack";
			// 
			// org_mp
			// 
			dataGridViewCellStyle54.Format = "N0";
			dataGridViewCellStyle54.NullValue = "NULL";
			this.org_mp.DefaultCellStyle = dataGridViewCellStyle54;
			this.org_mp.HeaderText = "org_mp";
			this.org_mp.Name = "org_mp";
			// 
			// org_hp
			// 
			dataGridViewCellStyle55.Format = "N0";
			dataGridViewCellStyle55.NullValue = "NULL";
			this.org_hp.DefaultCellStyle = dataGridViewCellStyle55;
			this.org_hp.HeaderText = "org_hp";
			this.org_hp.Name = "org_hp";
			// 
			// DataGridView1
			// 
			this.DataGridView1.AllowUserToAddRows = false;
			this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.org_hp,
            this.org_mp,
            this.base_physical_attack,
            this.base_attack_speed,
            this.base_magic_attack,
            this.base_defend,
            this.base_magic_defend});
			this.DataGridView1.Location = new System.Drawing.Point(6, 33);
			this.DataGridView1.Name = "DataGridView1";
			this.DataGridView1.Size = new System.Drawing.Size(609, 112);
			this.DataGridView1.TabIndex = 2;
			// 
			// base_attack_speed
			// 
			dataGridViewCellStyle56.Format = "N2";
			dataGridViewCellStyle56.NullValue = "NULL";
			this.base_attack_speed.DefaultCellStyle = dataGridViewCellStyle56;
			this.base_attack_speed.HeaderText = "base_attack_speed";
			this.base_attack_speed.Name = "base_attack_speed";
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.DataGridView1);
			this.TabPage1.Controls.Add(this.CommonStatTextBox);
			this.TabPage1.Controls.Add(this.NpcTypeComboBox);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(633, 172);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Working place";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(10, 8);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 162);
			this.PictureBox1.TabIndex = 18;
			this.PictureBox1.TabStop = false;
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(128, 11);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(641, 198);
			this.TabControl1.TabIndex = 20;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(568, 8);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(195, 19);
			this.Label1.TabIndex = 24;
			this.Label1.Text = "simple NpcData stats maker";
			// 
			// NpcDataMaker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(779, 246);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.ButtonClear);
			this.Controls.Add(this.ButtonGenerate);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.TabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NpcDataMaker";
			this.Text = "NpcDataMaker";
			this.Load += new System.EventHandler(this.NpcDataMaker_Load);
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.TabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button ButtonClear;
		internal System.Windows.Forms.Button ButtonGenerate;
		internal System.Windows.Forms.TextBox FinalTextBox;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.TextBox CommonStatTextBox;
		internal System.Windows.Forms.ComboBox NpcTypeComboBox;
		internal System.Windows.Forms.DataGridViewTextBoxColumn base_magic_defend;
		internal System.Windows.Forms.DataGridViewTextBoxColumn base_defend;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.DataGridViewTextBoxColumn base_magic_attack;
		internal System.Windows.Forms.DataGridViewTextBoxColumn base_physical_attack;
		internal System.Windows.Forms.DataGridViewTextBoxColumn org_mp;
		internal System.Windows.Forms.DataGridViewTextBoxColumn org_hp;
		internal System.Windows.Forms.DataGridView DataGridView1;
		internal System.Windows.Forms.DataGridViewTextBoxColumn base_attack_speed;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.Label Label1;
	}
}