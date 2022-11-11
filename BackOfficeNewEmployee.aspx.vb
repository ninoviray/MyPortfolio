Imports System.Data
Imports System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder
Imports System.Resources

Partial Class Pages_BackOfficeNewEmployee
    Inherits System.Web.UI.Page

    Dim StaffColor(20) As String
    Dim gId As Integer
    Dim gStart As String
    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        With Me

            If Not IsPostBack Then

                Me.ViewState("LinqNewEmployeeOrderBy") = LinqNewEmployee.OrderBy

                lbInfo.Text = "&bull; Users can create a checklist of tasks when processing new employees.  <br />"
                lbInfo.Text += "&bull; The textboxes are open for dates or notes to be entered. <br />"
                lbInfo.Text += "&bull; When all the tasks are completed, selecting the completed checkbox will remove the task from the list and populate in the completed records dropdown list. <br />"
                lbInfo.Text += "&bull; Users can restore any of the records from the dropdown list to review or update. "

            End If

            funcStaffCode()
            funcLegend()

        End With

    End Sub

    Protected Sub GridViewNewEmployee_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

                Dim txtStartDate As TextBox = TryCast(e.Row.FindControl("txtStartDate"), TextBox)
                If txtStartDate.Text = "01/01/1900" Then
                    txtStartDate.Text = Nothing
                End If

                Dim ddEmployee As DropDownList = TryCast(e.Row.FindControl("ddEmployee"), DropDownList)
                Dim txtEmployeeTemp As TextBox = TryCast(e.Row.FindControl("txtEmployeeTemp"), TextBox)
                If ddEmployee.SelectedValue <> Nothing Then
                    txtEmployeeTemp.Visible = False
                End If

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

                Try

                    Dim lbIT As Label = TryCast(e.Row.FindControl("lbIT"), Label)
                    Dim lbITBy As Label = TryCast(e.Row.FindControl("lbITBy"), Label)
                    Dim lbEmployee As Label = TryCast(e.Row.FindControl("lbEmployee"), Label)
                    Dim lbEmployeeTemp As Label = TryCast(e.Row.FindControl("lbEmployeeTemp"), Label)
                    Dim lbStartDate As Label = TryCast(e.Row.FindControl("lbStartDate"), Label)
                    Dim lbStartDateBy As Label = TryCast(e.Row.FindControl("lbStartDateBy"), Label)
                    Dim lbIncomingStatus As Label = TryCast(e.Row.FindControl("lbIncomingStatus"), Label)
                    Dim lbIncomingStatusBy As Label = TryCast(e.Row.FindControl("lbIncomingStatusBy"), Label)
                    Dim lbSupervisor As Label = TryCast(e.Row.FindControl("lbSupervisor"), Label)
                    Dim lbSupervisorBy As Label = TryCast(e.Row.FindControl("lbSupervisorBy"), Label)
                    Dim lbTitle As Label = TryCast(e.Row.FindControl("lbTitle"), Label)
                    Dim lbTitleBy As Label = TryCast(e.Row.FindControl("lbTitleBy"), Label)
                    Dim lbConfidentialityForm As Label = TryCast(e.Row.FindControl("lbConfidentialityForm"), Label)
                    Dim lbConfidentialityFormBy As Label = TryCast(e.Row.FindControl("lbConfidentialityFormBy"), Label)
                    Dim lbSentToDataSecurity As Label = TryCast(e.Row.FindControl("lbSentToDataSecurity"), Label)
                    Dim lbSentToDataSecurityBy As Label = TryCast(e.Row.FindControl("lbSentToDataSecurityBy"), Label)
                    Dim lbWelcomeEmail As Label = TryCast(e.Row.FindControl("lbWelcomeEmail"), Label)
                    Dim lbWelcomeEmailBy As Label = TryCast(e.Row.FindControl("lbWelcomeEmailBy"), Label)
                    Dim lbAccount As Label = TryCast(e.Row.FindControl("lbAccount"), Label)
                    Dim lbAccountBy As Label = TryCast(e.Row.FindControl("lbAccountBy"), Label)
                    Dim lbUNETAccount As Label = TryCast(e.Row.FindControl("lbUNETAccount"), Label)
                    Dim lbUNETAccountBy As Label = TryCast(e.Row.FindControl("lbUNETAccountBy"), Label)
                    Dim lbPhoneVoicemail As Label = TryCast(e.Row.FindControl("lbPhoneVoicemail"), Label)
                    Dim lbPhoneVoicemailBy As Label = TryCast(e.Row.FindControl("lbPhoneVoicemailBy"), Label)
                    Dim lbEFax As Label = TryCast(e.Row.FindControl("lbEFax"), Label)
                    Dim lbEFaxBy As Label = TryCast(e.Row.FindControl("lbEFaxBy"), Label)
                    Dim lbMailGroups As Label = TryCast(e.Row.FindControl("lbMailGroups"), Label)
                    Dim lbMailGroupsBy As Label = TryCast(e.Row.FindControl("lbMailGroupsBy"), Label)
                    Dim lbAdobe As Label = TryCast(e.Row.FindControl("lbAdobe"), Label)
                    Dim lbAdobeBy As Label = TryCast(e.Row.FindControl("lbAdobeBy"), Label)
                    Dim lbWebEx As Label = TryCast(e.Row.FindControl("lbWebEx"), Label)
                    Dim lbWebExBy As Label = TryCast(e.Row.FindControl("lbWebExBy"), Label)
                    Dim lbPremier As Label = TryCast(e.Row.FindControl("lbPremier"), Label)
                    Dim lbPremierBy As Label = TryCast(e.Row.FindControl("lbPremierBy"), Label)
                    Dim lbOfficeDepot As Label = TryCast(e.Row.FindControl("lbOfficeDepot"), Label)
                    Dim lbOfficeDepotBy As Label = TryCast(e.Row.FindControl("lbOfficeDepotBy"), Label)
                    Dim lbTMHPAccess As Label = TryCast(e.Row.FindControl("lbTMHPAccess"), Label)
                    Dim lbTMHPAccessBy As Label = TryCast(e.Row.FindControl("lbTMHPAccessBy"), Label)
                    Dim lbMedicareAccess As Label = TryCast(e.Row.FindControl("lbMedicareAccess"), Label)
                    Dim lbMedicareAccessBy As Label = TryCast(e.Row.FindControl("lbMedicareAccessBy"), Label)
                    Dim lbAllscriptsAccess As Label = TryCast(e.Row.FindControl("lbAllscriptsAccess"), Label)
                    Dim lbAllscriptsAccessBy As Label = TryCast(e.Row.FindControl("lbAllscriptsAccessBy"), Label)
                    Dim lbAMBNurseClass As Label = TryCast(e.Row.FindControl("lbAMBNurseClass"), Label)
                    Dim lbAMBNurseClassBy As Label = TryCast(e.Row.FindControl("lbAMBNurseClassBy"), Label)
                    Dim lbSentAccessToEmployee As Label = TryCast(e.Row.FindControl("lbSentAccessToEmployee"), Label)
                    Dim lbSentAccessToEmployeeBy As Label = TryCast(e.Row.FindControl("lbSentAccessToEmployeeBy"), Label)

                    If lbITBy.Text <> Nothing Then
                        lbIT.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbITBy.Text))
                        lbEmployee.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbITBy.Text))
                        lbEmployeeTemp.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbITBy.Text))
                    End If
                    If lbStartDateBy.Text <> Nothing Then
                        lbStartDate.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbStartDateBy.Text))
                    End If
                    If lbIncomingStatusBy.Text <> Nothing Then
                        lbIncomingStatus.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbIncomingStatusBy.Text))
                    End If
                    If lbSupervisorBy.Text <> Nothing Then
                        lbSupervisor.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbSupervisorBy.Text))
                    End If
                    If lbTitleBy.Text <> Nothing Then
                        lbTitle.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbTitleBy.Text))
                    End If
                    If lbConfidentialityFormBy.Text <> Nothing Then
                        lbConfidentialityForm.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbConfidentialityFormBy.Text))
                    End If
                    If lbSentToDataSecurityBy.Text <> Nothing Then
                        lbSentToDataSecurity.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbSentToDataSecurityBy.Text))
                    End If
                    If lbWelcomeEmailBy.Text <> Nothing Then
                        lbWelcomeEmail.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbWelcomeEmailBy.Text))
                    End If
                    If lbAccountBy.Text <> Nothing Then
                        lbAccount.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbAccountBy.Text))
                    End If
                    If lbUNETAccountBy.Text <> Nothing Then
                        lbUNETAccount.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbUNETAccountBy.Text))
                    End If
                    If lbPhoneVoicemailBy.Text <> Nothing Then
                        lbPhoneVoicemail.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbPhoneVoicemailBy.Text))
                    End If
                    If lbEFaxBy.Text <> Nothing Then
                        lbEFax.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbEFaxBy.Text))
                    End If
                    If lbMailGroupsBy.Text <> Nothing Then
                        lbMailGroups.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbMailGroupsBy.Text))
                    End If
                    If lbAdobeBy.Text <> Nothing Then
                        lbAdobe.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbAdobeBy.Text))
                    End If
                    If lbWebExBy.Text <> Nothing Then
                        lbWebEx.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbWebExBy.Text))
                    End If
                    If lbPremierBy.Text <> Nothing Then
                        lbPremier.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbPremierBy.Text))
                    End If
                    If lbOfficeDepotBy.Text <> Nothing Then
                        lbOfficeDepot.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbOfficeDepotBy.Text))
                    End If
                    If lbTMHPAccessBy.Text <> Nothing Then
                        lbTMHPAccess.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbTMHPAccessBy.Text))
                    End If
                    If lbMedicareAccessBy.Text <> Nothing Then
                        lbMedicareAccess.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbMedicareAccessBy.Text))
                    End If
                    If lbAllscriptsAccessBy.Text <> Nothing Then
                        lbAllscriptsAccess.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbAllscriptsAccessBy.Text))
                    End If
                    If lbAMBNurseClassBy.Text <> Nothing Then
                        lbAMBNurseClass.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbAMBNurseClassBy.Text))
                    End If
                    If lbSentAccessToEmployeeBy.Text <> Nothing Then
                        lbSentAccessToEmployee.ForeColor = Drawing.ColorTranslator.FromHtml(StaffColor(lbSentAccessToEmployeeBy.Text))
                    End If

                    If lbStartDate.Text = "01/01/1900" Then
                        lbStartDate.Text = Nothing
                    End If
                    If lbEmployee.Text <> " " Then
                        lbEmployeeTemp.Visible = False
                    Else
                        lbEmployee.Visible = True
                    End If

                Catch ex As Exception

                End Try

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub GridViewNewEmployee_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try

            Dim NEU = (From p In TPDC.tblBackOfficeNewEmployeeProcesses
                       Where p.Id.Equals(gId)).ToList()(0)

            NEU.StartDate = gStart

            TPDC.SubmitChanges()
            GridViewNewEmployee.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GridViewNewEmployee_RowUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs)

        ddEmployee.Items.Clear()
        ddEmployee.Items.Insert(0, New ListItem(String.Empty, String.Empty))
        ddEmployee.ClearSelection()
        ddEmployee.DataBind()

    End Sub

    Protected Sub GridViewNewEmployee_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Add" Then

                Try
                    Dim NE As New ListDictionary
                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                    Dim ITBy As Integer = DirectCast(row.FindControl("ddIT"), DropDownList).SelectedValue

                    NE.Add("IT", ITBy)
                    If DirectCast(row.FindControl("txtEmployeeTemp"), TextBox).Text = Nothing And DirectCast(row.FindControl("ddEmployee"), DropDownList).SelectedValue = Nothing Then

                        lbNewEmployeeMessage.Text = "Please enter an employee name! </br>"
                        lbNewEmployeeMessage.ForeColor = Drawing.Color.Red

                    Else

                        If DirectCast(row.FindControl("txtEmployeeTemp"), TextBox).Text <> Nothing Then
                            NE.Add("EmployeeTemp", DirectCast(row.FindControl("txtEmployeeTemp"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("ddEmployee"), DropDownList).SelectedValue <> Nothing Then
                            NE.Add("Employee", DirectCast(row.FindControl("ddEmployee"), DropDownList).SelectedValue)
                        End If
                        If DirectCast(row.FindControl("ddIncomingStatus"), DropDownList).SelectedValue <> Nothing Then
                            NE.Add("IncomingStatus", DirectCast(row.FindControl("ddIncomingStatus"), DropDownList).SelectedValue)
                            NE.Add("IncomingStatusBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("ddSupervisor"), DropDownList).SelectedValue <> Nothing Then
                            NE.Add("Supervisor", DirectCast(row.FindControl("ddSupervisor"), DropDownList).SelectedValue)
                            NE.Add("SupervisorBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtStartDate"), TextBox).Text <> Nothing Then
                            NE.Add("StartDate", DirectCast(row.FindControl("txtStartDate"), TextBox).Text)
                            NE.Add("StartDateBy", ITBy)
                        Else
                            NE.Add("StartDate", "01/01/1900")
                        End If
                        If DirectCast(row.FindControl("txtTitle"), TextBox).Text <> Nothing Then
                            NE.Add("Title", DirectCast(row.FindControl("txtTitle"), TextBox).Text)
                            NE.Add("TitleBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtConfidentialityForm"), TextBox).Text <> Nothing Then
                            NE.Add("ConfidentialityForm", DirectCast(row.FindControl("txtConfidentialityForm"), TextBox).Text)
                            NE.Add("ConfidentialityFormBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtSentToDataSecurity"), TextBox).Text <> Nothing Then
                            NE.Add("SentToDataSecurity", DirectCast(row.FindControl("txtSentToDataSecurity"), TextBox).Text)
                            NE.Add("SentToDataSecurityBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtWelcomeEmail"), TextBox).Text <> Nothing Then
                            NE.Add("WelcomeEmail", DirectCast(row.FindControl("txtWelcomeEmail"), TextBox).Text)
                            NE.Add("WelcomeEmailBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtAccount"), TextBox).Text <> Nothing Then
                            NE.Add("Account", DirectCast(row.FindControl("txtAccount"), TextBox).Text)
                            NE.Add("AccountBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtUNETAccount"), TextBox).Text <> Nothing Then
                            NE.Add("UNETAccount", DirectCast(row.FindControl("txtUNETAccount"), TextBox).Text)
                            NE.Add("UNETAccountBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtPhoneVoicemail"), TextBox).Text <> Nothing Then
                            NE.Add("PhoneVoicemail", DirectCast(row.FindControl("txtPhoneVoicemail"), TextBox).Text)
                            NE.Add("PhoneVoicemailBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtEFax"), TextBox).Text <> Nothing Then
                            NE.Add("EFax", DirectCast(row.FindControl("txtEFax"), TextBox).Text)
                            NE.Add("EFaxBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtMailGroups"), TextBox).Text <> Nothing Then
                            NE.Add("MailGroups", DirectCast(row.FindControl("txtMailGroups"), TextBox).Text)
                            NE.Add("MailGroupsBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtAdobe"), TextBox).Text <> Nothing Then
                            NE.Add("Adobe", DirectCast(row.FindControl("txtAdobe"), TextBox).Text)
                            NE.Add("AdobeBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtWebEx"), TextBox).Text <> Nothing Then
                            NE.Add("WebEx", DirectCast(row.FindControl("txtWebEx"), TextBox).Text)
                            NE.Add("WebExBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtPremier"), TextBox).Text <> Nothing Then
                            NE.Add("Premier", DirectCast(row.FindControl("txtPremier"), TextBox).Text)
                            NE.Add("PremierBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtOfficeDepot"), TextBox).Text <> Nothing Then
                            NE.Add("OfficeDepot", DirectCast(row.FindControl("txtOfficeDepot"), TextBox).Text)
                            NE.Add("OfficeDepotBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtTMHPAccess"), TextBox).Text <> Nothing Then
                            NE.Add("TMHPAccess", DirectCast(row.FindControl("txtTMHPAccess"), TextBox).Text)
                            NE.Add("TMHPAccessBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtMedicareAccess"), TextBox).Text <> Nothing Then
                            NE.Add("MedicareAccess", DirectCast(row.FindControl("txtMedicareAccess"), TextBox).Text)
                            NE.Add("MedicareAccessBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtAllscriptsAccess"), TextBox).Text <> Nothing Then
                            NE.Add("AllscriptsAccess", DirectCast(row.FindControl("txtAllscriptsAccess"), TextBox).Text)
                            NE.Add("AllscriptsAccessBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtAMBNurseClass"), TextBox).Text <> Nothing Then
                            NE.Add("AMBNurseClass", DirectCast(row.FindControl("txtAMBNurseClass"), TextBox).Text)
                            NE.Add("AMBNurseClassBy", ITBy)
                        End If
                        If DirectCast(row.FindControl("txtSentAccessToEmployee"), TextBox).Text <> Nothing Then
                            NE.Add("SentAccessToEmployee", DirectCast(row.FindControl("txtSentAccessToEmployee"), TextBox).Text)
                            NE.Add("SentAccessToEmployeeBy", ITBy)
                        End If

                        NE.Add("Completed", False)
                        NE.Add("EnterBy", hfUser.Value)
                        NE.Add("EnterDate", Now.ToString("G"))

                        LinqNewEmployee.Insert(NE)
                        LinqNewEmployee.OrderBy = Me.ViewState("LinqNewEmployeeOrderBy")
                        GridViewNewEmployee.DataBind()
                        NE.Clear()

                        lbNewEmployeeMessage.Text = "Record has been added! </br>"
                        lbNewEmployeeMessage.ForeColor = Drawing.Color.Green

                    End If

                Catch ex As Exception
                    lbNewEmployeeMessage.Text = "Your Record was Not Saved! </br>"
                    lbNewEmployeeMessage.ForeColor = Drawing.Color.Red
                End Try

            ElseIf e.CommandName = "Update" Then

                Try

                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                    gId = DirectCast(row.FindControl("lbId"), Label).Text

                    Dim Staff = From p In TPDC.lkpBackOfficeWorkOrderUsers
                                Where p.UserId.Equals(hfUserId.Value)
                                Select p.Id, p.Color

                    Dim NE = From p In TPDC.tblBackOfficeNewEmployeeProcesses
                             Where p.Id.Equals(DirectCast(row.FindControl("lbId"), Label).Text)

                    Dim NEU = (From p In TPDC.tblBackOfficeNewEmployeeProcesses
                               Where p.Id.Equals(DirectCast(row.FindControl("lbId"), Label).Text)).ToList()(0)

                    Try
                        If DirectCast(row.FindControl("ddIncomingStatus"), DropDownList).SelectedValue <> NE.First.IncomingStatus Then
                            NEU.IncomingStatusBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("ddSupervisor"), DropDownList).SelectedValue.ToString() <> NE.First.Supervisor.ToString Then
                            NEU.SupervisorBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtStartDate"), TextBox).Text <> Nothing Then
                            gStart = DirectCast(row.FindControl("txtStartDate"), TextBox).Text
                        Else
                            gStart = "01/01/1900"
                        End If
                        If DirectCast(row.FindControl("txtStartDate"), TextBox).Text <> NE.First.StartDate.ToString() And DirectCast(row.FindControl("txtStartDate"), TextBox).Text <> Nothing Then
                            NEU.StartDateBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtTitle"), TextBox).Text <> NE.First.Title Then
                            NEU.TitleBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtConfidentialityForm"), TextBox).Text <> NE.First.ConfidentialityForm Then
                            NEU.ConfidentialityFormBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtSentToDataSecurity"), TextBox).Text <> NE.First.SentToDataSecurity Then
                            NEU.SentToDataSecurityBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtWelcomeEmail"), TextBox).Text <> NE.First.WelcomeEmail Then
                            NEU.WelcomeEmailBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtAccount"), TextBox).Text <> NE.First.Account Then
                            NEU.AccountBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtUNETAccount"), TextBox).Text <> NE.First.UNETAccount Then
                            NEU.UNETAccountBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtPhoneVoicemail"), TextBox).Text <> NE.First.PhoneVoicemail Then
                            NEU.PhoneVoicemailBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtEFax"), TextBox).Text <> NE.First.EFax Then
                            NEU.EFaxBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtMailGroups"), TextBox).Text <> NE.First.MailGroups Then
                            NEU.MailGroupsBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtAdobe"), TextBox).Text <> NE.First.Adobe Then
                            NEU.AdobeBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtWebEx"), TextBox).Text <> NE.First.WebEx Then
                            NEU.WebExBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtPremier"), TextBox).Text <> NE.First.Premier Then
                            NEU.PremierBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtOfficeDepot"), TextBox).Text <> NE.First.OfficeDepot Then
                            NEU.OfficeDepotBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtTMHPAccess"), TextBox).Text <> NE.First.TMHPAccess Then
                            NEU.TMHPAccessBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtMedicareAccess"), TextBox).Text <> NE.First.MedicareAccess Then
                            NEU.MedicareAccessBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtAllscriptsAccess"), TextBox).Text <> NE.First.AllscriptsAccess Then
                            NEU.AllscriptsAccessBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtAMBNurseClass"), TextBox).Text <> NE.First.AMBNurseClass Then
                            NEU.AMBNurseClassBy = Staff.First.Id
                        End If
                        If DirectCast(row.FindControl("txtSentAccessToEmployee"), TextBox).Text <> NE.First.SentAccessToEmployee Then
                            NEU.SentAccessToEmployeeBy = Staff.First.Id
                        End If

                    Catch ex As Exception

                    End Try

                    NEU.ModifyBy = hfUser.Value
                    NEU.ModifyDate = Now.ToString("G")

                    TPDC.SubmitChanges()
                    LinqNewEmployee.OrderBy = Me.ViewState("LinqNewEmployeeOrderBy")
                    GridViewNewEmployee.DataBind()

                    lbNewEmployeeMessage.Text = "Record has been updated! </br>"
                    lbNewEmployeeMessage.ForeColor = Drawing.Color.Green
                Catch ex As Exception
                    lbNewEmployeeMessage.Text = "Your Record was Not Saved! </br>"
                    lbNewEmployeeMessage.ForeColor = Drawing.Color.Red
                End Try

            Else

                LinqNewEmployee.OrderBy = Me.ViewState("LinqNewEmployeeOrderBy")
                GridViewNewEmployee.DataBind()

            End If

        End With

    End Sub

    Private Function funcStaffCode() As String

        Dim AA = (From p In TPDC.lkpBackOfficeWorkOrderUsers
                  Order By p.Id Ascending
                  Select p.Id, p.Color).ToList()

        For Each row In AA
            StaffColor(row.Id) = row.Color
        Next

        Return True

    End Function

    Protected Sub btnRestore_Click() Handles btnRestore.Click

        If ddEmployee.SelectedValue <> Nothing Then
            Dim NE = (From p In TPDC.tblBackOfficeNewEmployeeProcesses
                      Where p.Id.Equals(ddEmployee.SelectedValue)).ToList(0)

            NE.Completed = False
            TPDC.SubmitChanges()

            ddEmployee.Items.Clear()
            ddEmployee.Items.Insert(0, New ListItem(String.Empty, String.Empty))
            ddEmployee.ClearSelection()
            ddEmployee.DataBind()
            GridViewNewEmployee.DataBind()

        End If

    End Sub

    Private Function funcLegend() As String

        Dim LG = From p In TPDC.lkpBackOfficeWorkOrderUsers
                 Order By p.tblStaff.FName
                 Select p.Id, p.Color, p.tblStaff.FName

        Dim rowcount As Integer = 0
        For Each row In LG
            rowcount += 1
        Next

        For Each row In LG
            rowcount -= 1
            Dim lbLegendD = New Label()
            lbLegendD.Text = row.FName & ", "
            lbLegendD.ID = "lbLegend" & row.Id
            lbLegendD.ForeColor = Drawing.ColorTranslator.FromHtml(row.Color)
            If rowcount = 0 Then
                lbLegendD.Text = lbLegendD.Text.Replace(", ", "")
            End If
            lbLegend.Controls.Add(lbLegendD)
        Next


        Return True
    End Function

    Protected Sub ddEmployee_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ddEmployee As DropDownList = CType(GridViewNewEmployee.HeaderRow.FindControl("ddEmployee"), DropDownList)
        Dim rfvEmployeeTemp As RequiredFieldValidator = CType(GridViewNewEmployee.HeaderRow.FindControl("rfvEmployeeTemp"), RequiredFieldValidator)
        If ddEmployee.SelectedValue <> Nothing Then
            rfvEmployeeTemp.Enabled = False
        Else
            rfvEmployeeTemp.Enabled = True
        End If

    End Sub

    Protected Sub Sort_OnClick(ByVal Sender As Object, ByVal e As EventArgs)

        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkIT"
                sortDirection = If(Me.ViewState("linkIT") Is Nothing, "ASC", If(Me.ViewState("linkIT") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkIT") = sortDirection
                sortExpression = "lkpBackOfficeWorkOrderUser.tblStaff.FName"
            Case "linkEmployee"
                sortDirection = If(Me.ViewState("linkEmployee") Is Nothing, "ASC", If(Me.ViewState("linkEmployee") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkEmployee") = sortDirection
                sortExpression = "EmployeeTemp " & sortDirection & ", tblStaff1.FName"
            Case "linkStartDate"
                sortDirection = If(Me.ViewState("linkStartDate") Is Nothing, "ASC", If(Me.ViewState("linkStartDate") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkStartDate") = sortDirection
                sortExpression = "StartDate"
            Case "linkIncomingStatus"
                sortDirection = If(Me.ViewState("linkIncomingStatus") Is Nothing, "ASC", If(Me.ViewState("linkIncomingStatus") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkIncomingStatus") = sortDirection
                sortExpression = "lkpBackOfficeIncomingStatus.Status"
            Case "linkSupervisor"
                sortDirection = If(Me.ViewState("linkSupervisor") Is Nothing, "ASC", If(Me.ViewState("linkSupervisor") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkSupervisor") = sortDirection
                sortExpression = "tblStaff.FName"
            Case "linkTitle"
                sortDirection = If(Me.ViewState("linkTitle") Is Nothing, "ASC", If(Me.ViewState("linkTitle") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkTitle") = sortDirection
                sortExpression = "Title"
            Case "linkConfidentialityForm"
                sortDirection = If(Me.ViewState("linkConfidentialityForm") Is Nothing, "ASC", If(Me.ViewState("linkConfidentialityForm") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkConfidentialityForm") = sortDirection
                sortExpression = "ConfidentialityForm"
            Case "linkSentToDataSecurity"
                sortDirection = If(Me.ViewState("linkSentToDataSecurity") Is Nothing, "ASC", If(Me.ViewState("linkSentToDataSecurity") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkSentToDataSecurity") = sortDirection
                sortExpression = "SentToDataSecurity"
            Case "linkWelcomeEmail"
                sortDirection = If(Me.ViewState("linkWelcomeEmail") Is Nothing, "ASC", If(Me.ViewState("linkWelcomeEmail") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkWelcomeEmail") = sortDirection
                sortExpression = "WelcomeEmail"
            Case "linkAccount"
                sortDirection = If(Me.ViewState("linkAccount") Is Nothing, "ASC", If(Me.ViewState("linkAccount") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkAccount") = sortDirection
                sortExpression = "Account"
            Case "linkUNETAccount"
                sortDirection = If(Me.ViewState("linkUNETAccount") Is Nothing, "ASC", If(Me.ViewState("linkUNETAccount") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkUNETAccount") = sortDirection
                sortExpression = "UNETAccount"
            Case "linkPhoneVoicemail"
                sortDirection = If(Me.ViewState("linkPhoneVoicemail") Is Nothing, "ASC", If(Me.ViewState("linkPhoneVoicemail") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkPhoneVoicemail") = sortDirection
                sortExpression = "PhoneVoicemail"
            Case "linkEFax"
                sortDirection = If(Me.ViewState("linkEFax") Is Nothing, "ASC", If(Me.ViewState("linkEFax") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkEFax") = sortDirection
                sortExpression = "EFax"
            Case "linkMailGroups"
                sortDirection = If(Me.ViewState("linkMailGroups") Is Nothing, "ASC", If(Me.ViewState("linkMailGroups") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkMailGroups") = sortDirection
                sortExpression = "MailGroups"
            Case "linkAdobe"
                sortDirection = If(Me.ViewState("linkAdobe") Is Nothing, "ASC", If(Me.ViewState("linkAdobe") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkAdobe") = sortDirection
                sortExpression = "Adobe"
            Case "linkWebEx"
                sortDirection = If(Me.ViewState("linkWebEx") Is Nothing, "ASC", If(Me.ViewState("linkWebEx") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkWebEx") = sortDirection
                sortExpression = "WebEx"
            Case "linkPremier"
                sortDirection = If(Me.ViewState("linkPremier") Is Nothing, "ASC", If(Me.ViewState("linkPremier") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkPremier") = sortDirection
                sortExpression = "Premier"
            Case "linkOfficeDepot"
                sortDirection = If(Me.ViewState("linkOfficeDepot") Is Nothing, "ASC", If(Me.ViewState("linkOfficeDepot") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkOfficeDepot") = sortDirection
                sortExpression = "OfficeDepot"
            Case "linkTMHPAccess"
                sortDirection = If(Me.ViewState("linkTMHPAccess") Is Nothing, "ASC", If(Me.ViewState("linkTMHPAccess") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkTMHPAccess") = sortDirection
                sortExpression = "TMHPAccess"
            Case "linkMedicareAccess"
                sortDirection = If(Me.ViewState("linkMedicareAccess") Is Nothing, "ASC", If(Me.ViewState("linkMedicareAccess") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkMedicareAccess") = sortDirection
                sortExpression = "MedicareAccess"
            Case "linkAllscriptsAccess"
                sortDirection = If(Me.ViewState("linkAllscriptsAccess") Is Nothing, "ASC", If(Me.ViewState("linkAllscriptsAccess") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkAllscriptsAccess") = sortDirection
                sortExpression = "AllscriptsAccess"
            Case "linkAMBNurseClass"
                sortDirection = If(Me.ViewState("linkAMBNurseClass") Is Nothing, "ASC", If(Me.ViewState("linkAMBNurseClass") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkAMBNurseClass") = sortDirection
                sortExpression = "AMBNurseClass"
            Case "linkSentAccessToEmployee"
                sortDirection = If(Me.ViewState("linkSentAccessToEmployee") Is Nothing, "ASC", If(Me.ViewState("linkSentAccessToEmployee") = "ASC", "DESC", "ASC"))
                Me.ViewState("linkSentAccessToEmployee") = sortDirection
                sortExpression = "SentAccessToEmployee"
            Case Else
                Return
        End Select

        LinqNewEmployee.OrderBy = sortExpression & " " & sortDirection
        Me.ViewState("LinqNewEmployeeOrderBy") = LinqNewEmployee.OrderBy
        GridViewNewEmployee.DataBind()

    End Sub

    Protected Sub btnReturn_Click(sender As Object, e As System.EventArgs) Handles btnReturn.Click

        Response.Redirect(hfBack.Value.ToString)

    End Sub

End Class
