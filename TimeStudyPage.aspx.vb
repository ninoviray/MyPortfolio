Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Data.SqlClient

Partial Class Pages_TimeStudyPage
    Inherits System.Web.UI.Page

    Dim MyUser As String
    Dim dtTSRpt As New DataTable()
    Private CustomerReportTS As New ReportDocument()
    Dim MyDataTable As New DataTable()

    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Not IsPostBack Then
            Session("dtTSRpt") = Nothing
        End If

        hfDate.Value = Request.QueryString("D").ToString
        hfUserId.Value = Request.QueryString("U").ToString

        Try
            CustomerReportTS.Load(Server.MapPath("~/Reports/FormTimeStudy.rpt"))
            If IsNothing(Session("dtTSRpt")) Then
                dtTSRpt = BindTS()
                Session("dtTSRpt") = dtTSRpt
            Else
                dtTSRpt = Session("dtTSRpt")
            End If
            CustomerReportTS.SetDataSource(dtTSRpt)
            CrystalReportViewerTS.ReportSource = CustomerReportTS
            CrystalReportViewerTS.ShowFirstPage()

        Catch ex As Exception

        End Try

    End Sub

    Public Function BindTS() As DataTable

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("MyPortfolioConnectionString").ConnectionString)
        Dim MyString As String = Nothing

        Dim lkp = From p In TPDC.lkpPreTransplantDates
                  Where p.Id.Equals(hfDate.Value)
                  Select p.Id, p.PreTransplantDate

        hfDateText.Value = Replace(lkp.First.PreTransplantDate, "/", "")
        Dim vtemp As String = Left(hfDateText.Value, 4)
        hfDateText.Value = hfDateText.Value.Remove(0, 4)
        hfDateText.Value += vtemp

        MyString += "DECLARE @Date AS VARCHAR(10) "
        MyString += "SET @Date = '" & lkp.First.PreTransplantDate & "' "
        MyString += "SELECT        ISNULL(NULLIF (S.FName, '') + ' ', '') + ISNULL(NULLIF (S.MName, '') + ' ', '') + ISNULL(NULLIF (S.LName, ''), '') AS Name, "
        MyString += "S.EmployeeId, "

        MyString += "Convert(varchar, @Date, 101) As DateSun, "
        MyString += "Convert(varchar, DateAdd(Day, 1, @Date), 101) As DateMon, "
        MyString += "Convert(varchar, DateAdd(Day, 2, @Date), 101) As DateTue, "
        MyString += "Convert(varchar, DateAdd(Day, 3, @Date), 101) As DateWed, "
        MyString += "Convert(varchar, DateAdd(Day, 4, @Date), 101) As DateThu, "
        MyString += "Convert(varchar, DateAdd(Day, 5, @Date), 101) As DateFri, "
        MyString += "Convert(varchar, DateAdd(Day, 6, @Date), 101) As DateSat, "

        MyString += "TSKidney.SundayHours As PKidSun, "
        MyString += "TSKidney.MondayHours As PKidMon, "
        MyString += "TSKidney.TuesdayHours As PKidTue, "
        MyString += "TSKidney.WednesdayHours As PKidWed, "
        MyString += "TSKidney.ThursdayHours As PKidThu, "
        MyString += "TSKidney.FridayHours As PKidFri, "
        MyString += "TSKidney.SaturdayHours As PKidSat, "

        MyString += "ISNULL(TSKidney.SundayHours, '0') + ISNULL(TSKidney.MondayHours, '0') + ISNULL(TSKidney.TuesdayHours, '0') + ISNULL(TSKidney.WednesdayHours, '0') + "
        MyString += "ISNULL(TSKidney.ThursdayHours, '0') + ISNULL(TSKidney.FridayHours, '0') + ISNULL(TSKidney.SaturdayHours, '0') AS TotalKidney, "

        MyString += "TSLiver.SundayHours As PLivSun, "
        MyString += "TSLiver.MondayHours As PLivMon, "
        MyString += "TSLiver.TuesdayHours As PLivTue, "
        MyString += "TSLiver.WednesdayHours As PLivWed, "
        MyString += "TSLiver.ThursdayHours As PLivThu, "
        MyString += "TSLiver.FridayHours As PLivFri, "
        MyString += "TSLiver.SaturdayHours As PLivSat, "

        MyString += "ISNULL(TSLiver.SundayHours, '0') + ISNULL(TSLiver.MondayHours, '0') + ISNULL(TSLiver.TuesdayHours, '0') + ISNULL(TSLiver.WednesdayHours, '0') + "
        MyString += "ISNULL(TSLiver.ThursdayHours, '0') + ISNULL(TSLiver.FridayHours, '0') + ISNULL(TSLiver.SaturdayHours, '0') AS TotalLiver, "

        MyString += "TSLung.SundayHours As PLunSun, "
        MyString += "TSLung.MondayHours As PLunMon, "
        MyString += "TSLung.TuesdayHours As PLunTue, "
        MyString += "TSLung.WednesdayHours As PLunWed, "
        MyString += "TSLung.ThursdayHours As PLunThu, "
        MyString += "TSLung.FridayHours As PLunFri, "
        MyString += "TSLung.SaturdayHours As PLunSat, "

        MyString += "ISNULL(TSLung.SundayHours, '0') + ISNULL(TSLung.MondayHours, '0') + ISNULL(TSLung.TuesdayHours, '0') + ISNULL(TSLung.WednesdayHours, '0') + "
        MyString += "ISNULL(TSLung.ThursdayHours, '0') + ISNULL(TSLung.FridayHours, '0') + ISNULL(TSLung.SaturdayHours, '0') AS TotalLung, "

        MyString += "NULLIF(ISNULL(TSKidney.SundayHours, '0') + ISNULL(TSLiver.SundayHours, '0') + ISNULL(TSLung.SundayHours, '0'), '0') AS PTotalSun, "
        MyString += "ISNULL(TSKidney.MondayHours, '0') + ISNULL(TSLiver.MondayHours, '0') + ISNULL(TSLung.MondayHours, '0') AS PTotalMon, "
        MyString += "ISNULL(TSKidney.TuesdayHours, '0') + ISNULL(TSLiver.TuesdayHours, '0') + ISNULL(TSLung.TuesdayHours, '0') AS PTotalTue, "
        MyString += "ISNULL(TSKidney.WednesdayHours, '0') + ISNULL(TSLiver.WednesdayHours, '0') + ISNULL(TSLung.WednesdayHours, '0') AS PTotalWed, "
        MyString += "ISNULL(TSKidney.ThursdayHours, '0') + ISNULL(TSLiver.ThursdayHours, '0') + ISNULL(TSLung.ThursdayHours, '0') AS PTotalThu, "
        MyString += "ISNULL(TSKidney.FridayHours, '0') + ISNULL(TSLiver.FridayHours, '0') + ISNULL(TSLung.FridayHours, '0') AS PTotalFri, "
        MyString += "NULLIF(ISNULL(TSKidney.SaturdayHours, '0') + ISNULL(TSLiver.SaturdayHours, '0') + ISNULL(TSLung.SaturdayHours, '0'), '0') AS PTotalSat, "

        MyString += "ISNULL(TSKidney.SundayHours, '0') + ISNULL(TSLiver.SundayHours, '0') + ISNULL(TSLung.SundayHours, '0') + "
        MyString += "ISNULL(TSKidney.MondayHours, '0') + ISNULL(TSLiver.MondayHours, '0') + ISNULL(TSLung.MondayHours, '0') + "
        MyString += "ISNULL(TSKidney.TuesdayHours, '0') + ISNULL(TSLiver.TuesdayHours, '0') + ISNULL(TSLung.TuesdayHours, '0') + "
        MyString += "ISNULL(TSKidney.WednesdayHours, '0') + ISNULL(TSLiver.WednesdayHours, '0') + ISNULL(TSLung.WednesdayHours, '0') + "
        MyString += "ISNULL(TSKidney.ThursdayHours, '0') + ISNULL(TSLiver.ThursdayHours, '0') + ISNULL(TSLung.ThursdayHours, '0') + "
        MyString += "ISNULL(TSKidney.FridayHours, '0') + ISNULL(TSLiver.FridayHours, '0') + ISNULL(TSLung.FridayHours, '0') + "
        MyString += "ISNULL(TSKidney.SaturdayHours, '0') + ISNULL(TSLiver.SaturdayHours, '0') + ISNULL(TSLung.SaturdayHours, '0') AS TotalPre, "

        MyString += "TSClinic.SundayHours AS ClinicSun, "
        MyString += "TSClinic.MondayHours AS ClinicMon, "
        MyString += "TSClinic.TuesdayHours AS ClinicTue, "
        MyString += "TSClinic.WednesdayHours AS ClinicWed, "
        MyString += "TSClinic.ThursdayHours AS ClinicThu, "
        MyString += "TSClinic.FridayHours AS ClinicFri, "
        MyString += "TSClinic.SaturdayHours AS ClinicSat, "

        MyString += "TSOther.SundayHours AS OtherSun, "
        MyString += "TSOther.MondayHours AS OtherMon, "
        MyString += "TSOther.TuesdayHours AS OtherTue, "
        MyString += "TSOther.WednesdayHours AS OtherWed, "
        MyString += "TSOther.ThursdayHours AS OtherThu, "
        MyString += "TSOther.FridayHours AS OtherFri, "
        MyString += "TSOther.SaturdayHours AS OtherSat, "

        MyString += "ISNULL(TSOther.SundayHours, '0') + ISNULL(TSOther.MondayHours, '0') + ISNULL(TSOther.TuesdayHours, '0') + ISNULL(TSOther.WednesdayHours, '0') + "
        MyString += "ISNULL(TSOther.ThursdayHours, '0') + ISNULL(TSOther.FridayHours, '0') + ISNULL(TSOther.SaturdayHours, '0') AS TotalOther, "

        MyString += "TSNA.SundayHours AS NASun, "
        MyString += "TSNA.MondayHours AS NAMon, "
        MyString += "TSNA.TuesdayHours AS NATue, "
        MyString += "TSNA.WednesdayHours AS NAWed, "
        MyString += "TSNA.ThursdayHours AS NAThu, "
        MyString += "TSNA.FridayHours AS NAFri, "
        MyString += "TSNA.SaturdayHours AS NASat, "

        MyString += "ISNULL(TSNA.SundayHours, '0') + ISNULL(TSNA.MondayHours, '0') + ISNULL(TSNA.TuesdayHours, '0') + ISNULL(TSNA.WednesdayHours, '0') + "
        MyString += "ISNULL(TSNA.ThursdayHours, '0') + ISNULL(TSNA.FridayHours, '0') + ISNULL(TSNA.SaturdayHours, '0') AS TotalNonAllowable, "

        MyString += "TSPTO.SundayHours AS PTOSun, "
        MyString += "TSPTO.MondayHours AS PTOMon, "
        MyString += "TSPTO.TuesdayHours AS PTOTue, "
        MyString += "TSPTO.WednesdayHours AS PTOWed, "
        MyString += "TSPTO.ThursdayHours AS PTOThu, "
        MyString += "TSPTO.FridayHours AS PTOFri, "
        MyString += "TSPTO.SaturdayHours AS PTOSat, "

        MyString += "ISNULL(TSPTO.SundayHours, '0') + ISNULL(TSPTO.MondayHours, '0') + ISNULL(TSPTO.TuesdayHours, '0') + ISNULL(TSPTO.WednesdayHours, '0') + "
        MyString += "ISNULL(TSPTO.ThursdayHours, '0') + ISNULL(TSPTO.FridayHours, '0') + ISNULL(TSPTO.SaturdayHours, '0') AS TotalPTO, "

        MyString += "NULLIF(ISNULL(TSKidney.SundayHours, '0') + ISNULL(TSLiver.SundayHours, '0') + ISNULL(TSLung.SundayHours, '0') + ISNULL(TSClinic.SundayHours, '0') + ISNULL(TSOther.SundayHours, '0') + ISNULL(TSPTO.SundayHours, '0') + ISNULL(TSNA.SundayHours, '0'), '0') AS SundayHours, "
        MyString += "ISNULL(TSKidney.MondayHours, '0') + ISNULL(TSLiver.MondayHours, '0') + ISNULL(TSLung.MondayHours, '0') + ISNULL(TSClinic.MondayHours, '0') + ISNULL(TSOther.MondayHours, '0') + ISNULL(TSPTO.MondayHours, '0') + ISNULL(TSNA.MondayHours, '0') AS MondayHours, "
        MyString += "ISNULL(TSKidney.TuesdayHours, '0') + ISNULL(TSLiver.TuesdayHours, '0') + ISNULL(TSLung.TuesdayHours, '0') + ISNULL(TSClinic.TuesdayHours, '0') + ISNULL(TSOther.TuesdayHours, '0') + ISNULL(TSPTO.TuesdayHours, '0') + ISNULL(TSNA.TuesdayHours, '0') AS TuesdayHours, "
        MyString += "ISNULL(TSKidney.WednesdayHours, '0') + ISNULL(TSLiver.WednesdayHours, '0') + ISNULL(TSLung.WednesdayHours, '0') + ISNULL(TSClinic.WednesdayHours, '0') + ISNULL(TSOther.WednesdayHours, '0') + ISNULL(TSPTO.WednesdayHours, '0') + ISNULL(TSNA.WednesdayHours, '0') AS WednesdayHours, "
        MyString += "ISNULL(TSKidney.ThursdayHours, '0') + ISNULL(TSLiver.ThursdayHours, '0') + ISNULL(TSLung.ThursdayHours, '0') + ISNULL(TSClinic.ThursdayHours, '0') + ISNULL(TSOther.ThursdayHours, '0') + ISNULL(TSPTO.ThursdayHours, '0') + ISNULL(TSNA.ThursdayHours, '0') AS ThursdayHours, "
        MyString += "ISNULL(TSKidney.FridayHours, '0') + ISNULL(TSLiver.FridayHours, '0') + ISNULL(TSLung.FridayHours, '0') + ISNULL(TSClinic.FridayHours, '0') + ISNULL(TSOther.FridayHours, '0') + ISNULL(TSPTO.FridayHours, '0') + ISNULL(TSNA.FridayHours, '0') AS FridayHours, "
        MyString += "NULLIF(ISNULL(TSKidney.SaturdayHours, '0') + ISNULL(TSLiver.SaturdayHours, '0') + ISNULL(TSLung.SaturdayHours, '0') + ISNULL(TSClinic.SaturdayHours, '0') + ISNULL(TSOther.SaturdayHours, '0') + ISNULL(TSPTO.SaturdayHours, '0') + ISNULL(TSNA.SaturdayHours, '0'), '0') AS SaturdayHours, "

        MyString += "ISNULL(TSKidney.TotalHours, '0') + ISNULL(TSLiver.TotalHours, '0') + ISNULL(TSLung.TotalHours, '0') + ISNULL(TSClinic.TotalHours, '0') + ISNULL(TSOther.TotalHours, '0') + ISNULL(TSPTO.TotalHours, '0') + ISNULL(TSNA.TotalHours, '0') AS TotalHours "

        MyString += "FROM            tblStaff AS S "
        MyString += "OUTER APPLY (SELECT TOP 1 * FROM tblStaffTimeStudy AS TSKidney WHERE TSKidney.UserId = S.UserId AND TSKidney.PreTransplantDate = '" & hfDate.Value & "' AND TSKidney.PreTransplantType = '1') AS TSKidney "
        MyString += "OUTER APPLY (SELECT TOP 1 * FROM tblStaffTimeStudy AS TSLiver WHERE TSLiver.UserId = S.UserId AND TSLiver.PreTransplantDate = '" & hfDate.Value & "' AND TSLiver.PreTransplantType = '2') AS TSLiver "
        MyString += "OUTER APPLY (SELECT TOP 1 * FROM tblStaffTimeStudy AS TSLung WHERE TSLung.UserId = S.UserId AND TSLung.PreTransplantDate = '" & hfDate.Value & "' AND TSLung.PreTransplantType = '3') AS TSLung "
        MyString += "OUTER APPLY (SELECT TOP 1 * FROM tblStaffTimeStudy AS TSOther WHERE TSOther.UserId = S.UserId AND TSOther.PreTransplantDate = '" & hfDate.Value & "' AND TSOther.PreTransplantType = '4') AS TSClinic "
        MyString += "OUTER APPLY (SELECT TOP 1 * FROM tblStaffTimeStudy AS TSOther WHERE TSOther.UserId = S.UserId AND TSOther.PreTransplantDate = '" & hfDate.Value & "' AND TSOther.PreTransplantType = '5') AS TSOther "
        MyString += "OUTER APPLY (SELECT TOP 1 * FROM tblStaffTimeStudy AS TSOther WHERE TSOther.UserId = S.UserId AND TSOther.PreTransplantDate = '" & hfDate.Value & "' AND TSOther.PreTransplantType = '6') AS TSPTO "
        MyString += "OUTER APPLY (SELECT TOP 1 * FROM tblStaffTimeStudy AS TSOther WHERE TSOther.UserId = S.UserId AND TSOther.PreTransplantDate = '" & hfDate.Value & "' AND TSOther.PreTransplantType = '7') AS TSNA "

        MyString += "WHERE        (S.UserId = '" & hfUserId.Value & "') "

        Try
            Dim cmd As New SqlCommand(MyString, con)
            Dim dAdapter As New SqlDataAdapter(cmd)
            dAdapter.Fill(MyDataTable)
            Return MyDataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        With Me

            If Not IsPostBack Then

                If Not Request.QueryString("U") Is Nothing Then
                    hfDate.Value = Request.QueryString("D").ToString
                    hfUserId.Value = Request.QueryString("U").ToString
                    Try
                        Dim TS = From p In TPDC.tblStaffTimeStudies
                                 Where p.UserId.Equals(hfUserId.Value) And p.PreTransplantDate.Equals(hfDate.Value)
                                 Select p.Id, p.Locked

                        If TS.First.Locked = True Then
                            btnApproval.Visible = False
                        Else
                            btnApproval.Visible = True
                        End If
                    Catch ex As Exception

                    End Try
                    If Not Request.QueryString("TSA") Is Nothing Then
                        btnApproval.Visible = False
                        btnCancel.Visible = False
                    Else
                        btnCancel.Visible = True
                    End If
                End If

                If Not Request.QueryString("TSA") Is Nothing Then
                    lbTimeStudyInfo.Text = "&bull; The approver can view the user's time sheet to determine approval. <br />"
                    lbTimeStudyInfo.Text += "&bull; This has also been sent as a pdf to the approver's email when the user sent for approval."
                Else
                    lbTimeStudyInfo.Text = "&bull; Users can view their time sheet and select 'Submit to Supervisor for Approval' <br />"
                    lbTimeStudyInfo.Text += "&bull; The User's supervisor will be emailed with a pdf copy of this report and their time study status will be updated."
                End If


            End If

        End With

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("TimeStudy.aspx?")

    End Sub

    Private Sub Page_Unload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload

        CrystalReportViewerTS.Dispose()
        CustomerReportTS.Close()
        CustomerReportTS.Dispose()

    End Sub

    Private Sub CrystalReportViewerTS_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewerTS.Unload

        CrystalReportViewerTS.Dispose()
        CustomerReportTS.Close()
        CustomerReportTS.Dispose()

    End Sub

    Protected Sub btnApproval_Click(sender As Object, e As System.EventArgs) Handles btnApproval.Click

        lbMessage.Visible = True
        lbMessage.ForeColor = Drawing.Color.Green
        lbMessage.Text = "</br> Approval was sent to your Supervisor! </br>"

        'Code Has been commented out for Demo purposes
        'Try
        '    Dim smtp As New SmtpClient
        '    Dim MyMail As New MailMessage
        '    Dim MyFrom As New MailAddress("no-reply@uthscsa.edu", "UTC No-Reply")

        '    Dim currentUser As MembershipUser = Membership.GetUser()
        '    'Current User eMail or Acting on Behalf of Staff No Longer Employed eMail
        '    Dim MyCC As New MailAddress(currentUser.Email.ToString)
        '    Dim vEmployeeId As String = 0

        '    Dim UT = From p In TPDC.tblStaffUsersInRoles
        '             From q In TPDC.tblStaffApproverLinks.Where(Function(a) a.StaffRoleIdEmployee = p.StaffRoleId).DefaultIfEmpty
        '             From w In TPDC.tblStaffUsersInRoles.Where(Function(b) b.StaffRoleId = q.StaffRoleIdApprover).DefaultIfEmpty
        '             From r In TPDC.tblStaffs.Where(Function(c) c.UserId = w.StaffUserId).DefaultIfEmpty
        '             From t In TPDC.tblStaffs.Where(Function(d) d.UserId = p.StaffUserId).DefaultIfEmpty
        '             Where p.StaffUserId.Equals(hfUserId.Value)
        '             Select r.UserId, r.PrieMail, t.FName, t.LName

        '    Dim vSupEmail As String = Nothing
        '    vSupEmail = UT.First.PrieMail
        '    Dim MyTo As New MailAddress(Trim(vSupEmail))

        '    MyMail.BodyEncoding = System.Text.Encoding.UTF8
        '    MyMail.To.Add(MyTo)
        '    MyMail.CC.Add(MyCC)
        '    MyMail.From = MyFrom
        '    MyMail.Priority = MailPriority.High
        '    MyMail.IsBodyHtml = True

        '    'Header
        '    MyMail.Subject = "++ Pre-Transplant Time Study Approval Request"
        '    MyMail.Body += "Greetings " & UT.First.FName & " " & UT.First.LName & " has sent you a Pre-Transplant Time Study Approval Request. </br>"
        '    MyMail.Body += "Please see attachment. </br></br>"
        '    MyMail.Body += "Choose Staff then User Time Study Approvals.</br></br>"

        '    'Footer
        '    MyMail.Body += "Thank you, </br>" & UT.First.FName & " " & UT.First.LName & "</br> "

        '    Try
        '        Dim EI = From p In TPDC.tblStaffs
        '                 Where p.UserId.Equals(hfUserId.Value)
        '                 Select p.UserId, p.EmployeeID, p.FName, p.LName

        '        vEmployeeId = EI.First.EmployeeID.ToString
        '        If vEmployeeId.Length < 8 Then
        '                For i = 1 To 8 - vEmployeeId.ToString.Length
        '                    vEmployeeId = "0" & vEmployeeId
        '                Next
        '            End If

        '        Dim MyAttachment As New Attachment(CreatePDF(vEmployeeId.ToString, EI.First.FName, EI.First.LName))
        '        MyMail.Attachments.Add(MyAttachment)
        '    Catch ex As Exception

        '    End Try

        '    smtp.Send(MyMail)
        '    lbMessage.Visible = True
        '    lbMessage.ForeColor = Drawing.Color.Green
        '    lbMessage.Text = "</br> Approval was sent! </br>"
        '    btnApproval.Enabled = False

        '    'Changed currentUser.ProviderUserKey --> hfUserId.Value
        '    Try
        '        Dim TS = From p In TPDC.tblStaffTimeStudies
        '                 Where p.UserId.Equals(hfUserId.Value) And p.PreTransplantDate.Equals(hfDate.Value)

        '        For Each rowTS In TS

        '            Dim TSU = (From p In TPDC.tblStaffTimeStudies
        '                       Where p.UserId.Equals(hfUserId.Value) And p.PreTransplantDate.Equals(hfDate.Value) And p.Id.Equals(rowTS.Id)).ToList()(0)

        '            TSU.StatusLog = rowTS.StatusLog & "Sent " & Date.Today & "; "
        '            TSU.Status = "Sent/Pending Approval"
        '            TSU.Locked = True
        '            TSU.ModifyBy = Me.MyUser
        '            TSU.ModifyDate = Now.ToString("G")
        '            TPDC.SubmitChanges()
        '        Next
        '    Catch ex As Exception
        '        lbMessage.Visible = True
        '        lbMessage.ForeColor = Drawing.Color.Red
        '        lbMessage.Text = "Approval sent but Status could not be saved" & Chr(13) & ex.Message.ToString
        '    End Try

        'Catch ex As Exception
        '    lbMessage.Visible = True
        '    lbMessage.ForeColor = Drawing.Color.Red
        '    lbMessage.Text = "Approval could not be sent!" & Chr(13)

        '    If ex.Message.ToString.Contains("no elements") Then
        '        lbMessage.Text += "Time Study role is missing, please contact Transplant IT."
        '    Else
        '        lbMessage.Text += ex.Message.ToString
        '    End If
        'End Try

    End Sub

    Private Function CreatePDF(ByVal MyStaffId As String, ByVal FName As String, ByVal LName As String) As String

        'With Me

        '    Dim UpPath As String = .MyUpDir & hfUserId.Value & ""

        '    Try
        '        If Directory.Exists(UpPath) Then

        '        Else
        '            Dim di As DirectoryInfo = Directory.CreateDirectory(UpPath)
        '        End If
        '    Catch ex As Exception

        '    End Try

        '    Dim SavePath As String = UpPath & "\"
        '    Dim MyPDFFileName As String = hfDateText.Value & "_" & FName & "_" & LName & "_001.pdf"
        '    Dim PathToCheck As String = SavePath + MyPDFFileName
        '    Dim TempFileName As String = Nothing

        '    If (System.IO.File.Exists(PathToCheck)) Then
        '        Dim Counter As Integer = 2
        '        While (System.IO.File.Exists(PathToCheck))
        '            TempFileName = hfDateText.Value & "_" & FName & "_" & LName & "_00" & Counter.ToString() & ".pdf"
        '            PathToCheck = SavePath + TempFileName
        '            Counter = Counter + 1
        '        End While
        '        MyPDFFileName = TempFileName
        '    End If

        '    CustomerReportTS.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, UpPath & "\" & MyPDFFileName)
        '    CustomerReportTS.Close()

        '    Try
        '        Dim LDIns As New ListDictionary()
        '        LDIns.Add("UserId", hfUserId.Value)
        '        LDIns.Add("StaffId", CInt(Trim(MyStaffId)))
        '        LDIns.Add("UploadDate", Now.ToString("G"))
        '        LDIns.Add("FilePath", "/UTCFiles/UploadedFiles/SiteStaffTimeStudy/" & hfUserId.Value & "/" & Trim(MyPDFFileName))
        '        LDIns.Add("FileName", Trim(MyPDFFileName))
        '        LDIns.Add("Provider", hfUserName.Value)
        '        LDIns.Add("Available", True)
        '        LDIns.Add("RefPhy", False)
        '        LDIns.Add("EnterBy", hfUserName.Value)
        '        LDIns.Add("EnterDate", Now.ToString("G"))

        '        LinqStaffTimeStudyPDF.Insert(LDIns)
        '    Catch ex As Exception

        '    End Try

        '    Return UpPath & "\" & MyPDFFileName

        'End With

        Return True

    End Function

End Class
