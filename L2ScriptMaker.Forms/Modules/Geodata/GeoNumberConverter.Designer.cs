
namespace L2ScriptMaker.Forms.Modules.Geodata
{
	partial class GeoNumberConverter
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeoNumberConverter));
			this.btnImport = new System.Windows.Forms.Button();
			this.txbImport = new System.Windows.Forms.TextBox();
			this.txbMap = new System.Windows.Forms.TextBox();
			this.txbYMap = new System.Windows.Forms.TextBox();
			this.btnQuit = new System.Windows.Forms.Button();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txbXMap = new System.Windows.Forms.TextBox();
			this.txbY = new System.Windows.Forms.TextBox();
			this.txbX = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblX = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnImport
			// 
			this.btnImport.Location = new System.Drawing.Point(278, 54);
			this.btnImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(68, 27);
			this.btnImport.TabIndex = 82;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// txbImport
			// 
			this.txbImport.Location = new System.Drawing.Point(154, 57);
			this.txbImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txbImport.Name = "txbImport";
			this.txbImport.PlaceholderText = "XXXX;YYYYY[;ZZZZ]";
			this.txbImport.Size = new System.Drawing.Size(116, 23);
			this.txbImport.TabIndex = 81;
			// 
			// txbMap
			// 
			this.txbMap.Location = new System.Drawing.Point(171, 147);
			this.txbMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txbMap.Name = "txbMap";
			this.txbMap.ReadOnly = true;
			this.txbMap.Size = new System.Drawing.Size(99, 23);
			this.txbMap.TabIndex = 80;
			// 
			// txbYMap
			// 
			this.txbYMap.Location = new System.Drawing.Point(278, 118);
			this.txbYMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txbYMap.Name = "txbYMap";
			this.txbYMap.ReadOnly = true;
			this.txbYMap.Size = new System.Drawing.Size(46, 23);
			this.txbYMap.TabIndex = 79;
			// 
			// btnQuit
			// 
			this.btnQuit.Location = new System.Drawing.Point(23, 178);
			this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(88, 27);
			this.btnQuit.TabIndex = 78;
			this.btnQuit.Text = "Quit";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
			this.Label5.Location = new System.Drawing.Point(129, 12);
			this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(206, 16);
			this.Label5.TabIndex = 76;
			this.Label5.Text = "GeoMap calculation for position";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.Label3.Location = new System.Drawing.Point(132, 152);
			this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(31, 15);
			this.Label3.TabIndex = 75;
			this.Label3.Text = "Map";
			// 
			// txbXMap
			// 
			this.txbXMap.Location = new System.Drawing.Point(278, 89);
			this.txbXMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txbXMap.Name = "txbXMap";
			this.txbXMap.ReadOnly = true;
			this.txbXMap.Size = new System.Drawing.Size(46, 23);
			this.txbXMap.TabIndex = 74;
			// 
			// txbY
			// 
			this.txbY.Location = new System.Drawing.Point(154, 118);
			this.txbY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txbY.Name = "txbY";
			this.txbY.PlaceholderText = "0";
			this.txbY.Size = new System.Drawing.Size(116, 23);
			this.txbY.TabIndex = 73;
			// 
			// txbX
			// 
			this.txbX.Location = new System.Drawing.Point(154, 89);
			this.txbX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txbX.Name = "txbX";
			this.txbX.PlaceholderText = "0";
			this.txbX.Size = new System.Drawing.Size(116, 23);
			this.txbX.TabIndex = 72;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(110, 160);
			this.pictureBox1.TabIndex = 84;
			this.pictureBox1.TabStop = false;
			// 
			// lblX
			// 
			this.lblX.AutoSize = true;
			this.lblX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblX.Location = new System.Drawing.Point(132, 92);
			this.lblX.Name = "lblX";
			this.lblX.Size = new System.Drawing.Size(15, 15);
			this.lblX.TabIndex = 85;
			this.lblX.Text = "X";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(132, 121);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(15, 15);
			this.label1.TabIndex = 86;
			this.label1.Text = "X";
			// 
			// GeoNumberConverter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(358, 227);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblX);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.txbImport);
			this.Controls.Add(this.txbMap);
			this.Controls.Add(this.txbYMap);
			this.Controls.Add(this.btnQuit);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.txbXMap);
			this.Controls.Add(this.txbY);
			this.Controls.Add(this.txbX);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "GeoNumberConverter";
			this.Text = "GeoNumberConverter";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Button btnImport;
		internal System.Windows.Forms.TextBox txbImport;
		internal System.Windows.Forms.TextBox txbMap;
		internal System.Windows.Forms.TextBox txbYMap;
		internal System.Windows.Forms.Button btnQuit;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txbXMap;
		internal System.Windows.Forms.TextBox txbY;
		internal System.Windows.Forms.TextBox txbX;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblX;
		private System.Windows.Forms.Label label1;
	}
}