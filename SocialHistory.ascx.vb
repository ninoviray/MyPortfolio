
Partial Class Controls_SocialHistory
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
            If hfTabPanelSocialHistory.Value = "False" Then
                If Not Request.QueryString("D") Is Nothing Then
                    hfUserId.Value = Request.QueryString("D").ToString
                    hfLanguage.Value = Request.QueryString("L").ToString
                    IsPanelControl()
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
            ddSmoking.Focus()
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
            'Smoking Settings
            If ddSmoking.SelectedValue = Nothing Then

            ElseIf ddSmoking.SelectedValue = 1 Then
                rfvSmokingCurrently.Enabled = True
                ddSmokingCurrently.Enabled = True
                rfvSmokingHowManyYears.Enabled = True
                rvSmokingHowManyYears.Enabled = True
                txtSmokingHowManyYears.Enabled = True
                rfvSmokingFrequency.Enabled = True
                ddSmokingFrequency.Enabled = True
                cbSmokingCigarettes.Enabled = True
                cbSmokingECigarettes.Enabled = True
                cbSmokingCigars.Enabled = True
                cbSmokingPipeHookah.Enabled = True
                cbSmokingVapes.Enabled = True
            Else
                rfvSmokingCurrently.Enabled = False
                ddSmokingCurrently.Enabled = False
                rfvSmokingHowManyYears.Enabled = False
                rvSmokingHowManyYears.Enabled = False
                txtSmokingHowManyYears.Enabled = False
                rfvSmokingFrequency.Enabled = False
                ddSmokingFrequency.Enabled = False
                cbSmokingCigarettes.Enabled = False
                cbSmokingECigarettes.Enabled = False
                cbSmokingCigars.Enabled = False
                cbSmokingPipeHookah.Enabled = False
                cbSmokingVapes.Enabled = False
            End If

            If ddSmokingCurrently.SelectedValue = Nothing Then

            ElseIf ddSmokingCurrently.SelectedValue = 1 Then
                rfvSmokingQuit.Enabled = True
                ddSmokingQuit.Enabled = True
            Else
                rfvSmokingQuit.Enabled = False
                ddSmokingQuit.Enabled = False
            End If

            'Drinking Settings
            If ddDrinking.SelectedValue = Nothing Then

            ElseIf ddDrinking.SelectedValue = 1 Then
                rfvDrinkingCurrently.Enabled = True
                ddDrinkingCurrently.Enabled = True
                rfvDrinkingFrequency.Enabled = True
                ddDrinkingFrequency.Enabled = True
                rfvDrinkingAlcoholAbuse.Enabled = True
                ddDrinkingAlcoholAbuse.Enabled = True
            Else
                rfvDrinkingCurrently.Enabled = False
                ddDrinkingCurrently.Enabled = False
                rfvDrinkingFrequency.Enabled = False
                ddDrinkingFrequency.Enabled = False
                rfvDrinkingAlcoholAbuse.Enabled = False
                ddDrinkingAlcoholAbuse.Enabled = False
            End If

            If ddDrinkingCurrently.SelectedValue = Nothing Then

            ElseIf ddDrinkingCurrently.SelectedValue = 1 Then
                rfvDrinkingQuit.Enabled = True
                ddDrinkingQuit.Enabled = True
            Else
                rfvDrinkingQuit.Enabled = False
                ddDrinkingQuit.Enabled = False
            End If

            'Prescription Drugs Settings
            If ddDrugPrescription.SelectedValue = Nothing Then

            ElseIf ddDrugPrescription.SelectedValue = 1 Then
                rfvDrugPrescriptionCurrently.Enabled = True
                ddDrugPrescriptionCurrently.Enabled = True
            Else
                rfvDrugPrescriptionCurrently.Enabled = False
                ddDrugPrescriptionCurrently.Enabled = False
            End If

            If ddDrugPrescriptionCurrently.SelectedValue = Nothing Then

            ElseIf ddDrugPrescriptionCurrently.SelectedValue = 1 Then
                rfvDrugPrescriptionQuit.Enabled = True
                ddDrugPrescriptionQuit.Enabled = True
            Else
                rfvDrugPrescriptionQuit.Enabled = False
                ddDrugPrescriptionQuit.Enabled = False
            End If

            'Recreational Drugs Settings
            If ddDrugRecreational.SelectedValue = Nothing Then

            ElseIf ddDrugRecreational.SelectedValue = 1 Then
                rfvDrugRecreationalCurrently.Enabled = True
                ddDrugRecreationalCurrently.Enabled = True
                cbDrugRecreationalMarijuana.Enabled = True
                cbDrugRecreationalSyntheticMarijuana.Enabled = True
                cbDrugRecreationalCocaine.Enabled = True
                cbDrugRecreationalCrackCocaine.Enabled = True
                cbDrugRecreationalHeroin.Enabled = True
                cbDrugRecreationalMethamphetamines.Enabled = True
                cbDrugRecreationalCrystalMeth.Enabled = True
                cbDrugRecreationalEcstasy.Enabled = True
                cbDrugRecreationalLysergicAcidDiethylamide.Enabled = True
            Else
                rfvDrugRecreationalCurrently.Enabled = False
                ddDrugRecreationalCurrently.Enabled = False
                cbDrugRecreationalMarijuana.Enabled = False
                cbDrugRecreationalSyntheticMarijuana.Enabled = False
                cbDrugRecreationalCocaine.Enabled = False
                cbDrugRecreationalCrackCocaine.Enabled = False
                cbDrugRecreationalHeroin.Enabled = False
                cbDrugRecreationalMethamphetamines.Enabled = False
                cbDrugRecreationalCrystalMeth.Enabled = False
                cbDrugRecreationalEcstasy.Enabled = False
                cbDrugRecreationalLysergicAcidDiethylamide.Enabled = False
            End If

            If ddDrugRecreationalCurrently.SelectedValue = Nothing Then

            ElseIf ddDrugRecreationalCurrently.SelectedValue = 1 Then
                rfvDrugRecreationalQuit.Enabled = True
                ddDrugRecreationalQuit.Enabled = True
            Else
                rfvDrugRecreationalQuit.Enabled = False
                ddDrugRecreationalQuit.Enabled = False
            End If

            'Drug Use Other
            If ddDrugUseOther.SelectedValue = Nothing Then

            ElseIf ddDrugUseOther.SelectedValue >= 1 Then
                txtDrugUseOtherComments.Enabled = True
            Else
                txtDrugUseOtherComments.Enabled = False
            End If
        End If

    End Sub

    'Set the Language Text, Populate TextBoxs, and Labels
    Private Sub IsPanelControl()

        hfTabPanelSocialHistory.Value = "True"

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
            Dim MySH = (From M In TPDDCReadI.lkpSocialHistoryReferrals Select M.SocialHistoryReferral).ToArray

            For Each MyField As String In MySH
                Dim SHRefLang As New List(Of String)

                Dim MyLabelText As String = Nothing
                Dim MyTextBoxText As String = Nothing
                Dim MyCheckBoxText As String = Nothing
                Dim MyDropDownListText As String = Nothing
                Dim MyRequiredFieldValidatorText As String = Nothing
                Dim MyRangeValidatorText As String = Nothing
                Dim MyRegularExpressionValidatorText As String = Nothing

                Dim MyCkField As String = Trim(MyField.ToString)
                MyLabelText = "lb" & MyCkField & "Text"
                MyTextBoxText = "txt" & MyCkField
                MyCheckBoxText = "cb" & MyCkField
                MyDropDownListText = "dd" & MyCkField
                MyRequiredFieldValidatorText = "rfv" & MyCkField
                MyRangeValidatorText = "rv" & MyCkField
                MyRegularExpressionValidatorText = "rev" & MyCkField

                Dim TPDDCReadII As New MyPortfolioDbDataContext
                Dim SH = From s In TPDDCReadII.lkpSocialHistoryReferrals
                         Where s.SocialHistoryReferral.ToString().Equals(MyCkField)
                         Select s

                Select Case hfLanguage.Value

                    Case "Eng"
                        Dim SHLE = (From sheng In SH Select sheng.SocialHistoryReferralEnglish).ToList
                        SHRefLang = SHLE
                    Case "Spa"
                        Dim SHLS = (From shspa In SH Select shspa.SocialHistoryReferralSpanish).ToList
                        SHRefLang = SHLS
                    Case "Man"
                        Dim SHLM = (From shman In SH Select shman.SocialHistoryReferralMandarin).ToList
                        SHRefLang = SHLM
                    Case "Ara"
                        Dim SHLA = (From shara In SH Select shara.SocialHistoryReferralArabic).ToList
                        SHRefLang = SHLA
                    Case "Hin"
                        Dim SHLH = (From shhin In SH Select shhin.SocialHistoryReferralHindiUrdu).ToList
                        SHRefLang = SHLH
                    Case "Ben"
                        Dim SHLB = (From shben In SH Select shben.SocialHistoryReferralBengali).ToList
                        SHRefLang = SHLB
                    Case "Por"
                        Dim SHLP = (From shpor In SH Select shpor.SocialHistoryReferralPortuguese).ToList
                        SHRefLang = SHLP
                    Case "Rus"
                        Dim SHLR = (From shrus In SH Select shrus.SocialHistoryReferralRussian).ToList
                        SHRefLang = SHLR
                    Case "Jap"
                        Dim SHLJ = (From shjap In SH Select shjap.SocialHistoryReferralJapanese).ToList
                        SHRefLang = SHLJ
                    Case "Pun"
                        Dim SHLPU = (From shpun In SH Select shpun.SocialHistoryReferralPunjabi).ToList
                        SHRefLang = SHLPU
                    Case Else
                        Dim SHLEN = (From sheng In SH Select sheng.SocialHistoryReferralEnglish).ToList
                        SHRefLang = SHLEN
                End Select

                For Each innerCtrl As Control In PanelSocialHistory.Controls
                    If TypeOf innerCtrl Is Label Then
                        If CType(innerCtrl, Label).ID = MyLabelText Then
                            CType(innerCtrl, Label).Text = SHRefLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerCtrl Is CheckBox Then
                        If CType(innerCtrl, CheckBox).ID = MyCheckBoxText Then
                            CType(innerCtrl, CheckBox).Text = SHRefLang.FirstOrDefault.ToString
                            CType(innerCtrl, CheckBox).ToolTip = hfPleaseEnter.Value & SHRefLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerCtrl Is TextBox Then
                        If CType(innerCtrl, TextBox).ID = MyTextBoxText Then
                            CType(innerCtrl, TextBox).ToolTip = hfPleaseEnter.Value & SHRefLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerCtrl Is DropDownList Then
                        If CType(innerCtrl, DropDownList).ID = MyDropDownListText Then
                            CType(innerCtrl, DropDownList).ToolTip = hfPleaseEnter.Value & SHRefLang.FirstOrDefault.ToString & "."
                            Select Case MyCkField

                                Case "Smoking"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorSmoking
                                    CType(innerCtrl, DropDownList).DataTextField = "Smoking" & hfLanguageText.Value
                                    LinqDonorSmoking.OrderBy = "Id"
                                Case "SmokingCurrently"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorSmokingCurrently
                                    CType(innerCtrl, DropDownList).DataTextField = "SmokingCurrently" & hfLanguageText.Value
                                    LinqDonorSmokingCurrently.OrderBy = "Id"
                                Case "SmokingFrequency"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorSmokingFrequency
                                    CType(innerCtrl, DropDownList).DataTextField = "SmokingFrequency" & hfLanguageText.Value
                                    LinqDonorSmokingFrequency.OrderBy = "Id"
                                Case "SmokingQuit"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorSmokingQuit
                                    CType(innerCtrl, DropDownList).DataTextField = "SmokingQuit" & hfLanguageText.Value
                                    LinqDonorSmokingQuit.OrderBy = "Id"
                                Case "Drinking"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrinking
                                    CType(innerCtrl, DropDownList).DataTextField = "Drinking" & hfLanguageText.Value
                                    LinqDonorDrinking.OrderBy = "Id"
                                Case "DrinkingCurrently"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrinkingCurrently
                                    CType(innerCtrl, DropDownList).DataTextField = "DrinkingCurrently" & hfLanguageText.Value
                                    LinqDonorDrinkingCurrently.OrderBy = "Id"
                                Case "DrinkingFrequency"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrinkingFrequency
                                    CType(innerCtrl, DropDownList).DataTextField = "DrinkingFrequency" & hfLanguageText.Value
                                    LinqDonorDrinkingFrequency.OrderBy = "Id"
                                Case "DrinkingAlcoholAbuse"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrinkingAlcoholAbuse
                                    CType(innerCtrl, DropDownList).DataTextField = "DrinkingAlcoholAbuse" & hfLanguageText.Value
                                    LinqDonorDrinkingAlcoholAbuse.OrderBy = "Id"
                                Case "DrinkingQuit"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrinkingQuit
                                    CType(innerCtrl, DropDownList).DataTextField = "DrinkingQuit" & hfLanguageText.Value
                                    LinqDonorDrinkingQuit.OrderBy = "Id"
                                Case "DrugPrescription"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrugPrescription
                                    CType(innerCtrl, DropDownList).DataTextField = "DrugPrescription" & hfLanguageText.Value
                                    LinqDonorDrugPrescription.OrderBy = "Id"
                                Case "DrugPrescriptionCurrently"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrugPrescriptionCurrently
                                    CType(innerCtrl, DropDownList).DataTextField = "DrugPrescriptionCurrently" & hfLanguageText.Value
                                    LinqDonorDrugPrescriptionCurrently.OrderBy = "Id"
                                Case "DrugPrescriptionQuit"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrugPrescriptionQuit
                                    CType(innerCtrl, DropDownList).DataTextField = "DrugPrescriptionQuit" & hfLanguageText.Value
                                    LinqDonorDrugPrescriptionQuit.OrderBy = "Id"
                                Case "DrugRecreational"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrugRecreational
                                    CType(innerCtrl, DropDownList).DataTextField = "DrugRecreational" & hfLanguageText.Value
                                    LinqDonorDrugRecreational.OrderBy = "Id"
                                Case "DrugRecreationalCurrently"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrugRecreationalCurrently
                                    CType(innerCtrl, DropDownList).DataTextField = "DrugRecreationalCurrently" & hfLanguageText.Value
                                    LinqDonorDrugRecreationalCurrently.OrderBy = "Id"
                                Case "DrugRecreationalQuit"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrugRecreationalQuit
                                    CType(innerCtrl, DropDownList).DataTextField = "DrugRecreationalQuit" & hfLanguageText.Value
                                    LinqDonorDrugRecreationalQuit.OrderBy = "Id"
                                Case "DrugUseOther"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorDrugUseOther
                                    CType(innerCtrl, DropDownList).DataTextField = "DrugUseOther" & hfLanguageText.Value
                                    LinqDonorDrugUseOther.OrderBy = "Id"
                                Case Else

                            End Select
                            CType(innerCtrl, DropDownList).DataValueField = "Id"
                            CType(innerCtrl, DropDownList).DataBind()
                        End If
                    End If
                    If TypeOf innerCtrl Is RequiredFieldValidator Then
                        If CType(innerCtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerCtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & SHRefLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                    If TypeOf innerCtrl Is RangeValidator Then
                        If CType(innerCtrl, RangeValidator).ID = MyRangeValidatorText Then
                            CType(innerCtrl, RangeValidator).ErrorMessage = SHRefLang.FirstOrDefault.ToString & hfIsInvalid.Value
                        End If
                    End If
                    If TypeOf innerCtrl Is RegularExpressionValidator Then
                        If CType(innerCtrl, RegularExpressionValidator).ID = MyRegularExpressionValidatorText Then
                            CType(innerCtrl, RegularExpressionValidator).ErrorMessage = SHRefLang.FirstOrDefault.ToString & hfIsInvalid.Value
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

            HR.Smoking = ddSmoking.SelectedValue
            HR.SmokingCigarettes = cbSmokingCigarettes.Checked
            HR.SmokingECigarettes = cbSmokingECigarettes.Checked
            HR.SmokingCigars = cbSmokingCigars.Checked
            HR.SmokingPipeHookah = cbSmokingPipeHookah.Checked
            HR.SmokingVapes = cbSmokingVapes.Checked
            HR.SmokingCurrently = ddSmokingCurrently.SelectedValue
            HR.SmokingHowManyYears = Trim(txtSmokingHowManyYears.Text)
            HR.SmokingFrequency = ddSmokingFrequency.SelectedValue
            HR.SmokingQuit = ddSmokingQuit.SelectedValue
            HR.Drinking = ddDrinking.SelectedValue
            HR.DrinkingCurrently = ddSmokingCurrently.SelectedValue
            HR.DrinkingFrequency = ddDrinkingFrequency.SelectedValue
            HR.DrinkingAlcoholAbuse = ddDrinkingAlcoholAbuse.SelectedValue
            HR.DrinkingQuit = ddDrinkingQuit.SelectedValue
            HR.DrugPrescription = ddDrugPrescription.SelectedValue
            HR.DrugPrescriptionCurrently = ddDrugPrescriptionCurrently.SelectedValue
            HR.DrugPrescriptionQuit = ddDrugPrescriptionQuit.SelectedValue
            HR.DrugRecreational = ddDrugRecreational.SelectedValue
            HR.DrugRecreationalMarijuana = cbDrugRecreationalMarijuana.Checked
            HR.DrugRecreationalSyntheticMarijuana = cbDrugRecreationalSyntheticMarijuana.Checked
            HR.DrugRecreationalCocaine = cbDrugRecreationalCocaine.Checked
            HR.DrugRecreationalCrackCocaine = cbDrugRecreationalCrackCocaine.Checked
            HR.DrugRecreationalHeroin = cbDrugRecreationalHeroin.Checked
            HR.DrugRecreationalMethamphetamines = cbDrugRecreationalMethamphetamines.Checked
            HR.DrugRecreationalCrystalMeth = cbDrugRecreationalCrystalMeth.Checked
            HR.DrugRecreationalEcstasy = cbDrugRecreationalEcstasy.Checked
            HR.DrugRecreationalLysergicAcidDiethylamide = cbDrugRecreationalLysergicAcidDiethylamide.Checked
            HR.DrugRecreationalCurrently = ddDrugRecreationalCurrently.SelectedValue
            HR.DrugRecreationalQuit = ddDrugRecreationalQuit.SelectedValue
            HR.DrugUseOther = ddDrugUseOther.SelectedValue
            HR.DrugUseOtherComments = Trim(txtDrugUseOtherComments.Text)
            HR.ModifyBy = Trim(CkUserName)
            HR.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

        Try
            Dim MyManager = New UserManager()
            MyManager.AddToRole(hfUserId.Value, "Social History")
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

            UHR.Smoking = ddSmoking.SelectedValue
            UHR.SmokingCigarettes = cbSmokingCigarettes.Checked
            UHR.SmokingECigarettes = cbSmokingECigarettes.Checked
            UHR.SmokingCigars = cbSmokingCigars.Checked
            UHR.SmokingPipeHookah = cbSmokingPipeHookah.Checked
            UHR.SmokingVapes = cbSmokingVapes.Checked
            UHR.SmokingCurrently = ddSmokingCurrently.SelectedValue
            UHR.SmokingHowManyYears = Trim(txtSmokingHowManyYears.Text)
            UHR.SmokingFrequency = ddSmokingFrequency.SelectedValue
            UHR.SmokingQuit = ddSmokingQuit.SelectedValue
            UHR.Drinking = ddDrinking.SelectedValue
            UHR.DrinkingCurrently = ddSmokingCurrently.SelectedValue
            UHR.DrinkingFrequency = ddDrinkingFrequency.SelectedValue
            UHR.DrinkingAlcoholAbuse = ddDrinkingAlcoholAbuse.SelectedValue
            UHR.DrinkingQuit = ddDrinkingQuit.SelectedValue
            UHR.DrugPrescription = ddDrugPrescription.SelectedValue
            UHR.DrugPrescriptionCurrently = ddDrugPrescriptionCurrently.SelectedValue
            UHR.DrugPrescriptionQuit = ddDrugPrescriptionQuit.SelectedValue
            UHR.DrugRecreational = ddDrugRecreational.SelectedValue
            UHR.DrugRecreationalMarijuana = cbDrugRecreationalMarijuana.Checked
            UHR.DrugRecreationalSyntheticMarijuana = cbDrugRecreationalSyntheticMarijuana.Checked
            UHR.DrugRecreationalCocaine = cbDrugRecreationalCocaine.Checked
            UHR.DrugRecreationalCrackCocaine = cbDrugRecreationalCrackCocaine.Checked
            UHR.DrugRecreationalHeroin = cbDrugRecreationalHeroin.Checked
            UHR.DrugRecreationalMethamphetamines = cbDrugRecreationalMethamphetamines.Checked
            UHR.DrugRecreationalCrystalMeth = cbDrugRecreationalCrystalMeth.Checked
            UHR.DrugRecreationalEcstasy = cbDrugRecreationalEcstasy.Checked
            UHR.DrugRecreationalLysergicAcidDiethylamide = cbDrugRecreationalLysergicAcidDiethylamide.Checked
            UHR.DrugRecreationalCurrently = ddDrugRecreationalCurrently.SelectedValue
            UHR.DrugRecreationalQuit = ddDrugRecreationalQuit.SelectedValue
            UHR.DrugUseOther = ddDrugUseOther.SelectedValue
            UHR.DrugUseOtherComments = Trim(txtDrugUseOtherComments.Text)
            UHR.ModifyBy = Trim(CkUserName)
            UHR.ModifyDate = Now.ToString("G")

            TPDDCUpdateII.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
