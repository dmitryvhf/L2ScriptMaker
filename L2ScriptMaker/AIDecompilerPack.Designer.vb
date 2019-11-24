<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AIDecompilerPack
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
        Me.CollectFuncButton = New System.Windows.Forms.Button()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.CollectHandlerButton = New System.Windows.Forms.Button()
        Me.CollectEventButton = New System.Windows.Forms.Button()
        Me.CollectFetchButton = New System.Windows.Forms.Button()
        Me.FetchDefaultCopyCheckBox = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CollectFuncButton
        '
        Me.CollectFuncButton.Location = New System.Drawing.Point(128, 12)
        Me.CollectFuncButton.Name = "CollectFuncButton"
        Me.CollectFuncButton.Size = New System.Drawing.Size(109, 23)
        Me.CollectFuncButton.TabIndex = 0
        Me.CollectFuncButton.Text = "Collect Func_call's"
        Me.CollectFuncButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(277, 12)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 1
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 178)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(340, 23)
        Me.ProgressBar.TabIndex = 2
        '
        'CollectHandlerButton
        '
        Me.CollectHandlerButton.Location = New System.Drawing.Point(128, 41)
        Me.CollectHandlerButton.Name = "CollectHandlerButton"
        Me.CollectHandlerButton.Size = New System.Drawing.Size(109, 22)
        Me.CollectHandlerButton.TabIndex = 3
        Me.CollectHandlerButton.Text = "Collect Handler's"
        Me.CollectHandlerButton.UseVisualStyleBackColor = True
        '
        'CollectEventButton
        '
        Me.CollectEventButton.Location = New System.Drawing.Point(128, 69)
        Me.CollectEventButton.Name = "CollectEventButton"
        Me.CollectEventButton.Size = New System.Drawing.Size(109, 23)
        Me.CollectEventButton.TabIndex = 4
        Me.CollectEventButton.Text = "Collect push_event"
        Me.CollectEventButton.UseVisualStyleBackColor = True
        '
        'CollectFetchButton
        '
        Me.CollectFetchButton.Location = New System.Drawing.Point(128, 98)
        Me.CollectFetchButton.Name = "CollectFetchButton"
        Me.CollectFetchButton.Size = New System.Drawing.Size(109, 23)
        Me.CollectFetchButton.TabIndex = 5
        Me.CollectFetchButton.Text = "Collect fetch_i"
        Me.CollectFetchButton.UseVisualStyleBackColor = True
        '
        'FetchDefaultCopyCheckBox
        '
        Me.FetchDefaultCopyCheckBox.AutoSize = True
        Me.FetchDefaultCopyCheckBox.Location = New System.Drawing.Point(150, 127)
        Me.FetchDefaultCopyCheckBox.Name = "FetchDefaultCopyCheckBox"
        Me.FetchDefaultCopyCheckBox.Size = New System.Drawing.Size(161, 30)
        Me.FetchDefaultCopyCheckBox.TabIndex = 6
        Me.FetchDefaultCopyCheckBox.Text = "Write record for defaut value" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "as additional record"
        Me.FetchDefaultCopyCheckBox.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 160)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'AIDecompilerPack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 218)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.FetchDefaultCopyCheckBox)
        Me.Controls.Add(Me.CollectFetchButton)
        Me.Controls.Add(Me.CollectEventButton)
        Me.Controls.Add(Me.CollectHandlerButton)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.CollectFuncButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AIDecompilerPack"
        Me.Text = "L2ScriptMaker: Lineage II AI.obj Decompiler Tool Pack"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CollectFuncButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CollectHandlerButton As System.Windows.Forms.Button
    Friend WithEvents CollectEventButton As System.Windows.Forms.Button
    Friend WithEvents CollectFetchButton As System.Windows.Forms.Button
    Friend WithEvents FetchDefaultCopyCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
