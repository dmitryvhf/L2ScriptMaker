<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SQLForms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SQLForms))
        Me.QueryButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.SQLPasswordMaskedTextBox = New System.Windows.Forms.MaskedTextBox
        Me.IntegratedSecurityCheckBox = New System.Windows.Forms.CheckBox
        Me.QueryResultTextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CheckConnButton = New System.Windows.Forms.Button
        Me.SQLUserTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SQLDBNameTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SQLSrvNameTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.QueryName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QueryValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.SQLQueryTextBox = New System.Windows.Forms.TextBox
        Me.SaveQueryButton = New System.Windows.Forms.Button
        Me.LoadQueryButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.SQLDataGridView = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.LoadConSetButton = New System.Windows.Forms.Button
        Me.SaveConSetButton = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QueryButton
        '
        Me.QueryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QueryButton.Location = New System.Drawing.Point(498, 178)
        Me.QueryButton.Name = "QueryButton"
        Me.QueryButton.Size = New System.Drawing.Size(109, 23)
        Me.QueryButton.TabIndex = 4
        Me.QueryButton.Text = "Query GO"
        Me.QueryButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QuitButton.Location = New System.Drawing.Point(498, 207)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(109, 23)
        Me.QuitButton.TabIndex = 5
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(130, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(362, 218)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SQLPasswordMaskedTextBox)
        Me.TabPage1.Controls.Add(Me.IntegratedSecurityCheckBox)
        Me.TabPage1.Controls.Add(Me.QueryResultTextBox)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.CheckConnButton)
        Me.TabPage1.Controls.Add(Me.SQLUserTextBox)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.SQLDBNameTextBox)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.SQLSrvNameTextBox)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(354, 192)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Connect Setting"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SQLPasswordMaskedTextBox
        '
        Me.SQLPasswordMaskedTextBox.Location = New System.Drawing.Point(178, 69)
        Me.SQLPasswordMaskedTextBox.Name = "SQLPasswordMaskedTextBox"
        Me.SQLPasswordMaskedTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.SQLPasswordMaskedTextBox.ReadOnly = True
        Me.SQLPasswordMaskedTextBox.Size = New System.Drawing.Size(170, 20)
        Me.SQLPasswordMaskedTextBox.TabIndex = 3
        Me.SQLPasswordMaskedTextBox.Text = "sa"
        '
        'IntegratedSecurityCheckBox
        '
        Me.IntegratedSecurityCheckBox.AutoSize = True
        Me.IntegratedSecurityCheckBox.Checked = True
        Me.IntegratedSecurityCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IntegratedSecurityCheckBox.Location = New System.Drawing.Point(178, 32)
        Me.IntegratedSecurityCheckBox.Name = "IntegratedSecurityCheckBox"
        Me.IntegratedSecurityCheckBox.Size = New System.Drawing.Size(170, 17)
        Me.IntegratedSecurityCheckBox.TabIndex = 1
        Me.IntegratedSecurityCheckBox.Text = "Use 'Integrated Security' mode"
        Me.IntegratedSecurityCheckBox.UseVisualStyleBackColor = True
        '
        'QueryResultTextBox
        '
        Me.QueryResultTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QueryResultTextBox.Location = New System.Drawing.Point(9, 134)
        Me.QueryResultTextBox.Multiline = True
        Me.QueryResultTextBox.Name = "QueryResultTextBox"
        Me.QueryResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.QueryResultTextBox.Size = New System.Drawing.Size(339, 51)
        Me.QueryResultTextBox.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(178, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "SQL Password:"
        '
        'CheckConnButton
        '
        Me.CheckConnButton.Location = New System.Drawing.Point(9, 105)
        Me.CheckConnButton.Name = "CheckConnButton"
        Me.CheckConnButton.Size = New System.Drawing.Size(109, 23)
        Me.CheckConnButton.TabIndex = 4
        Me.CheckConnButton.Text = "Check connection"
        Me.CheckConnButton.UseVisualStyleBackColor = True
        '
        'SQLUserTextBox
        '
        Me.SQLUserTextBox.Location = New System.Drawing.Point(9, 69)
        Me.SQLUserTextBox.Name = "SQLUserTextBox"
        Me.SQLUserTextBox.ReadOnly = True
        Me.SQLUserTextBox.Size = New System.Drawing.Size(163, 20)
        Me.SQLUserTextBox.TabIndex = 2
        Me.SQLUserTextBox.Text = "sa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "SQL User:"
        '
        'SQLDBNameTextBox
        '
        Me.SQLDBNameTextBox.Location = New System.Drawing.Point(178, 108)
        Me.SQLDBNameTextBox.Name = "SQLDBNameTextBox"
        Me.SQLDBNameTextBox.Size = New System.Drawing.Size(163, 20)
        Me.SQLDBNameTextBox.TabIndex = 5
        Me.SQLDBNameTextBox.Text = "testdb"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(175, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Database:"
        '
        'SQLSrvNameTextBox
        '
        Me.SQLSrvNameTextBox.Location = New System.Drawing.Point(9, 30)
        Me.SQLSrvNameTextBox.Name = "SQLSrvNameTextBox"
        Me.SQLSrvNameTextBox.Size = New System.Drawing.Size(163, 20)
        Me.SQLSrvNameTextBox.TabIndex = 0
        Me.SQLSrvNameTextBox.Text = "127.0.0.1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SQL Server Address:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(354, 192)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "Variables"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QueryName, Me.QueryValue})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(332, 132)
        Me.DataGridView1.TabIndex = 1
        '
        'QueryName
        '
        Me.QueryName.HeaderText = "Name"
        Me.QueryName.Name = "QueryName"
        Me.QueryName.Width = 120
        '
        'QueryValue
        '
        Me.QueryValue.HeaderText = "Value"
        Me.QueryValue.Name = "QueryValue"
        Me.QueryValue.Width = 150
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SQLQueryTextBox)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(354, 192)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Query"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SQLQueryTextBox
        '
        Me.SQLQueryTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SQLQueryTextBox.Location = New System.Drawing.Point(6, 6)
        Me.SQLQueryTextBox.Multiline = True
        Me.SQLQueryTextBox.Name = "SQLQueryTextBox"
        Me.SQLQueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.SQLQueryTextBox.Size = New System.Drawing.Size(342, 180)
        Me.SQLQueryTextBox.TabIndex = 0
        Me.SQLQueryTextBox.Text = "-- Lineage II ScriptMaker Query Manager" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-- Developed by HellFire, Russia"
        '
        'SaveQueryButton
        '
        Me.SaveQueryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveQueryButton.Location = New System.Drawing.Point(498, 149)
        Me.SaveQueryButton.Name = "SaveQueryButton"
        Me.SaveQueryButton.Size = New System.Drawing.Size(109, 23)
        Me.SaveQueryButton.TabIndex = 3
        Me.SaveQueryButton.Text = "Save Query Script"
        Me.SaveQueryButton.UseVisualStyleBackColor = True
        '
        'LoadQueryButton
        '
        Me.LoadQueryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoadQueryButton.Location = New System.Drawing.Point(498, 120)
        Me.LoadQueryButton.Name = "LoadQueryButton"
        Me.LoadQueryButton.Size = New System.Drawing.Size(109, 23)
        Me.LoadQueryButton.TabIndex = 2
        Me.LoadQueryButton.Text = "Load Query Script"
        Me.LoadQueryButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(112, 160)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'SQLDataGridView
        '
        Me.SQLDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SQLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SQLDataGridView.Location = New System.Drawing.Point(12, 236)
        Me.SQLDataGridView.Name = "SQLDataGridView"
        Me.SQLDataGridView.Size = New System.Drawing.Size(595, 156)
        Me.SQLDataGridView.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(33, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 54)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "SQL Query" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Template" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Manager"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LoadConSetButton
        '
        Me.LoadConSetButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoadConSetButton.Location = New System.Drawing.Point(498, 33)
        Me.LoadConSetButton.Name = "LoadConSetButton"
        Me.LoadConSetButton.Size = New System.Drawing.Size(111, 23)
        Me.LoadConSetButton.TabIndex = 1
        Me.LoadConSetButton.Text = "Load Conn Setting"
        Me.LoadConSetButton.UseVisualStyleBackColor = True
        '
        'SaveConSetButton
        '
        Me.SaveConSetButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveConSetButton.Location = New System.Drawing.Point(498, 62)
        Me.SaveConSetButton.Name = "SaveConSetButton"
        Me.SaveConSetButton.Size = New System.Drawing.Size(111, 23)
        Me.SaveConSetButton.TabIndex = 8
        Me.SaveConSetButton.Text = "Save Conn Setting"
        Me.SaveConSetButton.UseVisualStyleBackColor = True
        '
        'SQLForms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 404)
        Me.Controls.Add(Me.SaveConSetButton)
        Me.Controls.Add(Me.SaveQueryButton)
        Me.Controls.Add(Me.LoadConSetButton)
        Me.Controls.Add(Me.QueryButton)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LoadQueryButton)
        Me.Controls.Add(Me.SQLDataGridView)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.QuitButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SQLForms"
        Me.Text = "L2ScriptMaker: SQL Query Template Manager"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents QueryButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SQLDBNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SQLSrvNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SQLQueryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QueryResultTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SQLUserTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents IntegratedSecurityCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents LoadQueryButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveQueryButton As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SQLDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents QueryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QueryValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoadConSetButton As System.Windows.Forms.Button
    Friend WithEvents CheckConnButton As System.Windows.Forms.Button
    Friend WithEvents SQLPasswordMaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents SaveConSetButton As System.Windows.Forms.Button
End Class
