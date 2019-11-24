<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AiRateChanger
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AiRateChanger))
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ButtonQuest = New System.Windows.Forms.Button
        Me.TextBoxAdena = New System.Windows.Forms.TextBox
        Me.TextBoxExp = New System.Windows.Forms.TextBox
        Me.TextBoxSP = New System.Windows.Forms.TextBox
        Me.CheckBoxAdena = New System.Windows.Forms.CheckBox
        Me.CheckBoxExp = New System.Windows.Forms.CheckBox
        Me.CheckBoxSP = New System.Windows.Forms.CheckBox
        Me.CheckedListBox = New System.Windows.Forms.CheckedListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBoxItem = New System.Windows.Forms.CheckBox
        Me.TextBoxItem = New System.Windows.Forms.TextBox
        Me.SelectAllButton = New System.Windows.Forms.Button
        Me.DeselectAllButton = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.QuestListBox = New System.Windows.Forms.CheckedListBox
        Me.QuestDeSelectButton = New System.Windows.Forms.Button
        Me.QuestListCheckBox = New System.Windows.Forms.CheckBox
        Me.QuestSelectButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(32, 202)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 1
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 231)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(490, 23)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(116, 155)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'ButtonQuest
        '
        Me.ButtonQuest.Location = New System.Drawing.Point(32, 173)
        Me.ButtonQuest.Name = "ButtonQuest"
        Me.ButtonQuest.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuest.TabIndex = 7
        Me.ButtonQuest.Text = "Fix"
        Me.ButtonQuest.UseVisualStyleBackColor = True
        '
        'TextBoxAdena
        '
        Me.TextBoxAdena.Enabled = False
        Me.TextBoxAdena.Location = New System.Drawing.Point(96, 20)
        Me.TextBoxAdena.Name = "TextBoxAdena"
        Me.TextBoxAdena.Size = New System.Drawing.Size(37, 20)
        Me.TextBoxAdena.TabIndex = 10
        Me.TextBoxAdena.Text = "1"
        '
        'TextBoxExp
        '
        Me.TextBoxExp.Enabled = False
        Me.TextBoxExp.Location = New System.Drawing.Point(96, 46)
        Me.TextBoxExp.Name = "TextBoxExp"
        Me.TextBoxExp.Size = New System.Drawing.Size(37, 20)
        Me.TextBoxExp.TabIndex = 11
        Me.TextBoxExp.Text = "1"
        '
        'TextBoxSP
        '
        Me.TextBoxSP.Enabled = False
        Me.TextBoxSP.Location = New System.Drawing.Point(96, 72)
        Me.TextBoxSP.Name = "TextBoxSP"
        Me.TextBoxSP.Size = New System.Drawing.Size(37, 20)
        Me.TextBoxSP.TabIndex = 12
        Me.TextBoxSP.Text = "1"
        '
        'CheckBoxAdena
        '
        Me.CheckBoxAdena.AutoSize = True
        Me.CheckBoxAdena.Location = New System.Drawing.Point(7, 22)
        Me.CheckBoxAdena.Name = "CheckBoxAdena"
        Me.CheckBoxAdena.Size = New System.Drawing.Size(83, 17)
        Me.CheckBoxAdena.TabIndex = 13
        Me.CheckBoxAdena.Text = "Adena Rate"
        Me.CheckBoxAdena.UseVisualStyleBackColor = True
        '
        'CheckBoxExp
        '
        Me.CheckBoxExp.AutoSize = True
        Me.CheckBoxExp.Location = New System.Drawing.Point(7, 48)
        Me.CheckBoxExp.Name = "CheckBoxExp"
        Me.CheckBoxExp.Size = New System.Drawing.Size(70, 17)
        Me.CheckBoxExp.TabIndex = 14
        Me.CheckBoxExp.Text = "Exp Rate"
        Me.CheckBoxExp.UseVisualStyleBackColor = True
        '
        'CheckBoxSP
        '
        Me.CheckBoxSP.AutoSize = True
        Me.CheckBoxSP.Location = New System.Drawing.Point(7, 74)
        Me.CheckBoxSP.Name = "CheckBoxSP"
        Me.CheckBoxSP.Size = New System.Drawing.Size(66, 17)
        Me.CheckBoxSP.TabIndex = 15
        Me.CheckBoxSP.Text = "SP Rate"
        Me.CheckBoxSP.UseVisualStyleBackColor = True
        '
        'CheckedListBox
        '
        Me.CheckedListBox.CheckOnClick = True
        Me.CheckedListBox.FormattingEnabled = True
        Me.CheckedListBox.Items.AddRange(New Object() {"NO_DESIRE", "ON_START", "ATTACKED", "ON_NPC_DELETED", "SPELLED", "ON_SCRIPT_EVENT", "TALKED", "ON_DB_NPC_INFO", "TALK_SELECTED", "ON_TIMER", "SEE_CREATURE", "ON_NPC_CREATED", "MY_DYING", "TIMER_FIRED", "TIMER_FIRED_EX", "CREATED", "SEE_SPELL", "OUT_OF_TERRITORY", "DESIRE_MANIPULATION", "PARTY_ATTACKED", "PARTY_DIED", "CLAN_ATTACKED", "STATIC_OBJECT_CLAN_ATTACKED", "TELEPORT_REQUESTED", "QUEST_ACCEPTED", "MENU_SELECTED", "LEARN_SKILL_REQUESTED", "ENCHANT_SKILL_REQUESTED", "ONE_SKILL_SELECTED", "ONE_ENCHANT_SKILL_SELECTED", "CLASS_CHANGE_REQUESTED", "MANOR_MENU_SELECTED", "CREATE_PLEDGE", "DISMISS_PLEDGE", "REVIVE_PLEDGE", "LEVEL_UP_PLEDGE", "CREATE_ALLIANCE", "SCRIPT_EVENT", "TUTORIAL_EVENT", "QUESTION_MARK_CLICKED", "USER_CONNECTED", "ATTACK_FINISHED", "MOVE_TO_WAY_POINT_FINISHED", "USE_SKILL_FINISHED", "MOVE_TO_FINISHED", "DOOR_HP_LEVEL_INFORMED", "CONTROLTOWER_LEVEL_INFORMED", "TB_REGISTER_PLEDGE_RETURNED", "TB_SET_NPC_TYPE_RETURNED", "TB_GET_PLEDGE_REGISTER_STATUS_INFORMED", "TB_GET_BATTLE_ROYAL_PLEDGE_LIST_INFORMED", "SUBJOB_LIST_INFORMED", "SUBJOB_CREATED", "SUBJOB_CHANGED", "SUBJOB_RENEWED", "ON_SSQ_SYSTEM_EVENT", "SET_AGIT_DECO_RETURNED", "SET_AGIT_DECO_RETURNED", "RESET_AGIT_DECO_RETURNED", "RESET_AGIT_DECO_RETURNED", "CLAN_DIED", "SET_HERO_RETURNED", "DELETE_PREVIOUS_OLYMPIAD_POINT_RETURNED"})
        Me.CheckedListBox.Location = New System.Drawing.Point(139, 22)
        Me.CheckedListBox.Name = "CheckedListBox"
        Me.CheckedListBox.Size = New System.Drawing.Size(211, 109)
        Me.CheckedListBox.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(136, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Ignore handler list:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Featured rates:"
        '
        'CheckBoxItem
        '
        Me.CheckBoxItem.AutoSize = True
        Me.CheckBoxItem.Location = New System.Drawing.Point(7, 114)
        Me.CheckBoxItem.Name = "CheckBoxItem"
        Me.CheckBoxItem.Size = New System.Drawing.Size(87, 17)
        Me.CheckBoxItem.TabIndex = 19
        Me.CheckBoxItem.Text = "Custom Item:"
        Me.CheckBoxItem.UseVisualStyleBackColor = True
        '
        'TextBoxItem
        '
        Me.TextBoxItem.Enabled = False
        Me.TextBoxItem.Location = New System.Drawing.Point(7, 137)
        Me.TextBoxItem.Name = "TextBoxItem"
        Me.TextBoxItem.Size = New System.Drawing.Size(83, 20)
        Me.TextBoxItem.TabIndex = 20
        Me.TextBoxItem.Text = "57"
        '
        'SelectAllButton
        '
        Me.SelectAllButton.Location = New System.Drawing.Point(139, 134)
        Me.SelectAllButton.Name = "SelectAllButton"
        Me.SelectAllButton.Size = New System.Drawing.Size(75, 23)
        Me.SelectAllButton.TabIndex = 21
        Me.SelectAllButton.Text = "Select All"
        Me.SelectAllButton.UseVisualStyleBackColor = True
        '
        'DeselectAllButton
        '
        Me.DeselectAllButton.Location = New System.Drawing.Point(275, 134)
        Me.DeselectAllButton.Name = "DeselectAllButton"
        Me.DeselectAllButton.Size = New System.Drawing.Size(75, 23)
        Me.DeselectAllButton.TabIndex = 22
        Me.DeselectAllButton.Text = "DeSelect All"
        Me.DeselectAllButton.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(134, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(368, 194)
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckedListBox)
        Me.TabPage1.Controls.Add(Me.DeselectAllButton)
        Me.TabPage1.Controls.Add(Me.SelectAllButton)
        Me.TabPage1.Controls.Add(Me.TextBoxItem)
        Me.TabPage1.Controls.Add(Me.TextBoxAdena)
        Me.TabPage1.Controls.Add(Me.CheckBoxItem)
        Me.TabPage1.Controls.Add(Me.TextBoxExp)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TextBoxSP)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CheckBoxAdena)
        Me.TabPage1.Controls.Add(Me.CheckBoxExp)
        Me.TabPage1.Controls.Add(Me.CheckBoxSP)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(360, 168)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Options"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.QuestListBox)
        Me.TabPage2.Controls.Add(Me.QuestDeSelectButton)
        Me.TabPage2.Controls.Add(Me.QuestListCheckBox)
        Me.TabPage2.Controls.Add(Me.QuestSelectButton)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(360, 168)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Quest List"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'QuestListBox
        '
        Me.QuestListBox.Enabled = False
        Me.QuestListBox.FormattingEnabled = True
        Me.QuestListBox.Location = New System.Drawing.Point(3, 38)
        Me.QuestListBox.Name = "QuestListBox"
        Me.QuestListBox.Size = New System.Drawing.Size(351, 124)
        Me.QuestListBox.TabIndex = 56
        '
        'QuestDeSelectButton
        '
        Me.QuestDeSelectButton.Location = New System.Drawing.Point(279, 6)
        Me.QuestDeSelectButton.Name = "QuestDeSelectButton"
        Me.QuestDeSelectButton.Size = New System.Drawing.Size(75, 23)
        Me.QuestDeSelectButton.TabIndex = 22
        Me.QuestDeSelectButton.Text = "DeSelect All"
        Me.QuestDeSelectButton.UseVisualStyleBackColor = True
        '
        'QuestListCheckBox
        '
        Me.QuestListCheckBox.AutoSize = True
        Me.QuestListCheckBox.Location = New System.Drawing.Point(6, 6)
        Me.QuestListCheckBox.Name = "QuestListCheckBox"
        Me.QuestListCheckBox.Size = New System.Drawing.Size(149, 17)
        Me.QuestListCheckBox.TabIndex = 55
        Me.QuestListCheckBox.Text = "Work only with this quests"
        Me.QuestListCheckBox.UseVisualStyleBackColor = True
        '
        'QuestSelectButton
        '
        Me.QuestSelectButton.Location = New System.Drawing.Point(198, 6)
        Me.QuestSelectButton.Name = "QuestSelectButton"
        Me.QuestSelectButton.Size = New System.Drawing.Size(75, 23)
        Me.QuestSelectButton.TabIndex = 21
        Me.QuestSelectButton.Text = "Select All"
        Me.QuestSelectButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(405, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "(support C4 scripts)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(370, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 16)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "AI.obj Rate Changer"
        '
        'AiRateChanger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 264)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ButtonQuest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AiRateChanger"
        Me.Text = "Ai Rate Changer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonQuest As System.Windows.Forms.Button
    Friend WithEvents TextBoxAdena As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxExp As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSP As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxAdena As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxExp As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSP As System.Windows.Forms.CheckBox
    Friend WithEvents CheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxItem As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxItem As System.Windows.Forms.TextBox
    Friend WithEvents SelectAllButton As System.Windows.Forms.Button
    Friend WithEvents DeselectAllButton As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents QuestListCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents QuestListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents QuestDeSelectButton As System.Windows.Forms.Button
    Friend WithEvents QuestSelectButton As System.Windows.Forms.Button

End Class
