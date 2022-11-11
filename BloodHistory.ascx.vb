
Partial Class Controls_BloodHistory
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
            If hfTabPanelBloodHistory.Value = "False" Then
                If Not Request.QueryString("D") Is Nothing Then
                    hfUserId.Value = Request.QueryString("D").ToString
                    hfLanguage.Value = Request.QueryString("L").ToString
                    IsPanelControl()
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
            ddBloodType.Focus()
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
            If ddBloodType.SelectedValue = Nothing Then

            ElseIf ddBloodType.SelectedValue < 9 Then
                ddBloodRHFactor.Enabled = True
                rfvBloodRHFactor.Enabled = True
            Else
                ddBloodRHFactor.Enabled = False
                rfvBloodRHFactor.Enabled = False
            End If

            If ddHighBloodPressure.SelectedValue = Nothing Then

            ElseIf ddHighBloodPressure.SelectedValue = 1 Then
                ddHighBloodPressureMedication.Enabled = True
                rfvHighBloodPressureMedication.Enabled = True
            Else
                ddHighBloodPressureMedication.Enabled = False
                rfvHighBloodPressureMedication.Enabled = False
            End If

            If ddHighBloodPressureMedication.SelectedValue = Nothing Then

            ElseIf ddHighBloodPressureMedication.SelectedValue = 1 Then
                ddHighBloodPressureMedicationAmount.Enabled = True
                rfvHighBloodPressureMedicationAmount.Enabled = True
            Else
                ddHighBloodPressureMedicationAmount.Enabled = False
                rfvHighBloodPressureMedicationAmount.Enabled = False
            End If
        End If

    End Sub

    'Set the Language Text, Populate TextBoxs, and Labels
    Private Sub IsPanelControl()

        hfTabPanelBloodHistory.Value = "True"

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
            Dim MyBR = (From T In TPDDCReadI.lkpBloodReferrals Select T.BloodReferral).ToArray

            For Each MyField As String In MyBR
                Dim BTRefLang As New List(Of String)

                Dim MyLabelText As String = Nothing
                Dim MyDropDownListText As String = Nothing
                Dim MyRequiredFieldValidatorText As String = Nothing

                Dim MyCkField As String = Trim(MyField.ToString)
                MyLabelText = "lb" & MyCkField & "Text"
                MyDropDownListText = "dd" & MyCkField
                MyRequiredFieldValidatorText = "rfv" & MyCkField

                Dim TPDDCReadII As New MyPortfolioDbDataContext
                Dim BT = From p In TPDDCReadII.lkpBloodReferrals
                         Where p.BloodReferral.ToString().Equals(MyCkField)
                         Select p

                Select Case hfLanguage.Value

                    Case "Eng"
                        Dim BTLE = (From bteng In BT Select bteng.BloodReferralEnglish).ToList
                        BTRefLang = BTLE
                    Case "Spa"
                        Dim BTLS = (From btspa In BT Select btspa.BloodReferralSpanish).ToList
                        BTRefLang = BTLS
                    Case "Man"
                        Dim BTLM = (From btman In BT Select btman.BloodReferralMandarin).ToList
                        BTRefLang = BTLM
                    Case "Ara"
                        Dim BTLA = (From btara In BT Select btara.BloodReferralArabic).ToList
                        BTRefLang = BTLA
                    Case "Hin"
                        Dim BTLH = (From bthin In BT Select bthin.BloodReferralHindiUrdu).ToList
                        BTRefLang = BTLH
                    Case "Ben"
                        Dim BTLB = (From btben In BT Select btben.BloodReferralBengali).ToList
                        BTRefLang = BTLB
                    Case "Por"
                        Dim BTLP = (From btpor In BT Select btpor.BloodReferralPortuguese).ToList
                        BTRefLang = BTLP
                    Case "Rus"
                        Dim BTLR = (From btrus In BT Select btrus.BloodReferralRussian).ToList
                        BTRefLang = BTLR
                    Case "Jap"
                        Dim BTLJ = (From btjap In BT Select btjap.BloodReferralJapanese).ToList
                        BTRefLang = BTLJ
                    Case "Pun"
                        Dim BTLPU = (From btpun In BT Select btpun.BloodReferralPunjabi).ToList
                        BTRefLang = BTLPU
                    Case Else
                        Dim BTLEN = (From bteng In BT Select bteng.BloodReferralEnglish).ToList
                        BTRefLang = BTLEN
                End Select

                For Each innerCtrl As Control In PanelBloodHistory.Controls
                    If TypeOf innerCtrl Is Label Then
                        If CType(innerCtrl, Label).ID = MyLabelText Then
                            CType(innerCtrl, Label).Text = BTRefLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerCtrl Is DropDownList Then
                        If CType(innerCtrl, DropDownList).ID = MyDropDownListText Then
                            CType(innerCtrl, DropDownList).ToolTip = hfPleaseEnter.Value & BTRefLang.FirstOrDefault.ToString & "."
                            Select Case MyCkField

                                Case "BloodType"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorBloodType
                                    CType(innerCtrl, DropDownList).DataTextField = "BloodType" & hfLanguageText.Value
                                    LinqDonorBloodType.OrderBy = "BloodType" & hfLanguageText.Value
                                Case "BloodRHFactor"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorBloodRHFactor
                                    CType(innerCtrl, DropDownList).DataTextField = "BloodRHFactor" & hfLanguageText.Value
                                    LinqDonorBloodRHFactor.OrderBy = "BloodRHFactor" & hfLanguageText.Value
                                Case "HighBloodPressure"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorBloodPressure
                                    CType(innerCtrl, DropDownList).DataTextField = "BloodPressure" & hfLanguageText.Value
                                    LinqDonorBloodPressure.OrderBy = "Id"
                                Case "HighBloodPressureMedication"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorBloodPressureMedication
                                    CType(innerCtrl, DropDownList).DataTextField = "BloodPressureMedication" & hfLanguageText.Value
                                    LinqDonorBloodPressureMedication.OrderBy = "Id"
                                Case "HighBloodPressureMedicationAmount"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorBloodPressureMedicationAmount
                                    CType(innerCtrl, DropDownList).DataTextField = "BloodPressureMedicationAmount" & hfLanguageText.Value
                                    LinqDonorBloodPressureMedicationAmount.OrderBy = "Id"
                                Case "BloodTransfusion"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorBloodTransfusion
                                    CType(innerCtrl, DropDownList).DataTextField = "BloodTransfusion" & hfLanguageText.Value
                                    LinqDonorBloodTransfusion.OrderBy = "Id"
                                Case Else

                            End Select
                            CType(innerCtrl, DropDownList).DataValueField = "Id"
                            CType(innerCtrl, DropDownList).DataBind()
                        End If
                    End If
                    If TypeOf innerCtrl Is RequiredFieldValidator Then
                        If CType(innerCtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerCtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & BTRefLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                Next innerCtrl
            Next MyField
        Catch ex As Exception

        End Try

    End Sub

    'Insert New Donor Record
    Private Function IsNewDonor(ByVal CkUserName As String) As String

        'tblBloodReferral
        Try
            Dim TPDDCI As New MyPortfolioDbDataContext
            Dim BR As New tblBloodReferral
            BR.pid = CInt(Trim(hfPID.Value))
            BR.Blood = ddBloodType.SelectedValue
            BR.RHFactor = ddBloodRHFactor.SelectedValue
            BR.BloodDate = Now.ToString("G")
            BR.BloodTimeHR = "0"
            BR.BloodTimeMIN = "99"
            BR.BloodTimeAMPM = "0"
            BR.Comments = Nothing
            BR.EnterBy = Trim(CkUserName)
            BR.EnterDate = Now.ToString("G")
            BR.ModifyBy = Nothing
            BR.ModifyDate = Nothing

            TPDDCI.tblBloodReferrals.InsertOnSubmit(BR)
            TPDDCI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblHistoryReferral
        Try
            Dim TPDDCII As New MyPortfolioDbDataContext
            Dim HR As New tblHistoryReferral
            HR.pid = CInt(Trim(hfPID.Value))
            HR.Diabetes = Nothing
            HR.DiabetesInsulin = Nothing
            HR.DiabetesOralMedication = Nothing
            HR.HighBloodPressure = ddHighBloodPressure.SelectedValue
            HR.HighBloodPressureMedication = ddHighBloodPressureMedication.SelectedValue
            HR.HighBloodPressureMedicationAmount = ddHighBloodPressureMedicationAmount.SelectedValue
            HR.HeartProblems = Nothing
            HR.HeartProblemsDescription = Nothing
            HR.KidneyStones = Nothing
            HR.KidneyStonesAmount = Nothing
            HR.CancerMelanoma = Nothing
            HR.CancerNonMelanoma = Nothing
            HR.CancerDescription = Nothing
            HR.BloodTransfusion = ddBloodTransfusion.SelectedValue
            HR.PastSurgeries = Nothing
            HR.Medications = Nothing
            HR.Smoking = Nothing
            HR.SmokingCigarettes = False
            HR.SmokingECigarettes = False
            HR.SmokingCigars = False
            HR.SmokingPipeHookah = False
            HR.SmokingVapes = False
            HR.SmokingCurrently = Nothing
            HR.SmokingHowManyYears = Nothing
            HR.SmokingFrequency = Nothing
            HR.SmokingQuit = Nothing
            HR.Drinking = Nothing
            HR.DrinkingCurrently = Nothing
            HR.DrinkingFrequency = Nothing
            HR.DrinkingAlcoholAbuse = Nothing
            HR.DrinkingQuit = Nothing
            HR.DrugPrescription = Nothing
            HR.DrugPrescriptionCurrently = Nothing
            HR.DrugPrescriptionQuit = Nothing
            HR.DrugRecreational = Nothing
            HR.DrugRecreationalMarijuana = False
            HR.DrugRecreationalSyntheticMarijuana = False
            HR.DrugRecreationalCocaine = False
            HR.DrugRecreationalCrackCocaine = False
            HR.DrugRecreationalHeroin = False
            HR.DrugRecreationalMethamphetamines = False
            HR.DrugRecreationalCrystalMeth = False
            HR.DrugRecreationalEcstasy = False
            HR.DrugRecreationalLysergicAcidDiethylamide = False
            HR.DrugRecreationalCurrently = Nothing
            HR.DrugRecreationalQuit = Nothing
            HR.DrugUseOther = Nothing
            HR.DrugUseOtherComments = Nothing
            HR.EnterBy = Trim(CkUserName)
            HR.EnterDate = Now.ToString("G")
            HR.ModifyBy = Nothing
            HR.ModifyDate = Nothing

            TPDDCII.tblHistoryReferrals.InsertOnSubmit(HR)
            TPDDCII.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        Try
            Dim MyManager = New UserManager()
            MyManager.AddToRole(hfUserId.Value, "Blood History")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Update Previous Donor Record
    Private Function IsUpdateDonor(ByVal CkUserName As String) As String

        'tblBloodReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim UBR = (From p In TPDDCUpdateI.tblBloodReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UBR.Blood = ddBloodType.SelectedValue
            UBR.RHFactor = ddBloodRHFactor.SelectedValue
            UBR.ModifyBy = Trim(CkUserName)
            UBR.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblHistoryReferral
        Try
            Dim TPDDCUpdateII As New MyPortfolioDbDataContext
            Dim UHR = (From p In TPDDCUpdateII.tblHistoryReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UHR.HighBloodPressure = ddHighBloodPressure.SelectedValue
            UHR.HighBloodPressureMedication = ddHighBloodPressureMedication.SelectedValue
            UHR.HighBloodPressureMedicationAmount = ddHighBloodPressureMedicationAmount.SelectedValue
            UHR.BloodTransfusion = ddBloodTransfusion.SelectedValue
            UHR.ModifyBy = Trim(CkUserName)
            UHR.ModifyDate = Now.ToString("G")

            TPDDCUpdateII.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
