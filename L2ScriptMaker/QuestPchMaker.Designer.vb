<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuestPchMaker
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QuestPchMaker))
        Me.Label1 = New System.Windows.Forms.Label
        Me.QuestCacheScript = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.ButtonExit = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.QuestPchButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.StatusLabel = New System.Windows.Forms.Label
        Me.MakeUndefinedBox = New System.Windows.Forms.CheckBox
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(243, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "(support C4 scripts)"
        '
        'QuestCacheScript
        '
        Me.QuestCacheScript.Location = New System.Drawing.Point(8, 37)
        Me.QuestCacheScript.Name = "QuestCacheScript"
        Me.QuestCacheScript.Size = New System.Drawing.Size(160, 23)
        Me.QuestCacheScript.TabIndex = 54
        Me.QuestCacheScript.Text = "Generate CacheScript"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(243, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 16)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Questcomp-E Maker"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(8, 83)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(369, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 49
        '
        'ButtonExit
        '
        Me.ButtonExit.Location = New System.Drawing.Point(286, 37)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(91, 23)
        Me.ButtonExit.TabIndex = 51
        Me.ButtonExit.Text = "Exit"
        '
        'QuestPchButton
        '
        Me.QuestPchButton.Location = New System.Drawing.Point(8, 8)
        Me.QuestPchButton.Name = "QuestPchButton"
        Me.QuestPchButton.Size = New System.Drawing.Size(160, 23)
        Me.QuestPchButton.TabIndex = 56
        Me.QuestPchButton.Text = "Generate pch/pch2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Status:"
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.StatusLabel.Location = New System.Drawing.Point(57, 67)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 14)
        Me.StatusLabel.TabIndex = 58
        '
        'MakeUndefinedBox
        '
        Me.MakeUndefinedBox.AutoSize = True
        Me.MakeUndefinedBox.Location = New System.Drawing.Point(174, -1)
        Me.MakeUndefinedBox.Name = "MakeUndefinedBox"
        Me.MakeUndefinedBox.Size = New System.Drawing.Size(73, 43)
        Me.MakeUndefinedBox.TabIndex = 59
        Me.MakeUndefinedBox.Text = "Create" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "undefined" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "quest"
        Me.ToolTip.SetToolTip(Me.MakeUndefinedBox, "All quest not included in questdata-e" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "will be created and defined into" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "questpch" & _
                "/pch config files." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "New quest will be named" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[autoquestgen_QuestID]")
        Me.MakeUndefinedBox.UseVisualStyleBackColor = True
        '
        'QuestPchMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 118)
        Me.Controls.Add(Me.MakeUndefinedBox)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.QuestPchButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.QuestCacheScript)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ButtonExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "QuestPchMaker"
        Me.Text = "QuestPch/Pch2/Comp-e Builder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents QuestCacheScript As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents QuestPchButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents MakeUndefinedBox As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
End Class
