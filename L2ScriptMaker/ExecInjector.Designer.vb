<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ExecInjector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExecInjector))
        Me.InjectButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.FixName = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ExecName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Help = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.HelpButton2 = New System.Windows.Forms.Button
        Me.RecoveryBox = New System.Windows.Forms.CheckBox
        Me.IsOffset = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'InjectButton
        '
        Me.InjectButton.Location = New System.Drawing.Point(12, 96)
        Me.InjectButton.Name = "InjectButton"
        Me.InjectButton.Size = New System.Drawing.Size(75, 23)
        Me.InjectButton.TabIndex = 0
        Me.InjectButton.Text = "Inject"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(338, 93)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 1
        Me.QuitButton.Text = "Quit"
        '
        'FixName
        '
        Me.FixName.Location = New System.Drawing.Point(12, 70)
        Me.FixName.Name = "FixName"
        Me.FixName.ReadOnly = True
        Me.FixName.Size = New System.Drawing.Size(300, 20)
        Me.FixName.TabIndex = 2
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ExecName
        '
        Me.ExecName.Location = New System.Drawing.Point(12, 25)
        Me.ExecName.Name = "ExecName"
        Me.ExecName.ReadOnly = True
        Me.ExecName.Size = New System.Drawing.Size(300, 20)
        Me.ExecName.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Exec file to fix:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fix data file:"
        '
        'Help
        '
        Me.Help.Location = New System.Drawing.Point(13, 96)
        Me.Help.Name = "Help"
        Me.Help.Size = New System.Drawing.Size(75, 23)
        Me.Help.TabIndex = 7
        Me.Help.Text = "Help"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Help"
        '
        'HelpButton2
        '
        Me.HelpButton2.Location = New System.Drawing.Point(237, 93)
        Me.HelpButton2.Name = "HelpButton2"
        Me.HelpButton2.Size = New System.Drawing.Size(75, 23)
        Me.HelpButton2.TabIndex = 6
        Me.HelpButton2.Text = "Help"
        '
        'RecoveryBox
        '
        Me.RecoveryBox.AutoSize = True
        Me.RecoveryBox.Location = New System.Drawing.Point(318, 25)
        Me.RecoveryBox.Name = "RecoveryBox"
        Me.RecoveryBox.Size = New System.Drawing.Size(88, 17)
        Me.RecoveryBox.TabIndex = 7
        Me.RecoveryBox.Text = "Recovery Fix"
        '
        'IsOffset
        '
        Me.IsOffset.AutoSize = True
        Me.IsOffset.Location = New System.Drawing.Point(318, 48)
        Me.IsOffset.Name = "IsOffset"
        Me.IsOffset.Size = New System.Drawing.Size(101, 17)
        Me.IsOffset.TabIndex = 8
        Me.IsOffset.Text = "is 40000h offset"
        '
        'ExecInjector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 128)
        Me.Controls.Add(Me.IsOffset)
        Me.Controls.Add(Me.RecoveryBox)
        Me.Controls.Add(Me.HelpButton2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ExecName)
        Me.Controls.Add(Me.FixName)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.InjectButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ExecInjector"
        Me.Text = "ExecInjector"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InjectButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents FixName As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ExecName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Help As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents HelpButton2 As System.Windows.Forms.Button
    Friend WithEvents RecoveryBox As System.Windows.Forms.CheckBox
    Friend WithEvents IsOffset As System.Windows.Forms.CheckBox
End Class
