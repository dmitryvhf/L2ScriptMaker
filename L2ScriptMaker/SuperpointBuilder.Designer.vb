<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuperpointBuilder
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SuperpointBuilder))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.StartButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.GenerateButton = New System.Windows.Forms.Button
        Me.DataGridView = New System.Windows.Forms.DataGridView
        Me.X = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Y = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Z = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Delay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.SettingTabPage = New System.Windows.Forms.TabPage
        Me.GenAllCheckBox = New System.Windows.Forms.CheckBox
        Me.MakeNewButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.NpcNameTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.StartNumberTextBox = New System.Windows.Forms.TextBox
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.LoadPointsButton = New System.Windows.Forms.Button
        Me.ImportPointsTextBox = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.MakeNewTextBox = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SettingTabPage.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(114, 164)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(132, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(284, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Lineage II Cronicles 4: Superpoint.bin Builder"
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(3, 8)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(86, 23)
        Me.StartButton.TabIndex = 2
        Me.StartButton.Text = "Export data"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(26, 175)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(86, 23)
        Me.QuitButton.TabIndex = 3
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'GenerateButton
        '
        Me.GenerateButton.Location = New System.Drawing.Point(3, 37)
        Me.GenerateButton.Name = "GenerateButton"
        Me.GenerateButton.Size = New System.Drawing.Size(86, 23)
        Me.GenerateButton.TabIndex = 4
        Me.GenerateButton.Text = "Generate new"
        Me.GenerateButton.UseVisualStyleBackColor = True
        '
        'DataGridView
        '
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.X, Me.Y, Me.Z, Me.Delay})
        Me.DataGridView.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView.Name = "DataGridView"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView.Size = New System.Drawing.Size(446, 137)
        Me.DataGridView.TabIndex = 5
        '
        'X
        '
        Me.X.HeaderText = "X"
        Me.X.Name = "X"
        '
        'Y
        '
        Me.Y.HeaderText = "Y"
        Me.Y.Name = "Y"
        '
        'Z
        '
        Me.Z.HeaderText = "Z"
        Me.Z.Name = "Z"
        '
        'Delay
        '
        Me.Delay.HeaderText = "Delay"
        Me.Delay.Name = "Delay"
        Me.Delay.Width = 50
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.SettingTabPage)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(135, 26)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(463, 172)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.StartButton)
        Me.TabPage5.Controls.Add(Me.GenerateButton)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(455, 146)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Basic works"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(455, 146)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Points list"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SettingTabPage
        '
        Me.SettingTabPage.Controls.Add(Me.GenAllCheckBox)
        Me.SettingTabPage.Controls.Add(Me.MakeNewButton)
        Me.SettingTabPage.Controls.Add(Me.Label3)
        Me.SettingTabPage.Controls.Add(Me.NpcNameTextBox)
        Me.SettingTabPage.Controls.Add(Me.Label2)
        Me.SettingTabPage.Controls.Add(Me.StartNumberTextBox)
        Me.SettingTabPage.Location = New System.Drawing.Point(4, 22)
        Me.SettingTabPage.Name = "SettingTabPage"
        Me.SettingTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SettingTabPage.Size = New System.Drawing.Size(455, 146)
        Me.SettingTabPage.TabIndex = 2
        Me.SettingTabPage.Text = "Setting"
        Me.SettingTabPage.UseVisualStyleBackColor = True
        '
        'GenAllCheckBox
        '
        Me.GenAllCheckBox.AutoSize = True
        Me.GenAllCheckBox.Location = New System.Drawing.Point(9, 84)
        Me.GenAllCheckBox.Name = "GenAllCheckBox"
        Me.GenAllCheckBox.Size = New System.Drawing.Size(198, 17)
        Me.GenAllCheckBox.TabIndex = 4
        Me.GenAllCheckBox.Text = "Generate all conntype for each point"
        Me.GenAllCheckBox.UseVisualStyleBackColor = True
        '
        'MakeNewButton
        '
        Me.MakeNewButton.Location = New System.Drawing.Point(324, 10)
        Me.MakeNewButton.Name = "MakeNewButton"
        Me.MakeNewButton.Size = New System.Drawing.Size(125, 37)
        Me.MakeNewButton.TabIndex = 1
        Me.MakeNewButton.Text = "Make new superpoint" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "path use table values"
        Me.MakeNewButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Npc name:"
        '
        'NpcNameTextBox
        '
        Me.NpcNameTextBox.Location = New System.Drawing.Point(9, 19)
        Me.NpcNameTextBox.Name = "NpcNameTextBox"
        Me.NpcNameTextBox.Size = New System.Drawing.Size(202, 20)
        Me.NpcNameTextBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Start number:"
        '
        'StartNumberTextBox
        '
        Me.StartNumberTextBox.Location = New System.Drawing.Point(9, 58)
        Me.StartNumberTextBox.Name = "StartNumberTextBox"
        Me.StartNumberTextBox.Size = New System.Drawing.Size(67, 20)
        Me.StartNumberTextBox.TabIndex = 0
        Me.StartNumberTextBox.Text = "1"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.LoadPointsButton)
        Me.TabPage4.Controls.Add(Me.ImportPointsTextBox)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(455, 146)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Import Points"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'LoadPointsButton
        '
        Me.LoadPointsButton.Location = New System.Drawing.Point(363, 6)
        Me.LoadPointsButton.Name = "LoadPointsButton"
        Me.LoadPointsButton.Size = New System.Drawing.Size(86, 23)
        Me.LoadPointsButton.TabIndex = 7
        Me.LoadPointsButton.Text = "Load points"
        Me.LoadPointsButton.UseVisualStyleBackColor = True
        '
        'ImportPointsTextBox
        '
        Me.ImportPointsTextBox.Location = New System.Drawing.Point(6, 6)
        Me.ImportPointsTextBox.Multiline = True
        Me.ImportPointsTextBox.Name = "ImportPointsTextBox"
        Me.ImportPointsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ImportPointsTextBox.Size = New System.Drawing.Size(351, 134)
        Me.ImportPointsTextBox.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.MakeNewTextBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(455, 146)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Result"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'MakeNewTextBox
        '
        Me.MakeNewTextBox.Location = New System.Drawing.Point(6, 6)
        Me.MakeNewTextBox.Multiline = True
        Me.MakeNewTextBox.Name = "MakeNewTextBox"
        Me.MakeNewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.MakeNewTextBox.Size = New System.Drawing.Size(443, 134)
        Me.MakeNewTextBox.TabIndex = 0
        '
        'SuperpointBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 205)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SuperpointBuilder"
        Me.Text = "Superpoint.bin Builder"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SettingTabPage.ResumeLayout(False)
        Me.SettingTabPage.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GenerateButton As System.Windows.Forms.Button
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents MakeNewTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MakeNewButton As System.Windows.Forms.Button
    Friend WithEvents SettingTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StartNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NpcNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents LoadPointsButton As System.Windows.Forms.Button
    Friend WithEvents ImportPointsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GenAllCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Y As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Z As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delay As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
