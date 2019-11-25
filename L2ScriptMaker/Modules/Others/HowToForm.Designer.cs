namespace L2ScriptMaker.Modules.Others
{
	partial class HowToForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HowToForm));
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.InitialImage = null;
			this.PictureBox1.Location = new System.Drawing.Point(40, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(212, 232);
			this.PictureBox1.TabIndex = 3;
			this.PictureBox1.TabStop = false;
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(14, 261);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(267, 23);
			this.Button1.TabIndex = 2;
			this.Button1.Text = "Yes. Understand. I\'m no fool";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// HowToForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(294, 296);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.Button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "HowToForm";
			this.Text = "HowTo";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button Button1;
	}
}