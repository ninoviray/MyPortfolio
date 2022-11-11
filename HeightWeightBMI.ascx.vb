
Partial Class Controls_HeightWeightBMI
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
            If hfTabPanelHeightWeightBMI.Value = "False" Then
                If Not Request.QueryString("D") Is Nothing Then
                    hfUserId.Value = Request.QueryString("D").ToString
                    hfLanguage.Value = Request.QueryString("L").ToString
                    IsPanelControl()
                Else
                    Response.Redirect("Default.aspx")
                End If
            End If
            txtHeightFeet.Focus()
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
            txtHeightCM.Attributes.Add("onkeyup", "setBMINew('" + txtHeightCM.ClientID + "','" + txtWeightKG.ClientID + "','" + txtHeightFeet.ClientID + "','" + txtHeightInches.ClientID + "','" + txtWeightPounds.ClientID + "','" + txtBMI.ClientID + "',event)")
            txtWeightKG.Attributes.Add("onkeyup", "setBMINew('" + txtHeightCM.ClientID + "','" + txtWeightKG.ClientID + "','" + txtHeightFeet.ClientID + "','" + txtHeightInches.ClientID + "','" + txtWeightPounds.ClientID + "','" + txtBMI.ClientID + "',event)")
            txtHeightFeet.Attributes.Add("onkeyup", "setBMINew('" + txtHeightCM.ClientID + "','" + txtWeightKG.ClientID + "','" + txtHeightFeet.ClientID + "','" + txtHeightInches.ClientID + "','" + txtWeightPounds.ClientID + "','" + txtBMI.ClientID + "',event)")
            txtHeightInches.Attributes.Add("onkeyup", "setBMINew('" + txtHeightCM.ClientID + "','" + txtWeightKG.ClientID + "','" + txtHeightFeet.ClientID + "','" + txtHeightInches.ClientID + "','" + txtWeightPounds.ClientID + "','" + txtBMI.ClientID + "',event)")
            txtWeightPounds.Attributes.Add("onkeyup", "setBMINew('" + txtHeightCM.ClientID + "','" + txtWeightKG.ClientID + "','" + txtHeightFeet.ClientID + "','" + txtHeightInches.ClientID + "','" + txtWeightPounds.ClientID + "','" + txtBMI.ClientID + "',event)")

        Else
            Try
                txtBMI.Text = Math.Round((Convert.ToInt32(txtWeightPounds.Text) * 703) /
                                             ((Convert.ToInt32(txtHeightFeet.Text) * 12 +
                                             Convert.ToInt32(txtHeightInches.Text)) *
                                             (Convert.ToInt32(txtHeightFeet.Text) * 12 +
                                             Convert.ToInt32(txtHeightInches.Text))), 2)
            Catch ex As Exception
                txtBMI.Text = "Auto"
            End Try
        End If

    End Sub

    'Set the Language Text, Populate TextBoxs, and Labels
    Private Sub IsPanelControl()

        hfTabPanelHeightWeightBMI.Value = "True"

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
            Dim MyHWB = (From T In TPDDCReadI.lkpHtWtBMIReferrals Select T.HtWtBMIReferral).ToArray

            For Each MyField As String In MyHWB
                Dim BMIRefLang As New List(Of String)

                Dim MyLabelText As String = Nothing
                Dim MyTextBoxText As String = Nothing
                Dim MyRequiredFieldValidatorText As String = Nothing
                Dim MyRangeValidatorText As String = Nothing

                Dim MyCkField As String = Trim(MyField.ToString)
                MyLabelText = "lb" & MyCkField & "Text"
                MyTextBoxText = "txt" & MyCkField
                MyRequiredFieldValidatorText = "rfv" & MyCkField
                MyRangeValidatorText = "rv" & MyCkField

                Dim TPDDCReadII As New MyPortfolioDbDataContext
                Dim BR = From p In TPDDCReadII.lkpHtWtBMIReferrals
                         Where p.HtWtBMIReferral.ToString().Equals(MyCkField)
                         Select p

                Select Case hfLanguage.Value

                    Case "Eng"
                        Dim BRLE = (From breng In BR Select breng.HtWtBMIReferralEnglish).ToList
                        BMIRefLang = BRLE
                    Case "Spa"
                        Dim BRLS = (From brspa In BR Select brspa.HtWtBMIReferralSpanish).ToList
                        BMIRefLang = BRLS
                    Case "Man"
                        Dim BRLM = (From brman In BR Select brman.HtWtBMIReferralMandarin).ToList
                        BMIRefLang = BRLM
                    Case "Ara"
                        Dim BRLA = (From brara In BR Select brara.HtWtBMIReferralArabic).ToList
                        BMIRefLang = BRLA
                    Case "Hin"
                        Dim BRLH = (From brhin In BR Select brhin.HtWtBMIReferralHindiUrdu).ToList
                        BMIRefLang = BRLH
                    Case "Ben"
                        Dim BRLB = (From brben In BR Select brben.HtWtBMIReferralBengali).ToList
                        BMIRefLang = BRLB
                    Case "Por"
                        Dim BRLP = (From brpor In BR Select brpor.HtWtBMIReferralPortuguese).ToList
                        BMIRefLang = BRLP
                    Case "Rus"
                        Dim BRLR = (From brrus In BR Select brrus.HtWtBMIReferralRussian).ToList
                        BMIRefLang = BRLR
                    Case "Jap"
                        Dim BRLJ = (From brjap In BR Select brjap.HtWtBMIReferralJapanese).ToList
                        BMIRefLang = BRLJ
                    Case "Pun"
                        Dim BRLPU = (From brpun In BR Select brpun.HtWtBMIReferralPunjabi).ToList
                        BMIRefLang = BRLPU
                    Case Else
                        Dim BRLEN = (From breng In BR Select breng.HtWtBMIReferralEnglish).ToList
                        BMIRefLang = BRLEN
                End Select

                For Each innerCtrl As Control In PanelHeightWeightBMI.Controls
                    If TypeOf innerCtrl Is Label Then
                        If CType(innerCtrl, Label).ID = MyLabelText Then
                            CType(innerCtrl, Label).Text = BMIRefLang.FirstOrDefault.ToString & ":"
                        End If
                    End If
                    If TypeOf innerCtrl Is TextBox Then
                        If CType(innerCtrl, TextBox).ID = MyTextBoxText Then
                            CType(innerCtrl, TextBox).ToolTip = hfPleaseEnter.Value & BMIRefLang.FirstOrDefault.ToString & "."
                        End If
                    End If
                    If TypeOf innerCtrl Is RequiredFieldValidator Then
                        If CType(innerCtrl, RequiredFieldValidator).ID = MyRequiredFieldValidatorText Then
                            CType(innerCtrl, RequiredFieldValidator).ErrorMessage = hfPleaseEnter.Value & BMIRefLang.FirstOrDefault.ToString & "!"
                        End If
                    End If
                    If TypeOf innerCtrl Is RangeValidator Then
                        If CType(innerCtrl, RangeValidator).ID = MyRangeValidatorText Then
                            CType(innerCtrl, RangeValidator).ErrorMessage = BMIRefLang.FirstOrDefault.ToString & hfIsInvalid.Value
                        End If
                    End If
                Next innerCtrl
            Next MyField
        Catch ex As Exception

        End Try

    End Sub

    'Insert New Donor Record
    Private Function IsNewDonor(ByVal CkUserName As String) As String

        'tblHtWtBMIReferral
        Try
            Dim TPDDC As New MyPortfolioDbDataContext
            Dim HWB As New tblHtWtBMIReferral
            HWB.pid = CInt(Trim(hfPID.Value))
            HWB.MeasureDate = Now.ToString("G")

            Dim MyHeightFt As String = Trim(txtHeightFeet.Text)
            Dim MyHeightIn As String = Trim(txtHeightInches.Text)
            Dim MyHeight As Double = 0
            If MyHeightFt <> Nothing Then
                MyHeight = Convert.ToInt32(MyHeightFt) * 12
            End If
            If MyHeightIn <> Nothing Then
                MyHeight = MyHeight + Convert.ToInt32(MyHeightIn)
            End If
            Dim MyHeightStr As String = MyHeight.ToString
            Dim MyWeight As Double = 0
            Dim MyWeightLbs As String = Trim(txtWeightPounds.Text)
            MyWeight = Convert.ToDouble(MyWeightLbs)

            HWB.Height = MyHeightStr
            HWB.Weight = MyWeightLbs
            HWB.HeightCM = (MyHeight * 2.54).ToString
            HWB.WeightKG = (MyWeight * 0.453592).ToString
            HWB.BMI = Trim(txtBMI.Text)
            hfBMI.Value = Trim(txtBMI.Text)

            HWB.EnterBy = Trim(CkUserName)
            HWB.EnterDate = Now.ToString("G")
            HWB.ModifyBy = Nothing
            HWB.ModifyDate = Nothing

            TPDDC.tblHtWtBMIReferrals.InsertOnSubmit(HWB)
            TPDDC.SubmitChanges()
            'Return True
        Catch ex As Exception
            'Return False
        End Try

        Try
            Dim MyManager = New UserManager()
            MyManager.AddToRole(hfUserId.Value, "Height Weight BMI")
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    'Update Previous Donor Record
    Private Function IsUpdateDonor(ByVal CkUserName As String) As String

        'tblHtWtBMIReferral
        Try
            Dim TPDDCUpdateI As New MyPortfolioDbDataContext
            Dim UHWB = (From p In TPDDCUpdateI.tblHtWtBMIReferrals
                        Where p.pid.Equals(hfPID.Value)).ToList(0)

            UHWB.MeasureDate = Now.ToString("G")

            Dim MyHeightFt As String = Trim(txtHeightFeet.Text)
            Dim MyHeightIn As String = Trim(txtHeightInches.Text)
            Dim MyHeight As Double = 0
            If MyHeightFt <> Nothing Then
                MyHeight = Convert.ToInt32(MyHeightFt) * 12
            End If
            If MyHeightIn <> Nothing Then
                MyHeight = MyHeight + Convert.ToInt32(MyHeightIn)
            End If
            Dim MyHeightStr As String = MyHeight.ToString
            Dim MyWeight As Double = 0
            Dim MyWeightLbs As String = Trim(txtWeightPounds.Text)
            MyWeight = Convert.ToDouble(MyWeightLbs)

            UHWB.Height = MyHeightStr
            UHWB.Weight = MyWeightLbs
            UHWB.HeightCM = (MyHeight * 2.54).ToString
            UHWB.WeightKG = (MyWeight * 0.453592).ToString
            UHWB.BMI = Trim(txtBMI.Text)
            hfBMI.Value = Trim(txtBMI.Text)
            UHWB.ModifyBy = Trim(CkUserName)
            UHWB.ModifyDate = Now.ToString("G")

            TPDDCUpdateI.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
