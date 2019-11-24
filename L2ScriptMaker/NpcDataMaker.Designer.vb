<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcDataMaker
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.org_hp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.org_mp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.base_physical_attack = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.base_attack_speed = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.base_magic_attack = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.base_defend = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.base_magic_defend = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommonStatTextBox = New System.Windows.Forms.TextBox
        Me.NpcTypeComboBox = New System.Windows.Forms.ComboBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.FinalTextBox = New System.Windows.Forms.TextBox
        Me.ButtonClear = New System.Windows.Forms.Button
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.ButtonGenerate = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(576, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 19)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "simple NpcData stats maker"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 162)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(130, 15)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(641, 198)
        Me.TabControl1.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.CommonStatTextBox)
        Me.TabPage1.Controls.Add(Me.NpcTypeComboBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(633, 172)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Working place"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.org_hp, Me.org_mp, Me.base_physical_attack, Me.base_attack_speed, Me.base_magic_attack, Me.base_defend, Me.base_magic_defend})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 33)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(609, 112)
        Me.DataGridView1.TabIndex = 2
        '
        'org_hp
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "NULL"
        Me.org_hp.DefaultCellStyle = DataGridViewCellStyle1
        Me.org_hp.HeaderText = "org_hp"
        Me.org_hp.Name = "org_hp"
        '
        'org_mp
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "NULL"
        Me.org_mp.DefaultCellStyle = DataGridViewCellStyle2
        Me.org_mp.HeaderText = "org_mp"
        Me.org_mp.Name = "org_mp"
        '
        'base_physical_attack
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "NULL"
        Me.base_physical_attack.DefaultCellStyle = DataGridViewCellStyle3
        Me.base_physical_attack.HeaderText = "base_physical_attack"
        Me.base_physical_attack.Name = "base_physical_attack"
        '
        'base_attack_speed
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "NULL"
        Me.base_attack_speed.DefaultCellStyle = DataGridViewCellStyle4
        Me.base_attack_speed.HeaderText = "base_attack_speed"
        Me.base_attack_speed.Name = "base_attack_speed"
        '
        'base_magic_attack
        '
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "NULL"
        Me.base_magic_attack.DefaultCellStyle = DataGridViewCellStyle5
        Me.base_magic_attack.HeaderText = "base_magic_attack"
        Me.base_magic_attack.Name = "base_magic_attack"
        '
        'base_defend
        '
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "NULL"
        Me.base_defend.DefaultCellStyle = DataGridViewCellStyle6
        Me.base_defend.HeaderText = "base_defend"
        Me.base_defend.Name = "base_defend"
        '
        'base_magic_defend
        '
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "NULL"
        Me.base_magic_defend.DefaultCellStyle = DataGridViewCellStyle7
        Me.base_magic_defend.HeaderText = "base_magic_defend"
        Me.base_magic_defend.Name = "base_magic_defend"
        '
        'CommonStatTextBox
        '
        Me.CommonStatTextBox.Location = New System.Drawing.Point(104, 7)
        Me.CommonStatTextBox.Name = "CommonStatTextBox"
        Me.CommonStatTextBox.ReadOnly = True
        Me.CommonStatTextBox.Size = New System.Drawing.Size(480, 20)
        Me.CommonStatTextBox.TabIndex = 1
        '
        'NpcTypeComboBox
        '
        Me.NpcTypeComboBox.AutoCompleteCustomSource.AddRange(New String() {"warrior", "boss"})
        Me.NpcTypeComboBox.FormattingEnabled = True
        Me.NpcTypeComboBox.Items.AddRange(New Object() {"warrior", "boss"})
        Me.NpcTypeComboBox.Location = New System.Drawing.Point(6, 6)
        Me.NpcTypeComboBox.Name = "NpcTypeComboBox"
        Me.NpcTypeComboBox.Size = New System.Drawing.Size(92, 21)
        Me.NpcTypeComboBox.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FinalTextBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(633, 172)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Generate result"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FinalTextBox
        '
        Me.FinalTextBox.Location = New System.Drawing.Point(6, 6)
        Me.FinalTextBox.Multiline = True
        Me.FinalTextBox.Name = "FinalTextBox"
        Me.FinalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.FinalTextBox.Size = New System.Drawing.Size(621, 160)
        Me.FinalTextBox.TabIndex = 4
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(32, 211)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClear.TabIndex = 17
        Me.ButtonClear.Text = "Clear"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(692, 219)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 16
        Me.ButtonQuit.Text = "Exit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ButtonGenerate
        '
        Me.ButtonGenerate.Location = New System.Drawing.Point(32, 180)
        Me.ButtonGenerate.Name = "ButtonGenerate"
        Me.ButtonGenerate.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGenerate.TabIndex = 15
        Me.ButtonGenerate.Text = "Generate"
        Me.ButtonGenerate.UseVisualStyleBackColor = True
        '
        'NpcDataMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 246)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonGenerate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NpcDataMaker"
        Me.Text = "NpcDataMaker"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents FinalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ButtonGenerate As System.Windows.Forms.Button
    Friend WithEvents NpcTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CommonStatTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents org_hp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents org_mp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents base_physical_attack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents base_attack_speed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents base_magic_attack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents base_defend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents base_magic_defend As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
