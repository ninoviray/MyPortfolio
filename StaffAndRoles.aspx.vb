Partial Class Pages_StaffAndRoles
    Inherits System.Web.UI.Page

    Dim MyUser As String

    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lbTimeStudyInfo.Text = "&bull; Administrators can manage users in positions.  <br />"
        lbTimeStudyInfo.Text += "&bull; Validators and checks insure that a user can only be in one position at a time."

        'With Me

        '    Try
        '        Dim currentUser As MembershipUser = Membership.GetUser()
        '        .MyUser = currentUser.UserName
        '    Catch ex As Exception
        '        Response.Redirect("~/Account/ThankYou.aspx")
        '    End Try

        'End With

        If Not Page.IsPostBack Then

            'If Not Request.QueryString("U") Is Nothing Then
            'hfUserId.Value = Request.QueryString("U").ToString
            'BindUsersToStaffAndRoles()
            'hfFrom.Value = Request.QueryString("F").ToString
            'Dim MyVisitUser As New VisitUser
            'hfBack.Value = MyVisitUser.CkVisit(hfFrom.Value).ToString & hfUserId.Value
            'btnReturn.Text = "Return to User Status"
            'btnReturn.ToolTip = "Select to Return to User Status."
            'Else
            'hfBack.Value = "~/Administrator/Users/UserMenu.aspx"
            'btnReturn.Text = "Return to User Menu"
            'btnReturn.ToolTip = "Select to Return to User Menu."
            'End If

            BindStaffToList()
            BindStaffToListAdd()
            BindRolesToList()
            CheckRolesForSelectedStaff()
            DisplayStaffBelongingToRole()

            'Dim MyLogActivity As New LogActivity
            'MyLogActivity.LogActivity("View Admin Staff and Roles...", Request.RawUrl)

        End If

    End Sub

    Private Sub BindUsersToStaffAndRoles()

        'Try
        '    Dim CkSHA = From s In TPDC.tblStaffs
        '                Select s.UserId, s.FName, s.LName

        '    hfUserId.Value = Trim(CkSHA.FirstOrDefault.UserId.ToString)
        '    hfUserName.Value = Trim(CkSHA.FirstOrDefault.FName.ToString + CkSHA.First.LName.ToString)
        '    ddUserList.SelectedValue = hfUserName.Value
        '    ddUserList.Enabled = False
        '    ddUserListAdd.SelectedValue = hfUserName.Value
        '    ddUserListAdd.Enabled = False
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub BindRolesToList()

        Try
            Dim Staff = (From utcst In TPDC.tblStaffRoles
                         Order By utcst.StaffRoleName
                         Select utcst.StaffRoleName).ToList

            Dim roleNames() As String = Staff.ToArray
            Dim roleNamesLength As Integer = roleNames.Length
            Dim roleNamesDecimal As Decimal = roleNamesLength / 2
            Dim roleNamesCount As Integer = Math.Ceiling(roleNamesDecimal)
            StaffRoleList.DataSource = roleNames.Take(roleNamesCount).ToArray()
            StaffRoleList.DataBind()
            StaffRoleListII.DataSource = roleNames.Skip(roleNamesCount).ToArray()
            StaffRoleListII.DataBind()
            'ddRoleList.DataSource = roleNames
            'ddRoleList.DataBind()

            Dim roles = (From r In TPDC.tblStaffRoles
                         Order By r.StaffRoleName
                         Select r.StaffRoleId, r.StaffRoleName).Distinct

            ddRoleList.DataSource = roles.ToList
            ddRoleList.DataBind()

        Catch ex As Exception

        End Try

    End Sub

