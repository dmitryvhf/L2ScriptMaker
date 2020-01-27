namespace L2ScriptMaker.Modules.Scripts
{
	partial class ScriptLeecher
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
			this.Label13 = new System.Windows.Forms.Label();
			this.bLoadObraz = new System.Windows.Forms.Button();
			this.QuitButton = new System.Windows.Forms.Button();
			this.bSave = new System.Windows.Forms.Button();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.textSave = new System.Windows.Forms.TextBox();
			this.Status1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.Status = new System.Windows.Forms.StatusStrip();
			this.bCompute = new System.Windows.Forms.Button();
			this.cGrid = new System.Windows.Forms.DataGridView();
			this.sParameter = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.oParameter = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.num1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.num2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rInumber = new System.Windows.Forms.RadioButton();
			this.rIname = new System.Windows.Forms.RadioButton();
			this.rOnumber = new System.Windows.Forms.RadioButton();
			this.rOname = new System.Windows.Forms.RadioButton();
			this.GroupBox5 = new System.Windows.Forms.GroupBox();
			this.GroupBox4 = new System.Windows.Forms.GroupBox();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.Level = new System.Windows.Forms.ComboBox();
			this.ID = new System.Windows.Forms.ComboBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Open = new System.Windows.Forms.OpenFileDialog();
			this.Label14 = new System.Windows.Forms.Label();
			this.bOpenSource = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.textSource = new System.Windows.Forms.TextBox();
			this.GroupBox3.SuspendLayout();
			this.Status.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cGrid)).BeginInit();
			this.GroupBox5.SuspendLayout();
			this.GroupBox4.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label13
			// 
			this.Label13.AutoSize = true;
			this.Label13.Location = new System.Drawing.Point(301, 50);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(140, 26);
			this.Label13.TabIndex = 26;
			this.Label13.Text = "Developed by E.Koksharov,\r\nRussia, Ekaterinburg";
			// 
			// bLoadObraz
			// 
			this.bLoadObraz.Location = new System.Drawing.Point(444, 54);
			this.bLoadObraz.Name = "bLoadObraz";
			this.bLoadObraz.Size = new System.Drawing.Size(117, 35);
			this.bLoadObraz.TabIndex = 25;
			this.bLoadObraz.Text = "Loading like specimen/pattern";
			this.bLoadObraz.UseVisualStyleBackColor = true;
			this.bLoadObraz.Click += new System.EventHandler(this.bLoadObraz_Click);
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(481, 15);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 13;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// bSave
			// 
			this.bSave.Location = new System.Drawing.Point(374, 15);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(101, 22);
			this.bSave.TabIndex = 12;
			this.bSave.Text = "Save";
			this.bSave.UseVisualStyleBackColor = true;
			this.bSave.Click += new System.EventHandler(this.bSave_Click);
			// 
			// GroupBox3
			// 
			this.GroupBox3.Controls.Add(this.QuitButton);
			this.GroupBox3.Controls.Add(this.bSave);
			this.GroupBox3.Controls.Add(this.Label6);
			this.GroupBox3.Controls.Add(this.textSave);
			this.GroupBox3.Location = new System.Drawing.Point(5, 434);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(556, 47);
			this.GroupBox3.TabIndex = 24;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Results:";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(9, 20);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(26, 13);
			this.Label6.TabIndex = 10;
			this.Label6.Text = "File:";
			// 
			// textSave
			// 
			this.textSave.Location = new System.Drawing.Point(50, 17);
			this.textSave.Name = "textSave";
			this.textSave.Size = new System.Drawing.Size(318, 20);
			this.textSave.TabIndex = 9;
			this.textSave.DoubleClick += new System.EventHandler(this.textSave_DoubleClick);
			// 
			// Status1
			// 
			this.Status1.Name = "Status1";
			this.Status1.Size = new System.Drawing.Size(39, 17);
			this.Status1.Text = "Ready";
			// 
			// ToolStripProgressBar
			// 
			this.ToolStripProgressBar.Name = "ToolStripProgressBar";
			this.ToolStripProgressBar.Size = new System.Drawing.Size(350, 16);
			this.ToolStripProgressBar.Step = 1;
			this.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// Status
			// 
			this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripProgressBar,
            this.Status1});
			this.Status.Location = new System.Drawing.Point(0, 484);
			this.Status.Name = "Status";
			this.Status.Size = new System.Drawing.Size(569, 22);
			this.Status.TabIndex = 23;
			this.Status.Text = "StatusStrip1";
			// 
			// bCompute
			// 
			this.bCompute.Location = new System.Drawing.Point(440, 293);
			this.bCompute.Name = "bCompute";
			this.bCompute.Size = new System.Drawing.Size(101, 22);
			this.bCompute.TabIndex = 13;
			this.bCompute.Text = "Analyzing";
			this.bCompute.UseVisualStyleBackColor = true;
			this.bCompute.Click += new System.EventHandler(this.bCompute_Click);
			// 
			// cGrid
			// 
			this.cGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.cGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sParameter,
            this.oParameter,
            this.num1,
            this.num2});
			this.cGrid.Location = new System.Drawing.Point(7, 89);
			this.cGrid.Name = "cGrid";
			this.cGrid.Size = new System.Drawing.Size(534, 198);
			this.cGrid.TabIndex = 2;
			// 
			// sParameter
			// 
			this.sParameter.HeaderText = "Parameter of source";
			this.sParameter.Name = "sParameter";
			this.sParameter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.sParameter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.sParameter.Width = 230;
			// 
			// oParameter
			// 
			this.oParameter.HeaderText = "Parameter of pattern";
			this.oParameter.Name = "oParameter";
			this.oParameter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.oParameter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.oParameter.Width = 230;
			// 
			// num1
			// 
			this.num1.HeaderText = "num1";
			this.num1.Name = "num1";
			this.num1.Visible = false;
			// 
			// num2
			// 
			this.num2.HeaderText = "num2";
			this.num2.Name = "num2";
			this.num2.Visible = false;
			// 
			// rInumber
			// 
			this.rInumber.AutoSize = true;
			this.rInumber.Location = new System.Drawing.Point(6, 44);
			this.rInumber.Name = "rInumber";
			this.rInumber.Size = new System.Drawing.Size(89, 17);
			this.rInumber.TabIndex = 1;
			this.rInumber.TabStop = true;
			this.rInumber.Text = "Serial number";
			this.rInumber.UseVisualStyleBackColor = true;
			this.rInumber.CheckedChanged += new System.EventHandler(this.rInumber_CheckedChanged);
			// 
			// rIname
			// 
			this.rIname.AutoSize = true;
			this.rIname.Location = new System.Drawing.Point(6, 21);
			this.rIname.Name = "rIname";
			this.rIname.Size = new System.Drawing.Size(53, 17);
			this.rIname.TabIndex = 0;
			this.rIname.TabStop = true;
			this.rIname.Text = "Name";
			this.rIname.UseVisualStyleBackColor = true;
			this.rIname.CheckedChanged += new System.EventHandler(this.rIname_CheckedChanged);
			// 
			// rOnumber
			// 
			this.rOnumber.AutoSize = true;
			this.rOnumber.Location = new System.Drawing.Point(6, 44);
			this.rOnumber.Name = "rOnumber";
			this.rOnumber.Size = new System.Drawing.Size(89, 17);
			this.rOnumber.TabIndex = 3;
			this.rOnumber.TabStop = true;
			this.rOnumber.Text = "Serial number";
			this.rOnumber.UseVisualStyleBackColor = true;
			this.rOnumber.CheckedChanged += new System.EventHandler(this.rOnumber_CheckedChanged);
			// 
			// rOname
			// 
			this.rOname.AutoSize = true;
			this.rOname.Location = new System.Drawing.Point(6, 21);
			this.rOname.Name = "rOname";
			this.rOname.Size = new System.Drawing.Size(53, 17);
			this.rOname.TabIndex = 2;
			this.rOname.TabStop = true;
			this.rOname.Text = "Name";
			this.rOname.UseVisualStyleBackColor = true;
			this.rOname.CheckedChanged += new System.EventHandler(this.rOname_CheckedChanged);
			// 
			// GroupBox5
			// 
			this.GroupBox5.Controls.Add(this.rOnumber);
			this.GroupBox5.Controls.Add(this.rOname);
			this.GroupBox5.Location = new System.Drawing.Point(233, 8);
			this.GroupBox5.Name = "GroupBox5";
			this.GroupBox5.Size = new System.Drawing.Size(219, 70);
			this.GroupBox5.TabIndex = 1;
			this.GroupBox5.TabStop = false;
			this.GroupBox5.Text = "Identify specimen/pattern by..";
			// 
			// GroupBox4
			// 
			this.GroupBox4.Controls.Add(this.rInumber);
			this.GroupBox4.Controls.Add(this.rIname);
			this.GroupBox4.Location = new System.Drawing.Point(8, 8);
			this.GroupBox4.Name = "GroupBox4";
			this.GroupBox4.Size = new System.Drawing.Size(219, 70);
			this.GroupBox4.TabIndex = 0;
			this.GroupBox4.TabStop = false;
			this.GroupBox4.Text = "Identify source by..";
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.bCompute);
			this.TabPage2.Controls.Add(this.cGrid);
			this.TabPage2.Controls.Add(this.GroupBox5);
			this.TabPage2.Controls.Add(this.GroupBox4);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(548, 319);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Групповая обработка";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(5, 83);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(556, 345);
			this.TabControl1.TabIndex = 22;
			// 
			// Level
			// 
			this.Level.FormattingEnabled = true;
			this.Level.Location = new System.Drawing.Point(85, 57);
			this.Level.Name = "Level";
			this.Level.Size = new System.Drawing.Size(200, 21);
			this.Level.TabIndex = 21;
			// 
			// ID
			// 
			this.ID.FormattingEnabled = true;
			this.ID.Location = new System.Drawing.Point(85, 30);
			this.ID.Name = "ID";
			this.ID.Size = new System.Drawing.Size(200, 21);
			this.ID.TabIndex = 20;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(25, 60);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(54, 13);
			this.Label3.TabIndex = 19;
			this.Label3.Text = "Level tag:";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(6, 33);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(62, 13);
			this.Label2.TabIndex = 18;
			this.Label2.Text = "Identify tag:";
			// 
			// Label14
			// 
			this.Label14.AutoSize = true;
			this.Label14.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.Location = new System.Drawing.Point(301, 27);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(120, 18);
			this.Label14.TabIndex = 27;
			this.Label14.Text = "ScriptLeecher";
			// 
			// bOpenSource
			// 
			this.bOpenSource.Location = new System.Drawing.Point(444, 27);
			this.bOpenSource.Name = "bOpenSource";
			this.bOpenSource.Size = new System.Drawing.Size(117, 22);
			this.bOpenSource.TabIndex = 17;
			this.bOpenSource.Text = "Loading";
			this.bOpenSource.UseVisualStyleBackColor = true;
			this.bOpenSource.Click += new System.EventHandler(this.bOpenSource_Click);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(42, 7);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(26, 13);
			this.Label1.TabIndex = 16;
			this.Label1.Text = "File:";
			// 
			// textSource
			// 
			this.textSource.Location = new System.Drawing.Point(85, 4);
			this.textSource.Name = "textSource";
			this.textSource.Size = new System.Drawing.Size(476, 20);
			this.textSource.TabIndex = 15;
			this.textSource.DoubleClick += new System.EventHandler(this.textSource_DoubleClick);
			// 
			// ScriptLeecher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 506);
			this.Controls.Add(this.Label13);
			this.Controls.Add(this.bLoadObraz);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.Status);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.Level);
			this.Controls.Add(this.ID);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label14);
			this.Controls.Add(this.bOpenSource);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.textSource);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ScriptLeecher";
			this.Text = "L2ScriptMaker: ScriptLeecher";
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.Status.ResumeLayout(false);
			this.Status.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cGrid)).EndInit();
			this.GroupBox5.ResumeLayout(false);
			this.GroupBox5.PerformLayout();
			this.GroupBox4.ResumeLayout(false);
			this.GroupBox4.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.TabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.Button bLoadObraz;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button bSave;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox textSave;
		internal System.Windows.Forms.ToolStripStatusLabel Status1;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
		internal System.Windows.Forms.StatusStrip Status;
		internal System.Windows.Forms.Button bCompute;
		internal System.Windows.Forms.DataGridView cGrid;
		internal System.Windows.Forms.DataGridViewComboBoxColumn sParameter;
		internal System.Windows.Forms.DataGridViewComboBoxColumn oParameter;
		internal System.Windows.Forms.DataGridViewTextBoxColumn num1;
		internal System.Windows.Forms.DataGridViewTextBoxColumn num2;
		internal System.Windows.Forms.RadioButton rInumber;
		internal System.Windows.Forms.RadioButton rIname;
		internal System.Windows.Forms.RadioButton rOnumber;
		internal System.Windows.Forms.RadioButton rOname;
		internal System.Windows.Forms.GroupBox GroupBox5;
		internal System.Windows.Forms.GroupBox GroupBox4;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.ComboBox Level;
		internal System.Windows.Forms.ComboBox ID;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.OpenFileDialog Open;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.Button bOpenSource;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox textSource;
	}
}