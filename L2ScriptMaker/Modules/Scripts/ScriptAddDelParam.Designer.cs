namespace L2ScriptMaker.Modules.Scripts
{
	partial class ScriptAddDelParam
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptAddDelParam));
			this.CheckBoxAddParamOverwrite = new System.Windows.Forms.CheckBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.TextBoxAddParamValue = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ButtonDelParamGo = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.ComboBoxDelMode = new System.Windows.Forms.ComboBox();
			this.ButtonAddParamGo = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.TextBoxAddParam = new System.Windows.Forms.TextBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.ButtonStructLoad = new System.Windows.Forms.Button();
			this.ComboBoxEditMode = new System.Windows.Forms.ComboBox();
			this.ComboBoxParamList = new System.Windows.Forms.ComboBox();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.Label1 = new System.Windows.Forms.Label();
			this.ButtonQuit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// CheckBoxAddParamOverwrite
			// 
			this.CheckBoxAddParamOverwrite.AutoSize = true;
			this.CheckBoxAddParamOverwrite.Location = new System.Drawing.Point(283, 135);
			this.CheckBoxAddParamOverwrite.Name = "CheckBoxAddParamOverwrite";
			this.CheckBoxAddParamOverwrite.Size = new System.Drawing.Size(147, 17);
			this.CheckBoxAddParamOverwrite.TabIndex = 36;
			this.CheckBoxAddParamOverwrite.Text = "Overwrite value to default";
			this.CheckBoxAddParamOverwrite.UseVisualStyleBackColor = true;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(283, 93);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(104, 13);
			this.Label5.TabIndex = 35;
			this.Label5.Text = "Param default value:";
			// 
			// TextBoxAddParamValue
			// 
			this.TextBoxAddParamValue.Location = new System.Drawing.Point(283, 109);
			this.TextBoxAddParamValue.Name = "TextBoxAddParamValue";
			this.TextBoxAddParamValue.Size = new System.Drawing.Size(168, 20);
			this.TextBoxAddParamValue.TabIndex = 34;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(283, 54);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(93, 13);
			this.Label4.TabIndex = 33;
			this.Label4.Text = "New param name:";
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(138, 192);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(313, 23);
			this.ProgressBar.TabIndex = 32;
			// 
			// ButtonDelParamGo
			// 
			this.ButtonDelParamGo.Location = new System.Drawing.Point(138, 152);
			this.ButtonDelParamGo.Name = "ButtonDelParamGo";
			this.ButtonDelParamGo.Size = new System.Drawing.Size(100, 23);
			this.ButtonDelParamGo.TabIndex = 31;
			this.ButtonDelParamGo.Text = "Delete parameter";
			this.ButtonDelParamGo.UseVisualStyleBackColor = true;
			this.ButtonDelParamGo.Click += new System.EventHandler(this.ButtonDelParamGo_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(138, 107);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(83, 13);
			this.Label3.TabIndex = 30;
			this.Label3.Text = "Delete Mode:";
			// 
			// ComboBoxDelMode
			// 
			this.ComboBoxDelMode.AutoCompleteCustomSource.AddRange(new string[] {
            "Delete param",
            "Delete value"});
			this.ComboBoxDelMode.FormattingEnabled = true;
			this.ComboBoxDelMode.Items.AddRange(new object[] {
            "Delete value",
            "Delete param"});
			this.ComboBoxDelMode.Location = new System.Drawing.Point(138, 125);
			this.ComboBoxDelMode.Name = "ComboBoxDelMode";
			this.ComboBoxDelMode.Size = new System.Drawing.Size(121, 21);
			this.ComboBoxDelMode.TabIndex = 29;
			// 
			// ButtonAddParamGo
			// 
			this.ButtonAddParamGo.Location = new System.Drawing.Point(283, 152);
			this.ButtonAddParamGo.Name = "ButtonAddParamGo";
			this.ButtonAddParamGo.Size = new System.Drawing.Size(100, 23);
			this.ButtonAddParamGo.TabIndex = 28;
			this.ButtonAddParamGo.Text = "Add parameter";
			this.ButtonAddParamGo.UseVisualStyleBackColor = true;
			this.ButtonAddParamGo.Click += new System.EventHandler(this.ButtonAddParamGo_Click);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(283, 12);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(68, 13);
			this.Label2.TabIndex = 27;
			this.Label2.Text = "Add Mode:";
			// 
			// TextBoxAddParam
			// 
			this.TextBoxAddParam.Location = new System.Drawing.Point(283, 70);
			this.TextBoxAddParam.Name = "TextBoxAddParam";
			this.TextBoxAddParam.Size = new System.Drawing.Size(168, 20);
			this.TextBoxAddParam.TabIndex = 25;
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(13, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(108, 158);
			this.PictureBox1.TabIndex = 24;
			this.PictureBox1.TabStop = false;
			// 
			// ButtonStructLoad
			// 
			this.ButtonStructLoad.Location = new System.Drawing.Point(138, 12);
			this.ButtonStructLoad.Name = "ButtonStructLoad";
			this.ButtonStructLoad.Size = new System.Drawing.Size(100, 23);
			this.ButtonStructLoad.TabIndex = 23;
			this.ButtonStructLoad.Text = "Structure load";
			this.ButtonStructLoad.UseVisualStyleBackColor = true;
			this.ButtonStructLoad.Click += new System.EventHandler(this.ButtonStructLoad_Click);
			// 
			// ComboBoxEditMode
			// 
			this.ComboBoxEditMode.AutoCompleteCustomSource.AddRange(new string[] {
            "Before",
            "After"});
			this.ComboBoxEditMode.FormattingEnabled = true;
			this.ComboBoxEditMode.Items.AddRange(new object[] {
            "Before",
            "After"});
			this.ComboBoxEditMode.Location = new System.Drawing.Point(283, 30);
			this.ComboBoxEditMode.Name = "ComboBoxEditMode";
			this.ComboBoxEditMode.Size = new System.Drawing.Size(121, 21);
			this.ComboBoxEditMode.TabIndex = 22;
			this.ComboBoxEditMode.Text = "Before";
			// 
			// ComboBoxParamList
			// 
			this.ComboBoxParamList.FormattingEnabled = true;
			this.ComboBoxParamList.Location = new System.Drawing.Point(138, 57);
			this.ComboBoxParamList.Name = "ComboBoxParamList";
			this.ComboBoxParamList.Size = new System.Drawing.Size(121, 21);
			this.ComboBoxParamList.TabIndex = 21;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(138, 38);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(73, 13);
			this.Label1.TabIndex = 26;
			this.Label1.Text = "Parameter list:";
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(13, 192);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(100, 23);
			this.ButtonQuit.TabIndex = 20;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ScriptAddDelParam
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 226);
			this.Controls.Add(this.CheckBoxAddParamOverwrite);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.TextBoxAddParamValue);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.ButtonDelParamGo);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.ComboBoxDelMode);
			this.Controls.Add(this.ButtonAddParamGo);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.TextBoxAddParam);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.ButtonStructLoad);
			this.Controls.Add(this.ComboBoxEditMode);
			this.Controls.Add(this.ComboBoxParamList);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.ButtonQuit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ScriptAddDelParam";
			this.Text = "Scripts: Add/Delete parameters in scripts";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.CheckBox CheckBoxAddParamOverwrite;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox TextBoxAddParamValue;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.ProgressBar ProgressBar;
		internal System.Windows.Forms.Button ButtonDelParamGo;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.ComboBox ComboBoxDelMode;
		internal System.Windows.Forms.Button ButtonAddParamGo;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox TextBoxAddParam;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button ButtonStructLoad;
		internal System.Windows.Forms.ComboBox ComboBoxEditMode;
		internal System.Windows.Forms.ComboBox ComboBoxParamList;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button ButtonQuit;
	}
}