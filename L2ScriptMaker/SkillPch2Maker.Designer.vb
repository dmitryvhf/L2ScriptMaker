<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SkillPch2Maker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SkillPch2Maker))
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SkillCacheScript = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.IgnoreCustomSkillBox = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.La2GuardAttrCheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckBoxAsIs = New System.Windows.Forms.CheckBox()
        Me.CheckBoxKamaelIDStandart = New System.Windows.Forms.CheckBox()
        Me.IgnoreCustomAbnormalsCheckBox = New System.Windows.Forms.CheckBox()
        Me.UseCustomAbnormalsCheckBox = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.LoadAbListButton = New System.Windows.Forms.Button()
        Me.AbnormalListTextBox = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(6, 6)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(127, 23)
        Me.StartButton.TabIndex = 2
        Me.StartButton.Text = "Generate Pch/Pch2"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(370, 178)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(91, 23)
        Me.QuitButton.TabIndex = 3
        Me.QuitButton.Text = "Exit"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 178)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(352, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(320, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Skill Pch/Pch2 Maker"
        '
        'SkillCacheScript
        '
        Me.SkillCacheScript.Location = New System.Drawing.Point(6, 52)
        Me.SkillCacheScript.Name = "SkillCacheScript"
        Me.SkillCacheScript.Size = New System.Drawing.Size(127, 23)
        Me.SkillCacheScript.TabIndex = 45
        Me.SkillCacheScript.Text = "Generate CacheScript"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(320, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "(support C4 scripts)"
        '
        'IgnoreCustomSkillBox
        '
        Me.IgnoreCustomSkillBox.AutoSize = True
        Me.IgnoreCustomSkillBox.Location = New System.Drawing.Point(7, 79)
        Me.IgnoreCustomSkillBox.Name = "IgnoreCustomSkillBox"
        Me.IgnoreCustomSkillBox.Size = New System.Drawing.Size(118, 17)
        Me.IgnoreCustomSkillBox.TabIndex = 47
        Me.IgnoreCustomSkillBox.Text = "Ignore custom skills"
        Me.IgnoreCustomSkillBox.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 160)
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(128, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(337, 131)
        Me.TabControl1.TabIndex = 49
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.La2GuardAttrCheckBox)
        Me.TabPage1.Controls.Add(Me.CheckBoxAsIs)
        Me.TabPage1.Controls.Add(Me.CheckBoxKamaelIDStandart)
        Me.TabPage1.Controls.Add(Me.IgnoreCustomAbnormalsCheckBox)
        Me.TabPage1.Controls.Add(Me.UseCustomAbnormalsCheckBox)
        Me.TabPage1.Controls.Add(Me.StartButton)
        Me.TabPage1.Controls.Add(Me.SkillCacheScript)
        Me.TabPage1.Controls.Add(Me.IgnoreCustomSkillBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(329, 105)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Use Page"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'La2GuardAttrCheckBox
        '
        Me.La2GuardAttrCheckBox.AutoSize = True
        Me.La2GuardAttrCheckBox.Checked = True
        Me.La2GuardAttrCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.La2GuardAttrCheckBox.Location = New System.Drawing.Point(6, 33)
        Me.La2GuardAttrCheckBox.Name = "La2GuardAttrCheckBox"
        Me.La2GuardAttrCheckBox.Size = New System.Drawing.Size(119, 17)
        Me.La2GuardAttrCheckBox.TabIndex = 52
        Me.La2GuardAttrCheckBox.Text = "La2Guard attributes"
        Me.La2GuardAttrCheckBox.UseVisualStyleBackColor = True
        '
        'CheckBoxAsIs
        '
        Me.CheckBoxAsIs.AutoSize = True
        Me.CheckBoxAsIs.Checked = True
        Me.CheckBoxAsIs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAsIs.Location = New System.Drawing.Point(142, 56)
        Me.CheckBoxAsIs.Name = "CheckBoxAsIs"
        Me.CheckBoxAsIs.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxAsIs.TabIndex = 51
        Me.CheckBoxAsIs.Text = "Use name ""As-Is"""
        Me.CheckBoxAsIs.UseVisualStyleBackColor = True
        '
        'CheckBoxKamaelIDStandart
        '
        Me.CheckBoxKamaelIDStandart.AutoSize = True
        Me.CheckBoxKamaelIDStandart.Checked = True
        Me.CheckBoxKamaelIDStandart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxKamaelIDStandart.Location = New System.Drawing.Point(142, 33)
        Me.CheckBoxKamaelIDStandart.Name = "CheckBoxKamaelIDStandart"
        Me.CheckBoxKamaelIDStandart.Size = New System.Drawing.Size(116, 17)
        Me.CheckBoxKamaelIDStandart.TabIndex = 50
        Me.CheckBoxKamaelIDStandart.Text = "Kamael ID standart"
        Me.CheckBoxKamaelIDStandart.UseVisualStyleBackColor = True
        '
        'IgnoreCustomAbnormalsCheckBox
        '
        Me.IgnoreCustomAbnormalsCheckBox.AutoSize = True
        Me.IgnoreCustomAbnormalsCheckBox.Location = New System.Drawing.Point(142, 79)
        Me.IgnoreCustomAbnormalsCheckBox.Name = "IgnoreCustomAbnormalsCheckBox"
        Me.IgnoreCustomAbnormalsCheckBox.Size = New System.Drawing.Size(159, 17)
        Me.IgnoreCustomAbnormalsCheckBox.TabIndex = 49
        Me.IgnoreCustomAbnormalsCheckBox.Text = "Set unknown abnormal to -1"
        Me.IgnoreCustomAbnormalsCheckBox.UseVisualStyleBackColor = True
        '
        'UseCustomAbnormalsCheckBox
        '
        Me.UseCustomAbnormalsCheckBox.AutoSize = True
        Me.UseCustomAbnormalsCheckBox.Checked = True
        Me.UseCustomAbnormalsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UseCustomAbnormalsCheckBox.Enabled = False
        Me.UseCustomAbnormalsCheckBox.Location = New System.Drawing.Point(142, 10)
        Me.UseCustomAbnormalsCheckBox.Name = "UseCustomAbnormalsCheckBox"
        Me.UseCustomAbnormalsCheckBox.Size = New System.Drawing.Size(143, 17)
        Me.UseCustomAbnormalsCheckBox.TabIndex = 48
        Me.UseCustomAbnormalsCheckBox.Text = "Use custom abnormal list"
        Me.UseCustomAbnormalsCheckBox.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.LoadAbListButton)
        Me.TabPage2.Controls.Add(Me.AbnormalListTextBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(329, 105)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Custom AbNormal/Attribute List"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'LoadAbListButton
        '
        Me.LoadAbListButton.Location = New System.Drawing.Point(248, 6)
        Me.LoadAbListButton.Name = "LoadAbListButton"
        Me.LoadAbListButton.Size = New System.Drawing.Size(75, 23)
        Me.LoadAbListButton.TabIndex = 1
        Me.LoadAbListButton.Text = "Load List"
        Me.LoadAbListButton.UseVisualStyleBackColor = True
        '
        'AbnormalListTextBox
        '
        Me.AbnormalListTextBox.Location = New System.Drawing.Point(6, 6)
        Me.AbnormalListTextBox.Multiline = True
        Me.AbnormalListTextBox.Name = "AbnormalListTextBox"
        Me.AbnormalListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AbnormalListTextBox.Size = New System.Drawing.Size(236, 93)
        Me.AbnormalListTextBox.TabIndex = 0
        '
        'SkillPch2Maker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 210)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.QuitButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SkillPch2Maker"
        Me.Text = "Skill Pch/Pch2 Maker"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SkillCacheScript As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents IgnoreCustomSkillBox As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents UseCustomAbnormalsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AbnormalListTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LoadAbListButton As System.Windows.Forms.Button
    Friend WithEvents IgnoreCustomAbnormalsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxKamaelIDStandart As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxAsIs As System.Windows.Forms.CheckBox
    Friend WithEvents La2GuardAttrCheckBox As System.Windows.Forms.CheckBox
End Class