#Region "'By Staff' Interface-Specific Methods"

    Private Sub BindStaffToList()

        Try
            Dim UTC = (From u In TPDC.tblStaffs
                       Let MyName = u.LName.ToString & ", " & u.FName.ToString
                       Order By MyName Ascending
                       Select MyName, u.UserId).Distinct

            ddUserList.DataSource = UTC.ToList
            ddUserList.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BindStaffToListAdd()

        Try
            Dim UTC = (From u In TPDC.tblStaffs
                       Let MyName = u.LName.ToString & ", " & u.FName.ToString
                       Order By MyName Ascending
                       Select MyName, u.UserId).Distinct

            ddUserListAdd.DataSource = UTC.ToList
            ddUserListAdd.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddUserList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddUserList.SelectedIndexChanged

        'ActionStatus.Text = Nothing
        ActionStatusII.Text = Nothing
        ActionStatusIII.Text = Nothing
        CheckRolesForSelectedStaff()

    End Sub

    Private Sub CheckRolesForSelectedStaff()

        Try
            Dim CkSHA = From s In TPDC.tblStaffs
                        Where s.UserId().Equals(ddUserList.SelectedValue)
                        Select s.UserId, MyName = s.FName + " " + s.LName

            hfUserId.Value = Trim(CkSHA.FirstOrDefault.UserId.ToString)
            hfUserName.Value = Trim(CkSHA.FirstOrDefault.MyName.ToString)
        Catch ex As Exception

        End Try

        Dim selectedStaffRoleIds As String = Nothing
        Dim selectedStaffRoles As List(Of String) = New List(Of String)()

        Try
            Dim UTCRole As List(Of Guid) = (From utcst In TPDC.tblStaffUsersInRoles
                                            Where utcst.StaffUserId.Equals(hfUserId.Value)
                                            Select utcst.StaffRoleId).ToList

            For Each guid In UTCRole.ToList
                selectedStaffRoleIds = guid.ToString()
                Dim UTCName = (From utcst In TPDC.tblStaffRoles
                               Where utcst.StaffRoleId.Equals(selectedStaffRoleIds)
                               Select utcst.StaffRoleName).ToList

                For Each MyRole In UTCName.ToList
                    selectedStaffRoles.Add(MyRole)
                Next
            Next

            For Each ri As RepeaterItem In StaffRoleList.Items
                Dim cbRole As CheckBox = CType(ri.FindControl("cbRole"), CheckBox)
                If Linq.Enumerable.Contains(Of String)(selectedStaffRoles, cbRole.Text) Then
                    cbRole.Checked = True
                Else
                    cbRole.Checked = False
                End If
            Next

            For Each riII As RepeaterItem In StaffRoleListII.Items
                Dim cbRoleII As CheckBox = CType(riII.FindControl("cbRoleII"), CheckBox)
                If Linq.Enumerable.Contains(Of String)(selectedStaffRoles, cbRoleII.Text) Then
                    cbRoleII.Checked = True
                Else
                    cbRoleII.Checked = False
                End If
            Next

        Catch ex As Exception
            selectedStaffRoles = Nothing
        End Try

    End Sub

    Protected Sub cbRole_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)

        Dim cbRole As CheckBox = CType(sender, CheckBox)
        'Dim MyUserInfo As MembershipUser = Membership.GetUser(ddUserList.SelectedValue)
        'hfUserId.Value = MyUserInfo.ProviderUserKey.ToString
        Dim selectedUserName As String = ddUserList.SelectedItem.ToString
        Dim roleName As String = cbRole.Text
        Dim roleNameId As Guid = Nothing

        If selectedUserName = "Viray, Nino" Or selectedUserName = "User, New" Then

            ActionStatusII.Text = "Cannot change, protected for demo purposes, select another Staff."
            If cbRole.Checked = True Then
                cbRole.Checked = False
            Else
                cbRole.Checked = True
            End If

        Else

            Try
                Dim UTCRole = From utcst In TPDC.tblStaffRoles
                              Where utcst.StaffRoleName.Equals(roleName)
                              Select utcst.StaffRoleName, utcst.StaffRoleId

                roleNameId = Guid.Parse(UTCRole.First.StaffRoleId.ToString)

                If cbRole.Checked Then
                    Dim R = From p In TPDC.tblStaffUsersInRoles
                            From q In TPDC.tblStaffRoles.Where(Function(a) a.StaffRoleId = p.StaffRoleId)
                            Where p.StaffUserId.Equals(hfUserId.Value)
                            Select p.StaffUserId, q.StaffRoleName

                    Try
                        R.First.StaffUserId.ToString()
                        ActionStatusII.Text = String.Format("**Warning! Staff: {0} is Already in Position Role {1}.**<br />Only one role per staff can be selected.<br />Remove role from staff before selecting a new role.", selectedUserName, R.First.StaffRoleName)
                        'ActionStatusII.Text = ActionStatus.Text
                        ActionStatusIII.Text = Nothing
                        cbRole.Checked = False
                    Catch ex As Exception
                        Dim LDAddRole As New ListDictionary()
                        LDAddRole.Add("StaffUserId", hfUserId.Value)
                        LDAddRole.Add("StaffRoleId", roleNameId)
                        LinqStaffUsersInRoles.Insert(LDAddRole)
                        ActionStatusII.Text = String.Format("Staff: {0} was Added to Position Role {1}.", selectedUserName, roleName)
                        'ActionStatusII.Text = ActionStatus.Text
                        ActionStatusIII.Text = Nothing
                    End Try
                Else
                    Dim DelStaff = (From A In TPDC.tblStaffUsersInRoles
                                    Where A.StaffUserId.Equals(hfUserId.Value) And A.StaffRoleId.Equals(roleNameId)
                                    Select A).Single()

                    TPDC.tblStaffUsersInRoles.DeleteOnSubmit(DelStaff)
                    TPDC.SubmitChanges()
                    ActionStatusII.Text = String.Format("Staff: {0} was Removed from Position Role {1}.", selectedUserName, roleName)
                    'ActionStatusII.Text = ActionStatus.Text
                    ActionStatusIII.Text = Nothing
                End If

                DisplayStaffBelongingToRole()

            Catch ex As Exception
                ActionStatusII.Text = String.Format("Staff: {0} needs to Finish Setting Up their Account Before Position Roles can be Added.", selectedUserName)
                'ActionStatusII.Text = ActionStatus.Text
                ActionStatusIII.Text = Nothing
            End Try

        End If

    End Sub

    Protected Sub cbRoleII_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)

        Dim cbRoleII As CheckBox = CType(sender, CheckBox)
        'Dim MyUserInfo As MembershipUser = Membership.GetUser(ddUserList.SelectedValue)
        'hfUserId.Value = MyUserInfo.ProviderUserKey.ToString
        Dim selectedUserName As String = ddUserList.SelectedItem.ToString
        Dim roleName As String = cbRoleII.Text
        Dim roleNameId As Guid = Nothing

        If selectedUserName = "Viray, Nino" Or selectedUserName = "User, New" Then

            ActionStatusII.Text = "Cannot change, protected for demo purposes, select another Staff."
            If cbRoleII.Checked = True Then
                cbRoleII.Checked = False
            Else
                cbRoleII.Checked = True
            End If

        Else

            Try
                Dim UTCRole = From utcst In TPDC.tblStaffRoles
                              Where utcst.StaffRoleName.Equals(roleName)
                              Select utcst.StaffRoleName, utcst.StaffRoleId

                roleNameId = Guid.Parse(UTCRole.First.StaffRoleId.ToString)

                If cbRoleII.Checked Then
                    Dim R = From p In TPDC.tblStaffUsersInRoles
                            From q In TPDC.tblStaffRoles.Where(Function(a) a.StaffRoleId = p.StaffRoleId)
                            Where p.StaffUserId.Equals(hfUserId.Value)
                            Select p.StaffUserId, q.StaffRoleName

                    Try
                        R.First.StaffUserId.ToString()
                        ActionStatusII.Text = String.Format("**Warning! Staff: {0} is Already in Position Role {1}.**<br />Only one role per staff can be selected.<br />Remove role from staff before selecting a new role.", selectedUserName, R.First.StaffRoleName)
                        'ActionStatusII.Text = ActionStatus.Text
                        ActionStatusIII.Text = Nothing
                        cbRoleII.Checked = False
                    Catch ex As Exception
                        Dim LDAddRole As New ListDictionary()
                        LDAddRole.Add("StaffUserId", hfUserId.Value)
                        LDAddRole.Add("StaffRoleId", roleNameId)
                        LinqStaffUsersInRoles.Insert(LDAddRole)
                        ActionStatusII.Text = String.Format("Staff: {0} was Added to Position Role {1}.", selectedUserName, roleName)
                        'ActionStatusII.Text = ActionStatus.Text
                        ActionStatusIII.Text = Nothing
                    End Try
                Else
                    Dim DelStaff = (From A In TPDC.tblStaffUsersInRoles
                                    Where A.StaffUserId.Equals(hfUserId.Value) And A.StaffRoleId.Equals(roleNameId)
                                    Select A).Single()

                    TPDC.tblStaffUsersInRoles.DeleteOnSubmit(DelStaff)
                    TPDC.SubmitChanges()
                    ActionStatusII.Text = String.Format("Staff: {0} was Removed from Position Role {1}.", selectedUserName, roleName)
                    'ActionStatusII.Text = ActionStatus.Text
                    ActionStatusIII.Text = Nothing
                End If

                DisplayStaffBelongingToRole()

            Catch ex As Exception
                ActionStatusII.Text = String.Format("Staff: {0} needs to Finish Setting Up their Account Before Position Roles can be Added.", selectedUserName)
                'ActionStatusII.Text = ActionStatus.Text
                ActionStatusIII.Text = Nothing
            End Try

        End If

    End Sub

