<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HtmlDesigner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HtmlDesigner))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ComboBoxShortCuts = New System.Windows.Forms.ComboBox
        Me.TextBoxEdit = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TextBoxResult = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.ButtonLoad = New System.Windows.Forms.Button
        Me.ButtonSave = New System.Windows.Forms.Button
        Me.ButtonResult = New System.Windows.Forms.Button
        Me.WebBrowserPreview = New System.Windows.Forms.WebBrowser
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(134, 11)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(239, 349)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ComboBoxShortCuts)
        Me.TabPage1.Controls.Add(Me.TextBoxEdit)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(231, 323)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Edit"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ComboBoxShortCuts
        '
        Me.ComboBoxShortCuts.FormattingEnabled = True
        Me.ComboBoxShortCuts.Items.AddRange(New Object() {"<center></center>", "<font color=""LEVEL"">Text</font>", "<font color=""00FFFF"">Text</font>", "<font color=""999999"">Text</font>", "<a action=""bypass -h menu_select?ask=0&reply=0"">""Action Text""</a>", "<a action=""bypass -h deposit"">Deposit Item (Private Warehouse)</a>", "<a action=""bypass -h withdraw"">Withdraw Item (Private Warehouse)</a>", "<a action=""bypass -h deposit_pledge"" msg=""1039"">Deposit an item - Clan Warehouse<" & _
                        "/a>", "<a action=""bypass -h withdraw_pledge"">Pick up an item - Clan Warehouse</a>", "<a action=""bypass -h package_deposit"" msg=""1040"">Deposit a freight item.</a>", "<a action=""bypass -h package_withdraw"">Pick up a freight item.</a>", "<a action=""bypass -h create_pledge?pledge_name= $pledge_name"">Enter</a>", "<a action=""bypass -h pledge_levelup"">Level Up</a>", "<a action=""bypass -h dismiss_pledge"">Dissolve</a>", "<a action=""bypass -h revive_pledge"">Recovery</a>", "<a action=""bypass -h talk_select"">Quest</a>"})
        Me.ComboBoxShortCuts.Location = New System.Drawing.Point(6, 296)
        Me.ComboBoxShortCuts.Name = "ComboBoxShortCuts"
        Me.ComboBoxShortCuts.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxShortCuts.TabIndex = 69
        '
        'TextBoxEdit
        '
        Me.TextBoxEdit.Location = New System.Drawing.Point(6, 6)
        Me.TextBoxEdit.Multiline = True
        Me.TextBoxEdit.Name = "TextBoxEdit"
        Me.TextBoxEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxEdit.Size = New System.Drawing.Size(219, 284)
        Me.TextBoxEdit.TabIndex = 0
        Me.TextBoxEdit.Text = "Npc Name:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<font color=""LEVEL"">Hello, World!</font>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<a action=""bypass -h tal" & _
            "k_select"">Quest</a>"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TextBoxResult)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(231, 323)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Result"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TextBoxResult
        '
        Me.TextBoxResult.Location = New System.Drawing.Point(6, 6)
        Me.TextBoxResult.Multiline = True
        Me.TextBoxResult.Name = "TextBoxResult"
        Me.TextBoxResult.ReadOnly = True
        Me.TextBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxResult.Size = New System.Drawing.Size(219, 311)
        Me.TextBoxResult.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(116, 155)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 13)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "(support any Cronicles)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 16)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Dialog Designer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 198)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "(idea by Tilluss)"
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(35, 330)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 60
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(379, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Preview:"
        '
        'ButtonLoad
        '
        Me.ButtonLoad.Location = New System.Drawing.Point(35, 214)
        Me.ButtonLoad.Name = "ButtonLoad"
        Me.ButtonLoad.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLoad.TabIndex = 62
        Me.ButtonLoad.Text = "Load"
        Me.ButtonLoad.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(35, 272)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSave.TabIndex = 63
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'ButtonResult
        '
        Me.ButtonResult.Location = New System.Drawing.Point(35, 243)
        Me.ButtonResult.Name = "ButtonResult"
        Me.ButtonResult.Size = New System.Drawing.Size(75, 23)
        Me.ButtonResult.TabIndex = 64
        Me.ButtonResult.Text = "Generate"
        Me.ButtonResult.UseVisualStyleBackColor = True
        '
        'WebBrowserPreview
        '
        Me.WebBrowserPreview.AllowWebBrowserDrop = False
        Me.WebBrowserPreview.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowserPreview.Location = New System.Drawing.Point(383, 49)
        Me.WebBrowserPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowserPreview.Name = "WebBrowserPreview"
        Me.WebBrowserPreview.Size = New System.Drawing.Size(272, 311)
        Me.WebBrowserPreview.TabIndex = 65
        Me.WebBrowserPreview.Url = New System.Uri("", System.UriKind.Relative)
        Me.WebBrowserPreview.WebBrowserShortcutsEnabled = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(380, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(258, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "> Chat:                                                                     X"
        '
        'HtmlDesigner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 368)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.WebBrowserPreview)
        Me.Controls.Add(Me.ButtonResult)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.ButtonLoad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "HtmlDesigner"
        Me.Text = "HtmlDesigner"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents TextBoxEdit As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxResult As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ButtonLoad As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents ButtonResult As System.Windows.Forms.Button
    Friend WithEvents WebBrowserPreview As System.Windows.Forms.WebBrowser
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxShortCuts As System.Windows.Forms.ComboBox
End Class
