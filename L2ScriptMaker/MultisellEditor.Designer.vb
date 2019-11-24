<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultisellEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultisellEditor))
        Me.BuySellListBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabResultPage = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BuySellListTextBox = New System.Windows.Forms.TextBox
        Me.ButtonImport = New System.Windows.Forms.Button
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.DataGridView = New System.Windows.Forms.DataGridView
        Me.ItemList = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ItemValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemsComponentsList = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ItemsComponentsValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabDataPage = New System.Windows.Forms.TabPage
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MultisellIDBox = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.IsDutyfreeBox = New System.Windows.Forms.ComboBox
        Me.IsShowAllBox = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.KeepEnchantedBox = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.MultisellNoteBox = New System.Windows.Forms.TextBox
        Me.TabResultPage.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabDataPage.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BuySellListBox
        '
        Me.BuySellListBox.Location = New System.Drawing.Point(6, 6)
        Me.BuySellListBox.Multiline = True
        Me.BuySellListBox.Name = "BuySellListBox"
        Me.BuySellListBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.BuySellListBox.Size = New System.Drawing.Size(567, 190)
        Me.BuySellListBox.TabIndex = 0
        Me.BuySellListBox.Text = resources.GetString("BuySellListBox.Text")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(599, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "(support C4 scripts)"
        '
        'TabResultPage
        '
        Me.TabResultPage.Controls.Add(Me.BuySellListBox)
        Me.TabResultPage.Location = New System.Drawing.Point(4, 22)
        Me.TabResultPage.Name = "TabResultPage"
        Me.TabResultPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TabResultPage.Size = New System.Drawing.Size(579, 202)
        Me.TabResultPage.TabIndex = 1
        Me.TabResultPage.Text = "Result page"
        Me.TabResultPage.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(599, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 16)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "MultiSell Maker"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(398, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "MultiSell_begin:"
        '
        'BuySellListTextBox
        '
        Me.BuySellListTextBox.Location = New System.Drawing.Point(401, 30)
        Me.BuySellListTextBox.Name = "BuySellListTextBox"
        Me.BuySellListTextBox.Size = New System.Drawing.Size(151, 20)
        Me.BuySellListTextBox.TabIndex = 54
        Me.BuySellListTextBox.Text = "new_multisell"
        '
        'ButtonImport
        '
        Me.ButtonImport.Location = New System.Drawing.Point(29, 190)
        Me.ButtonImport.Name = "ButtonImport"
        Me.ButtonImport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonImport.TabIndex = 52
        Me.ButtonImport.Text = "Import"
        Me.ButtonImport.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(29, 219)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 49
        Me.ButtonStart.Text = "Generate"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'DataGridView
        '
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemList, Me.ItemValue, Me.ItemsComponentsList, Me.ItemsComponentsValue})
        Me.DataGridView.Location = New System.Drawing.Point(9, 6)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.Size = New System.Drawing.Size(565, 190)
        Me.DataGridView.TabIndex = 0
        '
        'ItemList
        '
        Me.ItemList.HeaderText = "ItemList"
        Me.ItemList.Name = "ItemList"
        Me.ItemList.Width = 200
        '
        'ItemValue
        '
        Me.ItemValue.HeaderText = "ItemValue"
        Me.ItemValue.Name = "ItemValue"
        Me.ItemValue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ItemValue.Width = 60
        '
        'ItemsComponentsList
        '
        Me.ItemsComponentsList.HeaderText = "ItemsComponentsList"
        Me.ItemsComponentsList.Name = "ItemsComponentsList"
        Me.ItemsComponentsList.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemsComponentsList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ItemsComponentsList.Width = 200
        '
        'ItemsComponentsValue
        '
        Me.ItemsComponentsValue.HeaderText = "Items Value"
        Me.ItemsComponentsValue.Name = "ItemsComponentsValue"
        Me.ItemsComponentsValue.Width = 60
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabDataPage)
        Me.TabControl1.Controls.Add(Me.TabResultPage)
        Me.TabControl1.Location = New System.Drawing.Point(128, 82)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(587, 228)
        Me.TabControl1.TabIndex = 51
        '
        'TabDataPage
        '
        Me.TabDataPage.Controls.Add(Me.DataGridView)
        Me.TabDataPage.Location = New System.Drawing.Point(4, 22)
        Me.TabDataPage.Name = "TabDataPage"
        Me.TabDataPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDataPage.Size = New System.Drawing.Size(579, 202)
        Me.TabDataPage.TabIndex = 0
        Me.TabDataPage.Text = "Data page"
        Me.TabDataPage.UseVisualStyleBackColor = True
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(29, 248)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 50
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 159)
        Me.PictureBox1.TabIndex = 53
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(398, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "MultiSell ID:"
        '
        'MultisellIDBox
        '
        Me.MultisellIDBox.Location = New System.Drawing.Point(401, 71)
        Me.MultisellIDBox.Name = "MultisellIDBox"
        Me.MultisellIDBox.Size = New System.Drawing.Size(60, 20)
        Me.MultisellIDBox.TabIndex = 58
        Me.MultisellIDBox.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(481, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "is_dutyfree:"
        '
        'IsDutyfreeBox
        '
        Me.IsDutyfreeBox.FormattingEnabled = True
        Me.IsDutyfreeBox.Items.AddRange(New Object() {"False", "True"})
        Me.IsDutyfreeBox.Location = New System.Drawing.Point(484, 69)
        Me.IsDutyfreeBox.Name = "IsDutyfreeBox"
        Me.IsDutyfreeBox.Size = New System.Drawing.Size(60, 21)
        Me.IsDutyfreeBox.TabIndex = 61
        '
        'IsShowAllBox
        '
        Me.IsShowAllBox.FormattingEnabled = True
        Me.IsShowAllBox.Items.AddRange(New Object() {"False", "True"})
        Me.IsShowAllBox.Location = New System.Drawing.Point(552, 69)
        Me.IsShowAllBox.Name = "IsShowAllBox"
        Me.IsShowAllBox.Size = New System.Drawing.Size(60, 21)
        Me.IsShowAllBox.TabIndex = 63
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(549, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "is_show_all:"
        '
        'KeepEnchantedBox
        '
        Me.KeepEnchantedBox.FormattingEnabled = True
        Me.KeepEnchantedBox.Items.AddRange(New Object() {"False", "True"})
        Me.KeepEnchantedBox.Location = New System.Drawing.Point(618, 69)
        Me.KeepEnchantedBox.Name = "KeepEnchantedBox"
        Me.KeepEnchantedBox.Size = New System.Drawing.Size(60, 21)
        Me.KeepEnchantedBox.TabIndex = 65
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(615, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "keep_enchanted:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(129, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "MultiSell Note:"
        '
        'MultisellNoteBox
        '
        Me.MultisellNoteBox.Location = New System.Drawing.Point(132, 30)
        Me.MultisellNoteBox.Name = "MultisellNoteBox"
        Me.MultisellNoteBox.Size = New System.Drawing.Size(256, 20)
        Me.MultisellNoteBox.TabIndex = 66
        Me.MultisellNoteBox.Text = "L2ScriptMaker New Multisell"
        '
        'MultisellEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 316)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.MultisellNoteBox)
        Me.Controls.Add(Me.KeepEnchantedBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.IsShowAllBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.IsDutyfreeBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MultisellIDBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BuySellListTextBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonImport)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonQuit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MultisellEditor"
        Me.Text = "Multisell Generator"
        Me.TabResultPage.ResumeLayout(False)
        Me.TabResultPage.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabDataPage.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BuySellListBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabResultPage As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BuySellListTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonImport As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabDataPage As System.Windows.Forms.TabPage
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents ItemList As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ItemValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemsComponentsList As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ItemsComponentsValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MultisellIDBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents IsDutyfreeBox As System.Windows.Forms.ComboBox
    Friend WithEvents IsShowAllBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents KeepEnchantedBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MultisellNoteBox As System.Windows.Forms.TextBox
End Class
