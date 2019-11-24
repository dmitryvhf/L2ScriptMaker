<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcdataRateReBuilder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcdataRateReBuilder))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.AmnAdenaBox = New System.Windows.Forms.TextBox()
        Me.AmnChgBothBox = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.NolownomoreRadioButton = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BalancedRadioButton = New System.Windows.Forms.RadioButton()
        Me.RateLimitTextBox = New System.Windows.Forms.TextBox()
        Me.RateLimitCheckBox = New System.Windows.Forms.CheckBox()
        Me.GoldMiddleRadioButton = New System.Windows.Forms.RadioButton()
        Me.Max100RadioButton = New System.Windows.Forms.RadioButton()
        Me.AgressiveRadioButton = New System.Windows.Forms.RadioButton()
        Me.NormalRadioButton = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MultSPBox = New System.Windows.Forms.TextBox()
        Me.MultDropBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MultExpBox = New System.Windows.Forms.TextBox()
        Me.MultSpoilBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MultAdenaBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MultSStoneBox = New System.Windows.Forms.TextBox()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.AmnChgItemListBox = New System.Windows.Forms.CheckBox()
        Me.AmnSStoneBox = New System.Windows.Forms.TextBox()
        Me.AmnDropBox = New System.Windows.Forms.TextBox()
        Me.AmnSpoilBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SpecialItemsListTextBox = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.IgnoreNpcSelectionInvertButton = New System.Windows.Forms.Button()
        Me.IgnoreNpcDeselectAllButton = New System.Windows.Forms.Button()
        Me.IgnoreNpcSelectAllButton = New System.Windows.Forms.Button()
        Me.IgnoreNpcCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.IgnoreNpcNamesTextBox = New System.Windows.Forms.TextBox()
        Me.IgnoreNpcNameCheckBox = New System.Windows.Forms.CheckBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.TabPage1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(69, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Spoil:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(69, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "SealStone:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Adena:"
        '
        'AmnAdenaBox
        '
        Me.AmnAdenaBox.Location = New System.Drawing.Point(9, 58)
        Me.AmnAdenaBox.Name = "AmnAdenaBox"
        Me.AmnAdenaBox.Size = New System.Drawing.Size(50, 20)
        Me.AmnAdenaBox.TabIndex = 2
        Me.AmnAdenaBox.Text = "1"
        '
        'AmnChgBothBox
        '
        Me.AmnChgBothBox.AutoSize = True
        Me.AmnChgBothBox.Checked = True
        Me.AmnChgBothBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AmnChgBothBox.Location = New System.Drawing.Point(9, 84)
        Me.AmnChgBothBox.Name = "AmnChgBothBox"
        Me.AmnChgBothBox.Size = New System.Drawing.Size(137, 17)
        Me.AmnChgBothBox.TabIndex = 4
        Me.AmnChgBothBox.Text = "Change both (min, max)"
        Me.ToolTip.SetToolTip(Me.AmnChgBothBox, "Default is True. Change Min and Max together." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{[item1];2;4;x}; with 2x rate will" & _
        " {[item1];4;8;x};" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If False" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{[item1];2;4;x}; with 2x rate will {[item1];2;8;x};" & _
        "")
        Me.AmnChgBothBox.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.NolownomoreRadioButton)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.BalancedRadioButton)
        Me.TabPage1.Controls.Add(Me.RateLimitTextBox)
        Me.TabPage1.Controls.Add(Me.RateLimitCheckBox)
        Me.TabPage1.Controls.Add(Me.GoldMiddleRadioButton)
        Me.TabPage1.Controls.Add(Me.Max100RadioButton)
        Me.TabPage1.Controls.Add(Me.AgressiveRadioButton)
        Me.TabPage1.Controls.Add(Me.NormalRadioButton)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.MultSPBox)
        Me.TabPage1.Controls.Add(Me.MultDropBox)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.MultExpBox)
        Me.TabPage1.Controls.Add(Me.MultSpoilBox)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.MultAdenaBox)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.MultSStoneBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 40)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(323, 147)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Chance Rate"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'NolownomoreRadioButton
        '
        Me.NolownomoreRadioButton.AutoSize = True
        Me.NolownomoreRadioButton.Location = New System.Drawing.Point(140, 70)
        Me.NolownomoreRadioButton.Name = "NolownomoreRadioButton"
        Me.NolownomoreRadioButton.Size = New System.Drawing.Size(105, 17)
        Me.NolownomoreRadioButton.TabIndex = 28
        Me.NolownomoreRadioButton.Text = "NoLowNowMore"
        Me.ToolTip.SetToolTip(Me.NolownomoreRadioButton, resources.GetString("NolownomoreRadioButton.ToolTip"))
        Me.NolownomoreRadioButton.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(133, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 14)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "USE ONLY TO SPOIL:"
        '
        'BalancedRadioButton
        '
        Me.BalancedRadioButton.AutoSize = True
        Me.BalancedRadioButton.Location = New System.Drawing.Point(140, 54)
        Me.BalancedRadioButton.Name = "BalancedRadioButton"
        Me.BalancedRadioButton.Size = New System.Drawing.Size(70, 17)
        Me.BalancedRadioButton.TabIndex = 27
        Me.BalancedRadioButton.Text = "Balanced"
        Me.ToolTip.SetToolTip(Me.BalancedRadioButton, resources.GetString("BalancedRadioButton.ToolTip"))
        Me.BalancedRadioButton.UseVisualStyleBackColor = True
        '
        'RateLimitTextBox
        '
        Me.RateLimitTextBox.Enabled = False
        Me.RateLimitTextBox.Location = New System.Drawing.Point(84, 121)
        Me.RateLimitTextBox.Name = "RateLimitTextBox"
        Me.RateLimitTextBox.Size = New System.Drawing.Size(38, 20)
        Me.RateLimitTextBox.TabIndex = 26
        Me.RateLimitTextBox.Text = "100"
        '
        'RateLimitCheckBox
        '
        Me.RateLimitCheckBox.AutoSize = True
        Me.RateLimitCheckBox.Location = New System.Drawing.Point(9, 123)
        Me.RateLimitCheckBox.Name = "RateLimitCheckBox"
        Me.RateLimitCheckBox.Size = New System.Drawing.Size(76, 17)
        Me.RateLimitCheckBox.TabIndex = 25
        Me.RateLimitCheckBox.Text = "Rate Limit:"
        Me.ToolTip.SetToolTip(Me.RateLimitCheckBox, "Uses with ""100% max"" metod. Enable feature" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and set maximum range for rates.")
        Me.RateLimitCheckBox.UseVisualStyleBackColor = True
        '
        'GoldMiddleRadioButton
        '
        Me.GoldMiddleRadioButton.AutoSize = True
        Me.GoldMiddleRadioButton.Location = New System.Drawing.Point(160, 112)
        Me.GoldMiddleRadioButton.Name = "GoldMiddleRadioButton"
        Me.GoldMiddleRadioButton.Size = New System.Drawing.Size(91, 30)
        Me.GoldMiddleRadioButton.TabIndex = 23
        Me.GoldMiddleRadioButton.TabStop = True
        Me.GoldMiddleRadioButton.Text = """Gold Middle""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Spoil"
        Me.ToolTip.SetToolTip(Me.GoldMiddleRadioButton, resources.GetString("GoldMiddleRadioButton.ToolTip"))
        Me.GoldMiddleRadioButton.UseVisualStyleBackColor = True
        '
        'Max100RadioButton
        '
        Me.Max100RadioButton.AutoSize = True
        Me.Max100RadioButton.Location = New System.Drawing.Point(140, 38)
        Me.Max100RadioButton.Name = "Max100RadioButton"
        Me.Max100RadioButton.Size = New System.Drawing.Size(73, 17)
        Me.Max100RadioButton.TabIndex = 22
        Me.Max100RadioButton.Text = "100% max"
        Me.ToolTip.SetToolTip(Me.Max100RadioButton, "All group chance more them 100%, will be dropped to 100%." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Example:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{[item1];1;2" & _
        ";450} will be converted to {[item1];1;2;100} ")
        Me.Max100RadioButton.UseVisualStyleBackColor = True
        '
        'AgressiveRadioButton
        '
        Me.AgressiveRadioButton.AutoSize = True
        Me.AgressiveRadioButton.Location = New System.Drawing.Point(140, 22)
        Me.AgressiveRadioButton.Name = "AgressiveRadioButton"
        Me.AgressiveRadioButton.Size = New System.Drawing.Size(71, 17)
        Me.AgressiveRadioButton.TabIndex = 20
        Me.AgressiveRadioButton.Text = "Agressive"
        Me.ToolTip.SetToolTip(Me.AgressiveRadioButton, resources.GetString("AgressiveRadioButton.ToolTip"))
        Me.AgressiveRadioButton.UseVisualStyleBackColor = True
        '
        'NormalRadioButton
        '
        Me.NormalRadioButton.AutoSize = True
        Me.NormalRadioButton.Checked = True
        Me.NormalRadioButton.Location = New System.Drawing.Point(140, 6)
        Me.NormalRadioButton.Name = "NormalRadioButton"
        Me.NormalRadioButton.Size = New System.Drawing.Size(58, 17)
        Me.NormalRadioButton.TabIndex = 19
        Me.NormalRadioButton.TabStop = True
        Me.NormalRadioButton.Text = "Normal"
        Me.ToolTip.SetToolTip(Me.NormalRadioButton, "Standart shema: all group chance more them 100%, will be increased to GroupChance" & _
        "*GroupRate." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Example:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{[item1];1;2;50} with rate 5x will be converted to {[item" & _
        "1];1;2;250} ")
        Me.NormalRadioButton.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Exp:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Spoil:"
        '
        'MultSPBox
        '
        Me.MultSPBox.Location = New System.Drawing.Point(9, 58)
        Me.MultSPBox.Name = "MultSPBox"
        Me.MultSPBox.Size = New System.Drawing.Size(50, 20)
        Me.MultSPBox.TabIndex = 2
        Me.MultSPBox.Text = "1"
        '
        'MultDropBox
        '
        Me.MultDropBox.Location = New System.Drawing.Point(72, 19)
        Me.MultDropBox.Name = "MultDropBox"
        Me.MultDropBox.Size = New System.Drawing.Size(50, 20)
        Me.MultDropBox.TabIndex = 1
        Me.MultDropBox.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Drop:"
        '
        'MultExpBox
        '
        Me.MultExpBox.Location = New System.Drawing.Point(9, 19)
        Me.MultExpBox.Name = "MultExpBox"
        Me.MultExpBox.Size = New System.Drawing.Size(50, 20)
        Me.MultExpBox.TabIndex = 0
        Me.MultExpBox.Text = "1"
        '
        'MultSpoilBox
        '
        Me.MultSpoilBox.Location = New System.Drawing.Point(72, 58)
        Me.MultSpoilBox.Name = "MultSpoilBox"
        Me.MultSpoilBox.Size = New System.Drawing.Size(50, 20)
        Me.MultSpoilBox.TabIndex = 3
        Me.MultSpoilBox.Text = "1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "SP:"
        '
        'MultAdenaBox
        '
        Me.MultAdenaBox.Location = New System.Drawing.Point(9, 97)
        Me.MultAdenaBox.Name = "MultAdenaBox"
        Me.MultAdenaBox.ReadOnly = True
        Me.MultAdenaBox.Size = New System.Drawing.Size(50, 20)
        Me.MultAdenaBox.TabIndex = 4
        Me.MultAdenaBox.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(69, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "SealStone:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Adena:"
        '
        'MultSStoneBox
        '
        Me.MultSStoneBox.Location = New System.Drawing.Point(72, 97)
        Me.MultSStoneBox.Name = "MultSStoneBox"
        Me.MultSStoneBox.ReadOnly = True
        Me.MultSStoneBox.Size = New System.Drawing.Size(50, 20)
        Me.MultSStoneBox.TabIndex = 5
        Me.MultSStoneBox.Text = "1"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage3)
        Me.TabControl.Controls.Add(Me.TabPage4)
        Me.TabControl.Controls.Add(Me.TabPage5)
        Me.TabControl.Location = New System.Drawing.Point(128, 41)
        Me.TabControl.Multiline = True
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(331, 191)
        Me.TabControl.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.TabControl, "List items from item_pch. No do empty lines and commentaries." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This 2 items only " & _
        "for example. Use self list.")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.AmnChgItemListBox)
        Me.TabPage2.Controls.Add(Me.AmnChgBothBox)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.AmnAdenaBox)
        Me.TabPage2.Controls.Add(Me.AmnSStoneBox)
        Me.TabPage2.Controls.Add(Me.AmnDropBox)
        Me.TabPage2.Controls.Add(Me.AmnSpoilBox)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 40)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(323, 147)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Amount Rate"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'AmnChgItemListBox
        '
        Me.AmnChgItemListBox.AutoSize = True
        Me.AmnChgItemListBox.Location = New System.Drawing.Point(9, 107)
        Me.AmnChgItemListBox.Name = "AmnChgItemListBox"
        Me.AmnChgItemListBox.Size = New System.Drawing.Size(139, 30)
        Me.AmnChgItemListBox.TabIndex = 5
        Me.AmnChgItemListBox.Text = "Change amount only" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for items from special list"
        Me.ToolTip.SetToolTip(Me.AmnChgItemListBox, "Only amount drop for this items will be change.")
        Me.AmnChgItemListBox.UseVisualStyleBackColor = True
        '
        'AmnSStoneBox
        '
        Me.AmnSStoneBox.Location = New System.Drawing.Point(72, 58)
        Me.AmnSStoneBox.Name = "AmnSStoneBox"
        Me.AmnSStoneBox.Size = New System.Drawing.Size(50, 20)
        Me.AmnSStoneBox.TabIndex = 3
        Me.AmnSStoneBox.Text = "1"
        '
        'AmnDropBox
        '
        Me.AmnDropBox.Location = New System.Drawing.Point(9, 19)
        Me.AmnDropBox.Name = "AmnDropBox"
        Me.AmnDropBox.Size = New System.Drawing.Size(50, 20)
        Me.AmnDropBox.TabIndex = 0
        Me.AmnDropBox.Text = "1"
        '
        'AmnSpoilBox
        '
        Me.AmnSpoilBox.Location = New System.Drawing.Point(72, 19)
        Me.AmnSpoilBox.Name = "AmnSpoilBox"
        Me.AmnSpoilBox.Size = New System.Drawing.Size(50, 20)
        Me.AmnSpoilBox.TabIndex = 1
        Me.AmnSpoilBox.Text = "1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Drop:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SpecialItemsListTextBox)
        Me.TabPage3.Location = New System.Drawing.Point(4, 40)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(323, 147)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Special List of Items"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SpecialItemsListTextBox
        '
        Me.SpecialItemsListTextBox.Location = New System.Drawing.Point(3, 3)
        Me.SpecialItemsListTextBox.Multiline = True
        Me.SpecialItemsListTextBox.Name = "SpecialItemsListTextBox"
        Me.SpecialItemsListTextBox.Size = New System.Drawing.Size(248, 142)
        Me.SpecialItemsListTextBox.TabIndex = 0
        Me.SpecialItemsListTextBox.Text = "[stem]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[coal]"
        Me.ToolTip.SetToolTip(Me.SpecialItemsListTextBox, "List of items ")
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.RadioButton3)
        Me.TabPage4.Controls.Add(Me.RadioButton2)
        Me.TabPage4.Controls.Add(Me.RadioButton1)
        Me.TabPage4.Controls.Add(Me.IgnoreNpcSelectionInvertButton)
        Me.TabPage4.Controls.Add(Me.IgnoreNpcDeselectAllButton)
        Me.TabPage4.Controls.Add(Me.IgnoreNpcSelectAllButton)
        Me.TabPage4.Controls.Add(Me.IgnoreNpcCheckedListBox)
        Me.TabPage4.Location = New System.Drawing.Point(4, 40)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(323, 147)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Ignored NpcType List"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(153, 42)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(164, 17)
        Me.RadioButton3.TabIndex = 7
        Me.RadioButton3.Text = "Ignore Except of Npc from list"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(153, 24)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(116, 17)
        Me.RadioButton2.TabIndex = 6
        Me.RadioButton2.Text = "Ignore Npc from list"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(153, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(36, 17)
        Me.RadioButton1.TabIndex = 5
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "All"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'IgnoreNpcSelectionInvertButton
        '
        Me.IgnoreNpcSelectionInvertButton.Location = New System.Drawing.Point(153, 120)
        Me.IgnoreNpcSelectionInvertButton.Name = "IgnoreNpcSelectionInvertButton"
        Me.IgnoreNpcSelectionInvertButton.Size = New System.Drawing.Size(92, 23)
        Me.IgnoreNpcSelectionInvertButton.TabIndex = 3
        Me.IgnoreNpcSelectionInvertButton.Text = "Invert Selection"
        Me.IgnoreNpcSelectionInvertButton.UseVisualStyleBackColor = True
        '
        'IgnoreNpcDeselectAllButton
        '
        Me.IgnoreNpcDeselectAllButton.Location = New System.Drawing.Point(153, 91)
        Me.IgnoreNpcDeselectAllButton.Name = "IgnoreNpcDeselectAllButton"
        Me.IgnoreNpcDeselectAllButton.Size = New System.Drawing.Size(92, 23)
        Me.IgnoreNpcDeselectAllButton.TabIndex = 2
        Me.IgnoreNpcDeselectAllButton.Text = "Deselect All"
        Me.IgnoreNpcDeselectAllButton.UseVisualStyleBackColor = True
        '
        'IgnoreNpcSelectAllButton
        '
        Me.IgnoreNpcSelectAllButton.Location = New System.Drawing.Point(153, 62)
        Me.IgnoreNpcSelectAllButton.Name = "IgnoreNpcSelectAllButton"
        Me.IgnoreNpcSelectAllButton.Size = New System.Drawing.Size(92, 23)
        Me.IgnoreNpcSelectAllButton.TabIndex = 1
        Me.IgnoreNpcSelectAllButton.Text = "Select All"
        Me.IgnoreNpcSelectAllButton.UseVisualStyleBackColor = True
        '
        'IgnoreNpcCheckedListBox
        '
        Me.IgnoreNpcCheckedListBox.FormattingEnabled = True
        Me.IgnoreNpcCheckedListBox.Items.AddRange(New Object() {"citizen", "warrior", "guard", "merchant", "blacksmith", "chamberlain", "warehouse_keeper", "package_keeper", "guild_master", "guild_coach", "teleporter", "summon", "pet", "object", "holything", "mrkeeper", "monrace", "treasure", "xmastree", "boss", "zzoldagu"})
        Me.IgnoreNpcCheckedListBox.Location = New System.Drawing.Point(6, 6)
        Me.IgnoreNpcCheckedListBox.Name = "IgnoreNpcCheckedListBox"
        Me.IgnoreNpcCheckedListBox.Size = New System.Drawing.Size(141, 139)
        Me.IgnoreNpcCheckedListBox.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.IgnoreNpcNamesTextBox)
        Me.TabPage5.Controls.Add(Me.IgnoreNpcNameCheckBox)
        Me.TabPage5.Location = New System.Drawing.Point(4, 40)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(323, 147)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Ignored NpcName List"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'IgnoreNpcNamesTextBox
        '
        Me.IgnoreNpcNamesTextBox.Enabled = False
        Me.IgnoreNpcNamesTextBox.Location = New System.Drawing.Point(6, 26)
        Me.IgnoreNpcNamesTextBox.Multiline = True
        Me.IgnoreNpcNamesTextBox.Name = "IgnoreNpcNamesTextBox"
        Me.IgnoreNpcNamesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.IgnoreNpcNamesTextBox.Size = New System.Drawing.Size(242, 115)
        Me.IgnoreNpcNamesTextBox.TabIndex = 1
        Me.IgnoreNpcNamesTextBox.Text = "[antaras]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[baium]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[zaken]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[queen_ant]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[orfen]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[core]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[valakas]"
        '
        'IgnoreNpcNameCheckBox
        '
        Me.IgnoreNpcNameCheckBox.AutoSize = True
        Me.IgnoreNpcNameCheckBox.Location = New System.Drawing.Point(6, 3)
        Me.IgnoreNpcNameCheckBox.Name = "IgnoreNpcNameCheckBox"
        Me.IgnoreNpcNameCheckBox.Size = New System.Drawing.Size(212, 17)
        Me.IgnoreNpcNameCheckBox.TabIndex = 0
        Me.IgnoreNpcNameCheckBox.Text = "Use special ignore Npc's list (by names)"
        Me.IgnoreNpcNameCheckBox.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(230, 12)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 238)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(444, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "(support C4 scripts)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 16)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "NpcData Rate Rebuilder"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.hell_logo
        Me.PictureBox1.Location = New System.Drawing.Point(15, 60)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 172)
        Me.PictureBox1.TabIndex = 50
        Me.PictureBox1.TabStop = False
        Me.ToolTip.SetToolTip(Me.PictureBox1, "My Face" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for your Progress")
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(315, 12)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 49
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'NpcdataRateReBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 270)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.ProgressBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcdataRateReBuilder"
        Me.Text = "NpcData Rate Rebuilder"
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents AmnAdenaBox As System.Windows.Forms.TextBox
    Friend WithEvents AmnChgBothBox As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MultSPBox As System.Windows.Forms.TextBox
    Friend WithEvents MultDropBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MultExpBox As System.Windows.Forms.TextBox
    Friend WithEvents MultSpoilBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MultAdenaBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MultSStoneBox As System.Windows.Forms.TextBox
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents AmnChgItemListBox As System.Windows.Forms.CheckBox
    Friend WithEvents AmnSStoneBox As System.Windows.Forms.TextBox
    Friend WithEvents AmnDropBox As System.Windows.Forms.TextBox
    Friend WithEvents AmnSpoilBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SpecialItemsListTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents AgressiveRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents NormalRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Max100RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents IgnoreNpcSelectionInvertButton As System.Windows.Forms.Button
    Friend WithEvents IgnoreNpcDeselectAllButton As System.Windows.Forms.Button
    Friend WithEvents IgnoreNpcSelectAllButton As System.Windows.Forms.Button
    Friend WithEvents IgnoreNpcCheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents GoldMiddleRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RateLimitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RateLimitCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BalancedRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents IgnoreNpcNamesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IgnoreNpcNameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents NolownomoreRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    'Friend WithEvents AiFixerBindingSource As System.Windows.Forms.BindingSource
End Class
