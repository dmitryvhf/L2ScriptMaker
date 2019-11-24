<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AIbuyselllistEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AIbuyselllistEditor))
        Me.DataGridView = New System.Windows.Forms.DataGridView
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabDataPage = New System.Windows.Forms.TabPage
        Me.TabResultPage = New System.Windows.Forms.TabPage
        Me.BuySellListBox = New System.Windows.Forms.TextBox
        Me.ButtonImport = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BuySellListTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ItemList = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.CityTax = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabDataPage.SuspendLayout()
        Me.TabResultPage.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView
        '
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemList, Me.CityTax})
        Me.DataGridView.Location = New System.Drawing.Point(9, 6)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.Size = New System.Drawing.Size(296, 219)
        Me.DataGridView.TabIndex = 0
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(29, 225)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 1
        Me.ButtonStart.Text = "Generate"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(29, 254)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 2
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabDataPage)
        Me.TabControl1.Controls.Add(Me.TabResultPage)
        Me.TabControl1.Location = New System.Drawing.Point(128, 54)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(316, 256)
        Me.TabControl1.TabIndex = 3
        '
        'TabDataPage
        '
        Me.TabDataPage.Controls.Add(Me.DataGridView)
        Me.TabDataPage.Location = New System.Drawing.Point(4, 22)
        Me.TabDataPage.Name = "TabDataPage"
        Me.TabDataPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDataPage.Size = New System.Drawing.Size(308, 230)
        Me.TabDataPage.TabIndex = 0
        Me.TabDataPage.Text = "Data page"
        Me.TabDataPage.UseVisualStyleBackColor = True
        '
        'TabResultPage
        '
        Me.TabResultPage.Controls.Add(Me.BuySellListBox)
        Me.TabResultPage.Location = New System.Drawing.Point(4, 22)
        Me.TabResultPage.Name = "TabResultPage"
        Me.TabResultPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TabResultPage.Size = New System.Drawing.Size(308, 230)
        Me.TabResultPage.TabIndex = 1
        Me.TabResultPage.Text = "Result page"
        Me.TabResultPage.UseVisualStyleBackColor = True
        '
        'BuySellListBox
        '
        Me.BuySellListBox.Location = New System.Drawing.Point(6, 6)
        Me.BuySellListBox.Multiline = True
        Me.BuySellListBox.Name = "BuySellListBox"
        Me.BuySellListBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.BuySellListBox.Size = New System.Drawing.Size(296, 218)
        Me.BuySellListBox.TabIndex = 0
        '
        'ButtonImport
        '
        Me.ButtonImport.Location = New System.Drawing.Point(29, 196)
        Me.ButtonImport.Name = "ButtonImport"
        Me.ButtonImport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonImport.TabIndex = 4
        Me.ButtonImport.Text = "Import"
        Me.ButtonImport.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.L2ScriptMaker.My.Resources.Resources.avatar14_22
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 159)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'BuySellListTextBox
        '
        Me.BuySellListTextBox.Location = New System.Drawing.Point(132, 28)
        Me.BuySellListTextBox.Name = "BuySellListTextBox"
        Me.BuySellListTextBox.Size = New System.Drawing.Size(151, 20)
        Me.BuySellListTextBox.TabIndex = 6
        Me.BuySellListTextBox.Text = "SellList0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(129, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "BuySellList name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(295, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "(support C4 scripts)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(295, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "AI.obj shop list maker"
        '
        'ItemList
        '
        Me.ItemList.HeaderText = "ItemList"
        Me.ItemList.Name = "ItemList"
        Me.ItemList.Width = 200
        '
        'CityTax
        '
        Me.CityTax.HeaderText = "CityTax"
        Me.CityTax.Name = "CityTax"
        Me.CityTax.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CityTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CityTax.Width = 50
        '
        'AIbuyselllistEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 313)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BuySellListTextBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonImport)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AIbuyselllistEditor"
        Me.Text = "AIbuyselllistEditor"
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabDataPage.ResumeLayout(False)
        Me.TabResultPage.ResumeLayout(False)
        Me.TabResultPage.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabDataPage As System.Windows.Forms.TabPage
    Friend WithEvents TabResultPage As System.Windows.Forms.TabPage
    Friend WithEvents BuySellListBox As System.Windows.Forms.TextBox
    Friend WithEvents ButtonImport As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BuySellListTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ItemList As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents CityTax As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
