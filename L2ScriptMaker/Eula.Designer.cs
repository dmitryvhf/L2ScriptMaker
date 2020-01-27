namespace L2ScriptMaker
{
	partial class Eula
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eula));
			this.DeclineButton = new System.Windows.Forms.Button();
			this.Accept2Button = new System.Windows.Forms.Button();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// DeclineButton
			// 
			this.DeclineButton.Location = new System.Drawing.Point(219, 186);
			this.DeclineButton.Name = "DeclineButton";
			this.DeclineButton.Size = new System.Drawing.Size(75, 23);
			this.DeclineButton.TabIndex = 5;
			this.DeclineButton.Text = "Decline";
			this.DeclineButton.UseVisualStyleBackColor = true;
			this.DeclineButton.Click += new System.EventHandler(this.DeclineButton_Click);
			// 
			// Accept2Button
			// 
			this.Accept2Button.Location = new System.Drawing.Point(129, 186);
			this.Accept2Button.Name = "Accept2Button";
			this.Accept2Button.Size = new System.Drawing.Size(75, 23);
			this.Accept2Button.TabIndex = 4;
			this.Accept2Button.Text = "Accept";
			this.Accept2Button.UseVisualStyleBackColor = true;
			this.Accept2Button.Click += new System.EventHandler(this.Accept2Button_Click);
			// 
			// TextBox1
			// 
			this.TextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TextBox1.Location = new System.Drawing.Point(12, 11);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ReadOnly = true;
			this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TextBox1.Size = new System.Drawing.Size(404, 169);
			this.TextBox1.TabIndex = 3;
			this.TextBox1.Text = resources.GetString("TextBox1.Text");
			// 
			// Eula
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 221);
			this.Controls.Add(this.DeclineButton);
			this.Controls.Add(this.Accept2Button);
			this.Controls.Add(this.TextBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Eula";
			this.Text = "Eula";
			this.Load += new System.EventHandler(this.Eula_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button DeclineButton;
		internal System.Windows.Forms.Button Accept2Button;
		internal System.Windows.Forms.TextBox TextBox1;
	}
}