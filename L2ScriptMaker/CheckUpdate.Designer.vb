<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckUpdate))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.StartButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.CheckStatLinkLabel = New System.Windows.Forms.LinkLabel
        Me.CheckStatLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.SendMailButton = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.MailFromTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MailSrvTextBox = New System.Windows.Forms.TextBox
        Me.SubjectTextBox = New System.Windows.Forms.TextBox
        Me.TextBox = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(109, 160)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(6, 6)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(143, 45)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "I want to check, maybe HF" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "made new release..."
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(33, 178)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 2
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(127, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(379, 189)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.CheckStatLinkLabel)
        Me.TabPage1.Controls.Add(Me.CheckStatLabel)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.StartButton)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(371, 163)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Updates"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Information about build:"
        '
        'CheckStatLinkLabel
        '
        Me.CheckStatLinkLabel.AutoSize = True
        Me.CheckStatLinkLabel.Location = New System.Drawing.Point(6, 93)
        Me.CheckStatLinkLabel.Name = "CheckStatLinkLabel"
        Me.CheckStatLinkLabel.Size = New System.Drawing.Size(0, 13)
        Me.CheckStatLinkLabel.TabIndex = 4
        '
        'CheckStatLabel
        '
        Me.CheckStatLabel.AutoSize = True
        Me.CheckStatLabel.Location = New System.Drawing.Point(6, 67)
        Me.CheckStatLabel.Name = "CheckStatLabel"
        Me.CheckStatLabel.Size = New System.Drawing.Size(90, 13)
        Me.CheckStatLabel.TabIndex = 3
        Me.CheckStatLabel.Text = "Version detected:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Check status:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SendMailButton)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.MailFromTextBox)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.MailSrvTextBox)
        Me.TabPage2.Controls.Add(Me.SubjectTextBox)
        Me.TabPage2.Controls.Add(Me.TextBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(371, 163)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Feedback"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SendMailButton
        '
        Me.SendMailButton.Location = New System.Drawing.Point(217, 89)
        Me.SendMailButton.Name = "SendMailButton"
        Me.SendMailButton.Size = New System.Drawing.Size(100, 39)
        Me.SendMailButton.TabIndex = 11
        Me.SendMailButton.Text = "Send Mail to tool owner"
        Me.SendMailButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(214, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "From:"
        '
        'MailFromTextBox
        '
        Me.MailFromTextBox.Location = New System.Drawing.Point(217, 63)
        Me.MailFromTextBox.Name = "MailFromTextBox"
        Me.MailFromTextBox.Size = New System.Drawing.Size(148, 20)
        Me.MailFromTextBox.TabIndex = 9
        Me.MailFromTextBox.Text = "tooluser@mailservername"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(214, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Mail Server:"
        '
        'MailSrvTextBox
        '
        Me.MailSrvTextBox.Location = New System.Drawing.Point(217, 23)
        Me.MailSrvTextBox.Name = "MailSrvTextBox"
        Me.MailSrvTextBox.Size = New System.Drawing.Size(148, 20)
        Me.MailSrvTextBox.TabIndex = 7
        Me.MailSrvTextBox.Text = "mailservername"
        '
        'SubjectTextBox
        '
        Me.SubjectTextBox.Location = New System.Drawing.Point(6, 6)
        Me.SubjectTextBox.Name = "SubjectTextBox"
        Me.SubjectTextBox.Size = New System.Drawing.Size(205, 20)
        Me.SubjectTextBox.TabIndex = 6
        Me.SubjectTextBox.Text = "L2ScriptMaker"
        '
        'TextBox
        '
        Me.TextBox.Location = New System.Drawing.Point(6, 32)
        Me.TextBox.Multiline = True
        Me.TextBox.Name = "TextBox"
        Me.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox.Size = New System.Drawing.Size(205, 125)
        Me.TextBox.TabIndex = 5
        Me.TextBox.Text = "Hi :)"
        '
        'CheckUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 210)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CheckUpdate"
        Me.Text = "Update support tool"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MailSrvTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SubjectTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MailFromTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SendMailButton As System.Windows.Forms.Button
    Friend WithEvents CheckStatLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents CheckStatLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
