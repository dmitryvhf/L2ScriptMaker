<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToolIncrementer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolIncrementer))
        Me.StartButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Use2RadioButton = New System.Windows.Forms.RadioButton
        Me.Use1RadioButton = New System.Windows.Forms.RadioButton
        Me.MultValueTextBox = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.ParamAddNameCheckBox = New System.Windows.Forms.CheckBox
        Me.StartValueTextBox = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.RightTextBox = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.LeftTextBox = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.IncValueTextBox = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.EndLevelTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.StartLevelTextBox = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ParamNameTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ResultTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(30, 174)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(30, 203)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 2
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 156)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(129, 44)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(318, 197)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Use2RadioButton)
        Me.TabPage1.Controls.Add(Me.Use1RadioButton)
        Me.TabPage1.Controls.Add(Me.MultValueTextBox)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.ParamAddNameCheckBox)
        Me.TabPage1.Controls.Add(Me.StartValueTextBox)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.RightTextBox)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.LeftTextBox)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.IncValueTextBox)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.EndLevelTextBox)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.StartLevelTextBox)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.ParamNameTextBox)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(310, 171)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Use2RadioButton
        '
        Me.Use2RadioButton.AutoSize = True
        Me.Use2RadioButton.Location = New System.Drawing.Point(92, 125)
        Me.Use2RadioButton.Name = "Use2RadioButton"
        Me.Use2RadioButton.Size = New System.Drawing.Size(87, 17)
        Me.Use2RadioButton.TabIndex = 21
        Me.Use2RadioButton.Text = "Use multiplier"
        Me.Use2RadioButton.UseVisualStyleBackColor = True
        '
        'Use1RadioButton
        '
        Me.Use1RadioButton.AutoSize = True
        Me.Use1RadioButton.Checked = True
        Me.Use1RadioButton.Location = New System.Drawing.Point(92, 108)
        Me.Use1RadioButton.Name = "Use1RadioButton"
        Me.Use1RadioButton.Size = New System.Drawing.Size(93, 17)
        Me.Use1RadioButton.TabIndex = 20
        Me.Use1RadioButton.TabStop = True
        Me.Use1RadioButton.Text = "Use increment"
        Me.Use1RadioButton.UseVisualStyleBackColor = True
        '
        'MultValueTextBox
        '
        Me.MultValueTextBox.Location = New System.Drawing.Point(9, 136)
        Me.MultValueTextBox.Name = "MultValueTextBox"
        Me.MultValueTextBox.ReadOnly = True
        Me.MultValueTextBox.Size = New System.Drawing.Size(68, 20)
        Me.MultValueTextBox.TabIndex = 18
        Me.MultValueTextBox.Text = "1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Multiplier value:"
        '
        'ParamAddNameCheckBox
        '
        Me.ParamAddNameCheckBox.AutoSize = True
        Me.ParamAddNameCheckBox.Checked = True
        Me.ParamAddNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ParamAddNameCheckBox.Location = New System.Drawing.Point(118, 19)
        Me.ParamAddNameCheckBox.Name = "ParamAddNameCheckBox"
        Me.ParamAddNameCheckBox.Size = New System.Drawing.Size(111, 17)
        Me.ParamAddNameCheckBox.TabIndex = 1
        Me.ParamAddNameCheckBox.Text = "Add level to name"
        Me.ParamAddNameCheckBox.UseVisualStyleBackColor = True
        '
        'StartValueTextBox
        '
        Me.StartValueTextBox.Location = New System.Drawing.Point(136, 58)
        Me.StartValueTextBox.Name = "StartValueTextBox"
        Me.StartValueTextBox.Size = New System.Drawing.Size(55, 20)
        Me.StartValueTextBox.TabIndex = 6
        Me.StartValueTextBox.Text = "1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(133, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Start value:"
        '
        'RightTextBox
        '
        Me.RightTextBox.Location = New System.Drawing.Point(275, 19)
        Me.RightTextBox.Name = "RightTextBox"
        Me.RightTextBox.Size = New System.Drawing.Size(25, 20)
        Me.RightTextBox.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(272, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Right:"
        '
        'LeftTextBox
        '
        Me.LeftTextBox.Location = New System.Drawing.Point(241, 19)
        Me.LeftTextBox.Name = "LeftTextBox"
        Me.LeftTextBox.Size = New System.Drawing.Size(25, 20)
        Me.LeftTextBox.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(238, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Left:"
        '
        'IncValueTextBox
        '
        Me.IncValueTextBox.Location = New System.Drawing.Point(9, 97)
        Me.IncValueTextBox.Name = "IncValueTextBox"
        Me.IncValueTextBox.Size = New System.Drawing.Size(68, 20)
        Me.IncValueTextBox.TabIndex = 7
        Me.IncValueTextBox.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Increment value:"
        '
        'EndLevelTextBox
        '
        Me.EndLevelTextBox.Location = New System.Drawing.Point(76, 58)
        Me.EndLevelTextBox.Name = "EndLevelTextBox"
        Me.EndLevelTextBox.Size = New System.Drawing.Size(55, 20)
        Me.EndLevelTextBox.TabIndex = 5
        Me.EndLevelTextBox.Text = "10"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(73, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "End level:"
        '
        'StartLevelTextBox
        '
        Me.StartLevelTextBox.Location = New System.Drawing.Point(9, 58)
        Me.StartLevelTextBox.Name = "StartLevelTextBox"
        Me.StartLevelTextBox.Size = New System.Drawing.Size(58, 20)
        Me.StartLevelTextBox.TabIndex = 4
        Me.StartLevelTextBox.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Start level:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Param additional name:"
        '
        'ParamNameTextBox
        '
        Me.ParamNameTextBox.Location = New System.Drawing.Point(9, 19)
        Me.ParamNameTextBox.Name = "ParamNameTextBox"
        Me.ParamNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ParamNameTextBox.TabIndex = 0
        Me.ParamNameTextBox.Text = "param_"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Param Name:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ResultTextBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(310, 171)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Results"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ResultTextBox
        '
        Me.ResultTextBox.Location = New System.Drawing.Point(6, 6)
        Me.ResultTextBox.Multiline = True
        Me.ResultTextBox.Name = "ResultTextBox"
        Me.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ResultTextBox.Size = New System.Drawing.Size(298, 144)
        Me.ResultTextBox.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(126, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "(simple tool, for all scripts)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(126, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 16)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Value Incrementer Tool"
        '
        'ToolIncrementer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 253)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ToolIncrementer"
        Me.Text = "Value Incrementer Tool"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ResultTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ParamNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents IncValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents EndLevelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents StartLevelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LeftTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents StartValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ParamAddNameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MultValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Use2RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Use1RadioButton As System.Windows.Forms.RadioButton
End Class
