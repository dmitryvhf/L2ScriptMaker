<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatDecoder
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatDecoder))
        Me.L2Adm2NormalButton = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.QuitButton = New System.Windows.Forms.Button
        Me.L2asmToTxtUseStructureButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Label12 = New System.Windows.Forms.Label
        Me.l2asmPathTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.l2asmDDFPathTextBox = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.DDFListComboBox = New System.Windows.Forms.ComboBox
        Me.l2disasmPathTextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.l2ancdecPathTextBox = New System.Windows.Forms.TextBox
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.l2encParamsComboBox = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.l2asmOutFileTextBox = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.l2encInFileTextBox = New System.Windows.Forms.TextBox
        Me.l2encOutFileTextBox = New System.Windows.Forms.TextBox
        Me.DecWithL2AsmButton = New System.Windows.Forms.Button
        Me.DecWithL2EncdecButton = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxtToL2asmUseStructureButton = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label23 = New System.Windows.Forms.Label
        Me.l2endecEncMetodComboBox = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.l2endecEncModeComboBox = New System.Windows.Forms.ComboBox
        Me.EncWithL2AsmButton = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.outl2asmToDatTextBox = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.inl2encdecToDatTextBox = New System.Windows.Forms.TextBox
        Me.inl2asmToDatTextBox = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.EncWithL2EncdecButton = New System.Windows.Forms.Button
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.DDFDataGridView = New System.Windows.Forms.DataGridView
        Me.Label26 = New System.Windows.Forms.Label
        Me.PlainFileNameTextBox = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.EndTextBox = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.HeadTextBox = New System.Windows.Forms.TextBox
        Me.LoadDDFButton = New System.Windows.Forms.Button
        Me.MakeConfigsButton = New System.Windows.Forms.Button
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label27 = New System.Windows.Forms.Label
        Me.TextBoxL2AsmAddComm = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.DDFDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'L2Adm2NormalButton
        '
        Me.L2Adm2NormalButton.Location = New System.Drawing.Point(10, 71)
        Me.L2Adm2NormalButton.Name = "L2Adm2NormalButton"
        Me.L2Adm2NormalButton.Size = New System.Drawing.Size(98, 35)
        Me.L2Adm2NormalButton.TabIndex = 0
        Me.L2Adm2NormalButton.Text = "Autoparse with use column name"
        Me.L2Adm2NormalButton.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(10, 192)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(326, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.Dragon
        Me.PictureBox1.Location = New System.Drawing.Point(389, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(90, 198)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(397, 230)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 1
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'L2asmToTxtUseStructureButton
        '
        Me.L2asmToTxtUseStructureButton.Location = New System.Drawing.Point(10, 30)
        Me.L2asmToTxtUseStructureButton.Name = "L2asmToTxtUseStructureButton"
        Me.L2asmToTxtUseStructureButton.Size = New System.Drawing.Size(98, 35)
        Me.L2asmToTxtUseStructureButton.TabIndex = 2
        Me.L2asmToTxtUseStructureButton.Text = "Generate file with use structure file"
        Me.L2asmToTxtUseStructureButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(260, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "(support all scripts)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(331, 16)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = ".DAT Decoder/Encoder with use l2encdec and l2asm"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(8, 42)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(375, 247)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.l2asmPathTextBox)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.l2asmDDFPathTextBox)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.DDFListComboBox)
        Me.TabPage4.Controls.Add(Me.l2disasmPathTextBox)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.l2ancdecPathTextBox)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(342, 221)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Settings"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "l2asm.exe:"
        '
        'l2asmPathTextBox
        '
        Me.l2asmPathTextBox.Location = New System.Drawing.Point(6, 94)
        Me.l2asmPathTextBox.Name = "l2asmPathTextBox"
        Me.l2asmPathTextBox.Size = New System.Drawing.Size(195, 20)
        Me.l2asmPathTextBox.TabIndex = 3
        Me.l2asmPathTextBox.Text = "DatProject\l2asm.exe"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "DDF path"
        '
        'l2asmDDFPathTextBox
        '
        Me.l2asmDDFPathTextBox.Location = New System.Drawing.Point(6, 132)
        Me.l2asmDDFPathTextBox.Name = "l2asmDDFPathTextBox"
        Me.l2asmDDFPathTextBox.Size = New System.Drawing.Size(195, 20)
        Me.l2asmDDFPathTextBox.TabIndex = 4
        Me.l2asmDDFPathTextBox.Text = "DatProject\DDF"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "l2disasm.exe:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Type of client file:"
        '
        'DDFListComboBox
        '
        Me.DDFListComboBox.Location = New System.Drawing.Point(6, 171)
        Me.DDFListComboBox.Name = "DDFListComboBox"
        Me.DDFListComboBox.Size = New System.Drawing.Size(333, 21)
        Me.DDFListComboBox.TabIndex = 3
        '
        'l2disasmPathTextBox
        '
        Me.l2disasmPathTextBox.Location = New System.Drawing.Point(6, 56)
        Me.l2disasmPathTextBox.Name = "l2disasmPathTextBox"
        Me.l2disasmPathTextBox.Size = New System.Drawing.Size(195, 20)
        Me.l2disasmPathTextBox.TabIndex = 2
        Me.l2disasmPathTextBox.Text = "DatProject\l2disasm.exe"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "l2encdec.exe:"
        '
        'l2ancdecPathTextBox
        '
        Me.l2ancdecPathTextBox.Location = New System.Drawing.Point(6, 18)
        Me.l2ancdecPathTextBox.Name = "l2ancdecPathTextBox"
        Me.l2ancdecPathTextBox.Size = New System.Drawing.Size(195, 20)
        Me.l2ancdecPathTextBox.TabIndex = 0
        Me.l2ancdecPathTextBox.Text = "DatProject\l2encdec.exe"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.l2encParamsComboBox)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.l2asmOutFileTextBox)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.l2encInFileTextBox)
        Me.TabPage1.Controls.Add(Me.l2encOutFileTextBox)
        Me.TabPage1.Controls.Add(Me.DecWithL2AsmButton)
        Me.TabPage1.Controls.Add(Me.DecWithL2EncdecButton)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(367, 221)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Decoding"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 82)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "decrypt mode:"
        '
        'l2encParamsComboBox
        '
        Me.l2encParamsComboBox.FormattingEnabled = True
        Me.l2encParamsComboBox.Items.AddRange(New Object() {"-l", "-g", "-s", "-d"})
        Me.l2encParamsComboBox.Location = New System.Drawing.Point(10, 97)
        Me.l2encParamsComboBox.Name = "l2encParamsComboBox"
        Me.l2encParamsComboBox.Size = New System.Drawing.Size(87, 21)
        Me.l2encParamsComboBox.TabIndex = 1
        Me.l2encParamsComboBox.Text = "-s"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(100, 175)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Output .txt file:"
        '
        'l2asmOutFileTextBox
        '
        Me.l2asmOutFileTextBox.Location = New System.Drawing.Point(103, 190)
        Me.l2asmOutFileTextBox.Name = "l2asmOutFileTextBox"
        Me.l2asmOutFileTextBox.Size = New System.Drawing.Size(230, 20)
        Me.l2asmOutFileTextBox.TabIndex = 4
        Me.ToolTip.SetToolTip(Me.l2asmOutFileTextBox, "Double click to line for select file")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 22)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "l2disasm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(103, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Input .dat file:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(103, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Output .dat file:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 22)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "l2encdec"
        '
        'l2encInFileTextBox
        '
        Me.l2encInFileTextBox.Location = New System.Drawing.Point(106, 43)
        Me.l2encInFileTextBox.Name = "l2encInFileTextBox"
        Me.l2encInFileTextBox.Size = New System.Drawing.Size(230, 20)
        Me.l2encInFileTextBox.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.l2encInFileTextBox, "Double click to line for select file")
        '
        'l2encOutFileTextBox
        '
        Me.l2encOutFileTextBox.Location = New System.Drawing.Point(106, 81)
        Me.l2encOutFileTextBox.Name = "l2encOutFileTextBox"
        Me.l2encOutFileTextBox.Size = New System.Drawing.Size(230, 20)
        Me.l2encOutFileTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.l2encOutFileTextBox, "Double click to line for select file")
        '
        'DecWithL2AsmButton
        '
        Me.DecWithL2AsmButton.Location = New System.Drawing.Point(6, 155)
        Me.DecWithL2AsmButton.Name = "DecWithL2AsmButton"
        Me.DecWithL2AsmButton.Size = New System.Drawing.Size(91, 51)
        Me.DecWithL2AsmButton.TabIndex = 5
        Me.DecWithL2AsmButton.Text = "Unpack file with l2disasm"
        Me.DecWithL2AsmButton.UseVisualStyleBackColor = True
        '
        'DecWithL2EncdecButton
        '
        Me.DecWithL2EncdecButton.Location = New System.Drawing.Point(6, 28)
        Me.DecWithL2EncdecButton.Name = "DecWithL2EncdecButton"
        Me.DecWithL2EncdecButton.Size = New System.Drawing.Size(91, 51)
        Me.DecWithL2EncdecButton.TabIndex = 2
        Me.DecWithL2EncdecButton.Text = "Decrypt file with l2encdec"
        Me.DecWithL2EncdecButton.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.TxtToL2asmUseStructureButton)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.L2Adm2NormalButton)
        Me.TabPage2.Controls.Add(Me.L2asmToTxtUseStructureButton)
        Me.TabPage2.Controls.Add(Me.ProgressBar)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(367, 221)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "L2Asm <->Txt"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 176)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(82, 13)
        Me.Label24.TabIndex = 71
        Me.Label24.Text = "Progress status:"
        '
        'TxtToL2asmUseStructureButton
        '
        Me.TxtToL2asmUseStructureButton.Location = New System.Drawing.Point(149, 30)
        Me.TxtToL2asmUseStructureButton.Name = "TxtToL2asmUseStructureButton"
        Me.TxtToL2asmUseStructureButton.Size = New System.Drawing.Size(98, 35)
        Me.TxtToL2asmUseStructureButton.TabIndex = 68
        Me.TxtToL2asmUseStructureButton.Text = "Generate file with use structure file"
        Me.TxtToL2asmUseStructureButton.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.Location = New System.Drawing.Point(145, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 19)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = "Txt -> L2Asm"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 19)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "L2DisAsm -> Txt"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.TextBoxL2AsmAddComm)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.l2endecEncMetodComboBox)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.l2endecEncModeComboBox)
        Me.TabPage3.Controls.Add(Me.EncWithL2AsmButton)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.outl2asmToDatTextBox)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.inl2encdecToDatTextBox)
        Me.TabPage3.Controls.Add(Me.inl2asmToDatTextBox)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.EncWithL2EncdecButton)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(367, 221)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Encoding"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(100, 182)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 13)
        Me.Label23.TabIndex = 70
        Me.Label23.Text = "encrypt method:"
        '
        'l2endecEncMetodComboBox
        '
        Me.l2endecEncMetodComboBox.FormattingEnabled = True
        Me.l2endecEncMetodComboBox.Items.AddRange(New Object() {"111", "120", "121", "211", "212", "411", "412", "413"})
        Me.l2endecEncMetodComboBox.Location = New System.Drawing.Point(103, 197)
        Me.l2endecEncMetodComboBox.Name = "l2endecEncMetodComboBox"
        Me.l2endecEncMetodComboBox.Size = New System.Drawing.Size(87, 21)
        Me.l2endecEncMetodComboBox.TabIndex = 69
        Me.l2endecEncMetodComboBox.Text = "413"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 182)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 13)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "encrypt mode:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 22)
        Me.Label20.TabIndex = 66
        Me.Label20.Text = "l2asm"
        '
        'l2endecEncModeComboBox
        '
        Me.l2endecEncModeComboBox.FormattingEnabled = True
        Me.l2endecEncModeComboBox.Items.AddRange(New Object() {"-h", "-e"})
        Me.l2endecEncModeComboBox.Location = New System.Drawing.Point(10, 197)
        Me.l2endecEncModeComboBox.Name = "l2endecEncModeComboBox"
        Me.l2endecEncModeComboBox.Size = New System.Drawing.Size(71, 21)
        Me.l2endecEncModeComboBox.TabIndex = 1
        Me.l2endecEncModeComboBox.Text = "-h"
        '
        'EncWithL2AsmButton
        '
        Me.EncWithL2AsmButton.Location = New System.Drawing.Point(6, 30)
        Me.EncWithL2AsmButton.Name = "EncWithL2AsmButton"
        Me.EncWithL2AsmButton.Size = New System.Drawing.Size(91, 51)
        Me.EncWithL2AsmButton.TabIndex = 5
        Me.EncWithL2AsmButton.Text = "Pack file with l2asm"
        Me.EncWithL2AsmButton.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(100, 50)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(79, 13)
        Me.Label21.TabIndex = 68
        Me.Label21.Text = "Output .dat file:"
        '
        'outl2asmToDatTextBox
        '
        Me.outl2asmToDatTextBox.Location = New System.Drawing.Point(103, 65)
        Me.outl2asmToDatTextBox.Name = "outl2asmToDatTextBox"
        Me.outl2asmToDatTextBox.Size = New System.Drawing.Size(230, 20)
        Me.outl2asmToDatTextBox.TabIndex = 4
        Me.ToolTip.SetToolTip(Me.outl2asmToDatTextBox, "Double click to line for select file")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 105)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 22)
        Me.Label17.TabIndex = 65
        Me.Label17.Text = "l2encdec"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(100, 14)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Input .txt file:"
        '
        'inl2encdecToDatTextBox
        '
        Me.inl2encdecToDatTextBox.Location = New System.Drawing.Point(103, 144)
        Me.inl2encdecToDatTextBox.Name = "inl2encdecToDatTextBox"
        Me.inl2encdecToDatTextBox.Size = New System.Drawing.Size(230, 20)
        Me.inl2encdecToDatTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.inl2encdecToDatTextBox, "Double click to line for select file")
        '
        'inl2asmToDatTextBox
        '
        Me.inl2asmToDatTextBox.Location = New System.Drawing.Point(103, 29)
        Me.inl2asmToDatTextBox.Name = "inl2asmToDatTextBox"
        Me.inl2asmToDatTextBox.Size = New System.Drawing.Size(230, 20)
        Me.inl2asmToDatTextBox.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.inl2asmToDatTextBox, "Double click to line for select file")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(100, 129)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "Output .dat file:"
        '
        'EncWithL2EncdecButton
        '
        Me.EncWithL2EncdecButton.Location = New System.Drawing.Point(6, 129)
        Me.EncWithL2EncdecButton.Name = "EncWithL2EncdecButton"
        Me.EncWithL2EncdecButton.Size = New System.Drawing.Size(91, 51)
        Me.EncWithL2EncdecButton.TabIndex = 2
        Me.EncWithL2EncdecButton.Text = "Encrypt file with l2encdec"
        Me.EncWithL2EncdecButton.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.DDFDataGridView)
        Me.TabPage5.Controls.Add(Me.Label26)
        Me.TabPage5.Controls.Add(Me.PlainFileNameTextBox)
        Me.TabPage5.Controls.Add(Me.Label25)
        Me.TabPage5.Controls.Add(Me.EndTextBox)
        Me.TabPage5.Controls.Add(Me.Label16)
        Me.TabPage5.Controls.Add(Me.HeadTextBox)
        Me.TabPage5.Controls.Add(Me.LoadDDFButton)
        Me.TabPage5.Controls.Add(Me.MakeConfigsButton)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(367, 221)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "CFG Generator"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'DDFDataGridView
        '
        Me.DDFDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DDFDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.DDFDataGridView.Location = New System.Drawing.Point(6, 87)
        Me.DDFDataGridView.Name = "DDFDataGridView"
        Me.DDFDataGridView.Size = New System.Drawing.Size(355, 128)
        Me.DDFDataGridView.TabIndex = 8
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(183, 6)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 13)
        Me.Label26.TabIndex = 7
        Me.Label26.Text = "Plain text file name:"
        '
        'PlainFileNameTextBox
        '
        Me.PlainFileNameTextBox.Location = New System.Drawing.Point(183, 22)
        Me.PlainFileNameTextBox.Name = "PlainFileNameTextBox"
        Me.PlainFileNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PlainFileNameTextBox.TabIndex = 6
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(183, 44)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(47, 13)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "End tag:"
        '
        'EndTextBox
        '
        Me.EndTextBox.Location = New System.Drawing.Point(183, 60)
        Me.EndTextBox.Name = "EndTextBox"
        Me.EndTextBox.Size = New System.Drawing.Size(100, 20)
        Me.EndTextBox.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Start tag:"
        '
        'HeadTextBox
        '
        Me.HeadTextBox.Location = New System.Drawing.Point(6, 60)
        Me.HeadTextBox.Name = "HeadTextBox"
        Me.HeadTextBox.Size = New System.Drawing.Size(100, 20)
        Me.HeadTextBox.TabIndex = 2
        '
        'LoadDDFButton
        '
        Me.LoadDDFButton.Location = New System.Drawing.Point(6, 6)
        Me.LoadDDFButton.Name = "LoadDDFButton"
        Me.LoadDDFButton.Size = New System.Drawing.Size(90, 35)
        Me.LoadDDFButton.TabIndex = 1
        Me.LoadDDFButton.Text = "Load L2Disasm Txt file"
        Me.LoadDDFButton.UseVisualStyleBackColor = True
        '
        'MakeConfigsButton
        '
        Me.MakeConfigsButton.Location = New System.Drawing.Point(102, 6)
        Me.MakeConfigsButton.Name = "MakeConfigsButton"
        Me.MakeConfigsButton.Size = New System.Drawing.Size(75, 35)
        Me.MakeConfigsButton.TabIndex = 0
        Me.MakeConfigsButton.Text = "Make configs"
        Me.MakeConfigsButton.UseVisualStyleBackColor = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Name"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 150
        '
        'Column2
        '
        Me.Column2.HeaderText = "Left Symbol"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "Right Symbol"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 50
        '
        'Column4
        '
        Me.Column4.HeaderText = "Unicode"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 50
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 84)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(87, 26)
        Me.Label27.TabIndex = 72
        Me.Label27.Text = "L2Asm additional" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "command:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxL2AsmAddComm
        '
        Me.TextBoxL2AsmAddComm.Location = New System.Drawing.Point(103, 91)
        Me.TextBoxL2AsmAddComm.Name = "TextBoxL2AsmAddComm"
        Me.TextBoxL2AsmAddComm.Size = New System.Drawing.Size(230, 20)
        Me.TextBoxL2AsmAddComm.TabIndex = 71
        Me.TextBoxL2AsmAddComm.Text = "-l"
        Me.ToolTip.SetToolTip(Me.TextBoxL2AsmAddComm, "Double click to line for select file")
        '
        'DatDecoder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 295)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DatDecoder"
        Me.Text = ".Dat Converter"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.DDFDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents L2Adm2NormalButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents L2asmToTxtUseStructureButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents l2encInFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents l2asmDDFPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents l2disasmPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents l2ancdecPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DDFListComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DecWithL2AsmButton As System.Windows.Forms.Button
    Friend WithEvents DecWithL2EncdecButton As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents l2encOutFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents l2asmOutFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents l2asmPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents l2encParamsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtToL2asmUseStructureButton As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents l2endecEncModeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents EncWithL2AsmButton As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents outl2asmToDatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents inl2encdecToDatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents inl2asmToDatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents EncWithL2EncdecButton As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents l2endecEncMetodComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents MakeConfigsButton As System.Windows.Forms.Button
    Friend WithEvents LoadDDFButton As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PlainFileNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DDFDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents EndTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents HeadTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBoxL2AsmAddComm As System.Windows.Forms.TextBox
End Class
