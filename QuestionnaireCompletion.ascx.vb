
Partial Class Controls_QuestionnaireCompletion
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
            If hfTabPanelQuestionnaireCompletion.Value = "False" Then
                If Not Request.QueryString("D") Is Nothing Then
                    hfUserId.Value = Request.QueryString("D").ToString
                    hfLanguage.Value = Request.QueryString("L").ToString
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
            IsRejections()
            IsPanelControl()
            hfTabPanelQuestionnaireCompletion.Value = "False"
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

        End If

    End Sub

    'Set the Language Text, Populate TextBoxs, and Labels
    Private Sub IsPanelControl()

        hfTabPanelQuestionnaireCompletion.Value = "False"

        'Dim MyAllHiddenItems As String = Nothing
        'Dim MyAllHiddenItem As String() = Nothing
        'Dim MyLanguageText As New LanguageText
        'MyAllHiddenItems = MyLanguageText.CkLanguage(hfLanguage.Value)
        'MyAllHiddenItem = MyAllHiddenItems.Split("||")
        'hfLanguageText.Value = MyAllHiddenItem(0)
        'hfPleaseEnter.Value = MyAllHiddenItem(2)
        'hfIsInvalid.Value = MyAllHiddenItem(4)

        Try
            Dim TPDDCReadI As New MyPortfolioDbDataContext
            Dim MyQC = (From M In TPDDCReadI.lkpQuestionnaireCompletionReferrals Select M.QuestionnaireCompletionReferral).ToArray

            For Each MyField As String In MyQC
                Dim QCRefLang As New List(Of String)

                Dim MyLabelTextI As String = Nothing
                Dim MyLabelTextII As String = Nothing

                Dim MyCkField As String = Trim(MyField.ToString)
                MyLabelTextI = "lb" & hfCompletionRejectionText.Value & MyCkField & "Text"
                MyLabelTextII = "lb" & MyCkField & "Text"

                Dim TPDDCReadII As New MyPortfolioDbDataContext
                Dim QC = From q In TPDDCReadII.lkpQuestionnaireCompletionReferrals
                         Where q.QuestionnaireCompletionReferral.ToString().Equals(MyCkField)
                         Select q

                Select Case hfLanguage.Value

                    Case "Eng"
                        Dim QCLE = (From qceng In QC Select qceng.QuestionnaireCompletionReferralEnglish).ToList
                        QCRefLang = QCLE
                    Case "Spa"
                        Dim QCLS = (From qcspa In QC Select qcspa.QuestionnaireCompletionReferralSpanish).ToList
                        QCRefLang = QCLS
                    Case "Man"
                        Dim QCLM = (From qcman In QC Select qcman.QuestionnaireCompletionReferralMandarin).ToList
                        QCRefLang = QCLM
                    Case "Ara"
                        Dim QCLA = (From qcara In QC Select qcara.QuestionnaireCompletionReferralArabic).ToList
                        QCRefLang = QCLA
                    Case "Hin"
                        Dim QCLH = (From qchin In QC Select qchin.QuestionnaireCompletionReferralHindiUrdu).ToList
                        QCRefLang = QCLH
                    Case "Ben"
                        Dim QCLB = (From qcben In QC Select qcben.QuestionnaireCompletionReferralBengali).ToList
                        QCRefLang = QCLB
                    Case "Por"
                        Dim QCLP = (From qcpor In QC Select qcpor.QuestionnaireCompletionReferralPortuguese).ToList
                        QCRefLang = QCLP
                    Case "Rus"
                        Dim QCLR = (From qcrus In QC Select qcrus.QuestionnaireCompletionReferralRussian).ToList
                        QCRefLang = QCLR
                    Case "Jap"
                        Dim QCLJ = (From qcjap In QC Select qcjap.QuestionnaireCompletionReferralJapanese).ToList
                        QCRefLang = QCLJ
                    Case "Pun"
                        Dim QCLPU = (From qcpun In QC Select qcpun.QuestionnaireCompletionReferralPunjabi).ToList
                        QCRefLang = QCLPU
                    Case Else
                        Dim QCLEN = (From qceng In QC Select qceng.QuestionnaireCompletionReferralEnglish).ToList
                        QCRefLang = QCLEN
                End Select

                For Each innerCtrl As Control In PanelQuestionnaireCompletion.Controls
                    If TypeOf innerCtrl Is Label Then
                        If CType(innerCtrl, Label).ID = MyLabelTextI Or CType(innerCtrl, Label).ID = MyLabelTextII Then
                            CType(innerCtrl, Label).Text = QCRefLang.FirstOrDefault.ToString
                        End If
                    End If
                Next innerCtrl
            Next MyField
        Catch ex As Exception

        End Try

    End Sub

    'Go or No Go for Rejections
    Private Sub IsRejections()

        hfSoftRejectionKidneyText.Value = Nothing
        hfSoftRejectionLiverText.Value = Nothing
        hfHardRejectionKidneyText.Value = Nothing
        hfHardRejectionLiverText.Value = Nothing
        hfCompletionRejectionText.Value = Nothing

        Dim MyKidneyDonor As Boolean = False
        Dim MyLiverDonor As Boolean = False

        Dim MyDOB As Date = Nothing
        Dim MyAge As Integer = Nothing
        Dim MyEthnicity As String = Nothing
        Dim MyBMI As Double = Nothing
        Dim MyDiabetes As Integer = Nothing
        Dim MyDiabetesInsulin As Integer = Nothing
        Dim MyDiabetesOralMedication As Integer = Nothing
        Dim MyHighBloodPressure As Integer = Nothing
        Dim MyHighBloodPressureMedicationAmount As Integer = Nothing
        Dim MyKidneyStones As Integer = Nothing
        Dim MyKidneyStonesAmount As Integer = Nothing
        Dim MyCancerMelanoma As Integer = Nothing
        Dim MyNonCancerMelanoma As Integer = Nothing
        Dim MyBloodTransfusion As Integer = Nothing
        Dim MySmokingQuit As Integer = Nothing
        Dim MyDrinkingQuit As Integer = Nothing
        Dim MyDrugPrescriptionQuit As Integer = Nothing
        Dim MyDrugRecreationalQuit As Integer = Nothing
        Dim MyDrugUseOther As Integer = Nothing

        lbReview1a.Text = Nothing
        lbReview1b.Text = Nothing
        lbReview2a.Text = Nothing
        lbReview2b.Text = Nothing
        lbReview3a.Text = Nothing
        lbReview3b.Text = Nothing
        lbReview4a.Text = Nothing
        lbReview4b.Text = Nothing
        lbReview5a.Text = Nothing
        lbReview5b.Text = Nothing
        lbReview6a.Text = Nothing
        lbReview6b.Text = Nothing
        lbReview7a.Text = Nothing
        lbReview7b.Text = Nothing
        lbReview8a.Text = Nothing
        lbReview8b.Text = Nothing

        'tblKingsCourtReferral
        Try
            Dim TPDDCRejI As New MyPortfolioDbDataContext
            Dim MyKCR = From kcr In TPDDCRejI.tblKingsCourtReferrals
                        Where kcr.pid.Equals(hfPID.Value)
                        Select kcr.pid, kcr.DonorKidney, kcr.DonorLiver,
                            kcr.tblTransplantDonorReferral.DonationType, kcr.tblTransplantDonorReferral.RecipientCurrentlyPatient,
                            kcr.tblTransplantDonorReferral.lkpRecipientChildAdultReferral.RecipientChildAdult,
                            kcr.tblContactReferral.oFirst1, kcr.tblContactReferral.oMid1, kcr.tblContactReferral.oLast1,
                            kcr.tblContactReferral.lkpRelationshipReferral.Relationship, kcr.tblContactReferral.oDOB,
                            kcr.tblDemographicReferral.DOB, kcr.tblDemographicReferral.AGE, kcr.tblDemographicReferral.lkpEthnicityReferral.Ethnicity,
                            kcr.tblHtWtBMIReferral.BMI, kcr.tblHistoryReferral.Diabetes, kcr.tblHistoryReferral.DiabetesInsulin,
                            kcr.tblHistoryReferral.DiabetesOralMedication, kcr.tblHistoryReferral.HighBloodPressure,
                            kcr.tblHistoryReferral.HighBloodPressureMedicationAmount, kcr.tblHistoryReferral.KidneyStones,
                            kcr.tblHistoryReferral.KidneyStonesAmount, kcr.tblHistoryReferral.CancerMelanoma, kcr.tblHistoryReferral.CancerNonMelanoma,
                            kcr.tblHistoryReferral.BloodTransfusion, kcr.tblHistoryReferral.SmokingQuit, kcr.tblHistoryReferral.DrinkingQuit,
                            kcr.tblHistoryReferral.DrugPrescriptionQuit, kcr.tblHistoryReferral.DrugRecreationalQuit, kcr.tblHistoryReferral.DrugUseOther

            MyKidneyDonor = MyKCR.FirstOrDefault.DonorKidney.ToString
            MyLiverDonor = MyKCR.FirstOrDefault.DonorLiver.ToString
            MyDOB = CDate(MyKCR.FirstOrDefault.DOB.ToString)
            MyAge = CInt(MyKCR.FirstOrDefault.AGE.ToString)
            MyEthnicity = Trim(MyKCR.FirstOrDefault.Ethnicity.ToString)
            MyBMI = CDbl(MyKCR.FirstOrDefault.BMI.ToString)
            MyDiabetes = CInt(MyKCR.FirstOrDefault.Diabetes.ToString)
            MyDiabetesInsulin = CInt(MyKCR.FirstOrDefault.DiabetesInsulin.ToString)
            MyDiabetesOralMedication = CInt(MyKCR.FirstOrDefault.DiabetesOralMedication.ToString)
            MyHighBloodPressure = CInt(MyKCR.FirstOrDefault.HighBloodPressure.ToString)
            MyHighBloodPressureMedicationAmount = CInt(MyKCR.FirstOrDefault.HighBloodPressureMedicationAmount.ToString)
            MyKidneyStones = CInt(MyKCR.FirstOrDefault.KidneyStones.ToString)
            MyKidneyStonesAmount = CInt(MyKCR.FirstOrDefault.KidneyStonesAmount.ToString)
            MyCancerMelanoma = CInt(MyKCR.FirstOrDefault.CancerMelanoma.ToString)
            MyNonCancerMelanoma = CInt(MyKCR.FirstOrDefault.CancerNonMelanoma.ToString)
            MyBloodTransfusion = CInt(MyKCR.FirstOrDefault.BloodTransfusion.ToString)
            MySmokingQuit = CInt(MyKCR.FirstOrDefault.SmokingQuit.ToString)
            MyDrinkingQuit = CInt(MyKCR.FirstOrDefault.DrinkingQuit.ToString)
            MyDrugPrescriptionQuit = CInt(MyKCR.FirstOrDefault.DrugPrescriptionQuit.ToString)
            MyDrugRecreationalQuit = CInt(MyKCR.FirstOrDefault.DrugRecreationalQuit.ToString)
            MyDrugUseOther = CInt(MyKCR.FirstOrDefault.DrugUseOther.ToString)

            'Kidney Rejections
            If MyKidneyDonor = True Then
                'Age
                If MyAge >= 70 Or MyAge < 20 Then
                    hfHardRejectionKidneyText.Value += "Age, "
                End If

                'BMI
                If MyBMI >= 35 Then
                    hfSoftRejectionKidneyText.Value += "BMI, "
                End If

                'Blood History
                If MyHighBloodPressure = 1 Then
                    If MyAge < 50 Then
                        hfHardRejectionKidneyText.Value += "High Blood Pressure, "
                    End If
                    If MyEthnicity.Contains("African") Then
                        hfHardRejectionKidneyText.Value += "High Blood Pressure African, "
                    End If
                    If MyHighBloodPressureMedicationAmount > 2 Then
                        hfHardRejectionKidneyText.Value += "High Blood Pressure Medication Amount, "
                    End If
                End If
                If MyBloodTransfusion = 0 Then
                    hfHardRejectionKidneyText.Value += "Will Not Accept Blood Transfusion, "
                End If

                'Medical History
                If MyDiabetes = 1 And (MyDiabetesInsulin = 1 Or MyDiabetesOralMedication = 1) Then
                    hfHardRejectionKidneyText.Value += "Diabetes, "
                End If
                If MyKidneyStones = 1 Then
                    If MyKidneyStonesAmount > 2 Then
                        hfHardRejectionKidneyText.Value += "Kidney Stones, "
                    End If
                End If
                If MyCancerMelanoma = 1 Then
                    hfHardRejectionKidneyText.Value += "Cancer Melanoma, "
                End If
                If MyNonCancerMelanoma = 1 Then
                    hfHardRejectionKidneyText.Value += "Cancer Non Melanoma, "
                End If

                'Social History
                If MySmokingQuit = 0 Then
                    hfSoftRejectionKidneyText.Value += "Will not Quit Smoking, "
                End If
                If MyDrinkingQuit = 0 Then
                    hfSoftRejectionKidneyText.Value += "Will not Quit Drinking, "
                End If
                If MyDrugPrescriptionQuit = 0 Then
                    hfSoftRejectionKidneyText.Value += "Will not Quit Prescription Drugs, "
                End If
                If MyDrugRecreationalQuit = 0 Then
                    hfSoftRejectionKidneyText.Value += "Will not Quit Recreational Drugs, "
                End If
                If MyDrugUseOther = 1 Then
                    hfSoftRejectionKidneyText.Value += "Other Drug Use, "
                End If
            End If

            'Liver Rejections
            If MyLiverDonor = True Then
                'Age
                If MyAge >= 60 Or MyAge < 21 Then
                    hfHardRejectionLiverText.Value += "Age, "
                End If

                'BMI 
                If MyBMI > 40 Then
                    hfHardRejectionLiverText.Value += "BMI, "
                End If

                'Blood History
                If MyBloodTransfusion = 0 Then
                    hfHardRejectionLiverText.Value += "Will Not Accept Blood Transfusion, "
                End If
            End If

            If hfSoftRejectionKidneyText.Value = Nothing Then
                hfSoftRejectionKidney.Value = "False"
            Else
                hfSoftRejectionKidney.Value = "True"
                lbSoftRejectionKidney.Text = hfSoftRejectionKidneyText.Value.Remove(hfSoftRejectionKidneyText.Value.Length - 2, 2)
            End If
            If hfSoftRejectionLiverText.Value = Nothing Then
                hfSoftRejectionLiver.Value = "False"
            Else
                hfSoftRejectionLiver.Value = "True"
                lbSoftRejectionLiver.Text = hfSoftRejectionLiverText.Value.Remove(hfSoftRejectionLiverText.Value.Length - 2, 2)
            End If
            If hfHardRejectionKidneyText.Value = Nothing Then
                hfHardRejectionKidney.Value = "False"
            Else
                hfHardRejectionKidney.Value = "True"
                lbHardRejectionKidney.Text = hfHardRejectionKidneyText.Value.Remove(hfHardRejectionKidneyText.Value.Length - 2, 2)
            End If
            If hfHardRejectionLiverText.Value = Nothing Then
                hfHardRejectionLiver.Value = "False"
            Else
                hfHardRejectionLiver.Value = "True"
                lbHardRejectionLiver.Text = hfHardRejectionLiverText.Value.Remove(hfHardRejectionLiverText.Value.Length - 2, 2)
            End If
            If hfHardRejectionKidney.Value = "True" Or hfHardRejectionLiver.Value = "True" Then
                hfCompletionRejectionText.Value = "Rejection"
                lbCompletionText.Visible = False
                lbCompletionPreviousNextText.Visible = False
                lbCompletionCloseText.Visible = False
                lbRejectionText.Visible = True
                lbRejectionPreviousNextText.Visible = True
                lbRejectionCloseText.Visible = True
            Else
                hfCompletionRejectionText.Value = "Completion"
                lbCompletionText.Visible = True
                lbCompletionPreviousNextText.Visible = True
                lbCompletionCloseText.Visible = True
                lbRejectionText.Visible = False
                lbRejectionPreviousNextText.Visible = False
                lbRejectionCloseText.Visible = False
            End If

            'Transplant Institute
            If MyKidneyDonor = True And MyLiverDonor = True Then
                lbReview1a.Text += "<b>Organs you are Interested In Donating: </b> Kidney, Liver</br> "
            ElseIf MyKidneyDonor = True Then
                lbReview1a.Text += "<b>Organ you are Interested in Donating:</b> Kidney</br> "
            Else
                lbReview1a.Text += "<b>Organ you are Interested in Donating:</b> Liver</br> "
            End If

            Select Case MyKCR.FirstOrDefault.DonationType.ToString
                Case "1"
                    lbReview1b.Text += "<b>Donation Type:</b> Anyone</br>"
                Case "2"
                    lbReview1b.Text += "<b>Donation Type:</b> Donation to Specific Individual</br>"
                    lbReview1b.Text += "<b>Is the Recipient Currently a Patient at Transplant:</b> "
                    Select Case MyKCR.FirstOrDefault.RecipientCurrentlyPatient.ToString
                        Case "0"
                            lbReview1b.Text += "No "
                        Case "1"
                            lbReview1b.Text += "Yes </br>"
                            lbReview1b.Text += "<b>Recipient Name:</b> " & MyKCR.FirstOrDefault.oFirst1.ToString & " " & MyKCR.FirstOrDefault.oMid1 & " " & MyKCR.FirstOrDefault.oLast1.ToString & "</br> "
                            lbReview1b.Text += "<b>Recipient DOB:</b> " & MyKCR.FirstOrDefault.oDOB.ToString & "</br> "
                            lbReview1b.Text += "<b>Relationship:</b> " & MyKCR.FirstOrDefault.Relationship.ToString & "</br> "
                        Case "2"
                            lbReview1b.Text += "Unknown "
                        Case Else

                    End Select
                    lbReview1a.Text += "<b>Recipient is a Child/Adult:</b> " & MyKCR.FirstOrDefault.RecipientChildAdult.ToString
                Case "3"
                    lbReview1b.Text += "<b>Donation Type:</b> Unknown</br>"
                Case Else

            End Select

        Catch ex As Exception

        End Try

        'tblKingsCourtReferral
        Try
            Dim TPDDCRejII As New MyPortfolioDbDataContext
            Dim MyKCRII = From kcrii In TPDDCRejII.tblKingsCourtReferrals
                          Where kcrii.pid.Equals(hfPID.Value)
                          Select kcrii.pid, kcrii.DonorKidney, kcrii.DonorLiver, kcrii.SSN, kcrii.NoSSN,
                              kcrii.tblPatientReferral.FirstName, kcrii.tblPatientReferral.MiddleName, kcrii.tblPatientReferral.LastName,
                              kcrii.tblPatientReferral.Address1, kcrii.tblPatientReferral.Address2, kcrii.tblPatientReferral.City,
                              kcrii.tblPatientReferral.lkpStateReferral.State, kcrii.tblPatientReferral.ZipCode, kcrii.tblPatientReferral.Country,
                              kcrii.tblPatientReferral.lkpResidencyReferral.Residency,
                              kcrii.tblPatientReferral.HomePhone, kcrii.tblPatientReferral.HomePhoneNotes,
                              kcrii.tblPatientReferral.CellPhone, kcrii.tblPatientReferral.CellPhoneNotes,
                              kcrii.tblPatientReferral.WorkPhone, kcrii.tblPatientReferral.WorkPhoneNotes,
                              kcrii.tblPatientReferral.AlternativePhone, kcrii.tblPatientReferral.AlternativePhoneNotes,
                              kcrii.tblPatientReferral.lkpPrimaryPhoneToCallReferral.PrimaryPhoneToCall,
                              kcrii.tblPatientReferral.PrimaryeMail, kcrii.tblPatientReferral.SecondaryeMail,
                              kcrii.tblPatientReferral.BestTimeToContact,
                              kcrii.tblDemographicReferral.lkpGenderReferral.Gender,
                              kcrii.tblDemographicReferral.lkpLanguageReferral.Language,
                              kcrii.tblDemographicReferral.lkpMaritalReferral.Marital,
                              kcrii.tblDemographicReferral.lkpReligionReferral.Religion,
                              kcrii.tblDemographicReferral.lkpUNOSHLOEducationReferral.Description,
                              kcrii.tblDemographicReferral.CountryOfOrigin,
                              kcrii.tblFinancialInsuranceReferral.PrimaryInsurance, kcrii.tblFinancialInsuranceReferral.PrimaryInsuranceId,
                              kcrii.tblFinancialInsuranceReferral.PrimaryInsuranceGroup, kcrii.tblFinancialInsuranceReferral.PrimaryInsurancePhone,
                              kcrii.tblFinancialInsuranceReferral.Employment, kcrii.tblFinancialInsuranceReferral.SecondaryInsurance,
                              kcrii.tblFinancialInsuranceReferral.SecondaryInsuranceId, kcrii.tblFinancialInsuranceReferral.SecondaryInsuranceGroup,
                              kcrii.tblFinancialInsuranceReferral.SecondaryInsurancePhone, kcrii.tblFinancialInsuranceReferral.InsuranceComments,
                              kcrii.tblHtWtBMIReferral.Height, kcrii.tblHtWtBMIReferral.HeightCM,
                              kcrii.tblHtWtBMIReferral.Weight, kcrii.tblHtWtBMIReferral.WeightKG, kcrii.tblHtWtBMIReferral.BMI,
                              kcrii.tblBloodReferral.lkpBloodTypeReferral.BloodType, kcrii.tblBloodReferral.lkpBloodRHFactorReferral.BloodRHFactor,
                              kcrii.tblHistoryReferral.lkpBloodPressureReferral.BloodPressure,
                              kcrii.tblHistoryReferral.lkpBloodPressureMedicationReferral.BloodPressureMedication,
                              kcrii.tblHistoryReferral.lkpBloodPressureMedicationAmountReferral.BloodPressureMedicationAmount,
                              kcrii.tblHistoryReferral.lkpBloodTransfusionReferral.BloodTransfusion


            'Living Donor
            lbReview2a.Text += "<b>Donor Name:</b> " & MyKCRII.FirstOrDefault.FirstName.ToString & " " & MyKCRII.FirstOrDefault.MiddleName & " " & MyKCRII.FirstOrDefault.LastName.ToString & "</br> "
            lbReview2a.Text += "<b>Donor Address:</b> " & MyKCRII.FirstOrDefault.Address1.ToString & " " & MyKCRII.FirstOrDefault.Address2 & "</br> "
            lbReview2a.Text += "&emsp; " & MyKCRII.FirstOrDefault.City.ToString & " " & MyKCRII.FirstOrDefault.State.ToString & " " & MyKCRII.FirstOrDefault.ZipCode.ToString & "</br> "
            lbReview2a.Text += "<b>Country:</b> " & MyKCRII.FirstOrDefault.Country.ToString & "</br> "
            lbReview2a.Text += "<b>Country of Origin:</b> " & MyKCRII.FirstOrDefault.CountryOfOrigin.ToString & "</br></br> "
            If MyKCRII.FirstOrDefault.NoSSN.ToString = "False" Then
                lbReview2a.Text += "<b>SSN:</b> " & MyKCRII.FirstOrDefault.SSN.ToString & "</br> "
            Else
                lbReview2a.Text += "<b>SSN:</b></br> "
            End If
            lbReview2b.Text += "<b><u>Contact Information</u></b></br> "
            lbReview2b.Text += "<b>Home Phone:</b> " & MyKCRII.FirstOrDefault.HomePhone & " " & " " & MyKCRII.FirstOrDefault.HomePhoneNotes & "</br> "
            lbReview2b.Text += "<b>Cell Phone:</b> " & MyKCRII.FirstOrDefault.CellPhone & " " & " " & MyKCRII.FirstOrDefault.CellPhoneNotes & "</br> "
            lbReview2b.Text += "<b>Work Phone:</b> " & MyKCRII.FirstOrDefault.WorkPhone & " " & " " & MyKCRII.FirstOrDefault.WorkPhoneNotes & "</br> "
            lbReview2b.Text += "<b>Alternative Phone:</b> " & MyKCRII.FirstOrDefault.AlternativePhone & " " & MyKCRII.FirstOrDefault.AlternativePhoneNotes & "</br> "
            lbReview2b.Text += "<b>Primary Phone to Call:</b> " & MyKCRII.FirstOrDefault.PrimaryPhoneToCall & "</br> "
            lbReview2b.Text += "<b>1st Email:</b> " & MyKCRII.FirstOrDefault.PrimaryeMail & "</br> "
            lbReview2b.Text += "<b>2nd Email:</b> " & MyKCRII.FirstOrDefault.SecondaryeMail & "</br> "
            lbReview2b.Text += "<b>Best time to Contact:</b> " & MyKCRII.FirstOrDefault.BestTimeToContact & "</br> "

            'Demographics
            lbReview3a.Text += "<b>DOB:</b> " & MyDOB & "</br> "
            Dim MyYear As Integer = DateDiff(DateInterval.Year, MyDOB, Now)
            Dim MyMonth As Integer = DateDiff(DateInterval.Month, MyDOB, Now) Mod 12
            If (MyKidneyDonor = True And (MyAge >= 70 Or MyAge < 20)) Or (MyLiverDonor = True And (MyAge >= 60 Or MyAge < 21)) Then
                lbReview3a.Text += "<b>Age:</b><span style='color:Red'> " & MyYear & " Yr. " & MyMonth & " Mo. </span></br> "
            Else
                lbReview3a.Text += "<b>Age:</b> " & MyYear & " Yr. " & MyMonth & " Mo. </br> "
            End If
            lbReview3a.Text += "<b>Gender:</b> " & MyKCRII.FirstOrDefault.Gender.ToString & "</br> "
            lbReview3a.Text += "<b>Ethnicity:</b> " & MyEthnicity & "</br> "
            lbReview3a.Text += "<b>Language:</b> " & MyKCRII.FirstOrDefault.Language.ToString & "</br> "
            lbReview3b.Text += "<b>Marital Status:</b> " & MyKCRII.FirstOrDefault.Marital.ToString & "</br> "
            lbReview3b.Text += "<b>Religion:</b> " & MyKCRII.FirstOrDefault.Religion.ToString & "</br> "
            lbReview3b.Text += "<b>Residency:</b> " & MyKCRII.FirstOrDefault.Residency.ToString & "</br> "
            lbReview3b.Text += "<b>Highest Level of Education:</b> " & MyKCRII.FirstOrDefault.Description.ToString & "</br> "

            'Insurance
            lbReview4a.Text += "<b><u>Primary Insurance</u></b></br> "
            lbReview4a.Text += "<b>Name:</b> " & MyKCRII.FirstOrDefault.PrimaryInsurance.ToString & "</br> "
            lbReview4a.Text += "<b>Id:</b> " & MyKCRII.FirstOrDefault.PrimaryInsuranceId & "</br> "
            lbReview4a.Text += "<b>Group:</b> " & MyKCRII.FirstOrDefault.PrimaryInsuranceGroup & "</br> "
            lbReview4a.Text += "<b>Phone:</b> " & MyKCRII.FirstOrDefault.PrimaryInsurancePhone & "</br></br> "
            lbReview4a.Text += "<b>Employment Status:</b> " & MyKCRII.FirstOrDefault.Employment.ToString & "</br> "
            lbReview4b.Text += "<b><u>Secondary Insurance</u></b></br> "
            lbReview4b.Text += "<b>Name:</b> " & MyKCRII.FirstOrDefault.SecondaryInsurance & "</br> "
            lbReview4b.Text += "<b>Id:</b> " & MyKCRII.FirstOrDefault.SecondaryInsuranceId & "</br> "
            lbReview4b.Text += "<b>Group:</b> " & MyKCRII.FirstOrDefault.SecondaryInsuranceGroup & "</br> "
            lbReview4b.Text += "<b>Phone:</b> " & MyKCRII.FirstOrDefault.SecondaryInsurancePhone & "</br></br> "
            lbReview4b.Text += "<b>Comments:</b> " & MyKCRII.FirstOrDefault.InsuranceComments & "</br> "

            'Height Weight BMI
            Dim MyFeet As Integer = Nothing
            Dim MyInches As Integer = Nothing
            MyInches = CInt(MyKCRII.FirstOrDefault.Height.ToString)
            MyFeet = Math.Floor(MyInches / 12)
            MyInches = MyInches - (MyFeet * 12)
            lbReview5a.Text += "<b>Height:</b> " & MyFeet & " ft. " & MyInches & " in. (" & CDbl(MyKCRII.FirstOrDefault.HeightCM).ToString("F2") & " cm.)</br>"
            lbReview5a.Text += "<b>Weight:</b> " & MyKCRII.FirstOrDefault.Weight.ToString & " lbs. (" & CDbl(MyKCRII.FirstOrDefault.WeightKG).ToString("F2") & " kg.)</br> "
            If (MyKidneyDonor = True And MyBMI >= 35) Or (MyLiverDonor = True And MyBMI > 40) Then
                lbReview5a.Text += "<b>BMI:</b><span style='color:Red'> " & MyKCRII.FirstOrDefault.BMI.ToString & "</span></br> "
            Else
                lbReview5a.Text += "<b>BMI:</b> " & MyKCRII.FirstOrDefault.BMI.ToString & "</br> "
            End If

            'Blood Type
            lbReview5b.Text += "<b>Blood Type:</b> " & MyKCRII.FirstOrDefault.BloodType.ToString & "</br> "
            lbReview5b.Text += "<b>RH Factor: </b> " & MyKCRII.FirstOrDefault.BloodRHFactor.ToString & "</br> "

            'High Blood Pressure
            If MyKidneyDonor = True And MyHighBloodPressure = 1 Then
                If MyAge < 50 Or MyEthnicity.Contains("African") Then
                    lbReview5b.Text += "<b>Treated for High Blood Pressure:</b><span style='color:Red'> " & MyKCRII.FirstOrDefault.BloodPressure.ToString & "</span></br> "
                Else
                    lbReview5b.Text += "<b>Treated for High Blood Pressure:</b> " & MyKCRII.FirstOrDefault.BloodPressure.ToString & "</br> "
                End If
                lbReview5b.Text += "<b>Medication for High Blood Pressure:</b> " & MyKCRII.FirstOrDefault.BloodPressureMedication.ToString & "</br> "
                If MyHighBloodPressureMedicationAmount > 2 Then
                    lbReview5b.Text += "<b>Amount of Medications for High Blood Pressure:</b><span style='color:Red'> " & MyKCRII.FirstOrDefault.BloodPressureMedicationAmount.ToString & "</span></br> "
                Else
                    lbReview5b.Text += "<b>Amount of Medications for High Blood Pressure:</b> " & MyKCRII.FirstOrDefault.BloodPressureMedicationAmount.ToString & "</br> "
                End If
            Else
                lbReview5b.Text += "<b>Treated for High Blood Pressure:</b> " & MyKCRII.FirstOrDefault.BloodPressure.ToString & "</br> "
                lbReview5b.Text += "<b>Medication for High Blood Pressure:</b> " & MyKCRII.FirstOrDefault.BloodPressureMedication.ToString & "</br> "
                lbReview5b.Text += "<b>Amount of Medications for High Blood Pressure:</b> " & MyKCRII.FirstOrDefault.BloodPressureMedicationAmount.ToString & "</br> "
            End If

            'Blood Transfusion
            If MyBloodTransfusion = 0 Then
                lbReview5b.Text += "<b>Willing to Accept a Blood Transfusion:</b><span style='color:Red'> " & MyKCRII.FirstOrDefault.BloodTransfusion.ToString & "</span></br> "
            Else
                lbReview5b.Text += "<b>Willing to Accept a Blood Transfusion:</b> " & MyKCRII.FirstOrDefault.BloodTransfusion.ToString & "</br> "
            End If

        Catch ex As Exception

        End Try


        'tblKingsCourtReferral
        Try
            Dim TPDDCRejIII As New MyPortfolioDbDataContext
            Dim MyKCRIII = From kcriii In TPDDCRejIII.tblKingsCourtReferrals
                           Where kcriii.pid.Equals(hfPID.Value)
                           Select kcriii.pid, kcriii.DonorKidney, kcriii.DonorLiver,
                               kcriii.tblHistoryReferral.lkpDiabetesReferral.Diabetes,
                               kcriii.tblHistoryReferral.lkpDiabetesInsulinReferral.DiabetesInsulin,
                               kcriii.tblHistoryReferral.lkpDiabetesOralMedicationReferral.DiabetesOralMedication,
                               kcriii.tblHistoryReferral.lkpHeartProblemsReferral.HeartProblems, kcriii.tblHistoryReferral.HeartProblemsDescription,
                               kcriii.tblHistoryReferral.lkpKidneyStonesReferral.KidneyStones,
                               kcriii.tblHistoryReferral.lkpKidneyStonesAmountReferral.KidneyStonesAmount,
                               kcriii.tblHistoryReferral.lkpCancerMelanomaReferral.CancerMelanoma,
                               kcriii.tblHistoryReferral.lkpCancerNonMelanomaReferral.CancerNonMelanoma, kcriii.tblHistoryReferral.CancerDescription,
                               kcriii.tblHistoryReferral.lkpPastSurgeriesReferral.PastSurgeries,
                               kcriii.tblHistoryReferral.Medications,
                               kcriii.tblHistoryReferral.lkpSmokingReferral.Smoking,
                               kcriii.tblHistoryReferral.SmokingCigarettes,
                               kcriii.tblHistoryReferral.SmokingECigarettes,
                               kcriii.tblHistoryReferral.SmokingCigars,
                               kcriii.tblHistoryReferral.SmokingPipeHookah,
                               kcriii.tblHistoryReferral.SmokingVapes,
                               kcriii.tblHistoryReferral.lkpSmokingCurrentlyReferral.SmokingCurrently,
                               kcriii.tblHistoryReferral.SmokingHowManyYears,
                               kcriii.tblHistoryReferral.lkpSmokingFrequencyReferral.SmokingFrequency,
                               kcriii.tblHistoryReferral.lkpSmokingQuitReferral.SmokingQuit,
                               kcriii.tblHistoryReferral.lkpDrinkingReferral.Drinking,
                               kcriii.tblHistoryReferral.lkpDrinkingCurrentlyReferral.DrinkingCurrently,
                               kcriii.tblHistoryReferral.lkpDrinkingFrequencyReferral.DrinkingFrequency,
                               kcriii.tblHistoryReferral.lkpDrinkingAlcoholAbuseReferral.DrinkingAlcoholAbuse,
                               kcriii.tblHistoryReferral.lkpDrinkingQuitReferral.DrinkingQuit,
                               kcriii.tblHistoryReferral.lkpDrugPrescriptionReferral.DrugPrescription,
                               kcriii.tblHistoryReferral.lkpDrugPrescriptionCurrentlyReferral.DrugPrescriptionCurrently,
                               kcriii.tblHistoryReferral.lkpDrugPrescriptionQuitReferral.DrugPrescriptionQuit,
                               kcriii.tblHistoryReferral.lkpDrugRecreationalReferral.DrugRecreational,
                               kcriii.tblHistoryReferral.DrugRecreationalMarijuana,
                               kcriii.tblHistoryReferral.DrugRecreationalSyntheticMarijuana,
                               kcriii.tblHistoryReferral.DrugRecreationalCocaine,
                               kcriii.tblHistoryReferral.DrugRecreationalCrackCocaine,
                               kcriii.tblHistoryReferral.DrugRecreationalHeroin,
                               kcriii.tblHistoryReferral.DrugRecreationalMethamphetamines,
                               kcriii.tblHistoryReferral.DrugRecreationalCrystalMeth,
                               kcriii.tblHistoryReferral.DrugRecreationalEcstasy,
                               kcriii.tblHistoryReferral.DrugRecreationalLysergicAcidDiethylamide,
                               kcriii.tblHistoryReferral.lkpDrugRecreationalCurrentlyReferral.DrugRecreationalCurrently,
                               kcriii.tblHistoryReferral.lkpDrugRecreationalQuitReferral.DrugRecreationalQuit,
                               kcriii.tblHistoryReferral.lkpDrugUseOtherReferral.DrugUseOther,
                               kcriii.tblHistoryReferral.DrugUseOtherComments


            'Medical History
            If MyKidneyDonor = True And MyDiabetes = 1 And (MyDiabetesInsulin = 1 Or MyDiabetesOralMedication = 1) Then
                lbReview6a.Text += "<b>History of Diabetes:</b><span style='color:Red'> " & MyKCRIII.FirstOrDefault.Diabetes.ToString & "</span></br> "
            Else
                lbReview6a.Text += "<b>History of Diabetes:</b> " & MyKCRIII.FirstOrDefault.Diabetes.ToString & "</br> "
            End If
            lbReview6a.Text += "<b>Insulin for your Treatment:</b> " & MyKCRIII.FirstOrDefault.DiabetesInsulin.ToString & "</br> "
            lbReview6a.Text += "<b>Oral Medication for your Treatment:</b> " & MyKCRIII.FirstOrDefault.DiabetesOralMedication.ToString & "</br> "
            lbReview6b.Text += "<b>Heart Problems:</b> " & MyKCRIII.FirstOrDefault.HeartProblems.ToString & "</br> "
            lbReview6b.Text += "<b>Heart Problem Description:</b> " & MyKCRIII.FirstOrDefault.HeartProblemsDescription & "</br> "
            If MyKidneyDonor = True And MyKidneyStones = 1 And MyKidneyStonesAmount > 2 Then
                lbReview7a.Text += "<b>History of Kidney Stones:</b><span style='color:Red'> " & MyKCRIII.FirstOrDefault.KidneyStones.ToString & "</span></br> "
            Else
                lbReview7a.Text += "<b>History of Kidney Stones:</b> " & MyKCRIII.FirstOrDefault.KidneyStones.ToString & "</br> "
            End If
            lbReview7a.Text += "<b>Amount of Episodes (past 5 years):</b> " & MyKCRIII.FirstOrDefault.KidneyStonesAmount.ToString & "</br></br> "
            If MyKidneyDonor = True And MyCancerMelanoma = 1 Then
                lbReview7b.Text += "<b>History of Melanoma Cancer:</b><span style='color:Red'> " & MyKCRIII.FirstOrDefault.CancerMelanoma.ToString & "</span></br> "
            Else
                lbReview7b.Text += "<b>History of Melanoma Cancer:</b> " & MyKCRIII.FirstOrDefault.CancerMelanoma.ToString & "</br> "
            End If
            If MyKidneyDonor = True And MyNonCancerMelanoma = 1 Then
                lbReview7b.Text += "<b>History of Non-Melanoma Cancer:</b><span style='color:Red'> " & MyKCRIII.FirstOrDefault.CancerNonMelanoma.ToString & "</span></br> "
            Else
                lbReview7b.Text += "<b>History of Non-Melanoma Cancer:</b> " & MyKCRIII.FirstOrDefault.CancerNonMelanoma.ToString & "</br> "
            End If
            lbReview7b.Text += "<b>Detail of Cancer:</b> " & MyKCRIII.FirstOrDefault.CancerDescription & "</br></br> "
            lbReview7a.Text += "<b>Past Surgeries:</b> " & MyKCRIII.FirstOrDefault.PastSurgeries.ToString & "</br> "
            lbReview7b.Text += "<b>Current Medications:</b> " & MyKCRIII.FirstOrDefault.Medications & "</br> "

            'Social History
            lbReview8a.Text += "<b>History of Smoking:</b> " & MyKCRIII.FirstOrDefault.Smoking.ToString & "</br> "
            lbReview8a.Text += "<b>Currently Smoking:</b> " & MyKCRIII.FirstOrDefault.SmokingCurrently.ToString & "</br> "
            If MyKCRIII.FirstOrDefault.SmokingCigarettes.ToString = "False" Then
                lbReview8a.Text += "<b>History Smoking Cigarettes:</b> No</br> "
            Else
                lbReview8a.Text += "<b>History Smoking Cigarettes:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.SmokingECigarettes.ToString = "False" Then
                lbReview8a.Text += "<b>History Smoking E-Cigarettes:</b> No</br> "
            Else
                lbReview8a.Text += "<b>History Smoking E-Cigarettes:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.SmokingCigars.ToString = "False" Then
                lbReview8a.Text += "<b>History Smoking Cigars:</b> No</br> "
            Else
                lbReview8a.Text += "<b>History Smoking Cigars:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.SmokingPipeHookah.ToString = "False" Then
                lbReview8a.Text += "<b>History Smoking Pipe/Hookah:</b> No</br> "
            Else
                lbReview8a.Text += "<b>History Smoking Pipe/Hookah:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.SmokingVapes.ToString = "False" Then
                lbReview8a.Text += "<b>History Smoking Vapes:</b> No</br> "
            Else
                lbReview8a.Text += "<b>History Smoking Vapes:</b> Yes</br> "
            End If
            lbReview8a.Text += "<b>How Many Years Have you Smoked:</b> " & Trim(MyKCRIII.FirstOrDefault.SmokingHowManyYears) & "</br> "
            lbReview8a.Text += "<b>How Many Times Do/Did you Smoke Per Day:</b> " & MyKCRIII.FirstOrDefault.SmokingFrequency.ToString & "</br> "
            If MySmokingQuit = 0 Then
                lbReview8a.Text += "<b>Willing to Quit Smoking Prior to Surgery:</b><span style='color:Red'> " & MyKCRIII.FirstOrDefault.SmokingQuit.ToString & "</span></br> "
            Else
                lbReview8a.Text += "<b>Willing to Quit Smoking Prior to Surgery:</b> " & MyKCRIII.FirstOrDefault.SmokingQuit.ToString & "</br></br> "
            End If
            lbReview8a.Text += "<b>History of Drinking:</b> " & MyKCRIII.FirstOrDefault.Drinking.ToString & "</br> "
            lbReview8a.Text += "<b>Currently Drinking:</b> " & MyKCRIII.FirstOrDefault.DrinkingCurrently.ToString & "</br> "
            lbReview8a.Text += "<b>Frequency Drinking:</b> " & MyKCRIII.FirstOrDefault.DrinkingFrequency.ToString & "</br> "
            lbReview8a.Text += "<b>Alcohol Abuse:</b> " & MyKCRIII.FirstOrDefault.DrinkingAlcoholAbuse.ToString & "</br> "
            If MyDrinkingQuit = 0 Then
                lbReview8a.Text += "<b>Willing to Quit Drinking Prior to Surgery:</b><span style='color:Red'> " & MyKCRIII.FirstOrDefault.DrinkingQuit.ToString & "</span></br></br> "
            Else
                lbReview8a.Text += "<b>Willing to Quit Drinking Prior to Surgery:</b> " & MyKCRIII.FirstOrDefault.DrinkingQuit.ToString & "</br></br> "
            End If
            lbReview8b.Text += "<b>History of Prescription Drug :</b> " & MyKCRIII.FirstOrDefault.DrugPrescription.ToString & "</br> "
            lbReview8b.Text += "<b>Currently Prescription Drug:</b> " & MyKCRIII.FirstOrDefault.DrugPrescriptionCurrently.ToString & "</br> "
            If MyDrugPrescriptionQuit = 0 Then
                lbReview8b.Text += "<b>Willing to Quit Prescription Drug Prior to Surgery:</b><span style='color:Red'> " & MyKCRIII.FirstOrDefault.DrugPrescriptionQuit.ToString & "</span></br></br> "
            Else
                lbReview8b.Text += "<b>Willing to Quit Prescription Drug Prior to Surgery:</b> " & MyKCRIII.FirstOrDefault.DrugPrescriptionQuit.ToString & "</br></br> "
            End If
            lbReview8b.Text += "<b>History of Recreational Drug:</b> " & MyKCRIII.FirstOrDefault.DrugRecreational.ToString & "</br> "
            lbReview8b.Text += "<b>Currently Recreational Drug:</b> " & MyKCRIII.FirstOrDefault.DrugRecreationalCurrently.ToString & "</br> "
            If MyKCRIII.FirstOrDefault.DrugRecreationalMarijuana.ToString = "False" Then
                lbReview8b.Text += "<b>History Recreational Marijuana:</b> No</br> "
            Else
                lbReview8b.Text += "<b>History Recreational Marijuana:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.DrugRecreationalSyntheticMarijuana.ToString = "False" Then
                lbReview8b.Text += "<b>History Recreational Synthetic Marijuana:</b> No</br> "
            Else
                lbReview8b.Text += "<b>History Recreational Synthetic Marijuana:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.DrugRecreationalCocaine.ToString = "False" Then
                lbReview8b.Text += "<b>History Recreational Cocaine:</b> No</br> "
            Else
                lbReview8b.Text += "<b>History Recreational Cocaine:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.DrugRecreationalCrackCocaine.ToString = "False" Then
                lbReview8b.Text += "<b>History Recreational Crack Cocaine:</b> No</br> "
            Else
                lbReview8b.Text += "<b>History Recreational Crack Cocaine:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.DrugRecreationalHeroin.ToString = "False" Then
                lbReview8b.Text += "<b>History Recreational Heroin:</b> No</br> "
            Else
                lbReview8b.Text += "<b>History Recreational Heroin:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.DrugRecreationalMethamphetamines.ToString = "False" Then
                lbReview8b.Text += "<b>History Recreational Methamphetamines:</b> No</br> "
            Else
                lbReview8b.Text += "<b>History Recreational Methamphetamines:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.DrugRecreationalCrystalMeth.ToString = "False" Then
                lbReview8b.Text += "<b>History Recreational Crystal Meth:</b> No</br> "
            Else
                lbReview8b.Text += "<b>History Recreational Crystal Meth:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.DrugRecreationalEcstasy.ToString = "False" Then
                lbReview8b.Text += "<b>History Recreational Ecstasy:</b> No</br> "
            Else
                lbReview8b.Text += "<b>History Recreational Ecstasy:</b> Yes</br> "
            End If
            If MyKCRIII.FirstOrDefault.DrugRecreationalLysergicAcidDiethylamide.ToString = "False" Then
                lbReview8b.Text += "<b>History Recreational Lysergic Acid Diethylamide (LSD):</b> No</br> "
            Else
                lbReview8b.Text += "<b>History Recreational Lysergic Acid Diethylamide (LSD):</b> Yes</br> "
            End If
            If MyDrugRecreationalQuit = 0 Then
                lbReview8b.Text += "<b>Willing to Quit Recreational Drug Prior to Surgery:</b><span style='color:Red'> " & MyKCRIII.FirstOrDefault.DrugRecreationalQuit.ToString & "</span></br> "
            Else
                lbReview8b.Text += "<b>Willing to Quit Recreational Drug Prior to Surgery:</b> " & MyKCRIII.FirstOrDefault.DrugRecreationalQuit.ToString & "</br> "
            End If
            If MyDrugUseOther = 1 Then
                lbReview8a.Text += "<b>Recent Other Drug Use:</b><span style='color:Red'> " & MyKCRIII.FirstOrDefault.DrugUseOther.ToString & "</span></br> "
            Else
                lbReview8a.Text += "<b>Recent Other Drug Use:</b> " & MyKCRIII.FirstOrDefault.DrugUseOther.ToString & "</br> "
            End If
            lbReview8a.Text += "<b>Other Drug Use Comments:</b> " & Trim(MyKCRIII.FirstOrDefault.DrugUseOtherComments) & "</br> "

        Catch ex As Exception

        End Try

    End Sub

    'Insert New Donor Record
    Private Function IsNewDonor(ByVal CkUserName As String) As String

        ''tblBloodReferral
        'Try
        '    Dim TPDDCI As New MyPortfolioDbDataContext
        '    Dim BR As New tblBloodReferral
        '    BR.Id = Guid.NewGuid
        '    BR.pid = CInt(Trim(hfPID.Value))
        '    BR.Comments = Nothing
        '    BR.EnterBy = Trim(CkUserName)
        '    BR.EnterDate = Now.ToString("G")
        '    BR.ModifyBy = Nothing
        '    BR.ModifyDate = Nothing

        '    TPDDCI.tblBloodReferrals.InsertOnSubmit(BR)
        '    TPDDCI.SubmitChanges()
        '    'Return True
        'Catch ex As Exception
        '    'Return False
        'End Try

        Try
            Dim MyManager = New UserManager()
            MyManager.AddToRole(hfUserId.Value, "Questionnaire Completion")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Update Previous Donor Record
    Private Function IsUpdateDonor(ByVal CkUserName As String) As String

        ''tblHistoryReferral
        'Try
        '    Dim TPDDCUpdateII As New MyPortfolioDbDataContext
        '    Dim UHR = (From p In TPDDCUpdateII.tblHistoryReferrals
        '               Where p.pid.Equals(hfPID.Value)).ToList(0)

        '    UHR.ModifyBy = Trim(CkUserName)
        '    UHR.ModifyDate = Now.ToString("G")

        '    TPDDCUpdateII.SubmitChanges()
        '    Return True
        'Catch ex As Exception
        Return False
        'End Try

    End Function

End Class
