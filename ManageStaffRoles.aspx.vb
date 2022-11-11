Partial Class Pages_ManageStaffRoles
    Inherits System.Web.UI.Page

    Dim MyUser As String

    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'With Me

        '    'Try
        '    '    Dim currentUser As MembershipUser = Membership.GetUser()
        '    '    .MyUser = currentUser.UserName
        '    'Catch ex As Exception
        '    '    Response.Redirect("~/Account/ThankYou.aspx")
        '    'End Try

        'End With

        'If Not Page.IsPostBack Then

        '    Dim MyLogActivity As New LogActivity
        '    MyLogActivity.LogActivity("View Admin Staff Roles...", Request.RawUrl)

        'End If
        lbTimeStudyInfo.Text = "&bull; Administrators can create new staff position roles and can link approver roles to employee roles. <br />"
        lbTimeStudyInfo.Text += "&bull; This management system allows the link between approvers and employees to be dynamically changed as needed.  "
        lbmessage.Text = Nothing

    End Sub

    Protected Sub btnCreateRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateRole.Click

        lbError.Text = String.Empty
        lbErrorII.Text = String.Empty
        Dim MyNewRoleName As String = Trim(txtRoleName.Text)
        Dim MyApplicationId As New Guid
        MyApplicationId = Guid.Parse("d2495780-d874-4e8e-9e22-b500e6e2d75b")

        If Page.IsValid Then
            Dim MR = From M In TPDC.tblStaffRoles
                     Select M.StaffRoleName

            If Not MR.Contains(MyNewRoleName) Then

                Dim LD1 As New ListDictionary()
                LD1.Add("ApplicationId", MyApplicationId)
                LD1.Add("StaffRoleId", Guid.NewGuid)
                LD1.Add("StaffRoleName", MyNewRoleName)
                LD1.Add("StaffLoweredRoleName", MyNewRoleName.ToLower)
                LD1.Add("StaffDescription", Nothing)

                Try
                    LinqStaffRoles.Insert(LD1)
                    TPDC.SubmitChanges()
                    GridViewRoleList.DataBind()
                    txtRoleName.Text = String.Empty
                Catch ex As Exception

                End Try
            Else
                lbError.Text = "Staff Position Role Already Exists!"
            End If
        End If

    End Sub

    Protected Sub GridviewRoleList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If e.Row.RowType = DataControlRowType.Footer Then

                GridViewApproverLink.DataBind()

            End If

        End With

    End Sub

    Protected Sub GridviewApproverLink_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Add" Then

                lbError.Text = String.Empty
                lbErrorII.Text = String.Empty
                If Page.IsValid Then

                    Dim LD As New ListDictionary

                    Dim MyStaffRoleIdApprover As Guid
                    MyStaffRoleIdApprover = Guid.Parse(DirectCast(GridViewApproverLink.FooterRow.FindControl("ddApprover"), DropDownList).SelectedValue)
                    LD.Add("StaffRoleIdApprover", MyStaffRoleIdApprover)

                    Dim MyStaffRoleIdEmployee As Guid
                    MyStaffRoleIdEmployee = Guid.Parse(DirectCast(GridViewApproverLink.FooterRow.FindControl("ddEmployee"), DropDownList).SelectedValue)
                    LD.Add("StaffRoleIdEmployee", MyStaffRoleIdEmployee)

                    Try
                        LinqStaffMatch.Insert(LD)
                        LD.Clear()
                        GridViewApproverLink.DataBind()
                    Catch ex As Exception
                        lbErrorII.Text = "Your Record was Not Saved! (There can only be 1 Approver Role for each Employee Role.)"
                    End Try
                End If

            ElseIf e.CommandName = "Delete" Then

                lbError.Text = String.Empty
                lbErrorII.Text = String.Empty

            End If

        End With

    End Sub

    Protected Sub GridviewRoleList_RowDeleted(ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)

        lbError.Text = String.Empty
        lbErrorII.Text = String.Empty

        If TypeOf e.Exception Is Exception Then
            Dim sqlErrorCode As String = (CType(e.Exception, Exception)).Message
            If sqlErrorCode.Contains("REFERENCE constraint") Then
                lbmessage.Text = "*Error! Could not delete role because it is linked to another role.  <br />Please delete the link before deleting the role from the list."
                e.ExceptionHandled = True
            End If
        End If

    End Sub

    Protected Sub GridviewRoleList_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Dim row As GridViewRow = GridViewRoleList.Rows(e.RowIndex)
        Dim lbRoleName As Label = DirectCast(row.FindControl("lbRoleName"), Label)
        If lbRoleName.Text = "Executive Director" Or lbRoleName.Text = "IT" Or lbRoleName.Text = "IT Director" Then
            lbmessage.Text = "Cannot delete, this is protected for Demo purposes."
            e.Cancel = True
        End If

    End Sub

    Protected Sub GridviewApproverLink_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Dim row As GridViewRow = GridViewApproverLink.Rows(e.RowIndex)
        Dim lbApproverRoleName As Label = DirectCast(row.FindControl("lbApproverRoleName"), Label)
        Dim lbEmployeeRoleName As Label = DirectCast(row.FindControl("lbEmployeeRoleName"), Label)

        If (lbApproverRoleName.Text = "IT" And lbEmployeeRoleName.Text = "Executive Director") Or (lbApproverRoleName.Text = "IT Director" And lbEmployeeRoleName.Text = "IT") Then
            lbErrorII.Text = "Cannot delete, this is protected for Demo purposes."
            e.Cancel = True
        End If

    End Sub

End Class
