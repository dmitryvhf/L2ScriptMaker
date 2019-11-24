Public Class ItemPchMaker

    'Dim TabSymbol As String = Chr(9)
    Dim TabSymbol As String = " "

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim TempStr As String
        'Dim FirstPos, SecondPos As Integer
        Dim ItemData() As String
        Dim ItemDataFile, ItemDataDir As String

        OpenFileDialog.InitialDirectory = System.Environment.CurrentDirectory
        OpenFileDialog.Filter = "Lineage II Item config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        ItemDataFile = OpenFileDialog.FileName
        ItemDataDir = System.IO.Path.GetDirectoryName(ItemDataFile)

        Dim inItemData As New System.IO.StreamReader(ItemDataFile, System.Text.Encoding.Default, True, 1)

        If System.IO.File.Exists(ItemDataDir + "\item_pch.txt") = True Then
            If MessageBox.Show("File item_pch.txt exist. Overwrite?", "Overwrite?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If

        Dim oPchFile As System.IO.Stream = New System.IO.FileStream(ItemDataDir + "\item_pch.txt", _
                IO.FileMode.Create, IO.FileAccess.Write)
        Dim outItemPchData As System.IO.StreamWriter = New System.IO.StreamWriter(oPchFile, _
                System.Text.Encoding.Unicode)

        Dim oErrFile As System.IO.Stream = New System.IO.FileStream(ItemDataDir + "\~item_pch.log", _
        IO.FileMode.Create, IO.FileAccess.Write)
        Dim outErrPchData As System.IO.StreamWriter = New System.IO.StreamWriter(oErrFile, _
                System.Text.Encoding.Unicode)

        outErrPchData.WriteLine(Now)

        While inItemData.BaseStream.Position <> inItemData.BaseStream.Length

            'ItemData = Replace(inItemData.ReadLine, Chr(9), TabSymbol).Split(Chr(32))
            TempStr = Replace(inItemData.ReadLine, Chr(9), TabSymbol)

            If Mid(Trim(TempStr), 1, 2) <> "//" And TempStr <> Nothing And InStr(TempStr, "set_begin") = 0 Then

                ' tabs and spaces correction
                While InStr(TempStr, "  ") <> 0
                    TempStr = Replace(TempStr, "  ", TabSymbol)
                End While
                ItemData = TempStr.Split(Chr(32))


                If InStr(ItemData(0), "item_begin") <> 0 Then

                    outItemPchData.Write(ItemData(3) & TabSymbol & "=" & TabSymbol)
                    outItemPchData.WriteLine(ItemData(2))

                Else
                    ' It's set or another/unknown
                End If

            End If

            ProgressBar.Value = CInt(inItemData.BaseStream.Position * 100 / inItemData.BaseStream.Length)

        End While

        inItemData.Close()
        outItemPchData.Close()
        outErrPchData.Close()

        System.IO.File.Create(ItemDataDir + "\item_pch2.txt")


        ProgressBar.Value = 0
    End Sub

    Private Sub ItemCacheScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCacheScript.Click
        '1      [Short Sword]   [no description]      consume_type_normal     0

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim inEFile As System.IO.StreamReader
        Try
            inEFile = New System.IO.StreamReader(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + "\itemname-e.txt", System.Text.Encoding.Default, True, 1)
        Catch ex As Exception
            MessageBox.Show("You must have itemdata-e in work folder for generation itemcache file. Put and try again.")
            Exit Sub
        End Try

        ' Initialization
        ProgressBar.Value = 0
        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        Dim oAiFile As System.IO.Stream = New System.IO.FileStream(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + "\itemcache.txt", _
            IO.FileMode.Create, IO.FileAccess.Write)
        Dim outAiData As System.IO.StreamWriter = New System.IO.StreamWriter(oAiFile, _
                System.Text.Encoding.Unicode, 1)

        Dim ReadStr, OutStr As String
        Dim ReadSplitStr() As String

        ProgressBar.Value = 0
        ProgressBar.Maximum = CInt(inEFile.BaseStream.Length)
        Dim ItemDB(30000, 3) As String '0- id, 1 - name, 2 - consume, 3 - type (for quest)
        Dim ItemDBMarker As Integer = 0
        Dim CommentName As String
        Dim CommentDescription As String

        While inEFile.EndOfStream <> True

            ReadStr = inEFile.ReadLine

            If ReadStr <> Nothing Then
                If Mid(ReadStr, 1, 2) <> "//" Then
                    ReadSplitStr = ReadStr.Split(Chr(9))
                    ItemDBMarker = CInt(ReadSplitStr(1).Replace("id=", ""))
                    If ItemDBMarker >= 30000 Then
                        MessageBox.Show("Item ID must be less then 30000. Custom items not supported. Last item_id:" + ItemDBMarker.ToString, "ItemID above them 30000", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ProgressBar.Value = 0
                        inFile.Close()
                        outAiData.Close()
                        Exit Sub
                    End If
                    ItemDB(ItemDBMarker, 0) = ReadSplitStr(2).Replace("name=", "")
                    ItemDB(ItemDBMarker, 1) = ReadSplitStr(5).Replace("description=", "")
                End If
            End If
            ProgressBar.Value = CInt(inFile.BaseStream.Position * 100 / inFile.BaseStream.Length)
        End While

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ProgressBar.Value = 0

        Do While inFile.BaseStream.Position <> inFile.BaseStream.Length

            ReadStr = Replace(inFile.ReadLine, Chr(9), Chr(32))


            ' tabs and spaces correction
            While InStr(ReadStr, "  ") <> 0
                ReadStr = Replace(ReadStr, "  ", Chr(32))
            End While

            If ReadStr <> Nothing Then
                If Mid(Trim(ReadStr), 1, 2) <> "//" Then


                    ReadSplitStr = ReadStr.Split(Chr(32))
                    If InStr(ReadStr, "set_begin") = 0 Then


                        'Find Item in Itemname-e
                        CommentName = ReadSplitStr(3)
                        CommentDescription = "[no description]"

                        ItemDBMarker = CInt(ReadSplitStr(2))
                        If ItemDBMarker <= 30000 Then
                            If ItemDB(ItemDBMarker, 0) <> "" Then
                                CommentName = ItemDB(ItemDBMarker, 0)
                            End If
                            If ItemDB(ItemDBMarker, 1) <> "" Then
                                CommentDescription = ItemDB(ItemDBMarker, 1)
                            End If
                        Else
                            If StopError.Checked = False Then
                                CommentName = "[L2ScriptMaker: Customs skills not supported]"
                                CommentDescription = "[L2ScriptMaker: Customs skills not supported]"
                            Else
                                MessageBox.Show("Item ID must be less then 30000. Custom Items not supported. Last item_id:" + ItemDBMarker.ToString, "ItemID above them 30000", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ProgressBar.Value = 0
                                inFile.Close()
                                outAiData.Close()
                                Exit Sub
                            End If
                        End If

                        ' 500 symbols fix
                        If CommentDescription.Length > 500 Then CommentDescription = CommentDescription.Substring(0, 500) & "]"

                        OutStr = ReadSplitStr(2) + Chr(9) + CommentName + Chr(9) + CommentDescription + Chr(9)

                        If InStr(ReadStr, "consume_type_normal") <> 0 Then
                            OutStr += "consume_type_normal" + Chr(9)
                        ElseIf InStr(ReadStr, "consume_type_stackable") <> 0 Then
                            OutStr += "consume_type_stackable" + Chr(9)
                        ElseIf InStr(ReadStr, "consume_type_asset") <> 0 Then
                            OutStr += "consume_type_asset" + Chr(9)
                        Else
                            MessageBox.Show("Unknown consume_type. Please report me about it", "Unknown consume_type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            inFile.Close()
                            outAiData.Close()
                            Exit Sub
                        End If

                        If InStr(ReadStr, "questitem") <> 0 Then
                            OutStr += "1"
                        Else
                            OutStr += "0"
                        End If

                        outAiData.WriteLine(OutStr)
                    End If


                End If
            End If

            ProgressBar.Value = CInt(inFile.BaseStream.Position * 100 / inFile.BaseStream.Length)
        Loop

        MessageBox.Show("itemcache.txt Complete")
        ProgressBar.Value = 0
        inFile.Close()
        outAiData.Close()
    End Sub


    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub
End Class