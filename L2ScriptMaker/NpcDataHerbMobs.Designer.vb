<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcDataHerbMobs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NpcDataHerbMobs))
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Label5 = New System.Windows.Forms.Label
        Me.HerbMobTypeTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.HerbMobMinLvlTextBox = New System.Windows.Forms.TextBox
        Me.CheckBoxLa2Herb = New System.Windows.Forms.CheckBox
        Me.CheckBoxDungeon = New System.Windows.Forms.CheckBox
        Me.RaduisXYTextBox = New System.Windows.Forms.TextBox
        Me.RaduisZTextBox = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(139, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 26)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "(support L2Disasm client file" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "support La2Guard Herb mob option)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(126, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 16)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Herb Mob generator"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 159)
        Me.PictureBox1.TabIndex = 53
        Me.PictureBox1.TabStop = False
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(129, 168)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 56
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(231, 168)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 57
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 209)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(398, 22)
        Me.StatusStrip.TabIndex = 58
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(250, 16)
        Me.ToolStripProgressBar.Step = 1
        Me.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(62, 17)
        Me.ToolStripStatusLabel.Text = "Welcome..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(139, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(186, 13)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "dVampire Herb mob type name:"
        '
        'HerbMobTypeTextBox
        '
        Me.HerbMobTypeTextBox.Location = New System.Drawing.Point(142, 103)
        Me.HerbMobTypeTextBox.Name = "HerbMobTypeTextBox"
        Me.HerbMobTypeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.HerbMobTypeTextBox.TabIndex = 63
        Me.HerbMobTypeTextBox.Text = "herb_warrior"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(139, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Herb mob min level:"
        '
        'HerbMobMinLvlTextBox
        '
        Me.HerbMobMinLvlTextBox.Location = New System.Drawing.Point(142, 142)
        Me.HerbMobMinLvlTextBox.Name = "HerbMobMinLvlTextBox"
        Me.HerbMobMinLvlTextBox.Size = New System.Drawing.Size(100, 20)
        Me.HerbMobMinLvlTextBox.TabIndex = 65
        Me.HerbMobMinLvlTextBox.Text = "1"
        '
        'CheckBoxLa2Herb
        '
        Me.CheckBoxLa2Herb.AutoSize = True
        Me.CheckBoxLa2Herb.Checked = True
        Me.CheckBoxLa2Herb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxLa2Herb.Location = New System.Drawing.Point(142, 67)
        Me.CheckBoxLa2Herb.Name = "CheckBoxLa2Herb"
        Me.CheckBoxLa2Herb.Size = New System.Drawing.Size(106, 17)
        Me.CheckBoxLa2Herb.TabIndex = 67
        Me.CheckBoxLa2Herb.Text = "La2Guard Param"
        Me.CheckBoxLa2Herb.UseVisualStyleBackColor = True
        '
        'CheckBoxDungeon
        '
        Me.CheckBoxDungeon.AutoSize = True
        Me.CheckBoxDungeon.Location = New System.Drawing.Point(267, 67)
        Me.CheckBoxDungeon.Name = "CheckBoxDungeon"
        Me.CheckBoxDungeon.Size = New System.Drawing.Size(111, 17)
        Me.CheckBoxDungeon.TabIndex = 68
        Me.CheckBoxDungeon.Text = "Enable Dungeons"
        Me.CheckBoxDungeon.UseVisualStyleBackColor = True
        '
        'RaduisXYTextBox
        '
        Me.RaduisXYTextBox.Location = New System.Drawing.Point(278, 103)
        Me.RaduisXYTextBox.Name = "RaduisXYTextBox"
        Me.RaduisXYTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RaduisXYTextBox.TabIndex = 69
        Me.RaduisXYTextBox.Text = "13000"
        '
        'RaduisZTextBox
        '
        Me.RaduisZTextBox.Location = New System.Drawing.Point(278, 129)
        Me.RaduisZTextBox.Name = "RaduisZTextBox"
        Me.RaduisZTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RaduisZTextBox.TabIndex = 70
        Me.RaduisZTextBox.Text = "1000"
        '
        'NpcDataHerbMobs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 231)
        Me.Controls.Add(Me.RaduisZTextBox)
        Me.Controls.Add(Me.RaduisXYTextBox)
        Me.Controls.Add(Me.CheckBoxDungeon)
        Me.Controls.Add(Me.CheckBoxLa2Herb)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.HerbMobMinLvlTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.HerbMobTypeTextBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NpcDataHerbMobs"
        Me.Text = "NpcDataHerbMobs"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents HerbMobTypeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents HerbMobMinLvlTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxLa2Herb As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxDungeon As System.Windows.Forms.CheckBox
    Friend WithEvents RaduisXYTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RaduisZTextBox As System.Windows.Forms.TextBox
End Class
