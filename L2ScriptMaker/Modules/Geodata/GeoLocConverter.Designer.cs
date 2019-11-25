namespace L2ScriptMaker.Modules.Geodata
{
	partial class GeoLocConverter
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeoLocConverter));
			this.Label6 = new System.Windows.Forms.Label();
			this.ImportLocButton = new System.Windows.Forms.Button();
			this.ImportLocTextBox = new System.Windows.Forms.TextBox();
			this.GeonameTextBox = new System.Windows.Forms.TextBox();
			this.GeonameYTextBox = new System.Windows.Forms.TextBox();
			this.QuitButton = new System.Windows.Forms.Button();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.GeonameXTextBox = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.YTextBox = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.XTextBox = new System.Windows.Forms.TextBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(119, 51);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(60, 13);
			this.Label6.TabIndex = 71;
			this.Label6.Text = "Import data";
			// 
			// ImportLocButton
			// 
			this.ImportLocButton.Location = new System.Drawing.Point(228, 65);
			this.ImportLocButton.Name = "ImportLocButton";
			this.ImportLocButton.Size = new System.Drawing.Size(75, 23);
			this.ImportLocButton.TabIndex = 70;
			this.ImportLocButton.Text = "Import";
			this.ImportLocButton.UseVisualStyleBackColor = true;
			this.ImportLocButton.Click += new System.EventHandler(this.ImportLocButton_Click);
			// 
			// ImportLocTextBox
			// 
			this.ImportLocTextBox.Location = new System.Drawing.Point(122, 67);
			this.ImportLocTextBox.Name = "ImportLocTextBox";
			this.ImportLocTextBox.Size = new System.Drawing.Size(100, 20);
			this.ImportLocTextBox.TabIndex = 69;
			this.ImportLocTextBox.Text = "XXXX,YYY,ZZZZ";
			// 
			// GeonameTextBox
			// 
			this.GeonameTextBox.Location = new System.Drawing.Point(122, 184);
			this.GeonameTextBox.Name = "GeonameTextBox";
			this.GeonameTextBox.ReadOnly = true;
			this.GeonameTextBox.Size = new System.Drawing.Size(69, 20);
			this.GeonameTextBox.TabIndex = 68;
			// 
			// GeonameYTextBox
			// 
			this.GeonameYTextBox.Location = new System.Drawing.Point(228, 145);
			this.GeonameYTextBox.Name = "GeonameYTextBox";
			this.GeonameYTextBox.ReadOnly = true;
			this.GeonameYTextBox.Size = new System.Drawing.Size(40, 20);
			this.GeonameYTextBox.TabIndex = 67;
			this.GeonameYTextBox.TextChanged += new System.EventHandler(this.GeonameXTextBox_TextChanged);
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(228, 182);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 66;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(119, 27);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(97, 13);
			this.Label4.TabIndex = 65;
			this.Label4.Text = "(support C4 scripts)";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label5.Location = new System.Drawing.Point(119, 11);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(194, 16);
			this.Label5.TabIndex = 64;
			this.Label5.Text = "Geoname finder from location";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(119, 168);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(53, 13);
			this.Label3.TabIndex = 63;
			this.Label3.Text = "Geoname";
			// 
			// GeonameXTextBox
			// 
			this.GeonameXTextBox.Location = new System.Drawing.Point(228, 106);
			this.GeonameXTextBox.Name = "GeonameXTextBox";
			this.GeonameXTextBox.ReadOnly = true;
			this.GeonameXTextBox.Size = new System.Drawing.Size(40, 20);
			this.GeonameXTextBox.TabIndex = 62;
			this.GeonameXTextBox.TextChanged += new System.EventHandler(this.GeonameXTextBox_TextChanged);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(119, 129);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(14, 13);
			this.Label2.TabIndex = 61;
			this.Label2.Text = "Y";
			// 
			// YTextBox
			// 
			this.YTextBox.Location = new System.Drawing.Point(122, 145);
			this.YTextBox.Name = "YTextBox";
			this.YTextBox.Size = new System.Drawing.Size(100, 20);
			this.YTextBox.TabIndex = 60;
			this.YTextBox.Text = "0";
			this.YTextBox.TextChanged += new System.EventHandler(this.YTextBox_TextChanged);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(119, 90);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(14, 13);
			this.Label1.TabIndex = 59;
			this.Label1.Text = "X";
			// 
			// XTextBox
			// 
			this.XTextBox.Location = new System.Drawing.Point(122, 106);
			this.XTextBox.Name = "XTextBox";
			this.XTextBox.Size = new System.Drawing.Size(100, 20);
			this.XTextBox.TabIndex = 58;
			this.XTextBox.Text = "0";
			this.XTextBox.TextChanged += new System.EventHandler(this.XTextBox_TextChanged);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(5, 11);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 158);
			this.PictureBox1.TabIndex = 57;
			this.PictureBox1.TabStop = false;
			// 
			// GeoLocConverter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 216);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.ImportLocButton);
			this.Controls.Add(this.ImportLocTextBox);
			this.Controls.Add(this.GeonameTextBox);
			this.Controls.Add(this.GeonameYTextBox);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.GeonameXTextBox);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.YTextBox);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.XTextBox);
			this.Controls.Add(this.PictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "GeoLocConverter";
			this.Text = "Geodata: Geoname from Location";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Button ImportLocButton;
		internal System.Windows.Forms.TextBox ImportLocTextBox;
		internal System.Windows.Forms.TextBox GeonameTextBox;
		internal System.Windows.Forms.TextBox GeonameYTextBox;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox GeonameXTextBox;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox YTextBox;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox XTextBox;
		internal System.Windows.Forms.PictureBox PictureBox1;
	}
}