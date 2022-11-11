
Partial Class Controls_TransplantInstitute
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
            If hfTabPanelTransplantInstitute.Value = "False" Then
                If Not Request.QueryString("D") Is Nothing Then
                    hfUserId.Value = Request.QueryString("D").ToString
                    hfLanguage.Value = Request.QueryString("L").ToString
                    IsPanelControl()
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
            cbKidneyDonor.Focus()
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
            rvRecipientDateOfBirth.MaximumValue = DateTime.Today.AddDays(0).ToShortDateString()
            rvRecipientDateOfBirth.MinimumValue = DateTime.Today.AddYears(-115).ToShortDateString

        Else

        End If

    End Sub

    'Set the Language Text, Populate TextBoxs, and Labels
    Private Sub IsPanelControl()

        hfTabPanelTransplantInstitute.Value = "True"

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
            Dim MyPR = (From T In TPDDCReadI.lkpTransplantReferrals Select T.TransplantReferral).ToArray

            For Each MyField As String In MyPR
                Dim DonPreLang As New List(Of String)

                Dim MyLabelText As String = Nothing
                Dim MyTextBoxText As String = Nothing
                Dim MyCheckBoxText As String = Nothing
                Dim MyRadioButtonListText As String = Nothing
                Dim MyDropDownListText As String = Nothing
                Dim MyCustomValidatorText As String = Nothing
                Dim MyRequiredFieldValidatorText As String = Nothing
                Dim MyRegularExpressionValidatorText As String = Nothing
                Dim MyRangeValidatorText As String = Nothing

                Dim MyCkField As String = Trim(MyField.ToString)
                MyLabelText = "lb" & MyCkField & "Text"
                MyTextBoxText = "txt" & MyCkField
                MyCheckBoxText = "cb" & MyCkField
                MyRadioButtonListText = "rbl" & MyCkField
                MyDropDownListText = "dd" & MyCkField
                MyCustomValidatorText = "cv" & MyCkField
                MyRequiredFieldValidatorText = "rfv" & MyCkField
                MyRegularExpressionValidatorText = "rev" & MyCkField
                MyRangeValidatorText = "rv" & MyCkField

                Dim TPDDCReadII As New MyPortfolioDbDataContext
                Dim PR = From p In TPDDCReadII.lkpTransplantReferrals
                         Where p.TransplantReferral.ToString().Equals(MyCkField)
                         Select p

                Select Case hfLanguage.Value

                    Case "Eng"
                        Dim PRLE = (From preng In PR Select preng.TransplantReferralEnglish).ToList
                        DonPreLang = PRLE
                    Case "Spa"
                        Dim PRLS = (From prspa In PR Select prspa.TransplantReferralSpanish).ToList
                        DonPreLang = PRLS
                    Case "Man"
                        Dim PRLM = (From prman In PR Select prman.TransplantReferralMandarin).ToList
                        DonPreLang = PRLM
                    Case "Ara"
                        Dim PRLA = (From prara In PR Select prara.TransplantReferralArabic).ToList
                        DonPreLang = PRLA
                    Case "Hin"
                        Dim PRLH = (From prhin In PR Select prhin.TransplantReferralHindiUrdu).ToList
                        DonPreLang = PRLH
                    Case "Ben"
                        Dim PRLB = (From prben In PR Select prben.TransplantReferralBengali).ToList
                        DonPreLang = PRLB
                    Case "Por"
                        Dim PRLP = (From prpor In PR Select prpor.TransplantReferralPortuguese).ToList
                        DonPreLang = PRLP
                    Case "Rus"
                        Dim PRLR = (From prrus In PR Select prrus.TransplantReferralRussian).ToList
                        DonPreLang = PRLR
                    Case "Jap"
                        Dim PRLJ = (From prjap In PR Select prjap.TransplantReferralJapanese).ToList
                        DonPreLang = PRLJ
                    Case "Pun"
                        Dim PRLPU = (From prpun In PR Select prpun.TransplantReferralPunjabi).ToList
                        DonPreLang = PRLPU
                    Case Else
                        Dim PRLEN = (From preng In PR Select preng.TransplantReferralEnglish).ToList
                        DonPreLang = PRLEN
                End Select

                For Each innerPTICtrl As Control In PanelTransplantInstitute.Controls
                    If TypeOf innerPTICtrl Is Label Then
                        If CType(innerPTICtrl, Label).ID = MyLabelText Then
                            CType(innerPTICtrl, Label).Text = DonPreLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerPTICtrl Is CheckBox Then
                        If CType(innerPTICtrl, CheckBox).ID = MyCheckBoxText Then
                            CType(innerPTICtrl, CheckBox).Text = DonPreLang.FirstOrDefault.ToString
                            CType(innerPTICtrl, CheckBox).ToolTip = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerPTICtrl Is TextBox Then
                        If CType(innerPTICtrl, TextBox).ID = MyTextBoxText Then
                            CType(innerPTICtrl, TextBox).ToolTip = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerPTICtrl Is RadioButtonList Then
                        If CType(innerPTICtrl, RadioButtonList).ID = MyRadioButtonListText Then
                            CType(innerPTICtrl, RadioButtonList).ToolTip = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "."
                            Select Case MyCkField

                                Case "DonationType"
                                    CType(innerPTICtrl, RadioButtonList).DataSource = LinqDonationType
                                    CType(innerPTICtrl, RadioButtonList).DataTextField = "DonationType" & hfLanguageText.Value
                                    LinqDonationType.OrderBy = "DonationType" & hfLanguageText.Value
                                Case Else

                            End Select
                            CType(innerPTICtrl, RadioButtonList).DataValueField = "Id"
                            CType(innerPTICtrl, RadioButtonList).DataBind()
                        End If
                    End If
                    If TypeOf innerPTICtrl Is CustomValidator Then
                        If CType(innerPTICtrl, CustomValidator).ID = MyCustomValidatorText Then
                            CType(innerPTICtrl, CustomValidator).ErrorMessage = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                    If TypeOf innerPTICtrl Is RequiredFieldValidator Then
                        If CType(innerPTICtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerPTICtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                Next innerPTICtrl

                For Each innerPRCtrl As Control In PanelRecipient.Controls
                    If TypeOf innerPRCtrl Is Label Then
                        If CType(innerPRCtrl, Label).ID = MyLabelText Then
                            CType(innerPRCtrl, Label).Text = DonPreLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerPRCtrl Is RadioButtonList Then
                        If CType(innerPRCtrl, RadioButtonList).ID = MyRadioButtonListText Then
                            CType(innerPRCtrl, RadioButtonList).ToolTip = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "."
                            Select Case MyCkField

                                Case "RecipientCurrentlyPatient"
                                    CType(innerPRCtrl, RadioButtonList).DataSource = LinqRecipientCurrentlyPatient
                                    CType(innerPRCtrl, RadioButtonList).DataTextField = "RecipientCurrentlyPatient" & hfLanguageText.Value
                                    LinqRecipientCurrentlyPatient.OrderBy = "RecipientCurrentlyPatient" & hfLanguageText.Value
                                Case "RecipientChildAdult"
                                    CType(innerPRCtrl, RadioButtonList).DataSource = LinqRecipientChildAdult
                                    CType(innerPRCtrl, RadioButtonList).DataTextField = "RecipientChildAdult" & hfLanguageText.Value
                                    LinqRecipientChildAdult.OrderBy = "RecipientChildAdult" & hfLanguageText.Value
                                Case Else

                            End Select
                            CType(innerPRCtrl, RadioButtonList).DataValueField = "Id"
                            CType(innerPRCtrl, RadioButtonList).DataBind()
                        End If
                    End If
                    If TypeOf innerPRCtrl Is RequiredFieldValidator Then
                        If CType(innerPRCtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerPRCtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                Next innerPRCtrl

                For Each innerPRCPCtrl As Control In PanelRecipientCurrentlyPatient.Controls
                    If TypeOf innerPRCPCtrl Is Label Then
                        If CType(innerPRCPCtrl, Label).ID = MyLabelText Then
                            CType(innerPRCPCtrl, Label).Text = DonPreLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerPRCPCtrl Is TextBox Then
                        If CType(innerPRCPCtrl, TextBox).ID = MyTextBoxText Then
                            CType(innerPRCPCtrl, TextBox).ToolTip = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerPRCPCtrl Is DropDownList Then
                        If CType(innerPRCPCtrl, DropDownList).ID = MyDropDownListText Then
                            CType(innerPRCPCtrl, DropDownList).ToolTip = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "."
                            Select Case MyCkField

                                Case "RecipientRelationship"
                                    CType(innerPRCPCtrl, DropDownList).DataSource = LinqRecipientRelationship
                                    CType(innerPRCPCtrl, DropDownList).DataTextField = "Relationship" & hfLanguageText.Value
                                    LinqRecipientRelationship.OrderBy = "Relationship" & hfLanguageText.Value
                                Case Else

                            End Select
                            CType(innerPRCPCtrl, DropDownList).DataValueField = "Id"
                            CType(innerPRCPCtrl, DropDownList).DataBind()
                        End If
                    End If
                    If TypeOf innerPRCPCtrl Is RequiredFieldValidator Then
                        If CType(innerPRCPCtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerPRCPCtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & DonPreLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                    If TypeOf innerPRCPCtrl Is RangeValidator Then
                        If CType(innerPRCPCtrl, RangeValidator).ID = MyRangeValidatorText Then
                            CType(innerPRCPCtrl, RangeValidator).ErrorMessage = DonPreLang.FirstOrDefault.ToString & hfIsInvalid.Value
                        End If
                    End If
                Next innerPRCPCtrl
            Next MyField
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub rblDonationType_SelectedIndexChanged(sender As Object, e As EventArgs)

        If rblDonationType.SelectedItem.Value = 2 Then
            PanelRecipient.Visible = True
        Else
            PanelRecipient.Visible = False
            PanelRecipientCurrentlyPatient.Visible = False
            rblRecipientCurrentlyPatient.SelectedValue = Nothing
            txtRecipientFirstName.Text = Nothing
            txtRecipientMiddleName.Text = Nothing
            txtRecipientLastName.Text = Nothing
            txtRecipientDateOfBirth.Text = Nothing
            ddRecipientRelationship.SelectedValue = Nothing
            rblRecipientChildAdult.SelectedValue = Nothing
        End If

    End Sub

    Protected Sub rblRecipientCurrentlyPatient_SelectedIndexChanged(sender As Object, e As EventArgs)

        If rblRecipientCurrentlyPatient.SelectedItem.Value = 1 Then
            PanelRecipientCurrentlyPatient.Visible = True
            txtRecipientFirstName.Focus()
        Else
            PanelRecipientCurrentlyPatient.Visible = False
            txtRecipientFirstName.Text = Nothing
            txtRecipientMiddleName.Text = Nothing
            txtRecipientLastName.Text = Nothing
            txtRecipientDateOfBirth.Text = Nothing
            ddRecipientRelationship.SelectedValue = Nothing
            rblRecipientChildAdult.SelectedValue = Nothing
        End If

    End Sub

    Protected Sub OrganDonating_Validate(ByVal source As Object, ByVal args As ServerValidateEventArgs)

        If cbKidneyDonor.Checked = True Or cbLiverDonor.Checked = True Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If

    End Sub

    'Insert New Donor Record
    Private Function IsNewDonor(ByVal CkUserName As String) As String

        'tblKingsCourtReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim KCR = (From p In TPDDCUpdateI.tblKingsCourtReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            KCR.DonorKidney = cbKidneyDonor.Checked
            KCR.DonorLiver = cbLiverDonor.Checked
            KCR.ModifyBy = Trim(CkUserName)
            KCR.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblTransplantReferral
        Try
            Dim TPDDCI As New MyPortfolioDbDataContext
            Dim TR As New tblTransplantDonorReferral
            TR.pid = CInt(Trim(hfPID.Value))
            TR.DonationType = Trim(rblDonationType.SelectedValue)
            If rblRecipientCurrentlyPatient.SelectedValue = Nothing Then
                TR.RecipientCurrentlyPatient = "2"
            Else
                TR.RecipientCurrentlyPatient = Trim(rblRecipientCurrentlyPatient.SelectedValue)
            End If
            If rblRecipientChildAdult.SelectedValue = Nothing Then
                TR.RecipientChildAdult = "3"
            Else
                TR.RecipientChildAdult = Trim(rblRecipientChildAdult.SelectedValue)
            End If
            TR.EnterBy = Trim(CkUserName)
            TR.EnterDate = Now.ToString("G")
            TR.ModifyBy = Nothing
            TR.ModifyDate = Nothing

            TPDDCI.tblTransplantDonorReferrals.InsertOnSubmit(TR)
            TPDDCI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblContactReferral
        Try
            Dim TPDDCII As New MyPortfolioDbDataContext
            Dim CR As New tblContactReferral
            CR.pid = CInt(Trim(hfPID.Value))
            CR.LivingContact = True
            If rblRecipientCurrentlyPatient.SelectedValue = "1" Then
                CR.oFirst1 = Trim(StrConv(txtRecipientFirstName.Text, VbStrConv.ProperCase))
                If txtRecipientMiddleName.Text = Nothing Then
                    CR.oMid1 = Nothing
                Else
                    CR.oMid1 = Trim(txtRecipientMiddleName.Text.ToUpper)
                End If
                CR.oLast1 = ConvertToProperCase(txtRecipientLastName.Text)
                CR.oRelationship1 = ddRecipientRelationship.SelectedValue
                CR.oDOB = Trim(txtRecipientDateOfBirth.Text)
                CR.Comments = "Potential Donor for Reciepent: " & Trim(StrConv(txtRecipientFirstName.Text, VbStrConv.ProperCase)) &
                    " " & ConvertToProperCase(txtRecipientLastName.Text) & " DOB: " & Trim(txtRecipientDateOfBirth.Text)
            End If
            CR.oPotentialDonor1 = False
            CR.oPotentialDonor2 = False
            CR.oPotentialDonor3 = False
            CR.oPotentialDonor4 = False
            CR.oPotentialDonor5 = False
            CR.EnterBy = Trim(CkUserName)
            CR.EnterDate = Now.ToString("G")
            CR.ModifyBy = Nothing
            CR.ModifyDate = Nothing

            TPDDCII.tblContactReferrals.InsertOnSubmit(CR)
            TPDDCII.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        Try
            Dim MyManager = New UserManager()
            MyManager.AddToRole(hfUserId.Value, "Transplant Institute")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Update Previous Donor Record
    Private Function IsUpdateDonor(ByVal CkUserName As String) As String

        'tblKingsCourtReferral
        Try
            Dim TPDDCUpdateII As New MyPortfolioDbDataContext
            Dim UKCR = (From p In TPDDCUpdateII.tblKingsCourtReferrals
                        Where p.pid.Equals(hfPID.Value)).ToList(0)

            UKCR.DonorKidney = cbKidneyDonor.Checked
            UKCR.DonorLiver = cbLiverDonor.Checked
            UKCR.ModifyBy = Trim(CkUserName)
            UKCR.ModifyDate = Now.ToString("G")

            TPDDCUpdateII.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblTransplantReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim UDo = (From p In TPDDCUpdateI.tblTransplantDonorReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UDo.DonationType = rblDonationType.SelectedValue
            If rblRecipientCurrentlyPatient.SelectedValue = Nothing Then
                UDo.RecipientCurrentlyPatient = "2"
            Else
                UDo.RecipientCurrentlyPatient = rblRecipientCurrentlyPatient.SelectedValue
            End If
            If rblRecipientChildAdult.SelectedValue = Nothing Then
                UDo.RecipientChildAdult = "3"
            Else
                UDo.RecipientChildAdult = rblRecipientChildAdult.SelectedValue
            End If
            UDo.ModifyBy = Trim(CkUserName)
            UDo.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblContactReferral
        Try
            Dim TPDDCUpdateII As New MyPortfolioDbDataContext
            Dim UC = (From p In TPDDCUpdateII.tblContactReferrals
                      Where p.pid.Equals(hfPID.Value)).ToList(0)

            If rblRecipientCurrentlyPatient.SelectedValue = "1" Then
                UC.oFirst1 = Trim(StrConv(txtRecipientFirstName.Text, VbStrConv.ProperCase))
                If txtRecipientMiddleName.Text = Nothing Then
                    UC.oMid1 = Nothing
                Else
                    UC.oMid1 = Trim(txtRecipientMiddleName.Text.ToUpper)
                End If
                UC.oLast1 = ConvertToProperCase(txtRecipientLastName.Text)
                UC.oRelationship1 = ddRecipientRelationship.SelectedValue
                UC.oDOB = Trim(txtRecipientDateOfBirth.Text)
            Else
                UC.oFirst1 = Nothing
                UC.oMid1 = Nothing
                UC.oLast1 = Nothing
                UC.oRelationship1 = Nothing
                UC.oDOB = Nothing
            End If
            UC.ModifyBy = Trim(CkUserName)
            UC.ModifyDate = Now.ToString("G")

            TPDDCUpdateII.SubmitChanges()
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
