<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SkillAcquireEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SkillAcquireEditor))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ClassListBox = New System.Windows.Forms.ListBox
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.AutoSortComboBox = New System.Windows.Forms.ComboBox
        Me.AutoSortCheckBox = New System.Windows.Forms.CheckBox
        Me.AddDownButton = New System.Windows.Forms.Button
        Me.CloneDownButton = New System.Windows.Forms.Button
        Me.CloneUpButton = New System.Windows.Forms.Button
        Me.CopyDownButton = New System.Windows.Forms.Button
        Me.CopyUpButton = New System.Windows.Forms.Button
        Me.MoveDownButton = New System.Windows.Forms.Button
        Me.MoveUpButton = New System.Windows.Forms.Button
        Me.CopyPasteComboBox = New System.Windows.Forms.ComboBox
        Me.CopyPasteSkillButton = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.CopyPasteTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.AddRowBeforeButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.InheritsComboBox = New System.Windows.Forms.ComboBox
        Me.SaveSkillAcquireButton = New System.Windows.Forms.Button
        Me.LoadSkillAcquireButton = New System.Windows.Forms.Button
        Me.DataGridView = New System.Windows.Forms.DataGridView
        Me.skill_name = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.get_lv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lv_up_sp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.auto_get = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.item_needed1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.item_needed1_value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.item_needed2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.item_needed2_value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.note = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuitButton = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ClassListBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProgressBar)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.AutoSortComboBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.AutoSortCheckBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.AddDownButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CloneDownButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CloneUpButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CopyDownButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CopyUpButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MoveDownButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MoveUpButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CopyPasteComboBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CopyPasteSkillButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CopyPasteTextBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.AddRowBeforeButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.InheritsComboBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SaveSkillAcquireButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LoadSkillAcquireButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView)
        Me.SplitContainer1.Panel2.Controls.Add(Me.QuitButton)
        Me.SplitContainer1.Size = New System.Drawing.Size(947, 312)
        Me.SplitContainer1.SplitterDistance = 134
        Me.SplitContainer1.TabIndex = 0
        '
        'ClassListBox
        '
        Me.ClassListBox.FormattingEnabled = True
        Me.ClassListBox.Items.AddRange(New Object() {"fighter_begin", "warrior_begin"})
        Me.ClassListBox.Location = New System.Drawing.Point(12, 12)
        Me.ClassListBox.Name = "ClassListBox"
        Me.ClassListBox.Size = New System.Drawing.Size(113, 264)
        Me.ClassListBox.TabIndex = 2
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 281)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(113, 23)
        Me.ProgressBar.TabIndex = 2
        '
        'AutoSortComboBox
        '
        Me.AutoSortComboBox.AutoCompleteCustomSource.AddRange(New String() {"skill_name", "get_lv", "lv_up_sp", "auto_get"})
        Me.AutoSortComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.AutoSortComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AutoSortComboBox.Items.AddRange(New Object() {"skill_name", "get_lv", "lv_up_sp", "auto_get"})
        Me.AutoSortComboBox.Location = New System.Drawing.Point(2, 258)
        Me.AutoSortComboBox.Name = "AutoSortComboBox"
        Me.AutoSortComboBox.Size = New System.Drawing.Size(121, 21)
        Me.AutoSortComboBox.TabIndex = 68
        Me.AutoSortComboBox.Text = "skill_name"
        '
        'AutoSortCheckBox
        '
        Me.AutoSortCheckBox.AutoSize = True
        Me.AutoSortCheckBox.Location = New System.Drawing.Point(3, 241)
        Me.AutoSortCheckBox.Name = "AutoSortCheckBox"
        Me.AutoSortCheckBox.Size = New System.Drawing.Size(96, 17)
        Me.AutoSortCheckBox.TabIndex = 67
        Me.AutoSortCheckBox.Text = "Auto sorting by"
        Me.AutoSortCheckBox.UseVisualStyleBackColor = True
        '
        'AddDownButton
        '
        Me.AddDownButton.Location = New System.Drawing.Point(3, 215)
        Me.AddDownButton.Name = "AddDownButton"
        Me.AddDownButton.Size = New System.Drawing.Size(75, 23)
        Me.AddDownButton.TabIndex = 66
        Me.AddDownButton.Text = "Add Down"
        Me.AddDownButton.UseVisualStyleBackColor = True
        '
        'CloneDownButton
        '
        Me.CloneDownButton.Location = New System.Drawing.Point(3, 186)
        Me.CloneDownButton.Name = "CloneDownButton"
        Me.CloneDownButton.Size = New System.Drawing.Size(75, 23)
        Me.CloneDownButton.TabIndex = 65
        Me.CloneDownButton.Text = "CloneDown"
        Me.CloneDownButton.UseVisualStyleBackColor = True
        '
        'CloneUpButton
        '
        Me.CloneUpButton.Location = New System.Drawing.Point(3, 41)
        Me.CloneUpButton.Name = "CloneUpButton"
        Me.CloneUpButton.Size = New System.Drawing.Size(75, 23)
        Me.CloneUpButton.TabIndex = 64
        Me.CloneUpButton.Text = "CloneUp"
        Me.CloneUpButton.UseVisualStyleBackColor = True
        '
        'CopyDownButton
        '
        Me.CopyDownButton.Location = New System.Drawing.Point(3, 157)
        Me.CopyDownButton.Name = "CopyDownButton"
        Me.CopyDownButton.Size = New System.Drawing.Size(75, 23)
        Me.CopyDownButton.TabIndex = 63
        Me.CopyDownButton.Text = "CopyDown"
        Me.CopyDownButton.UseVisualStyleBackColor = True
        '
        'CopyUpButton
        '
        Me.CopyUpButton.Location = New System.Drawing.Point(3, 70)
        Me.CopyUpButton.Name = "CopyUpButton"
        Me.CopyUpButton.Size = New System.Drawing.Size(75, 23)
        Me.CopyUpButton.TabIndex = 62
        Me.CopyUpButton.Text = "CopyUp"
        Me.CopyUpButton.UseVisualStyleBackColor = True
        '
        'MoveDownButton
        '
        Me.MoveDownButton.Location = New System.Drawing.Point(3, 128)
        Me.MoveDownButton.Name = "MoveDownButton"
        Me.MoveDownButton.Size = New System.Drawing.Size(75, 23)
        Me.MoveDownButton.TabIndex = 61
        Me.MoveDownButton.Text = "MoveDown"
        Me.MoveDownButton.UseVisualStyleBackColor = True
        '
        'MoveUpButton
        '
        Me.MoveUpButton.Location = New System.Drawing.Point(3, 99)
        Me.MoveUpButton.Name = "MoveUpButton"
        Me.MoveUpButton.Size = New System.Drawing.Size(75, 23)
        Me.MoveUpButton.TabIndex = 60
        Me.MoveUpButton.Text = "MoveUp"
        Me.MoveUpButton.UseVisualStyleBackColor = True
        '
        'CopyPasteComboBox
        '
        Me.CopyPasteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CopyPasteComboBox.FormattingEnabled = True
        Me.CopyPasteComboBox.Items.AddRange(New Object() {"skill_name", "item_needed1", "item_needed2", "note"})
        Me.CopyPasteComboBox.Location = New System.Drawing.Point(415, 283)
        Me.CopyPasteComboBox.Name = "CopyPasteComboBox"
        Me.CopyPasteComboBox.Size = New System.Drawing.Size(140, 21)
        Me.CopyPasteComboBox.TabIndex = 59
        Me.CopyPasteComboBox.Text = "skill_name"
        '
        'CopyPasteSkillButton
        '
        Me.CopyPasteSkillButton.Location = New System.Drawing.Point(295, 281)
        Me.CopyPasteSkillButton.Name = "CopyPasteSkillButton"
        Me.CopyPasteSkillButton.Size = New System.Drawing.Size(114, 23)
        Me.CopyPasteSkillButton.TabIndex = 55
        Me.CopyPasteSkillButton.Text = "Copy/Paste to"
        Me.CopyPasteSkillButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(292, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Pch name for copy/paste:"
        '
        'CopyPasteTextBox
        '
        Me.CopyPasteTextBox.Location = New System.Drawing.Point(295, 257)
        Me.CopyPasteTextBox.Name = "CopyPasteTextBox"
        Me.CopyPasteTextBox.Size = New System.Drawing.Size(260, 20)
        Me.CopyPasteTextBox.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(675, 255)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "(support C4 scripts)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(675, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 16)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "SkillAquire Editor"
        '
        'AddRowBeforeButton
        '
        Me.AddRowBeforeButton.Location = New System.Drawing.Point(3, 12)
        Me.AddRowBeforeButton.Name = "AddRowBeforeButton"
        Me.AddRowBeforeButton.Size = New System.Drawing.Size(75, 23)
        Me.AddRowBeforeButton.TabIndex = 7
        Me.AddRowBeforeButton.Text = "Add Up"
        Me.AddRowBeforeButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(136, 242)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Include main class:"
        '
        'InheritsComboBox
        '
        Me.InheritsComboBox.FormattingEnabled = True
        Me.InheritsComboBox.Items.AddRange(New Object() {"fighter_begin", "warrior_begin"})
        Me.InheritsComboBox.Location = New System.Drawing.Point(139, 258)
        Me.InheritsComboBox.Name = "InheritsComboBox"
        Me.InheritsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.InheritsComboBox.TabIndex = 5
        '
        'SaveSkillAcquireButton
        '
        Me.SaveSkillAcquireButton.Location = New System.Drawing.Point(561, 281)
        Me.SaveSkillAcquireButton.Name = "SaveSkillAcquireButton"
        Me.SaveSkillAcquireButton.Size = New System.Drawing.Size(102, 23)
        Me.SaveSkillAcquireButton.TabIndex = 4
        Me.SaveSkillAcquireButton.Text = "Save SkillAcquire"
        Me.SaveSkillAcquireButton.UseVisualStyleBackColor = True
        '
        'LoadSkillAcquireButton
        '
        Me.LoadSkillAcquireButton.Location = New System.Drawing.Point(3, 281)
        Me.LoadSkillAcquireButton.Name = "LoadSkillAcquireButton"
        Me.LoadSkillAcquireButton.Size = New System.Drawing.Size(102, 23)
        Me.LoadSkillAcquireButton.TabIndex = 3
        Me.LoadSkillAcquireButton.Text = "Load SkillAcquire"
        Me.LoadSkillAcquireButton.UseVisualStyleBackColor = True
        '
        'DataGridView
        '
        Me.DataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.skill_name, Me.get_lv, Me.lv_up_sp, Me.auto_get, Me.item_needed1, Me.item_needed1_value, Me.item_needed2, Me.item_needed2_value, Me.note})
        Me.DataGridView.Location = New System.Drawing.Point(84, 12)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.Size = New System.Drawing.Size(712, 224)
        Me.DataGridView.TabIndex = 1
        '
        'skill_name
        '
        Me.skill_name.HeaderText = "skill_name"
        Me.skill_name.Name = "skill_name"
        Me.skill_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.skill_name.Width = 200
        '
        'get_lv
        '
        DataGridViewCellStyle1.NullValue = "0"
        Me.get_lv.DefaultCellStyle = DataGridViewCellStyle1
        Me.get_lv.HeaderText = "get_lv"
        Me.get_lv.Name = "get_lv"
        Me.get_lv.Width = 40
        '
        'lv_up_sp
        '
        DataGridViewCellStyle2.NullValue = "0"
        Me.lv_up_sp.DefaultCellStyle = DataGridViewCellStyle2
        Me.lv_up_sp.HeaderText = "lv_up_sp"
        Me.lv_up_sp.Name = "lv_up_sp"
        '
        'auto_get
        '
        DataGridViewCellStyle3.NullValue = "False"
        Me.auto_get.DefaultCellStyle = DataGridViewCellStyle3
        Me.auto_get.HeaderText = "auto_get"
        Me.auto_get.Items.AddRange(New Object() {"False", "True"})
        Me.auto_get.Name = "auto_get"
        Me.auto_get.Width = 60
        '
        'item_needed1
        '
        Me.item_needed1.HeaderText = "item_needed1"
        Me.item_needed1.Name = "item_needed1"
        Me.item_needed1.Width = 150
        '
        'item_needed1_value
        '
        DataGridViewCellStyle4.NullValue = "0"
        Me.item_needed1_value.DefaultCellStyle = DataGridViewCellStyle4
        Me.item_needed1_value.HeaderText = "item_needed1_value"
        Me.item_needed1_value.Name = "item_needed1_value"
        Me.item_needed1_value.Width = 30
        '
        'item_needed2
        '
        Me.item_needed2.HeaderText = "item_needed"
        Me.item_needed2.Name = "item_needed2"
        '
        'item_needed2_value
        '
        Me.item_needed2_value.HeaderText = "item_needed2_value"
        Me.item_needed2_value.Name = "item_needed2_value"
        '
        'note
        '
        Me.note.HeaderText = "note"
        Me.note.Name = "note"
        Me.note.Width = 200
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(721, 281)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 0
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'SkillAcquireEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 312)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SkillAcquireEditor"
        Me.Text = "SkillAcquire Editor"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents ClassListBox As System.Windows.Forms.ListBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LoadSkillAcquireButton As System.Windows.Forms.Button
    Friend WithEvents SaveSkillAcquireButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents InheritsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AddRowBeforeButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CopyPasteSkillButton As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CopyPasteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CopyPasteComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MoveUpButton As System.Windows.Forms.Button
    Friend WithEvents MoveDownButton As System.Windows.Forms.Button
    Friend WithEvents CopyDownButton As System.Windows.Forms.Button
    Friend WithEvents CopyUpButton As System.Windows.Forms.Button
    Friend WithEvents CloneUpButton As System.Windows.Forms.Button
    Friend WithEvents CloneDownButton As System.Windows.Forms.Button
    Friend WithEvents AddDownButton As System.Windows.Forms.Button
    Friend WithEvents skill_name As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents get_lv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lv_up_sp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents auto_get As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents item_needed1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents item_needed1_value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item_needed2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents item_needed2_value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents note As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AutoSortComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AutoSortCheckBox As System.Windows.Forms.CheckBox
End Class
