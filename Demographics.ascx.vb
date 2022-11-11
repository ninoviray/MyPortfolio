
Partial Class Controls_Demographics
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
            If hfTabPanelDemographics.Value = "False" Then
                If Not Request.QueryString("D") Is Nothing Then
                    hfUserId.Value = Request.QueryString("D").ToString
                    hfLanguage.Value = Request.QueryString("L").ToString
                    IsPanelControl()
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
            txtDateOfBirth.Focus()
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
            rvDateOfBirth.MaximumValue = DateTime.Today.AddDays(0).ToShortDateString()
            rvDateOfBirth.MinimumValue = DateTime.Today.AddYears(-95).ToShortDateString
            txtDateOfBirth.Attributes.Add("onblur", "Age(this)")

        Else

        End If

    End Sub

    'Set the Language Text, Populate TextBoxs, and Labels
    Private Sub IsPanelControl()

        hfTabPanelDemographics.Value = "True"

        Dim MyAllHiddenItems As String = Nothing
        Dim MyAllHiddenItem As String() = Nothing
        Dim MyLanguageText As New LanguageText
        MyAllHiddenItems = MyLanguageText.CkLanguage(hfLanguage.Value)
        MyAllHiddenItem = MyAllHiddenItems.Split("||")
        hfLanguageText.Value = MyAllHiddenItem(0)
        hfPleaseEnter.Value = MyAllHiddenItem(2)
        hfIsInvalid.Value = MyAllHiddenItem(4)

        Try
            Dim TPDDCRead As New MyPortfolioDbDataContext
            Dim MyDR = (From T In TPDDCRead.lkpDemographicReferrals Select T.DemographicReferral).ToArray

            For Each MyField As String In MyDR
                Dim DemoRefLang As New List(Of String)

                Dim MyLabelText As String = Nothing
                Dim MyTextBoxText As String = Nothing
                Dim MyDropDownListText As String = Nothing
                Dim MyRequiredFieldValidatorText As String = Nothing
                Dim MyRegularExpressionValidatorText As String = Nothing
                Dim MyRangeValidatorText As String = Nothing

                Dim MyCkField As String = Trim(MyField.ToString)
                MyLabelText = "lb" & MyCkField & "Text"
                MyTextBoxText = "txt" & MyCkField
                MyDropDownListText = "dd" & MyCkField
                MyRequiredFieldValidatorText = "rfv" & MyCkField
                MyRegularExpressionValidatorText = "rev" & MyCkField
                MyRangeValidatorText = "rv" & MyCkField

                Dim DR = From p In TPDDCRead.lkpDemographicReferrals
                         Where p.DemographicReferral.ToString().Equals(MyCkField)
                         Select p

                Select Case hfLanguage.Value

                    Case "Eng"
                        Dim DRLE = (From dreng In DR Select dreng.DemographicReferralEnglish).ToList
                        DemoRefLang = DRLE
                    Case "Spa"
                        Dim DRLS = (From drspa In DR Select drspa.DemographicReferralSpanish).ToList
                        DemoRefLang = DRLS
                    Case "Man"
                        Dim DRLM = (From drman In DR Select drman.DemographicReferralMandarin).ToList
                        DemoRefLang = DRLM
                    Case "Ara"
                        Dim DRLA = (From drara In DR Select drara.DemographicReferralArabic).ToList
                        DemoRefLang = DRLA
                    Case "Hin"
                        Dim DRLH = (From drhin In DR Select drhin.DemographicReferralHindiUrdu).ToList
                        DemoRefLang = DRLH
                    Case "Ben"
                        Dim DRLB = (From drben In DR Select drben.DemographicReferralBengali).ToList
                        DemoRefLang = DRLB
                    Case "Por"
                        Dim DRLP = (From drpor In DR Select drpor.DemographicReferralPortuguese).ToList
                        DemoRefLang = DRLP
                    Case "Rus"
                        Dim DRLR = (From drrus In DR Select drrus.DemographicReferralRussian).ToList
                        DemoRefLang = DRLR
                    Case "Jap"
                        Dim DRLJ = (From drjap In DR Select drjap.DemographicReferralJapanese).ToList
                        DemoRefLang = DRLJ
                    Case "Pun"
                        Dim DRLPU = (From drpun In DR Select drpun.DemographicReferralPunjabi).ToList
                        DemoRefLang = DRLPU
                    Case Else
                        Dim DRLEN = (From dreng In DR Select dreng.DemographicReferralEnglish).ToList
                        DemoRefLang = DRLEN
                End Select

                For Each innerCtrl As Object In PanelDemographics.Controls
                    If TypeOf innerCtrl Is Label Then
                        If CType(innerCtrl, Label).ID = MyLabelText Then
                            CType(innerCtrl, Label).Text = DemoRefLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerCtrl Is TextBox Then
                        If CType(innerCtrl, TextBox).ID = MyTextBoxText Then
                            CType(innerCtrl, TextBox).ToolTip = hfPleaseEnter.Value & DemoRefLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerCtrl Is DropDownList Then
                        If CType(innerCtrl, DropDownList).ID = MyDropDownListText Then
                            CType(innerCtrl, DropDownList).ToolTip = hfPleaseEnter.Value & DemoRefLang.FirstOrDefault.ToString & "."
                            Select Case MyCkField

                                Case "Gender"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorGender
                                    CType(innerCtrl, DropDownList).DataTextField = "Gender" & hfLanguageText.Value
                                    LinqDonorGender.OrderBy = "Gender" & hfLanguageText.Value
                                Case "Ethnicity"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorEthnicity
                                    CType(innerCtrl, DropDownList).DataTextField = "Ethnicity" & hfLanguageText.Value
                                    LinqDonorEthnicity.OrderBy = "Ethnicity" & hfLanguageText.Value
                                Case "Language"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorLanguage
                                    CType(innerCtrl, DropDownList).DataTextField = "Language" & hfLanguageText.Value
                                    LinqDonorLanguage.OrderBy = "Language" & hfLanguageText.Value
                                Case "Marital"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorMarital
                                    CType(innerCtrl, DropDownList).DataTextField = "Marital" & hfLanguageText.Value
                                    LinqDonorMarital.OrderBy = "Marital" & hfLanguageText.Value
                                Case "Religion"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorReligion
                                    CType(innerCtrl, DropDownList).DataTextField = "Religion" & hfLanguageText.Value
                                    LinqDonorReligion.OrderBy = "Religion" & hfLanguageText.Value
                                Case "Residency"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorResidency
                                    CType(innerCtrl, DropDownList).DataTextField = "Residency" & hfLanguageText.Value
                                    LinqDonorResidency.OrderBy = "Residency" & hfLanguageText.Value
                                Case "HighestLevelOfEducation"
                                    CType(innerCtrl, DropDownList).DataSource = LinqDonorHighestLevelOfEducation
                                    CType(innerCtrl, DropDownList).DataTextField = "Description" & hfLanguageText.Value
                                    LinqDonorHighestLevelOfEducation.OrderBy = "Description" & hfLanguageText.Value
                                Case Else

                            End Select
                            CType(innerCtrl, DropDownList).DataValueField = "Id"
                            CType(innerCtrl, DropDownList).DataBind()
                        End If
                    End If
                    If TypeOf innerCtrl Is RequiredFieldValidator Then
                        If CType(innerCtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerCtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & DemoRefLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                    If TypeOf innerCtrl Is RegularExpressionValidator Then
                        If CType(innerCtrl, RegularExpressionValidator).ID = MyRegularExpressionValidatorText Then
                            CType(innerCtrl, RegularExpressionValidator).ErrorMessage = DemoRefLang.FirstOrDefault.ToString & hfIsInvalid.Value
                        End If
                    End If
                    If TypeOf innerCtrl Is RangeValidator Then
                        If CType(innerCtrl, RangeValidator).ID = MyRangeValidatorText Then
                            CType(innerCtrl, RangeValidator).ErrorMessage = DemoRefLang.FirstOrDefault.ToString & hfIsInvalid.Value
                        End If
                    End If
                Next innerCtrl
            Next MyField
        Catch ex As Exception

        End Try

    End Sub

    'Insert New Donor Record
    Private Function IsNewDonor(ByVal CkUserName As String) As String

        'tblPatientReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim UPR = (From p In TPDDCUpdateI.tblPatientReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UPR.Residency = Trim(ddResidency.SelectedValue)
            UPR.ModifyBy = Trim(CkUserName)
            UPR.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblDemographicReferral
        Try
            Dim TPDDCUpdateII As New MyPortfolioDbDataContext
            Dim UDR = (From p In TPDDCUpdateII.tblDemographicReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UDR.DOB = Trim(txtDateOfBirth.Text)
            UDR.Gender = Trim(ddGender.SelectedValue)
            UDR.Ethnicity = Trim(ddEthnicity.SelectedValue)
            UDR.Language = Trim(ddLanguage.SelectedValue)
            UDR.MaritalStatus = Trim(ddMarital.SelectedValue)
            UDR.Religion = Trim(ddReligion.SelectedValue)
            UDR.HighestLevelOfEducation = Trim(ddHighestLevelOfEducation.SelectedValue)
            UDR.ModifyBy = Trim(CkUserName)
            UDR.ModifyDate = Now.ToString("G")

            TPDDCUpdateII.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        Try
            Dim MyManager = New UserManager()
            MyManager.AddToRole(hfUserId.Value, "Demographics")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Update Previous Donor Record
    Private Function IsUpdateDonor(ByVal CkUserName As String) As String


        'tblPatientReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim UPR = (From p In TPDDCUpdateI.tblPatientReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UPR.Residency = Trim(ddResidency.SelectedValue)
            UPR.ModifyBy = Trim(CkUserName)
            UPR.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        'tblDemographicReferral
        Try
            Dim TPDDCUpdateII As New MyPortfolioDbDataContext
            Dim UDR = (From p In TPDDCUpdateII.tblDemographicReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            UDR.DOB = Trim(txtDateOfBirth.Text)
            UDR.Gender = Trim(ddGender.SelectedValue)
            UDR.Ethnicity = Trim(ddEthnicity.SelectedValue)
            UDR.Language = Trim(ddLanguage.SelectedValue)
            UDR.MaritalStatus = Trim(ddMarital.SelectedValue)
            UDR.Religion = Trim(ddReligion.SelectedValue)
            UDR.HighestLevelOfEducation = Trim(ddHighestLevelOfEducation.SelectedValue)
            UDR.ModifyBy = Trim(CkUserName)
            UDR.ModifyDate = Now.ToString("G")

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
