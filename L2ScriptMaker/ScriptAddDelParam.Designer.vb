<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptAddDelParam
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
        Me.ButtonQuit = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ComboBoxParamList = New System.Windows.Forms.ComboBox()
        Me.ComboBoxEditMode = New System.Windows.Forms.ComboBox()
        Me.ButtonStructLoad = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBoxAddParam = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonAddParamGo = New System.Windows.Forms.Button()
        Me.ButtonDelParamGo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxDelMode = New System.Windows.Forms.ComboBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxAddParamValue = New System.Windows.Forms.TextBox()
        Me.CheckBoxAddParamOverwrite = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(12, 192)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(100, 23)
        Me.ButtonQuit.TabIndex = 1
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ComboBoxParamList
        '
        Me.ComboBoxParamList.FormattingEnabled = True
        Me.ComboBoxParamList.Location = New System.Drawing.Point(137, 57)
        Me.ComboBoxParamList.Name = "ComboBoxParamList"
        Me.ComboBoxParamList.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxParamList.TabIndex = 3
        '
        'ComboBoxEditMode
        '
        Me.ComboBoxEditMode.AutoCompleteCustomSource.AddRange(New String() {"Before", "After"})
        Me.ComboBoxEditMode.FormattingEnabled = True
        Me.ComboBoxEditMode.Items.AddRange(New Object() {"Before", "After"})
        Me.ComboBoxEditMode.Location = New System.Drawing.Point(282, 30)
        Me.ComboBoxEditMode.Name = "ComboBoxEditMode"
        Me.ComboBoxEditMode.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxEditMode.TabIndex = 4
        Me.ComboBoxEditMode.Text = "Before"
        '
        'ButtonStructLoad
        '
        Me.ButtonStructLoad.Location = New System.Drawing.Point(137, 12)
        Me.ButtonStructLoad.Name = "ButtonStructLoad"
        Me.ButtonStructLoad.Size = New System.Drawing.Size(100, 23)
        Me.ButtonStructLoad.TabIndex = 5
        Me.ButtonStructLoad.Text = "Structure load"
        Me.ButtonStructLoad.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 158)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'TextBoxAddParam
        '
        Me.TextBoxAddParam.Location = New System.Drawing.Point(282, 70)
        Me.TextBoxAddParam.Name = "TextBoxAddParam"
        Me.TextBoxAddParam.Size = New System.Drawing.Size(168, 20)
        Me.TextBoxAddParam.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(137, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Parameter list:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(282, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Add Mode:"
        '
        'ButtonAddParamGo
        '
        Me.ButtonAddParamGo.Location = New System.Drawing.Point(282, 152)
        Me.ButtonAddParamGo.Name = "ButtonAddParamGo"
        Me.ButtonAddParamGo.Size = New System.Drawing.Size(100, 23)
        Me.ButtonAddParamGo.TabIndex = 10
        Me.ButtonAddParamGo.Text = "Add parameter"
        Me.ButtonAddParamGo.UseVisualStyleBackColor = True
        '
        'ButtonDelParamGo
        '
        Me.ButtonDelParamGo.Location = New System.Drawing.Point(137, 152)
        Me.ButtonDelParamGo.Name = "ButtonDelParamGo"
        Me.ButtonDelParamGo.Size = New System.Drawing.Size(100, 23)
        Me.ButtonDelParamGo.TabIndex = 14
        Me.ButtonDelParamGo.Text = "Delete parameter"
        Me.ButtonDelParamGo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(137, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Delete Mode:"
        '
        'ComboBoxDelMode
        '
        Me.ComboBoxDelMode.AutoCompleteCustomSource.AddRange(New String() {"Delete param", "Delete value"})
        Me.ComboBoxDelMode.FormattingEnabled = True
        Me.ComboBoxDelMode.Items.AddRange(New Object() {"Delete value", "Delete param"})
        Me.ComboBoxDelMode.Location = New System.Drawing.Point(137, 125)
        Me.ComboBoxDelMode.Name = "ComboBoxDelMode"
        Me.ComboBoxDelMode.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxDelMode.TabIndex = 11
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(137, 192)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(313, 23)
        Me.ProgressBar.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(282, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "New param name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(282, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Param default value:"
        '
        'TextBoxAddParamValue
        '
        Me.TextBoxAddParamValue.Location = New System.Drawing.Point(282, 109)
        Me.TextBoxAddParamValue.Name = "TextBoxAddParamValue"
        Me.TextBoxAddParamValue.Size = New System.Drawing.Size(168, 20)
        Me.TextBoxAddParamValue.TabIndex = 17
        '
        'CheckBoxAddParamOverwrite
        '
        Me.CheckBoxAddParamOverwrite.AutoSize = True
        Me.CheckBoxAddParamOverwrite.Location = New System.Drawing.Point(282, 135)
        Me.CheckBoxAddParamOverwrite.Name = "CheckBoxAddParamOverwrite"
        Me.CheckBoxAddParamOverwrite.Size = New System.Drawing.Size(147, 17)
        Me.CheckBoxAddParamOverwrite.TabIndex = 19
        Me.CheckBoxAddParamOverwrite.Text = "Overwrite value to default"
        Me.CheckBoxAddParamOverwrite.UseVisualStyleBackColor = True
        '
        'ScriptAddDelParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 226)
        Me.Controls.Add(Me.CheckBoxAddParamOverwrite)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxAddParamValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ButtonDelParamGo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBoxDelMode)
        Me.Controls.Add(Me.ButtonAddParamGo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxAddParam)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonStructLoad)
        Me.Controls.Add(Me.ComboBoxEditMode)
        Me.Controls.Add(Me.ComboBoxParamList)
        Me.Controls.Add(Me.ButtonQuit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ScriptAddDelParam"
        Me.Text = "Scripts: Add/Delete parameters in scripts"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ComboBoxParamList As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxEditMode As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonStructLoad As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBoxAddParam As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonAddParamGo As System.Windows.Forms.Button
    Friend WithEvents ButtonDelParamGo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDelMode As System.Windows.Forms.ComboBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAddParamValue As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxAddParamOverwrite As System.Windows.Forms.CheckBox
End Class
