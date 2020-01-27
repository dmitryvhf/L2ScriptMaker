namespace L2ScriptMaker.Modules.Others
{
	partial class EventDataEditorAbout
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventDataEditorAbout));
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// TextBox1
			// 
			this.TextBox1.Location = new System.Drawing.Point(3, 6);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ReadOnly = true;
			this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TextBox1.Size = new System.Drawing.Size(652, 209);
			this.TextBox1.TabIndex = 0;
			this.TextBox1.Text = resources.GetString("TextBox1.Text");
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(13, 12);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(669, 247);
			this.TabControl1.TabIndex = 3;
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.TextBox1);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(661, 221);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Russian";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.TextBox2);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(661, 221);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "English";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// TextBox2
			// 
			this.TextBox2.Location = new System.Drawing.Point(3, 6);
			this.TextBox2.Multiline = true;
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.ReadOnly = true;
			this.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TextBox2.Size = new System.Drawing.Size(652, 209);
			this.TextBox2.TabIndex = 0;
			this.TextBox2.Text = resources.GetString("TextBox2.Text");
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(306, 265);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 2;
			this.ButtonQuit.Text = "Close";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// EventDataEditorAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(694, 301);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.ButtonQuit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "EventDataEditorAbout";
			this.Text = "EventDataEditorAbout";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.TextBox TextBox2;
		internal System.Windows.Forms.Button ButtonQuit;
	}
}