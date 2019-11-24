<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AIDecompiler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AIDecompiler))
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.ButtonQuit = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.AIDstCodeTextBox = New System.Windows.Forms.TextBox()
        Me.AIDebugCodeTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ShowBugLineCheckBox = New System.Windows.Forms.CheckBox()
        Me.ShowCodeCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ShowFileCheckBox = New System.Windows.Forms.CheckBox()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.AiVarsCheckBox = New System.Windows.Forms.CheckBox()
        Me.FullDebugCodeCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SrcFileExtTextBox = New System.Windows.Forms.TextBox()
        Me.CheckBoxLa2GuardFormat = New System.Windows.Forms.CheckBox()
        Me.LoadFilesCheckBox = New System.Windows.Forms.CheckBox()
        Me.SourcePathTextBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SplitClassCheckBox = New System.Windows.Forms.CheckBox()
        Me.DecompiledPathTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.AppendFileCheckBox = New System.Windows.Forms.CheckBox()
        Me.outAiTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.inAiTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.FuncFileTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SrcAITextBox = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SavedFileLabel = New System.Windows.Forms.Label()
        Me.SaveCodeButton = New System.Windows.Forms.Button()
        Me.DataFromDebugCheckBox = New System.Windows.Forms.CheckBox()
        Me.GlobalProgressBar = New System.Windows.Forms.ProgressBar()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.FreyaAITempFixCheckBox = New System.Windows.Forms.CheckBox()
        Me.TabControl.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(27, 242)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 0
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(27, 362)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 1
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar.Location = New System.Drawing.Point(128, 433)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(547, 12)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 1
        '
        'AIDstCodeTextBox
        '
        Me.AIDstCodeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AIDstCodeTextBox.Location = New System.Drawing.Point(6, 19)
        Me.AIDstCodeTextBox.Multiline = True
        Me.AIDstCodeTextBox.Name = "AIDstCodeTextBox"
        Me.AIDstCodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AIDstCodeTextBox.Size = New System.Drawing.Size(527, 180)
        Me.AIDstCodeTextBox.TabIndex = 10
        '
        'AIDebugCodeTextBox
        '
        Me.AIDebugCodeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AIDebugCodeTextBox.Location = New System.Drawing.Point(6, 218)
        Me.AIDebugCodeTextBox.Multiline = True
        Me.AIDebugCodeTextBox.Name = "AIDebugCodeTextBox"
        Me.AIDebugCodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AIDebugCodeTextBox.Size = New System.Drawing.Size(527, 131)
        Me.AIDebugCodeTextBox.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 404)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 26)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Decompilation" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "status:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(566, 417)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "line is:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(125, 417)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "current code:"
        '
        'ShowBugLineCheckBox
        '
        Me.ShowBugLineCheckBox.AutoSize = True
        Me.ShowBugLineCheckBox.Checked = True
        Me.ShowBugLineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowBugLineCheckBox.Location = New System.Drawing.Point(9, 6)
        Me.ShowBugLineCheckBox.Name = "ShowBugLineCheckBox"
        Me.ShowBugLineCheckBox.Size = New System.Drawing.Size(252, 17)
        Me.ShowBugLineCheckBox.TabIndex = 16
        Me.ShowBugLineCheckBox.Text = "Show bugline on error (in 'Error Debug Window')"
        Me.ShowBugLineCheckBox.UseVisualStyleBackColor = True
        '
        'ShowCodeCheckBox
        '
        Me.ShowCodeCheckBox.AutoSize = True
        Me.ShowCodeCheckBox.Location = New System.Drawing.Point(9, 29)
        Me.ShowCodeCheckBox.Name = "ShowCodeCheckBox"
        Me.ShowCodeCheckBox.Size = New System.Drawing.Size(312, 17)
        Me.ShowCodeCheckBox.TabIndex = 17
        Me.ShowCodeCheckBox.Text = "Show decompiled code after processing (in Results Window)"
        Me.ShowCodeCheckBox.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Error Debug Window:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Decompiled Code:"
        '
        'ShowFileCheckBox
        '
        Me.ShowFileCheckBox.AutoSize = True
        Me.ShowFileCheckBox.Checked = True
        Me.ShowFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowFileCheckBox.Location = New System.Drawing.Point(9, 52)
        Me.ShowFileCheckBox.Name = "ShowFileCheckBox"
        Me.ShowFileCheckBox.Size = New System.Drawing.Size(308, 17)
        Me.ShowFileCheckBox.TabIndex = 20
        Me.ShowFileCheckBox.Text = "Open decompiled file after compilation (single file mode only)"
        Me.ShowFileCheckBox.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage3)
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Location = New System.Drawing.Point(128, 12)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(547, 389)
        Me.TabControl.TabIndex = 21
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FreyaAITempFixCheckBox)
        Me.TabPage2.Controls.Add(Me.AiVarsCheckBox)
        Me.TabPage2.Controls.Add(Me.FullDebugCodeCheckBox)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.SrcFileExtTextBox)
        Me.TabPage2.Controls.Add(Me.CheckBoxLa2GuardFormat)
        Me.TabPage2.Controls.Add(Me.LoadFilesCheckBox)
        Me.TabPage2.Controls.Add(Me.SourcePathTextBox)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.SplitClassCheckBox)
        Me.TabPage2.Controls.Add(Me.DecompiledPathTextBox)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.AppendFileCheckBox)
        Me.TabPage2.Controls.Add(Me.outAiTextBox)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.inAiTextBox)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Controls.Add(Me.FuncFileTextBox)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.ShowCodeCheckBox)
        Me.TabPage2.Controls.Add(Me.ShowFileCheckBox)
        Me.TabPage2.Controls.Add(Me.ShowBugLineCheckBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(539, 363)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'AiVarsCheckBox
        '
        Me.AiVarsCheckBox.AutoSize = True
        Me.AiVarsCheckBox.Location = New System.Drawing.Point(200, 116)
        Me.AiVarsCheckBox.Name = "AiVarsCheckBox"
        Me.AiVarsCheckBox.Size = New System.Drawing.Size(207, 30)
        Me.AiVarsCheckBox.TabIndex = 37
        Me.AiVarsCheckBox.Text = "handler/fetch_i/push_event/func_call" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " from config"
        Me.AiVarsCheckBox.UseVisualStyleBackColor = True
        '
        'FullDebugCodeCheckBox
        '
        Me.FullDebugCodeCheckBox.AutoSize = True
        Me.FullDebugCodeCheckBox.Location = New System.Drawing.Point(9, 75)
        Me.FullDebugCodeCheckBox.Name = "FullDebugCodeCheckBox"
        Me.FullDebugCodeCheckBox.Size = New System.Drawing.Size(248, 17)
        Me.FullDebugCodeCheckBox.TabIndex = 36
        Me.FullDebugCodeCheckBox.Text = "Full output debug code (power developer only!)"
        Me.FullDebugCodeCheckBox.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(366, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 26)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Default extentions" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for source files:"
        '
        'SrcFileExtTextBox
        '
        Me.SrcFileExtTextBox.Location = New System.Drawing.Point(417, 257)
        Me.SrcFileExtTextBox.Name = "SrcFileExtTextBox"
        Me.SrcFileExtTextBox.Size = New System.Drawing.Size(41, 20)
        Me.SrcFileExtTextBox.TabIndex = 34
        Me.SrcFileExtTextBox.Text = "*.txt"
        '
        'CheckBoxLa2GuardFormat
        '
        Me.CheckBoxLa2GuardFormat.AutoSize = True
        Me.CheckBoxLa2GuardFormat.Checked = True
        Me.CheckBoxLa2GuardFormat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxLa2GuardFormat.Location = New System.Drawing.Point(269, 75)
        Me.CheckBoxLa2GuardFormat.Name = "CheckBoxLa2GuardFormat"
        Me.CheckBoxLa2GuardFormat.Size = New System.Drawing.Size(144, 17)
        Me.CheckBoxLa2GuardFormat.TabIndex = 6
        Me.CheckBoxLa2GuardFormat.Text = "Write in La2Guard format"
        Me.CheckBoxLa2GuardFormat.UseVisualStyleBackColor = True
        '
        'LoadFilesCheckBox
        '
        Me.LoadFilesCheckBox.AutoSize = True
        Me.LoadFilesCheckBox.Location = New System.Drawing.Point(9, 221)
        Me.LoadFilesCheckBox.Name = "LoadFilesCheckBox"
        Me.LoadFilesCheckBox.Size = New System.Drawing.Size(312, 17)
        Me.LoadFilesCheckBox.TabIndex = 33
        Me.LoadFilesCheckBox.Text = "Load files from folder (one file can have more then one class)"
        Me.LoadFilesCheckBox.UseVisualStyleBackColor = True
        '
        'SourcePathTextBox
        '
        Me.SourcePathTextBox.Enabled = False
        Me.SourcePathTextBox.Location = New System.Drawing.Point(9, 257)
        Me.SourcePathTextBox.Name = "SourcePathTextBox"
        Me.SourcePathTextBox.Size = New System.Drawing.Size(404, 20)
        Me.SourcePathTextBox.TabIndex = 32
        Me.SourcePathTextBox.Text = "AIDecompiler\Source\"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 241)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(183, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Default source folder name with data:"
        '
        'SplitClassCheckBox
        '
        Me.SplitClassCheckBox.AutoSize = True
        Me.SplitClassCheckBox.Location = New System.Drawing.Point(9, 283)
        Me.SplitClassCheckBox.Name = "SplitClassCheckBox"
        Me.SplitClassCheckBox.Size = New System.Drawing.Size(296, 17)
        Me.SplitClassCheckBox.TabIndex = 30
        Me.SplitClassCheckBox.Text = "Save each class to different files (file name is class name)"
        Me.SplitClassCheckBox.UseVisualStyleBackColor = True
        '
        'DecompiledPathTextBox
        '
        Me.DecompiledPathTextBox.Enabled = False
        Me.DecompiledPathTextBox.Location = New System.Drawing.Point(9, 319)
        Me.DecompiledPathTextBox.Name = "DecompiledPathTextBox"
        Me.DecompiledPathTextBox.Size = New System.Drawing.Size(404, 20)
        Me.DecompiledPathTextBox.TabIndex = 29
        Me.DecompiledPathTextBox.Text = "AIDecompiler\Decompiled\"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 303)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(213, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Default target path name for splitting output:"
        '
        'AppendFileCheckBox
        '
        Me.AppendFileCheckBox.AutoSize = True
        Me.AppendFileCheckBox.Location = New System.Drawing.Point(200, 197)
        Me.AppendFileCheckBox.Name = "AppendFileCheckBox"
        Me.AppendFileCheckBox.Size = New System.Drawing.Size(248, 17)
        Me.AppendFileCheckBox.TabIndex = 27
        Me.AppendFileCheckBox.Text = "Append data to target file (overwrite for disable)"
        Me.AppendFileCheckBox.UseVisualStyleBackColor = True
        '
        'outAiTextBox
        '
        Me.outAiTextBox.Location = New System.Drawing.Point(9, 195)
        Me.outAiTextBox.Name = "outAiTextBox"
        Me.outAiTextBox.Size = New System.Drawing.Size(185, 20)
        Me.outAiTextBox.TabIndex = 26
        Me.outAiTextBox.Text = "ai_out.txt"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Default target file name:"
        '
        'inAiTextBox
        '
        Me.inAiTextBox.Location = New System.Drawing.Point(9, 155)
        Me.inAiTextBox.Name = "inAiTextBox"
        Me.inAiTextBox.Size = New System.Drawing.Size(185, 20)
        Me.inAiTextBox.TabIndex = 24
        Me.inAiTextBox.Text = "ai.obj"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Default source file name:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.L2ScriptMaker.My.Resources.Resources.hell_logo
        Me.PictureBox2.Location = New System.Drawing.Point(433, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 174)
        Me.PictureBox2.TabIndex = 20
        Me.PictureBox2.TabStop = False
        '
        'FuncFileTextBox
        '
        Me.FuncFileTextBox.Location = New System.Drawing.Point(9, 116)
        Me.FuncFileTextBox.Name = "FuncFileTextBox"
        Me.FuncFileTextBox.Size = New System.Drawing.Size(185, 20)
        Me.FuncFileTextBox.TabIndex = 22
        Me.FuncFileTextBox.Text = "AIDecompiler\ai_functions.txt"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(267, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Path to functions table file (Sauron decompiler standart)"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.SrcAITextBox)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(539, 363)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Manual data"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Source Code:"
        '
        'SrcAITextBox
        '
        Me.SrcAITextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SrcAITextBox.Location = New System.Drawing.Point(3, 19)
        Me.SrcAITextBox.Multiline = True
        Me.SrcAITextBox.Name = "SrcAITextBox"
        Me.SrcAITextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.SrcAITextBox.Size = New System.Drawing.Size(527, 332)
        Me.SrcAITextBox.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.AIDstCodeTextBox)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.AIDebugCodeTextBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(539, 363)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Results"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 37)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 160)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'SavedFileLabel
        '
        Me.SavedFileLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SavedFileLabel.AutoSize = True
        Me.SavedFileLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SavedFileLabel.Location = New System.Drawing.Point(125, 404)
        Me.SavedFileLabel.Name = "SavedFileLabel"
        Me.SavedFileLabel.Size = New System.Drawing.Size(58, 13)
        Me.SavedFileLabel.TabIndex = 22
        Me.SavedFileLabel.Text = "Saved file:"
        '
        'SaveCodeButton
        '
        Me.SaveCodeButton.Location = New System.Drawing.Point(27, 333)
        Me.SaveCodeButton.Name = "SaveCodeButton"
        Me.SaveCodeButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveCodeButton.TabIndex = 23
        Me.SaveCodeButton.Text = "Save Code"
        Me.SaveCodeButton.UseVisualStyleBackColor = True
        '
        'DataFromDebugCheckBox
        '
        Me.DataFromDebugCheckBox.AutoSize = True
        Me.DataFromDebugCheckBox.Location = New System.Drawing.Point(12, 271)
        Me.DataFromDebugCheckBox.Name = "DataFromDebugCheckBox"
        Me.DataFromDebugCheckBox.Size = New System.Drawing.Size(99, 43)
        Me.DataFromDebugCheckBox.TabIndex = 24
        Me.DataFromDebugCheckBox.Text = "Decompile from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Manual data" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Window"
        Me.DataFromDebugCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DataFromDebugCheckBox.UseVisualStyleBackColor = True
        '
        'GlobalProgressBar
        '
        Me.GlobalProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GlobalProgressBar.Location = New System.Drawing.Point(128, 448)
        Me.GlobalProgressBar.Name = "GlobalProgressBar"
        Me.GlobalProgressBar.Size = New System.Drawing.Size(547, 12)
        Me.GlobalProgressBar.Step = 1
        Me.GlobalProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.GlobalProgressBar.TabIndex = 25
        '
        'AboutButton
        '
        Me.AboutButton.Location = New System.Drawing.Point(27, 215)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(75, 23)
        Me.AboutButton.TabIndex = 1
        Me.AboutButton.Text = "About"
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'FreyaAITempFixCheckBox
        '
        Me.FreyaAITempFixCheckBox.AutoSize = True
        Me.FreyaAITempFixCheckBox.Location = New System.Drawing.Point(200, 145)
        Me.FreyaAITempFixCheckBox.Name = "FreyaAITempFixCheckBox"
        Me.FreyaAITempFixCheckBox.Size = New System.Drawing.Size(143, 17)
        Me.FreyaAITempFixCheckBox.TabIndex = 38
        Me.FreyaAITempFixCheckBox.Text = "FreyaAI fix (temporary fix)"
        Me.FreyaAITempFixCheckBox.UseVisualStyleBackColor = True
        '
        'AIDecompiler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 465)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.GlobalProgressBar)
        Me.Controls.Add(Me.DataFromDebugCheckBox)
        Me.Controls.Add(Me.SaveCodeButton)
        Me.Controls.Add(Me.SavedFileLabel)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AIDecompiler"
        Me.Text = "L2ScriptMaker: Lineage II Cronicles 4 AI.obj Decompiler"
        Me.TabControl.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents AIDstCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AIDebugCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ShowBugLineCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ShowCodeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ShowFileCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents FuncFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents AppendFileCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents outAiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents inAiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DecompiledPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SplitClassCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SavedFileLabel As System.Windows.Forms.Label
    Friend WithEvents LoadFilesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SourcePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents SrcFileExtTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FullDebugCodeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SaveCodeButton As System.Windows.Forms.Button
    Friend WithEvents DataFromDebugCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GlobalProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SrcAITextBox As System.Windows.Forms.TextBox
    Friend WithEvents AboutButton As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxLa2GuardFormat As System.Windows.Forms.CheckBox
    Friend WithEvents AiVarsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FreyaAITempFixCheckBox As System.Windows.Forms.CheckBox

End Class
