namespace L2ScriptMaker.Modules.Others
{
	partial class ToolIncrementer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolIncrementer));
			this.Label4 = new System.Windows.Forms.Label();
			this.ResultTextBox = new System.Windows.Forms.TextBox();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.Label3 = new System.Windows.Forms.Label();
			this.Use2RadioButton = new System.Windows.Forms.RadioButton();
			this.Use1RadioButton = new System.Windows.Forms.RadioButton();
			this.MultValueTextBox = new System.Windows.Forms.TextBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.ParamAddNameCheckBox = new System.Windows.Forms.CheckBox();
			this.StartValueTextBox = new System.Windows.Forms.TextBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.RightTextBox = new System.Windows.Forms.TextBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.LeftTextBox = new System.Windows.Forms.TextBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.Label9 = new System.Windows.Forms.Label();
			this.IncValueTextBox = new System.Windows.Forms.TextBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.EndLevelTextBox = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.StartLevelTextBox = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.ParamNameTextBox = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.QuitButton = new System.Windows.Forms.Button();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.StartButton = new System.Windows.Forms.Button();
			this.TabPage2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(124, 14);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(152, 16);
			this.Label4.TabIndex = 55;
			this.Label4.Text = "Value Incrementer Tool";
			// 
			// ResultTextBox
			// 
			this.ResultTextBox.Location = new System.Drawing.Point(6, 6);
			this.ResultTextBox.Multiline = true;
			this.ResultTextBox.Name = "ResultTextBox";
			this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.ResultTextBox.Size = new System.Drawing.Size(298, 144);
			this.ResultTextBox.TabIndex = 0;
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.ResultTextBox);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(310, 171);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Results";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(124, 30);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(126, 13);
			this.Label3.TabIndex = 56;
			this.Label3.Text = "(simple tool, for all scripts)";
			// 
			// Use2RadioButton
			// 
			this.Use2RadioButton.AutoSize = true;
			this.Use2RadioButton.Location = new System.Drawing.Point(92, 125);
			this.Use2RadioButton.Name = "Use2RadioButton";
			this.Use2RadioButton.Size = new System.Drawing.Size(87, 17);
			this.Use2RadioButton.TabIndex = 21;
			this.Use2RadioButton.Text = "Use multiplier";
			this.Use2RadioButton.UseVisualStyleBackColor = true;
			this.Use2RadioButton.CheckedChanged += new System.EventHandler(this.Use2RadioButton_CheckedChanged);
			// 
			// Use1RadioButton
			// 
			this.Use1RadioButton.AutoSize = true;
			this.Use1RadioButton.Checked = true;
			this.Use1RadioButton.Location = new System.Drawing.Point(92, 108);
			this.Use1RadioButton.Name = "Use1RadioButton";
			this.Use1RadioButton.Size = new System.Drawing.Size(93, 17);
			this.Use1RadioButton.TabIndex = 20;
			this.Use1RadioButton.TabStop = true;
			this.Use1RadioButton.Text = "Use increment";
			this.Use1RadioButton.UseVisualStyleBackColor = true;
			// 
			// MultValueTextBox
			// 
			this.MultValueTextBox.Location = new System.Drawing.Point(9, 136);
			this.MultValueTextBox.Name = "MultValueTextBox";
			this.MultValueTextBox.ReadOnly = true;
			this.MultValueTextBox.Size = new System.Drawing.Size(68, 20);
			this.MultValueTextBox.TabIndex = 18;
			this.MultValueTextBox.Text = "1";
			// 
			// Label11
			// 
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(6, 120);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(80, 13);
			this.Label11.TabIndex = 19;
			this.Label11.Text = "Multiplier value:";
			// 
			// ParamAddNameCheckBox
			// 
			this.ParamAddNameCheckBox.AutoSize = true;
			this.ParamAddNameCheckBox.Checked = true;
			this.ParamAddNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ParamAddNameCheckBox.Location = new System.Drawing.Point(118, 19);
			this.ParamAddNameCheckBox.Name = "ParamAddNameCheckBox";
			this.ParamAddNameCheckBox.Size = new System.Drawing.Size(111, 17);
			this.ParamAddNameCheckBox.TabIndex = 1;
			this.ParamAddNameCheckBox.Text = "Add level to name";
			this.ParamAddNameCheckBox.UseVisualStyleBackColor = true;
			// 
			// StartValueTextBox
			// 
			this.StartValueTextBox.Location = new System.Drawing.Point(136, 58);
			this.StartValueTextBox.Name = "StartValueTextBox";
			this.StartValueTextBox.Size = new System.Drawing.Size(55, 20);
			this.StartValueTextBox.TabIndex = 6;
			this.StartValueTextBox.Text = "1";
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.Location = new System.Drawing.Point(133, 42);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(61, 13);
			this.Label10.TabIndex = 17;
			this.Label10.Text = "Start value:";
			// 
			// RightTextBox
			// 
			this.RightTextBox.Location = new System.Drawing.Point(275, 19);
			this.RightTextBox.Name = "RightTextBox";
			this.RightTextBox.Size = new System.Drawing.Size(25, 20);
			this.RightTextBox.TabIndex = 3;
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(272, 3);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(35, 13);
			this.Label8.TabIndex = 14;
			this.Label8.Text = "Right:";
			// 
			// LeftTextBox
			// 
			this.LeftTextBox.Location = new System.Drawing.Point(241, 19);
			this.LeftTextBox.Name = "LeftTextBox";
			this.LeftTextBox.Size = new System.Drawing.Size(25, 20);
			this.LeftTextBox.TabIndex = 2;
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(127, 46);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(318, 197);
			this.TabControl1.TabIndex = 51;
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.Use2RadioButton);
			this.TabPage1.Controls.Add(this.Use1RadioButton);
			this.TabPage1.Controls.Add(this.MultValueTextBox);
			this.TabPage1.Controls.Add(this.Label11);
			this.TabPage1.Controls.Add(this.ParamAddNameCheckBox);
			this.TabPage1.Controls.Add(this.StartValueTextBox);
			this.TabPage1.Controls.Add(this.Label10);
			this.TabPage1.Controls.Add(this.RightTextBox);
			this.TabPage1.Controls.Add(this.Label8);
			this.TabPage1.Controls.Add(this.LeftTextBox);
			this.TabPage1.Controls.Add(this.Label9);
			this.TabPage1.Controls.Add(this.IncValueTextBox);
			this.TabPage1.Controls.Add(this.Label7);
			this.TabPage1.Controls.Add(this.EndLevelTextBox);
			this.TabPage1.Controls.Add(this.Label6);
			this.TabPage1.Controls.Add(this.StartLevelTextBox);
			this.TabPage1.Controls.Add(this.Label5);
			this.TabPage1.Controls.Add(this.Label2);
			this.TabPage1.Controls.Add(this.ParamNameTextBox);
			this.TabPage1.Controls.Add(this.Label1);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(310, 171);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Settings";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// Label9
			// 
			this.Label9.AutoSize = true;
			this.Label9.Location = new System.Drawing.Point(238, 3);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(28, 13);
			this.Label9.TabIndex = 12;
			this.Label9.Text = "Left:";
			// 
			// IncValueTextBox
			// 
			this.IncValueTextBox.Location = new System.Drawing.Point(9, 97);
			this.IncValueTextBox.Name = "IncValueTextBox";
			this.IncValueTextBox.Size = new System.Drawing.Size(68, 20);
			this.IncValueTextBox.TabIndex = 7;
			this.IncValueTextBox.Text = "1";
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(6, 81);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(86, 13);
			this.Label7.TabIndex = 8;
			this.Label7.Text = "Increment value:";
			// 
			// EndLevelTextBox
			// 
			this.EndLevelTextBox.Location = new System.Drawing.Point(76, 58);
			this.EndLevelTextBox.Name = "EndLevelTextBox";
			this.EndLevelTextBox.Size = new System.Drawing.Size(55, 20);
			this.EndLevelTextBox.TabIndex = 5;
			this.EndLevelTextBox.Text = "10";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(73, 42);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(54, 13);
			this.Label6.TabIndex = 6;
			this.Label6.Text = "End level:";
			// 
			// StartLevelTextBox
			// 
			this.StartLevelTextBox.Location = new System.Drawing.Point(9, 58);
			this.StartLevelTextBox.Name = "StartLevelTextBox";
			this.StartLevelTextBox.Size = new System.Drawing.Size(58, 20);
			this.StartLevelTextBox.TabIndex = 4;
			this.StartLevelTextBox.Text = "1";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(6, 42);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(57, 13);
			this.Label5.TabIndex = 4;
			this.Label5.Text = "Start level:";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(115, 3);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(117, 13);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Param additional name:";
			// 
			// ParamNameTextBox
			// 
			this.ParamNameTextBox.Location = new System.Drawing.Point(9, 19);
			this.ParamNameTextBox.Name = "ParamNameTextBox";
			this.ParamNameTextBox.Size = new System.Drawing.Size(100, 20);
			this.ParamNameTextBox.TabIndex = 0;
			this.ParamNameTextBox.Text = "param_";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(6, 3);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(71, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Param Name:";
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(28, 205);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 54;
			this.QuitButton.Text = "Quit";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(10, 14);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 156);
			this.PictureBox1.TabIndex = 52;
			this.PictureBox1.TabStop = false;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(28, 176);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 53;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// ToolIncrementer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 256);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.StartButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ToolIncrementer";
			this.Text = "Value Incrementer Tool";
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox ResultTextBox;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.RadioButton Use2RadioButton;
		internal System.Windows.Forms.RadioButton Use1RadioButton;
		internal System.Windows.Forms.TextBox MultValueTextBox;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.CheckBox ParamAddNameCheckBox;
		internal System.Windows.Forms.TextBox StartValueTextBox;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.TextBox RightTextBox;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.TextBox LeftTextBox;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.TextBox IncValueTextBox;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TextBox EndLevelTextBox;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox StartLevelTextBox;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox ParamNameTextBox;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button StartButton;
	}
}