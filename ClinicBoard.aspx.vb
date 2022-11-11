Imports System.Data

Partial Class Pages_ClinicBoard
    Inherits System.Web.UI.Page

    Dim MyUser As String
    Dim MyPID As Integer
    Dim MyToDay As Date
    Dim Array(13, 12) As String
    Dim Array2(13, 12) As String
    Dim DontCare As String = Nothing
    Dim size As String = "18"
    Dim Ready As Boolean = True
    Dim ReadyUser As String = Nothing
    Dim Ready2 As Boolean = True
    Dim ReadyUser2 As String = Nothing
    Dim LabelRoomDict As New Dictionary(Of String, Object)
    Dim LinkButtonRoomDict As New Dictionary(Of String, Object)
    Dim LinkDict As New Dictionary(Of String, Object)
    Dim ImageDict As New Dictionary(Of String, Object)
    Dim TextDict As New Dictionary(Of String, Object)
    Dim LabelLinkDict As New Dictionary(Of String, Object)
    Dim ButtonDict As New Dictionary(Of String, Object)
    Dim NameChanged As Integer = Nothing
    Dim RoomChanged As Integer = Nothing

    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        With Me
            If Not IsPostBack Then
                InitializeDictionaries()
                InitializeSize()

            ElseIf IsPostBack Then
                MyToDay = ViewState("DateCal")
                InitializeDictionaries()
            End If
        End With

    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged

        With Me
            Try
                .MyToDay = Calendar1.SelectedDate
                ViewState("DateCal") = .MyToDay
                LabelDate.Text = .MyToDay
                LabelDatea.Text = .MyToDay
                Ready = True
                Ready2 = True
                NotReady.Text = Nothing
                notreadya.Text = Nothing
                btnReturnM.Visible = True
                btnReturnA.Visible = True
                PanelCalendar.Visible = False
                PanelBoardMorning.Visible = True
                btnAfternoon.Visible = True
                TableBoardMorning.Visible = True
                InitBoards()
                If ReadSQLData(DontCare) Then
                End If
                Timer2.Enabled = True
            Catch ex As Exception
            End Try
        End With

    End Sub

    'Initialize Morning Board
    Private Function InitBoards() As String
        'initialize everything for a new board
        For i = 1 To 8
            Dim tempObj As New Object
            Dim tempObj2 As New Object
            TextDict.TryGetValue("TextBoxPat" & i, tempObj)
            tempObj.Text = "Click to Edit"
            LinkDict.TryGetValue("LinkPat" & i, tempObj)
            tempObj.ForeColor = Drawing.Color.LightGray
            tempObj.Text = "Click to Edit"
            tempObj.ToolTip = "Click to Edit"
            TextDict.TryGetValue("TextBox" & i, tempObj)
            tempObj.Text = "Click to Edit"
            LinkDict.TryGetValue("Link" & i, tempObj)
            tempObj.Text = "Click to Edit"
            tempObj.ForeColor = Drawing.Color.LightGray
            LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
            '/////////////////////////////////////////////////////////
            Try
                Dim MyLastWeek As Date = MyToDay.AddDays(-7)
                Dim RN = From AA In TPDC.tblClinics
                         Select AA.Id, AA.ClinicDate, AA.RoomNames
                         Where ClinicDate = MyLastWeek

                Dim tempVar As String = RN.FirstOrDefault.RoomNames
                Dim tempArr(8) As String
                Dim n As Integer = 1
                For k = 0 To tempVar.Length - 1
                    If tempVar.Chars(k) <> "^" Then
                        tempArr(n) += tempVar.Chars(k)
                    ElseIf tempVar.Chars(k) = "^" Then
                        n += 1
                    End If
                Next
                For j = 1 To 8
                    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & j, tempObj)
                    tempObj.Text = tempArr(j)
                Next
            Catch ex2 As Exception
                For j = 1 To 8
                    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & j, tempObj)
                    tempObj.Text = "Room " & j
                Next
            End Try
            '/////////////////////////////////////////////////////////
            For k = 1 To 7
                ImageDict.TryGetValue("Imagebutton" & i & k, tempObj)
                If k < 6 Then
                    tempObj.ImageUrl = "~/Images/clear.png"
                Else
                    tempObj.ImageUrl = "~/Images/clear75.png"
                End If
                LinkDict.TryGetValue("LinkButtonM" & i & k, tempObj)
                tempObj.Text = "Add Note"
                tempObj.ForeColor = Drawing.Color.LightGray
                TextDict.TryGetValue("TextBoxM" & i & k, tempObj)
                tempObj.Text = "Add Note"

            Next
        Next
        Try
            For i = 1 To 8
                Dim tempObj As New Object
                Dim tempObj2 As New Object
                TextDict.TryGetValue("TextBoxHeader" & i, tempObj)
                LinkDict.TryGetValue("LinkButtonHeader" & i, tempObj2)
                Select Case i
                    Case "1"
                        tempObj.Text = "PA"
                        tempObj2.Text = "PA"
                    Case "2"
                        tempObj.Text = "Hepatology"
                        tempObj2.Text = "Hepatology"
                    Case "3"
                        tempObj.Text = "Med/Onc"
                        tempObj2.Text = "Med/Onc"
                    Case "4"
                        tempObj.Text = "Social Work"
                        tempObj2.Text = "Social Work"
                    Case "5"
                        tempObj.Text = "Dietitian"
                        tempObj2.Text = "Dietitian"
                    Case "6"
                        tempObj.Text = "Lab"
                        tempObj2.Text = "Lab"
                    Case "7"
                        tempObj.Text = "Imaging"
                        tempObj2.Text = "Imaging"
                    Case "8"
                        tempObj.Text = "Notes"
                        tempObj2.Text = "Notes"
                End Select
            Next
        Catch ex As Exception
        End Try

        'initialize everything for a new board afternoon
        Try
            For i = 1 To 8
                Dim tempObj As New Object
                Dim tempObj2 As New Object
                TextDict.TryGetValue("TextBoxPat" & i & "a", tempObj)
                tempObj.Text = "Click to Edit"
                LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                tempObj.ForeColor = Drawing.Color.LightGray
                tempObj.Text = "Click to Edit"
                tempObj.ToolTip = "Click to Edit"
                TextDict.TryGetValue("TextBox" & i & "a", tempObj)
                tempObj.Text = "Click to Edit"
                LinkDict.TryGetValue("Link" & i & "a", tempObj)
                tempObj.ForeColor = Drawing.Color.LightGray
                tempObj.Text = "Click to Edit"
                LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                '/////////////////////////////////////////////////////////
                Try
                    Dim MyLastWeek As Date = MyToDay.AddDays(-7)
                    Dim RN = From AA In TPDC.tblClinics
                             Select AA.Id, AA.ClinicDate, AA.RoomNames2
                             Where ClinicDate = MyLastWeek

                    Dim tempVar As String = RN.FirstOrDefault.RoomNames2
                    Dim tempArr(8) As String
                    Dim n As Integer = 1
                    For k = 0 To tempVar.Length - 1
                        If tempVar.Chars(k) <> "^" Then
                            tempArr(n) += tempVar.Chars(k)
                        ElseIf tempVar.Chars(k) = "^" Then
                            n += 1
                        End If
                    Next
                    For j = 1 To 8
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & j & "a", tempObj)
                        tempObj.Text = tempArr(j)
                    Next
                Catch ex2 As Exception
                    For j = 1 To 8
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & j & "a", tempObj)
                        tempObj.Text = "Room " & j
                    Next
                End Try
                '/////////////////////////////////////////////////////////
                For k = 1 To 6
                    ImageDict.TryGetValue("Imagebutton" & i & k & "a", tempObj)
                    tempObj.ImageUrl = "~/Images/nottobeseen.png"
                    LinkDict.TryGetValue("LinkButtonA" & i & k, tempObj)
                    tempObj.ForeColor = Drawing.Color.LightGray
                    tempObj.Text = "Add Note"
                    TextDict.TryGetValue("TextBoxA" & i & k, tempObj)
                    tempObj.Text = "Add Note"
                Next
            Next
        Catch ex As Exception
        End Try
        For i = 1 To 7
            Dim tempObj As New Object
            Dim tempObj2 As New Object
            TextDict.TryGetValue("TextBoxHeader" & i & "a", tempObj)
            LinkDict.TryGetValue("LinkButtonHeader" & i & "a", tempObj2)
            Select Case i
                Case "1"
                    tempObj.Text = "PA"
                    tempObj2.Text = "PA"
                Case "2"
                    tempObj.Text = "Surgeon"
                    tempObj2.Text = "Surgeon"
                Case "3"
                    tempObj.Text = "IR"
                    tempObj2.Text = "IR"
                Case "4"
                    tempObj.Text = "Dietitian"
                    tempObj2.Text = "Dietitian"
                Case "5"
                    tempObj.Text = "Social Work"
                    tempObj2.Text = "Social Work"
                Case "6"
                    tempObj.Text = "Med/Onc"
                    tempObj2.Text = "Med/Onc"
                Case "7"
                    tempObj.Text = "Notes"
                    tempObj2.Text = "Notes"
            End Select
        Next

        Return True
    End Function

    'ImageButton Change by Click
    Protected Sub Change_Command(sender As Object, e As CommandEventArgs)

        Try
            ReadCheckRead()
            If PanelBoardMorning.Visible = True Then
                If Ready = True Or (Ready = False And ReadyUser = MyUser) Then
                    Select Case sender.ImageURL
                        Case "~/Images/clear.png"
                            sender.ImageURL = "~/Images/willbeseen.png"
                        Case "~/Images/willbeseen.png"
                            sender.ImageURL = "~/Images/inroom2.png"
                        Case "~/Images/inroom2.png"
                            sender.ImageURL = "~/Images/done.png"
                        Case "~/Images/done.png"
                            sender.ImageURL = "~/Images/clear.png"
                        Case "~/Images/clear75.png"
                            sender.ImageURL = "~/Images/check.png"
                        Case "~/Images/check.png"
                            sender.ImageURL = "~/Images/x.png"
                        Case "~/Images/x.png"
                            sender.ImageURL = "~/Images/clear75.png"
                    End Select
                    Ready = True
                    If WriteSQLData(DontCare) Then
                    End If
                End If
            ElseIf PanelBoardAfternoon.Visible = True Then
                If Ready2 = True Or (Ready2 = False And ReadyUser2 = MyUser) Then
                    Select Case sender.ImageURL
                        Case "~/Images/nottobeseen.png"
                            sender.ImageURL = "~/Images/willbeseen.png"
                        Case "~/Images/willbeseen.png"
                            sender.ImageURL = "~/Images/inroom2.png"
                        Case "~/Images/inroom2.png"
                            sender.ImageURL = "~/Images/done.png"
                        Case "~/Images/done.png"
                            sender.ImageURL = "~/Images/nottobeseen.png"
                    End Select
                    Ready2 = True
                    If WriteSQLData(DontCare) Then
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnAfternoon_Click(sender As Object, e As System.EventArgs) Handles btnAfternoon.Click
        Try
            PanelBoardMorning.Visible = False
            TableBoardMorning.Visible = False
            btnAfternoon.Visible = False

            PanelBoardAfternoon.Visible = True
            TableBoardAfternoon.Visible = True
            btnMorning.Visible = True
            If ReadSQLData(DontCare) Then
            End If
            Timer2.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnMorning_Click(sender As Object, e As System.EventArgs) Handles btnMorning.Click
        Try
            PanelBoardMorning.Visible = True
            TableBoardMorning.Visible = True
            btnAfternoon.Visible = True

            PanelBoardAfternoon.Visible = False
            TableBoardAfternoon.Visible = False
            btnMorning.Visible = False
            If ReadSQLData(DontCare) Then
            End If
            Timer2.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    'TextBox to Link and Label Notes
    Public Sub TextChanged(ByVal Sender As Object, ByVal e As EventArgs)
        Try
            If PanelBoardMorning.Visible = True Then
                Dim ID As String = Sender.ID.ToString()
                Dim Num As String = Nothing
                If ID.Contains("1") Then
                    Num = "1"
                ElseIf ID.Contains("2") Then
                    Num = "2"
                ElseIf ID.Contains("3") Then
                    Num = "3"
                ElseIf ID.Contains("4") Then
                    Num = "4"
                ElseIf ID.Contains("5") Then
                    Num = "5"
                ElseIf ID.Contains("6") Then
                    Num = "6"
                ElseIf ID.Contains("7") Then
                    Num = "7"
                ElseIf ID.Contains("8") Then
                    Num = "8"
                End If
                If ID.Contains("TextBoxRoom") Or ID.Contains("ButtonRoom") Then
                    Select Case Num
                        Case "1"
                            If TextBoxRoom1.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom1.Text = TextBoxRoom1.Text.Trim()
                            End If
                            LinkButtonRoom1.Visible = True
                            TextBoxRoom1.Visible = False
                            ButtonRoom1.Visible = False
                            LinkButtonDone1.Visible = True
                        Case "2"
                            If TextBoxRoom2.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom2.Text = TextBoxRoom2.Text.Trim()
                            End If
                            LinkButtonRoom2.Visible = True
                            TextBoxRoom2.Visible = False
                            ButtonRoom2.Visible = False
                            LinkButtonDone2.Visible = True
                        Case "3"
                            If TextBoxRoom3.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom3.Text = TextBoxRoom3.Text.Trim()
                            End If
                            LinkButtonRoom3.Visible = True
                            TextBoxRoom3.Visible = False
                            ButtonRoom3.Visible = False
                            LinkButtonDone3.Visible = True
                        Case "4"
                            If TextBoxRoom4.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom4.Text = TextBoxRoom4.Text.Trim()
                            End If
                            LinkButtonRoom4.Visible = True
                            TextBoxRoom4.Visible = False
                            ButtonRoom4.Visible = False
                            LinkButtonDone4.Visible = True
                        Case "5"
                            If TextBoxRoom5.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom5.Text = TextBoxRoom5.Text.Trim()
                            End If
                            LinkButtonRoom5.Visible = True
                            TextBoxRoom5.Visible = False
                            ButtonRoom5.Visible = False
                            LinkButtonDone5.Visible = True
                        Case "6"
                            If TextBoxRoom6.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom6.Text = TextBoxRoom6.Text.Trim()
                            End If
                            LinkButtonRoom6.Visible = True
                            TextBoxRoom6.Visible = False
                            ButtonRoom6.Visible = False
                            LinkButtonDone6.Visible = True
                        Case "7"
                            If TextBoxRoom7.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom7.Text = TextBoxRoom7.Text.Trim()
                            End If
                            LinkButtonRoom7.Visible = True
                            TextBoxRoom7.Visible = False
                            ButtonRoom7.Visible = False
                            LinkButtonDone7.Visible = True
                        Case "8"
                            If TextBoxRoom8.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom8.Text = TextBoxRoom8.Text.Trim()
                            End If
                            LinkButtonRoom8.Visible = True
                            TextBoxRoom8.Visible = False
                            ButtonRoom8.Visible = False
                            LinkButtonDone8.Visible = True
                    End Select
                    RoomChanged += 1
                ElseIf ID.Contains("TextBoxPat") Or ID.Contains("ButtonPat") Then
                    Select Case Num
                        Case "1"
                            Dim test As String = TextBoxPat1.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat1.Text = "Click to Edit"
                                LinkPat1.ToolTip = "Click to Edit"
                                LinkPat1.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat1.Text.Replace(vbLf, " ")
                                LinkPat1.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat1.Text = str
                                LinkPat1.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat1.Visible = False
                            ButtonPat1.Visible = False
                            LinkPat1.Visible = True
                        Case "2"
                            Dim test As String = TextBoxPat2.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat2.Text = "Click to Edit"
                                LinkPat2.ToolTip = "Click to Edit"
                                LinkPat2.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat2.Text.Replace(vbLf, " ")
                                LinkPat2.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat2.Text = str
                                LinkPat2.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat2.Visible = False
                            ButtonPat2.Visible = False
                            LinkPat2.Visible = True
                        Case "3"
                            Dim test As String = TextBoxPat3.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat3.Text = "Click to Edit"
                                LinkPat3.ToolTip = "Click to Edit"
                                LinkPat3.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat3.Text.Replace(vbLf, " ")
                                LinkPat3.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat3.Text = str
                                LinkPat3.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat3.Visible = False
                            ButtonPat3.Visible = False
                            LinkPat3.Visible = True
                        Case "4"
                            Dim test As String = TextBoxPat4.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat4.Text = "Click to Edit"
                                LinkPat4.ToolTip = "Click to Edit"
                                LinkPat4.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat4.Text.Replace(vbLf, " ")
                                LinkPat4.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat4.Text = str
                                LinkPat4.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat4.Visible = False
                            ButtonPat4.Visible = False
                            LinkPat4.Visible = True
                        Case "5"
                            Dim test As String = TextBoxPat5.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat5.Text = "Click to Edit"
                                LinkPat5.ToolTip = "Click to Edit"
                                LinkPat5.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat5.Text.Replace(vbLf, " ")
                                LinkPat5.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat5.Text = str
                                LinkPat5.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat5.Visible = False
                            ButtonPat5.Visible = False
                            LinkPat5.Visible = True
                        Case "6"
                            Dim test As String = TextBoxPat6.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat6.Text = "Click to Edit"
                                LinkPat6.ToolTip = "Click to Edit"
                                LinkPat6.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat6.Text.Replace(vbLf, " ")
                                LinkPat6.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat6.Text = str
                                LinkPat6.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat6.Visible = False
                            ButtonPat6.Visible = False
                            LinkPat6.Visible = True
                        Case "7"
                            Dim test As String = TextBoxPat7.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat7.Text = "Click to Edit"
                                LinkPat7.ToolTip = "Click to Edit"
                                LinkPat7.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat7.Text.Replace(vbLf, " ")
                                LinkPat7.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat7.Text = str
                                LinkPat7.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat7.Visible = False
                            ButtonPat7.Visible = False
                            LinkPat7.Visible = True
                        Case "8"
                            Dim test As String = TextBoxPat8.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat8.Text = "Click to Edit"
                                LinkPat8.ToolTip = "Click to Edit"
                                LinkPat8.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat8.Text.Replace(vbLf, " ")
                                LinkPat8.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat8.Text = str
                                LinkPat8.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat8.Visible = False
                            ButtonPat8.Visible = False
                            LinkPat8.Visible = True
                    End Select
                    NameChanged += 1
                ElseIf ID.Contains("Header") Then
                    Select Case Num
                        Case "1"
                            Dim test As String = TextBoxHeader1.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader1.Text = "PA"
                            Else
                                Dim str As String = TextBoxHeader1.Text
                                LinkButtonHeader1.Text = str
                            End If
                            TextBoxHeader1.Visible = False
                            ButtonHeader1.Visible = False
                            LinkButtonHeader1.Visible = True
                        Case "2"
                            Dim test As String = TextBoxHeader2.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader2.Text = "Hepatology"
                            Else
                                Dim str As String = TextBoxHeader2.Text
                                LinkButtonHeader2.Text = str
                            End If
                            TextBoxHeader2.Visible = False
                            ButtonHeader2.Visible = False
                            LinkButtonHeader2.Visible = True
                        Case "3"
                            Dim test As String = TextBoxHeader3.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader3.Text = "Med/Onc"
                            Else
                                Dim str As String = TextBoxHeader3.Text
                                LinkButtonHeader3.Text = str
                            End If
                            TextBoxHeader3.Visible = False
                            ButtonHeader3.Visible = False
                            LinkButtonHeader3.Visible = True
                        Case "4"
                            Dim test As String = TextBoxHeader4.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader4.Text = "Social Work"
                            Else
                                Dim str As String = TextBoxHeader4.Text
                                LinkButtonHeader4.Text = str
                            End If
                            TextBoxHeader4.Visible = False
                            ButtonHeader4.Visible = False
                            LinkButtonHeader4.Visible = True
                        Case "5"
                            Dim test As String = TextBoxHeader5.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader5.Text = "Dietitian"
                            Else
                                Dim str As String = TextBoxHeader5.Text
                                LinkButtonHeader5.Text = str
                            End If
                            TextBoxHeader5.Visible = False
                            ButtonHeader5.Visible = False
                            LinkButtonHeader5.Visible = True
                        Case "6"
                            Dim test As String = TextBoxHeader6.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader6.Text = "Lab"
                            Else
                                Dim str As String = TextBoxHeader6.Text
                                LinkButtonHeader6.Text = str
                            End If
                            TextBoxHeader6.Visible = False
                            ButtonHeader6.Visible = False
                            LinkButtonHeader6.Visible = True
                        Case "7"
                            Dim test As String = TextBoxHeader7.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader7.Text = "Imaging"
                            Else
                                Dim str As String = TextBoxHeader7.Text
                                LinkButtonHeader7.Text = str
                            End If
                            TextBoxHeader7.Visible = False
                            ButtonHeader7.Visible = False
                            LinkButtonHeader7.Visible = True
                        Case "8"
                            Dim test As String = TextBoxHeader8.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader8.Text = "Notes"
                            Else
                                Dim str As String = TextBoxHeader8.Text
                                LinkButtonHeader8.Text = str
                            End If
                            TextBoxHeader8.Visible = False
                            ButtonHeader8.Visible = False
                            LinkButtonHeader8.Visible = True
                    End Select
                Else
                    Select Case Num
                        Case "1"
                            Dim test As String = TextBox1.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link1.Text = "Click to Edit"
                                Link1.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox1.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link1.Text = str
                                Link1.ForeColor = Drawing.Color.Black
                            End If
                            TextBox1.Visible = False
                            Button1.Visible = False
                            Link1.Visible = True
                        Case "2"
                            Dim test As String = TextBox2.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link2.Text = "Click to Edit"
                                Link2.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox2.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link2.Text = str
                                Link2.ForeColor = Drawing.Color.Black
                            End If
                            TextBox2.Visible = False
                            Button2.Visible = False
                            Link2.Visible = True
                        Case "3"
                            Dim test As String = TextBox3.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link3.Text = "Click to Edit"
                                Link3.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox3.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link3.Text = str
                                Link3.ForeColor = Drawing.Color.Black

                            End If
                            TextBox3.Visible = False
                            Button3.Visible = False
                            Link3.Visible = True
                        Case "4"
                            Dim test As String = TextBox4.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link4.Text = "Click to Edit"
                                Link4.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox4.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link4.Text = str
                                Link4.ForeColor = Drawing.Color.Black
                            End If
                            TextBox4.Visible = False
                            Button4.Visible = False
                            Link4.Visible = True
                        Case "5"
                            Dim test As String = TextBox5.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link5.Text = "Click to Edit"
                                Link5.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox5.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link5.Text = str
                                Link5.ForeColor = Drawing.Color.Black
                            End If
                            TextBox5.Visible = False
                            Button5.Visible = False
                            Link5.Visible = True
                        Case "6"
                            Dim test As String = TextBox6.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link6.Text = "Click to Edit"
                                Link6.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox6.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link6.Text = str
                                Link6.ForeColor = Drawing.Color.Black
                            End If
                            TextBox6.Visible = False
                            Button6.Visible = False
                            Link6.Visible = True
                        Case "7"
                            Dim test As String = TextBox7.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link7.Text = "Click to Edit"
                                Link7.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox7.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link7.Text = str
                                Link7.ForeColor = Drawing.Color.Black
                            End If
                            TextBox7.Visible = False
                            Button7.Visible = False
                            Link7.Visible = True
                        Case "8"
                            Dim test As String = TextBox8.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link8.Text = "Click to Edit"
                                Link8.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox8.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link8.Text = str
                                Link8.ForeColor = Drawing.Color.Black
                            End If
                            TextBox8.Visible = False
                            Button8.Visible = False
                            Link8.Visible = True
                    End Select
                End If
                If CheckIfTextBoxIsOpen(DontCare) Then
                End If
            ElseIf PanelBoardAfternoon.Visible = True Then
                Dim ID As String = Sender.ID.ToString()
                Dim Num As String = Nothing
                If ID.Contains("1") Then
                    Num = "1"
                ElseIf ID.Contains("2") Then
                    Num = "2"
                ElseIf ID.Contains("3") Then
                    Num = "3"
                ElseIf ID.Contains("4") Then
                    Num = "4"
                ElseIf ID.Contains("5") Then
                    Num = "5"
                ElseIf ID.Contains("6") Then
                    Num = "6"
                ElseIf ID.Contains("7") Then
                    Num = "7"
                ElseIf ID.Contains("8") Then
                    Num = "8"
                End If
                If ID.Contains("TextBoxRoom") Or ID.Contains("ButtonRoom") Then
                    Select Case Num
                        Case "1"
                            If TextBoxRoom1a.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom1a.Text = TextBoxRoom1a.Text.Trim()
                            End If
                            LinkButtonRoom1a.Visible = True
                            TextBoxRoom1a.Visible = False
                            ButtonRoom1a.Visible = False
                            LinkButtonDone1a.Visible = True
                        Case "2"
                            If TextBoxRoom2a.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom2a.Text = TextBoxRoom2a.Text.Trim()
                            End If
                            LinkButtonRoom2a.Visible = True
                            TextBoxRoom2a.Visible = False
                            ButtonRoom2a.Visible = False
                            LinkButtonDone2a.Visible = True
                        Case "3"
                            If TextBoxRoom3a.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom3a.Text = TextBoxRoom3a.Text.Trim()
                            End If
                            LinkButtonRoom3a.Visible = True
                            TextBoxRoom3a.Visible = False
                            ButtonRoom3a.Visible = False
                            LinkButtonDone3a.Visible = True
                        Case "4"
                            If TextBoxRoom4a.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom4a.Text = TextBoxRoom4a.Text.Trim()
                            End If
                            LinkButtonRoom4a.Visible = True
                            TextBoxRoom4a.Visible = False
                            ButtonRoom4a.Visible = False
                            LinkButtonDone4a.Visible = True
                        Case "5"
                            If TextBoxRoom5a.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom5a.Text = TextBoxRoom5a.Text.Trim()
                            End If
                            LinkButtonRoom5a.Visible = True
                            TextBoxRoom5a.Visible = False
                            ButtonRoom5a.Visible = False
                            LinkButtonDone5a.Visible = True
                        Case "6"
                            If TextBoxRoom6a.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom6a.Text = TextBoxRoom6a.Text.Trim()
                            End If
                            LinkButtonRoom6a.Visible = True
                            TextBoxRoom6a.Visible = False
                            ButtonRoom6a.Visible = False
                            LinkButtonDone6a.Visible = True
                        Case "7"
                            If TextBoxRoom7a.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom7a.Text = TextBoxRoom7a.Text.Trim()
                            End If
                            LinkButtonRoom7a.Visible = True
                            TextBoxRoom7a.Visible = False
                            ButtonRoom7a.Visible = False
                            LinkButtonDone7a.Visible = True
                        Case "8"
                            If TextBoxRoom8a.Text.Trim() = Nothing Then
                            Else
                                LinkButtonRoom8a.Text = TextBoxRoom8a.Text.Trim()
                            End If
                            LinkButtonRoom8a.Visible = True
                            TextBoxRoom8a.Visible = False
                            ButtonRoom8a.Visible = False
                            LinkButtonDone8a.Visible = True
                    End Select
                    RoomChanged += 1
                ElseIf ID.Contains("TextBoxPat") Or ID.Contains("ButtonPat") Then
                    Select Case Num
                        Case "1"
                            Dim test As String = TextBoxPat1a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat1a.Text = "Click to Edit"
                                LinkPat1a.ToolTip = "Click to Edit"
                                LinkPat1a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat1a.Text.Replace(vbLf, " ")
                                LinkPat1a.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat1a.Text = str
                                LinkPat1a.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat1a.Visible = False
                            ButtonPat1a.Visible = False
                            LinkPat1a.Visible = True
                        Case "2"
                            Dim test As String = TextBoxPat2a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat2a.Text = "Click to Edit"
                                LinkPat2a.ToolTip = "Click to Edit"
                                LinkPat2a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat2a.Text.Replace(vbLf, " ")
                                LinkPat2a.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat2a.Text = str
                                LinkPat2a.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat2a.Visible = False
                            ButtonPat2a.Visible = False
                            LinkPat2a.Visible = True
                        Case "3"
                            Dim test As String = TextBoxPat3a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat3a.Text = "Click to Edit"
                                LinkPat3a.ToolTip = "Click to Edit"
                                LinkPat3a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat3a.Text.Replace(vbLf, " ")
                                LinkPat3a.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat3a.Text = str
                                LinkPat3a.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat3a.Visible = False
                            ButtonPat3a.Visible = False
                            LinkPat3a.Visible = True
                        Case "4"
                            Dim test As String = TextBoxPat4a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat4a.Text = "Click to Edit"
                                LinkPat4a.ToolTip = "Click to Edit"
                                LinkPat4a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat4a.Text.Replace(vbLf, " ")
                                LinkPat4a.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat4a.Text = str
                                LinkPat4a.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat4a.Visible = False
                            ButtonPat4a.Visible = False
                            LinkPat4a.Visible = True
                        Case "5"
                            Dim test As String = TextBoxPat5a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat5a.Text = "Click to Edit"
                                LinkPat5a.ToolTip = "Click to Edit"
                                LinkPat5a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat5a.Text.Replace(vbLf, " ")
                                LinkPat5a.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat5a.Text = str
                                LinkPat5a.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat5a.Visible = False
                            ButtonPat5a.Visible = False
                            LinkPat5a.Visible = True
                        Case "6"
                            Dim test As String = TextBoxPat6a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat6a.Text = "Click to Edit"
                                LinkPat6a.ToolTip = "Click to Edit"
                                LinkPat6a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat6a.Text.Replace(vbLf, " ")
                                LinkPat6a.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat6a.Text = str
                                LinkPat6a.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat6a.Visible = False
                            ButtonPat6a.Visible = False
                            LinkPat6a.Visible = True
                        Case "7"
                            Dim test As String = TextBoxPat7a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat7a.Text = "Click to Edit"
                                LinkPat7a.ToolTip = "Click to Edit"
                                LinkPat7a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat7a.Text.Replace(vbLf, " ")
                                LinkPat7a.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat7a.Text = str
                                LinkPat7a.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat7a.Visible = False
                            ButtonPat7a.Visible = False
                            LinkPat7a.Visible = True
                        Case "8"
                            Dim test As String = TextBoxPat8a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkPat8a.Text = "Click to Edit"
                                LinkPat8a.ToolTip = "Click to Edit"
                                LinkPat8a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBoxPat8a.Text.Replace(vbLf, " ")
                                LinkPat8a.ToolTip = str
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For i = 0 To str.Length - 1
                                '    If str.Chars(i) = " " Then
                                '        If str.Chars(i + 1) <> " " And (i + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(i + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                LinkPat8a.Text = str
                                LinkPat8a.ForeColor = Drawing.Color.Black
                            End If
                            TextBoxPat8a.Visible = False
                            ButtonPat8a.Visible = False
                            LinkPat8a.Visible = True
                    End Select
                    NameChanged += 1
                ElseIf ID.Contains("Header") Then
                    Select Case Num
                        Case "1"
                            Dim test As String = TextBoxHeader1a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader1a.Text = "PA"
                            Else
                                Dim str As String = TextBoxHeader1a.Text
                                LinkButtonHeader1a.Text = str
                            End If
                            TextBoxHeader1a.Visible = False
                            ButtonHeader1a.Visible = False
                            LinkButtonHeader1a.Visible = True
                        Case "2"
                            Dim test As String = TextBoxHeader2a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader2a.Text = "Surgeon"
                            Else
                                Dim str As String = TextBoxHeader2a.Text
                                LinkButtonHeader2a.Text = str
                            End If
                            TextBoxHeader2a.Visible = False
                            ButtonHeader2a.Visible = False
                            LinkButtonHeader2a.Visible = True
                        Case "3"
                            Dim test As String = TextBoxHeader3a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader3a.Text = "IR"
                            Else
                                Dim str As String = TextBoxHeader3a.Text
                                LinkButtonHeader3a.Text = str
                            End If
                            TextBoxHeader3a.Visible = False
                            ButtonHeader3a.Visible = False
                            LinkButtonHeader3a.Visible = True
                        Case "4"
                            Dim test As String = TextBoxHeader4a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader4a.Text = "Dietitian"
                            Else
                                Dim str As String = TextBoxHeader4a.Text
                                LinkButtonHeader4a.Text = str
                            End If
                            TextBoxHeader4a.Visible = False
                            ButtonHeader4a.Visible = False
                            LinkButtonHeader4a.Visible = True
                        Case "5"
                            Dim test As String = TextBoxHeader5a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader5a.Text = "Social Work"
                            Else
                                Dim str As String = TextBoxHeader5a.Text
                                LinkButtonHeader5a.Text = str
                            End If
                            TextBoxHeader5a.Visible = False
                            ButtonHeader5a.Visible = False
                            LinkButtonHeader5a.Visible = True
                        Case "6"
                            Dim test As String = TextBoxHeader6a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader6a.Text = "Med/Onc"
                            Else
                                Dim str As String = TextBoxHeader6a.Text
                                LinkButtonHeader6a.Text = str
                            End If
                            TextBoxHeader6a.Visible = False
                            ButtonHeader6a.Visible = False
                            LinkButtonHeader6a.Visible = True
                        Case "7"
                            Dim test As String = TextBoxHeader7a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                LinkButtonHeader7a.Text = "Notes"
                            Else
                                Dim str As String = TextBoxHeader7a.Text
                                LinkButtonHeader7a.Text = str
                            End If
                            TextBoxHeader7a.Visible = False
                            ButtonHeader7a.Visible = False
                            LinkButtonHeader7a.Visible = True
                    End Select
                Else
                    Select Case Num
                        Case "1"
                            Dim test As String = TextBox1a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link1a.Text = "Click to Edit"
                                Link1a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox1a.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link1a.Text = str
                                Link1a.ForeColor = Drawing.Color.Black
                            End If
                            TextBox1a.Visible = False
                            Button1a.Visible = False
                            Link1a.Visible = True
                        Case "2"
                            Dim test As String = TextBox2a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link2a.Text = "Click to Edit"
                                Link2a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox2a.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link2a.Text = str
                                Link2a.ForeColor = Drawing.Color.Black
                            End If
                            TextBox2a.Visible = False
                            Button2a.Visible = False
                            Link2a.Visible = True
                        Case "3"
                            Dim test As String = TextBox3a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link3a.Text = "Click to Edit"
                                Link3a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox3a.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link3a.Text = str
                                Link3a.ForeColor = Drawing.Color.Black
                            End If
                            TextBox3a.Visible = False
                            Button3a.Visible = False
                            Link3a.Visible = True
                        Case "4"
                            Dim test As String = TextBox4a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link4a.Text = "Click to Edit"
                                Link4a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox4a.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link4a.Text = str
                                Link4a.ForeColor = Drawing.Color.Black
                            End If
                            TextBox4a.Visible = False
                            Button4a.Visible = False
                            Link4a.Visible = True
                        Case "5"
                            Dim test As String = TextBox5a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link5a.Text = "Click to Edit"
                                Link5a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox5a.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link5a.Text = str
                                Link5a.ForeColor = Drawing.Color.Black
                            End If
                            TextBox5a.Visible = False
                            Button5a.Visible = False
                            Link5a.Visible = True
                        Case "6"
                            Dim test As String = TextBox6a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link6a.Text = "Click to Edit"
                                Link6a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox6a.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link6a.Text = str
                                Link6a.ForeColor = Drawing.Color.Black
                            End If
                            TextBox6a.Visible = False
                            Button6a.Visible = False
                            Link6a.Visible = True
                        Case "7"
                            Dim test As String = TextBox7a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link7a.Text = "Click to Edit"
                                Link7a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox7a.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link7a.Text = str
                                Link7a.ForeColor = Drawing.Color.Black
                            End If
                            TextBox7a.Visible = False
                            Button7a.Visible = False
                            Link7a.Visible = True
                        Case "8"
                            Dim test As String = TextBox8a.Text.Replace(" ", "").Trim()
                            If test = Nothing Then
                                Link8a.Text = "Click to Edit"
                                Link8a.ForeColor = Drawing.Color.LightGray
                            Else
                                Dim str As String = TextBox8a.Text.Replace(vbLf, "<br/>&hairsp;&hairsp;&hairsp;&hairsp;")
                                Link8a.Text = str
                                Link8a.ForeColor = Drawing.Color.Black
                            End If
                            TextBox8a.Visible = False
                            Button8a.Visible = False
                            Link8a.Visible = True
                    End Select
                End If
                If CheckIfTextBoxIsOpen(DontCare) Then
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Link and Label to TextBox Notes
    Protected Sub Notes_Command(sender As Object, e As CommandEventArgs)
        Try
            ReadCheckRead()
            If PanelBoardMorning.Visible = True Then
                If Ready = True Or (Ready = False And ReadyUser = MyUser) Then
                    Timer1.Enabled = False
                    Dim ID As String = sender.ID.ToString()
                    'RoomName
                    If ID.Contains("LinkButtonRoom") Then
                        If sender.text.Contains("Done") Then
                        Else
                            If ID.Contains("1") Then
                                TextBoxRoom1.Text = LinkButtonRoom1.Text
                                TextBoxRoom1.Visible = True
                                ButtonRoom1.Visible = True
                                LinkButtonRoom1.Visible = False
                                LinkButtonDone1.Visible = False
                            End If
                            If ID.Contains("2") Then
                                TextBoxRoom2.Text = LinkButtonRoom2.Text
                                TextBoxRoom2.Visible = True
                                ButtonRoom2.Visible = True
                                LinkButtonRoom2.Visible = False
                                LinkButtonDone2.Visible = False
                            End If
                            If ID.Contains("3") Then
                                TextBoxRoom3.Text = LinkButtonRoom3.Text
                                TextBoxRoom3.Visible = True
                                ButtonRoom3.Visible = True
                                LinkButtonRoom3.Visible = False
                                LinkButtonDone3.Visible = False
                            End If
                            If ID.Contains("4") Then
                                TextBoxRoom4.Text = LinkButtonRoom4.Text
                                TextBoxRoom4.Visible = True
                                ButtonRoom4.Visible = True
                                LinkButtonRoom4.Visible = False
                                LinkButtonDone4.Visible = False
                            End If
                            If ID.Contains("5") Then
                                TextBoxRoom5.Text = LinkButtonRoom5.Text
                                TextBoxRoom5.Visible = True
                                ButtonRoom5.Visible = True
                                LinkButtonRoom5.Visible = False
                                LinkButtonDone5.Visible = False
                            End If
                            If ID.Contains("6") Then
                                TextBoxRoom6.Text = LinkButtonRoom6.Text
                                TextBoxRoom6.Visible = True
                                ButtonRoom6.Visible = True
                                LinkButtonRoom6.Visible = False
                                LinkButtonDone6.Visible = False
                            End If
                            If ID.Contains("7") Then
                                TextBoxRoom7.Text = LinkButtonRoom7.Text
                                TextBoxRoom7.Visible = True
                                ButtonRoom7.Visible = True
                                LinkButtonRoom7.Visible = False
                                LinkButtonDone7.Visible = False
                            End If
                            If ID.Contains("8") Then
                                TextBoxRoom8.Text = LinkButtonRoom8.Text
                                TextBoxRoom8.Visible = True
                                ButtonRoom8.Visible = True
                                LinkButtonRoom8.Visible = False
                                LinkButtonDone8.Visible = False
                            End If
                        End If

                        'PatientName
                    ElseIf ID.Contains("LinkPat") Then
                        If ID.Contains("1") Then
                            If LinkPat1.Text = "Click to Edit" Then
                                TextBoxPat1.Text = Nothing
                            Else
                                Dim str As String = LinkPat1.ToolTip
                                TextBoxPat1.Text = str
                            End If
                            TextBoxPat1.Visible = True
                            ButtonPat1.Visible = True
                            LinkPat1.Visible = False
                        End If

                        If ID.Contains("2") Then
                            If LinkPat2.Text = "Click to Edit" Then
                                TextBoxPat2.Text = Nothing
                            Else
                                Dim str As String = LinkPat2.ToolTip
                                TextBoxPat2.Text = str
                            End If
                            TextBoxPat2.Visible = True
                            ButtonPat2.Visible = True
                            LinkPat2.Visible = False
                        End If

                        If ID.Contains("3") Then
                            If LinkPat3.Text = "Click to Edit" Then
                                TextBoxPat3.Text = Nothing
                            Else
                                Dim str As String = LinkPat3.ToolTip
                                TextBoxPat3.Text = str
                            End If
                            TextBoxPat3.Visible = True
                            ButtonPat3.Visible = True
                            LinkPat3.Visible = False
                        End If

                        If ID.Contains("4") Then
                            If LinkPat4.Text = "Click to Edit" Then
                                TextBoxPat4.Text = Nothing
                            Else
                                Dim str As String = LinkPat4.ToolTip
                                TextBoxPat4.Text = str
                            End If
                            TextBoxPat4.Visible = True
                            ButtonPat4.Visible = True
                            LinkPat4.Visible = False
                        End If

                        If ID.Contains("5") Then
                            If LinkPat5.Text = "Click to Edit" Then
                                TextBoxPat5.Text = Nothing
                            Else
                                Dim str As String = LinkPat5.ToolTip
                                TextBoxPat5.Text = str
                            End If
                            TextBoxPat5.Visible = True
                            ButtonPat5.Visible = True
                            LinkPat5.Visible = False
                        End If

                        If ID.Contains("6") Then
                            If LinkPat6.Text = "Click to Edit" Then
                                TextBoxPat6.Text = Nothing
                            Else
                                Dim str As String = LinkPat6.ToolTip
                                TextBoxPat6.Text = str
                            End If
                            TextBoxPat6.Visible = True
                            ButtonPat6.Visible = True
                            LinkPat6.Visible = False
                        End If

                        If ID.Contains("7") Then
                            If LinkPat7.Text = "Click to Edit" Then
                                TextBoxPat7.Text = Nothing
                            Else
                                Dim str As String = LinkPat7.ToolTip
                                TextBoxPat7.Text = str
                            End If
                            TextBoxPat7.Visible = True
                            ButtonPat7.Visible = True
                            LinkPat7.Visible = False
                        End If

                        If ID.Contains("8") Then
                            If LinkPat8.Text = "Click to Edit" Then
                                TextBoxPat8.Text = Nothing
                            Else
                                Dim str As String = LinkPat8.ToolTip
                                TextBoxPat8.Text = str
                            End If
                            TextBoxPat8.Visible = True
                            ButtonPat8.Visible = True
                            LinkPat8.Visible = False
                        End If

                        'Headers
                    ElseIf ID.Contains("Header") Then
                        If ID.Contains("1") Then
                            Dim str As String = LinkButtonHeader1.Text
                            TextBoxHeader1.Text = str
                            TextBoxHeader1.Visible = True
                            ButtonHeader1.Visible = True
                            LinkButtonHeader1.Visible = False
                        End If
                        If ID.Contains("2") Then
                            Dim str As String = LinkButtonHeader2.Text
                            TextBoxHeader2.Text = str
                            TextBoxHeader2.Visible = True
                            ButtonHeader2.Visible = True
                            LinkButtonHeader2.Visible = False
                        End If
                        If ID.Contains("3") Then
                            Dim str As String = LinkButtonHeader3.Text
                            TextBoxHeader3.Text = str
                            TextBoxHeader3.Visible = True
                            ButtonHeader3.Visible = True
                            LinkButtonHeader3.Visible = False
                        End If
                        If ID.Contains("4") Then
                            Dim str As String = LinkButtonHeader4.Text
                            TextBoxHeader4.Text = str
                            TextBoxHeader4.Visible = True
                            ButtonHeader4.Visible = True
                            LinkButtonHeader4.Visible = False
                        End If
                        If ID.Contains("5") Then
                            Dim str As String = LinkButtonHeader5.Text
                            TextBoxHeader5.Text = str
                            TextBoxHeader5.Visible = True
                            ButtonHeader5.Visible = True
                            LinkButtonHeader5.Visible = False
                        End If
                        If ID.Contains("6") Then
                            Dim str As String = LinkButtonHeader6.Text
                            TextBoxHeader6.Text = str
                            TextBoxHeader6.Visible = True
                            ButtonHeader6.Visible = True
                            LinkButtonHeader6.Visible = False
                        End If
                        If ID.Contains("7") Then
                            Dim str As String = LinkButtonHeader7.Text
                            TextBoxHeader7.Text = str
                            TextBoxHeader7.Visible = True
                            ButtonHeader7.Visible = True
                            LinkButtonHeader7.Visible = False
                        End If
                        If ID.Contains("8") Then
                            Dim str As String = LinkButtonHeader8.Text
                            TextBoxHeader8.Text = str
                            TextBoxHeader8.Visible = True
                            ButtonHeader8.Visible = True
                            LinkButtonHeader8.Visible = False
                        End If
                    Else    'Notes
                        If ID.Contains("1") Then
                            If Link1.Text = "Click to Edit" Then
                                TextBox1.Text = Nothing
                            Else
                                Dim str As String = Link1.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox1.Text = str
                            End If
                            TextBox1.Visible = True
                            Button1.Visible = True
                            Link1.Visible = False
                        End If

                        If ID.Contains("2") Then
                            If Link2.Text = "Click to Edit" Then
                                TextBox2.Text = Nothing
                            Else
                                Dim str As String = Link2.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox2.Text = str
                            End If
                            TextBox2.Visible = True
                            Button2.Visible = True
                            Link2.Visible = False
                        End If

                        If ID.Contains("3") Then
                            If Link3.Text = "Click to Edit" Then
                                TextBox3.Text = Nothing
                            Else
                                Dim str As String = Link3.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox3.Text = str
                            End If
                            TextBox3.Visible = True
                            Button3.Visible = True
                            Link3.Visible = False
                        End If

                        If ID.Contains("4") Then
                            If Link4.Text = "Click to Edit" Then
                                TextBox4.Text = Nothing
                            Else
                                Dim str As String = Link4.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox4.Text = str
                            End If
                            TextBox4.Visible = True
                            Button4.Visible = True
                            Link4.Visible = False
                        End If

                        If ID.Contains("5") Then
                            If Link5.Text = "Click to Edit" Then
                                TextBox5.Text = Nothing
                            Else
                                Dim str As String = Link5.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox5.Text = str
                            End If
                            TextBox5.Visible = True
                            Button5.Visible = True
                            Link5.Visible = False
                        End If

                        If ID.Contains("6") Then
                            If Link6.Text = "Click to Edit" Then
                                TextBox6.Text = Nothing
                            Else
                                Dim str As String = Link6.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox6.Text = str
                            End If
                            TextBox6.Visible = True
                            Button6.Visible = True
                            Link6.Visible = False
                        End If

                        If ID.Contains("7") Then
                            If Link7.Text = "Click to Edit" Then
                                TextBox7.Text = Nothing
                            Else
                                Dim str As String = Link7.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox7.Text = str
                            End If
                            TextBox7.Visible = True
                            Button7.Visible = True
                            Link7.Visible = False
                        End If

                        If ID.Contains("8") Then
                            If Link8.Text = "Click to Edit" Then
                                TextBox8.Text = Nothing
                            Else
                                Dim str As String = Link8.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox8.Text = str
                            End If
                            TextBox8.Visible = True
                            Button8.Visible = True
                            Link8.Visible = False
                        End If
                    End If

                    Ready = False
                    If WriteSQLData(DontCare) Then
                    End If
                End If
            ElseIf PanelBoardAfternoon.Visible = True Then
                If Ready2 = True Or (Ready2 = False And ReadyUser2 = MyUser) Then
                    Timer1.Enabled = False
                    Dim ID As String = sender.ID.ToString()
                    'Room Name
                    If ID.Contains("LinkButtonRoom") Then
                        If sender.text.Contains("Done") Then
                        Else
                            If ID.Contains("1") Then
                                TextBoxRoom1a.Text = LinkButtonRoom1a.Text
                                TextBoxRoom1a.Visible = True
                                ButtonRoom1a.Visible = True
                                LinkButtonRoom1a.Visible = False
                                LinkButtonDone1a.Visible = False
                            End If
                            If ID.Contains("2") Then
                                TextBoxRoom2a.Text = LinkButtonRoom2a.Text
                                TextBoxRoom2a.Visible = True
                                ButtonRoom2a.Visible = True
                                LinkButtonRoom2a.Visible = False
                                LinkButtonDone2a.Visible = False
                            End If
                            If ID.Contains("3") Then
                                TextBoxRoom3a.Text = LinkButtonRoom3a.Text
                                TextBoxRoom3a.Visible = True
                                ButtonRoom3a.Visible = True
                                LinkButtonRoom3a.Visible = False
                                LinkButtonDone3a.Visible = False
                            End If
                            If ID.Contains("4") Then
                                TextBoxRoom4a.Text = LinkButtonRoom4a.Text
                                TextBoxRoom4a.Visible = True
                                ButtonRoom4a.Visible = True
                                LinkButtonRoom4a.Visible = False
                                LinkButtonDone4a.Visible = False
                            End If
                            If ID.Contains("5") Then
                                TextBoxRoom5a.Text = LinkButtonRoom5a.Text
                                TextBoxRoom5a.Visible = True
                                ButtonRoom5a.Visible = True
                                LinkButtonRoom5a.Visible = False
                                LinkButtonDone5a.Visible = False
                            End If
                            If ID.Contains("6") Then
                                TextBoxRoom6a.Text = LinkButtonRoom6a.Text
                                TextBoxRoom6a.Visible = True
                                ButtonRoom6a.Visible = True
                                LinkButtonRoom6a.Visible = False
                                LinkButtonDone6a.Visible = False
                            End If
                            If ID.Contains("7") Then
                                TextBoxRoom7a.Text = LinkButtonRoom7a.Text
                                TextBoxRoom7a.Visible = True
                                ButtonRoom7a.Visible = True
                                LinkButtonRoom7a.Visible = False
                                LinkButtonDone7a.Visible = False
                            End If
                            If ID.Contains("8") Then
                                TextBoxRoom8a.Text = LinkButtonRoom8a.Text
                                TextBoxRoom8a.Visible = True
                                ButtonRoom8a.Visible = True
                                LinkButtonRoom8a.Visible = False
                                LinkButtonDone8a.Visible = False
                            End If
                        End If

                        'Patient Name
                    ElseIf ID.Contains("LinkPat") Then
                        If ID.Contains("1") Then
                            If LinkPat1a.Text = "Click to Edit" Then
                                TextBoxPat1a.Text = Nothing
                            Else
                                Dim str As String = LinkPat1a.ToolTip
                                TextBoxPat1a.Text = str
                            End If
                            TextBoxPat1a.Visible = True
                            ButtonPat1a.Visible = True
                            LinkPat1a.Visible = False
                        End If

                        If ID.Contains("2") Then
                            If LinkPat2a.Text = "Click to Edit" Then
                                TextBoxPat2a.Text = Nothing
                            Else
                                Dim str As String = LinkPat2a.ToolTip
                                TextBoxPat2a.Text = str
                            End If
                            TextBoxPat2a.Visible = True
                            ButtonPat2a.Visible = True
                            LinkPat2a.Visible = False
                        End If

                        If ID.Contains("3") Then
                            If LinkPat3a.Text = "Click to Edit" Then
                                TextBoxPat3a.Text = Nothing
                            Else
                                Dim str As String = LinkPat3a.ToolTip
                                TextBoxPat3a.Text = str
                            End If
                            TextBoxPat3a.Visible = True
                            ButtonPat3a.Visible = True
                            LinkPat3a.Visible = False
                        End If

                        If ID.Contains("4") Then
                            If LinkPat4a.Text = "Click to Edit" Then
                                TextBoxPat4a.Text = Nothing
                            Else
                                Dim str As String = LinkPat4a.ToolTip
                                TextBoxPat4a.Text = str
                            End If
                            TextBoxPat4a.Visible = True
                            ButtonPat4a.Visible = True
                            LinkPat4a.Visible = False
                        End If

                        If ID.Contains("5") Then
                            If LinkPat5a.Text = "Click to Edit" Then
                                TextBoxPat5a.Text = Nothing
                            Else
                                Dim str As String = LinkPat5a.ToolTip
                                TextBoxPat5a.Text = str
                            End If
                            TextBoxPat5a.Visible = True
                            ButtonPat5a.Visible = True
                            LinkPat5a.Visible = False
                        End If

                        If ID.Contains("6") Then
                            If LinkPat6a.Text = "Click to Edit" Then
                                TextBoxPat6a.Text = Nothing
                            Else
                                Dim str As String = LinkPat6a.ToolTip
                                TextBoxPat6a.Text = str
                            End If
                            TextBoxPat6a.Visible = True
                            ButtonPat6a.Visible = True
                            LinkPat6a.Visible = False
                        End If

                        If ID.Contains("7") Then
                            If LinkPat7a.Text = "Click to Edit" Then
                                TextBoxPat7a.Text = Nothing
                            Else
                                Dim str As String = LinkPat7a.ToolTip
                                TextBoxPat7a.Text = str
                            End If
                            TextBoxPat7a.Visible = True
                            ButtonPat7a.Visible = True
                            LinkPat7a.Visible = False
                        End If

                        If ID.Contains("8") Then
                            If LinkPat8a.Text = "Click to Edit" Then
                                TextBoxPat8a.Text = Nothing
                            Else
                                Dim str As String = LinkPat8a.ToolTip
                                TextBoxPat8a.Text = str
                            End If
                            TextBoxPat8a.Visible = True
                            ButtonPat8a.Visible = True
                            LinkPat8a.Visible = False
                        End If

                        'Headers
                    ElseIf ID.Contains("Header") Then
                        If ID.Contains("1") Then
                            Dim str As String = LinkButtonHeader1a.Text
                            TextBoxHeader1a.Text = str
                            TextBoxHeader1a.Visible = True
                            ButtonHeader1a.Visible = True
                            LinkButtonHeader1a.Visible = False
                        End If
                        If ID.Contains("2") Then
                            Dim str As String = LinkButtonHeader2a.Text
                            TextBoxHeader2a.Text = str
                            TextBoxHeader2a.Visible = True
                            ButtonHeader2a.Visible = True
                            LinkButtonHeader2a.Visible = False
                        End If
                        If ID.Contains("3") Then
                            Dim str As String = LinkButtonHeader3a.Text
                            TextBoxHeader3a.Text = str
                            TextBoxHeader3a.Visible = True
                            ButtonHeader3a.Visible = True
                            LinkButtonHeader3a.Visible = False
                        End If
                        If ID.Contains("4") Then
                            Dim str As String = LinkButtonHeader4a.Text
                            TextBoxHeader4a.Text = str
                            TextBoxHeader4a.Visible = True
                            ButtonHeader4a.Visible = True
                            LinkButtonHeader4a.Visible = False
                        End If
                        If ID.Contains("5") Then
                            Dim str As String = LinkButtonHeader5a.Text
                            TextBoxHeader5a.Text = str
                            TextBoxHeader5a.Visible = True
                            ButtonHeader5a.Visible = True
                            LinkButtonHeader5a.Visible = False
                        End If
                        If ID.Contains("6") Then
                            Dim str As String = LinkButtonHeader6a.Text
                            TextBoxHeader6a.Text = str
                            TextBoxHeader6a.Visible = True
                            ButtonHeader6a.Visible = True
                            LinkButtonHeader6a.Visible = False
                        End If
                        If ID.Contains("7") Then
                            Dim str As String = LinkButtonHeader7a.Text
                            TextBoxHeader7a.Text = str
                            TextBoxHeader7a.Visible = True
                            ButtonHeader7a.Visible = True
                            LinkButtonHeader7a.Visible = False
                        End If
                    Else    'Notes
                        If ID.Contains("1") Then
                            If Link1a.Text = "Click to Edit" Then
                                TextBox1a.Text = Nothing
                            Else
                                Dim str As String = Link1a.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox1a.Text = str
                            End If
                            TextBox1a.Visible = True
                            Button1a.Visible = True
                            Link1a.Visible = False
                        End If

                        If ID.Contains("2") Then
                            If Link2a.Text = "Click to Edit" Then
                                TextBox2a.Text = Nothing
                            Else
                                Dim str As String = Link2a.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox2a.Text = str
                            End If
                            TextBox2a.Visible = True
                            Button2a.Visible = True
                            Link2a.Visible = False
                        End If

                        If ID.Contains("3") Then
                            If Link3a.Text = "Click to Edit" Then
                                TextBox3a.Text = Nothing
                            Else
                                Dim str As String = Link3a.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox3a.Text = str
                            End If
                            TextBox3a.Visible = True
                            Button3a.Visible = True
                            Link3a.Visible = False
                        End If

                        If ID.Contains("4") Then
                            If Link4a.Text = "Click to Edit" Then
                                TextBox4a.Text = Nothing
                            Else
                                Dim str As String = Link4a.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox4a.Text = str
                            End If
                            TextBox4a.Visible = True
                            Button4a.Visible = True
                            Link4a.Visible = False
                        End If

                        If ID.Contains("5") Then
                            If Link5a.Text = "Click to Edit" Then
                                TextBox5a.Text = Nothing
                            Else
                                Dim str As String = Link5a.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox5a.Text = str
                            End If
                            TextBox5a.Visible = True
                            Button5a.Visible = True
                            Link5a.Visible = False
                        End If

                        If ID.Contains("6") Then
                            If Link6a.Text = "Click to Edit" Then
                                TextBox6a.Text = Nothing
                            Else
                                Dim str As String = Link6a.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox6a.Text = str
                            End If
                            TextBox6a.Visible = True
                            Button6a.Visible = True
                            Link6a.Visible = False
                        End If

                        If ID.Contains("7") Then
                            If Link7a.Text = "Click to Edit" Then
                                TextBox7a.Text = Nothing
                            Else
                                Dim str As String = Link7a.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox7a.Text = str
                            End If
                            TextBox7a.Visible = True
                            Button7a.Visible = True
                            Link7a.Visible = False
                        End If

                        If ID.Contains("8") Then
                            If Link8a.Text = "Click to Edit" Then
                                TextBox8a.Text = Nothing
                            Else
                                Dim str As String = Link8a.Text.Replace("<br/>&hairsp;&hairsp;&hairsp;&hairsp;", vbLf)
                                TextBox8a.Text = str
                            End If
                            TextBox8a.Visible = True
                            Button8a.Visible = True
                            Link8a.Visible = False
                        End If

                    End If
                    Ready2 = False
                    If WriteSQLData(DontCare) Then
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'image text notes: textbox to link
    Public Sub ImgBtnTextChanged(ByVal Sender As Object, ByVal e As EventArgs)
        Try
            If PanelBoardMorning.Visible = True Then
                Dim num As String = Nothing
                If Ready = True Or (Ready = False And ReadyUser = MyUser) Then
                    For i = 0 To Sender.ID.ToString.Length - 1
                        If Char.IsNumber(Sender.Id.ToString(i)) Then
                            num += Sender.ID.ToString.Chars(i)
                        End If
                    Next
                    Timer1.Enabled = True
                    Dim tempObj1 As New Object
                    Dim tempObj2 As New Object
                    LinkDict.TryGetValue("LinkButtonM" & num, tempObj1)
                    TextDict.TryGetValue("TextBoxM" & num, tempObj2)
                    Dim text As String = tempObj2.Text.Trim()
                    If text = "" Then
                        text = "Add Note"
                    End If
                    tempObj1.Text = text
                    If tempObj1.Text = "Add Note" Then
                        tempObj1.ForeColor = Drawing.Color.LightGray
                    Else
                        tempObj1.ForeColor = Drawing.Color.DodgerBlue
                    End If
                    tempObj1.Visible = True
                    tempObj2.Visible = False
                    ButtonDict.TryGetValue("ButtonM" & num, tempObj1)
                    tempObj1.Visible = False
                End If
                If CheckIfTextBoxIsOpen(DontCare) Then
                End If
            ElseIf PanelBoardAfternoon.Visible = True Then
                If Ready2 = True Or (Ready2 = False And ReadyUser2 = MyUser) Then
                    Dim num As String = Nothing
                    If Ready2 = True Or (Ready2 = False And ReadyUser2 = MyUser) Then
                        For i = 0 To Sender.ID.ToString.Length - 1
                            If Char.IsNumber(Sender.Id.ToString(i)) Then
                                num += Sender.ID.ToString.Chars(i)
                            End If
                        Next
                        Timer1.Enabled = True
                        Dim tempObj1 As New Object
                        Dim tempObj2 As New Object
                        LinkDict.TryGetValue("LinkButtonA" & num, tempObj1)
                        TextDict.TryGetValue("TextBoxA" & num, tempObj2)
                        Dim text As String = tempObj2.Text.Trim()
                        If text = "" Then
                            text = "Add Note"
                        End If
                        tempObj1.Text = text
                        If tempObj1.Text = "Add Note" Then
                            tempObj1.ForeColor = Drawing.Color.LightGray
                        Else
                            tempObj1.ForeColor = Drawing.Color.DodgerBlue
                        End If
                        tempObj1.Visible = True
                        tempObj2.Visible = False
                        ButtonDict.TryGetValue("ButtonA" & num, tempObj1)
                        tempObj1.Visible = False
                    End If
                    If CheckIfTextBoxIsOpen(DontCare) Then
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'image text notes: link to textbox
    Protected Sub ImgBtnText_Command(sender As Object, e As CommandEventArgs)
        Try
            ReadCheckRead()
            If PanelBoardMorning.Visible = True Then
                Dim num As String = Nothing
                If Ready = True Or (Ready = False And ReadyUser = MyUser) Then
                    For i = 0 To sender.ID.ToString.Length - 1
                        If Char.IsNumber(sender.Id.ToString(i)) Then
                            num += sender.ID.ToString.Chars(i)
                        End If
                    Next
                    Timer1.Enabled = False
                    Dim tempObj1 As New Object
                    Dim tempObj2 As New Object
                    LinkDict.TryGetValue("LinkButtonM" & num, tempObj1)
                    TextDict.TryGetValue("TextBoxM" & num, tempObj2)
                    Dim text As String = tempObj1.Text
                    If text = "Add Note" Then
                        text = ""
                    End If
                    tempObj2.Text = text
                    tempObj1.Visible = False
                    tempObj2.Visible = True
                    ButtonDict.TryGetValue("ButtonM" & num, tempObj1)
                    tempObj1.Visible = True
                    Ready = False
                    If WriteSQLData(DontCare) Then
                    End If
                End If
            ElseIf PanelBoardAfternoon.Visible = True Then
                If Ready2 = True Or (Ready2 = False And ReadyUser2 = MyUser) Then
                    Dim num As String = Nothing
                    If Ready2 = True Or (Ready2 = False And ReadyUser2 = MyUser) Then
                        For i = 0 To sender.ID.ToString.Length - 1
                            If Char.IsNumber(sender.Id.ToString(i)) Then
                                num += sender.ID.ToString.Chars(i)
                            End If
                        Next
                        Timer1.Enabled = False
                        Dim tempObj1 As New Object
                        Dim tempObj2 As New Object
                        LinkDict.TryGetValue("LinkButtonA" & num, tempObj1)
                        TextDict.TryGetValue("TextBoxA" & num, tempObj2)
                        Dim text As String = tempObj1.Text
                        If text = "Add Note" Then
                            text = ""
                        End If
                        tempObj2.Text = text
                        tempObj1.Visible = False
                        tempObj2.Visible = True
                        ButtonDict.TryGetValue("ButtonA" & num, tempObj1)
                        tempObj1.Visible = True
                        Ready2 = False
                        If WriteSQLData(DontCare) Then
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Hide and Show Rooms by Click
    Protected Sub Room_Command(sender As Object, e As CommandEventArgs)
        Try
            ReadCheckRead()
            If PanelBoardMorning.Visible = True Then
                If Ready = True Or (Ready = False And ReadyUser = MyUser) Then
                    Timer1.Enabled = True
                    Dim ID As String = sender.ID.ToString()
                    Dim tempObj As New Object
                    'RoomNumber
                    Dim num As String = Nothing
                    If ID.Contains("1") Then
                        num = "1"
                    ElseIf ID.Contains("2") Then
                        num = "2"
                    ElseIf ID.Contains("3") Then
                        num = "3"
                    ElseIf ID.Contains("4") Then
                        num = "4"
                    ElseIf ID.Contains("5") Then
                        num = "5"
                    ElseIf ID.Contains("6") Then
                        num = "6"
                    ElseIf ID.Contains("7") Then
                        num = "7"
                    ElseIf ID.Contains("8") Then
                        num = "8"
                    End If
                    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num, tempObj)
                    '////////////////////////////////////////////////////////////////////////
                    'Remove this when move back to rooms 1, 2 3, 4, 5, 6/////////////////////
                    Dim RD = From p In TPDC.tblClinics
                             Where p.ClinicDate = MyToDay
                             Select p.ClinicDate, p.RoomNames

                    Dim temp As String = RD.FirstOrDefault.RoomNames
                    Dim tempArr(8) As String
                    Dim n As Integer = 1
                    For i = 0 To temp.Length - 1
                        If temp.Chars(i) <> "^" Then
                            tempArr(n) += temp.Chars(i)
                        ElseIf temp.Chars(i) = "^" Then
                            n += 1
                        End If
                    Next
                    If tempObj.Text.Contains("Done") Then
                        Select Case num
                            Case "1"
                                tempObj.Text = tempArr(1).Replace("<br/>Done", "")
                                LinkButtonDone1.Text = "Close"
                            Case "2"
                                tempObj.Text = tempArr(2).Replace("<br/>Done", "")
                                LinkButtonDone2.Text = "Close"
                            Case "3"
                                tempObj.Text = tempArr(3).Replace("<br/>Done", "")
                                LinkButtonDone3.Text = "Close"
                            Case "4"
                                tempObj.Text = tempArr(4).Replace("<br/>Done", "")
                                LinkButtonDone4.Text = "Close"
                            Case "5"
                                tempObj.Text = tempArr(5).Replace("<br/>Done", "")
                                LinkButtonDone5.Text = "Close"
                            Case "6"
                                tempObj.Text = tempArr(6).Replace("<br/>Done", "")
                                LinkButtonDone6.Text = "Close"
                            Case "7"
                                tempObj.Text = tempArr(7).Replace("<br/>Done", "")
                                LinkButtonDone7.Text = "Close"
                            Case "8"
                                tempObj.Text = tempArr(8).Replace("<br/>Done", "")
                                LinkButtonDone8.Text = "Close"
                        End Select
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num, tempObj)
                        tempObj.ForeColor = Drawing.Color.Black
                        LinkDict.TryGetValue("LinkPat" & num, tempObj)
                        tempObj.Visible = True
                        For k = 1 To 7
                            ImageDict.TryGetValue("Imagebutton" & num & k, tempObj)
                            tempObj.Visible = True
                            LinkDict.TryGetValue("LinkButtonM" & num & k, tempObj)
                            tempObj.Visible = True
                        Next
                        LinkDict.TryGetValue("Link" & num, tempObj)
                        tempObj.Visible = True
                    Else
                        Select Case num
                            Case "1"
                                tempObj.Text = tempArr(1) & "<br/>Done"
                                LinkButtonDone1.Text = "Open"
                            Case "2"
                                tempObj.Text = tempArr(2) & "<br/>Done"
                                LinkButtonDone2.Text = "Open"
                            Case "3"
                                tempObj.Text = tempArr(3) & "<br/>Done"
                                LinkButtonDone3.Text = "Open"
                            Case "4"
                                tempObj.Text = tempArr(4) & "<br/>Done"
                                LinkButtonDone4.Text = "Open"
                            Case "5"
                                tempObj.Text = tempArr(5) & "<br/>Done"
                                LinkButtonDone5.Text = "Open"
                            Case "6"
                                tempObj.Text = tempArr(6) & "<br/>Done"
                                LinkButtonDone6.Text = "Open"
                            Case "7"
                                tempObj.Text = tempArr(7) & "<br/>Done"
                                LinkButtonDone7.Text = "Open"
                            Case "8"
                                tempObj.Text = tempArr(8) & "<br/>Done"
                                LinkButtonDone8.Text = "Open"
                        End Select
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num, tempObj)
                        tempObj.ForeColor = Drawing.Color.Green
                        LinkDict.TryGetValue("LinkPat" & num, tempObj)
                        tempObj.Visible = True
                        For k = 1 To 7
                            ImageDict.TryGetValue("Imagebutton" & num & k, tempObj)
                            tempObj.Visible = False
                            LinkDict.TryGetValue("LinkButtonM" & num & k, tempObj)
                            tempObj.Visible = False
                        Next
                        LinkDict.TryGetValue("Link" & num, tempObj)
                        tempObj.Visible = False
                    End If
                    '////////////////////////////////////////////////////////////////////////
                    'Restore back when move back to rooms 1, 2, 3, 4, 5, 6/////////////////
                    'If tempObj.Text = num Then
                    '    tempObj.Text = num & "<br/>Done"
                    '    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num, tempObj)
                    '    tempObj.ForeColor = Drawing.Color.Green
                    '    LinkDict.TryGetValue("LinkPat" & num, tempObj)
                    '    tempObj.Visible = True
                    '    For k = 1 To 7
                    '        ImageDict.TryGetValue("Imagebutton" & num & k, tempObj)
                    '        tempObj.Visible = False
                    '        LinkDict.TryGetValue("LinkButtonM" & num & k, tempObj)
                    '        tempObj.Visible = False
                    '    Next
                    '    LinkDict.TryGetValue("Link" & num, tempObj)
                    '    tempObj.Visible = False


                    'Else
                    '    tempObj.Text = num
                    '    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num, tempObj)
                    '    tempObj.ForeColor = Drawing.Color.Black
                    '    LinkDict.TryGetValue("LinkPat" & num, tempObj)
                    '    tempObj.Visible = True
                    '    For k = 1 To 7
                    '        ImageDict.TryGetValue("Imagebutton" & num & k, tempObj)
                    '        tempObj.Visible = True
                    '        LinkDict.TryGetValue("LinkButtonM" & num & k, tempObj)
                    '        tempObj.Visible = True
                    '    Next
                    '    LinkDict.TryGetValue("Link" & num, tempObj)
                    '    tempObj.Visible = True
                    'End If
                    '////////////////////////////////////////////////////////////////////////
                    Ready = True
                    If WriteSQLData(DontCare) Then
                    End If
                End If
            ElseIf PanelBoardAfternoon.Visible = True Then
                If Ready2 = True Or (Ready2 = False And ReadyUser2 = MyUser) Then
                    Timer1.Enabled = True
                    Dim ID As String = sender.ID.ToString()
                    Dim tempObj As New Object
                    'RoomNumber
                    Dim num As String = Nothing
                    If ID.Contains("1") Then
                        num = "1"
                    ElseIf ID.Contains("2") Then
                        num = "2"
                    ElseIf ID.Contains("3") Then
                        num = "3"
                    ElseIf ID.Contains("4") Then
                        num = "4"
                    ElseIf ID.Contains("5") Then
                        num = "5"
                    ElseIf ID.Contains("6") Then
                        num = "6"
                    ElseIf ID.Contains("7") Then
                        num = "7"
                    ElseIf ID.Contains("8") Then
                        num = "8"
                    End If
                    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num & "a", tempObj)
                    Dim RD = From p In TPDC.tblClinics
                             Where p.ClinicDate = MyToDay
                             Select p.ClinicDate, p.RoomNames2

                    Dim temp As String = RD.FirstOrDefault.RoomNames2
                    Dim tempArr(8) As String
                    Dim n As Integer = 1
                    For i = 0 To temp.Length - 1
                        If temp.Chars(i) <> "^" Then
                            tempArr(n) += temp.Chars(i)
                        ElseIf temp.Chars(i) = "^" Then
                            n += 1
                        End If
                    Next
                    If tempObj.Text.Contains("Done") Then
                        Select Case num
                            Case "1"
                                tempObj.Text = tempArr(1).Replace("<br/>Done", "")
                                LinkButtonDone1a.Text = "Close"
                            Case "2"
                                tempObj.Text = tempArr(2).Replace("<br/>Done", "")
                                LinkButtonDone2a.Text = "Close"
                            Case "3"
                                tempObj.Text = tempArr(3).Replace("<br/>Done", "")
                                LinkButtonDone3a.Text = "Close"
                            Case "4"
                                tempObj.Text = tempArr(4).Replace("<br/>Done", "")
                                LinkButtonDone4a.Text = "Close"
                            Case "5"
                                tempObj.Text = tempArr(5).Replace("<br/>Done", "")
                                LinkButtonDone5a.Text = "Close"
                            Case "6"
                                tempObj.Text = tempArr(6).Replace("<br/>Done", "")
                                LinkButtonDone6a.Text = "Close"
                            Case "7"
                                tempObj.Text = tempArr(7).Replace("<br/>Done", "")
                                LinkButtonDone7a.Text = "Close"
                            Case "8"
                                tempObj.Text = tempArr(8).Replace("<br/>Done", "")
                                LinkButtonDone8a.Text = "Close"
                        End Select
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num & "a", tempObj)
                        tempObj.ForeColor = Drawing.Color.Black
                        LinkDict.TryGetValue("LinkPat" & num & "a", tempObj)
                        tempObj.Visible = True
                        For k = 1 To 6
                            ImageDict.TryGetValue("Imagebutton" & num & k & "a", tempObj)
                            tempObj.Visible = True
                            LinkDict.TryGetValue("LinkButtonA" & num & k, tempObj)
                            tempObj.Visible = True
                        Next
                        LinkDict.TryGetValue("Link" & num & "a", tempObj)
                        tempObj.Visible = True
                    Else
                        Select Case num
                            Case "1"
                                tempObj.Text = tempArr(1) & "<br/>Done"
                                LinkButtonDone1a.Text = "Open"
                            Case "2"
                                tempObj.Text = tempArr(2) & "<br/>Done"
                                LinkButtonDone2a.Text = "Open"
                            Case "3"
                                tempObj.Text = tempArr(3) & "<br/>Done"
                                LinkButtonDone3a.Text = "Open"
                            Case "4"
                                tempObj.Text = tempArr(4) & "<br/>Done"
                                LinkButtonDone4a.Text = "Open"
                            Case "5"
                                tempObj.Text = tempArr(5) & "<br/>Done"
                                LinkButtonDone5a.Text = "Open"
                            Case "6"
                                tempObj.Text = tempArr(6) & "<br/>Done"
                                LinkButtonDone6a.Text = "Open"
                            Case "7"
                                tempObj.Text = tempArr(7) & "<br/>Done"
                                LinkButtonDone7a.Text = "Open"
                            Case "8"
                                tempObj.Text = tempArr(8) & "<br/>Done"
                                LinkButtonDone8a.Text = "Open"
                        End Select
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num & "a", tempObj)
                        tempObj.ForeColor = Drawing.Color.Green
                        LinkDict.TryGetValue("LinkPat" & num & "a", tempObj)
                        tempObj.Visible = True
                        For k = 1 To 6
                            ImageDict.TryGetValue("Imagebutton" & num & k & "a", tempObj)
                            tempObj.Visible = False
                            LinkDict.TryGetValue("LinkButtonA" & num & k, tempObj)
                            tempObj.Visible = False
                        Next
                        LinkDict.TryGetValue("Link" & num & "a", tempObj)
                        tempObj.Visible = False
                    End If
                    '/////////////////////////////////////////////////////////////////////////
                    'Restore when move back to rooms 1, 2, 3, 4, 5, 6/////////////////////////
                    'If tempObj.Text = num Then
                    '    tempObj.Text = num & "<br/>Done"
                    '    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num & "a", tempObj)
                    '    tempObj.ForeColor = Drawing.Color.Green
                    '    LinkDict.TryGetValue("LinkPat" & num & "a", tempObj)
                    '    tempObj.Visible = True
                    '    For k = 1 To 6
                    '        ImageDict.TryGetValue("Imagebutton" & num & k & "a", tempObj)
                    '        tempObj.Visible = False
                    '        LinkDict.TryGetValue("LinkButtonA" & num & k, tempObj)
                    '        tempObj.Visible = False
                    '    Next
                    '    LinkDict.TryGetValue("Link" & num & "a", tempObj)
                    '    tempObj.Visible = False
                    'Else
                    '    tempObj.Text = num
                    '    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & num & "a", tempObj)
                    '    tempObj.ForeColor = Drawing.Color.Black
                    '    LinkDict.TryGetValue("LinkPat" & num & "a", tempObj)
                    '    tempObj.Visible = True
                    '    For k = 1 To 6
                    '        ImageDict.TryGetValue("Imagebutton" & num & k & "a", tempObj)
                    '        tempObj.Visible = True
                    '        LinkDict.TryGetValue("LinkButtonA" & num & k, tempObj)
                    '        tempObj.Visible = True
                    '    Next
                    '    LinkDict.TryGetValue("Link" & num & "a", tempObj)
                    '    tempObj.Visible = True
                    'End If
                    '//////////////////////////////////////////////////////////////////////////
                    Ready2 = True
                    If WriteSQLData(DontCare) Then
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Read to Hide and Show Rooms
    Protected Sub RoomDone()
        Try
            Dim tempObj As New Object
            If PanelBoardMorning.Visible = True Then
                For i = 1 To 8
                    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                    '////////////////////////////////////////////////////////////////
                    'Remove when move back to rooms 1, 2, 3, 4, 5, 6/////////////////
                    If tempObj.Text.Contains("Done") Then
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                        tempObj.ForeColor = Drawing.Color.Green
                        Select Case i
                            Case "1"
                                LinkButtonDone1.Text = "Open"
                            Case "2"
                                LinkButtonDone2.Text = "Open"
                            Case "3"
                                LinkButtonDone3.Text = "Open"
                            Case "4"
                                LinkButtonDone4.Text = "Open"
                            Case "5"
                                LinkButtonDone5.Text = "Open"
                            Case "6"
                                LinkButtonDone6.Text = "Open"
                            Case "7"
                                LinkButtonDone7.Text = "Open"
                            Case "8"
                                LinkButtonDone8.Text = "Open"
                        End Select
                        LinkDict.TryGetValue("LinkPat" & i, tempObj)
                        tempObj.Visible = True
                        For k = 1 To 7
                            ImageDict.TryGetValue("Imagebutton" & i & k, tempObj)
                            tempObj.Visible = False
                            LinkDict.TryGetValue("LinkButtonM" & i & k, tempObj)
                            tempObj.Visible = False
                        Next
                        LinkDict.TryGetValue("Link" & i, tempObj)
                        tempObj.Visible = False
                    Else
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                        tempObj.ForeColor = Drawing.Color.Black
                        LinkDict.TryGetValue("LinkPat" & i, tempObj)
                        tempObj.Visible = True
                        For k = 1 To 7
                            ImageDict.TryGetValue("Imagebutton" & i & k, tempObj)
                            tempObj.Visible = True
                            LinkDict.TryGetValue("LinkButtonM" & i & k, tempObj)
                            tempObj.Visible = True
                        Next
                        LinkDict.TryGetValue("Link" & i, tempObj)
                        tempObj.Visible = True
                    End If
                    '////////////////////////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////
                    'Restore when move back to rooms 1, 2, 3, 4, 5, 6/////////////////
                    'If tempObj.Text = i.ToString() Then
                    '    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                    '    tempObj.ForeColor = Drawing.Color.Black
                    '    LinkDict.TryGetValue("LinkPat" & i, tempObj)
                    '    tempObj.Visible = True
                    '    For k = 1 To 7
                    '        ImageDict.TryGetValue("Imagebutton" & i & k, tempObj)
                    '        tempObj.Visible = True
                    '        LinkDict.TryGetValue("LinkButtonM" & i & k, tempObj)
                    '        tempObj.Visible = True
                    '    Next
                    '    LinkDict.TryGetValue("Link" & i, tempObj)
                    '    tempObj.Visible = True
                    'ElseIf tempObj.Text = i.ToString() & "<br/>Done" Then
                    '    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                    '    tempObj.ForeColor = Drawing.Color.Green
                    '    LinkDict.TryGetValue("LinkPat" & i, tempObj)
                    '    tempObj.Visible = True
                    '    For k = 1 To 7
                    '        ImageDict.TryGetValue("Imagebutton" & i & k, tempObj)
                    '        tempObj.Visible = False
                    '        LinkDict.TryGetValue("LinkButtonM" & i & k, tempObj)
                    '        tempObj.Visible = False
                    '    Next
                    '    LinkDict.TryGetValue("Link" & i, tempObj)
                    '    tempObj.Visible = False
                    'End If
                    '//////////////////////////////////////////////////////////////////
                Next
            ElseIf PanelBoardAfternoon.Visible = True Then
                For i = 1 To 8
                    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                    '///////////////////////////////////////////////////////////////////////
                    'Remove when move back to rooms 1, 2, 3, 4, 5, 6////////////////////////
                    If tempObj.Text.Contains("Done") Then
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                        tempObj.ForeColor = Drawing.Color.Green
                        Select Case i
                            Case "1"
                                LinkButtonDone1a.Text = "Open"
                            Case "2"
                                LinkButtonDone2a.Text = "Open"
                            Case "3"
                                LinkButtonDone3a.Text = "Open"
                            Case "4"
                                LinkButtonDone4a.Text = "Open"
                            Case "5"
                                LinkButtonDone5a.Text = "Open"
                            Case "6"
                                LinkButtonDone6a.Text = "Open"
                            Case "7"
                                LinkButtonDone7a.Text = "Open"
                            Case "8"
                                LinkButtonDone8a.Text = "Open"
                        End Select
                        LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                        tempObj.Visible = True
                        For k = 1 To 6
                            ImageDict.TryGetValue("Imagebutton" & i & k & "a", tempObj)
                            tempObj.Visible = False
                            LinkDict.TryGetValue("LinkButtonA" & i & k, tempObj)
                            tempObj.Visible = False
                        Next
                        LinkDict.TryGetValue("Link" & i & "a", tempObj)
                        tempObj.Visible = False
                    Else
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                        tempObj.ForeColor = Drawing.Color.Black
                        LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                        tempObj.Visible = True
                        For k = 1 To 6
                            ImageDict.TryGetValue("Imagebutton" & i & k & "a", tempObj)
                            tempObj.Visible = True
                            LinkDict.TryGetValue("LinkButtonA" & i & k, tempObj)
                            tempObj.Visible = True
                        Next
                        LinkDict.TryGetValue("Link" & i, tempObj)
                        tempObj.Visible = True
                    End If
                    '///////////////////////////////////////////////////////////////////////
                    '///////////////////////////////////////////////////////////////////////
                    'Restore when back to rooms 1, 2, 3, 4, 5, 6'///////////////////////////
                    'If tempObj.Text = i.ToString() Then
                    '    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                    '    tempObj.ForeColor = Drawing.Color.Black
                    '    LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                    '    tempObj.Visible = True
                    '    For k = 1 To 6
                    '        ImageDict.TryGetValue("Imagebutton" & i & k & "a", tempObj)
                    '        tempObj.Visible = True
                    '        LinkDict.TryGetValue("LinkButtonA" & i & k, tempObj)
                    '        tempObj.Visible = True
                    '    Next
                    '    LinkDict.TryGetValue("Link" & i, tempObj)
                    '    tempObj.Visible = True
                    'ElseIf tempObj.Text = i.ToString() & "<br/>Done" Then
                    '    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                    '    tempObj.ForeColor = Drawing.Color.Green
                    '    LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                    '    tempObj.Visible = True
                    '    For k = 1 To 6
                    '        ImageDict.TryGetValue("Imagebutton" & i & k & "a", tempObj)
                    '        tempObj.Visible = False
                    '        LinkDict.TryGetValue("LinkButtonA" & i & k, tempObj)
                    '        tempObj.Visible = False
                    '    Next
                    '    LinkDict.TryGetValue("Link" & i & "a", tempObj)
                    '    tempObj.Visible = False
                    'End If
                    '////////////////////////////////////////////////////////////////////////
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Back to Calendar
    Protected Sub btnReturn_Click(sender As Object, e As System.EventArgs)
        'Response.Redirect(Request.RawUrl)
        Try
            Calendar1.SelectedDate = Nothing
            btnReturnM.Visible = False
            btnReturnA.Visible = False
            PanelCalendar.Visible = True
            PanelBoardMorning.Visible = False
            btnAfternoon.Visible = False
            TableBoardMorning.Visible = False
            btnMorning.Visible = False
            PanelBoardAfternoon.Visible = False
            TableBoardAfternoon.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    'Timer2Tick
    Protected Sub Timer2_Tick(sender As Object, e As System.EventArgs)
        Timer2.Enabled = False
    End Sub

    'Timer1Tick
    Protected Sub Timer1_Tick(sender As Object, e As System.EventArgs)
        ReadCheckRead()
    End Sub

    Protected Sub btnUpdateNow(sender As Object, e As System.EventArgs)
        ReadSQLData(DontCare)
    End Sub

    Function ReadSQLData(ByVal DontCare As String) As String
        Try
            If PanelBoardMorning.Visible = True Then
                If Ready = True Or (Ready = False And ReadyUser <> MyUser) Then
                    Dim flag As Boolean = False
                    Dim Read = From AA In TPDC.tblClinics
                               Select AA.Id, AA.ClinicDate, AA.RoomNames, AA.PatientNames, AA.Coordinator, AA.Hepatology, AA.MedOnc, AA.SW, AA.Dietitian, AA.Lab, AA.Imaging, AA.Notes, AA.Header, AA.ImgBtnText, AA.Done, AA.ReadyRW, AA.FontSize
                               Where ClinicDate = MyToDay

                    For Each row In Read
                        'clear array
                        For i = 0 To 13
                            For j = 0 To 12
                                Array(i, j) = Nothing
                            Next
                        Next

                        'Read the Patient Names and separate them looking for ^
                        Dim temp As String = row.PatientNames
                        If temp <> Nothing Then
                            flag = True

                            Dim x As Integer = 1
                            Dim y As Integer = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Coordinator
                            x = 2
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Hepatology
                            x = 3
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.MedOnc
                            x = 4
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.SW
                            x = 5
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Dietitian
                            x = 6
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Lab
                            x = 7
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Imaging
                            x = 8
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Notes
                            x = 9
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.ImgBtnText
                            x = 10
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "|" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "|" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Done
                            x = 11
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Header
                            x = 12
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.RoomNames
                            x = 13
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            Ready = row.ReadyRW
                            size = row.FontSize
                        End If
                    Next
                    If flag = True Then
                        'Load the Data to the Table
                        'Array: Name, Coord, IR, Surg, Trans, Notes

                        For i = 1 To 8
                            Dim tempObj As New Object
                            TextDict.TryGetValue("TextBoxPat" & i, tempObj)
                            tempObj.Text = Array(1, i)
                            LinkDict.TryGetValue("LinkPat" & i, tempObj)
                            tempObj.ToolTip = Array(1, i)
                            If Array(1, i) <> "Click to Edit" Then
                                Dim str As String = Array(1, i)
                                Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For p = 0 To str.Length - 1
                                '    If str.Chars(p) = " " And p <> str.Length - 1 Then
                                '        If str.Chars(p + 1) <> " " And (p + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(p + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                tempObj.Text = str
                            Else
                                tempObj.Text = "Click to Edit"
                            End If
                            If tempObj.Text = "Click to Edit" Then
                                tempObj.ForeColor = Drawing.Color.LightGray
                            Else
                                tempObj.ForeColor = Drawing.Color.Black
                            End If
                            TextDict.TryGetValue("TextBox" & i, tempObj)
                            tempObj.Text = Array(9, i)
                            LinkDict.TryGetValue("Link" & i, tempObj)
                            tempObj.Text = Array(9, i)
                            If tempObj.Text = "Click to Edit" Then
                                tempObj.ForeColor = Drawing.Color.LightGray
                            Else
                                tempObj.ForeColor = Drawing.Color.Black
                            End If
                            LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                            tempObj.Text = Array(11, i)
                            For k = 1 To 7
                                ImageDict.TryGetValue("Imagebutton" & i & k, tempObj)
                                tempObj.ImageUrl = Array(k + 1, i)
                            Next
                            Dim j As String = "1"
                            LinkDict.TryGetValue("LinkButtonM" & i & j, tempObj)
                            tempObj.Text = Nothing
                            For m = 0 To Array(10, i).Length - 1
                                If Array(10, i).Chars(m) <> "^" Then
                                    tempObj.Text += Array(10, i).Chars(m)
                                ElseIf Array(10, i).Chars(m) = "^" Then
                                    j += 1
                                    If tempObj.Text = "Add Note" Then
                                        tempObj.ForeColor = Drawing.Color.LightGray
                                    Else
                                        tempObj.ForeColor = Drawing.Color.DodgerBlue
                                    End If
                                    LinkDict.TryGetValue("LinkButtonM" & i & j, tempObj)
                                    tempObj.Text = Nothing
                                End If
                                If tempObj.Text = "Add Note" Then
                                    tempObj.ForeColor = Drawing.Color.LightGray
                                Else
                                    tempObj.ForeColor = Drawing.Color.DodgerBlue
                                End If
                            Next
                            j = "1"
                            TextDict.TryGetValue("TextBoxM" & i & j, tempObj)
                            tempObj.Text = Nothing
                            For m = 0 To Array(10, i).Length - 1
                                If Array(10, i).Chars(m) <> "^" Then
                                    tempObj.Text += Array(10, i).Chars(m)
                                ElseIf Array(10, i).Chars(m) = "^" Then
                                    j += 1
                                    TextDict.TryGetValue("TextBoxM" & i & j, tempObj)
                                    tempObj.Text = Nothing
                                End If
                            Next
                        Next
                        For i = 1 To 8
                            Dim tempObj As New Object
                            TextDict.TryGetValue("TextBoxHeader" & i, tempObj)
                            tempObj.Text = Array(12, i)
                            LinkDict.TryGetValue("LinkButtonHeader" & i, tempObj)
                            tempObj.Text = Array(12, i)
                        Next
                        Try
                            Dim tempObj As New Object
                            For i = 1 To 8
                                LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                                tempObj.Text = Array(13, i)
                            Next
                        Catch ex As Exception

                        End Try

                    Else
                        'initialize everything for a new board
                        For i = 1 To 8
                            Dim tempObj As New Object
                            Dim tempObj2 As New Object
                            TextDict.TryGetValue("TextBoxPat" & i, tempObj)
                            tempObj.Text = "Click to Edit"
                            LinkDict.TryGetValue("LinkPat" & i, tempObj)
                            tempObj.ForeColor = Drawing.Color.LightGray
                            tempObj.Text = "Click to Edit"
                            tempObj.ToolTip = "Click to Edit"
                            TextDict.TryGetValue("TextBox" & i, tempObj)
                            tempObj.Text = "Click to Edit"
                            LinkDict.TryGetValue("Link" & i, tempObj)
                            tempObj.Text = "Click to Edit"
                            tempObj.ForeColor = Drawing.Color.LightGray
                            LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                            '/////////////////////////////////////////////////////////
                            Try
                                Dim MyLastWeek As Date = MyToDay.AddDays(-7)
                                Dim RN = From AA In TPDC.tblClinics
                                         Select AA.Id, AA.ClinicDate, AA.RoomNames
                                         Where ClinicDate = MyLastWeek

                                Dim tempVar As String = RN.FirstOrDefault.RoomNames
                                Dim tempArr(8) As String
                                Dim n As Integer = 1
                                For k = 0 To tempVar.Length - 1
                                    If tempVar.Chars(k) <> "^" Then
                                        tempArr(n) += tempVar.Chars(k)
                                    ElseIf tempVar.Chars(k) = "^" Then
                                        n += 1
                                    End If
                                Next
                                For j = 1 To 8
                                    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & j, tempObj)
                                    tempObj.Text = tempArr(j)
                                Next
                            Catch ex2 As Exception
                                For j = 1 To 8
                                    LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & j, tempObj)
                                    tempObj.Text = "Room " & j
                                Next
                            End Try
                            '/////////////////////////////////////////////////////////
                            For k = 1 To 7
                                ImageDict.TryGetValue("Imagebutton" & i & k, tempObj)
                                If k < 6 Then
                                    tempObj.ImageUrl = "~/Images/clear.png"
                                Else
                                    tempObj.ImageUrl = "~/Images/clear75.png"
                                End If
                                LinkDict.TryGetValue("LinkButtonM" & i & k, tempObj)
                                tempObj.Text = "Add Note"
                                tempObj.ForeColor = Drawing.Color.LightGray
                                TextDict.TryGetValue("TextBoxM" & i & k, tempObj)
                                tempObj.Text = "Add Note"

                            Next
                        Next
                        Try
                            For i = 1 To 8
                                Dim tempObj As New Object
                                Dim tempObj2 As New Object
                                TextDict.TryGetValue("TextBoxHeader" & i, tempObj)
                                LinkDict.TryGetValue("LinkButtonHeader" & i, tempObj2)
                                Select Case i
                                    Case "1"
                                        tempObj.Text = "PA"
                                        tempObj2.Text = "PA"
                                    Case "2"
                                        tempObj.Text = "Hepatology"
                                        tempObj2.Text = "Hepatology"
                                    Case "3"
                                        tempObj.Text = "Med/Onc"
                                        tempObj2.Text = "Med/Onc"
                                    Case "4"
                                        tempObj.Text = "Social Work"
                                        tempObj2.Text = "Social Work"
                                    Case "5"
                                        tempObj.Text = "Dietitian"
                                        tempObj2.Text = "Dietitian"
                                    Case "6"
                                        tempObj.Text = "Lab"
                                        tempObj2.Text = "Lab"
                                    Case "7"
                                        tempObj.Text = "Imaging"
                                        tempObj2.Text = "Imaging"
                                    Case "8"
                                        tempObj.Text = "Notes"
                                        tempObj2.Text = "Notes"
                                End Select
                            Next
                        Catch ex As Exception
                        End Try
                        InitializeAfternoon()
                    End If
                End If
            ElseIf PanelBoardAfternoon.Visible = True Then
                If Ready2 = True Or (Ready2 = False And ReadyUser2 <> MyUser) Then
                    Dim flag As Boolean = False
                    Dim Read = From AA In TPDC.tblClinics
                               Select AA.Id, AA.ClinicDate, AA.RoomNames2, AA.PatientNames2, AA.Coordinator2, AA.Surgeon, AA.IR, AA.Dietitian2, AA.SW2, AA.MedOnc2, AA.Notes2, AA.Header2, AA.Done2, AA.ReadyRW2, AA.ImgBtnText2, AA.FontSize
                               Where ClinicDate = MyToDay

                    For Each row In Read
                        'clear array
                        For i = 0 To 13
                            For j = 0 To 12
                                Array2(i, j) = Nothing
                            Next
                        Next
                        'Read the Patient Names and separate them looking for ^
                        Dim temp As String = row.PatientNames2
                        If temp <> Nothing Then
                            flag = True
                            Dim x As Integer = 1
                            Dim y As Integer = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Coordinator2
                            x = 2
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Surgeon
                            x = 3
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.IR
                            x = 4
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Dietitian2
                            x = 5
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.SW2
                            x = 6
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.MedOnc2
                            x = 7
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Notes2
                            x = 8
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Header2
                            x = 9
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.Done2
                            x = 10
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            temp = row.ImgBtnText2
                            x = 11
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "|" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "|" Then
                                    y += 1
                                End If
                            Next

                            temp = row.RoomNames2
                            x = 13
                            y = 1
                            For i = 0 To temp.Length - 1
                                If temp.Chars(i) <> "^" Then
                                    Array2(x, y) += temp.Chars(i)
                                ElseIf temp.Chars(i) = "^" Then
                                    y += 1
                                End If
                            Next

                            Ready2 = row.ReadyRW2
                            size = row.FontSize
                        End If
                    Next
                    If flag = True Then
                        'Load the Data to the Table
                        'Array2: Name, Coord, IR, Surg, Trans, Notes
                        For i = 1 To 8
                            Dim tempObj As New Object
                            TextDict.TryGetValue("TextBoxPat" & i & "a", tempObj)
                            tempObj.Text = Array2(1, i)
                            LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                            tempObj.ToolTip = Array2(1, i)
                            If Array2(1, i) <> "Click to Edit" Then
                                Dim str As String = Array2(1, i)
                                str = str.Trim()
                                'Dim Initials As String = Nothing
                                'If str.Chars(0) <> " " Then
                                '    Initials += str.Chars(0) & " "
                                'End If
                                'For p = 0 To str.Length - 1
                                '    If str.Chars(p) = " " And p <> str.Length - 1 Then
                                '        If str.Chars(p + 1) <> " " And (p + 1) <= (str.Length - 1) Then
                                '            Initials += str.Chars(p + 1) & " "
                                '        End If
                                '    End If
                                'Next
                                tempObj.Text = str
                            Else
                                tempObj.Text = "Click to Edit"
                            End If
                            If tempObj.Text = "Click to Edit" Then
                                tempObj.ForeColor = Drawing.Color.LightGray
                            Else
                                tempObj.ForeColor = Drawing.Color.Black
                            End If
                            TextDict.TryGetValue("TextBox" & i & "a", tempObj)
                            tempObj.Text = Array2(8, i)
                            LinkDict.TryGetValue("Link" & i & "a", tempObj)
                            tempObj.Text = Array2(8, i)
                            If tempObj.Text = "Click to Edit" Then
                                tempObj.ForeColor = Drawing.Color.LightGray
                            Else
                                tempObj.ForeColor = Drawing.Color.Black
                            End If
                            LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                            tempObj.Text = Array2(10, i)
                            For k = 1 To 6
                                ImageDict.TryGetValue("Imagebutton" & i & k & "a", tempObj)
                                tempObj.ImageUrl = Array2(k + 1, i)
                            Next
                            Dim j As String = "1"
                            LinkDict.TryGetValue("LinkButtonA" & i & j, tempObj)
                            tempObj.Text = Nothing
                            For m = 0 To Array2(11, i).Length - 1
                                If Array2(11, i).Chars(m) <> "^" Then
                                    tempObj.Text += Array2(11, i).Chars(m)
                                ElseIf Array2(11, i).Chars(m) = "^" Then
                                    If tempObj.Text = "Add Note" Then
                                        tempObj.ForeColor = Drawing.Color.LightGray
                                    Else
                                        tempObj.ForeColor = Drawing.Color.DodgerBlue
                                    End If
                                    j += 1
                                    LinkDict.TryGetValue("LinkButtonA" & i & j, tempObj)
                                    tempObj.Text = Nothing
                                End If
                                If tempObj.Text = "Add Note" Then
                                    tempObj.ForeColor = Drawing.Color.LightGray
                                Else
                                    tempObj.ForeColor = Drawing.Color.DodgerBlue
                                End If
                            Next
                            j = "1"
                            TextDict.TryGetValue("TextBoxA" & i & j, tempObj)
                            tempObj.Text = Nothing
                            For m = 0 To Array2(11, i).Length - 1
                                If Array2(11, i).Chars(m) <> "^" Then
                                    tempObj.Text += Array2(11, i).Chars(m)
                                ElseIf Array2(11, i).Chars(m) = "^" Then
                                    j += 1
                                    TextDict.TryGetValue("TextBoxA" & i & j, tempObj)
                                    tempObj.Text = Nothing
                                End If
                            Next
                        Next
                        For i = 1 To 7
                            Dim tempObj As New Object
                            TextDict.TryGetValue("TextBoxHeader" & i & "a", tempObj)
                            tempObj.Text = Array2(9, i)
                            LinkDict.TryGetValue("LinkButtonHeader" & i & "a", tempObj)
                            tempObj.Text = Array2(9, i)
                        Next
                        Try
                            Dim tempObj As New Object
                            For i = 1 To 8
                                LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                                tempObj.Text = Array2(13, i)
                            Next
                        Catch ex As Exception

                        End Try
                    Else
                        'initialize everything for a new board
                        Try
                            For i = 1 To 8
                                Dim tempObj As New Object
                                Dim tempObj2 As New Object
                                TextDict.TryGetValue("TextBoxPat" & i & "a", tempObj)
                                tempObj.Text = "Click to Edit"
                                LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                                tempObj.ForeColor = Drawing.Color.LightGray
                                tempObj.Text = "Click to Edit"
                                tempObj.ToolTip = "Click to Edit"
                                TextDict.TryGetValue("TextBox" & i & "a", tempObj)
                                tempObj.Text = "Click to Edit"
                                LinkDict.TryGetValue("Link" & i & "a", tempObj)
                                tempObj.ForeColor = Drawing.Color.LightGray
                                tempObj.Text = "Click to Edit"
                                LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                                '/////////////////////////////////////////////////////////
                                Try
                                    Dim MyLastWeek As Date = MyToDay.AddDays(-7)
                                    Dim RN = From AA In TPDC.tblClinics
                                             Select AA.Id, AA.ClinicDate, AA.RoomNames2
                                             Where ClinicDate = MyLastWeek

                                    Dim tempVar As String = RN.FirstOrDefault.RoomNames2
                                    Dim tempArr(8) As String
                                    Dim n As Integer = 1
                                    For k = 0 To tempVar.Length - 1
                                        If tempVar.Chars(k) <> "^" Then
                                            tempArr(n) += tempVar.Chars(k)
                                        ElseIf tempVar.Chars(k) = "^" Then
                                            n += 1
                                        End If
                                    Next
                                    For j = 1 To 8
                                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & j & "a", tempObj)
                                        tempObj.Text = tempArr(j)
                                    Next
                                Catch ex2 As Exception
                                    For j = 1 To 8
                                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & j & "a", tempObj)
                                        tempObj.Text = "Room " & j
                                    Next
                                End Try
                                '/////////////////////////////////////////////////////////
                                For k = 1 To 6
                                    ImageDict.TryGetValue("Imagebutton" & i & k & "a", tempObj)
                                    tempObj.ImageUrl = "~/Images/nottobeseen.png"
                                    LinkDict.TryGetValue("LinkButtonA" & i & k, tempObj)
                                    tempObj.ForeColor = Drawing.Color.LightGray
                                    tempObj.Text = "Add Note"
                                    TextDict.TryGetValue("TextBoxA" & i & k, tempObj)
                                    tempObj.Text = "Add Note"
                                Next
                            Next
                        Catch ex As Exception
                        End Try
                        For i = 1 To 7
                            Dim tempObj As New Object
                            Dim tempObj2 As New Object
                            TextDict.TryGetValue("TextBoxHeader" & i & "a", tempObj)
                            LinkDict.TryGetValue("LinkButtonHeader" & i & "a", tempObj2)
                            Select Case i
                                Case "1"
                                    tempObj.Text = "PA"
                                    tempObj2.Text = "PA"
                                Case "2"
                                    tempObj.Text = "Surgeon"
                                    tempObj2.Text = "Surgeon"
                                Case "3"
                                    tempObj.Text = "IR"
                                    tempObj2.Text = "IR"
                                Case "4"
                                    tempObj.Text = "Dietitian"
                                    tempObj2.Text = "Dietitian"
                                Case "5"
                                    tempObj.Text = "Social Work"
                                    tempObj2.Text = "Social Work"
                                Case "6"
                                    tempObj.Text = "Med/Onc"
                                    tempObj2.Text = "Med/Onc"
                                Case "7"
                                    tempObj.Text = "Notes"
                                    tempObj2.Text = "Notes"
                            End Select
                        Next

                    End If
                End If
            End If
        Catch ex As Exception
        End Try
            RoomDone()
        Return True
    End Function

    Function WriteSQLData(ByVal DontCare As String) As String
        Try
            If PanelBoardMorning.Visible = True Then
                Try
                    Dim flag As Boolean = False
                    'Check if it exists first
                    Dim Read = From AA In TPDC.tblClinics
                               Select AA.Id, AA.ClinicDate, AA.RoomNames, AA.PatientNames, AA.Coordinator, AA.Hepatology, AA.MedOnc, AA.SW, AA.Dietitian, AA.Lab, AA.Imaging, AA.ImgBtnText, AA.Notes, AA.Header, AA.Done
                               Where ClinicDate = MyToDay
                    For Each row In Read
                        flag = True
                    Next
                    'Save Everything in Array
                    For i = 0 To 12
                        Array(0, i) = Nothing
                    Next

                    Dim tempObj As New Object
                    For i = 1 To 8
                        LinkDict.TryGetValue("LinkPat" & i, tempObj)
                        Array(0, 1) += tempObj.ToolTip.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                        For j = 1 To 7
                            ImageDict.TryGetValue("Imagebutton" & i & j, tempObj)
                            Array(0, j + 1) += tempObj.ImageUrl & "^"
                        Next
                        LinkDict.TryGetValue("Link" & i, tempObj)
                        Array(0, 9) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                        Array(0, 11) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                        For k = 1 To 7
                            LinkDict.TryGetValue("LinkButtonM" & i & k, tempObj)
                            If k < 7 Then
                                Array(0, 10) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                            ElseIf k = 7 Then
                                Array(0, 10) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "|"
                            End If
                        Next
                    Next
                    For i = 1 To 8
                        LinkDict.TryGetValue("LinkButtonHeader" & i, tempObj)
                        Array(0, 12) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                    Next
                    If flag = True Then
                        'Update
                        Dim Update = (From BB In TPDC.tblClinics
                                      Where BB.ClinicDate = MyToDay).ToList()(0)
                        Update.RoomNames = Array(0, 11)
                        Update.PatientNames = Array(0, 1)
                        Update.Coordinator = Array(0, 2)
                        Update.Hepatology = Array(0, 3)
                        Update.MedOnc = Array(0, 4)
                        Update.SW = Array(0, 5)
                        Update.Dietitian = Array(0, 6)
                        Update.Lab = Array(0, 7)
                        Update.Imaging = Array(0, 8)
                        Update.Notes = Array(0, 9)
                        Update.ImgBtnText = Array(0, 10)
                        Update.Done = Array(0, 11)
                        Update.Header = Array(0, 12)
                        Update.ModifyBy = MyUser
                        Update.ModifyDate = MyToDay
                        Update.ReadyRW = Ready
                        TPDC.SubmitChanges()
                    ElseIf flag = False Then
                        'Insert
                        Dim Insert As New ListDictionary
                        Dim temp = MyToDay.ToShortDateString
                        Insert.Add("ClinicDate", CStr(temp))
                        Insert.Add("RoomNames", Array(0, 11))
                        Insert.Add("PatientNames", Array(0, 1))
                        Insert.Add("Coordinator", Array(0, 2))
                        Insert.Add("Hepatology", Array(0, 3))
                        Insert.Add("MedOnc", Array(0, 4))
                        Insert.Add("SW", Array(0, 5))
                        Insert.Add("Dietitian", Array(0, 6))
                        Insert.Add("Lab", Array(0, 7))
                        Insert.Add("Imaging", Array(0, 8))
                        Insert.Add("Notes", Array(0, 9))
                        Insert.Add("ImgBtnText", Array(0, 10))
                        Insert.Add("Done", Array(0, 11))
                        Insert.Add("Header", Array(0, 12))
                        Insert.Add("EnterBy", MyUser)
                        Insert.Add("EnterDate", MyToDay)
                        Insert.Add("ModifyBy", MyUser)
                        Insert.Add("ModifyDate", MyToDay)
                        Insert.Add("ReadyRW", Ready)
                        Insert.Add("FontSize", size)
                        LinqClinic.Insert(Insert)
                        Insert.Clear()
                        If WriteAfternoon(DontCare) Then
                        End If
                    End If
                Catch ex As Exception
                End Try
            ElseIf PanelBoardAfternoon.Visible = True Then
                Try
                    Dim flag As Boolean = False
                    'Check if it exists first
                    Dim Read2 = From AA In TPDC.tblClinics
                                Select AA.Id, AA.ClinicDate, AA.RoomNames2, AA.PatientNames2, AA.Coordinator2, AA.Surgeon, AA.IR, AA.Dietitian2, AA.SW2, AA.MedOnc2, AA.ImgBtnText2, AA.Notes2, AA.Header2, AA.Done2
                                Where ClinicDate = MyToDay
                    For Each row In Read2
                        flag = True
                    Next
                    'Save Everything in Array2
                    For i = 0 To 12
                        Array2(0, i) = Nothing
                    Next
                    Dim tempObj As New Object
                    For i = 1 To 8
                        LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                        Array2(0, 1) += tempObj.ToolTip.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                        For j = 1 To 6
                            ImageDict.TryGetValue("Imagebutton" & i & j & "a", tempObj)
                            Array2(0, j + 1) += tempObj.ImageUrl & "^"
                        Next
                        LinkDict.TryGetValue("Link" & i & "a", tempObj)
                        Array2(0, 8) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                        LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                        Array2(0, 10) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                        For k = 1 To 6
                            LinkDict.TryGetValue("LinkButtonA" & i & k, tempObj)
                            If k < 6 Then
                                Array2(0, 11) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                            ElseIf k = 6 Then
                                Array2(0, 11) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "|"
                            End If
                        Next
                    Next
                    For i = 1 To 7
                        LinkDict.TryGetValue("LinkButtonHeader" & i & "a", tempObj)
                        Array2(0, 9) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                    Next

                    If flag = True Then
                        'Update
                        Dim Update = (From BB In TPDC.tblClinics
                                      Where BB.ClinicDate = MyToDay).ToList()(0)
                        Update.RoomNames2 = Array2(0, 10)
                        Update.PatientNames2 = Array2(0, 1)
                        Update.Coordinator2 = Array2(0, 2)
                        Update.Surgeon = Array2(0, 3)
                        Update.IR = Array2(0, 4)
                        Update.Dietitian2 = Array2(0, 5)
                        Update.SW2 = Array2(0, 6)
                        Update.MedOnc2 = Array2(0, 7)
                        Update.Notes2 = Array2(0, 8)
                        Update.Header2 = Array2(0, 9)
                        Update.Done2 = Array2(0, 10)
                        Update.ImgBtnText2 = Array2(0, 11)
                        Update.ModifyBy2 = MyUser
                        Update.ModifyDate2 = MyToDay
                        Update.ReadyRW2 = Ready2
                        TPDC.SubmitChanges()
                    ElseIf flag = False Then
                        'Insert
                        Try
                            Dim Insert As New ListDictionary
                            Dim temp = MyToDay.ToShortDateString
                            Insert.Add("ClinicDate", CStr(temp))
                            Insert.Add("RoomNames2", Array2(0, 10))
                            Insert.Add("PatientNames2", Array2(0, 1))
                            Insert.Add("Coordinator2", Array2(0, 2))
                            Insert.Add("Surgeon", Array2(0, 3))
                            Insert.Add("IR", Array2(0, 4))
                            Insert.Add("Dietitian2", Array2(0, 5))
                            Insert.Add("SW2", Array2(0, 6))
                            Insert.Add("MedOnc2", Array2(0, 7))
                            Insert.Add("Notes2", Array2(0, 8))
                            Insert.Add("Header2", Array2(0, 9))
                            Insert.Add("Done2", Array2(0, 10))
                            Insert.Add("ImgBtnText2", Array2(0, 11))
                            Insert.Add("EnterBy2", MyUser)
                            Insert.Add("EnterDate2", MyToDay)
                            Insert.Add("ModifyBy2", MyUser)
                            Insert.Add("ModifyDate2", MyToDay)
                            Insert.Add("ReadyRW2", Ready2)
                            Insert.Add("FontSize", size)
                            LinqClinic.Insert(Insert)
                            Insert.Clear()
                        Catch ex As Exception
                        End Try
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Function WriteAfternoon(ByVal DontCare As String) As String
        For i = 0 To 12
            Array2(0, i) = Nothing
        Next
        Dim tempObj As New Object
        For i = 1 To 8
            LinkDict.TryGetValue("LinkPat" & i, tempObj)
            Array2(0, 1) += tempObj.ToolTip & "^"
            For j = 1 To 6
                ImageDict.TryGetValue("Imagebutton" & i & j & "a", tempObj)
                Array2(0, j + 1) += tempObj.ImageUrl & "^"
            Next
            LinkDict.TryGetValue("Link" & i & "a", tempObj)
            Array2(0, 8) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
            For k = 1 To 6
                LinkDict.TryGetValue("LinkButtonA" & i & k, tempObj)
                If k < 6 Then
                    Array2(0, 11) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
                ElseIf k = 6 Then
                    Array2(0, 11) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "|"
                End If
            Next
        Next
        Dim RD = From p In TPDC.tblClinics
                 Where p.ClinicDate = MyToDay.AddDays(-7)
                 Select p.Id, p.RoomNames2

        Try
            Array2(0, 10) = RD.FirstOrDefault.RoomNames2
        Catch ex As Exception
            For i = 1 To 8
                Array2(0, 10) += "Room " & i & "^"
            Next
        End Try

        For i = 1 To 7
            LinkDict.TryGetValue("LinkButtonHeader" & i & "a", tempObj)
            Array2(0, 9) += tempObj.Text.Replace(">", "").Replace("<", "").Replace("/", "").Replace("?", "").Replace("*", "") & "^"
        Next
        Ready2 = True
        Dim Update = (From BB In TPDC.tblClinics
                      Where BB.ClinicDate = MyToDay).ToList()(0)
        Update.RoomNames2 = Array2(0, 10)
        Update.PatientNames2 = Array2(0, 1)
        Update.Coordinator2 = Array2(0, 2)
        Update.Surgeon = Array2(0, 3)
        Update.IR = Array2(0, 4)
        Update.Dietitian2 = Array2(0, 5)
        Update.SW2 = Array2(0, 6)
        Update.MedOnc2 = Array2(0, 7)
        Update.Notes2 = Array2(0, 8)
        Update.Header2 = Array2(0, 9)
        Update.Done2 = Array2(0, 10)
        Update.ImgBtnText2 = Array2(0, 11)
        Update.EnterBy2 = MyUser
        Update.EnterDate2 = MyToDay
        Update.ModifyBy2 = MyUser
        Update.ModifyDate2 = MyToDay
        Update.ReadyRW2 = Ready2
        TPDC.SubmitChanges()
        Return True
    End Function

    Protected Sub InitializeAfternoon()
        'initialize everything for a new board
        Try
            For i = 1 To 8
                Dim tempObj As New Object
                Dim tempObj2 As New Object
                TextDict.TryGetValue("TextBoxPat" & i & "a", tempObj)
                tempObj.Text = "Click to Edit"
                LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                tempObj.ForeColor = Drawing.Color.LightGray
                tempObj.Text = "Click to Edit"
                tempObj.ToolTip = "Click to Edit"
                TextDict.TryGetValue("TextBox" & i & "a", tempObj)
                tempObj.Text = "Click to Edit"
                LinkDict.TryGetValue("Link" & i & "a", tempObj)
                tempObj.ForeColor = Drawing.Color.LightGray
                tempObj.Text = "Click to Edit"
                LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i & "a", tempObj)
                tempObj.Text = i
                For k = 1 To 6
                    ImageDict.TryGetValue("Imagebutton" & i & k & "a", tempObj)
                    tempObj.ImageUrl = "~/Images/nottobeseen.png"
                    LinkDict.TryGetValue("LinkButtonA" & i & k, tempObj)
                    tempObj.ForeColor = Drawing.Color.LightGray
                    tempObj.Text = "Add Note"
                    TextDict.TryGetValue("TextBoxA" & i & k, tempObj)
                    tempObj.Text = "Add Note"
                Next
            Next
        Catch ex As Exception
        End Try
        For i = 1 To 7
            Dim tempObj As New Object
            Dim tempObj2 As New Object
            TextDict.TryGetValue("TextBoxHeader" & i & "a", tempObj)
            LinkDict.TryGetValue("LinkButtonHeader" & i & "a", tempObj2)
            Select Case i
                Case "1"
                    tempObj.Text = "PA"
                    tempObj2.Text = "PA"
                Case "2"
                    tempObj.Text = "Surgeon"
                    tempObj2.Text = "Surgeon"
                Case "3"
                    tempObj.Text = "IR"
                    tempObj2.Text = "IR"
                Case "4"
                    tempObj.Text = "Dietitian"
                    tempObj2.Text = "Dietitian"
                Case "5"
                    tempObj.Text = "Social Work"
                    tempObj2.Text = "Social Work"
                Case "6"
                    tempObj.Text = "Med/Onc"
                    tempObj2.Text = "Med/Onc"
                Case "7"
                    tempObj.Text = "Notes"
                    tempObj2.Text = "Notes"
            End Select
        Next
    End Sub

    Function AutoWriteAfternoon(ByVal DontCare As String) As String
        Try

            For i = 0 To 12
                Array2(0, i) = Nothing
            Next
            Dim tempObj As New Object
            For i = 1 To 8
                LinkDict.TryGetValue("LinkPat" & i, tempObj)
                Array2(0, 1) += tempObj.ToolTip & "^"
                LinkButtonRoomDict.TryGetValue("LinkButtonRoom" & i, tempObj)
                Array2(0, 2) += tempObj.Text & "^"
            Next
            Dim Update = (From BB In TPDC.tblClinics
                          Where BB.ClinicDate = MyToDay).ToList()(0)
            Update.RoomNames2 = Array2(0, 2)
            Update.PatientNames2 = Array2(0, 1)
            Update.ModifyBy2 = MyUser
            Update.ModifyDate2 = MyToDay
            TPDC.SubmitChanges()

        Catch ex As Exception
        End Try
        Return True
    End Function

    Protected Sub ReadCheckRead()
        If PanelBoardMorning.Visible = True Then
            Try
                'Read the ReadyRW if false, set flag and display message
                Dim Read = From AA In TPDC.tblClinics
                           Select AA.Id, AA.ClinicDate, AA.ReadyRW, AA.ModifyBy
                           Where ClinicDate = MyToDay

                For Each row In Read
                    Ready = row.ReadyRW
                    ReadyUser = row.ModifyBy
                Next
                If Ready = False And ReadyUser <> MyUser Then
                    NotReady.Text = "User: '" & ReadyUser & "' is currently making changes."
                    If ReadSQLData(DontCare) Then
                    End If
                ElseIf Ready = False And ReadyUser = MyUser Then
                    NotReady.Text = Nothing
                Else
                    NotReady.Text = Nothing 'Clear for Ready
                    If ReadSQLData(DontCare) Then
                    End If
                End If
            Catch Ex As Exception
            End Try
        ElseIf PanelBoardAfternoon.Visible = True Then
            Try
                'Read the ReadyRW2 if false, set flag and display message
                Dim Read = From AA In TPDC.tblClinics
                           Select AA.Id, AA.ClinicDate, AA.ReadyRW2, AA.ModifyBy2
                           Where ClinicDate = MyToDay
                For Each row In Read
                    Ready2 = row.ReadyRW2
                    ReadyUser2 = row.ModifyBy2
                Next
                If Ready2 = False And ReadyUser2 <> MyUser Then
                    notreadya.Text = "User: '" & ReadyUser2 & "' is currently making changes."
                    If ReadSQLData(DontCare) Then
                    End If
                ElseIf Ready2 = False And ReadyUser2 = MyUser Then
                    notreadya.Text = Nothing
                Else
                    notreadya.Text = Nothing 'Clear for Ready
                    If ReadSQLData(DontCare) Then
                    End If
                End If
            Catch Ex As Exception
            End Try
        End If
    End Sub

    Sub InitializeSize()
        Try
            Dim tempObj As New Object
            For i = 1 To 8
                TextDict.TryGetValue("TextBox" & i, tempObj)
                tempObj.Font.Size = size
                LinkDict.TryGetValue("Link" & i, tempObj)
                tempObj.Font.Size = size
                LabelLinkDict.TryGetValue("LabelLink" & i, tempObj)
                tempObj.Font.Size = size
                TextDict.TryGetValue("TextBoxPat" & i, tempObj)
                tempObj.Font.Size = size
                LinkDict.TryGetValue("LinkPat" & i, tempObj)
                tempObj.Font.Size = size
                LabelLinkDict.TryGetValue("LabelLinkPat" & i, tempObj)
                tempObj.Font.Size = size

                TextDict.TryGetValue("TextBox" & i & "a", tempObj)
                tempObj.Font.Size = size
                LinkDict.TryGetValue("Link" & i & "a", tempObj)
                tempObj.Font.Size = size
                LabelLinkDict.TryGetValue("LabelLink" & i & "a", tempObj)
                tempObj.Font.Size = size
                TextDict.TryGetValue("TextBoxPat" & i & "a", tempObj)
                tempObj.Font.Size = size
                LinkDict.TryGetValue("LinkPat" & i & "a", tempObj)
                tempObj.Font.Size = size
                LabelLinkDict.TryGetValue("LabelLinkPat" & i & "a", tempObj)
                tempObj.Font.Size = size
            Next
        Catch ex As Exception
        End Try
        Return
    End Sub

    Function CheckIfTextBoxIsOpen(ByVal DontCare As String) As String
        Try
            If PanelBoardMorning.Visible = True Then
                Dim tempObj As New Object
                Dim count As Integer = Nothing
                For i = 1 To 8
                    TextDict.TryGetValue("TextBoxRoom" & i, tempObj)
                    If tempObj.Visible() = True Then
                        count += 1
                    End If
                    TextDict.TryGetValue("TextBox" & i, tempObj)
                    If tempObj.Visible() = True Then
                        count += 1
                    End If
                    TextDict.TryGetValue("TextBoxPat" & i, tempObj)
                    If tempObj.Visible() = True Then
                        count += 1
                    End If
                    TextDict.TryGetValue("TextBoxHeader" & i, tempObj)
                    If tempObj.Visible() = True Then
                        count += 1
                    End If
                    For k = 1 To 7
                        TextDict.TryGetValue("TextBoxM" & i & k, tempObj)
                        If tempObj.Visible() = True Then
                            count += 1
                        End If
                    Next
                Next
                If count <> Nothing Then
                    Ready = False
                    If WriteSQLData(DontCare) Then
                    End If
                    If NameChanged <> Nothing Then
                        NameChanged = Nothing
                        If AutoWriteAfternoon(DontCare) Then
                        End If
                    End If
                Else
                    Ready = True
                    If WriteSQLData(DontCare) Then
                    End If
                    If NameChanged <> Nothing Then
                        NameChanged = Nothing
                        If AutoWriteAfternoon(DontCare) Then
                        End If
                    End If
                    If RoomChanged <> Nothing Then
                        RoomChanged = Nothing
                        If AutoWriteAfternoon(DontCare) Then
                        End If
                    End If
                    Timer1.Enabled = True
                End If

            ElseIf PanelBoardAfternoon.Visible = True Then
                Dim tempObj As New Object
                Dim count As Integer = Nothing
                For i = 1 To 8
                    TextDict.TryGetValue("TextBoxRoom" & i & "a", tempObj)
                    If tempObj.Visible() = True Then
                        count += 1
                    End If
                    TextDict.TryGetValue("TextBox" & i & "a", tempObj)
                    If tempObj.Visible() = True Then
                        count += 1
                    End If
                    TextDict.TryGetValue("TextBoxPat" & i & "a", tempObj)
                    If tempObj.Visible() = True Then
                        count += 1
                    End If
                    For k = 1 To 6
                        TextDict.TryGetValue("TextBoxA" & i & k, tempObj)
                        If tempObj.Visible() = True Then
                            count += 1
                        End If
                    Next
                Next
                For j = 1 To 7
                    TextDict.TryGetValue("TextBoxHeader" & j & "a", tempObj)
                    If tempObj.Visible() = True Then
                        count += 1
                    End If
                Next
                If count <> Nothing Then
                    Ready2 = False
                    If WriteSQLData(DontCare) Then
                    End If
                    If AutoWriteAfternoon(DontCare) Then
                    End If
                Else
                    Ready2 = True
                    If WriteSQLData(DontCare) Then
                    End If
                    Timer1.Enabled = True
                End If

            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Sub InitializeDictionaries()
        Try
            LinkButtonRoomDict.Add("LinkButtonRoom1", LinkButtonRoom1)
            LinkButtonRoomDict.Add("LinkButtonRoom2", LinkButtonRoom2)
            LinkButtonRoomDict.Add("LinkButtonRoom3", LinkButtonRoom3)
            LinkButtonRoomDict.Add("LinkButtonRoom4", LinkButtonRoom4)
            LinkButtonRoomDict.Add("LinkButtonRoom5", LinkButtonRoom5)
            LinkButtonRoomDict.Add("LinkButtonRoom6", LinkButtonRoom6)
            LinkButtonRoomDict.Add("LinkButtonRoom7", LinkButtonRoom7)
            LinkButtonRoomDict.Add("LinkButtonRoom8", LinkButtonRoom8)
            LinkButtonRoomDict.Add("LinkButtonRoom1a", LinkButtonRoom1a)
            LinkButtonRoomDict.Add("LinkButtonRoom2a", LinkButtonRoom2a)
            LinkButtonRoomDict.Add("LinkButtonRoom3a", LinkButtonRoom3a)
            LinkButtonRoomDict.Add("LinkButtonRoom4a", LinkButtonRoom4a)
            LinkButtonRoomDict.Add("LinkButtonRoom5a", LinkButtonRoom5a)
            LinkButtonRoomDict.Add("LinkButtonRoom6a", LinkButtonRoom6a)
            LinkButtonRoomDict.Add("LinkButtonRoom7a", LinkButtonRoom7a)
            LinkButtonRoomDict.Add("LinkButtonRoom8a", LinkButtonRoom8a)
            LabelRoomDict.Add("LabelRoom1", LabelRoom1)
            LabelRoomDict.Add("LabelRoom2", LabelRoom2)
            LabelRoomDict.Add("LabelRoom3", LabelRoom3)
            LabelRoomDict.Add("LabelRoom4", LabelRoom4)
            LabelRoomDict.Add("LabelRoom5", LabelRoom5)
            LabelRoomDict.Add("LabelRoom6", LabelRoom6)
            LabelRoomDict.Add("LabelRoom7", LabelRoom7)
            LabelRoomDict.Add("LabelRoom8", LabelRoom8)
            LabelRoomDict.Add("LabelRoom1a", LabelRoom1a)
            LabelRoomDict.Add("LabelRoom2a", LabelRoom2a)
            LabelRoomDict.Add("LabelRoom3a", LabelRoom3a)
            LabelRoomDict.Add("LabelRoom4a", LabelRoom4a)
            LabelRoomDict.Add("LabelRoom5a", LabelRoom5a)
            LabelRoomDict.Add("LabelRoom6a", LabelRoom6a)
            LabelRoomDict.Add("LabelRoom7a", LabelRoom7a)
            LabelRoomDict.Add("LabelRoom8a", LabelRoom8a)
            LabelLinkDict.Add("LabelLink1", LabelLink1)
            LabelLinkDict.Add("LabelLink2", LabelLink2)
            LabelLinkDict.Add("LabelLink3", LabelLink3)
            LabelLinkDict.Add("LabelLink4", LabelLink4)
            LabelLinkDict.Add("LabelLink5", LabelLink5)
            LabelLinkDict.Add("LabelLink6", LabelLink6)
            LabelLinkDict.Add("LabelLink7", LabelLink7)
            LabelLinkDict.Add("LabelLink8", LabelLink8)
            LabelLinkDict.Add("LabelLink1a", LabelLink1a)
            LabelLinkDict.Add("LabelLink2a", LabelLink2a)
            LabelLinkDict.Add("LabelLink3a", LabelLink3a)
            LabelLinkDict.Add("LabelLink4a", LabelLink4a)
            LabelLinkDict.Add("LabelLink5a", LabelLink5a)
            LabelLinkDict.Add("LabelLink6a", LabelLink6a)
            LabelLinkDict.Add("LabelLink7a", LabelLink7a)
            LabelLinkDict.Add("LabelLink8a", LabelLink8a)
            LabelLinkDict.Add("LabelLinkPat1", LabelLinkPat1)
            LabelLinkDict.Add("LabelLinkPat2", LabelLinkPat2)
            LabelLinkDict.Add("LabelLinkPat3", LabelLinkPat3)
            LabelLinkDict.Add("LabelLinkPat4", LabelLinkPat4)
            LabelLinkDict.Add("LabelLinkPat5", LabelLinkPat5)
            LabelLinkDict.Add("LabelLinkPat6", LabelLinkPat6)
            LabelLinkDict.Add("LabelLinkPat7", LabelLinkPat7)
            LabelLinkDict.Add("LabelLinkPat8", LabelLinkPat8)
            LabelLinkDict.Add("LabelLinkPat1a", LabelLinkPat1a)
            LabelLinkDict.Add("LabelLinkPat2a", LabelLinkPat2a)
            LabelLinkDict.Add("LabelLinkPat3a", LabelLinkPat3a)
            LabelLinkDict.Add("LabelLinkPat4a", LabelLinkPat4a)
            LabelLinkDict.Add("LabelLinkPat5a", LabelLinkPat5a)
            LabelLinkDict.Add("LabelLinkPat6a", LabelLinkPat6a)
            LabelLinkDict.Add("LabelLinkPat7a", LabelLinkPat7a)
            LabelLinkDict.Add("LabelLinkPat8a", LabelLinkPat8a)
            LinkDict.Add("Link1", Link1)
            LinkDict.Add("Link2", Link2)
            LinkDict.Add("Link3", Link3)
            LinkDict.Add("Link4", Link4)
            LinkDict.Add("Link5", Link5)
            LinkDict.Add("Link6", Link6)
            LinkDict.Add("Link7", Link7)
            LinkDict.Add("Link8", Link8)
            LinkDict.Add("Link1a", Link1a)
            LinkDict.Add("Link2a", Link2a)
            LinkDict.Add("Link3a", Link3a)
            LinkDict.Add("Link4a", Link4a)
            LinkDict.Add("Link5a", Link5a)
            LinkDict.Add("Link6a", Link6a)
            LinkDict.Add("Link7a", Link7a)
            LinkDict.Add("Link8a", Link8a)
            LinkDict.Add("LinkPat1", LinkPat1)
            LinkDict.Add("LinkPat2", LinkPat2)
            LinkDict.Add("LinkPat3", LinkPat3)
            LinkDict.Add("LinkPat4", LinkPat4)
            LinkDict.Add("LinkPat5", LinkPat5)
            LinkDict.Add("LinkPat6", LinkPat6)
            LinkDict.Add("LinkPat7", LinkPat7)
            LinkDict.Add("LinkPat8", LinkPat8)
            LinkDict.Add("LinkPat1a", LinkPat1a)
            LinkDict.Add("LinkPat2a", LinkPat2a)
            LinkDict.Add("LinkPat3a", LinkPat3a)
            LinkDict.Add("LinkPat4a", LinkPat4a)
            LinkDict.Add("LinkPat5a", LinkPat5a)
            LinkDict.Add("LinkPat6a", LinkPat6a)
            LinkDict.Add("LinkPat7a", LinkPat7a)
            LinkDict.Add("LinkPat8a", LinkPat8a)
            LinkDict.Add("LinkButtonHeader1", LinkButtonHeader1)
            LinkDict.Add("LinkButtonHeader2", LinkButtonHeader2)
            LinkDict.Add("LinkButtonHeader3", LinkButtonHeader3)
            LinkDict.Add("LinkButtonHeader4", LinkButtonHeader4)
            LinkDict.Add("LinkButtonHeader5", LinkButtonHeader5)
            LinkDict.Add("LinkButtonHeader6", LinkButtonHeader6)
            LinkDict.Add("LinkButtonHeader7", LinkButtonHeader7)
            LinkDict.Add("LinkButtonHeader8", LinkButtonHeader8)
            LinkDict.Add("LinkButtonHeader1a", LinkButtonHeader1a)
            LinkDict.Add("LinkButtonHeader2a", LinkButtonHeader2a)
            LinkDict.Add("LinkButtonHeader3a", LinkButtonHeader3a)
            LinkDict.Add("LinkButtonHeader4a", LinkButtonHeader4a)
            LinkDict.Add("LinkButtonHeader5a", LinkButtonHeader5a)
            LinkDict.Add("LinkButtonHeader6a", LinkButtonHeader6a)
            LinkDict.Add("LinkButtonHeader7a", LinkButtonHeader7a)
            LinkDict.Add("LinkButtonM11", LinkButtonM11)
            LinkDict.Add("LinkButtonM12", LinkButtonM12)
            LinkDict.Add("LinkButtonM13", LinkButtonM13)
            LinkDict.Add("LinkButtonM14", LinkButtonM14)
            LinkDict.Add("LinkButtonM15", LinkButtonM15)
            LinkDict.Add("LinkButtonM16", LinkButtonM16)
            LinkDict.Add("LinkButtonM17", LinkButtonM17)
            LinkDict.Add("LinkButtonM21", LinkButtonM21)
            LinkDict.Add("LinkButtonM22", LinkButtonM22)
            LinkDict.Add("LinkButtonM23", LinkButtonM23)
            LinkDict.Add("LinkButtonM24", LinkButtonM24)
            LinkDict.Add("LinkButtonM25", LinkButtonM25)
            LinkDict.Add("LinkButtonM26", LinkButtonM26)
            LinkDict.Add("LinkButtonM27", LinkButtonM27)
            LinkDict.Add("LinkButtonM31", LinkButtonM31)
            LinkDict.Add("LinkButtonM32", LinkButtonM32)
            LinkDict.Add("LinkButtonM33", LinkButtonM33)
            LinkDict.Add("LinkButtonM34", LinkButtonM34)
            LinkDict.Add("LinkButtonM35", LinkButtonM35)
            LinkDict.Add("LinkButtonM36", LinkButtonM36)
            LinkDict.Add("LinkButtonM37", LinkButtonM37)
            LinkDict.Add("LinkButtonM41", LinkButtonM41)
            LinkDict.Add("LinkButtonM42", LinkButtonM42)
            LinkDict.Add("LinkButtonM43", LinkButtonM43)
            LinkDict.Add("LinkButtonM44", LinkButtonM44)
            LinkDict.Add("LinkButtonM45", LinkButtonM45)
            LinkDict.Add("LinkButtonM46", LinkButtonM46)
            LinkDict.Add("LinkButtonM47", LinkButtonM47)
            LinkDict.Add("LinkButtonM51", LinkButtonM51)
            LinkDict.Add("LinkButtonM52", LinkButtonM52)
            LinkDict.Add("LinkButtonM53", LinkButtonM53)
            LinkDict.Add("LinkButtonM54", LinkButtonM54)
            LinkDict.Add("LinkButtonM55", LinkButtonM55)
            LinkDict.Add("LinkButtonM56", LinkButtonM56)
            LinkDict.Add("LinkButtonM57", LinkButtonM57)
            LinkDict.Add("LinkButtonM61", LinkButtonM61)
            LinkDict.Add("LinkButtonM62", LinkButtonM62)
            LinkDict.Add("LinkButtonM63", LinkButtonM63)
            LinkDict.Add("LinkButtonM64", LinkButtonM64)
            LinkDict.Add("LinkButtonM65", LinkButtonM65)
            LinkDict.Add("LinkButtonM66", LinkButtonM66)
            LinkDict.Add("LinkButtonM67", LinkButtonM67)
            LinkDict.Add("LinkButtonM71", LinkButtonM71)
            LinkDict.Add("LinkButtonM72", LinkButtonM72)
            LinkDict.Add("LinkButtonM73", LinkButtonM73)
            LinkDict.Add("LinkButtonM74", LinkButtonM74)
            LinkDict.Add("LinkButtonM75", LinkButtonM75)
            LinkDict.Add("LinkButtonM76", LinkButtonM76)
            LinkDict.Add("LinkButtonM77", LinkButtonM77)
            LinkDict.Add("LinkButtonM81", LinkButtonM81)
            LinkDict.Add("LinkButtonM82", LinkButtonM82)
            LinkDict.Add("LinkButtonM83", LinkButtonM83)
            LinkDict.Add("LinkButtonM84", LinkButtonM84)
            LinkDict.Add("LinkButtonM85", LinkButtonM85)
            LinkDict.Add("LinkButtonM86", LinkButtonM86)
            LinkDict.Add("LinkButtonM87", LinkButtonM87)
            LinkDict.Add("LinkButtonA11", LinkButtonA11)
            LinkDict.Add("LinkButtonA12", LinkButtonA12)
            LinkDict.Add("LinkButtonA13", LinkButtonA13)
            LinkDict.Add("LinkButtonA14", LinkButtonA14)
            LinkDict.Add("LinkButtonA15", LinkButtonA15)
            LinkDict.Add("LinkButtonA16", LinkButtonA16)
            LinkDict.Add("LinkButtonA21", LinkButtonA21)
            LinkDict.Add("LinkButtonA22", LinkButtonA22)
            LinkDict.Add("LinkButtonA23", LinkButtonA23)
            LinkDict.Add("LinkButtonA24", LinkButtonA24)
            LinkDict.Add("LinkButtonA25", LinkButtonA25)
            LinkDict.Add("LinkButtonA26", LinkButtonA26)
            LinkDict.Add("LinkButtonA31", LinkButtonA31)
            LinkDict.Add("LinkButtonA32", LinkButtonA32)
            LinkDict.Add("LinkButtonA33", LinkButtonA33)
            LinkDict.Add("LinkButtonA34", LinkButtonA34)
            LinkDict.Add("LinkButtonA35", LinkButtonA35)
            LinkDict.Add("LinkButtonA36", LinkButtonA36)
            LinkDict.Add("LinkButtonA41", LinkButtonA41)
            LinkDict.Add("LinkButtonA42", LinkButtonA42)
            LinkDict.Add("LinkButtonA43", LinkButtonA43)
            LinkDict.Add("LinkButtonA44", LinkButtonA44)
            LinkDict.Add("LinkButtonA45", LinkButtonA45)
            LinkDict.Add("LinkButtonA46", LinkButtonA46)
            LinkDict.Add("LinkButtonA51", LinkButtonA51)
            LinkDict.Add("LinkButtonA52", LinkButtonA52)
            LinkDict.Add("LinkButtonA53", LinkButtonA53)
            LinkDict.Add("LinkButtonA54", LinkButtonA54)
            LinkDict.Add("LinkButtonA55", LinkButtonA55)
            LinkDict.Add("LinkButtonA56", LinkButtonA56)
            LinkDict.Add("LinkButtonA61", LinkButtonA61)
            LinkDict.Add("LinkButtonA62", LinkButtonA62)
            LinkDict.Add("LinkButtonA63", LinkButtonA63)
            LinkDict.Add("LinkButtonA64", LinkButtonA64)
            LinkDict.Add("LinkButtonA65", LinkButtonA65)
            LinkDict.Add("LinkButtonA66", LinkButtonA66)
            LinkDict.Add("LinkButtonA71", LinkButtonA71)
            LinkDict.Add("LinkButtonA72", LinkButtonA72)
            LinkDict.Add("LinkButtonA73", LinkButtonA73)
            LinkDict.Add("LinkButtonA74", LinkButtonA74)
            LinkDict.Add("LinkButtonA75", LinkButtonA75)
            LinkDict.Add("LinkButtonA76", LinkButtonA76)
            LinkDict.Add("LinkButtonA81", LinkButtonA81)
            LinkDict.Add("LinkButtonA82", LinkButtonA82)
            LinkDict.Add("LinkButtonA83", LinkButtonA83)
            LinkDict.Add("LinkButtonA84", LinkButtonA84)
            LinkDict.Add("LinkButtonA85", LinkButtonA85)
            LinkDict.Add("LinkButtonA86", LinkButtonA86)
            TextDict.Add("TextBox1", TextBox1)
            TextDict.Add("TextBox2", TextBox2)
            TextDict.Add("TextBox3", TextBox3)
            TextDict.Add("TextBox4", TextBox4)
            TextDict.Add("TextBox5", TextBox5)
            TextDict.Add("TextBox6", TextBox6)
            TextDict.Add("TextBox7", TextBox7)
            TextDict.Add("TextBox8", TextBox8)
            TextDict.Add("TextBoxRoom1", TextBoxRoom1)
            TextDict.Add("TextBoxRoom2", TextBoxRoom2)
            TextDict.Add("TextBoxRoom3", TextBoxRoom3)
            TextDict.Add("TextBoxRoom4", TextBoxRoom4)
            TextDict.Add("TextBoxRoom5", TextBoxRoom5)
            TextDict.Add("TextBoxRoom6", TextBoxRoom6)
            TextDict.Add("TextBoxRoom7", TextBoxRoom7)
            TextDict.Add("TextBoxRoom8", TextBoxRoom8)
            TextDict.Add("TextBoxRoom1a", TextBoxRoom1a)
            TextDict.Add("TextBoxRoom2a", TextBoxRoom2a)
            TextDict.Add("TextBoxRoom3a", TextBoxRoom3a)
            TextDict.Add("TextBoxRoom4a", TextBoxRoom4a)
            TextDict.Add("TextBoxRoom5a", TextBoxRoom5a)
            TextDict.Add("TextBoxRoom6a", TextBoxRoom6a)
            TextDict.Add("TextBoxRoom7a", TextBoxRoom7a)
            TextDict.Add("TextBoxRoom8a", TextBoxRoom8a)
            TextDict.Add("TextBoxPat1", TextBoxPat1)
            TextDict.Add("TextBoxPat2", TextBoxPat2)
            TextDict.Add("TextBoxPat3", TextBoxPat3)
            TextDict.Add("TextBoxPat4", TextBoxPat4)
            TextDict.Add("TextBoxPat5", TextBoxPat5)
            TextDict.Add("TextBoxPat6", TextBoxPat6)
            TextDict.Add("TextBoxPat7", TextBoxPat7)
            TextDict.Add("TextBoxPat8", TextBoxPat8)
            TextDict.Add("TextBox1a", TextBox1a)
            TextDict.Add("TextBox2a", TextBox2a)
            TextDict.Add("TextBox3a", TextBox3a)
            TextDict.Add("TextBox4a", TextBox4a)
            TextDict.Add("TextBox5a", TextBox5a)
            TextDict.Add("TextBox6a", TextBox6a)
            TextDict.Add("TextBox7a", TextBox7a)
            TextDict.Add("TextBox8a", TextBox8a)
            TextDict.Add("TextBoxPat1a", TextBoxPat1a)
            TextDict.Add("TextBoxPat2a", TextBoxPat2a)
            TextDict.Add("TextBoxPat3a", TextBoxPat3a)
            TextDict.Add("TextBoxPat4a", TextBoxPat4a)
            TextDict.Add("TextBoxPat5a", TextBoxPat5a)
            TextDict.Add("TextBoxPat6a", TextBoxPat6a)
            TextDict.Add("TextBoxPat7a", TextBoxPat7a)
            TextDict.Add("TextBoxPat8a", TextBoxPat8a)
            TextDict.Add("TextBoxHeader1", TextBoxHeader1)
            TextDict.Add("TextBoxHeader2", TextBoxHeader2)
            TextDict.Add("TextBoxHeader3", TextBoxHeader3)
            TextDict.Add("TextBoxHeader4", TextBoxHeader4)
            TextDict.Add("TextBoxHeader5", TextBoxHeader5)
            TextDict.Add("TextBoxHeader6", TextBoxHeader6)
            TextDict.Add("TextBoxHeader7", TextBoxHeader7)
            TextDict.Add("TextBoxHeader8", TextBoxHeader8)
            TextDict.Add("LabelHeader1", LabelHeader1)
            TextDict.Add("LabelHeader2", LabelHeader2)
            TextDict.Add("LabelHeader3", LabelHeader3)
            TextDict.Add("LabelHeader4", LabelHeader4)
            TextDict.Add("LabelHeader5", LabelHeader5)
            TextDict.Add("LabelHeader6", LabelHeader6)
            TextDict.Add("LabelHeader7", LabelHeader7)
            TextDict.Add("LabelHeader8", LabelHeader8)
            TextDict.Add("TextBoxHeader1a", TextBoxHeader1a)
            TextDict.Add("TextBoxHeader2a", TextBoxHeader2a)
            TextDict.Add("TextBoxHeader3a", TextBoxHeader3a)
            TextDict.Add("TextBoxHeader4a", TextBoxHeader4a)
            TextDict.Add("TextBoxHeader5a", TextBoxHeader5a)
            TextDict.Add("TextBoxHeader6a", TextBoxHeader6a)
            TextDict.Add("TextBoxHeader7a", TextBoxHeader7a)
            TextDict.Add("LabelHeader1a", LabelHeader1a)
            TextDict.Add("LabelHeader2a", LabelHeader2a)
            TextDict.Add("LabelHeader3a", LabelHeader3a)
            TextDict.Add("LabelHeader4a", LabelHeader4a)
            TextDict.Add("LabelHeader5a", LabelHeader5a)
            TextDict.Add("LabelHeader6a", LabelHeader6a)
            TextDict.Add("LabelHeader7a", LabelHeader7a)
            TextDict.Add("TextBoxM11", TextBoxM11)
            TextDict.Add("TextBoxM12", TextBoxM12)
            TextDict.Add("TextBoxM13", TextBoxM13)
            TextDict.Add("TextBoxM14", TextBoxM14)
            TextDict.Add("TextBoxM15", TextBoxM15)
            TextDict.Add("TextBoxM16", TextBoxM16)
            TextDict.Add("TextBoxM17", TextBoxM17)
            TextDict.Add("TextBoxM21", TextBoxM21)
            TextDict.Add("TextBoxM22", TextBoxM22)
            TextDict.Add("TextBoxM23", TextBoxM23)
            TextDict.Add("TextBoxM24", TextBoxM24)
            TextDict.Add("TextBoxM25", TextBoxM25)
            TextDict.Add("TextBoxM26", TextBoxM26)
            TextDict.Add("TextBoxM27", TextBoxM27)
            TextDict.Add("TextBoxM31", TextBoxM31)
            TextDict.Add("TextBoxM32", TextBoxM32)
            TextDict.Add("TextBoxM33", TextBoxM33)
            TextDict.Add("TextBoxM34", TextBoxM34)
            TextDict.Add("TextBoxM35", TextBoxM35)
            TextDict.Add("TextBoxM36", TextBoxM36)
            TextDict.Add("TextBoxM37", TextBoxM37)
            TextDict.Add("TextBoxM41", TextBoxM41)
            TextDict.Add("TextBoxM42", TextBoxM42)
            TextDict.Add("TextBoxM43", TextBoxM43)
            TextDict.Add("TextBoxM44", TextBoxM44)
            TextDict.Add("TextBoxM45", TextBoxM45)
            TextDict.Add("TextBoxM46", TextBoxM46)
            TextDict.Add("TextBoxM47", TextBoxM47)
            TextDict.Add("TextBoxM51", TextBoxM51)
            TextDict.Add("TextBoxM52", TextBoxM52)
            TextDict.Add("TextBoxM53", TextBoxM53)
            TextDict.Add("TextBoxM54", TextBoxM54)
            TextDict.Add("TextBoxM55", TextBoxM55)
            TextDict.Add("TextBoxM56", TextBoxM56)
            TextDict.Add("TextBoxM57", TextBoxM57)
            TextDict.Add("TextBoxM61", TextBoxM61)
            TextDict.Add("TextBoxM62", TextBoxM62)
            TextDict.Add("TextBoxM63", TextBoxM63)
            TextDict.Add("TextBoxM64", TextBoxM64)
            TextDict.Add("TextBoxM65", TextBoxM65)
            TextDict.Add("TextBoxM66", TextBoxM66)
            TextDict.Add("TextBoxM67", TextBoxM67)
            TextDict.Add("TextBoxM71", TextBoxM71)
            TextDict.Add("TextBoxM72", TextBoxM72)
            TextDict.Add("TextBoxM73", TextBoxM73)
            TextDict.Add("TextBoxM74", TextBoxM74)
            TextDict.Add("TextBoxM75", TextBoxM75)
            TextDict.Add("TextBoxM76", TextBoxM76)
            TextDict.Add("TextBoxM77", TextBoxM77)
            TextDict.Add("TextBoxM81", TextBoxM81)
            TextDict.Add("TextBoxM82", TextBoxM82)
            TextDict.Add("TextBoxM83", TextBoxM83)
            TextDict.Add("TextBoxM84", TextBoxM84)
            TextDict.Add("TextBoxM85", TextBoxM85)
            TextDict.Add("TextBoxM86", TextBoxM86)
            TextDict.Add("TextBoxM87", TextBoxM87)
            TextDict.Add("TextBoxA11", TextBoxA11)
            TextDict.Add("TextBoxA12", TextBoxA12)
            TextDict.Add("TextBoxA13", TextBoxA13)
            TextDict.Add("TextBoxA14", TextBoxA14)
            TextDict.Add("TextBoxA15", TextBoxA15)
            TextDict.Add("TextBoxA16", TextBoxA16)
            TextDict.Add("TextBoxA21", TextBoxA21)
            TextDict.Add("TextBoxA22", TextBoxA22)
            TextDict.Add("TextBoxA23", TextBoxA23)
            TextDict.Add("TextBoxA24", TextBoxA24)
            TextDict.Add("TextBoxA25", TextBoxA25)
            TextDict.Add("TextBoxA26", TextBoxA26)
            TextDict.Add("TextBoxA31", TextBoxA31)
            TextDict.Add("TextBoxA32", TextBoxA32)
            TextDict.Add("TextBoxA33", TextBoxA33)
            TextDict.Add("TextBoxA34", TextBoxA34)
            TextDict.Add("TextBoxA35", TextBoxA35)
            TextDict.Add("TextBoxA36", TextBoxA36)
            TextDict.Add("TextBoxA41", TextBoxA41)
            TextDict.Add("TextBoxA42", TextBoxA42)
            TextDict.Add("TextBoxA43", TextBoxA43)
            TextDict.Add("TextBoxA44", TextBoxA44)
            TextDict.Add("TextBoxA45", TextBoxA45)
            TextDict.Add("TextBoxA46", TextBoxA46)
            TextDict.Add("TextBoxA51", TextBoxA51)
            TextDict.Add("TextBoxA52", TextBoxA52)
            TextDict.Add("TextBoxA53", TextBoxA53)
            TextDict.Add("TextBoxA54", TextBoxA54)
            TextDict.Add("TextBoxA55", TextBoxA55)
            TextDict.Add("TextBoxA56", TextBoxA56)
            TextDict.Add("TextBoxA61", TextBoxA61)
            TextDict.Add("TextBoxA62", TextBoxA62)
            TextDict.Add("TextBoxA63", TextBoxA63)
            TextDict.Add("TextBoxA64", TextBoxA64)
            TextDict.Add("TextBoxA65", TextBoxA65)
            TextDict.Add("TextBoxA66", TextBoxA66)
            TextDict.Add("TextBoxA71", TextBoxA71)
            TextDict.Add("TextBoxA72", TextBoxA72)
            TextDict.Add("TextBoxA73", TextBoxA73)
            TextDict.Add("TextBoxA74", TextBoxA74)
            TextDict.Add("TextBoxA75", TextBoxA75)
            TextDict.Add("TextBoxA76", TextBoxA76)
            TextDict.Add("TextBoxA81", TextBoxA81)
            TextDict.Add("TextBoxA82", TextBoxA82)
            TextDict.Add("TextBoxA83", TextBoxA83)
            TextDict.Add("TextBoxA84", TextBoxA84)
            TextDict.Add("TextBoxA85", TextBoxA85)
            TextDict.Add("TextBoxA86", TextBoxA86)
            ButtonDict.Add("ButtonM11", ButtonM11)
            ButtonDict.Add("ButtonM12", ButtonM12)
            ButtonDict.Add("ButtonM13", ButtonM13)
            ButtonDict.Add("ButtonM14", ButtonM14)
            ButtonDict.Add("ButtonM15", ButtonM15)
            ButtonDict.Add("ButtonM16", ButtonM16)
            ButtonDict.Add("ButtonM17", ButtonM17)
            ButtonDict.Add("ButtonM21", ButtonM21)
            ButtonDict.Add("ButtonM22", ButtonM22)
            ButtonDict.Add("ButtonM23", ButtonM23)
            ButtonDict.Add("ButtonM24", ButtonM24)
            ButtonDict.Add("ButtonM25", ButtonM25)
            ButtonDict.Add("ButtonM26", ButtonM26)
            ButtonDict.Add("ButtonM27", ButtonM27)
            ButtonDict.Add("ButtonM31", ButtonM31)
            ButtonDict.Add("ButtonM32", ButtonM32)
            ButtonDict.Add("ButtonM33", ButtonM33)
            ButtonDict.Add("ButtonM34", ButtonM34)
            ButtonDict.Add("ButtonM35", ButtonM35)
            ButtonDict.Add("ButtonM36", ButtonM36)
            ButtonDict.Add("ButtonM37", ButtonM37)
            ButtonDict.Add("ButtonM41", ButtonM41)
            ButtonDict.Add("ButtonM42", ButtonM42)
            ButtonDict.Add("ButtonM43", ButtonM43)
            ButtonDict.Add("ButtonM44", ButtonM44)
            ButtonDict.Add("ButtonM45", ButtonM45)
            ButtonDict.Add("ButtonM46", ButtonM46)
            ButtonDict.Add("ButtonM47", ButtonM47)
            ButtonDict.Add("ButtonM51", ButtonM51)
            ButtonDict.Add("ButtonM52", ButtonM52)
            ButtonDict.Add("ButtonM53", ButtonM53)
            ButtonDict.Add("ButtonM54", ButtonM54)
            ButtonDict.Add("ButtonM55", ButtonM55)
            ButtonDict.Add("ButtonM56", ButtonM56)
            ButtonDict.Add("ButtonM57", ButtonM57)
            ButtonDict.Add("ButtonM61", ButtonM61)
            ButtonDict.Add("ButtonM62", ButtonM62)
            ButtonDict.Add("ButtonM63", ButtonM63)
            ButtonDict.Add("ButtonM64", ButtonM64)
            ButtonDict.Add("ButtonM65", ButtonM65)
            ButtonDict.Add("ButtonM66", ButtonM66)
            ButtonDict.Add("ButtonM67", ButtonM67)
            ButtonDict.Add("ButtonM71", ButtonM71)
            ButtonDict.Add("ButtonM72", ButtonM72)
            ButtonDict.Add("ButtonM73", ButtonM73)
            ButtonDict.Add("ButtonM74", ButtonM74)
            ButtonDict.Add("ButtonM75", ButtonM75)
            ButtonDict.Add("ButtonM76", ButtonM76)
            ButtonDict.Add("ButtonM77", ButtonM77)
            ButtonDict.Add("ButtonM81", ButtonM81)
            ButtonDict.Add("ButtonM82", ButtonM82)
            ButtonDict.Add("ButtonM83", ButtonM83)
            ButtonDict.Add("ButtonM84", ButtonM84)
            ButtonDict.Add("ButtonM85", ButtonM85)
            ButtonDict.Add("ButtonM86", ButtonM86)
            ButtonDict.Add("ButtonM87", ButtonM87)
            ButtonDict.Add("ButtonA11", ButtonA11)
            ButtonDict.Add("ButtonA12", ButtonA12)
            ButtonDict.Add("ButtonA13", ButtonA13)
            ButtonDict.Add("ButtonA14", ButtonA14)
            ButtonDict.Add("ButtonA15", ButtonA15)
            ButtonDict.Add("ButtonA16", ButtonA16)
            ButtonDict.Add("ButtonA21", ButtonA21)
            ButtonDict.Add("ButtonA22", ButtonA22)
            ButtonDict.Add("ButtonA23", ButtonA23)
            ButtonDict.Add("ButtonA24", ButtonA24)
            ButtonDict.Add("ButtonA25", ButtonA25)
            ButtonDict.Add("ButtonA26", ButtonA26)
            ButtonDict.Add("ButtonA31", ButtonA31)
            ButtonDict.Add("ButtonA32", ButtonA32)
            ButtonDict.Add("ButtonA33", ButtonA33)
            ButtonDict.Add("ButtonA34", ButtonA34)
            ButtonDict.Add("ButtonA35", ButtonA35)
            ButtonDict.Add("ButtonA36", ButtonA36)
            ButtonDict.Add("ButtonA41", ButtonA41)
            ButtonDict.Add("ButtonA42", ButtonA42)
            ButtonDict.Add("ButtonA43", ButtonA43)
            ButtonDict.Add("ButtonA44", ButtonA44)
            ButtonDict.Add("ButtonA45", ButtonA45)
            ButtonDict.Add("ButtonA46", ButtonA46)
            ButtonDict.Add("ButtonA51", ButtonA51)
            ButtonDict.Add("ButtonA52", ButtonA52)
            ButtonDict.Add("ButtonA53", ButtonA53)
            ButtonDict.Add("ButtonA54", ButtonA54)
            ButtonDict.Add("ButtonA55", ButtonA55)
            ButtonDict.Add("ButtonA56", ButtonA56)
            ButtonDict.Add("ButtonA61", ButtonA61)
            ButtonDict.Add("ButtonA62", ButtonA62)
            ButtonDict.Add("ButtonA63", ButtonA63)
            ButtonDict.Add("ButtonA64", ButtonA64)
            ButtonDict.Add("ButtonA65", ButtonA65)
            ButtonDict.Add("ButtonA66", ButtonA66)
            ButtonDict.Add("ButtonA71", ButtonA71)
            ButtonDict.Add("ButtonA72", ButtonA72)
            ButtonDict.Add("ButtonA73", ButtonA73)
            ButtonDict.Add("ButtonA74", ButtonA74)
            ButtonDict.Add("ButtonA75", ButtonA75)
            ButtonDict.Add("ButtonA76", ButtonA76)
            ButtonDict.Add("ButtonA81", ButtonA81)
            ButtonDict.Add("ButtonA82", ButtonA82)
            ButtonDict.Add("ButtonA83", ButtonA83)
            ButtonDict.Add("ButtonA84", ButtonA84)
            ButtonDict.Add("ButtonA85", ButtonA85)
            ButtonDict.Add("ButtonA86", ButtonA86)
            ImageDict.Add("Imagebutton11", Imagebutton11)
            ImageDict.Add("Imagebutton12", Imagebutton12)
            ImageDict.Add("Imagebutton13", ImageButton13)
            ImageDict.Add("Imagebutton14", ImageButton14)
            ImageDict.Add("Imagebutton15", ImageButton15)
            ImageDict.Add("Imagebutton16", ImageButton16)
            ImageDict.Add("Imagebutton17", ImageButton17)
            ImageDict.Add("Imagebutton21", Imagebutton21)
            ImageDict.Add("Imagebutton22", Imagebutton22)
            ImageDict.Add("Imagebutton23", ImageButton23)
            ImageDict.Add("Imagebutton24", ImageButton24)
            ImageDict.Add("Imagebutton25", ImageButton25)
            ImageDict.Add("Imagebutton26", ImageButton26)
            ImageDict.Add("Imagebutton27", ImageButton27)
            ImageDict.Add("Imagebutton31", Imagebutton31)
            ImageDict.Add("Imagebutton32", Imagebutton32)
            ImageDict.Add("Imagebutton33", ImageButton33)
            ImageDict.Add("Imagebutton34", ImageButton34)
            ImageDict.Add("Imagebutton35", ImageButton35)
            ImageDict.Add("Imagebutton36", ImageButton36)
            ImageDict.Add("Imagebutton37", ImageButton37)
            ImageDict.Add("Imagebutton41", Imagebutton41)
            ImageDict.Add("Imagebutton42", Imagebutton42)
            ImageDict.Add("Imagebutton43", ImageButton43)
            ImageDict.Add("Imagebutton44", ImageButton44)
            ImageDict.Add("Imagebutton45", ImageButton45)
            ImageDict.Add("Imagebutton46", ImageButton46)
            ImageDict.Add("Imagebutton47", ImageButton47)
            ImageDict.Add("Imagebutton51", Imagebutton51)
            ImageDict.Add("Imagebutton52", Imagebutton52)
            ImageDict.Add("Imagebutton53", ImageButton53)
            ImageDict.Add("Imagebutton54", ImageButton54)
            ImageDict.Add("Imagebutton55", ImageButton55)
            ImageDict.Add("Imagebutton56", ImageButton56)
            ImageDict.Add("Imagebutton57", ImageButton57)
            ImageDict.Add("Imagebutton61", Imagebutton61)
            ImageDict.Add("Imagebutton62", Imagebutton62)
            ImageDict.Add("Imagebutton63", ImageButton63)
            ImageDict.Add("Imagebutton64", ImageButton64)
            ImageDict.Add("Imagebutton65", ImageButton65)
            ImageDict.Add("Imagebutton66", ImageButton66)
            ImageDict.Add("Imagebutton67", ImageButton67)
            ImageDict.Add("Imagebutton71", Imagebutton71)
            ImageDict.Add("Imagebutton72", Imagebutton72)
            ImageDict.Add("Imagebutton73", ImageButton73)
            ImageDict.Add("Imagebutton74", ImageButton74)
            ImageDict.Add("Imagebutton75", ImageButton75)
            ImageDict.Add("Imagebutton76", ImageButton76)
            ImageDict.Add("Imagebutton77", ImageButton77)
            ImageDict.Add("Imagebutton81", Imagebutton81)
            ImageDict.Add("Imagebutton82", Imagebutton82)
            ImageDict.Add("Imagebutton83", ImageButton83)
            ImageDict.Add("Imagebutton84", ImageButton84)
            ImageDict.Add("Imagebutton85", ImageButton85)
            ImageDict.Add("Imagebutton86", ImageButton86)
            ImageDict.Add("Imagebutton87", ImageButton87)
            ImageDict.Add("Imagebutton11a", Imagebutton11a)
            ImageDict.Add("Imagebutton12a", Imagebutton12a)
            ImageDict.Add("Imagebutton13a", ImageButton13a)
            ImageDict.Add("Imagebutton14a", ImageButton14a)
            ImageDict.Add("Imagebutton15a", ImageButton15a)
            ImageDict.Add("Imagebutton16a", ImageButton16a)
            ImageDict.Add("Imagebutton21a", Imagebutton21a)
            ImageDict.Add("Imagebutton22a", Imagebutton22a)
            ImageDict.Add("Imagebutton23a", ImageButton23a)
            ImageDict.Add("Imagebutton24a", ImageButton24a)
            ImageDict.Add("Imagebutton25a", ImageButton25a)
            ImageDict.Add("Imagebutton26a", ImageButton26a)
            ImageDict.Add("Imagebutton31a", Imagebutton31a)
            ImageDict.Add("Imagebutton32a", Imagebutton32a)
            ImageDict.Add("Imagebutton33a", ImageButton33a)
            ImageDict.Add("Imagebutton34a", ImageButton34a)
            ImageDict.Add("Imagebutton35a", ImageButton35a)
            ImageDict.Add("Imagebutton36a", ImageButton36a)
            ImageDict.Add("Imagebutton41a", Imagebutton41a)
            ImageDict.Add("Imagebutton42a", Imagebutton42a)
            ImageDict.Add("Imagebutton43a", ImageButton43a)
            ImageDict.Add("Imagebutton44a", ImageButton44a)
            ImageDict.Add("Imagebutton45a", ImageButton45a)
            ImageDict.Add("Imagebutton46a", ImageButton46a)
            ImageDict.Add("Imagebutton51a", Imagebutton51a)
            ImageDict.Add("Imagebutton52a", Imagebutton52a)
            ImageDict.Add("Imagebutton53a", ImageButton53a)
            ImageDict.Add("Imagebutton54a", ImageButton54a)
            ImageDict.Add("Imagebutton55a", ImageButton55a)
            ImageDict.Add("Imagebutton56a", ImageButton56a)
            ImageDict.Add("Imagebutton61a", Imagebutton61a)
            ImageDict.Add("Imagebutton62a", Imagebutton62a)
            ImageDict.Add("Imagebutton63a", ImageButton63a)
            ImageDict.Add("Imagebutton64a", ImageButton64a)
            ImageDict.Add("Imagebutton65a", ImageButton65a)
            ImageDict.Add("Imagebutton66a", ImageButton66a)
            ImageDict.Add("Imagebutton71a", Imagebutton71a)
            ImageDict.Add("Imagebutton72a", Imagebutton72a)
            ImageDict.Add("Imagebutton73a", ImageButton73a)
            ImageDict.Add("Imagebutton74a", ImageButton74a)
            ImageDict.Add("Imagebutton75a", ImageButton75a)
            ImageDict.Add("Imagebutton76a", ImageButton76a)
            ImageDict.Add("Imagebutton81a", Imagebutton81a)
            ImageDict.Add("Imagebutton82a", Imagebutton82a)
            ImageDict.Add("Imagebutton83a", ImageButton83a)
            ImageDict.Add("Imagebutton84a", ImageButton84a)
            ImageDict.Add("Imagebutton85a", ImageButton85a)
            ImageDict.Add("Imagebutton86a", ImageButton86a)
        Catch ex As Exception
        End Try
        Return
    End Sub

End Class
