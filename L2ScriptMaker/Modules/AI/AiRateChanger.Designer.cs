namespace L2ScriptMaker.Modules.AI
{
	partial class AiRateChanger
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AiRateChanger));
			this.Label4 = new System.Windows.Forms.Label();
			this.QuestListBox = new System.Windows.Forms.CheckedListBox();
			this.QuestDeSelectButton = new System.Windows.Forms.Button();
			this.QuestListCheckBox = new System.Windows.Forms.CheckBox();
			this.QuestSelectButton = new System.Windows.Forms.Button();
			this.TextBoxAdena = new System.Windows.Forms.TextBox();
			this.TextBoxExp = new System.Windows.Forms.TextBox();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.DeselectAllButton = new System.Windows.Forms.Button();
			this.SelectAllButton = new System.Windows.Forms.Button();
			this.TextBoxItem = new System.Windows.Forms.TextBox();
			this.CheckBoxItem = new System.Windows.Forms.CheckBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.TextBoxSP = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.CheckBoxAdena = new System.Windows.Forms.CheckBox();
			this.CheckBoxExp = new System.Windows.Forms.CheckBox();
			this.CheckBoxSP = new System.Windows.Forms.CheckBox();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.ButtonQuest = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.Label3 = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.ButtonQuit = new System.Windows.Forms.Button();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label4.Location = new System.Drawing.Point(370, 12);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(132, 16);
			this.Label4.TabIndex = 60;
			this.Label4.Text = "AI.obj Rate Changer";
			// 
			// QuestListBox
			// 
			this.QuestListBox.Enabled = false;
			this.QuestListBox.FormattingEnabled = true;
			this.QuestListBox.Location = new System.Drawing.Point(3, 38);
			this.QuestListBox.Name = "QuestListBox";
			this.QuestListBox.Size = new System.Drawing.Size(351, 124);
			this.QuestListBox.TabIndex = 56;
			// 
			// QuestDeSelectButton
			// 
			this.QuestDeSelectButton.Location = new System.Drawing.Point(279, 6);
			this.QuestDeSelectButton.Name = "QuestDeSelectButton";
			this.QuestDeSelectButton.Size = new System.Drawing.Size(75, 23);
			this.QuestDeSelectButton.TabIndex = 22;
			this.QuestDeSelectButton.Text = "DeSelect All";
			this.QuestDeSelectButton.UseVisualStyleBackColor = true;
			this.QuestDeSelectButton.Click += new System.EventHandler(this.QuestDeSelectButton_Click);
			// 
			// QuestListCheckBox
			// 
			this.QuestListCheckBox.AutoSize = true;
			this.QuestListCheckBox.Location = new System.Drawing.Point(6, 6);
			this.QuestListCheckBox.Name = "QuestListCheckBox";
			this.QuestListCheckBox.Size = new System.Drawing.Size(149, 17);
			this.QuestListCheckBox.TabIndex = 55;
			this.QuestListCheckBox.Text = "Work only with this quests";
			this.QuestListCheckBox.UseVisualStyleBackColor = true;
			this.QuestListCheckBox.CheckedChanged += new System.EventHandler(this.QuestListCheckBox_CheckedChanged);
			// 
			// QuestSelectButton
			// 
			this.QuestSelectButton.Location = new System.Drawing.Point(198, 6);
			this.QuestSelectButton.Name = "QuestSelectButton";
			this.QuestSelectButton.Size = new System.Drawing.Size(75, 23);
			this.QuestSelectButton.TabIndex = 21;
			this.QuestSelectButton.Text = "Select All";
			this.QuestSelectButton.UseVisualStyleBackColor = true;
			this.QuestSelectButton.Click += new System.EventHandler(this.QuestSelectButton_Click);
			// 
			// TextBoxAdena
			// 
			this.TextBoxAdena.Enabled = false;
			this.TextBoxAdena.Location = new System.Drawing.Point(96, 20);
			this.TextBoxAdena.Name = "TextBoxAdena";
			this.TextBoxAdena.Size = new System.Drawing.Size(37, 20);
			this.TextBoxAdena.TabIndex = 10;
			this.TextBoxAdena.Text = "1";
			this.TextBoxAdena.Leave += new System.EventHandler(this.TextBoxAdena_Leave);
			// 
			// TextBoxExp
			// 
			this.TextBoxExp.Enabled = false;
			this.TextBoxExp.Location = new System.Drawing.Point(96, 46);
			this.TextBoxExp.Name = "TextBoxExp";
			this.TextBoxExp.Size = new System.Drawing.Size(37, 20);
			this.TextBoxExp.TabIndex = 11;
			this.TextBoxExp.Text = "1";
			this.TextBoxExp.Leave += new System.EventHandler(this.TextBoxExp_Leave);
			// 
			// TabPage1
			// 
			this.TabPage1.Controls.Add(this.CheckedListBox);
			this.TabPage1.Controls.Add(this.DeselectAllButton);
			this.TabPage1.Controls.Add(this.SelectAllButton);
			this.TabPage1.Controls.Add(this.TextBoxItem);
			this.TabPage1.Controls.Add(this.TextBoxAdena);
			this.TabPage1.Controls.Add(this.CheckBoxItem);
			this.TabPage1.Controls.Add(this.TextBoxExp);
			this.TabPage1.Controls.Add(this.Label2);
			this.TabPage1.Controls.Add(this.TextBoxSP);
			this.TabPage1.Controls.Add(this.Label1);
			this.TabPage1.Controls.Add(this.CheckBoxAdena);
			this.TabPage1.Controls.Add(this.CheckBoxExp);
			this.TabPage1.Controls.Add(this.CheckBoxSP);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(360, 168);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Options";
			this.TabPage1.UseVisualStyleBackColor = true;
			// 
			// CheckedListBox
			// 
			this.CheckedListBox.CheckOnClick = true;
			this.CheckedListBox.FormattingEnabled = true;
			this.CheckedListBox.Items.AddRange(new object[] {
            "NO_DESIRE",
            "ON_START",
            "ATTACKED",
            "ON_NPC_DELETED",
            "SPELLED",
            "ON_SCRIPT_EVENT",
            "TALKED",
            "ON_DB_NPC_INFO",
            "TALK_SELECTED",
            "ON_TIMER",
            "SEE_CREATURE",
            "ON_NPC_CREATED",
            "MY_DYING",
            "TIMER_FIRED",
            "TIMER_FIRED_EX",
            "CREATED",
            "SEE_SPELL",
            "OUT_OF_TERRITORY",
            "DESIRE_MANIPULATION",
            "PARTY_ATTACKED",
            "PARTY_DIED",
            "CLAN_ATTACKED",
            "STATIC_OBJECT_CLAN_ATTACKED",
            "TELEPORT_REQUESTED",
            "QUEST_ACCEPTED",
            "MENU_SELECTED",
            "LEARN_SKILL_REQUESTED",
            "ENCHANT_SKILL_REQUESTED",
            "ONE_SKILL_SELECTED",
            "ONE_ENCHANT_SKILL_SELECTED",
            "CLASS_CHANGE_REQUESTED",
            "MANOR_MENU_SELECTED",
            "CREATE_PLEDGE",
            "DISMISS_PLEDGE",
            "REVIVE_PLEDGE",
            "LEVEL_UP_PLEDGE",
            "CREATE_ALLIANCE",
            "SCRIPT_EVENT",
            "TUTORIAL_EVENT",
            "QUESTION_MARK_CLICKED",
            "USER_CONNECTED",
            "ATTACK_FINISHED",
            "MOVE_TO_WAY_POINT_FINISHED",
            "USE_SKILL_FINISHED",
            "MOVE_TO_FINISHED",
            "DOOR_HP_LEVEL_INFORMED",
            "CONTROLTOWER_LEVEL_INFORMED",
            "TB_REGISTER_PLEDGE_RETURNED",
            "TB_SET_NPC_TYPE_RETURNED",
            "TB_GET_PLEDGE_REGISTER_STATUS_INFORMED",
            "TB_GET_BATTLE_ROYAL_PLEDGE_LIST_INFORMED",
            "SUBJOB_LIST_INFORMED",
            "SUBJOB_CREATED",
            "SUBJOB_CHANGED",
            "SUBJOB_RENEWED",
            "ON_SSQ_SYSTEM_EVENT",
            "SET_AGIT_DECO_RETURNED",
            "SET_AGIT_DECO_RETURNED",
            "RESET_AGIT_DECO_RETURNED",
            "RESET_AGIT_DECO_RETURNED",
            "CLAN_DIED",
            "SET_HERO_RETURNED",
            "DELETE_PREVIOUS_OLYMPIAD_POINT_RETURNED"});
			this.CheckedListBox.Location = new System.Drawing.Point(139, 22);
			this.CheckedListBox.Name = "CheckedListBox";
			this.CheckedListBox.Size = new System.Drawing.Size(211, 109);
			this.CheckedListBox.TabIndex = 16;
			// 
			// DeselectAllButton
			// 
			this.DeselectAllButton.Location = new System.Drawing.Point(275, 134);
			this.DeselectAllButton.Name = "DeselectAllButton";
			this.DeselectAllButton.Size = new System.Drawing.Size(75, 23);
			this.DeselectAllButton.TabIndex = 22;
			this.DeselectAllButton.Text = "DeSelect All";
			this.DeselectAllButton.UseVisualStyleBackColor = true;
			this.DeselectAllButton.Click += new System.EventHandler(this.DeselectAllButton_Click);
			// 
			// SelectAllButton
			// 
			this.SelectAllButton.Location = new System.Drawing.Point(139, 134);
			this.SelectAllButton.Name = "SelectAllButton";
			this.SelectAllButton.Size = new System.Drawing.Size(75, 23);
			this.SelectAllButton.TabIndex = 21;
			this.SelectAllButton.Text = "Select All";
			this.SelectAllButton.UseVisualStyleBackColor = true;
			this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
			// 
			// TextBoxItem
			// 
			this.TextBoxItem.Enabled = false;
			this.TextBoxItem.Location = new System.Drawing.Point(7, 137);
			this.TextBoxItem.Name = "TextBoxItem";
			this.TextBoxItem.Size = new System.Drawing.Size(83, 20);
			this.TextBoxItem.TabIndex = 20;
			this.TextBoxItem.Text = "57";
			this.TextBoxItem.Leave += new System.EventHandler(this.TextBoxItem_Leave);
			// 
			// CheckBoxItem
			// 
			this.CheckBoxItem.AutoSize = true;
			this.CheckBoxItem.Location = new System.Drawing.Point(7, 114);
			this.CheckBoxItem.Name = "CheckBoxItem";
			this.CheckBoxItem.Size = new System.Drawing.Size(87, 17);
			this.CheckBoxItem.TabIndex = 19;
			this.CheckBoxItem.Text = "Custom Item:";
			this.CheckBoxItem.UseVisualStyleBackColor = true;
			this.CheckBoxItem.CheckedChanged += new System.EventHandler(this.CheckBoxItem_CheckedChanged);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label2.Location = new System.Drawing.Point(6, 3);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(90, 16);
			this.Label2.TabIndex = 18;
			this.Label2.Text = "Featured rates:";
			// 
			// TextBoxSP
			// 
			this.TextBoxSP.Enabled = false;
			this.TextBoxSP.Location = new System.Drawing.Point(96, 72);
			this.TextBoxSP.Name = "TextBoxSP";
			this.TextBoxSP.Size = new System.Drawing.Size(37, 20);
			this.TextBoxSP.TabIndex = 12;
			this.TextBoxSP.Text = "1";
			this.TextBoxSP.Leave += new System.EventHandler(this.TextBoxSP_Leave);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label1.Location = new System.Drawing.Point(136, 3);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(110, 16);
			this.Label1.TabIndex = 17;
			this.Label1.Text = "Ignore handler list:";
			// 
			// CheckBoxAdena
			// 
			this.CheckBoxAdena.AutoSize = true;
			this.CheckBoxAdena.Location = new System.Drawing.Point(7, 22);
			this.CheckBoxAdena.Name = "CheckBoxAdena";
			this.CheckBoxAdena.Size = new System.Drawing.Size(83, 17);
			this.CheckBoxAdena.TabIndex = 13;
			this.CheckBoxAdena.Text = "Adena Rate";
			this.CheckBoxAdena.UseVisualStyleBackColor = true;
			this.CheckBoxAdena.CheckedChanged += new System.EventHandler(this.CheckBoxAdena_CheckedChanged);
			// 
			// CheckBoxExp
			// 
			this.CheckBoxExp.AutoSize = true;
			this.CheckBoxExp.Location = new System.Drawing.Point(7, 48);
			this.CheckBoxExp.Name = "CheckBoxExp";
			this.CheckBoxExp.Size = new System.Drawing.Size(70, 17);
			this.CheckBoxExp.TabIndex = 14;
			this.CheckBoxExp.Text = "Exp Rate";
			this.CheckBoxExp.UseVisualStyleBackColor = true;
			this.CheckBoxExp.CheckedChanged += new System.EventHandler(this.CheckBoxExp_CheckedChanged);
			// 
			// CheckBoxSP
			// 
			this.CheckBoxSP.AutoSize = true;
			this.CheckBoxSP.Location = new System.Drawing.Point(7, 74);
			this.CheckBoxSP.Name = "CheckBoxSP";
			this.CheckBoxSP.Size = new System.Drawing.Size(66, 17);
			this.CheckBoxSP.TabIndex = 15;
			this.CheckBoxSP.Text = "SP Rate";
			this.CheckBoxSP.UseVisualStyleBackColor = true;
			this.CheckBoxSP.CheckedChanged += new System.EventHandler(this.CheckBoxSP_CheckedChanged);
			// 
			// TabPage2
			// 
			this.TabPage2.Controls.Add(this.QuestListBox);
			this.TabPage2.Controls.Add(this.QuestDeSelectButton);
			this.TabPage2.Controls.Add(this.QuestListCheckBox);
			this.TabPage2.Controls.Add(this.QuestSelectButton);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(360, 168);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Quest List";
			this.TabPage2.UseVisualStyleBackColor = true;
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(134, 31);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(368, 194);
			this.TabControl1.TabIndex = 59;
			// 
			// ButtonQuest
			// 
			this.ButtonQuest.Location = new System.Drawing.Point(32, 173);
			this.ButtonQuest.Name = "ButtonQuest";
			this.ButtonQuest.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuest.TabIndex = 58;
			this.ButtonQuest.Text = "Fix";
			this.ButtonQuest.UseVisualStyleBackColor = true;
			this.ButtonQuest.Click += new System.EventHandler(this.ButtonQuest_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Label3.Location = new System.Drawing.Point(405, 28);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(97, 13);
			this.Label3.TabIndex = 61;
			this.Label3.Text = "(support C4 scripts)";
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
			this.PictureBox1.Location = new System.Drawing.Point(12, 12);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(116, 155);
			this.PictureBox1.TabIndex = 57;
			this.PictureBox1.TabStop = false;
			// 
			// ButtonQuit
			// 
			this.ButtonQuit.Location = new System.Drawing.Point(32, 202);
			this.ButtonQuit.Name = "ButtonQuit";
			this.ButtonQuit.Size = new System.Drawing.Size(75, 23);
			this.ButtonQuit.TabIndex = 55;
			this.ButtonQuit.Text = "Quit";
			this.ButtonQuit.UseVisualStyleBackColor = true;
			this.ButtonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(12, 231);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(490, 23);
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressBar.TabIndex = 56;
			// 
			// AiRateChanger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 266);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.ButtonQuest);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.ButtonQuit);
			this.Controls.Add(this.ProgressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AiRateChanger";
			this.Text = "Ai Rate Changer";
			this.Load += new System.EventHandler(this.AiRateChanger_Load);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.CheckedListBox QuestListBox;
		internal System.Windows.Forms.Button QuestDeSelectButton;
		internal System.Windows.Forms.CheckBox QuestListCheckBox;
		internal System.Windows.Forms.Button QuestSelectButton;
		internal System.Windows.Forms.TextBox TextBoxAdena;
		internal System.Windows.Forms.TextBox TextBoxExp;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.CheckedListBox CheckedListBox;
		internal System.Windows.Forms.Button DeselectAllButton;
		internal System.Windows.Forms.Button SelectAllButton;
		internal System.Windows.Forms.TextBox TextBoxItem;
		internal System.Windows.Forms.CheckBox CheckBoxItem;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox TextBoxSP;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.CheckBox CheckBoxAdena;
		internal System.Windows.Forms.CheckBox CheckBoxExp;
		internal System.Windows.Forms.CheckBox CheckBoxSP;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.Button ButtonQuest;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Button ButtonQuit;
		internal System.Windows.Forms.ProgressBar ProgressBar;
	}
}