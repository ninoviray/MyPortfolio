Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Data.SqlClient

Partial Class Pages_ReportTimeStudyYearlyPage
    Inherits System.Web.UI.Page

    Dim MyUser As String
    Dim dtTSRpt As New DataTable()
    Private CustomerReportTS As New ReportDocument()
    Dim MyDataTable As New DataTable()
    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        'Try
        '    Dim currentUser As MembershipUser = Membership.GetUser()
        '    Me.MyUser = currentUser.UserName
        '    hfUserId.Value = currentUser.ProviderUserKey.ToString
        'Catch ex As Exception
        '    Response.Redirect("~/Account/ThankYou.aspx")
        'End Try

        If Not IsPostBack Then
            Session("dtTSRpt") = Nothing
        End If

        hfDate.Value = Request.QueryString("D")

        Try
            CustomerReportTS.Load(Server.MapPath("~/Reports/ReportTimeStudyYearly.rpt"))
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

        MyString += "SELECT        Staff.EmployeeID, "
        MyString += "Staff.RevenueCode AS RC, Staff.LName + ', ' + Staff.FName AS Name, "
        MyString += "(SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) And (TD.PreTransplantDate Like '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) AS Total, "

        MyString += "CAST((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TS.PreTransplantType = '1') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) / "
        MyString += "((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "From            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) - "
        MyString += "(SELECT        ISNULL(NULLIF(SUM(TS.TotalHours), 0), 0) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) And (TS.PreTransplantType = '6') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved'))) "
        MyString += "* 100 AS DECIMAL(5, 2)) AS Kidney, "

        MyString += "CAST((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TS.PreTransplantType = '2') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) / "
        MyString += "((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "From            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) - "
        MyString += "(SELECT        ISNULL(NULLIF(SUM(TS.TotalHours), 0), 0) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) And (TS.PreTransplantType = '6') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved'))) "
        MyString += "* 100 AS DECIMAL(5, 2)) AS Liver, "

        MyString += "CAST((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TS.PreTransplantType = '3') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) / "
        MyString += "((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "From            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) - "
        MyString += "(SELECT        ISNULL(NULLIF(SUM(TS.TotalHours), 0), 0) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) And (TS.PreTransplantType = '6') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved'))) "
        MyString += "* 100 AS DECIMAL(5, 2)) AS Lung, "

        MyString += "CAST((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TS.PreTransplantType = '5') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) / "
        MyString += "((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "From            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) - "
        MyString += "(SELECT        ISNULL(NULLIF(SUM(TS.TotalHours), 0), 0) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) And (TS.PreTransplantType = '6') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved'))) "
        MyString += "* 100 AS DECIMAL(5, 2)) AS Other, "

        MyString += "CAST((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TS.PreTransplantType = '7') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) / "
        MyString += "((SELECT        SUM(TS.TotalHours) AS Expr1 "
        MyString += "From            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) - "
        MyString += "(SELECT        ISNULL(NULLIF(SUM(TS.TotalHours), 0), 0) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) And (TS.PreTransplantType = '6') AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved'))) "
        MyString += "* 100 AS DECIMAL(5, 2)) AS NonAllowable, "

        MyString += "(SELECT        TOP (1) LEFT(DATENAME(month, TD.PreTransplantDate), 3) AS Expr1 "
        MyString += "From            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved') "
        MyString += "ORDER BY TD.PreTransplantDate) AS StartMonth, "

        MyString += "(SELECT        TOP (1) LEFT(DATENAME(month, TD.PreTransplantDate), 3) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved') "
        MyString += "ORDER BY TD.PreTransplantDate DESC) AS EndMonth, "

        MyString += "(SELECT        CONVERT(varchar, COUNT(DISTINCT TS.PreTransplantDate)) AS Expr1 "
        MyString += "FROM            tblStaffTimeStudy AS TS LEFT OUTER JOIN "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = TS.PreTransplantDate "
        MyString += "WHERE        (TS.UserId = Staff.UserId) AND (TD.PreTransplantDate LIKE '%" & hfDate.Value & "%') AND (TS.Status = 'Approved')) AS Months, "

        MyString += "(SELECT Top 1 roles.StaffRoleName "
        MyString += "From tblStaffUsersInRoles As users left outer Join "
        MyString += "tblStaffRoles As Roles On Roles.StaffRoleId = users.StaffRoleId "
        MyString += "Where users.StaffUserId = Staff.UserId) As Team, "

        MyString += "(SELECT Top 1 staffApprover.FName + ' ' + staffApprover.LName "
        MyString += "From tblStaffUsersInRoles As users1 left outer Join "
        MyString += "tblStaffApproverLink As link On link.StaffRoleIdEmployee = users1.StaffRoleId left outer Join "
        MyString += "tblStaffUsersInRoles As users2 On users2.StaffRoleId = link.StaffRoleIdApprover left outer Join "
        MyString += "tblStaff As staffApprover On staffApprover.UserId = users2.StaffUserId  "
        MyString += "Where users1.StaffUserId = Staff.UserId) As Approver, "

        MyString += "CONVERT(varchar, staff.TimeStudyStartDate, 101) As TimeStudyStartDate, "
        MyString += "CONVERT(varchar, staff.TimeStudyEndDate, 101) As TimeStudyEndDate "

        MyString += "From(Select ts.UserId FROM tblStaffTimeStudy AS ts Left Outer Join "
        MyString += "lkpPreTransplantDate AS TD ON TD.Id = ts.PreTransplantDate Where TD.PreTransplantDate Like '%" & hfDate.Value & "%' Group By ts.UserId) as ts Left Outer Join "
        MyString += "tblStaff as staff on staff.UserId = ts.UserId "

        MyString += "Order By StartMonth DESC, Name "

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

            lbTimeStudyInfo.Text = "&bull; This report has been optimized for exporting to an Excel sheet. <br />"
            lbTimeStudyInfo.Text += "&bull; An sql query is ran against the data to get a percentage of the total hours for each category. <br />"
            lbTimeStudyInfo.Text += "&bull; Only time studies that have been approved will be calculated in the report."

            'If Not IsPostBack Then

            '    Dim MyLogActivity As New LogActivity
            '    MyLogActivity.LogActivity("View Time Study Yearly Report...", Request.RawUrl)

            'End If

        End With

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("~/Pages/TimeStudyApproval.aspx")

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

End Class
