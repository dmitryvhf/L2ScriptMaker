<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Eula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Eula))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Accept2Button = New System.Windows.Forms.Button
        Me.DeclineButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(404, 169)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Accept2Button
        '
        Me.Accept2Button.Location = New System.Drawing.Point(129, 187)
        Me.Accept2Button.Name = "Accept2Button"
        Me.Accept2Button.Size = New System.Drawing.Size(75, 23)
        Me.Accept2Button.TabIndex = 1
        Me.Accept2Button.Text = "Accept"
        Me.Accept2Button.UseVisualStyleBackColor = True
        '
        'DeclineButton
        '
        Me.DeclineButton.Location = New System.Drawing.Point(219, 187)
        Me.DeclineButton.Name = "DeclineButton"
        Me.DeclineButton.Size = New System.Drawing.Size(75, 23)
        Me.DeclineButton.TabIndex = 2
        Me.DeclineButton.Text = "Decline"
        Me.DeclineButton.UseVisualStyleBackColor = True
        '
        'Eula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 218)
        Me.Controls.Add(Me.DeclineButton)
        Me.Controls.Add(Me.Accept2Button)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Eula"
        Me.Text = "Eula"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Accept2Button As System.Windows.Forms.Button
    Friend WithEvents DeclineButton As System.Windows.Forms.Button
End Class