#End Region

#Region "'By Role' Interface-Specific Methods"

    Protected Sub ddRoleList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddRoleList.SelectedIndexChanged

        ActionStatusII.Text = Nothing
        'ActionStatusII.Text = Nothing
        ActionStatusIII.Text = Nothing
        DisplayStaffBelongingToRole()

    End Sub

    Private Sub DisplayStaffBelongingToRole()

        Dim selectedRoleName As String = ddRoleList.SelectedItem.Text
        lbPositionRole.Text = selectedRoleName
        Dim selectedStaffRoleIds As String = Nothing
        Dim staffBelongingToRole As List(Of String) = New List(Of String)()

        Try
            Dim UTCRole As List(Of Guid) = (From utcst In TPDC.tblStaffRoles
                                            Where utcst.StaffRoleName.Equals(selectedRoleName)
                                            Select utcst.StaffRoleId).ToList

            For Each guid In UTCRole.ToList
                selectedStaffRoleIds = guid.ToString()
                Dim Staff = (From utcst In TPDC.tblStaffUsersInRoles
                             Where utcst.StaffRoleId.Equals(selectedStaffRoleIds)
                             Select utcst.StaffUserId).ToList

                For Each MyRole In Staff.ToList
                    Dim UTC = (From u In TPDC.tblStaffs
                               Where u.UserId.Equals(MyRole.ToString)
                               Let MyName = u.LName.ToString & ", " & u.FName.ToString
                               Order By MyName Ascending
                               Select MyName, u.UserId).Distinct

                    staffBelongingToRole.Add(UTC.FirstOrDefault.MyName.ToString)
                Next
            Next

            RolesUserList.DataSource = staffBelongingToRole
            RolesUserList.DataBind()

        Catch ex As Exception
            staffBelongingToRole = Nothing
        End Try

    End Sub

    Protected Sub RolesUserList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles RolesUserList.RowDeleting

        Dim selectedRoleName As String = ddRoleList.SelectedItem.Text
        Dim UserNameLabel As Label = CType(RolesUserList.Rows(e.RowIndex).FindControl("lbUserName"), Label)
        Dim selectedUserId As Guid = Nothing
        Dim roleNameId As Guid = Nothing

        If UserNameLabel.Text = "Viray, Nino" Or UserNameLabel.Text = "User, New" Then

            ActionStatusIII.Text = "Cannot change, protected for demo purposes."
            e.Cancel = True

        Else

            Try
                Dim UTC = From u In TPDC.tblStaffs
                          Let MyName = u.LName.ToString & ", " & u.FName.ToString
                          Where MyName.Equals(UserNameLabel.Text)
                          Select u.UserId, MyName

                selectedUserId = UTC.FirstOrDefault.UserId

                Dim UTCRole = From utcst In TPDC.tblStaffRoles
                              Where utcst.StaffRoleName.Equals(selectedRoleName)
                              Select utcst.StaffRoleName, utcst.StaffRoleId

                roleNameId = Guid.Parse(UTCRole.First.StaffRoleId.ToString)

                Dim DelStaff = (From A In TPDC.tblStaffUsersInRoles
                                Where A.StaffUserId.Equals(selectedUserId) And A.StaffRoleId.Equals(roleNameId)
                                Select A).Single()

                TPDC.tblStaffUsersInRoles.DeleteOnSubmit(DelStaff)
                TPDC.SubmitChanges()

                DisplayStaffBelongingToRole()
                ActionStatusIII.Text = String.Format("Staff: {0} was Removed from Position Role {1}.", UserNameLabel.Text, selectedRoleName)
                ActionStatusII.Text = Nothing
                ActionStatusII.Text = Nothing
                CheckRolesForSelectedStaff()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Protected Sub btnAddStaffRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddStaffRole.Click

        Dim selectedUserId As String = ddUserListAdd.SelectedValue
        Dim selectedRoleName As String = ddRoleList.SelectedItem.Text
        Dim selectedStaffRoleIds As String = Nothing
        Dim UserAddRole As String = ddUserListAdd.SelectedValue
        Dim selectedUserName As String = ddUserListAdd.SelectedItem.ToString

        If UserAddRole.Trim().Length = 0 Then
            ActionStatusIII.Text = "You must Enter a Staff Login Name in the textbox."
            ActionStatusII.Text = Nothing
            ActionStatusII.Text = Nothing
            Exit Sub
        End If

        'Dim userInfo As MembershipUser = Membership.GetUser(UserAddRole)
        'If userInfo Is Nothing Then
        '    ActionStatusIII.Text = String.Format("The Staff Login Name {0} does not Exist in the UTC System.", UserAddRole)
        '    ActionStatusII.Text = Nothing
        '    ActionStatusII.Text = Nothing
        '    Exit Sub
        'Else
        '    selectedUserId = userInfo.ProviderUserKey
        'End If

        Try
            Dim UTCName = From utcst In TPDC.tblStaffRoles
                          Where utcst.StaffRoleName.Equals(selectedRoleName)
                          Select utcst.StaffRoleId, utcst.StaffRoleName

            selectedStaffRoleIds = UTCName.First.StaffRoleId.ToString

            Dim UTCRole = From utcst In TPDC.tblStaffUsersInRoles
                          Where utcst.StaffRoleId.Equals(Guid.Parse(selectedUserId))
                          Select utcst.StaffUserId, utcst.StaffRoleId

            UTCRole.First.StaffRoleId.ToString()
            ActionStatusIII.Text = String.Format("Staff: {0} is Already a Member of Position Role {1}.", selectedUserName, selectedRoleName)
            ActionStatusII.Text = Nothing
            ActionStatusII.Text = Nothing
        Catch ex As Exception
            Dim LDAddRole As New ListDictionary()
            LDAddRole.Add("StaffUserId", selectedUserId)
            LDAddRole.Add("StaffRoleId", selectedStaffRoleIds)

            Dim R = From p In TPDC.tblStaffUsersInRoles
                    From q In TPDC.tblStaffRoles.Where(Function(a) a.StaffRoleId = p.StaffRoleId)
                    Where p.StaffUserId.Equals(selectedUserId)
                    Select p.StaffUserId, q.StaffRoleName

            Try
                R.First.StaffUserId.ToString()
                ActionStatusII.Text = Nothing
                ActionStatusII.Text = Nothing
                ActionStatusIII.Text = String.Format("**Warning! Staff: {0} is Already in Position Role {1}.**<br />Only One Role per Staff can be Selected.<br />Remove Role from Staff before Selecting a New Role.", selectedUserName, R.First.StaffRoleName)
            Catch ex2 As Exception
                Try
                    LinqStaffUsersInRoles.Insert(LDAddRole)
                    'ddUserListAdd.SelectedIndex = 0
                    DisplayStaffBelongingToRole()
                    ActionStatusIII.Text = String.Format("Staff: {0} was Added to Position Role {1}.", selectedUserName, selectedRoleName)
                    'ActionStatus.Text = Nothing
                    ActionStatusII.Text = Nothing
                    CheckRolesForSelectedStaff()
                Catch ex3 As Exception
                    ActionStatusIII.Text = "Please Select a Staff Position Role!"
                    'ActionStatus.Text = Nothing
                    ActionStatusII.Text = Nothing
                End Try

            End Try

        End Try

    End Sub

#End Region

End Class
