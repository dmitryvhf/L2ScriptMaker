namespace L2ScriptMaker.Forms.Modules.AI
{
	partial class AiBuyselllistEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AiBuyselllistEditor));
			this.ButtonImport = new System.Windows.Forms.Button();
			this.DataGridView = new System.Windows.Forms.DataGridView();
			this.ItemList = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.CityTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabDataPage = new System.Windows.Forms.TabPage();
			this.TabResultPage = new System.Windows.Forms.TabPage();
			this.BuySellListBox = new System.Windows.Forms.TextBox();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.BuySellListTextBox = new System.Windows.Forms.TextBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
			this.TabControl1.SuspendLayout();
			this.TabDataPage.SuspendLayout();
			this.TabResultPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// ButtonImport
			// 
			this.ButtonImport.Location = new System.Drawing.Point(29, 196);
			this.ButtonImport.Name = "ButtonImport";
			this.ButtonImport.Size = new System.Drawing.Size(75, 23);
			this.ButtonImport.TabIndex = 61;
			this.ButtonImport.Text = "Import";
			this.ButtonImport.UseVisualStyleBackColor = true;
			this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
			// 
			// DataGridView
			// 
			this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemList,
            this.CityTax});
			this.DataGridView.Location = new System.Drawing.Point(9, 6);
			this.DataGridView.Name = "DataGridView";
			this.DataGridView.Size = new System.Drawing.Size(296, 219);
			this.DataGridView.TabIndex = 0;
			this.DataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellEndEdit);
			// 
			// ItemList
			// 
			this.ItemList.HeaderText = "ItemList";
			this.ItemList.Name = "ItemList";
			this.ItemList.Width = 200;
			// 
			// CityTax
			// 
			this.CityTax.HeaderText = "CityTax";
			this.CityTax.Name = "CityTax";
			this.CityTax.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.CityTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.CityTax.Width = 50;
			// 
			// ButtonStart
			// 
			this.ButtonStart.Location = new System.Drawing.Point(29, 225);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(75, 23);
			this.ButtonStart.TabIndex = 58;
			this.ButtonStart.Text = "Generate";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabDataPage);
			this.TabControl1.Controls.Add(this.TabResultPage);
			this.TabControl1.Location = new System.Drawing.Point(128, 54);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(316, 256);
			this.TabControl1.TabIndex = 60;
			// 
			// TabDataPage
			// 
			this.TabDataPage.Controls.Add(this.DataGridView);
			this.TabDataPage.Location = new System.Drawing.Point(4, 22);
			this.TabDataPage.Name = "TabDataPage";
			this.TabDataPage.Padding = new System.Windows.Forms.Padding(3);
			this.TabDataPage.Size = new System.Drawing.Size(308, 230);
			this.TabDataPage.TabIndex = 0;
			this.TabDataPage.Text = "Data page";
			this.TabDataPage.UseVisualStyleBackColor = true;
			// 
			// TabResultPage
			// 
			this.TabResultPage.Controls.Add(this.BuySellListBox);
			this.TabResultPage.Location = new System.Drawing.Point(4, 22);
			this.TabResultPage.Name = "TabResultPage";
			this.TabResultPage.Padding = new System.Windows.Forms.Padding(3);
			this.TabResultPage.Size = new System.Drawing.Size(308, 230);
			this.TabResultPage.TabIndex = 1;
			this.TabResultPage.Text = "Result page";
			this.TabResultPage.UseVisualStyleBackColor = true;
			// 
			// BuySellListBox
			// 
			this.BuySellListBox.Location = new System.Drawing.Point(6, 6);
			this.BuySellListBox.Multiline = true;
			this.BuySellListBox.Name = "BuySellListBox";
			this.BuySellListBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.BuySellListBox.Size = new System.Drawing.Size(296, 218);
			this.BuySellListBox.TabIndex = 0;
			this.BuySellListBox.Text = "buyselllist_begin SellList0\r\n\t{1829; 10; 1.000000; 5}\r\n\t{5169; 10; 1.000000; 5}\r\n" +
    "buyselllist_end";
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(29, 254);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 59;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(295, 28);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 66;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(295, 12);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(144, 16);
			this.Label4.TabIndex = 65;
			this.Label4.Text = "AI.obj shop list maker";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(129, 12);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(90, 13);
			this.Label1.TabIndex = 64;
			this.Label1.Text = "BuySellList name:";
			// 
			// BuySellListTextBox
			// 
			this.BuySellListTextBox.Location = new System.Drawing.Point(132, 28);
			this.BuySellListTextBox.Name = "BuySellListTextBox";
			this.BuySellListTextBox.Size = new System.Drawing.Size(151, 20);
			this.BuySellListTextBox.TabIndex = 63;
			this.BuySellListTextBox.Text = "SellList0";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(110, 159);
			this.PictureBox1.TabIndex = 62;
			this.PictureBox1.TabStop = false;
			// 
			// AiBuyselllistEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 316);
			this.Controls.Add(this.ButtonImport);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.BuySellListTextBox);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AiBuyselllistEditor";
			this.Text = "AI.obj shop list maker";
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
			this.TabControl1.ResumeLayout(false);
			this.TabDataPage.ResumeLayout(false);
			this.TabResultPage.ResumeLayout(false);
			this.TabResultPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button ButtonImport;
		internal System.Windows.Forms.DataGridView DataGridView;
		internal System.Windows.Forms.DataGridViewComboBoxColumn ItemList;
		internal System.Windows.Forms.DataGridViewTextBoxColumn CityTax;
		internal System.Windows.Forms.Button ButtonStart;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabDataPage;
		internal System.Windows.Forms.TabPage TabResultPage;
		internal System.Windows.Forms.TextBox BuySellListBox;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox BuySellListTextBox;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}