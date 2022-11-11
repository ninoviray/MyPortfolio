Imports AjaxControlToolkit

Partial Class Controls_LivingDonor
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
            If hfTabPanelLivingDonor.Value = "False" Then
                If Not Request.QueryString("D") Is Nothing Then
                    hfUserId.Value = Request.QueryString("D").ToString
                    hfLanguage.Value = Request.QueryString("L").ToString
                    IsPanelControl()
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
            txtFirstName.Focus()
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

        End If

    End Sub

    'Set the Language Text, Populate TextBoxs, and Labels
    Private Sub IsPanelControl()

        hfTabPanelLivingDonor.Value = "True"

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
            Dim MyPR = (From T In TPDDCReadI.lkpPatientReferrals Select T.PatientReferral).ToArray

            For Each MyField As String In MyPR
                Dim PatRefLang As New List(Of String)

                Dim MyLabelText As String = Nothing
                Dim MyTextBoxText As String = Nothing
                Dim MyDropDownListText As String = Nothing
                Dim MyRequiredFieldValidatorText As String = Nothing
                Dim MyRegularExpressionValidatorText As String = Nothing
                Dim MyTextBoxWatermarkExtender As String = Nothing

                Dim MyCkField As String = Trim(MyField.ToString)
                MyLabelText = "lb" & MyCkField & "Text"
                MyTextBoxText = "txt" & MyCkField
                MyDropDownListText = "dd" & MyCkField
                MyRequiredFieldValidatorText = "rfv" & MyCkField
                MyRegularExpressionValidatorText = "rev" & MyCkField
                MyTextBoxWatermarkExtender = "tbwe" & MyCkField

                Dim TPDDCReadII As New MyPortfolioDbDataContext
                Dim PR = From p In TPDDCReadII.lkpPatientReferrals
                         Where p.PatientReferral.ToString().Equals(MyCkField)
                         Select p

                Select Case hfLanguage.Value

                    Case "Eng"
                        Dim PRLE = (From preng In PR Select preng.PatientReferralEnglish).ToList
                        PatRefLang = PRLE
                    Case "Spa"
                        Dim PRLS = (From prspa In PR Select prspa.PatientReferralSpanish).ToList
                        PatRefLang = PRLS
                    Case "Man"
                        Dim PRLM = (From prman In PR Select prman.PatientReferralMandarin).ToList
                        PatRefLang = PRLM
                    Case "Ara"
                        Dim PRLA = (From prara In PR Select prara.PatientReferralArabic).ToList
                        PatRefLang = PRLA
                    Case "Hin"
                        Dim PRLH = (From prhin In PR Select prhin.PatientReferralHindiUrdu).ToList
                        PatRefLang = PRLH
                    Case "Ben"
                        Dim PRLB = (From prben In PR Select prben.PatientReferralBengali).ToList
                        PatRefLang = PRLB
                    Case "Por"
                        Dim PRLP = (From prpor In PR Select prpor.PatientReferralPortuguese).ToList
                        PatRefLang = PRLP
                    Case "Rus"
                        Dim PRLR = (From prrus In PR Select prrus.PatientReferralRussian).ToList
                        PatRefLang = PRLR
                    Case "Jap"
                        Dim PRLJ = (From prjap In PR Select prjap.PatientReferralJapanese).ToList
                        PatRefLang = PRLJ
                    Case "Pun"
                        Dim PRLPU = (From prpun In PR Select prpun.PatientReferralPunjabi).ToList
                        PatRefLang = PRLPU
                    Case Else
                        Dim PRLEN = (From preng In PR Select preng.PatientReferralEnglish).ToList
                        PatRefLang = PRLEN
                End Select

                For Each innerCtrl As Object In PanelLivingDonor.Controls
                    If TypeOf innerCtrl Is Label Then
                        If CType(innerCtrl, Label).ID = MyLabelText Then
                            CType(innerCtrl, Label).Text = PatRefLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerCtrl Is TextBox Then
                        If CType(innerCtrl, TextBox).ID = MyTextBoxText Then
                            CType(innerCtrl, TextBox).ToolTip = hfPleaseEnter.Value & PatRefLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerCtrl Is DropDownList Then
                        If CType(innerCtrl, DropDownList).ID = MyDropDownListText Then
                            CType(innerCtrl, DropDownList).ToolTip = hfPleaseEnter.Value & PatRefLang.FirstOrDefault.ToString & "."
                            Select Case MyCkField

                                Case "State"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorState
                                    CType(innerCtrl, DropDownList).DataTextField = "State" & hfLanguageText.Value
                                    LinqDonorState.OrderBy = "State" & hfLanguageText.Value
                                Case "PrimaryPhoneToCall"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorPrimaryPhoneToCall
                                    CType(innerCtrl, DropDownList).DataTextField = "PrimaryPhoneToCall" & hfLanguageText.Value
                                    LinqDonorPrimaryPhoneToCall.OrderBy = "PrimaryPhoneToCall" & hfLanguageText.Value
                                Case Else

                            End Select
                            CType(innerCtrl, DropDownList).DataValueField = "Id"
                            CType(innerCtrl, DropDownList).DataBind()
                        End If
                    End If
                    If TypeOf innerCtrl Is TextBoxWatermarkExtender Then
                        If CType(innerCtrl, TextBoxWatermarkExtender).ID = MyTextBoxWatermarkExtender Then
                            CType(innerCtrl, TextBoxWatermarkExtender).WatermarkText = PatRefLang.FirstOrDefault.ToString
                        End If
                    End If
                    If TypeOf innerCtrl Is RequiredFieldValidator Then
                        If CType(innerCtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerCtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & PatRefLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                    If TypeOf innerCtrl Is RegularExpressionValidator Then
                        If CType(innerCtrl, RegularExpressionValidator).ID = MyRegularExpressionValidatorText Then
                            CType(innerCtrl, RegularExpressionValidator).ErrorMessage = PatRefLang.FirstOrDefault.ToString & hfIsInvalid.Value
                        End If
                    End If
                Next innerCtrl
            Next MyField
        Catch ex As Exception

        End Try

    End Sub

    'Insert New Donor Record
    Private Function IsNewDonor(ByVal CkUserName As String) As String

        Dim MyNoSSN As New String("SSN000000")
        Dim MyNewPID As Integer = hfPID.Value
        Dim MyLengthPID As Integer = Nothing
        Dim MyNewSSNPID As String = Nothing

        'tblKingsCourtReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim UKCR = (From p In TPDDCUpdateI.tblKingsCourtReferrals
                        Where p.pid.Equals(hfPID.Value)).ToList(0)

            hfSSN.Value = Trim(txtSocialSecurityNumber.Text)
            If hfSSN.Value = Nothing Then
                Dim MyFixSSN As String = Nothing
                MyLengthPID = 9 - hfPID.Value.ToString.Length
                MyFixSSN = Left(MyNoSSN, MyLengthPID)
                MyNewSSNPID = MyFixSSN & MyNewPID
                Dim MyNewSSN As String = MyNewSSNPID.Insert(5, "-").Insert(3, "-")
                hfSSN.Value = MyNewSSN
            Else
                hfSSN.Value = Trim(txtSocialSecurityNumber.Text)
            End If

            UKCR.SSN = hfSSN.Value
            If hfSSN.Value.Contains("SSN") Then
                UKCR.NoSSN = True
            Else
                UKCR.NoSSN = False
            End If
            UKCR.ModifyBy = Trim(CkUserName)
            UKCR.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblPatientReferral
        Try
            Dim TPDDCI As New MyPortfolioDbDataContext
            Dim PR As New tblPatientReferral
            PR.pid = CInt(Trim(hfPID.Value))
            PR.FirstName = Trim(StrConv(txtFirstName.Text, VbStrConv.ProperCase))
            If txtMiddleName.Text = Nothing Then
                PR.MiddleName = Nothing
            Else
                PR.MiddleName = Trim(StrConv(txtMiddleName.Text, VbStrConv.ProperCase))
            End If
            PR.LastName = ConvertToProperCase(txtLastName.Text)
            PR.Address1 = Trim(StrConv(txtAddress1.Text, VbStrConv.ProperCase))
            If txtAddress2.Text = Nothing Then
                PR.Address2 = Nothing
            Else
                PR.Address2 = Trim(StrConv(txtAddress2.Text, VbStrConv.ProperCase))
            End If
            PR.City = Trim(StrConv(txtCity.Text, VbStrConv.ProperCase))
            PR.State = Trim(ddState.SelectedValue)
            PR.ZipCode = Trim(txtZipCode.Text)
            PR.Country = Trim(txtCountry.Text.ToUpper)
            PR.Residency = Nothing 'Trim(ddResidency.SelectedValue))
            If txtHomePhone.Text = Nothing Then
                PR.HomePhone = Nothing
            Else
                PR.HomePhone = Trim(txtHomePhone.Text)
            End If
            If txtHomePhoneNotes.Text = Nothing Then
                PR.HomePhoneNotes = Nothing
            Else
                PR.HomePhoneNotes = Trim(txtHomePhoneNotes.Text)
            End If
            If txtCellPhone.Text = Nothing Then
                PR.CellPhone = Nothing
            Else
                PR.CellPhone = Trim(txtCellPhone.Text)
            End If
            If txtCellPhoneNotes.Text = Nothing Then
                PR.CellPhoneNotes = Nothing
            Else
                PR.CellPhoneNotes = Trim(txtCellPhoneNotes.Text)
            End If
            If txtWorkPhone.Text = Nothing Then
                PR.WorkPhone = Nothing
            Else
                PR.WorkPhone = Trim(txtWorkPhone.Text)
            End If
            If txtWorkPhoneNotes.Text = Nothing Then
                PR.WorkPhoneNotes = Nothing
            Else
                PR.WorkPhoneNotes = Trim(txtWorkPhoneNotes.Text)
            End If
            If txtAlternativePhone.Text = Nothing Then
                PR.AlternativePhone = Nothing
            Else
                PR.AlternativePhone = Trim(txtAlternativePhone.Text)
            End If
            If txtAlternativePhoneNotes.Text = Nothing Then
                PR.AlternativePhoneNotes = Nothing
            Else
                PR.AlternativePhoneNotes = Trim(txtAlternativePhoneNotes.Text)
            End If
            PR.PrimaryPhoneToCall = Trim(ddPrimaryPhoneToCall.SelectedValue)
            If txtPrimaryeMail.Text = Nothing Then
                PR.PrimaryeMail = Nothing
            Else
                PR.PrimaryeMail = Trim(txtPrimaryeMail.Text.ToLower)
            End If
            If txtSecondaryeMail.Text = Nothing Then
                PR.SecondaryeMail = Nothing
            Else
                PR.SecondaryeMail = Trim(txtSecondaryeMail.Text.ToLower)
            End If
            If txtBestTimeToContact.Text = Nothing Then
                PR.BestTimeToContact = Nothing
            Else
                PR.BestTimeToContact = Trim(txtBestTimeToContact.Text)
            End If
            PR.ReferralPhysicianId = Nothing
            PR.ReferralDate = Nothing
            PR.EnterBy = Trim(CkUserName)
            PR.EnterDate = Now.ToString("G")
            PR.ModifyBy = Nothing
            PR.ModifyDate = Nothing

            TPDDCI.tblPatientReferrals.InsertOnSubmit(PR)
            TPDDCI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblDemographicReferral
        Try
            Dim TPDDCII As New MyPortfolioDbDataContext
            Dim DR As New tblDemographicReferral
            DR.pid = CInt(Trim(hfPID.Value))
            DR.DOB = Nothing
            DR.Gender = Nothing
            DR.Ethnicity = Nothing
            DR.Language = Nothing
            DR.MaritalStatus = Nothing
            DR.Religion = Nothing
            DR.NumChildren = Nothing
            DR.SupportNetwork = Nothing
            DR.NewsLetter = Nothing
            DR.InterestsHobbies = Nothing
            DR.HighestLevelOfEducation = Nothing
            DR.MedAdvanceDirectives = False
            DR.GiftForDonor = False
            DR.GiftForRecipient = False
            DR.AcknowledgementDate = Nothing
            DR.PreOpEducationDate = Nothing
            DR.MileageToUHS = Nothing
            DR.RemoteClinic = "8"
            DR.CountryOfOrigin = Trim(txtCountryOfOrigin.Text)
            DR.Comments = Nothing
            DR.EnterBy = Trim(CkUserName)
            DR.EnterDate = Now.ToString("G")
            DR.ModifyBy = Nothing
            DR.ModifyDate = Nothing

            TPDDCII.tblDemographicReferrals.InsertOnSubmit(DR)
            TPDDCII.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        Try
            Dim MyManager = New UserManager()
            MyManager.AddToRole(hfUserId.Value, "Living Donor")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Update Previous Donor Record
    Private Function IsUpdateDonor(ByVal CkUserName As String) As String

        Dim MyNoSSN As New String("SSN000000")
        Dim MyNewPID As Integer = hfPID.Value
        Dim MyLengthPID As Integer = Nothing
        Dim MyNewSSNPID As String = Nothing

        'tblKingsCourtReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim UKCR = (From p In TPDDCUpdateI.tblKingsCourtReferrals
                        Where p.pid.Equals(hfPID.Value)).ToList(0)

            hfSSN.Value = Trim(txtSocialSecurityNumber.Text)
            If hfSSN.Value = Nothing Then
                Dim MyFixSSN As String = Nothing
                MyLengthPID = 9 - hfPID.Value.ToString.Length
                MyFixSSN = Left(MyNoSSN, MyLengthPID)
                MyNewSSNPID = MyFixSSN & MyNewPID
                Dim MyNewSSN As String = MyNewSSNPID.Insert(5, "-").Insert(3, "-")
                hfSSN.Value = MyNewSSN
            Else
                hfSSN.Value = Trim(txtSocialSecurityNumber.Text)
            End If

            UKCR.SSN = hfSSN.Value
            If hfSSN.Value.Contains("SSN") Then
                UKCR.NoSSN = True
            Else
                UKCR.NoSSN = False
            End If
            UKCR.ModifyBy = Trim(CkUserName)
            UKCR.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblPatientReferral
        Try
            Dim TPDDCUpdateII As New MyPortfolioDbDataContext
            Dim UPR = (From p In TPDDCUpdateII.tblPatientReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UPR.FirstName = Trim(StrConv(txtFirstName.Text, VbStrConv.ProperCase))
            If txtMiddleName.Text = Nothing Then
                UPR.MiddleName = Nothing
            Else
                UPR.MiddleName = Trim(StrConv(txtMiddleName.Text, VbStrConv.ProperCase))
            End If
            UPR.LastName = Trim(StrConv(txtLastName.Text, VbStrConv.ProperCase))
            UPR.Address1 = Trim(StrConv(txtAddress1.Text, VbStrConv.ProperCase))
            If txtAddress2.Text = Nothing Then
                UPR.Address2 = Nothing
            Else
                UPR.Address2 = Trim(StrConv(txtAddress2.Text, VbStrConv.ProperCase))
            End If
            UPR.City = Trim(StrConv(txtCity.Text, VbStrConv.ProperCase))
            UPR.State = Trim(ddState.SelectedValue)
            UPR.ZipCode = Trim(txtZipCode.Text)
            UPR.Country = Trim(txtCountry.Text.ToUpper)
            If txtHomePhone.Text = Nothing Then
                UPR.HomePhone = Nothing
            Else
                UPR.HomePhone = Trim(txtHomePhone.Text)
            End If
            If txtHomePhoneNotes.Text = Nothing Then
                UPR.HomePhoneNotes = Nothing
            Else
                UPR.HomePhoneNotes = Trim(txtHomePhoneNotes.Text)
            End If
            If txtCellPhone.Text = Nothing Then
                UPR.CellPhone = Nothing
            Else
                UPR.CellPhone = Trim(txtCellPhone.Text)
            End If
            If txtCellPhoneNotes.Text = Nothing Then
                UPR.CellPhoneNotes = Nothing
            Else
                UPR.CellPhoneNotes = Trim(txtCellPhoneNotes.Text)
            End If
            If txtWorkPhone.Text = Nothing Then
                UPR.WorkPhone = Nothing
            Else
                UPR.WorkPhone = Trim(txtWorkPhone.Text)
            End If
            If txtWorkPhoneNotes.Text = Nothing Then
                UPR.WorkPhoneNotes = Nothing
            Else
                UPR.WorkPhoneNotes = Trim(txtWorkPhoneNotes.Text)
            End If
            If txtAlternativePhone.Text = Nothing Then
                UPR.AlternativePhone = Nothing
            Else
                UPR.AlternativePhone = Trim(txtAlternativePhone.Text)
            End If
            If txtAlternativePhoneNotes.Text = Nothing Then
                UPR.AlternativePhoneNotes = Nothing
            Else
                UPR.AlternativePhoneNotes = Trim(txtAlternativePhoneNotes.Text)
            End If
            UPR.PrimaryPhoneToCall = Trim(ddPrimaryPhoneToCall.SelectedValue)
            If txtPrimaryeMail.Text = Nothing Then
                UPR.PrimaryeMail = Nothing
            Else
                UPR.PrimaryeMail = Trim(txtPrimaryeMail.Text.ToLower)
            End If
            If txtSecondaryeMail.Text = Nothing Then
                UPR.SecondaryeMail = Nothing
            Else
                UPR.SecondaryeMail = Trim(txtSecondaryeMail.Text.ToLower)
            End If
            If txtBestTimeToContact.Text = Nothing Then
                UPR.BestTimeToContact = Nothing
            Else
                UPR.BestTimeToContact = Trim(txtBestTimeToContact.Text)
            End If
            UPR.ModifyBy = Trim(CkUserName)
            UPR.ModifyDate = Now.ToString("G")

            TPDDCUpdateII.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblDemographicReferral
        Try
            Dim TPDDCUpdateIII As New MyPortfolioDbDataContext
            Dim UDR = (From p In TPDDCUpdateIII.tblDemographicReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UDR.CountryOfOrigin = Trim(txtCountryOfOrigin.Text)
            UDR.ModifyBy = Trim(CkUserName)
            UDR.ModifyDate = Now.ToString("G")

            TPDDCUpdateIII.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Overloads Function ConvertToProperCase(ByRef strToConvert As String) As String

        strToConvert = LCase(strToConvert)
        strToConvert = Regex.Replace(strToConvert.ToLower(), "(?<=\b(?: mc|mac)?)[a-zA-Z](?<!'s\b)", Function(m) m.Value.ToUpper())
        'Suffixes "jr", "sr", "i", "ii", "iii", "iv", "v", "vi", "vii", "viii", "ix", "x", "xi", "xii", "xiii", "xiv", "xv"
        strToConvert = strToConvert.Replace("Iii", "III")
        strToConvert = strToConvert.Replace("Ii", "II")

        Return Trim(strToConvert)

    End Function

End Class
