Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail

Partial Class Pages_TimeStudyApproval
    Inherits System.Web.UI.Page

    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        With Me

            If Not IsPostBack Then

                hfLookUpUserId.Value = "123abc7e-21e4-4142-86ea-70aad3abc123"
                hfUserId.Value = "123abc7e-21e4-4142-86ea-70aad3abc123"
                Try
                    Dim TPDCStaff As New MyPortfolioDbDataContext
                    Dim STF = From u In TPDCStaff.tblStaffs
                              Where u.UserId.Equals(Trim(hfLookUpUserId.Value))
                              Select u.UserId, u.FName, u.LName

                    lbViewTheTimeStudyForm.Text = "Pre-Transplant Time Study Approvals:<br/>" & Trim(STF.First.LName) & ", " & Trim(STF.First.FName)
                Catch ex As Exception
                    lbViewTheTimeStudyForm.Text = "Pre-Transplant Time Study Approvals"
                End Try

            Else

                'lbViewTheTimeStudyForm.Text = "Pre-Transplant Time Study Approvals"
                'lbTitle.Text = lbViewTheTimeStudyForm.Text

                'btnYearlyReport.Visible = True User.IsInRole("Administrator") OrElse User.IsInRole("UTC Staff Administrator")
                'ddyear.Visible = True User.IsInRole("Administrator") OrElse User.IsInRole("UTC Staff Administrator")
                'btnReminder.Visible = True User.IsInRole("Administrator") OrElse User.IsInRole("UTC Staff Administrator")
                'btnDelinquent.Visible = True User.IsInRole("Administrator") OrElse User.IsInRole("UTC Staff Administrator")
                'hfUserType.Value = "TSA"

                'If hfFrom.Value = "Adm" Then
                '    'Admin View, can view everyone
                'Else
                '    'Check if user is an approver, if not, redirect back
                '    Try
                '        Dim UT = From p In TPDC.tblStaffUsersInRoles
                '                 From q In TPDC.tblStaffApproverLinks.Where(Function(a) a.StaffRoleIdApprover = p.StaffRoleId)
                '                 Where p.StaffUserId.Equals(hfUserId.Value)
                '                 Select p.StaffRoleId, p.StaffUserId

                '        UT.First.StaffUserId.ToString()
                '    Catch ex As Exception
                '        Response.Redirect(hfBack.Value.ToString)
                '    End Try
                'End If

            End If

            lbViewTheTimeStudyForm.Text = "Pre-Transplant Time Study Approvals"
            lbTitle.Text = lbViewTheTimeStudyForm.Text

            btnYearlyReport.Visible = True
            ddyear.Visible = True
            btnReminder.Visible = True
            btnDelinquent.Visible = True
            hfUserType.Value = "TSA"

            lbTimeStudyInfo.Text = "&bull; The approvers can select a date to see all users assigned to them, managed in the 'Time Study User Management' page. <br />"
            lbTimeStudyInfo.Text += "&bull; They can see the status if the time study has not been started, opened, or sent by the user. <br />"
            lbTimeStudyInfo.Text += "&bull; They can view the report and they can choose to approve or disapprove the time study. <br />"
            lbTimeStudyInfo.Text += "&bull; Dissaproving will unlock the the time study for the user for resubmission. <br />"
            lbTimeStudyInfo.Text += "&bull; Administrators can send email reminders to users about the next upcoming time study or delinquent time studies. <br />"
            lbTimeStudyInfo.Text += "&bull; The email will give information on the status of all the user's time studies for the year and will cc their approver. <br />"
            lbTimeStudyInfo.Text += "&bull; Administrators can view a yearly report of all users and their time studies broken down into percentage of each category."

        End With

    End Sub

    Protected Sub GridViewTimeStudy_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewTimeStudy.RowDataBound

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

                Dim lbStatus As Label = TryCast(e.Row.FindControl("lbStatus"), Label)
                If lbStatus.Text = "Approved" Then
                    lbStatus.ForeColor = Drawing.Color.Green
                    Dim cbApprove As CheckBox = TryCast(e.Row.FindControl("cbApprove"), CheckBox)
                    cbApprove.Enabled = False
                    cbApprove.Checked = True
                ElseIf lbStatus.Text = "Open/Not Submitted" Then
                    lbStatus.ForeColor = Drawing.Color.SlateGray
                    Dim cbApprove As CheckBox = TryCast(e.Row.FindControl("cbApprove"), CheckBox)
                    cbApprove.Enabled = False
                    cbApprove.Checked = False
                    Dim cbDisapprove As CheckBox = TryCast(e.Row.FindControl("cbDisapprove"), CheckBox)
                    cbDisapprove.Enabled = False
                ElseIf lbStatus.Text = "Sent/Pending Approval" Then
                    lbStatus.ForeColor = Drawing.Color.Red
                    Dim cbApprove As CheckBox = TryCast(e.Row.FindControl("cbApprove"), CheckBox)
                    cbApprove.Checked = False
                Else
                    lbStatus.Text = "Not Started"
                    lbStatus.ForeColor = Drawing.Color.Orange
                    Dim cbApprove As CheckBox = TryCast(e.Row.FindControl("cbApprove"), CheckBox)
                    Dim cbDisapprove As CheckBox = TryCast(e.Row.FindControl("cbDisapprove"), CheckBox)
                    cbApprove.Enabled = False
                    cbDisapprove.Enabled = False
                    Dim linkViewReport As LinkButton = TryCast(e.Row.FindControl("linkViewReport"), LinkButton)
                    linkViewReport.Enabled = False
                End If

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            End If

        End With

    End Sub

    Protected Sub GridViewTimeStudy_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Report" Then

                Dim MyUserIdReport As String = Nothing
                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                MyUserIdReport = DirectCast(row.FindControl("lbUserId"), Label).Text

                ScriptManager.RegisterStartupScript(Me, [GetType](), "ViewReport", "window.open('/Pages/TimeStudyPage.aspx?D=" & hfStudyDate.Value & "&U=" & MyUserIdReport & "&TSA=" & hfUserType.Value & "','ViewReport','height=980,width=1040,status=no,resizable=yes,scrollbars=yes,toolbar=no,location=no,menubar=no');", True)

            End If

        End With

    End Sub

    Protected Sub GridViewTimeStudy_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            SQLTimeStudy.SelectCommand = IsInSQLCommand(Nothing)
            GridViewTimeStudy.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnStudyDate_Click(sender As Object, e As System.EventArgs)

        If Page.IsValid Then

            Try
                lbMessage.Text = ""
                hfStudyDate.Value = ddStudyDate.SelectedValue
                hfDateText.Value = Replace(ddStudyDate.SelectedItem.Text, "/", "")
                Dim vtemp As String = Left(hfDateText.Value, 4)
                hfDateText.Value = hfDateText.Value.Remove(0, 4)
                hfDateText.Value += vtemp

                lbStudyDate.Text = hfStudyDate.Value
                PanelTimeStudyApproval.Visible = True
                PanelTimeStudyDate.Visible = False
                btnSelectStudyDateBack.Visible = True
                SQLTimeStudy.SelectCommand = IsInSQLCommand(Nothing)
                GridViewTimeStudy.DataBind()
            Catch ex As Exception

            End Try

        End If

    End Sub

    Protected Sub btnYearlyReport_Click(sender As Object, e As System.EventArgs)

        Response.Redirect("ReportTimeStudyYearlyPageImage.aspx")

    End Sub

    Protected Sub btnReminder_Click(sender As Object, e As System.EventArgs)

        lbMessage.ForeColor = Drawing.Color.Green
        lbMessage.Text = "Email sent to all users that are required to complete the current Time Study."

        'Dim MyDataTable As New DataTable()
        'Dim MyCon As New SqlConnection(ConfigurationManager.ConnectionStrings("MyPortfolioConnectionString").ConnectionString)

        'Dim MyQuery As String = "SELECT CONVERT(date, GETDATE(), 101) AS TodayDate, "
        'MyQuery += "ISNULL((Select TOP 1 TSDate.PreTransplantDate "
        'MyQuery += "FROM lkpPreTransplantDate AS TSDate "
        'MyQuery += "WHERE DATEDIFF(day, TSDate.PreTransplantDate, GETDATE()) < 7 AND DATEDIFF(day, TSDate.PreTransplantDate, GETDATE()) >= 0), "
        'MyQuery += "(Select TOP 1 TSDate.PreTransplantDate "
        'MyQuery += "FROM lkpPreTransplantDate AS TSDate "
        'MyQuery += "WHERE TSDate.PreTransplantDate > CONVERT(date, GETDATE(), 101))) AS TimeStudyDate, "
        'MyQuery += "Staff.FName, Staff.LName, Staff.PrieMail "
        'MyQuery += "FROM tblStaffUsersInRoles AS Users LEFT OUTER JOIN tblStaff AS Staff ON Users.StaffUserId = staff.UserId "
        'MyQuery += "WHERE Users.StaffRoleId <> '589a276a-8cbd-4f52-af9c-fc2128237b83' "

        'Dim MyCmd As New SqlCommand(MyQuery, MyCon)
        'MyCon.Open()
        'Dim MyReader As SqlDataReader = MyCmd.ExecuteReader
        'Dim smtp As New SmtpClient
        'Dim MyMail As New MailMessage
        'Dim MyFrom As New MailAddress("no-reply@uthscsa.edu", "UTC No-Reply")
        'Dim currentUser As MembershipUser = Membership.GetUser()
        'Dim MyTo As New MailAddress(currentUser.Email.ToString)
        ''Dim MyCC As New MailAddress(currentUser.Email.ToString)

        'Dim UT = From p In TPDC.tblStaffs
        '         Where p.UserId.Equals(currentUser.ProviderUserKey)
        '         Select p.FName, p.LName

        'MyMail.BodyEncoding = System.Text.Encoding.UTF8
        'MyMail.To.Add(MyTo)
        ''MyMail.CC.Add(MyCC)
        'MyMail.From = MyFrom
        'MyMail.Priority = MailPriority.High
        'MyMail.IsBodyHtml = True
        'Dim MyTSDate As String = Nothing

        'While MyReader.Read()
        '    Try
        '        MyTSDate = MyReader("TimeStudyDate").ToString
        '        MyMail.Bcc.Add(MyReader("PrieMail").ToString)
        '    Catch ex As Exception

        '    End Try
        'End While

        'MyMail.Subject = "++ Time Study Reminder"
        'MyMail.Body += "Greetings! </br>"
        'MyMail.Body += "This is a reminder that there is a Time Study for the week of <b>" & MyTSDate & "</b>. </br></br>"
        'MyMail.Body += "To document your Time Studies please log in to: </br>"
        'MyMail.Body += "Choose Staff then User Time Study.</br></br>"
        'MyMail.Body += "Thank you, </br>" & UT.First.FName & " " & UT.First.LName & "</br> "

        'smtp.Send(MyMail)

        'MyReader.Close()
        'MyCon.Close()

    End Sub

    Protected Sub btnDelinquent_Click(sender As Object, e As System.EventArgs)

        lbMessage.ForeColor = Drawing.Color.Green
        lbMessage.Text = "Email sent to all users with delinquent Time Studies."

        'Dim MyDataTable As New DataTable()
        'Dim MyCon As New SqlConnection(ConfigurationManager.ConnectionStrings("MyPortfolioDbDataContext").ConnectionString)
        'Dim currentUser As MembershipUser = Membership.GetUser()

        'Dim MyQuery As String = "SELECT Staff.UserId, Staff.FName, Staff.LName, Staff.PrieMail, "
        'MyQuery += "CONVERT(varchar, Staff.TimeStudyStartDate, 101) AS TSStartDate, "

        ''MyQuery += "ISNULL(STUFF((SELECT + '</br>' + PreDateA.PreTransplantDate + ' ' + ISNULL(Study.Status, 'Not Started') + ' ' "
        ''MyQuery += "FROM tblStaffUsersInRoles AS UsersA LEFT OUTER JOIN "
        ''MyQuery += "tblStaff AS StaffA ON UsersA.StaffUserId = StaffA.UserId LEFT OUTER JOIN "
        ''MyQuery += "lkpPreTransplantDate AS PreDateA ON PreDateA.Active = 'True' OUTER APPLY "
        ''MyQuery += "(SELECT TOP 1 * FROM tblStaffTimeStudy AS StudyA WHERE StudyA.UserId = Staff.UserId AND StudyA.PreTransplantDate = PreDateA.Id) AS Study "
        ''MyQuery += "WHERE UsersA.StaffUserId = Staff.UserId AND "
        ''MyQuery += "ISNULL((SELECT TOP 1 TSA.Status "
        ''MyQuery += "FROM tblStaffTimeStudy AS TSA "
        ''MyQuery += "WHERE TSA.UserId = users.StaffUserId AND TSA.PreTransplantDate = PreDateA.Id), 'Not Started') <> 'Approved' "
        ''MyQuery += "And ISNULL(DateDiff(Day, Convert(varchar, StaffA.TimeStudyStartDate, 101), PreDateA.PreTransplantDate), 0) >= 0 "
        ''MyQuery += "And ISNULL(DateDiff(Day, DATEADD(day, 7, PreDateA.PretransplantDate), Convert(varchar, GETDATE(), 101)), 0) >= 0 "
        ''MyQuery += "For XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)'), 1, 5, ''), 'Complete') AS TSStatus,  "

        'MyQuery += "ISNULL(CASE "
        'MyQuery += "WHEN "
        'MyQuery += "ISNULL(STUFF((SELECT + '</br>' + PreDateA.PreTransplantDate + ' ' + ISNULL(Study.Status, 'Not Started') + ' ' "
        'MyQuery += "FROM tblStaffUsersInRoles AS UsersA LEFT OUTER JOIN "
        'MyQuery += "tblStaff AS StaffA On UsersA.StaffUserId = StaffA.UserId LEFT OUTER JOIN "
        'MyQuery += "lkpPreTransplantDate AS PreDateA On PreDateA.Active = 'True' OUTER APPLY "
        'MyQuery += "(SELECT TOP 1 * FROM tblStaffTimeStudy AS StudyA WHERE StudyA.UserId = Staff.UserId And StudyA.PreTransplantDate = PreDateA.Id) AS Study "
        'MyQuery += "WHERE UsersA.StaffUserId = Staff.UserId And "
        'MyQuery += "ISNULL((SELECT TOP 1 TSA.Status "
        'MyQuery += "FROM tblStaffTimeStudy AS TSA "
        'MyQuery += "Where TSA.UserId = users.StaffUserId And TSA.PreTransplantDate = PreDateA.Id), 'Not Started') <> '0' "
        'MyQuery += "And ISNULL(DateDiff(Day, Convert(varchar, StaffA.TimeStudyStartDate, 101), PreDateA.PreTransplantDate), 0) >= 0 "
        'MyQuery += "And ISNULL(DateDiff(Day, DATEADD(day, 7, PreDateA.PretransplantDate), Convert(varchar, GETDATE(), 101)), 0) >= 0 "
        'MyQuery += "For XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)'), 1, 5, ''), 'Complete') Like '%Not%'  "
        'MyQuery += "Or "
        'MyQuery += "ISNULL(STUFF((SELECT + '</br>' + PreDateA.PreTransplantDate + ' ' + ISNULL(Study.Status, 'Not Started') + ' '  "
        'MyQuery += "FROM tblStaffUsersInRoles AS UsersA LEFT OUTER JOIN "
        'MyQuery += "tblStaff AS StaffA On UsersA.StaffUserId = StaffA.UserId LEFT OUTER JOIN "
        'MyQuery += "lkpPreTransplantDate AS PreDateA On PreDateA.Active = 'True' OUTER APPLY "
        'MyQuery += "(SELECT TOP 1 * FROM tblStaffTimeStudy AS StudyA WHERE StudyA.UserId = Staff.UserId And StudyA.PreTransplantDate = PreDateA.Id) AS Study "
        'MyQuery += "WHERE UsersA.StaffUserId = Staff.UserId And "
        'MyQuery += "ISNULL((SELECT TOP 1 TSA.Status "
        'MyQuery += "FROM tblStaffTimeStudy AS TSA "
        'MyQuery += "Where TSA.UserId = users.StaffUserId And TSA.PreTransplantDate = PreDateA.Id), 'Not Started') <> '0' "
        'MyQuery += "And ISNULL(DateDiff(Day, Convert(varchar, StaffA.TimeStudyStartDate, 101), PreDateA.PreTransplantDate), 0) >= 0 "
        'MyQuery += "And ISNULL(DateDiff(Day, DATEADD(day, 7, PreDateA.PretransplantDate), Convert(varchar, GETDATE(), 101)), 0) >= 0 "
        'MyQuery += "For XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)'), 1, 5, ''), 'Complete') Like '%Open%'  "
        'MyQuery += "Or "
        'MyQuery += "ISNULL(STUFF((SELECT + '</br>' + PreDateA.PreTransplantDate + ' ' + ISNULL(Study.Status, 'Not Started') + ' '  "
        'MyQuery += "FROM tblStaffUsersInRoles AS UsersA LEFT OUTER JOIN "
        'MyQuery += "tblStaff AS StaffA On UsersA.StaffUserId = StaffA.UserId LEFT OUTER JOIN "
        'MyQuery += "lkpPreTransplantDate AS PreDateA On PreDateA.Active = 'True' OUTER APPLY "
        'MyQuery += "(SELECT TOP 1 * FROM tblStaffTimeStudy AS StudyA WHERE StudyA.UserId = Staff.UserId And StudyA.PreTransplantDate = PreDateA.Id) AS Study "
        'MyQuery += "WHERE UsersA.StaffUserId = Staff.UserId And "
        'MyQuery += "ISNULL((SELECT TOP 1 TSA.Status "
        'MyQuery += "FROM tblStaffTimeStudy AS TSA "
        'MyQuery += "Where TSA.UserId = users.StaffUserId And TSA.PreTransplantDate = PreDateA.Id), 'Not Started') <> '0' "
        'MyQuery += "And ISNULL(DateDiff(Day, Convert(varchar, StaffA.TimeStudyStartDate, 101), PreDateA.PreTransplantDate), 0) >= 0 "
        'MyQuery += "And ISNULL(DateDiff(Day, DATEADD(day, 7, PreDateA.PretransplantDate), Convert(varchar, GETDATE(), 101)), 0) >= 0 "
        'MyQuery += "For XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)'), 1, 5, ''), 'Complete') Like '%Sent%'  "
        'MyQuery += "THEN  "
        'MyQuery += "ISNULL(STUFF((SELECT + '</br>' + PreDateA.PreTransplantDate + ' ' + ISNULL(Study.Status, 'Not Started') + ' '  "
        'MyQuery += "FROM tblStaffUsersInRoles AS UsersA LEFT OUTER JOIN "
        'MyQuery += "tblStaff AS StaffA On UsersA.StaffUserId = StaffA.UserId LEFT OUTER JOIN "
        'MyQuery += "lkpPreTransplantDate AS PreDateA On PreDateA.Active = 'True' OUTER APPLY "
        'MyQuery += "(SELECT TOP 1 * FROM tblStaffTimeStudy AS StudyA WHERE StudyA.UserId = Staff.UserId And StudyA.PreTransplantDate = PreDateA.Id) AS Study "
        'MyQuery += "WHERE UsersA.StaffUserId = Staff.UserId And "
        'MyQuery += "ISNULL((SELECT TOP 1 TSA.Status "
        'MyQuery += "FROM tblStaffTimeStudy AS TSA "
        'MyQuery += "Where TSA.UserId = users.StaffUserId And TSA.PreTransplantDate = PreDateA.Id), 'Not Started') <> '0' "
        'MyQuery += "And ISNULL(DateDiff(Day, Convert(varchar, StaffA.TimeStudyStartDate, 101), PreDateA.PreTransplantDate), 0) >= 0 "
        'MyQuery += "And ISNULL(DateDiff(Day, DATEADD(day, 7, PreDateA.PretransplantDate), Convert(varchar, GETDATE(), 101)), 0) >= 0 "
        'MyQuery += "For XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)'), 1, 5, ''), 'Complete')  "
        'MyQuery += "End, 'Complete')  "
        'MyQuery += "AS TSStatus,  "

        'MyQuery += "(SELECT StaffAP.PrieMail "
        'MyQuery += "FROM tblStaffApproverLink AS Link LEFT OUTER JOIN "
        'MyQuery += "tblStaffUsersInRoles AS UsersAP ON UsersAP.StaffRoleId = Link.StaffRoleIdApprover LEFT OUTER JOIN "
        'MyQuery += "tblStaff AS StaffAP ON StaffAP.UserId = UsersAP.StaffUserId "
        'MyQuery += " WHERE Link.StaffRoleIdEmployee = Users.StaffRoleId) AS ApproverEmail, "
        'MyQuery += " (SELECT StaffB.FName + ' ' + StaffB.LName "
        'MyQuery += " FROM aspnet_Users AS UsersB LEFT OUTER JOIN "
        'MyQuery += " tblStaff AS StaffB On StaffB.UserId = UsersB.UserId "
        'MyQuery += " Where UsersB.LoweredUserName = '" & currentUser.UserName.ToLower() & "') AS SenderName "
        'MyQuery += "FROM tblStaffUsersInRoles AS Users LEFT OUTER JOIN "
        'MyQuery += "tblStaff AS Staff ON Users.StaffUserId = staff.UserId "
        'MyQuery += "WHERE Users.StaffRoleId <> '589a276a-8cbd-4f52-af9c-fc2128237b83' "

        'Dim MyCmd As New SqlCommand(MyQuery, MyCon)
        'MyCon.Open()
        'Dim MyReader As SqlDataReader = MyCmd.ExecuteReader
        'Dim smtp As New SmtpClient
        'Dim MyFrom As New MailAddress("no-reply@uthscsa.edu", "UTC No-Reply")

        'While MyReader.Read()
        '    Try
        '        If MyReader("TSStatus").ToString() <> "Complete" Then
        '            Dim MyMail As New MailMessage
        '            MyMail.BodyEncoding = System.Text.Encoding.UTF8
        '            MyMail.To.Add(MyReader("PrieMail").ToString())
        '            MyMail.CC.Add(currentUser.Email.ToString)
        '            MyMail.CC.Add(MyReader("ApproverEmail").ToString())
        '            MyMail.From = MyFrom
        '            MyMail.Priority = MailPriority.High
        '            MyMail.IsBodyHtml = True

        '            MyMail.Subject = "++ Time Study Delinquencies"
        '            MyMail.Body += "Hello " & MyReader("FName").ToString() & " " & MyReader("LName").ToString() & ", </br>"
        '            MyMail.Body += "The following shows you have at least one delinquent Time Study. <br>"
        '            MyMail.Body += "Please review and complete any delinquent Time Studies as soon as possible.</br></br>"

        '            MyMail.Body += "<b>Time Study Start Date: " & MyReader("TSSTartDate").ToString() & "</b></br></br> "

        '            MyMail.Body += "<b>" & MyReader("TSStatus").ToString & "</b></br></br>"

        '            MyMail.Body += "To document your Time Studies please log In To: </br>"
        '            MyMail.Body += "Choose Staff then User Time Study.</br></br>"
        '            MyMail.Body += "Thank you, </br>" & MyReader("SenderName").ToString() & "</br> "

        '            'smtp.Send(MyMail)
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End While

        'MyReader.Close()
        'MyCon.Close()

    End Sub

    Public Sub cbApprove_Checked(sender As Object, e As EventArgs)

        Dim cbAll As CheckBox = DirectCast(sender, CheckBox)
        Dim rowType As GridViewRow = DirectCast(cbAll.NamingContainer, GridViewRow)
        Dim lbStatus As Label = CType(rowType.FindControl("lbStatus"), Label)
        Dim lbStatusLog As Label = CType(rowType.FindControl("lbStatusLog"), Label)
        Dim cbA As CheckBox = CType(rowType.FindControl("cbApprove"), CheckBox)
        Dim cbD As CheckBox = CType(rowType.FindControl("cbDisapprove"), CheckBox)
        lbStatus.Text = "Approved"
        lbStatusLog.Text += "Approved " & Date.Today & "; "
        cbA.Checked = False
        cbD.Checked = False


        'Try
        '    Dim cbAll As CheckBox = DirectCast(sender, CheckBox)
        '    Dim row As GridViewRow = DirectCast(cbAll.NamingContainer, GridViewRow)
        '    Dim vUserId As Guid
        '    vUserId = Guid.Parse(DirectCast(row.FindControl("lbUserId"), Label).Text)

        '    Dim TS = From p In TPDC.tblStaffTimeStudies
        '             Where p.UserId.Equals(vUserId) And p.PreTransplantDate.Equals(hfStudyDate.Value)

        '    For Each rowTS In TS

        '        Dim TSU = (From p In TPDC.tblStaffTimeStudies
        '                   Where p.UserId.Equals(vUserId) And p.PreTransplantDate.Equals(hfStudyDate.Value) And p.Id.Equals(rowTS.Id)).ToList()(0)

        '        TSU.StatusLog = rowTS.StatusLog & "Approved " & Date.Today & "; "
        '        TSU.Status = "Approved"
        '        TSU.Locked = True
        '        DirectCast(row.FindControl("cbDisapprove"), CheckBox).Checked = False
        '        TSU.ModifyBy = hfUser.Value
        '        TSU.ModifyDate = Now.ToString("G")

        '        TPDC.SubmitChanges()
        '    Next

        'Catch ex As Exception

        'End Try
        'SQLTimeStudy.SelectCommand = IsInSQLCommand(Nothing)
        'GridViewTimeStudy.DataBind()

    End Sub

    Protected Sub cbDisapprove_Checked(sender As Object, e As System.EventArgs)

        Dim cbAll As CheckBox = DirectCast(sender, CheckBox)
        Dim rowType As GridViewRow = DirectCast(cbAll.NamingContainer, GridViewRow)
        Dim lbStatus As Label = CType(rowType.FindControl("lbStatus"), Label)
        Dim lbStatusLog As Label = CType(rowType.FindControl("lbStatusLog"), Label)
        Dim cbA As CheckBox = CType(rowType.FindControl("cbApprove"), CheckBox)
        Dim cbD As CheckBox = CType(rowType.FindControl("cbDisapprove"), CheckBox)
        lbStatus.Text = "Disapproved"
        lbStatusLog.Text += "Disapproved " & Date.Today & "; "
        cbA.Checked = False
        cbD.Checked = False
        cbA.Enabled = True

        'Try
        '    Dim cbAll As CheckBox = DirectCast(sender, CheckBox)
        '    Dim row As GridViewRow = DirectCast(cbAll.NamingContainer, GridViewRow)
        '    Dim vUserId As Guid
        '    vUserId = Guid.Parse(DirectCast(row.FindControl("lbUserId"), Label).Text)

        '    Dim TS = From p In TPDC.tblStaffTimeStudies
        '             Where p.UserId.Equals(vUserId) And p.PreTransplantDate.Equals(hfStudyDate.Value)

        '    For Each rowTS In TS

        '        Dim TSU = (From p In TPDC.tblStaffTimeStudies
        '                   Where p.UserId.Equals(vUserId) And p.PreTransplantDate.Equals(hfStudyDate.Value) And p.Id.Equals(rowTS.Id)).ToList()(0)

        '        TSU.StatusLog = rowTS.StatusLog & "Disapproved " & Date.Today & "; "
        '        TSU.Status = "Open/Not Submitted"
        '        TSU.Locked = False
        '        DirectCast(row.FindControl("cbApprove"), CheckBox).Checked = False
        '        TSU.ModifyBy = hfUser.Value
        '        TSU.ModifyDate = Now.ToString("G")

        '        TPDC.SubmitChanges()
        '    Next

        'Catch ex As Exception

        'End Try
        'SQLTimeStudy.SelectCommand = IsInSQLCommand(Nothing)
        'GridViewTimeStudy.DataBind()

    End Sub

    Protected Sub btnSelectStudyDateBack_Click(sender As Object, e As System.EventArgs)

        PanelTimeStudyDate.Visible = True
        PanelTimeStudyApproval.Visible = False
        btnSelectStudyDateBack.Visible = False

    End Sub

    Protected Function IsInSQLCommand(ByVal MyCommand As String) As String

        MyCommand += "SELECT staff.UserId, staff.LName + ', ' + staff.FName AS Name, "
        MyCommand += "lkp.PreTransplantDate, "
        MyCommand += "(SELECT SUM (tsTotal.TotalHours) AS Expr1 "
        MyCommand += "FROM tblStaffTimeStudy AS tsTotal "
        MyCommand += "LEFT OUTER JOIN lkpPreTransplantDate AS td ON td.Id = tsTotal.PreTransplantDate "
        MyCommand += "WHERE tsTotal.UserId = staff.UserId And tsTotal.PreTransplantDate = '" & hfStudyDate.Value & "') AS TotalHours, "
        MyCommand += "ts.Locked, ts.Status, ts.StatusLog "

        MyCommand += "FROM tblStaffUsersInRoles AS role LEFT OUTER JOIN "
        If hfFrom.Value = "Adm" Then
            MyCommand += "tblStaff AS staff on staff.UserId = role.StaffUserId OUTER APPLY "
        Else
            MyCommand += "tblStaffApproverLink AS link on link.StaffRoleIdApprover = role.StaffRoleId LEFT OUTER JOIN "
            MyCommand += "tblStaffUsersInRoles AS employees on employees.StaffRoleId = link.StaffRoleIdEmployee LEFT OUTER JOIN "
            MyCommand += "tblStaff AS staff on staff.UserId = employees.StaffUserId OUTER APPLY "
        End If
        MyCommand += "(SELECT TOP 1 * FROM tblStaffTimeStudy AS ts WHERE staff.UserId = ts.UserId And ts.PreTransplantDate = '" & hfStudyDate.Value & "') AS ts "
        MyCommand += "LEFT OUTER JOIN lkpPreTransplantDate AS lkp ON ts.PreTransplantDate = lkp.Id "

        If hfFrom.Value = "Adm" Then
            If hfLookUpUserId.Value = Nothing Then

            Else
                MyCommand += "WHERE role.StaffUserId = '" & hfLookUpUserId.Value & "' "
            End If
        Else
            MyCommand += "WHERE role.StaffUserId = '" & hfUserId.Value & "' "
        End If

        MyCommand += "ORDER BY staff.LName, staff.FName "

        Return MyCommand

    End Function

End Class
