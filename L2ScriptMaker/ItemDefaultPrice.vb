Public Class ItemDefaultPrice

    Private Sub DefaultPrice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TownTax.Text = "0"
        CastleTax.Text = "0"
        ShopPrice.Text = "0"
        DefaultItemPrice.Text = "0"
    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Close()
    End Sub

    Private Sub ShopPrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShopPrice.Leave
        DefaultItemPrice.Text = CInt((Val(ShopPrice.Text) * 100) / (100 + Val(TownTax.Text) + Val(CastleTax.Text))).ToString  '=(A5*100)/(100+$H$4+$I$4)
    End Sub

    Private Sub DefaultItemPrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DefaultItemPrice.Leave
        ShopPrice.Text = CInt(Val(DefaultItemPrice.Text) + Val(DefaultItemPrice.Text) / 100 * Val(TownTax.Text) + Val(DefaultItemPrice.Text) / 100 * Val(CastleTax.Text)).ToString '=B5+B5/100*$H$4+B5/100*$I$4
    End Sub

    Private Sub TownTax_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TownTax.Leave
        DefaultItemPrice.Text = CInt((Val(ShopPrice.Text) * 100) / (100 + Val(TownTax.Text) + Val(CastleTax.Text))).ToString  '=(A5*100)/(100+$H$4+$I$4)
    End Sub

    Private Sub CastleTax_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CastleTax.Leave
        DefaultItemPrice.Text = CInt((Val(ShopPrice.Text) * 100) / (100 + Val(TownTax.Text) + Val(CastleTax.Text))).ToString  '=(A5*100)/(100+$H$4+$I$4)
    End Sub
End Class