namespace L2ScriptMaker.Modules.Others
{
	partial class SQLForms
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLForms));
			this.SQLQueryTextBox = new System.Windows.Forms.TextBox();
			this.LoadQueryButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SQLPasswordMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.IntegratedSecurityCheckBox = new System.Windows.Forms.CheckBox();
			this.QueryResultTextBox = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.CheckConnButton = new System.Windows.Forms.Button();
			this.SQLUserTextBox = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.SQLDBNameTextBox = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.SQLSrvNameTextBox = new System.Windows.Forms.TextBox();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.SaveConSetButton = new System.Windows.Forms.Button();
			this.SaveQueryButton = new System.Windows.Forms.Button();
			this.Label6 = new System.Windows.Forms.Label();
			this.SQLDataGridView = new System.Windows.Forms.DataGridView();
			this.Label1 = new System.Windows.Forms.Label();
			this.QueryValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.QueryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGridView1 = new System.Windows.Forms.DataGridView();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.LoadConSetButton = new System.Windows.Forms.Button();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage3 = new System.Windows.Forms.TabPage();
			this.QuitButton = new System.Windows.Forms.Button();
			this.QueryButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SQLDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
			this.TabPage2.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// SQLQueryTextBox
			// 
			this.SQLQueryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SQLQueryTextBox.Location = new System.Drawing.Point(6, 6);
			this.SQLQueryTextBox.Multiline = true;
			this.SQLQueryTextBox.Name = "SQLQueryTextBox";
			this.SQLQueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.SQLQueryTextBox.Size = new System.Drawing.Size(342, 180);
			this.SQLQueryTextBox.TabIndex = 0;
			this.SQLQueryTextBox.Text = "-- Lineage II ScriptMaker Query Manager\r\n-- Developed by HellFire, Russia";
			// 
			// LoadQueryButton
			// 
			this.LoadQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadQueryButton.Location = new System.Drawing.Point(500, 121);
			this.LoadQueryButton.Name = "LoadQueryButton";
			this.LoadQueryButton.Size = new System.Drawing.Size(109, 23);
			this.LoadQueryButton.TabIndex = 61;
			this.LoadQueryButton.Text = "Load Query Script";
			this.LoadQueryButton.UseVisualStyleBackColor = true;
			this.LoadQueryButton.Click += new System.EventHandler(this.LoadQueryButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(14, 14);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(112, 160);
			this.PictureBox1.TabIndex = 58;
			this.PictureBox1.TabStop = false;
			// 
			// SQLPasswordMaskedTextBox
			// 
			this.SQLPasswordMaskedTextBox.Location = new System.Drawing.Point(178, 69);
			this.SQLPasswordMaskedTextBox.Name = "SQLPasswordMaskedTextBox";
			this.SQLPasswordMaskedTextBox.PasswordChar = '*';
			this.SQLPasswordMaskedTextBox.ReadOnly = true;
			this.SQLPasswordMaskedTextBox.Size = new System.Drawing.Size(170, 20);
			this.SQLPasswordMaskedTextBox.TabIndex = 3;
			this.SQLPasswordMaskedTextBox.Text = "sa";
			// 
			// IntegratedSecurityCheckBox
			// 
			this.IntegratedSecurityCheckBox.AutoSize = true;
			this.IntegratedSecurityCheckBox.Checked = true;
			this.IntegratedSecurityCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.IntegratedSecurityCheckBox.Location = new System.Drawing.Point(178, 32);
			this.IntegratedSecurityCheckBox.Name = "IntegratedSecurityCheckBox";
			this.IntegratedSecurityCheckBox.Size = new System.Drawing.Size(170, 17);
			this.IntegratedSecurityCheckBox.TabIndex = 1;
			this.IntegratedSecurityCheckBox.Text = "Use \'Integrated Security\' mode";
			this.IntegratedSecurityCheckBox.UseVisualStyleBackColor = true;
			this.IntegratedSecurityCheckBox.CheckedChanged += new System.EventHandler(this.IntegratedSecurityCheckBox_CheckedChanged);
			// 
			// QueryResultTextBox
			// 
			this.QueryResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.QueryResultTextBox.Location = new System.Drawing.Point(9, 134);
			this.QueryResultTextBox.Multiline = true;
			this.QueryResultTextBox.Name = "QueryResultTextBox";
			this.QueryResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.QueryResultTextBox.Size = new System.Drawing.Size(339, 51);
			this.QueryResultTextBox.TabIndex = 6;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(178, 53);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(80, 13);
			this.Label4.TabIndex = 7;
			this.Label4.Text = "SQL Password:";
			// 
			// CheckConnButton
			// 
			this.CheckConnButton.Location = new System.Drawing.Point(9, 105);
			this.CheckConnButton.Name = "CheckConnButton";
			this.CheckConnButton.Size = new System.Drawing.Size(109, 23);
			this.CheckConnButton.TabIndex = 4;
			this.CheckConnButton.Text = "Check connection";
			this.CheckConnButton.UseVisualStyleBackColor = true;
			this.CheckConnButton.Click += new System.EventHandler(this.CheckConnButton_Click);
			// 
			// SQLUserTextBox
			// 
			this.SQLUserTextBox.Location = new System.Drawing.Point(9, 69);
			this.SQLUserTextBox.Name = "SQLUserTextBox";
			this.SQLUserTextBox.ReadOnly = true;
			this.SQLUserTextBox.Size = new System.Drawing.Size(163, 20);
			this.SQLUserTextBox.TabIndex = 2;
			this.SQLUserTextBox.Text = "sa";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(6, 53);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(56, 13);
			this.Label3.TabIndex = 5;
			this.Label3.Text = "SQL User:";
			// 
			// SQLDBNameTextBox
			// 
			this.SQLDBNameTextBox.Location = new System.Drawing.Point(178, 108);
			this.SQLDBNameTextBox.Name = "SQLDBNameTextBox";
			this.SQLDBNameTextBox.Size = new System.Drawing.Size(163, 20);
			this.SQLDBNameTextBox.TabIndex = 5;
			this.SQLDBNameTextBox.Text = "testdb";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(175, 92);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(56, 13);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Database:";
			// 
			// SQLSrvNameTextBox
			// 
			this.SQLSrvNameTextBox.Location = new System.Drawing.Point(9, 30);
			this.SQLSrvNameTextBox.Name = "SQLSrvNameTextBox";
			this.SQLSrvNameTextBox.Size = new System.Drawing.Size(163, 20);
			this.SQLSrvNameTextBox.TabIndex = 0;
			this.SQLSrvNameTextBox.Text = "127.0.0.1";
			// 
			// SaveConSetButton
			// 
			this.SaveConSetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveConSetButton.Location = new System.Drawing.Point(500, 63);
			this.SaveConSetButton.Name = "SaveConSetButton";
			this.SaveConSetButton.Size = new System.Drawing.Size(111, 23);
			this.SaveConSetButton.TabIndex = 66;
			this.SaveConSetButton.Text = "Save Conn Setting";
			this.SaveConSetButton.UseVisualStyleBackColor = true;
			this.SaveConSetButton.Click += new System.EventHandler(this.SaveConSetButton_Click);
			// 
			// SaveQueryButton
			// 
			this.SaveQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveQueryButton.Location = new System.Drawing.Point(500, 150);
			this.SaveQueryButton.Name = "SaveQueryButton";
			this.SaveQueryButton.Size = new System.Drawing.Size(109, 23);
			this.SaveQueryButton.TabIndex = 62;
			this.SaveQueryButton.Text = "Save Query Script";
			this.SaveQueryButton.UseVisualStyleBackColor = true;
			this.SaveQueryButton.Click += new System.EventHandler(this.SaveQueryButton_Click);
			// 
			// Label6
			// 
			this.Label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label6.Location = new System.Drawing.Point(35, 177);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(79, 54);
			this.Label6.TabIndex = 67;
			this.Label6.Text = "SQL Query\r\nTemplate\r\nManager";
			this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SQLDataGridView
			// 
			this.SQLDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SQLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.SQLDataGridView.Location = new System.Drawing.Point(14, 237);
			this.SQLDataGridView.Name = "SQLDataGridView";
			this.SQLDataGridView.Size = new System.Drawing.Size(595, 156);
			this.SQLDataGridView.TabIndex = 64;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(6, 14);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(106, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "SQL Server Address:";
			// 
			// QueryValue
			// 
			this.QueryValue.HeaderText = "Value";
			this.QueryValue.Name = "QueryValue";
			this.QueryValue.Width = 150;
			// 
			// QueryName
			// 
			this.QueryName.HeaderText = "Name";
			this.QueryName.Name = "QueryName";
			this.QueryName.Width = 120;
			// 
			// DataGridView1
			// 
			this.DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QueryName,
            this.QueryValue});
			this.DataGridView1.Location = new System.Drawing.Point(6, 6);
			this.DataGridView1.Name = "DataGridView1";
			this.DataGridView1.Size = new System.Drawing.Size(332, 132);
			this.DataGridView1.TabIndex = 1;
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.DataGridView1);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(354, 192);
			this.TabPage2.TabIndex = 2;
			this.TabPage2.Text = "Variables";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// LoadConSetButton
			// 
			this.LoadConSetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LoadConSetButton.Location = new System.Drawing.Point(500, 34);
			this.LoadConSetButton.Name = "LoadConSetButton";
			this.LoadConSetButton.Size = new System.Drawing.Size(111, 23);
			this.LoadConSetButton.TabIndex = 60;
			this.LoadConSetButton.Text = "Load Conn Setting";
			this.LoadConSetButton.UseVisualStyleBackColor = true;
			this.LoadConSetButton.Click += new System.EventHandler(this.LoadConSetButton_Click);
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.SQLPasswordMaskedTextBox);
			this.TabPage1.Controls.Add(this.IntegratedSecurityCheckBox);
			this.TabPage1.Controls.Add(this.QueryResultTextBox);
			this.TabPage1.Controls.Add(this.Label4);
			this.TabPage1.Controls.Add(this.CheckConnButton);
			this.TabPage1.Controls.Add(this.SQLUserTextBox);
			this.TabPage1.Controls.Add(this.Label3);
			this.TabPage1.Controls.Add(this.SQLDBNameTextBox);
			this.TabPage1.Controls.Add(this.Label2);
			this.TabPage1.Controls.Add(this.SQLSrvNameTextBox);
			this.TabPage1.Controls.Add(this.Label1);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(354, 192);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Connect Setting";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// TabControl1
			// 
			this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Controls.Add(this.TabPage3);
			this.TabControl1.Location = new System.Drawing.Point(132, 13);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(362, 218);
			this.TabControl1.TabIndex = 59;
			// 
			// TabPage3
			// 
			this.TabPage3.Controls.Add(this.SQLQueryTextBox);
			this.TabPage3.Location = new System.Drawing.Point(4, 22);
			this.TabPage3.Name = "TabPage3";
			this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage3.Size = new System.Drawing.Size(354, 192);
			this.TabPage3.TabIndex = 1;
			this.TabPage3.Text = "Query";
			this.TabPage3.UseVisualStyleBackColor = true;
			// 
			// QuitButton
			// 
			this.QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.QuitButton.Location = new System.Drawing.Point(500, 208);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(109, 23);
			this.QuitButton.TabIndex = 65;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// QueryButton
			// 
			this.QueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.QueryButton.Location = new System.Drawing.Point(500, 179);
			this.QueryButton.Name = "QueryButton";
			this.QueryButton.Size = new System.Drawing.Size(109, 23);
			this.QueryButton.TabIndex = 63;
			this.QueryButton.Text = "Query GO";
			this.QueryButton.UseVisualStyleBackColor = true;
			this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
			// 
			// SQLForms
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 406);
			this.Controls.Add(this.LoadQueryButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.SaveConSetButton);
			this.Controls.Add(this.SaveQueryButton);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.SQLDataGridView);
			this.Controls.Add(this.LoadConSetButton);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.QueryButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SQLForms";
			this.Text = "L2ScriptMaker: SQL Query Template Manager";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SQLDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
			this.TabPage2.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPage3.ResumeLayout(false);
			this.TabPage3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.TextBox SQLQueryTextBox;
		internal System.Windows.Forms.Button LoadQueryButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.MaskedTextBox SQLPasswordMaskedTextBox;
		internal System.Windows.Forms.CheckBox IntegratedSecurityCheckBox;
		internal System.Windows.Forms.TextBox QueryResultTextBox;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Button CheckConnButton;
		internal System.Windows.Forms.TextBox SQLUserTextBox;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox SQLDBNameTextBox;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox SQLSrvNameTextBox;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog;
		internal System.Windows.Forms.Button SaveConSetButton;
		internal System.Windows.Forms.Button SaveQueryButton;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.DataGridView SQLDataGridView;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.DataGridViewTextBoxColumn QueryValue;
		internal System.Windows.Forms.DataGridViewTextBoxColumn QueryName;
		internal System.Windows.Forms.DataGridView DataGridView1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Button LoadConSetButton;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage3;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button QueryButton;
	}
}