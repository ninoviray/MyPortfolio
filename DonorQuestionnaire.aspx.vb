
Partial Class Pages_DonorQuestionnaire
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Not Request.QueryString("D") Is Nothing Then
                hfUserId.Value = Request.QueryString("D").ToString
                hfLanguage.Value = Request.QueryString("L").ToString

                Try
                    Dim TPDDC As New MyPortfolioDbDataContext
                    Dim MyKC = From kc In TPDDC.tblKingsCourtReferrals
                               Where kc.UserId.Equals(hfUserId.Value)
                               Select kc.pid, kc.UserId

                    hfPID.Value = MyKC.First.pid.ToString
                    IsTransplantInstituteHeaders(hfLanguage.Value)
                    IsTransplantInstituteLanguage(hfLanguage.Value)
                    IsActivePanel("TabPanelTransplantInstitute")
                    IsWelcomeText(hfLanguage.Value)
                Catch ex As Exception

                End Try
            Else
                Response.Redirect("~/Default.aspx")
            End If

            lbInfo.Text = "&bull; This projects uses controls to display each page in a tab container. <br />"
            lbInfo.Text += "&bull; All text is dynamically populated based on the selected language(English, Spanish). <br />"
            lbInfo.Text += "&bull; In code behind, all object controls are cycled through the page populating the labels with the correct text."

        End If

    End Sub

    Public Sub IsActivePanel(ByVal CkActivePanel As String)

        Select Case CkActivePanel

            Case "TabPanelTransplantInstitute"
                TabPanelTransplantInstitute.Enabled = True
                TabContainerTransplantInstitute.ActiveTabIndex = 0
                MyTransplantInstitute.FindPID = hfPID.Value
                ValSumLivingDonorQuestionnaire.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnPrevious.Visible = False
                btnCancel.Visible = True
                TabPanelLivingDonor.Enabled = False
                btnNext.Enabled = True
            Case "TabPanelLivingDonor"
                TabPanelTransplantInstitute.Enabled = False
                TabPanelLivingDonor.Enabled = True
                TabContainerTransplantInstitute.ActiveTabIndex = 1
                MyLivingDonor.FindPID = hfPID.Value
                ValSumLivingDonorQuestionnaire.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnPrevious.Visible = True
                btnCancel.Visible = False
                TabPanelDemographics.Enabled = False
                btnNext.Enabled = True
            Case "TabPanelDemographics"
                TabPanelLivingDonor.Enabled = False
                TabPanelDemographics.Enabled = True
                TabContainerTransplantInstitute.ActiveTabIndex = 2
                MyDemographics.FindPID = hfPID.Value
                ValSumLivingDonorQuestionnaire.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                TabPanelInsurance.Enabled = False
                btnNext.Enabled = True
            Case "TabPanelInsurance"
                TabPanelDemographics.Enabled = False
                TabPanelInsurance.Enabled = True
                TabContainerTransplantInstitute.ActiveTabIndex = 3
                MyInsurance.FindPID = hfPID.Value
                ValSumLivingDonorQuestionnaire.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                TabPanelHeightWeightBMI.Enabled = False
                btnNext.Enabled = True
            Case "TabPanelHeightWeightBMI"
                TabPanelInsurance.Enabled = False
                TabPanelHeightWeightBMI.Enabled = True
                TabContainerTransplantInstitute.ActiveTabIndex = 4
                MyHeightWeightBMI.FindPID = hfPID.Value
                ValSumLivingDonorQuestionnaire.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                TabPanelBloodHistory.Enabled = False
                btnNext.Enabled = True
            Case "TabPanelBloodHistory"
                TabPanelHeightWeightBMI.Enabled = False
                TabPanelBloodHistory.Enabled = True
                TabContainerTransplantInstitute.ActiveTabIndex = 5
                MyBloodHistory.FindPID = hfPID.Value
                ValSumLivingDonorQuestionnaire.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                TabPanelMedicalHistory.Enabled = False
                btnNext.Enabled = True
            Case "TabPanelMedicalHistory"
                TabPanelBloodHistory.Enabled = False
                TabPanelMedicalHistory.Enabled = True
                TabContainerTransplantInstitute.ActiveTabIndex = 6
                MyMedicalHistory.FindPID = hfPID.Value
                ValSumLivingDonorQuestionnaire.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                TabPanelSocialHistory.Enabled = False
                btnNext.Enabled = True
            Case "TabPanelSocialHistory"
                TabPanelMedicalHistory.Enabled = False
                TabPanelSocialHistory.Enabled = True
                TabContainerTransplantInstitute.ActiveTabIndex = 7
                MySocialHistory.FindPID = hfPID.Value
                ValSumLivingDonorQuestionnaire.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                TabPanelQuestionnaireCompletion.Enabled = False
                btnNext.Enabled = True
            Case "TabPanelQuestionnaireCompletion"
                TabPanelSocialHistory.Enabled = False
                TabPanelQuestionnaireCompletion.Enabled = True
                TabContainerTransplantInstitute.ActiveTabIndex = 8
                MyQuestionnaireCompletion.FindPID = hfPID.Value
                ValSumLivingDonorQuestionnaire.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.ValidationGroup = CkActivePanel.Replace("TabPanel", "")
                btnNext.Enabled = False
            Case Else

        End Select

        hfTab.Value = TabContainerTransplantInstitute.ActiveTabIndex

    End Sub

    'btnPrevious Click Event
    Protected Sub btnPrevious_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrevious.Click

        Dim MyPreviousTabName As String = TabContainerTransplantInstitute.ActiveTab.ID

        Select Case MyPreviousTabName

            Case "TabPanelTransplantInstitute"

            Case "TabPanelLivingDonor"
                IsActivePanel("TabPanelTransplantInstitute")
            Case "TabPanelDemographics"
                IsActivePanel("TabPanelLivingDonor")
            Case "TabPanelInsurance"
                IsActivePanel("TabPanelDemographics")
            Case "TabPanelHeightWeightBMI"
                IsActivePanel("TabPanelInsurance")
            Case "TabPanelBloodHistory"
                IsActivePanel("TabPanelHeightWeightBMI")
            Case "TabPanelMedicalHistory"
                IsActivePanel("TabPanelBloodHistory")
            Case "TabPanelSocialHistory"
                IsActivePanel("TabPanelMedicalHistory")
            Case "TabPanelQuestionnaireCompletion"
                IsActivePanel("TabPanelSocialHistory")
            Case Else

        End Select


    End Sub

    'btnCancel Click Event
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click

        Context.GetOwinContext().Authentication.SignOut()
        FormsAuthentication.SignOut()
        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()
        'FormsAuthentication.RedirectToLoginPage("~/Default.aspx")

    End Sub

    'btnNext Click Event
    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNext.Click

        If Page.IsValid Then

            Dim MyNextTabName As String = TabContainerTransplantInstitute.ActiveTab.ID

            Select Case MyNextTabName

                Case "TabPanelTransplantInstitute"
                    If hfTabPanelTransplantInstitute.Value = "False" Then
                        MyTransplantInstitute.FindNewDonor = "UTCDonor" & hfPID.Value
                        hfTabPanelTransplantInstitute.Value = "True"
                    Else
                        MyTransplantInstitute.FindUpdateDonor = "UTCDonor" & hfPID.Value
                    End If
                    IsActivePanel("TabPanelLivingDonor")
                    IsOrgans()
                Case "TabPanelLivingDonor"
                    If hfTabPanelLivingDonor.Value = "False" Then
                        MyLivingDonor.FindNewDonor = "UTCDonor" & hfPID.Value
                        hfTabPanelLivingDonor.Value = "True"
                    Else
                        MyLivingDonor.FindUpdateDonor = "UTCDonor" & hfPID.Value
                    End If
                    IsActivePanel("TabPanelDemographics")
                Case "TabPanelDemographics"
                    If hfTabPanelDemographics.Value = "False" Then
                        MyDemographics.FindNewDonor = "UTCDonor" & hfPID.Value
                        hfTabPanelDemographics.Value = "True"
                    Else
                        MyDemographics.FindUpdateDonor = "UTCDonor" & hfPID.Value
                    End If
                    IsActivePanel("TabPanelInsurance")
                Case "TabPanelInsurance"
                    If hfTabPanelInsurance.Value = "False" Then
                        MyInsurance.FindNewDonor = "UTCDonor" & hfPID.Value
                        hfTabPanelInsurance.Value = "True"
                    Else
                        MyInsurance.FindUpdateDonor = "UTCDonor" & hfPID.Value
                    End If
                    IsActivePanel("TabPanelHeightWeightBMI")
                Case "TabPanelHeightWeightBMI"
                    If hfTabPanelHeightWeightBMI.Value = "False" Then
                        MyHeightWeightBMI.FindNewDonor = "UTCDonor" & hfPID.Value
                        hfTabPanelHeightWeightBMI.Value = "True"
                    Else
                        MyHeightWeightBMI.FindUpdateDonor = "UTCDonor" & hfPID.Value
                    End If
                    IsActivePanel("TabPanelBloodHistory")
                Case "TabPanelBloodHistory"
                    If hfTabPanelBloodHistory.Value = "False" Then
                        MyBloodHistory.FindNewDonor = "UTCDonor" & hfPID.Value
                        hfTabPanelBloodHistory.Value = "True"
                    Else
                        MyBloodHistory.FindUpdateDonor = "UTCDonor" & hfPID.Value
                    End If
                    IsActivePanel("TabPanelMedicalHistory")
                Case "TabPanelMedicalHistory"
                    If hfTabPanelMedicalHistory.Value = "False" Then
                        MyMedicalHistory.FindNewDonor = "UTCDonor" & hfPID.Value
                        hfTabPanelMedicalHistory.Value = "True"
                    Else
                        MyMedicalHistory.FindUpdateDonor = "UTCDonor" & hfPID.Value
                    End If
                    IsActivePanel("TabPanelSocialHistory")
                Case "TabPanelSocialHistory"
                    If hfTabPanelSocialHistory.Value = "False" Then
                        MySocialHistory.FindNewDonor = "UTCDonor" & hfPID.Value
                        hfTabPanelSocialHistory.Value = "True"
                    Else
                        MySocialHistory.FindUpdateDonor = "UTCDonor" & hfPID.Value
                    End If
                    IsActivePanel("TabPanelQuestionnaireCompletion")
                Case "TabPanelQuestionnaireCompletion"

                    IdentityHelper.RedirectToReturnUrl("~/Pages/DonorScreening.aspx?D=" & hfUserId.Value & "&L=" & hfLanguage.Value & "", Response)

                Case Else

            End Select

        End If

    End Sub

    'Container Transplant Institute Headers
    Private Function IsTransplantInstituteHeaders(ByVal CkLanguage As String) As String

        For Each obj As Object In TabContainerTransplantInstitute.Controls
            If TypeOf obj Is AjaxControlToolkit.TabPanel Then
                Dim tabPanel As AjaxControlToolkit.TabPanel = CType(obj, AjaxControlToolkit.TabPanel)

                Try
                    Dim TPDDCRead As New MyPortfolioDbDataContext
                    Dim PR = From p In TPDDCRead.lkpTabHeaderTexts
                             Where p.TabHeaderText.Equals(tabPanel.ID)
                             Select p.Id, p.TabHeaderTextEnglish, p.TabHeaderTextSpanish, p.TabHeaderTextMandarin, p.TabHeaderTextArabic,
                                 p.TabHeaderTextHindiUrdu, p.TabHeaderTextBengali, p.TabHeaderTextPortuguese, p.TabHeaderTextRussian,
                                 p.TabHeaderTextJapanese, p.TabHeaderTextPunjabi

                    Select Case CkLanguage

                        Case "Eng"
                            tabPanel.HeaderText = PR.First.TabHeaderTextEnglish.ToString
                        Case "Spa"
                            tabPanel.HeaderText = PR.First.TabHeaderTextSpanish.ToString
                        Case "Man"
                            tabPanel.HeaderText = PR.First.TabHeaderTextMandarin.ToString
                        Case "Ara"
                            tabPanel.HeaderText = PR.First.TabHeaderTextArabic.ToString
                        Case "Hin"
                            tabPanel.HeaderText = PR.First.TabHeaderTextHindiUrdu.ToString
                        Case "Ben"
                            tabPanel.HeaderText = PR.First.TabHeaderTextBengali.ToString
                        Case "Por"
                            tabPanel.HeaderText = PR.First.TabHeaderTextPortuguese.ToString
                        Case "Rus"
                            tabPanel.HeaderText = PR.First.TabHeaderTextRussian.ToString
                        Case "Jap"
                            tabPanel.HeaderText = PR.First.TabHeaderTextJapanese.ToString
                        Case "Pun"
                            tabPanel.HeaderText = PR.First.TabHeaderTextPunjabi.ToString
                        Case Else
                            tabPanel.HeaderText = PR.First.TabHeaderTextEnglish.ToString
                    End Select
                Catch ex As Exception

                End Try
            End If
        Next obj

        lbTabPanelLivingDonorText.Text = TabPanelLivingDonor.HeaderText
        lbTabPanelDemographicsText.Text = TabPanelDemographics.HeaderText
        lbTabPanelInsuranceText.Text = TabPanelInsurance.HeaderText
        lbTabPanelHeightWeightBMIText.Text = TabPanelHeightWeightBMI.HeaderText
        lbTabPanelBloodHistoryText.Text = TabPanelBloodHistory.HeaderText
        lbTabPanelMedicalHistoryText.Text = TabPanelMedicalHistory.HeaderText
        lbTabPanelSocialHistoryText.Text = TabPanelSocialHistory.HeaderText
        lbTabPanelQuestionnaireCompletionText.Text = TabPanelQuestionnaireCompletion.HeaderText

        Return True

    End Function

    'Container Transplant Institute Language
    Private Function IsTransplantInstituteLanguage(ByVal CkLanguage As String) As String

        Select Case CkLanguage

            Case "Eng"
                hfValidationSummary.Value = "Please Review/Answer the Question/Questions Listed Below:"
                hfCancel.Value = "Cancel"
                hfCancelToolTip.Value = "Cancel and Go Back to the Start Page."
                hfCancelConfirm.Value = "Are you Sure you Want to Cancel!"
                hfPrevious.Value = "Previous"
                hfPreviousToolTip.Value = "Go to the Previous Section."
                hfNext.Value = "Next"
                hfNextToolTip.Value = "Go to the Next Section."
            Case "Spa"
                hfValidationSummary.Value = "Por Favor Revise/Responda a la Pregunta/Preguntas que se Enumeran a Continuación:"
                hfCancel.Value = "Cancelar"
                hfCancelToolTip.Value = "Cancelar y Volver A La Página De Inicio."
                hfCancelConfirm.Value = "¿Está Seguro De Que Desea Cancelar!"
                hfPrevious.Value = "Anterior"
                hfPreviousToolTip.Value = "Vaya A La Sección Anterior."
                hfNext.Value = "Próximo"
                hfNextToolTip.Value = "Vaya A La Siguiente Sección."
            Case "Man"
                hfValidationSummary.Value = "qǐng chá kàn / huí dá xià mian liè chū de wèn tí:"
                hfCancel.Value = ""
                hfCancelToolTip.Value = ""
                hfCancelConfirm.Value = ""
                hfPrevious.Value = ""
                hfPreviousToolTip.Value = ""
                hfNext.Value = ""
                hfNextToolTip.Value = ""
            Case "Ara"
                hfValidationSummary.Value = "yergi marajaa / eligaba ola al-sual / al-asailah madkoura adnah:"
                hfCancel.Value = ""
                hfCancelToolTip.Value = ""
                hfCancelConfirm.Value = ""
                hfPrevious.Value = ""
                hfPreviousToolTip.Value = ""
                hfNext.Value = ""
                hfNextToolTip.Value = ""
            Case "Hin"
                hfValidationSummary.Value = "kripya niche suchibaddh prashn/prashnon key samiksha/uttar den:"
                hfCancel.Value = ""
                hfCancelToolTip.Value = ""
                hfCancelConfirm.Value = ""
                hfPrevious.Value = ""
                hfPreviousToolTip.Value = ""
                hfNext.Value = ""
                hfNextToolTip.Value = ""
            Case "Ben"
                hfValidationSummary.Value = "anugraha kore neechey talikabhukto prashna/proshner parjalochana/uttar din:"
                hfCancel.Value = ""
                hfCancelToolTip.Value = ""
                hfCancelConfirm.Value = ""
                hfPrevious.Value = ""
                hfPreviousToolTip.Value = ""
                hfNext.Value = ""
                hfNextToolTip.Value = ""
            Case "Por"
                hfValidationSummary.Value = "Por Favor, Reveja/Responda à Pergunta/Perguntas Listadas Abaixo:"
                hfCancel.Value = ""
                hfCancelToolTip.Value = ""
                hfCancelConfirm.Value = ""
                hfPrevious.Value = ""
                hfPreviousToolTip.Value = ""
                hfNext.Value = ""
                hfNextToolTip.Value = ""
            Case "Rus"
                hfValidationSummary.Value = "Pojaluista, Prosmotrite/Otvette na Voprosy/Voprosy, Perechislennye Nije:"
                hfCancel.Value = ""
                hfCancelToolTip.Value = ""
                hfCancelConfirm.Value = ""
                hfPrevious.Value = ""
                hfPreviousToolTip.Value = ""
                hfNext.Value = ""
                hfNextToolTip.Value = ""
            Case "Jap"
                hfValidationSummary.Value = "ika ni shimesu shitsumon / shitsumon wo kakunin / kaito shi te kudasai:"
                hfCancel.Value = ""
                hfCancelToolTip.Value = ""
                hfCancelConfirm.Value = ""
                hfPrevious.Value = ""
                hfPreviousToolTip.Value = ""
                hfNext.Value = ""
                hfNextToolTip.Value = ""
            Case "Pun"
                hfValidationSummary.Value = "kirpa karke hethan suchibaddha prashan/prashana di samikhia/jawab deo:"
                hfCancel.Value = ""
                hfCancelToolTip.Value = ""
                hfCancelConfirm.Value = ""
                hfPrevious.Value = ""
                hfPreviousToolTip.Value = ""
                hfNext.Value = ""
                hfNextToolTip.Value = ""
            Case Else
                hfValidationSummary.Value = "Please Review/Answer the Question/Questions Listed Below:"
                hfCancel.Value = "Cancel"
                hfCancelToolTip.Value = "Go Back to the Start Page."
                hfCancelConfirm.Value = "Are you Sure you Want to Cancel!"
                hfPrevious.Value = "Previous"
                hfPreviousToolTip.Value = "Go to the Previous Section."
                hfNext.Value = "Next"
                hfNextToolTip.Value = "Go to the Next Section."
        End Select

        ValSumLivingDonorQuestionnaire.HeaderText = hfValidationSummary.Value
        btnCancel.Text = hfCancel.Value
        btnCancel.ToolTip = hfCancelToolTip.Value
        cbeCancel.ConfirmText = hfCancelConfirm.Value
        btnPrevious.Text = hfPrevious.Value
        btnPrevious.ToolTip = hfPreviousToolTip.Value
        btnNext.Text = hfNext.Value
        btnNext.ToolTip = hfNextToolTip.Value

        Return True

    End Function

    'Welcome Text
    Private Function IsWelcomeText(ByVal CkLanguage As String) As String

        Try
            Dim DonPreLang As New List(Of String)
            Dim TPDDCRead As New MyPortfolioDbDataContext
            Dim DP = From p In TPDDCRead.lkpTransplantReferrals
                     Where p.Id.Equals(2)
                     Select p

            Select Case CkLanguage

                Case "Eng"
                    Dim DPLE = (From dpeng In DP Select dpeng.TransplantReferralEnglish).ToList
                    DonPreLang = DPLE
                Case "Spa"
                    Dim DPLS = (From dpspa In DP Select dpspa.TransplantReferralSpanish).ToList
                    DonPreLang = DPLS
                Case "Man"
                    Dim DPLM = (From dpman In DP Select dpman.TransplantReferralMandarin).ToList
                    DonPreLang = DPLM
                Case "Ara"
                    Dim DPLA = (From dpara In DP Select dpara.TransplantReferralArabic).ToList
                    DonPreLang = DPLA
                Case "Hin"
                    Dim DPLH = (From dphin In DP Select dphin.TransplantReferralHindiUrdu).ToList
                    DonPreLang = DPLH
                Case "Ben"
                    Dim DPLB = (From dpben In DP Select dpben.TransplantReferralBengali).ToList
                    DonPreLang = DPLB
                Case "Por"
                    Dim DPLP = (From dppor In DP Select dppor.TransplantReferralPortuguese).ToList
                    DonPreLang = DPLP
                Case "Rus"
                    Dim DPLR = (From dprus In DP Select dprus.TransplantReferralRussian).ToList
                    DonPreLang = DPLR
                Case "Jap"
                    Dim DPLJ = (From dpjap In DP Select dpjap.TransplantReferralJapanese).ToList
                    DonPreLang = DPLJ
                Case "Pun"
                    Dim DPLPU = (From dppun In DP Select dppun.TransplantReferralPunjabi).ToList
                    DonPreLang = DPLPU
                Case Else
                    Dim DPLEN = (From dpeng In DP Select dpeng.TransplantReferralEnglish).ToList
                    DonPreLang = DPLEN
            End Select

            lbTabPanelTransplantInstituteText.Text = DonPreLang.FirstOrDefault.ToString

        Catch ex As Exception

        End Try

        Return True

    End Function

    'Set Organs in Hidden fields
    Private Sub IsOrgans()

        Try
            Dim TPDDCRead As New MyPortfolioDbDataContext
            Dim MyKCR = From kcr In TPDDCRead.tblKingsCourtReferrals
                        Where kcr.pid.Equals(hfPID.Value)
                        Select kcr.pid, kcr.DonorKidney, kcr.DonorLiver

            hfKidneyDonor.Value = MyKCR.First.DonorKidney.ToString
            hfLiverDonor.Value = MyKCR.First.DonorLiver.ToString
        Catch ex As Exception

        End Try

    End Sub

End Class
