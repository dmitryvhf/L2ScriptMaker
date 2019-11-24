<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemDefaultPrice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemDefaultPrice))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TownTax = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CastleTax = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ShopPrice = New System.Windows.Forms.TextBox
        Me.DefaultItem = New System.Windows.Forms.Label
        Me.DefaultItemPrice = New System.Windows.Forms.TextBox
        Me.ButtonQuit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(344, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tool for find default_price from known Castle Tax Rate, Town Tax Rate"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(105, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "and Shop price for this item"
        '
        'TownTax
        '
        Me.TownTax.Location = New System.Drawing.Point(12, 64)
        Me.TownTax.Name = "TownTax"
        Me.TownTax.Size = New System.Drawing.Size(100, 20)
        Me.TownTax.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Town City tax rate:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Castle City tax rate:"
        '
        'CastleTax
        '
        Me.CastleTax.Location = New System.Drawing.Point(12, 103)
        Me.CastleTax.Name = "CastleTax"
        Me.CastleTax.Size = New System.Drawing.Size(100, 20)
        Me.CastleTax.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Shop price:"
        '
        'ShopPrice
        '
        Me.ShopPrice.Location = New System.Drawing.Point(136, 64)
        Me.ShopPrice.Name = "ShopPrice"
        Me.ShopPrice.Size = New System.Drawing.Size(100, 20)
        Me.ShopPrice.TabIndex = 6
        '
        'DefaultItem
        '
        Me.DefaultItem.AutoSize = True
        Me.DefaultItem.Location = New System.Drawing.Point(255, 48)
        Me.DefaultItem.Name = "DefaultItem"
        Me.DefaultItem.Size = New System.Drawing.Size(67, 13)
        Me.DefaultItem.TabIndex = 10
        Me.DefaultItem.Text = "Default Item:"
        '
        'DefaultItemPrice
        '
        Me.DefaultItemPrice.Location = New System.Drawing.Point(255, 64)
        Me.DefaultItemPrice.Name = "DefaultItemPrice"
        Me.DefaultItemPrice.Size = New System.Drawing.Size(100, 20)
        Me.DefaultItemPrice.TabIndex = 9
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(281, 113)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 11
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ItemDefaultPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 148)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.DefaultItem)
        Me.Controls.Add(Me.DefaultItemPrice)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ShopPrice)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CastleTax)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TownTax)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ItemDefaultPrice"
        Me.Text = "DefaultPrice finder tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TownTax As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CastleTax As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ShopPrice As System.Windows.Forms.TextBox
    Friend WithEvents DefaultItem As System.Windows.Forms.Label
    Friend WithEvents DefaultItemPrice As System.Windows.Forms.TextBox
    Friend WithEvents ButtonQuit As System.Windows.Forms.Button
End Class
