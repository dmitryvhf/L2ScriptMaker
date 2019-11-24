<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class AiInjector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AiInjector))
        Me.Inject = New System.Windows.Forms.Button
        Me.Quit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.AiFile = New System.Windows.Forms.TextBox
        Me.FixFile = New System.Windows.Forms.TextBox
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.StatusBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SplitButton = New System.Windows.Forms.Button
        Me.MergeButton = New System.Windows.Forms.Button
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.FixOneClassBox = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.MergeCheckBox2 = New System.Windows.Forms.CheckBox
        Me.MergeCheckBox1 = New System.Windows.Forms.CheckBox
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.SplitClassTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CheckBoxUseList = New System.Windows.Forms.CheckBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ButtonFindExact = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBoxFindSelect = New System.Windows.Forms.TextBox
        Me.ButtonFindSelect = New System.Windows.Forms.Button
        Me.ButtonLoadClassList = New System.Windows.Forms.Button
        Me.CheckedListBox = New System.Windows.Forms.CheckedListBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Inject
        '
        Me.Inject.Location = New System.Drawing.Point(7, 150)
        Me.Inject.Name = "Inject"
        Me.Inject.Size = New System.Drawing.Size(75, 23)
        Me.Inject.TabIndex = 2
        Me.Inject.Text = "Inject fix"
        '
        'Quit
        '
        Me.Quit.Location = New System.Drawing.Point(20, 268)
        Me.Quit.Name = "Quit"
        Me.Quit.Size = New System.Drawing.Size(75, 23)
        Me.Quit.TabIndex = 3
        Me.Quit.Text = "Quit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "AI file:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fix file:"
        '
        'AiFile
        '
        Me.AiFile.Location = New System.Drawing.Point(7, 30)
        Me.AiFile.Name = "AiFile"
        Me.AiFile.ReadOnly = True
        Me.AiFile.Size = New System.Drawing.Size(420, 20)
        Me.AiFile.TabIndex = 8
        '
        'FixFile
        '
        Me.FixFile.Location = New System.Drawing.Point(7, 69)
        Me.FixFile.Name = "FixFile"
        Me.FixFile.ReadOnly = True
        Me.FixFile.Size = New System.Drawing.Size(420, 20)
        Me.FixFile.TabIndex = 9
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(119, 268)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(436, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 10
        '
        'StatusBox
        '
        Me.StatusBox.Location = New System.Drawing.Point(119, 242)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.ReadOnly = True
        Me.StatusBox.Size = New System.Drawing.Size(436, 20)
        Me.StatusBox.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(119, 226)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Status:"
        '
        'SplitButton
        '
        Me.SplitButton.Location = New System.Drawing.Point(7, 95)
        Me.SplitButton.Name = "SplitButton"
        Me.SplitButton.Size = New System.Drawing.Size(75, 23)
        Me.SplitButton.TabIndex = 13
        Me.SplitButton.Text = "Split"
        '
        'MergeButton
        '
        Me.MergeButton.Location = New System.Drawing.Point(7, 121)
        Me.MergeButton.Name = "MergeButton"
        Me.MergeButton.Size = New System.Drawing.Size(75, 23)
        Me.MergeButton.TabIndex = 14
        Me.MergeButton.Text = "Merge"
        '
        'FolderBrowserDialog
        '
        Me.FolderBrowserDialog.SelectedPath = "FolderBrowserDialog"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.Dragon
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(12, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(89, 198)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'FixOneClassBox
        '
        Me.FixOneClassBox.AutoSize = True
        Me.FixOneClassBox.Location = New System.Drawing.Point(88, 154)
        Me.FixOneClassBox.Name = "FixOneClassBox"
        Me.FixOneClassBox.Size = New System.Drawing.Size(89, 17)
        Me.FixOneClassBox.TabIndex = 48
        Me.FixOneClassBox.Text = "Fix One class"
        Me.FixOneClassBox.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 245)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "(support C4 scripts)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "AI.obj Builder"
        '
        'MergeCheckBox2
        '
        Me.MergeCheckBox2.AutoSize = True
        Me.MergeCheckBox2.Location = New System.Drawing.Point(252, 127)
        Me.MergeCheckBox2.Name = "MergeCheckBox2"
        Me.MergeCheckBox2.Size = New System.Drawing.Size(68, 17)
        Me.MergeCheckBox2.TabIndex = 57
        Me.MergeCheckBox2.Text = "Write log"
        Me.MergeCheckBox2.UseVisualStyleBackColor = True
        '
        'MergeCheckBox1
        '
        Me.MergeCheckBox1.AutoSize = True
        Me.MergeCheckBox1.Location = New System.Drawing.Point(88, 127)
        Me.MergeCheckBox1.Name = "MergeCheckBox1"
        Me.MergeCheckBox1.Size = New System.Drawing.Size(163, 17)
        Me.MergeCheckBox1.TabIndex = 59
        Me.MergeCheckBox1.Text = "Write class w/o dependence"
        Me.MergeCheckBox1.UseVisualStyleBackColor = True
        '
        'SplitClassTextBox
        '
        Me.SplitClassTextBox.Location = New System.Drawing.Point(132, 97)
        Me.SplitClassTextBox.Name = "SplitClassTextBox"
        Me.SplitClassTextBox.Size = New System.Drawing.Size(186, 20)
        Me.SplitClassTextBox.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(85, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Class:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(115, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(444, 211)
        Me.TabControl1.TabIndex = 62
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckBoxUseList)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Inject)
        Me.TabPage1.Controls.Add(Me.SplitClassTextBox)
        Me.TabPage1.Controls.Add(Me.MergeCheckBox1)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.MergeCheckBox2)
        Me.TabPage1.Controls.Add(Me.AiFile)
        Me.TabPage1.Controls.Add(Me.FixFile)
        Me.TabPage1.Controls.Add(Me.SplitButton)
        Me.TabPage1.Controls.Add(Me.FixOneClassBox)
        Me.TabPage1.Controls.Add(Me.MergeButton)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(436, 185)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Control Panel"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CheckBoxUseList
        '
        Me.CheckBoxUseList.AutoSize = True
        Me.CheckBoxUseList.Enabled = False
        Me.CheckBoxUseList.Location = New System.Drawing.Point(324, 99)
        Me.CheckBoxUseList.Name = "CheckBoxUseList"
        Me.CheckBoxUseList.Size = New System.Drawing.Size(103, 17)
        Me.CheckBoxUseList.TabIndex = 62
        Me.CheckBoxUseList.Text = "Use Classes List"
        Me.CheckBoxUseList.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ButtonFindExact)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.TextBoxFindSelect)
        Me.TabPage2.Controls.Add(Me.ButtonFindSelect)
        Me.TabPage2.Controls.Add(Me.ButtonLoadClassList)
        Me.TabPage2.Controls.Add(Me.CheckedListBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(436, 185)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Classes List"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ButtonFindExact
        '
        Me.ButtonFindExact.Location = New System.Drawing.Point(334, 128)
        Me.ButtonFindExact.Name = "ButtonFindExact"
        Me.ButtonFindExact.Size = New System.Drawing.Size(96, 23)
        Me.ButtonFindExact.TabIndex = 5
        Me.ButtonFindExact.Text = "Find Exact"
        Me.ButtonFindExact.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Find and select:"
        '
        'TextBoxFindSelect
        '
        Me.TextBoxFindSelect.Location = New System.Drawing.Point(95, 159)
        Me.TextBoxFindSelect.Name = "TextBoxFindSelect"
        Me.TextBoxFindSelect.Size = New System.Drawing.Size(232, 20)
        Me.TextBoxFindSelect.TabIndex = 3
        '
        'ButtonFindSelect
        '
        Me.ButtonFindSelect.Location = New System.Drawing.Point(333, 157)
        Me.ButtonFindSelect.Name = "ButtonFindSelect"
        Me.ButtonFindSelect.Size = New System.Drawing.Size(97, 23)
        Me.ButtonFindSelect.TabIndex = 2
        Me.ButtonFindSelect.Text = "Find and Select"
        Me.ButtonFindSelect.UseVisualStyleBackColor = True
        '
        'ButtonLoadClassList
        '
        Me.ButtonLoadClassList.Location = New System.Drawing.Point(333, 6)
        Me.ButtonLoadClassList.Name = "ButtonLoadClassList"
        Me.ButtonLoadClassList.Size = New System.Drawing.Size(100, 23)
        Me.ButtonLoadClassList.TabIndex = 1
        Me.ButtonLoadClassList.Text = "Analysing AI.obj"
        Me.ButtonLoadClassList.UseVisualStyleBackColor = True
        '
        'CheckedListBox
        '
        Me.CheckedListBox.FormattingEnabled = True
        Me.CheckedListBox.Location = New System.Drawing.Point(6, 6)
        Me.CheckedListBox.Name = "CheckedListBox"
        Me.CheckedListBox.Size = New System.Drawing.Size(321, 139)
        Me.CheckedListBox.TabIndex = 0
        '
        'AiInjector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 302)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Quit)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.ProgressBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AiInjector"
        Me.Text = "Lineage II Intelligence class Builder"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Inject As System.Windows.Forms.Button
    Friend WithEvents Quit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AiFile As System.Windows.Forms.TextBox
    Friend WithEvents FixFile As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitButton As System.Windows.Forms.Button
    Friend WithEvents MergeButton As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents FixOneClassBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MergeCheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents MergeCheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SplitClassTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CheckBoxUseList As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonLoadClassList As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFindSelect As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFindSelect As System.Windows.Forms.Button
    Friend WithEvents ButtonFindExact As System.Windows.Forms.Button
End Class
