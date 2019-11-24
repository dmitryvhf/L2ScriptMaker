<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ItemPchMaker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemPchMaker))
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.StartButton = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.StopError = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ItemCacheScript = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 70)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(369, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 8
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(291, 41)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(91, 23)
        Me.ButtonQuit.TabIndex = 10
        Me.ButtonQuit.Text = "Exit"
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(12, 12)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(160, 23)
        Me.StartButton.TabIndex = 9
        Me.StartButton.Text = "Generate Pch"
        '
        'StopError
        '
        Me.StopError.AutoSize = True
        Me.StopError.Checked = True
        Me.StopError.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StopError.Location = New System.Drawing.Point(179, 43)
        Me.StopError.Name = "StopError"
        Me.StopError.Size = New System.Drawing.Size(87, 17)
        Me.StopError.TabIndex = 12
        Me.StopError.Text = "Stop on error"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(241, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Item_Pch/Pch2 Maker"
        '
        'ItemCacheScript
        '
        Me.ItemCacheScript.Location = New System.Drawing.Point(12, 41)
        Me.ItemCacheScript.Name = "ItemCacheScript"
        Me.ItemCacheScript.Size = New System.Drawing.Size(160, 23)
        Me.ItemCacheScript.TabIndex = 44
        Me.ItemCacheScript.Text = "Generate CacheScript"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(241, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "(support C4 scripts)"
        '
        'ItemPchMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 99)
        Me.Controls.Add(Me.ItemCacheScript)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StopError)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ItemPchMaker"
        Me.Text = "ItemPchMaker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StopError As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ItemCacheScript As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
