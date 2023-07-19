namespace L2ScriptMaker.Forms.Modules
{
	partial class AboutBoxForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBoxForm));
			TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			LogoPictureBox = new System.Windows.Forms.PictureBox();
			LabelProductName = new System.Windows.Forms.Label();
			LabelVersion = new System.Windows.Forms.Label();
			LabelCopyright = new System.Windows.Forms.Label();
			LabelCompanyName = new System.Windows.Forms.Label();
			TextBoxDescription = new System.Windows.Forms.TextBox();
			OKButton = new System.Windows.Forms.Button();
			TableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
			SuspendLayout();
			// 
			// TableLayoutPanel
			// 
			TableLayoutPanel.ColumnCount = 2;
			TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
			TableLayoutPanel.Controls.Add(LogoPictureBox, 0, 0);
			TableLayoutPanel.Controls.Add(LabelProductName, 1, 0);
			TableLayoutPanel.Controls.Add(LabelVersion, 1, 1);
			TableLayoutPanel.Controls.Add(LabelCopyright, 1, 2);
			TableLayoutPanel.Controls.Add(LabelCompanyName, 1, 3);
			TableLayoutPanel.Controls.Add(TextBoxDescription, 1, 4);
			TableLayoutPanel.Controls.Add(OKButton, 1, 5);
			TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			TableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			TableLayoutPanel.Name = "TableLayoutPanel";
			TableLayoutPanel.RowCount = 6;
			TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			TableLayoutPanel.Size = new System.Drawing.Size(483, 318);
			TableLayoutPanel.TabIndex = 1;
			// 
			// LogoPictureBox
			// 
			LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			LogoPictureBox.Image = (System.Drawing.Image)resources.GetObject("LogoPictureBox.Image");
			LogoPictureBox.Location = new System.Drawing.Point(4, 3);
			LogoPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			LogoPictureBox.Name = "LogoPictureBox";
			TableLayoutPanel.SetRowSpan(LogoPictureBox, 6);
			LogoPictureBox.Size = new System.Drawing.Size(151, 312);
			LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			LogoPictureBox.TabIndex = 0;
			LogoPictureBox.TabStop = false;
			// 
			// LabelProductName
			// 
			LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
			LabelProductName.Location = new System.Drawing.Point(166, 0);
			LabelProductName.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
			LabelProductName.MaximumSize = new System.Drawing.Size(0, 20);
			LabelProductName.Name = "LabelProductName";
			LabelProductName.Size = new System.Drawing.Size(313, 20);
			LabelProductName.TabIndex = 0;
			LabelProductName.Text = "Product Name";
			LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LabelVersion
			// 
			LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
			LabelVersion.Location = new System.Drawing.Point(166, 31);
			LabelVersion.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
			LabelVersion.MaximumSize = new System.Drawing.Size(0, 20);
			LabelVersion.Name = "LabelVersion";
			LabelVersion.Size = new System.Drawing.Size(313, 20);
			LabelVersion.TabIndex = 0;
			LabelVersion.Text = "Version";
			LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LabelCopyright
			// 
			LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
			LabelCopyright.Location = new System.Drawing.Point(166, 62);
			LabelCopyright.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
			LabelCopyright.MaximumSize = new System.Drawing.Size(0, 20);
			LabelCopyright.Name = "LabelCopyright";
			LabelCopyright.Size = new System.Drawing.Size(313, 20);
			LabelCopyright.TabIndex = 0;
			LabelCopyright.Text = "Copyright";
			LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LabelCompanyName
			// 
			LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
			LabelCompanyName.Location = new System.Drawing.Point(166, 93);
			LabelCompanyName.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
			LabelCompanyName.MaximumSize = new System.Drawing.Size(0, 20);
			LabelCompanyName.Name = "LabelCompanyName";
			LabelCompanyName.Size = new System.Drawing.Size(313, 20);
			LabelCompanyName.TabIndex = 0;
			LabelCompanyName.Text = "Company Name";
			LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TextBoxDescription
			// 
			TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			TextBoxDescription.Location = new System.Drawing.Point(166, 127);
			TextBoxDescription.Margin = new System.Windows.Forms.Padding(7, 3, 4, 3);
			TextBoxDescription.Multiline = true;
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.ReadOnly = true;
			TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			TextBoxDescription.Size = new System.Drawing.Size(313, 153);
			TextBoxDescription.TabIndex = 0;
			TextBoxDescription.TabStop = false;
			TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text");
			// 
			// OKButton
			// 
			OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			OKButton.Location = new System.Drawing.Point(391, 288);
			OKButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			OKButton.Name = "OKButton";
			OKButton.Size = new System.Drawing.Size(88, 27);
			OKButton.TabIndex = 0;
			OKButton.Text = "&OK";
			OKButton.Click += OKButton_Click;
			// 
			// AboutBoxForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(483, 318);
			Controls.Add(TableLayoutPanel);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Name = "AboutBoxForm";
			Text = "AboutBox";
			Load += AboutBox_Load;
			TableLayoutPanel.ResumeLayout(false);
			TableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
			ResumeLayout(false);
		}

		#endregion

		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
		internal System.Windows.Forms.PictureBox LogoPictureBox;
		internal System.Windows.Forms.Label LabelProductName;
		internal System.Windows.Forms.Label LabelVersion;
		internal System.Windows.Forms.Label LabelCopyright;
		internal System.Windows.Forms.Label LabelCompanyName;
		internal System.Windows.Forms.TextBox TextBoxDescription;
		internal System.Windows.Forms.Button OKButton;
	}
}