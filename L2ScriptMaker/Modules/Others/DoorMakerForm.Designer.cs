namespace L2ScriptMaker.Modules.Others
{
	partial class DoorMakerForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoorMakerForm));
			this.Label16 = new System.Windows.Forms.Label();
			this.Label17 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.KnowType = new System.Windows.Forms.ComboBox();
			this.Label14 = new System.Windows.Forms.Label();
			this.MDef = new System.Windows.Forms.TextBox();
			this.Label13 = new System.Windows.Forms.Label();
			this.PDef = new System.Windows.Forms.TextBox();
			this.Label12 = new System.Windows.Forms.Label();
			this.HP = new System.Windows.Forms.TextBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.Heights = new System.Windows.Forms.TextBox();
			this.OpenMetod = new System.Windows.Forms.ComboBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.StatObjID = new System.Windows.Forms.TextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.DoorType = new System.Windows.Forms.ComboBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.DoorName = new System.Windows.Forms.TextBox();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.BestZBox = new System.Windows.Forms.CheckBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.AutoClearBox = new System.Windows.Forms.CheckBox();
			this.ButtonClear = new System.Windows.Forms.Button();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.TextBoxZS = new System.Windows.Forms.TextBox();
			this.TextBoxYS = new System.Windows.Forms.TextBox();
			this.TextBoxXS = new System.Windows.Forms.TextBox();
			this.TextBoxFinal = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.TextBoxZ = new System.Windows.Forms.TextBox();
			this.TextBoxY = new System.Windows.Forms.TextBox();
			this.TextBoxX = new System.Windows.Forms.TextBox();
			this.QuitButton = new System.Windows.Forms.Button();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.StartButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label16
			// 
			this.Label16.AutoSize = true;
			this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label16.Location = new System.Drawing.Point(11, 286);
			this.Label16.Name = "Label16";
			this.Label16.Size = new System.Drawing.Size(97, 13);
			this.Label16.TabIndex = 100;
			this.Label16.Text = "(support C4 scripts)";
			// 
			// Label17
			// 
			this.Label17.AutoSize = true;
			this.Label17.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label17.Location = new System.Drawing.Point(11, 270);
			this.Label17.Name = "Label17";
			this.Label17.Size = new System.Drawing.Size(108, 16);
			this.Label17.TabIndex = 99;
			this.Label17.Text = "DoorData Maker";
			// 
			// Label15
			// 
			this.Label15.AutoSize = true;
			this.Label15.Location = new System.Drawing.Point(471, 12);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(58, 13);
			this.Label15.TabIndex = 98;
			this.Label15.Text = "KnowType";
			// 
			// KnowType
			// 
			this.KnowType.FormattingEnabled = true;
			this.KnowType.Items.AddRange(new object[] {
            "Aden Walls",
            "Aden Outer Doors",
            "Aden Inner Doors",
            "Aden Castle Gates",
            "Castle Walls",
            "Castle Outer Doors",
            "Castle Inner Doors",
            "Castle Gate (Station)",
            "Lattice",
            "Kruma Door",
            "Bandit Stronghold Door",
            "City and Partisan Doors"});
			this.KnowType.Location = new System.Drawing.Point(472, 27);
			this.KnowType.Name = "KnowType";
			this.KnowType.Size = new System.Drawing.Size(121, 21);
			this.KnowType.TabIndex = 69;
			this.KnowType.TextChanged += new System.EventHandler(this.KnowType_TextChanged);
			// 
			// Label14
			// 
			this.Label14.AutoSize = true;
			this.Label14.Location = new System.Drawing.Point(556, 139);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(46, 26);
			this.Label14.TabIndex = 97;
			this.Label14.Text = "Magical\r\ndefence";
			// 
			// MDef
			// 
			this.MDef.Location = new System.Drawing.Point(472, 139);
			this.MDef.Name = "MDef";
			this.MDef.Size = new System.Drawing.Size(78, 20);
			this.MDef.TabIndex = 74;
			// 
			// Label13
			// 
			this.Label13.AutoSize = true;
			this.Label13.Location = new System.Drawing.Point(556, 106);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(46, 26);
			this.Label13.TabIndex = 96;
			this.Label13.Text = "Physical\r\ndefence";
			// 
			// PDef
			// 
			this.PDef.Location = new System.Drawing.Point(472, 112);
			this.PDef.Name = "PDef";
			this.PDef.Size = new System.Drawing.Size(78, 20);
			this.PDef.TabIndex = 72;
			// 
			// Label12
			// 
			this.Label12.AutoSize = true;
			this.Label12.Location = new System.Drawing.Point(556, 85);
			this.Label12.Name = "Label12";
			this.Label12.Size = new System.Drawing.Size(22, 13);
			this.Label12.TabIndex = 95;
			this.Label12.Text = "HP";
			// 
			// HP
			// 
			this.HP.Location = new System.Drawing.Point(472, 85);
			this.HP.Name = "HP";
			this.HP.Size = new System.Drawing.Size(78, 20);
			this.HP.TabIndex = 71;
			// 
			// Label11
			// 
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(556, 59);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(38, 13);
			this.Label11.TabIndex = 94;
			this.Label11.Text = "Height";
			// 
			// Heights
			// 
			this.Heights.Location = new System.Drawing.Point(472, 56);
			this.Heights.Name = "Heights";
			this.Heights.Size = new System.Drawing.Size(78, 20);
			this.Heights.TabIndex = 70;
			// 
			// OpenMetod
			// 
			this.OpenMetod.FormattingEnabled = true;
			this.OpenMetod.Items.AddRange(new object[] {
            "by_npc",
            "by_skill",
            "by_click",
            "by_time"});
			this.OpenMetod.Location = new System.Drawing.Point(296, 72);
			this.OpenMetod.Name = "OpenMetod";
			this.OpenMetod.Size = new System.Drawing.Size(121, 21);
			this.OpenMetod.TabIndex = 62;
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.Location = new System.Drawing.Point(295, 56);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(63, 13);
			this.Label10.TabIndex = 91;
			this.Label10.Text = "OpenMetod";
			// 
			// StatObjID
			// 
			this.StatObjID.Location = new System.Drawing.Point(102, 70);
			this.StatObjID.Name = "StatObjID";
			this.StatObjID.Size = new System.Drawing.Size(100, 20);
			this.StatObjID.TabIndex = 61;
			// 
			// Label9
			// 
			this.Label9.AutoSize = true;
			this.Label9.Location = new System.Drawing.Point(102, 54);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(76, 13);
			this.Label9.TabIndex = 81;
			this.Label9.Text = "StaticObjectID";
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(295, 11);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(54, 13);
			this.Label8.TabIndex = 90;
			this.Label8.Text = "DoorType";
			// 
			// DoorType
			// 
			this.DoorType.FormattingEnabled = true;
			this.DoorType.Items.AddRange(new object[] {
            "normal_type",
            "wall_type",
            "parent_type",
            "child_type"});
			this.DoorType.Location = new System.Drawing.Point(296, 27);
			this.DoorType.Name = "DoorType";
			this.DoorType.Size = new System.Drawing.Size(121, 21);
			this.DoorType.TabIndex = 60;
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(101, 12);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(58, 13);
			this.Label7.TabIndex = 83;
			this.Label7.Text = "DoorName";
			// 
			// DoorName
			// 
			this.DoorName.Location = new System.Drawing.Point(102, 28);
			this.DoorName.Name = "DoorName";
			this.DoorName.Size = new System.Drawing.Size(178, 20);
			this.DoorName.TabIndex = 59;
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(7, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(88, 196);
			this.PictureBox1.TabIndex = 89;
			this.PictureBox1.TabStop = false;
			// 
			// BestZBox
			// 
			this.BestZBox.AutoSize = true;
			this.BestZBox.Location = new System.Drawing.Point(351, 150);
			this.BestZBox.Name = "BestZBox";
			this.BestZBox.Size = new System.Drawing.Size(95, 17);
			this.BestZBox.TabIndex = 88;
			this.BestZBox.Text = "No best-Z shift";
			this.ToolTip1.SetToolTip(this.BestZBox, "No do best Z location.\r\n\"Pos\" will have the same level,\r\nas \"Range\".");
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(167, 257);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 87;
			this.Button1.Text = "HowToDo";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// AutoClearBox
			// 
			this.AutoClearBox.AutoSize = true;
			this.AutoClearBox.Location = new System.Drawing.Point(328, 261);
			this.AutoClearBox.Name = "AutoClearBox";
			this.AutoClearBox.Size = new System.Drawing.Size(75, 17);
			this.AutoClearBox.TabIndex = 77;
			this.AutoClearBox.Text = "Auto Clear";
			this.ToolTip1.SetToolTip(this.AutoClearBox, "Check it for automatic clearing a window\r\nof a conclusion of the information.");
			// 
			// ButtonClear
			// 
			this.ButtonClear.Location = new System.Drawing.Point(248, 286);
			this.ButtonClear.Name = "ButtonClear";
			this.ButtonClear.Size = new System.Drawing.Size(75, 23);
			this.ButtonClear.TabIndex = 86;
			this.ButtonClear.Text = "Clear";
			this.ToolTip1.SetToolTip(this.ButtonClear, "Press it for clearing output\r\nwindow for new position info.");
			this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(308, 127);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(36, 13);
			this.Label5.TabIndex = 85;
			this.Label5.Text = "Y-shift";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(186, 128);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(36, 13);
			this.Label6.TabIndex = 84;
			this.Label6.Text = "X-shift";
			// 
			// TextBoxZS
			// 
			this.TextBoxZS.Location = new System.Drawing.Point(351, 128);
			this.TextBoxZS.Name = "TextBoxZS";
			this.TextBoxZS.Size = new System.Drawing.Size(78, 20);
			this.TextBoxZS.TabIndex = 68;
			// 
			// TextBoxYS
			// 
			this.TextBoxYS.Location = new System.Drawing.Point(225, 128);
			this.TextBoxYS.Name = "TextBoxYS";
			this.TextBoxYS.Size = new System.Drawing.Size(78, 20);
			this.TextBoxYS.TabIndex = 67;
			// 
			// TextBoxXS
			// 
			this.TextBoxXS.Location = new System.Drawing.Point(102, 128);
			this.TextBoxXS.Name = "TextBoxXS";
			this.TextBoxXS.Size = new System.Drawing.Size(78, 20);
			this.TextBoxXS.TabIndex = 66;
			// 
			// TextBoxFinal
			// 
			this.TextBoxFinal.Location = new System.Drawing.Point(103, 173);
			this.TextBoxFinal.Multiline = true;
			this.TextBoxFinal.Name = "TextBoxFinal";
			this.TextBoxFinal.ReadOnly = true;
			this.TextBoxFinal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBoxFinal.Size = new System.Drawing.Size(493, 80);
			this.TextBoxFinal.TabIndex = 79;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(432, 128);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(38, 13);
			this.Label4.TabIndex = 82;
			this.Label4.Text = "Z-Shift";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(432, 104);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(14, 13);
			this.Label3.TabIndex = 78;
			this.Label3.Text = "Z";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(309, 104);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(14, 13);
			this.Label2.TabIndex = 75;
			this.Label2.Text = "Y";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(186, 103);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(14, 13);
			this.Label1.TabIndex = 73;
			this.Label1.Text = "X";
			// 
			// TextBoxZ
			// 
			this.TextBoxZ.Location = new System.Drawing.Point(351, 104);
			this.TextBoxZ.Name = "TextBoxZ";
			this.TextBoxZ.Size = new System.Drawing.Size(78, 20);
			this.TextBoxZ.TabIndex = 65;
			// 
			// TextBoxY
			// 
			this.TextBoxY.Location = new System.Drawing.Point(225, 103);
			this.TextBoxY.Name = "TextBoxY";
			this.TextBoxY.Size = new System.Drawing.Size(78, 20);
			this.TextBoxY.TabIndex = 64;
			// 
			// TextBoxX
			// 
			this.TextBoxX.Location = new System.Drawing.Point(102, 103);
			this.TextBoxX.Name = "TextBoxX";
			this.TextBoxX.Size = new System.Drawing.Size(78, 20);
			this.TextBoxX.TabIndex = 63;
			// 
			// QuitButton
			// 
			this.QuitButton.Location = new System.Drawing.Point(521, 257);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 80;
			this.QuitButton.Text = "Quit";
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(248, 257);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 76;
			this.StartButton.Text = "Start";
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// DoorMakerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 321);
			this.Controls.Add(this.Label16);
			this.Controls.Add(this.Label17);
			this.Controls.Add(this.Label15);
			this.Controls.Add(this.KnowType);
			this.Controls.Add(this.Label14);
			this.Controls.Add(this.MDef);
			this.Controls.Add(this.Label13);
			this.Controls.Add(this.PDef);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this.HP);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.Heights);
			this.Controls.Add(this.OpenMetod);
			this.Controls.Add(this.Label10);
			this.Controls.Add(this.StatObjID);
			this.Controls.Add(this.Label9);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.DoorType);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.DoorName);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.BestZBox);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.AutoClearBox);
			this.Controls.Add(this.ButtonClear);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.TextBoxZS);
			this.Controls.Add(this.TextBoxYS);
			this.Controls.Add(this.TextBoxXS);
			this.Controls.Add(this.TextBoxFinal);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.TextBoxZ);
			this.Controls.Add(this.TextBoxY);
			this.Controls.Add(this.TextBoxX);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.StartButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DoorMakerForm";
			this.Text = "LineageII RangeMaker";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		internal System.Windows.Forms.Label Label16;
		internal System.Windows.Forms.Label Label17;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.ComboBox KnowType;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.TextBox MDef;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.TextBox PDef;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.TextBox HP;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.TextBox Heights;
		internal System.Windows.Forms.ComboBox OpenMetod;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.TextBox StatObjID;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.ComboBox DoorType;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TextBox DoorName;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.CheckBox BestZBox;
		internal System.Windows.Forms.ToolTip ToolTip1;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.CheckBox AutoClearBox;
		internal System.Windows.Forms.Button ButtonClear;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox TextBoxZS;
		internal System.Windows.Forms.TextBox TextBoxYS;
		internal System.Windows.Forms.TextBox TextBoxXS;
		internal System.Windows.Forms.TextBox TextBoxFinal;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox TextBoxZ;
		internal System.Windows.Forms.TextBox TextBoxY;
		internal System.Windows.Forms.TextBox TextBoxX;
		internal System.Windows.Forms.Button QuitButton;
		internal System.Windows.Forms.Button StartButton;
	}
}