<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class L2J_NpcPos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(L2J_NpcPos))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ButtonQuit = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonPTStoL2J = New System.Windows.Forms.Button()
        Me.TextBoxL2JMaxLines = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBoxShowAll = New System.Windows.Forms.CheckBox()
        Me.CheckBoxShowNpcName = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSaveEventNpc = New System.Windows.Forms.CheckBox()
        Me.StatusStrip.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(201, 16)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "NpcPos Generator from L2J file"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 165)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(368, 22)
        Me.StatusStrip.TabIndex = 61
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(200, 16)
        Me.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(128, 137)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 59
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(128, 31)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 58
        Me.ButtonStart.Text = "L2J->PTS"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(107, 157)
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'ButtonPTStoL2J
        '
        Me.ButtonPTStoL2J.Location = New System.Drawing.Point(128, 60)
        Me.ButtonPTStoL2J.Name = "ButtonPTStoL2J"
        Me.ButtonPTStoL2J.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPTStoL2J.TabIndex = 63
        Me.ButtonPTStoL2J.Text = "PTS->L2J"
        Me.ButtonPTStoL2J.UseVisualStyleBackColor = True
        '
        'TextBoxL2JMaxLines
        '
        Me.TextBoxL2JMaxLines.Location = New System.Drawing.Point(266, 62)
        Me.TextBoxL2JMaxLines.Name = "TextBoxL2JMaxLines"
        Me.TextBoxL2JMaxLines.Size = New System.Drawing.Size(35, 20)
        Me.TextBoxL2JMaxLines.TabIndex = 64
        Me.TextBoxL2JMaxLines.Text = "100"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(209, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Max lines"
        '
        'CheckBoxShowAll
        '
        Me.CheckBoxShowAll.AutoSize = True
        Me.CheckBoxShowAll.Location = New System.Drawing.Point(128, 89)
        Me.CheckBoxShowAll.Name = "CheckBoxShowAll"
        Me.CheckBoxShowAll.Size = New System.Drawing.Size(95, 17)
        Me.CheckBoxShowAll.TabIndex = 66
        Me.CheckBoxShowAll.Text = "Show all errors"
        Me.CheckBoxShowAll.UseVisualStyleBackColor = True
        '
        'CheckBoxShowNpcName
        '
        Me.CheckBoxShowNpcName.AutoSize = True
        Me.CheckBoxShowNpcName.Location = New System.Drawing.Point(128, 113)
        Me.CheckBoxShowNpcName.Name = "CheckBoxShowNpcName"
        Me.CheckBoxShowNpcName.Size = New System.Drawing.Size(103, 17)
        Me.CheckBoxShowNpcName.TabIndex = 67
        Me.CheckBoxShowNpcName.Text = "Show npc name"
        Me.CheckBoxShowNpcName.UseVisualStyleBackColor = True
        '
        'CheckBoxSaveEventNpc
        '
        Me.CheckBoxSaveEventNpc.AutoSize = True
        Me.CheckBoxSaveEventNpc.Location = New System.Drawing.Point(229, 89)
        Me.CheckBoxSaveEventNpc.Name = "CheckBoxSaveEventNpc"
        Me.CheckBoxSaveEventNpc.Size = New System.Drawing.Size(107, 17)
        Me.CheckBoxSaveEventNpc.TabIndex = 68
        Me.CheckBoxSaveEventNpc.Text = "Save events npc"
        Me.CheckBoxSaveEventNpc.UseVisualStyleBackColor = True
        '
        'L2J_NpcPos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 187)
        Me.Controls.Add(Me.CheckBoxSaveEventNpc)
        Me.Controls.Add(Me.CheckBoxShowNpcName)
        Me.Controls.Add(Me.CheckBoxShowAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxL2JMaxLines)
        Me.Controls.Add(Me.ButtonPTStoL2J)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "L2J_NpcPos"
        Me.Text = "L2J_NpcPos"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonPTStoL2J As System.Windows.Forms.Button
    Friend WithEvents TextBoxL2JMaxLines As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxShowNpcName As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSaveEventNpc As System.Windows.Forms.CheckBox
End Class
