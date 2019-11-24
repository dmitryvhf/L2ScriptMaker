<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptLeecher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptLeecher))
        Me.textSource = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.bOpenSource = New System.Windows.Forms.Button
        Me.Open = New System.Windows.Forms.OpenFileDialog
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ID = New System.Windows.Forms.ComboBox
        Me.Level = New System.Windows.Forms.ComboBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.bCompute = New System.Windows.Forms.Button
        Me.cGrid = New System.Windows.Forms.DataGridView
        Me.sParameter = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.oParameter = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.num1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.rOnumber = New System.Windows.Forms.RadioButton
        Me.rOname = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rInumber = New System.Windows.Forms.RadioButton
        Me.rIname = New System.Windows.Forms.RadioButton
        Me.Status = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.Status1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label6 = New System.Windows.Forms.Label
        Me.textSave = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.QuitButton = New System.Windows.Forms.Button
        Me.bSave = New System.Windows.Forms.Button
        Me.bLoadObraz = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.cGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Status.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'textSource
        '
        Me.textSource.Location = New System.Drawing.Point(85, 4)
        Me.textSource.Name = "textSource"
        Me.textSource.Size = New System.Drawing.Size(476, 20)
        Me.textSource.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "File:"
        '
        'bOpenSource
        '
        Me.bOpenSource.Location = New System.Drawing.Point(444, 27)
        Me.bOpenSource.Name = "bOpenSource"
        Me.bOpenSource.Size = New System.Drawing.Size(117, 22)
        Me.bOpenSource.TabIndex = 2
        Me.bOpenSource.Text = "Loading"
        Me.bOpenSource.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Identify tag:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Level tag:"
        '
        'ID
        '
        Me.ID.FormattingEnabled = True
        Me.ID.Location = New System.Drawing.Point(85, 30)
        Me.ID.Name = "ID"
        Me.ID.Size = New System.Drawing.Size(200, 21)
        Me.ID.TabIndex = 5
        '
        'Level
        '
        Me.Level.FormattingEnabled = True
        Me.Level.Location = New System.Drawing.Point(85, 57)
        Me.Level.Name = "Level"
        Me.Level.Size = New System.Drawing.Size(200, 21)
        Me.Level.TabIndex = 6
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(5, 83)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(556, 345)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.bCompute)
        Me.TabPage2.Controls.Add(Me.cGrid)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(548, 319)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Групповая обработка"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'bCompute
        '
        Me.bCompute.Location = New System.Drawing.Point(440, 291)
        Me.bCompute.Name = "bCompute"
        Me.bCompute.Size = New System.Drawing.Size(101, 22)
        Me.bCompute.TabIndex = 13
        Me.bCompute.Text = "Analyzing"
        Me.bCompute.UseVisualStyleBackColor = True
        '
        'cGrid
        '
        Me.cGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.cGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sParameter, Me.oParameter, Me.num1, Me.num2})
        Me.cGrid.Location = New System.Drawing.Point(7, 87)
        Me.cGrid.Name = "cGrid"
        Me.cGrid.Size = New System.Drawing.Size(534, 198)
        Me.cGrid.TabIndex = 2
        '
        'sParameter
        '
        Me.sParameter.HeaderText = "Parameter of source"
        Me.sParameter.Name = "sParameter"
        Me.sParameter.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sParameter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.sParameter.Width = 230
        '
        'oParameter
        '
        Me.oParameter.HeaderText = "Parameter of pattern"
        Me.oParameter.Name = "oParameter"
        Me.oParameter.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.oParameter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.oParameter.Width = 230
        '
        'num1
        '
        Me.num1.HeaderText = "num1"
        Me.num1.Name = "num1"
        Me.num1.Visible = False
        '
        'num2
        '
        Me.num2.HeaderText = "num2"
        Me.num2.Name = "num2"
        Me.num2.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rOnumber)
        Me.GroupBox5.Controls.Add(Me.rOname)
        Me.GroupBox5.Location = New System.Drawing.Point(233, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(219, 70)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Identify specimen/pattern by.."
        '
        'rOnumber
        '
        Me.rOnumber.AutoSize = True
        Me.rOnumber.Location = New System.Drawing.Point(6, 42)
        Me.rOnumber.Name = "rOnumber"
        Me.rOnumber.Size = New System.Drawing.Size(89, 17)
        Me.rOnumber.TabIndex = 3
        Me.rOnumber.TabStop = True
        Me.rOnumber.Text = "Serial number"
        Me.rOnumber.UseVisualStyleBackColor = True
        '
        'rOname
        '
        Me.rOname.AutoSize = True
        Me.rOname.Location = New System.Drawing.Point(6, 19)
        Me.rOname.Name = "rOname"
        Me.rOname.Size = New System.Drawing.Size(53, 17)
        Me.rOname.TabIndex = 2
        Me.rOname.TabStop = True
        Me.rOname.Text = "Name"
        Me.rOname.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rInumber)
        Me.GroupBox4.Controls.Add(Me.rIname)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(219, 70)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Identify source by.."
        '
        'rInumber
        '
        Me.rInumber.AutoSize = True
        Me.rInumber.Location = New System.Drawing.Point(6, 42)
        Me.rInumber.Name = "rInumber"
        Me.rInumber.Size = New System.Drawing.Size(89, 17)
        Me.rInumber.TabIndex = 1
        Me.rInumber.TabStop = True
        Me.rInumber.Text = "Serial number"
        Me.rInumber.UseVisualStyleBackColor = True
        '
        'rIname
        '
        Me.rIname.AutoSize = True
        Me.rIname.Location = New System.Drawing.Point(6, 19)
        Me.rIname.Name = "rIname"
        Me.rIname.Size = New System.Drawing.Size(53, 17)
        Me.rIname.TabIndex = 0
        Me.rIname.TabStop = True
        Me.rIname.Text = "Name"
        Me.rIname.UseVisualStyleBackColor = True
        '
        'Status
        '
        Me.Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.Status1})
        Me.Status.Location = New System.Drawing.Point(0, 483)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(567, 22)
        Me.Status.TabIndex = 8
        Me.Status.Text = "StatusStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(350, 16)
        Me.ToolStripProgressBar.Step = 1
        Me.ToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'Status1
        '
        Me.Status1.Name = "Status1"
        Me.Status1.Size = New System.Drawing.Size(39, 17)
        Me.Status1.Text = "Ready"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "File:"
        '
        'textSave
        '
        Me.textSave.Location = New System.Drawing.Point(50, 15)
        Me.textSave.Name = "textSave"
        Me.textSave.Size = New System.Drawing.Size(318, 20)
        Me.textSave.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.QuitButton)
        Me.GroupBox3.Controls.Add(Me.bSave)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.textSave)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 434)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(556, 47)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Results:"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(481, 13)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 13
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'bSave
        '
        Me.bSave.Location = New System.Drawing.Point(374, 13)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(101, 22)
        Me.bSave.TabIndex = 12
        Me.bSave.Text = "Save"
        Me.bSave.UseVisualStyleBackColor = True
        '
        'bLoadObraz
        '
        Me.bLoadObraz.Location = New System.Drawing.Point(444, 54)
        Me.bLoadObraz.Name = "bLoadObraz"
        Me.bLoadObraz.Size = New System.Drawing.Size(117, 35)
        Me.bLoadObraz.TabIndex = 12
        Me.bLoadObraz.Text = "Loading like specimen/pattern"
        Me.bLoadObraz.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(301, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 18)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "ScriptLeecher"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(301, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 26)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Developed by E.Koksharov," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Russia, Ekaterinburg"
        '
        'ScriptLeecher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 505)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.bLoadObraz)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Level)
        Me.Controls.Add(Me.ID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bOpenSource)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textSource)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScriptLeecher"
        Me.Text = "L2ScriptMaker: ScriptLeecher"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.cGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Status.ResumeLayout(False)
        Me.Status.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textSource As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bOpenSource As System.Windows.Forms.Button
    Friend WithEvents Open As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.ComboBox
    Friend WithEvents Level As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Status As System.Windows.Forms.StatusStrip
    Friend WithEvents Status1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents textSave As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents bSave As System.Windows.Forms.Button
    Friend WithEvents bLoadObraz As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rOnumber As System.Windows.Forms.RadioButton
    Friend WithEvents rOname As System.Windows.Forms.RadioButton
    Friend WithEvents rInumber As System.Windows.Forms.RadioButton
    Friend WithEvents rIname As System.Windows.Forms.RadioButton
    Friend WithEvents cGrid As System.Windows.Forms.DataGridView
    Friend WithEvents bCompute As System.Windows.Forms.Button
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents sParameter As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents oParameter As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents num1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
