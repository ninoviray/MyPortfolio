
Partial Class Controls_Insurance
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
            If hfTabPanelInsurance.Value = "False" Then
                If Not Request.QueryString("D") Is Nothing Then
                    hfUserId.Value = Request.QueryString("D").ToString
                    hfLanguage.Value = Request.QueryString("L").ToString
                    IsPanelControl()
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
            txtPrimaryInsurance.Focus()
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
            'Put Date Range Validator Here!!!


        Else

        End If

    End Sub

    'Set the Language Text, Populate TextBoxs, and Labels
    Private Sub IsPanelControl()

        hfTabPanelInsurance.Value = "True"

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
            Dim MyIR = (From T In TPDDCReadI.lkpInsuranceReferrals Select T.InsuranceReferral).ToArray

            For Each MyField As String In MyIR
                Dim InsRefLang As New List(Of String)

                Dim MyLabelText As String = Nothing
                Dim MyTextBoxText As String = Nothing
                Dim MyRequiredFieldValidatorText As String = Nothing
                Dim MyRegularExpressionValidatorText As String = Nothing

                Dim MyCkField As String = Trim(MyField.ToString)
                MyLabelText = "lb" & MyCkField & "Text"
                MyTextBoxText = "txt" & MyCkField
                MyRequiredFieldValidatorText = "rfv" & MyCkField
                MyRegularExpressionValidatorText = "rev" & MyCkField

                Dim TPDDCReadII As New MyPortfolioDbDataContext
                Dim IR = From p In TPDDCReadII.lkpInsuranceReferrals
                         Where p.InsuranceReferral.ToString().Equals(MyCkField)
                         Select p

                Select Case hfLanguage.Value

                    Case "Eng"
                        Dim IRLE = (From ireng In IR Select ireng.InsuranceReferralEnglish).ToList
                        InsRefLang = IRLE
                    Case "Spa"
                        Dim IRLS = (From irspa In IR Select irspa.InsuranceReferralSpanish).ToList
                        InsRefLang = IRLS
                    Case "Man"
                        Dim IRLM = (From irman In IR Select irman.InsuranceReferralMandarin).ToList
                        InsRefLang = IRLM
                    Case "Ara"
                        Dim IRLA = (From irara In IR Select irara.InsuranceReferralArabic).ToList
                        InsRefLang = IRLA
                    Case "Hin"
                        Dim IRLH = (From irhin In IR Select irhin.InsuranceReferralHindiUrdu).ToList
                        InsRefLang = IRLH
                    Case "Ben"
                        Dim IRLB = (From irben In IR Select irben.InsuranceReferralBengali).ToList
                        InsRefLang = IRLB
                    Case "Por"
                        Dim IRLP = (From irpor In IR Select irpor.InsuranceReferralPortuguese).ToList
                        InsRefLang = IRLP
                    Case "Rus"
                        Dim IRLR = (From irrus In IR Select irrus.InsuranceReferralRussian).ToList
                        InsRefLang = IRLR
                    Case "Jap"
                        Dim IRLJ = (From irjap In IR Select irjap.InsuranceReferralJapanese).ToList
                        InsRefLang = IRLJ
                    Case "Pun"
                        Dim IRLPU = (From irpun In IR Select irpun.InsuranceReferralPunjabi).ToList
                        InsRefLang = IRLPU
                    Case Else
                        Dim IRLEN = (From ireng In IR Select ireng.InsuranceReferralEnglish).ToList
                        InsRefLang = IRLEN
                End Select

                For Each innerCtrl As Object In PanelInsurance.Controls
                    If TypeOf innerCtrl Is Label Then
                        If CType(innerCtrl, Label).ID = MyLabelText Then
                            CType(innerCtrl, Label).Text = InsRefLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerCtrl Is TextBox Then
                        If CType(innerCtrl, TextBox).ID = MyTextBoxText Then
                            CType(innerCtrl, TextBox).ToolTip = hfPleaseEnter.Value & InsRefLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerCtrl Is RequiredFieldValidator Then
                        If CType(innerCtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerCtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & InsRefLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                    If TypeOf innerCtrl Is RegularExpressionValidator Then
                        If CType(innerCtrl, RegularExpressionValidator).ID = MyRegularExpressionValidatorText Then
                            CType(innerCtrl, RegularExpressionValidator).ErrorMessage = InsRefLang.FirstOrDefault.ToString & hfIsInvalid.Value
                        End If
                    End If
                Next innerCtrl
            Next MyField
        Catch ex As Exception

        End Try

    End Sub

    'Insert New Donor Record
    Private Function IsNewDonor(ByVal CkUserName As String) As String

        'tblFinancialInsuranceReferral
        Try
            Dim TPDDCI As New MyPortfolioDbDataContext
            Dim IR As New tblFinancialInsuranceReferral
            IR.pid = CInt(Trim(hfPID.Value))
            IR.ReferralDate = Now.ToString("G")
            IR.ReferralType = "23"
            If (txtSecondaryInsurance.Text = Nothing And txtSecondaryInsuranceId.Text = Nothing And
                txtSecondaryInsurancePhone.Text = Nothing And txtSecondaryInsuranceGroup.Text = Nothing) Then
                IR.PrimarySecondary = "1"
            Else
                IR.PrimarySecondary = "2"
            End If
            IR.PrimaryInsurance = Trim(txtPrimaryInsurance.Text)
            If txtPrimaryInsuranceId.Text = Nothing Then
                IR.PrimaryInsuranceId = Nothing
            Else
                IR.PrimaryInsuranceId = Trim(txtPrimaryInsuranceId.Text).ToUpper
            End If
            If txtPrimaryInsuranceGroup.Text = Nothing Then
                IR.PrimaryInsuranceGroup = Nothing
            Else
                IR.PrimaryInsuranceGroup = Trim(txtPrimaryInsuranceGroup.Text).ToUpper
            End If
            If txtPrimaryInsurancePhone.Text = Nothing Then
                IR.PrimaryInsurancePhone = Nothing
            Else
                IR.PrimaryInsurancePhone = Trim(txtPrimaryInsurancePhone.Text)
            End If
            IR.Employment = Trim(txtEmployment.Text)
            If txtSecondaryInsurance.Text = Nothing Then
                IR.SecondaryInsurance = Nothing
            Else
                IR.SecondaryInsurance = Trim(txtSecondaryInsurance.Text)
            End If
            If txtSecondaryInsuranceId.Text = Nothing Then
                IR.SecondaryInsuranceId = Nothing
            Else
                IR.SecondaryInsuranceId = Trim(txtSecondaryInsuranceId.Text).ToUpper
            End If
            If txtSecondaryInsuranceGroup.Text = Nothing Then
                IR.SecondaryInsuranceGroup = Nothing
            Else
                IR.SecondaryInsuranceGroup = Trim(txtSecondaryInsuranceGroup.Text).ToUpper
            End If
            If txtSecondaryInsurancePhone.Text = Nothing Then
                IR.SecondaryInsurancePhone = Nothing
            Else
                IR.SecondaryInsurancePhone = Trim(txtSecondaryInsurancePhone.Text)
            End If
            If txtInsuranceComments.Text = Nothing Then
                IR.InsuranceComments = Nothing
            Else
                IR.InsuranceComments = Trim(txtInsuranceComments.Text)
            End If
            IR.Active = True
            IR.EnterBy = Trim(CkUserName)
            IR.EnterDate = Now.ToString("G")
            IR.ModifyBy = Nothing
            IR.ModifyDate = Nothing

            TPDDCI.tblFinancialInsuranceReferrals.InsertOnSubmit(IR)
            TPDDCI.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        Try
            Dim MyManager = New UserManager()
            MyManager.AddToRole(hfUserId.Value, "Insurance")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Update Previous Donor Record
    Private Function IsUpdateDonor(ByVal CkUserName As String) As String

        'tblFinancialInsuranceReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim FIR = (From p In TPDDCUpdateI.tblFinancialInsuranceReferrals
                       Where p.pid.Equals(hfPID.Value)).ToList(0)

            FIR.ReferralDate = Now.ToString("G")
            If (txtSecondaryInsurance.Text = Nothing And txtSecondaryInsuranceId.Text = Nothing And
                txtSecondaryInsurancePhone.Text = Nothing And txtSecondaryInsuranceGroup.Text = Nothing) Then
                FIR.PrimarySecondary = "1"
            Else
                FIR.PrimarySecondary = "2"
            End If
            FIR.PrimaryInsurance = Trim(txtPrimaryInsurance.Text)
            If txtPrimaryInsuranceId.Text = Nothing Then
                FIR.PrimaryInsuranceId = Nothing
            Else
                FIR.PrimaryInsuranceId = Trim(txtPrimaryInsuranceId.Text).ToUpper
            End If
            If txtPrimaryInsuranceGroup.Text = Nothing Then
                FIR.PrimaryInsuranceGroup = Nothing
            Else
                FIR.PrimaryInsuranceGroup = Trim(txtPrimaryInsuranceGroup.Text).ToUpper
            End If
            If txtPrimaryInsurancePhone.Text = Nothing Then
                FIR.PrimaryInsurancePhone = Nothing
            Else
                FIR.PrimaryInsurancePhone = Trim(txtPrimaryInsurancePhone.Text)
            End If
            FIR.Employment = Trim(txtEmployment.Text)
            If txtSecondaryInsurance.Text = Nothing Then
                FIR.SecondaryInsurance = Nothing
            Else
                FIR.SecondaryInsurance = Trim(txtSecondaryInsurance.Text)
            End If
            If txtSecondaryInsuranceId.Text = Nothing Then
                FIR.SecondaryInsuranceId = Nothing
            Else
                FIR.SecondaryInsuranceId = Trim(txtSecondaryInsuranceId.Text).ToUpper
            End If
            If txtSecondaryInsuranceGroup.Text = Nothing Then
                FIR.SecondaryInsuranceGroup = Nothing
            Else
                FIR.SecondaryInsuranceGroup = Trim(txtSecondaryInsuranceGroup.Text).ToUpper
            End If
            If txtSecondaryInsurancePhone.Text = Nothing Then
                FIR.SecondaryInsurancePhone = Nothing
            Else
                FIR.SecondaryInsurancePhone = Trim(txtSecondaryInsurancePhone.Text)
            End If
            If txtInsuranceComments.Text = Nothing Then
                FIR.InsuranceComments = Nothing
            Else
                FIR.InsuranceComments = Trim(txtInsuranceComments.Text)
            End If
            FIR.ModifyBy = Trim(CkUserName)
            FIR.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
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
