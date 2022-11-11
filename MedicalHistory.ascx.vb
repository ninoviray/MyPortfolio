
Partial Class Controls_MedicalHistory
    Inherits UserControl

    Private MyPID As String = Nothing
    Private MyNewDonor As String = Nothing
    Private MyUpdateDonor As String = Nothing

    Public Property FindPID() As String

        Get
            Return MyPID
        End Get

        Set(ByVal Value As String)
            hfPID.Value = Value
            If hfTabPanelMedicalHistory.Value = "False" Then
                If Not Request.QueryString("D") Is Nothing Then
                    hfUserId.Value = Request.QueryString("D").ToString
                    hfLanguage.Value = Request.QueryString("L").ToString
                    IsPanelControl()
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
            ddDiabetes.Focus()
        End Set

    End Property

    'Insert New Donor Info
    Public Property FindNewDonor() As String

        Get
            Return MyNewDonor
        End Get

        Set(ByVal Value As String)
            MyNewDonor = Value
            IsNewDonor(MyNewDonor)
        End Set

    End Property

    'Update Donor Info when moving Back or Forward
    Public Property FindUpdateDonor() As String

        Get
            Return MyUpdateDonor
        End Get

        Set(ByVal Value As String)
            MyUpdateDonor = Value
            IsUpdateDonor(MyUpdateDonor)
        End Set

    End Property

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'Put Attributes and Date Range Validator Here!!!


        Else
            If ddDiabetes.SelectedValue = Nothing Then

            ElseIf ddDiabetes.SelectedValue = 1 Then
                ddDiabetesInsulin.Enabled = True
                rfvDiabetesInsulin.Enabled = True
                ddDiabetesOralMedication.Enabled = True
                rfvDiabetesOralMedication.Enabled = True
            Else
                ddDiabetesInsulin.Enabled = False
                rfvDiabetesInsulin.Enabled = False
                ddDiabetesOralMedication.Enabled = False
                rfvDiabetesOralMedication.Enabled = False
            End If

            If ddHeartProblems.SelectedValue = Nothing Then

            ElseIf ddHeartProblems.SelectedValue = 1 Then
                txtHeartProblemsDescription.Enabled = True
            Else
                txtHeartProblemsDescription.Enabled = False
            End If

            If ddKidneyStones.SelectedValue = Nothing Then

            ElseIf ddKidneyStones.SelectedValue = 1 Then
                ddKidneyStonesAmount.Enabled = True
                rfvKidneyStonesAmount.Enabled = True
            Else
                ddKidneyStonesAmount.Enabled = False
                rfvKidneyStonesAmount.Enabled = False
            End If

            If ddCancerMelanoma.SelectedValue = Nothing Or ddCancerNonMelanoma.SelectedValue = Nothing Then

            ElseIf ddCancerMelanoma.SelectedValue = 1 Or ddCancerNonMelanoma.SelectedValue = 1 Then
                txtCancerDescription.Enabled = True
            Else
                txtCancerDescription.Enabled = False
            End If

        End If

    End Sub

    'Set the Language Text, Populate TextBoxs, and Labels
    Private Sub IsPanelControl()

        hfTabPanelMedicalHistory.Value = "True"

        Dim MyAllHiddenItems As String = Nothing
        Dim MyAllHiddenItem As String() = Nothing
        Dim MyLanguageText As New LanguageText
        MyAllHiddenItems = MyLanguageText.CkLanguage(hfLanguage.Value)
        MyAllHiddenItem = MyAllHiddenItems.Split("||")
        hfLanguageText.Value = MyAllHiddenItem(0)
        hfPleaseEnter.Value = MyAllHiddenItem(2)
        hfIsInvalid.Value = MyAllHiddenItem(4)

        Try
            Dim TPDDCReadI As New MyPortfolioDbDataContext
            Dim MyMH = (From M In TPDDCReadI.lkpMedicalHistoryReferrals Select M.MedicalHistoryReferral).ToArray

            For Each MyField As String In MyMH
                Dim MHRefLang As New List(Of String)

                Dim MyLabelText As String = Nothing
                Dim MyTextBoxText As String = Nothing
                Dim MyDropDownListText As String = Nothing
                Dim MyRequiredFieldValidatorText As String = Nothing
                Dim MyRegularExpressionValidatorText As String = Nothing

                Dim MyCkField As String = Trim(MyField.ToString)
                MyLabelText = "lb" & MyCkField & "Text"
                MyTextBoxText = "txt" & MyCkField
                MyDropDownListText = "dd" & MyCkField
                MyRequiredFieldValidatorText = "rfv" & MyCkField
                MyRegularExpressionValidatorText = "rev" & MyCkField

                Dim TPDDCReadII As New MyPortfolioDbDataContext
                Dim MH = From h In TPDDCReadII.lkpMedicalHistoryReferrals
                         Where h.MedicalHistoryReferral.ToString().Equals(MyCkField)
                         Select h

                Select Case hfLanguage.Value

                    Case "Eng"
                        Dim MHLE = (From mheng In MH Select mheng.MedicalHistoryReferralEnglish).ToList
                        MHRefLang = MHLE
                    Case "Spa"
                        Dim MHLS = (From mhspa In MH Select mhspa.MedicalHistoryReferralSpanish).ToList
                        MHRefLang = MHLS
                    Case "Man"
                        Dim MHLM = (From mhman In MH Select mhman.MedicalHistoryReferralMandarin).ToList
                        MHRefLang = MHLM
                    Case "Ara"
                        Dim MHLA = (From mhara In MH Select mhara.MedicalHistoryReferralArabic).ToList
                        MHRefLang = MHLA
                    Case "Hin"
                        Dim MHLH = (From mhhin In MH Select mhhin.MedicalHistoryReferralHindiUrdu).ToList
                        MHRefLang = MHLH
                    Case "Ben"
                        Dim MHLB = (From mhben In MH Select mhben.MedicalHistoryReferralBengali).ToList
                        MHRefLang = MHLB
                    Case "Por"
                        Dim MHLP = (From mhpor In MH Select mhpor.MedicalHistoryReferralPortuguese).ToList
                        MHRefLang = MHLP
                    Case "Rus"
                        Dim MHLR = (From mhrus In MH Select mhrus.MedicalHistoryReferralRussian).ToList
                        MHRefLang = MHLR
                    Case "Jap"
                        Dim MHLJ = (From mhjap In MH Select mhjap.MedicalHistoryReferralJapanese).ToList
                        MHRefLang = MHLJ
                    Case "Pun"
                        Dim MHLPU = (From mhpun In MH Select mhpun.MedicalHistoryReferralPunjabi).ToList
                        MHRefLang = MHLPU
                    Case Else
                        Dim MHLEN = (From mheng In MH Select mheng.MedicalHistoryReferralEnglish).ToList
                        MHRefLang = MHLEN
                End Select

                For Each innerCtrl As Control In PanelMedicalHistory.Controls
                    If TypeOf innerCtrl Is Label Then
                        If CType(innerCtrl, Label).ID = MyLabelText Then
                            CType(innerCtrl, Label).Text = MHRefLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerCtrl Is TextBox Then
                        If CType(innerCtrl, TextBox).ID = MyTextBoxText Then
                            CType(innerCtrl, TextBox).ToolTip = hfPleaseEnter.Value & MHRefLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerCtrl Is DropDownList Then
                        If CType(innerCtrl, DropDownList).ID = MyDropDownListText Then
                            CType(innerCtrl, DropDownList).ToolTip = hfPleaseEnter.Value & MHRefLang.FirstOrDefault.ToString & "."
                            Select Case MyCkField

                                Case "Diabetes"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDiabetes
                                    CType(innerCtrl, DropDownList).DataTextField = "Diabetes" & hfLanguageText.Value
                                    LinqDonorDiabetes.OrderBy = "Id"
                                Case "DiabetesInsulin"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDiabetesInsulin
                                    CType(innerCtrl, DropDownList).DataTextField = "DiabetesInsulin" & hfLanguageText.Value
                                    LinqDonorDiabetesInsulin.OrderBy = "Id"
                                Case "DiabetesOralMedication"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDiabetesOralMedication
                                    CType(innerCtrl, DropDownList).DataTextField = "DiabetesOralMedication" & hfLanguageText.Value
                                    LinqDonorDiabetesOralMedication.OrderBy = "Id"
                                Case "HeartProblems"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorHeartProblems
                                    CType(innerCtrl, DropDownList).DataTextField = "HeartProblems" & hfLanguageText.Value
                                    LinqDonorHeartProblems.OrderBy = "Id"
                                Case "KidneyStones"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorKidneyStones
                                    CType(innerCtrl, DropDownList).DataTextField = "kidneyStones" & hfLanguageText.Value
                                    LinqDonorKidneyStones.OrderBy = "Id"
                                Case "KidneyStonesAmount"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorKidneyStonesAmount
                                    CType(innerCtrl, DropDownList).DataTextField = "KidneyStonesAmount" & hfLanguageText.Value
                                    LinqDonorKidneyStonesAmount.OrderBy = "Id"
                                Case "CancerMelanoma"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorCancerMelanoma
                                    CType(innerCtrl, DropDownList).DataTextField = "CancerMelanoma" & hfLanguageText.Value
                                    LinqDonorCancerMelanoma.OrderBy = "Id"
                                Case "CancerNonMelanoma"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorCancerNonMelanoma
                                    CType(innerCtrl, DropDownList).DataTextField = "CancerNonMelanoma" & hfLanguageText.Value
                                    LinqDonorCancerNonMelanoma.OrderBy = "Id"
                                Case "PastSurgeries"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorPastSurgeries
                                    CType(innerCtrl, DropDownList).DataTextField = "PastSurgeries" & hfLanguageText.Value
                                    LinqDonorPastSurgeries.OrderBy = "Id"
                                Case Else

                            End Select
                            CType(innerCtrl, DropDownList).DataValueField = "Id"
                            CType(innerCtrl, DropDownList).DataBind()
                        End If
                    End If
                    If TypeOf innerCtrl Is RequiredFieldValidator Then
                        If CType(innerCtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerCtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & MHRefLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                    If TypeOf innerCtrl Is RegularExpressionValidator Then
                        If CType(innerCtrl, RegularExpressionValidator).ID = MyRegularExpressionValidatorText Then
                            CType(innerCtrl, RegularExpressionValidator).ErrorMessage = MHRefLang.FirstOrDefault.ToString & hfIsInvalid.Value
                        End If
                    End If
                Next innerCtrl
            Next MyField
        Catch ex As Exception

        End Try

    End Sub

    'Insert New Donor Record
    Private Function IsNewDonor(ByVal CkUserName As String) As String

        'tblHistoryReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim HR = (From p In TPDDCUpdateI.tblHistoryReferrals
                      Where p.pid.Equals(hfPID.Value)).ToList(0)

            HR.Diabetes = ddDiabetes.SelectedValue
            HR.DiabetesInsulin = ddDiabetesInsulin.SelectedValue
            HR.DiabetesOralMedication = ddDiabetesOralMedication.SelectedValue
            HR.HeartProblems = ddHeartProblems.SelectedValue
            If txtHeartProblemsDescription.Text = Nothing Then
                HR.HeartProblemsDescription = Nothing
            Else
                HR.HeartProblemsDescription = Trim(txtHeartProblemsDescription.Text)
            End If
            HR.KidneyStones = ddKidneyStones.SelectedValue
            HR.KidneyStonesAmount = ddKidneyStonesAmount.SelectedValue
            HR.CancerMelanoma = ddCancerMelanoma.SelectedValue
            HR.CancerNonMelanoma = ddCancerNonMelanoma.SelectedValue
            If txtCancerDescription.Text = Nothing Then
                HR.CancerDescription = Nothing
            Else
                HR.CancerDescription = Trim(txtCancerDescription.Text)
            End If
            HR.PastSurgeries = ddPastSurgeries.SelectedValue
            If txtCurrentMedication.Text = Nothing Then
                HR.Medications = Nothing
            Else
                HR.Medications = Trim(txtCurrentMedication.Text)
            End If
            HR.ModifyBy = Trim(CkUserName)
            HR.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

        Try
            Dim MyManager = New UserManager()
            MyManager.AddToRole(hfUserId.Value, "Medical History")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Update Previous Donor Record
    Private Function IsUpdateDonor(ByVal CkUserName As String) As String

        'tblHistoryReferral
        Try
            Dim TPDDCUpdateII As New MyPortfolioDbDataContext
            Dim UHR = (From p In TPDDCUpdateII.tblHistoryReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UHR.Diabetes = ddDiabetes.SelectedValue
            UHR.DiabetesInsulin = ddDiabetesInsulin.SelectedValue
            UHR.DiabetesOralMedication = ddDiabetesOralMedication.SelectedValue
            UHR.HeartProblems = ddHeartProblems.SelectedValue
            If txtHeartProblemsDescription.Text = Nothing Then
                UHR.HeartProblemsDescription = Nothing
            Else
                UHR.HeartProblemsDescription = Trim(txtHeartProblemsDescription.Text)
            End If
            UHR.KidneyStones = ddKidneyStones.SelectedValue
            UHR.KidneyStonesAmount = ddKidneyStonesAmount.SelectedValue
            UHR.CancerMelanoma = ddCancerMelanoma.SelectedValue
            UHR.CancerNonMelanoma = ddCancerNonMelanoma.SelectedValue
            If txtCancerDescription.Text = Nothing Then
                UHR.CancerDescription = Nothing
            Else
                UHR.CancerDescription = Trim(txtCancerDescription.Text)
            End If
            UHR.PastSurgeries = ddPastSurgeries.SelectedValue
            If txtCurrentMedication.Text = Nothing Then
                UHR.Medications = Nothing
            Else
                UHR.Medications = Trim(txtCurrentMedication.Text)
            End If
            UHR.ModifyBy = Trim(CkUserName)
            UHR.ModifyDate = Now.ToString("G")

            TPDDCUpdateII.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
