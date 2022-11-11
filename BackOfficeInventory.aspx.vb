Imports System.Data
Imports System.Data.Entity.Core.Common.CommandTrees
Imports System.Data.Entity.Core.Metadata.Edm
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Partial Class PagesStaff_BackOfficeInventory
    Inherits System.Web.UI.Page

    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        With Me

            If Not IsPostBack Then

                SQLCheckOut.SelectCommand = SQLCheckOutCommand(Nothing)
                Me.ViewState("SQLCheckOut") = SQLCheckOut.SelectCommand
                SQLCheckOutLog.SelectCommand = SQLCheckOutLogCommand(Nothing)
                Me.ViewState("SQLCheckOutLog") = SQLCheckOutLog.SelectCommand
                SQLHotspots.SelectCommand = SQLHotspotsCommand(Nothing)
                Me.ViewState("SQLHotspots") = SQLHotspots.SelectCommand
                SQLLaptops.SelectCommand = SQLLaptopsCommand(Nothing)
                Me.ViewState("SQLLaptops") = SQLLaptops.SelectCommand
                SQLPrinters.SelectCommand = SQLPrinterCommand(Nothing)
                Me.ViewState("SQLPrinters") = SQLPrinters.SelectCommand
                SQLPCs.SelectCommand = SQLPCCommand(Nothing)
                Me.ViewState("SQLPCs") = SQLPCs.SelectCommand
                SQLMiscellaneous.SelectCommand = SQLMiscellaneousCommand(Nothing)
                Me.ViewState("SQLMiscellaneous") = SQLMiscellaneous.SelectCommand
                SqlOverview.SelectCommand = SQLOverviewCommand(Nothing)
                Me.ViewState("SQLOverview") = SqlOverview.SelectCommand

                lbInfo.Text = "&bull; Admins can use this section to manage equipment inventories and check outs. <br />"
                lbInfo.Text += "&bull; A check out log is kept to record equipment usage and reasons for reporting purposes. <br />"

            End If

        End With

    End Sub

    Protected Sub TabContainerInventory_OnClientClick(ByVal sender As Object, ByVal e As EventArgs) Handles TabContainerInventory.ActiveTabChanged
        Select Case hfTabIndex.Value
            Case 0
                SQLCheckOut.SelectCommand = Me.ViewState("SQLCheckOut")
                GridViewCheckOut.DataBind()
                SQLCheckOutLog.SelectCommand = Me.ViewState("SQLCheckOutLog")
                GridViewCheckOutLog.DataBind()
                lbInfo.Text = "&bull; Admins can use this section to manage equipment inventories and check outs. <br />"
                lbInfo.Text += "&bull; A check out log is kept to record equipment usage and reasons for reporting purposes. <br />"
            Case 1
                SQLHotspots.SelectCommand = Me.ViewState("SQLHotspots")
                GridViewHotspots.DataBind()
                lbInfo.Text = "&bull; Hotspots can be managed(Add, Edit and Delete). <br />"
                lbInfo.Text += "&bull; Status of hotpots can be seen here. <br />"
            Case 2
                SQLLaptops.SelectCommand = Me.ViewState("SQLLaptops")
                GridViewLaptops.DataBind()
                lbInfo.Text = "&bull; Laptops can be managed(Add, Edit and Delete). <br />"
                lbInfo.Text += "&bull; Status of Laptops can be seen here. <br />"
            Case 3
                SQLMiscellaneous.SelectCommand = Me.ViewState("SQLMiscellaneous")
                GridViewMiscellaneousInventory.DataBind()
                lbInfo.Text = "&bull; Other equipment items can be managed(Add, Edit and Delete). <br />"
                lbInfo.Text += "&bull; Status of these items can be seen here as well as keeping track of their location. "
            Case 4
                SQLPCs.SelectCommand = Me.ViewState("SQLPCs")
                GridViewPCsInventory.DataBind()
                lbInfo.Text = "&bull; PC workstations can be managed(Add, Edit and Delete). <br />"
                lbInfo.Text += "&bull; The PC's can be linked to the primary user and office location. "
            Case 5
                SQLPrinters.SelectCommand = Me.ViewState("SQLPrinters")
                GridViewPrintersInventory.DataBind()
                lbInfo.Text = "&bull; Printers can be managed(Add, Edit and Delete). <br />"
                lbInfo.Text += "&bull; The printers office location is also managed. "
            Case 6
                SqlOverview.SelectCommand = Me.ViewState("SQLOverview")
                GridViewOverview.DataBind()
                lbInfo.Text = "&bull; Admins can view all equipment based on the location. <br />"
                lbInfo.Text += "&bull; A nested gridview is used to provide a linkbutton (Printers, PCs) to go to their respective tabs). "
            Case Else
        End Select

    End Sub

    'Check out
    Protected Sub GridViewCheckOut_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Add" Then

                If Page.IsValid Then

                    Try
                        Dim INV As New ListDictionary
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                        INV.Add("StaffId", Guid.Parse(DirectCast(row.FindControl("ddStaffList"), DropDownList).SelectedValue))
                        INV.Add("ItemType", DirectCast(row.FindControl("ddItemType"), DropDownList).SelectedValue)
                        Select Case DirectCast(row.FindControl("ddItemType"), DropDownList).SelectedValue
                            Case "1"
                                INV.Add("HotspotId", Guid.Parse(DirectCast(row.FindControl("ddDevice"), DropDownList).SelectedValue))
                            Case "2"
                                INV.Add("LaptopId", Guid.Parse(DirectCast(row.FindControl("ddDevice"), DropDownList).SelectedValue))
                            Case "3"
                                INV.Add("MiscellaneousId", Guid.Parse(DirectCast(row.FindControl("ddDevice"), DropDownList).SelectedValue))
                            Case Else
                        End Select
                        INV.Add("Reason", DirectCast(row.FindControl("ddReason"), DropDownList).SelectedValue)
                        INV.Add("CheckedOutDate", DirectCast(row.FindControl("txtCheckedOutDate"), TextBox).Text)
                        If DirectCast(row.FindControl("txtComments"), TextBox).Text <> Nothing Then
                            INV.Add("Comments", DirectCast(row.FindControl("txtComments"), TextBox).Text)
                        End If
                        INV.Add("EnterBy", hfUser.Value)
                        INV.Add("EnterDate", Now.ToString("G"))


                        LinqCheckOut.Insert(INV)
                        INV.Clear()
                        SQLCheckOut.SelectCommand = Me.ViewState("SQLCheckOut")
                        GridViewCheckOut.DataBind()
                        lbCheckOutMessage.Text = "Record has been added! </br>"
                        lbCheckOutMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbCheckOutMessage.Text = "Your Record was Not Saved! </br>"
                        lbCheckOutMessage.ForeColor = Drawing.Color.Red
                    End Try

                    Try
                        'Save to tblInventoryCheckOutsLog
                        Dim AB = From p In TPDC.tblInventoryCheckOuts
                                 Order By p.Id Descending
                                 Select p

                        Dim Log As New ListDictionary
                        Log.Add("Id", AB.First.Id)
                        Log.Add("StaffId", AB.First.StaffId)
                        Log.Add("ItemType", AB.First.ItemType)
                        Select Case AB.First.ItemType
                            Case "1"
                                Log.Add("HotspotId", AB.First.HotspotId)
                            Case "2"
                                Log.Add("LaptopId", AB.First.LaptopId)
                            Case "3"
                                Log.Add("MiscellaneousId", AB.First.MiscellaneousId)
                            Case Else
                        End Select
                        Log.Add("Reason", AB.First.Reason)
                        Log.Add("CheckedOutDate", AB.First.CheckedOutDate)
                        Log.Add("Comments", AB.First.Comments)
                        Log.Add("EnterBy", hfUser.Value)
                        Log.Add("EnterDate", Now.ToString("G"))

                        LinqCheckOutLog.Insert(Log)
                        Log.Clear()
                        SQLCheckOutLog.SelectCommand = SQLCheckOutLogCommand(Nothing)
                        GridViewCheckOutLog.DataBind()
                        lbCheckOutMessage.Text += "</br>Record has been added to Log! </br>"
                        lbCheckOutMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbCheckOutMessage.Text += "</br>Your Record was Not Saved to Log! </br>"
                        lbCheckOutMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "UpdateLog" Then

                If Page.IsValid Then

                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                    If DirectCast(row.FindControl("txtReturnDate"), TextBox).Text <> Nothing Then
                        Try
                            'Save to tblInventoryCheckOutsLog
                            Dim Log As New ListDictionary
                            Log.Add("Id", DirectCast(row.FindControl("lbId"), Label).Text)
                            Log.Add("StaffId", DirectCast(row.FindControl("lbStaffId"), Label).Text)
                            Log.Add("ItemType", DirectCast(row.FindControl("lbItemTypeId"), Label).Text)

                            Select Case DirectCast(row.FindControl("lbItemTypeId"), Label).Text
                                Case 1
                                    Log.Add("HotspotId", DirectCast(row.FindControl("lbDeviceTypeId"), Label).Text)
                                Case 2
                                    Log.Add("LaptopId", DirectCast(row.FindControl("lbDeviceTypeId"), Label).Text)
                                Case 3
                                    Log.Add("MiscellaneousId", DirectCast(row.FindControl("lbDeviceTypeId"), Label).Text)
                                Case Else
                            End Select
                            Log.Add("Reason", DirectCast(row.FindControl("lbReasonId"), Label).Text)
                            Log.Add("CheckedOutDate", DirectCast(row.FindControl("lbCheckedOutDate"), Label).Text)
                            Log.Add("ReturnDate", DirectCast(row.FindControl("txtReturnDate"), TextBox).Text)
                            Log.Add("Comments", DirectCast(row.FindControl("txtComments"), TextBox).Text)
                            Log.Add("EnterBy", hfUser.Value)
                            Log.Add("EnterDate", Now.ToString("G"))
                            LinqCheckOutLog.Insert(Log)
                            Log.Clear()
                            GridViewCheckOut.SetEditRow(-1)
                            SQLCheckOut.SelectCommand = Me.ViewState("SQLCheckOut")
                            GridViewCheckOut.DataBind()
                            SQLCheckOutLog.SelectCommand = Me.ViewState("SQLCheckOutLog")
                            GridViewCheckOutLog.DataBind()
                            lbCheckOutMessage.Text = "Record has been Saved to Log! </br>"
                            lbCheckOutMessage.ForeColor = Drawing.Color.Green
                        Catch ex As Exception
                            lbCheckOutMessage.Text = "Your Record was Not Saved to Log! </br>"
                            lbCheckOutMessage.ForeColor = Drawing.Color.Red
                        End Try

                        Try
                            'Delete current row from this main table
                            Dim Delete = From p In TPDC.tblInventoryCheckOuts
                                         Where p.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                         Select p

                            For Each p In Delete
                                TPDC.tblInventoryCheckOuts.DeleteOnSubmit(p)
                            Next

                            TPDC.SubmitChanges()

                        Catch ex As Exception

                        End Try

                    Else

                        Try
                            Dim AB = (From p In TPDC.tblInventoryCheckOuts
                                      Where p.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)

                            AB.Comments = DirectCast(row.FindControl("txtComments"), TextBox).Text
                            AB.ModifyBy = hfUser.Value
                            AB.ModifyDate = Now.ToString("G")

                            TPDC.SubmitChanges()

                        Catch ex As Exception

                        End Try

                    End If

                    GridViewCheckOut.EditIndex = -1
                    SQLCheckOut.SelectCommand = Me.ViewState("SQLCheckOut")
                    GridViewCheckOut.DataBind()

                End If

            ElseIf e.CommandName = "Edit" Then

                SQLCheckOut.SelectCommand = Me.ViewState("SQLCheckOut")
                GridViewCheckOut.DataBind()

            ElseIf e.CommandName = "Cancel" Then

                SQLCheckOut.SelectCommand = Me.ViewState("SQLCheckOut")
                GridViewCheckOut.DataBind()

            ElseIf e.CommandName = "DeleteCheckOut" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                Try
                    'Save to tblInventoryCheckOutsLog
                    Dim Log As New ListDictionary
                    Log.Add("Id", DirectCast(row.FindControl("lbId"), Label).Text)
                    Log.Add("StaffId", DirectCast(row.FindControl("lbStaffId"), Label).Text)
                    Log.Add("ItemType", DirectCast(row.FindControl("lbItemTypeId"), Label).Text)

                    Select Case DirectCast(row.FindControl("lbItemTypeId"), Label).Text
                        Case 1
                            Log.Add("HotspotId", DirectCast(row.FindControl("lbDeviceTypeId"), Label).Text)
                        Case 2
                            Log.Add("LaptopId", DirectCast(row.FindControl("lbDeviceTypeId"), Label).Text)
                        Case 3
                            Log.Add("MiscellaneousId", DirectCast(row.FindControl("lbDeviceTypeId"), Label).Text)
                        Case Else
                    End Select
                    Log.Add("Reason", DirectCast(row.FindControl("lbReasonId"), Label).Text)
                    Log.Add("CheckedOutDate", DirectCast(row.FindControl("lbCheckedOutDate"), Label).Text)
                    Log.Add("Comments", "[Deleted] " & DirectCast(row.FindControl("lbComments"), Label).Text)
                    Log.Add("EnterBy", hfUser.Value)
                    Log.Add("EnterDate", Now.ToString("G"))

                    LinqCheckOutLog.Insert(Log)
                    Log.Clear()

                    Dim Delete = From p In TPDC.tblInventoryCheckOuts
                                 Where p.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                 Select p

                    For Each p In Delete
                        TPDC.tblInventoryCheckOuts.DeleteOnSubmit(p)
                    Next

                    TPDC.SubmitChanges()
                    SQLCheckOut.SelectCommand = Me.ViewState("SQLCheckOut")
                    GridViewCheckOut.DataBind()
                    SQLCheckOutLog.SelectCommand = Me.ViewState("SQLCheckOutLog")
                    GridViewCheckOutLog.DataBind()
                    lbCheckOutMessage.Text = "Record has been Saved to Log! </br>"
                    lbCheckOutMessage.ForeColor = Drawing.Color.Green
                Catch ex As Exception
                    lbCheckOutMessage.Text = "Your Record was Not Saved to Log! </br>"
                    lbCheckOutMessage.ForeColor = Drawing.Color.Red
                End Try

            End If

        End With

    End Sub

    Protected Sub GridViewCheckOut_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

                Dim ddStaffList As DropDownList = TryCast(e.Row.FindControl("ddStaffList"), DropDownList)

                Try
                    Dim UTC = (From u In TPDC.tblStaffs
                               Where u.EndDate Is Nothing
                               Let MyName = u.FName.ToString & If(u.MName IsNot Nothing, " " & u.MName.ToString() & " ", " ") & u.LName.ToString()
                               Order By MyName Ascending
                               Select MyName, u.UserId).Distinct

                    ddStaffList.DataSource = UTC.ToList
                    ddStaffList.DataBind()
                Catch ex As Exception

                End Try

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub dropdownlistHeader_SelectedIndexChanged(sender As Object, e As EventArgs)

        Select Case sender.Id
            Case "ddStaffList"
                Dim ddStaffList As DropDownList = CType(GridViewCheckOut.HeaderRow.FindControl("ddStaffList"), DropDownList)
                Dim ddItemType As DropDownList = CType(GridViewCheckOut.HeaderRow.FindControl("ddItemType"), DropDownList)

                If ddStaffList.SelectedIndex = 0 Then
                    ddItemType.Enabled = False
                Else
                    ddItemType.Enabled = True
                End If
            Case "ddItemType"
                Dim ddItemType As DropDownList = CType(GridViewCheckOut.HeaderRow.FindControl("ddItemType"), DropDownList)
                Dim ddDevice As DropDownList = CType(GridViewCheckOut.HeaderRow.FindControl("ddDevice"), DropDownList)

                Select Case ddItemType.SelectedValue
                    Case 1
                        ddDevice.Enabled = True
                        ddDevice.Items.Clear()
                        'Search for available hotspots that are not in the checkouts table
                        Dim MyCommand As String = "SELECT lkp.Description, lkp.Id "
                        MyCommand += "FROM lkpInventoryHotspots as lkp OUTER APPLY "
                        MyCommand += "(SELECT TOP 1 co.Id FROM tblInventoryCheckOut as co WHERE co.HotspotId = lkp.Id) as co "
                        MyCommand += "WHERE lkp.Active = 'True' AND ISNULL((CASE WHEN ISNULL(co.Id, '') = '' THEN lkp.Description END), '') <> '' "
                        SQLDevice.SelectCommand = MyCommand
                        ddDevice.DataSourceID = SQLDevice.ID
                        ddDevice.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                        ddDevice.SelectedIndex = 0
                        ddDevice.DataBind()
                    Case 2
                        ddDevice.Enabled = True
                        ddDevice.Items.Clear()
                        'Search for available hotspots that are not in the checkouts table
                        Dim MyCommand As String = "SELECT lkp.Description, lkp.Id "
                        MyCommand += "FROM lkpInventoryLaptops as lkp OUTER APPLY "
                        MyCommand += "(SELECT TOP 1 co.Id FROM tblInventoryCheckOut as co WHERE co.LaptopId = lkp.Id) as co "
                        MyCommand += "WHERE lkp.Active = 'True' AND ISNULL((CASE WHEN ISNULL(co.Id, '') = '' THEN lkp.Description END), '') <> '' "
                        SQLDevice.SelectCommand = MyCommand
                        ddDevice.DataSourceID = SQLDevice.ID
                        ddDevice.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                        ddDevice.SelectedIndex = 0
                        ddDevice.DataBind()
                    Case 3
                        ddDevice.Enabled = True
                        ddDevice.Items.Clear()
                        'Search for available miscellaneous items that are not in the checkouts table
                        Dim MyCommand As String = "SELECT lkp.Description, lkp.Id "
                        MyCommand += "FROM lkpInventoryMiscellaneous as lkp OUTER APPLY "
                        MyCommand += "(SELECT TOP 1 co.Id FROM tblInventoryCheckOut as co WHERE co.MiscellaneousId = lkp.Id) as co "
                        MyCommand += "WHERE lkp.Active = 'True' AND ISNULL((CASE WHEN ISNULL(co.Id, '') = '' THEN lkp.Description END), '') <> '' "
                        SQLDevice.SelectCommand = MyCommand
                        ddDevice.DataSourceID = SQLDevice.ID
                        ddDevice.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                        ddDevice.SelectedIndex = 0
                        ddDevice.DataBind()
                    Case Else
                        ddDevice.Enabled = False
                        ddDevice.SelectedIndex = 0
                End Select
            Case "ddDevice"
                Dim ddDevice As DropDownList = CType(GridViewCheckOut.HeaderRow.FindControl("ddDevice"), DropDownList)
                Dim ddReason As DropDownList = CType(GridViewCheckOut.HeaderRow.FindControl("ddReason"), DropDownList)

                If ddDevice.SelectedIndex = 0 Then
                    ddReason.Enabled = False
                Else
                    ddReason.Enabled = True
                End If
            Case "ddReason"
                Dim ddReason As DropDownList = CType(GridViewCheckOut.HeaderRow.FindControl("ddReason"), DropDownList)
                Dim txtCheckedOutDate As TextBox = CType(GridViewCheckOut.HeaderRow.FindControl("txtCheckedOutDate"), TextBox)
                Dim txtComments As TextBox = CType(GridViewCheckOut.HeaderRow.FindControl("txtComments"), TextBox)

                If ddReason.SelectedIndex > 0 Then
                    txtCheckedOutDate.Enabled = True
                    txtComments.Enabled = True
                Else
                    txtCheckedOutDate.Enabled = False
                    txtComments.Enabled = False
                    txtCheckedOutDate.Text = Nothing
                    txtComments.Text = Nothing
                End If

            Case Else

        End Select

    End Sub

    Protected Sub CheckOutSort(ByVal Sender As Object, ByVal e As EventArgs)

        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkStaffList"
                sortDirection = If(Me.ViewState("LogStaff") Is Nothing, "ASC", If(Me.ViewState("LogStaff") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogStaff") = sortDirection
                sortExpression = "StaffList"
            Case "linkType"
                sortDirection = If(Me.ViewState("LogType") Is Nothing, "ASC", If(Me.ViewState("LogType") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogType") = sortDirection
                sortExpression = "ItemType"
            Case "linkDevice"
                sortDirection = If(Me.ViewState("LogDevice") Is Nothing, "ASC", If(Me.ViewState("LogDevice") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogDevice") = sortDirection
                sortExpression = "Device"
            Case "linkReason"
                sortDirection = If(Me.ViewState("LogReason") Is Nothing, "ASC", If(Me.ViewState("LogReason") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogReason") = sortDirection
                sortExpression = "Reason"
            Case "linkCheckedOut"
                sortExpression = If(Me.ViewState("LogCheckedOut") Is Nothing, "ASC", If(Me.ViewState("LogCheckedOut") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogCheckedOut") = sortDirection
                sortExpression = "CheckedOutDate"
            Case "linkReturnDate"
                sortDirection = If(Me.ViewState("LogReturnDate") Is Nothing, "ASC", If(Me.ViewState("LogReturnDate") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogReturnDate") = sortDirection
                sortExpression = "ReturnDate"
            Case "linkComments"
                sortDirection = If(Me.ViewState("LogComments") Is Nothing, "ASC", If(Me.ViewState("LogComments") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogComments") = sortDirection
                sortExpression = "Comments"
            Case Else
                Return
        End Select

        SQLCheckOut.SelectCommand = SQLCheckOutCommand(Nothing).Replace("Id DESC ", sortExpression) & " " & sortDirection
        Me.ViewState("SQLCheckOut") = SQLCheckOut.SelectCommand
        GridViewCheckOut.DataBind()

    End Sub

    Protected Function SQLCheckOutCommand(ByVal MyCommand As String) As String

        MyCommand += "SELECT col.Id, col.StaffId, "
        MyCommand += "staff.FName + ISNULL(' ' + NULLIF(staff.MName, '') + ' ', ' ') + staff.LName AS StaffList, "
        MyCommand += "type.EquipmentType AS ItemType, "
        MyCommand += "col.ItemType AS ItemTypeId, "
        MyCommand += "ISNULL(hots.Description, ISNULL(laps.Description, misc.Description)) AS Device, "
        MyCommand += "ISNULL(col.HotspotId, ISNULL(col.LaptopId, col.MiscellaneousId)) AS DeviceId, "
        MyCommand += "reas.Reason AS Reason, col.Reason AS ReasonId, "
        MyCommand += "col.CheckedOutDate AS CheckedOutDate, "
        MyCommand += "col.ReturnDate AS ReturnDate, "
        MyCommand += "col.Comments AS Comments "

        MyCommand += "FROM tblInventoryCheckOut as col LEFT OUTER JOIN "
        MyCommand += "lkpInventoryHotspots as hots on hots.Id = col.HotspotId LEFT OUTER JOIN "
        MyCommand += "lkpInventoryLaptops as laps on laps.Id = col.LaptopId LEFT OUTER JOIN "
        MyCommand += "lkpInventoryMiscellaneous as misc on misc.Id = col.MiscellaneousId LEFT OUTER JOIN "
        MyCommand += "lkpInventoryReason as reas on reas.Id = col.Reason LEFT OUTER JOIN "
        MyCommand += "lkpInventoryType as type on type.Id = col.ItemType LEFT OUTER JOIN "
        MyCommand += "tblStaff as staff on staff.UserId = col.StaffId OUTER APPLY "
        MyCommand += "(SELECT TOP 1 Staff.LName + ', ' + Staff.FName AS Name FROM tblStaff AS Staff WHERE Staff.UserId = col.StaffId) AS StaffName "

        MyCommand += "WHERE StaffName.Name like '%" & txtSearchCheckOut.Text & "%' OR type.EquipmentType like '%" & txtSearchCheckOut.Text & "%' OR "
        MyCommand += "ISNULL(hots.Description, ISNULL(laps.Description, misc.Description)) Like '%" & txtSearchCheckOut.Text & "%' OR "
        MyCommand += "reas.Reason like '%" & txtSearchCheckOut.Text & "%' OR CONVERT(varchar, CheckedOutDate, 101) like '%" & txtSearchCheckOut.Text & "%' OR col.Comments like '%" & txtSearchCheckOut.Text & "%' "

        MyCommand += "Order By Id DESC "

        Return MyCommand

    End Function

    Protected Sub SearchCheckOut_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            SQLCheckOut.SelectCommand = SQLCheckOutCommand(Nothing)
            Me.ViewState("SQLCheckOut") = SQLCheckOut.SelectCommand
            GridViewCheckOut.DataBind()

        End If

    End Sub

    'Check out Log
    Protected Sub GridViewCheckOutLog_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub CheckOutLogSort(ByVal Sender As Object, ByVal e As EventArgs)

        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkDate"
                sortDirection = If(Me.ViewState("LogEnterDate") Is Nothing, "ASC", If(Me.ViewState("LogEnterDate") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogEnterDate") = sortDirection
                sortExpression = "UId"
            Case "linkStaffList"
                sortDirection = If(Me.ViewState("LogStaff") Is Nothing, "ASC", If(Me.ViewState("LogStaff") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogStaff") = sortDirection
                sortExpression = "StaffList"
            Case "linkType"
                sortDirection = If(Me.ViewState("LogType") Is Nothing, "ASC", If(Me.ViewState("LogType") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogType") = sortDirection
                sortExpression = "ItemType"
            Case "linkDevice"
                sortDirection = If(Me.ViewState("LogDevice") Is Nothing, "ASC", If(Me.ViewState("LogDevice") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogDevice") = sortDirection
                sortExpression = "Device"
            Case "linkReason"
                sortDirection = If(Me.ViewState("LogReason") Is Nothing, "ASC", If(Me.ViewState("LogReason") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogReason") = sortDirection
                sortExpression = "Reason"
            Case "linkCheckedOut"
                sortExpression = If(Me.ViewState("LogCheckedOut") Is Nothing, "ASC", If(Me.ViewState("LogCheckedOut") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogCheckedOut") = sortDirection
                sortExpression = "CheckedOutDate"
            Case "linkReturnDate"
                sortDirection = If(Me.ViewState("LogReturnDate") Is Nothing, "ASC", If(Me.ViewState("LogReturnDate") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogReturnDate") = sortDirection
                sortExpression = "ReturnDate"
            Case "linkComments"
                sortDirection = If(Me.ViewState("LogComments") Is Nothing, "ASC", If(Me.ViewState("LogComments") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogComments") = sortDirection
                sortExpression = "Comments"
            Case Else
                Return
        End Select

        SQLCheckOutLog.SelectCommand = SQLCheckOutLogCommand(Nothing).Replace("UId DESC ", sortExpression) & " " & sortDirection
        Me.ViewState("SQLCheckOutLog") = SQLCheckOutLog.SelectCommand
        GridViewCheckOutLog.DataBind()

    End Sub

    Protected Function SQLCheckOutLogCommand(ByVal MyCommand As String) As String

        MyCommand += "SELECT col.UId AS UId, col.EnterDate AS EnterDate, "
        MyCommand += "staff.FName + ISNULL(' ' + NULLIF(staff.MName, '') + ' ', ' ') + staff.LName AS StaffList, "
        MyCommand += "type.EquipmentType AS ItemType, "
        MyCommand += "ISNULL(hots.Description, ISNULL(laps.Description, misc.Description)) AS Device, "
        MyCommand += "reas.Reason AS Reason, "
        MyCommand += "col.CheckedOutDate AS CheckedOutDate, "
        MyCommand += "col.ReturnDate AS ReturnDate, "
        MyCommand += "col.Comments AS Comments "

        MyCommand += "FROM tblInventoryCheckOutLog as col LEFT OUTER JOIN "
        MyCommand += "lkpInventoryHotspots as hots on hots.Id = col.HotspotId LEFT OUTER JOIN "
        MyCommand += "lkpInventoryLaptops as laps on laps.Id = col.LaptopId LEFT OUTER JOIN "
        MyCommand += "lkpInventoryMiscellaneous as misc on misc.Id = col.MiscellaneousId LEFT OUTER JOIN "
        MyCommand += "lkpInventoryReason as reas on reas.Id = col.Reason LEFT OUTER JOIN "
        MyCommand += "lkpInventoryType as type on type.Id = col.ItemType LEFT OUTER JOIN "
        MyCommand += "tblStaff as staff on staff.UserId = col.StaffId OUTER APPLY "
        MyCommand += "(SELECT TOP 1 Staff.LName + ', ' + Staff.FName AS Name FROM tblStaff AS Staff WHERE Staff.UserId = col.StaffId) AS StaffName "

        MyCommand += "WHERE StaffName.Name like '%" & txtSearchCheckOutLog.Text & "%' OR type.EquipmentType like '%" & txtSearchCheckOutLog.Text & "%' OR "
        MyCommand += "ISNULL(hots.Description, ISNULL(laps.Description, misc.Description)) Like '%" & txtSearchCheckOutLog.Text & "%' OR "
        MyCommand += "reas.Reason like '%" & txtSearchCheckOutLog.Text & "%' OR CONVERT(varchar, CheckedOutDate, 101) like '%" & txtSearchCheckOutLog.Text & "%' OR "
        MyCommand += "col.Comments Like '%" & txtSearchCheckOutLog.Text & "%' OR CONVERT(varchar, col.EnterDate, 101) like '%" & txtSearchCheckOutLog.Text & "%' OR "
        MyCommand += "CONVERT(varchar, ReturnDate, 101) like '%" & txtSearchCheckOutLog.Text & "%' "

        MyCommand += "Order By UId DESC "

        Return MyCommand

    End Function

    Protected Sub SearchCheckOutLog_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            SQLCheckOutLog.SelectCommand = SQLCheckOutLogCommand(Nothing)
            Me.ViewState("SQLCheckOutLog") = SQLCheckOutLog.SelectCommand
            GridViewCheckOutLog.DataBind()

        End If

    End Sub

    'Hotspots
    Protected Function SQLHotspotsCommand(ByVal MyCommand As String) As String

        MyCommand += "SELECT        hot.Id, hot.Description, hot.TagId, hot.Model, hot.Notes, hot.UH, hot.UT, hot.Active, "
        MyCommand += "hot.EnterBy, hot.EnterDate, hot.ModifyBy, hot.ModifyDate, "
        MyCommand += "CASE WHEN ISNULL(co.Reason, '') = '' THEN 1 WHEN co.Reason = 7 OR co.Reason = 8 THEN 3 ELSE 2 END AS Assigned "
        MyCommand += "From            lkpInventoryHotspots AS hot LEFT OUTER JOIN "
        MyCommand += "tblInventoryCheckOut AS co ON co.HotspotId = hot.Id "

        MyCommand += "WHERE hot.Id like '%" & txtSearchHotspots.Text & "%' OR hot.Description like '%" & txtSearchHotspots.Text & "%' "
        MyCommand += "OR hot.TagId like '%" & txtSearchHotspots.Text & "%' OR hot.Model like '%" & txtSearchHotspots.Text & "%' "
        MyCommand += "OR hot.Notes like '%" & txtSearchHotspots.Text & "%' "

        MyCommand += "ORDER BY hot.Active DESC, Assigned ASC, hot.Description ASC "

        Return MyCommand

    End Function

    Protected Sub GridViewHotspots_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

                Dim lbStatus As Label = TryCast(e.Row.FindControl("lbStatus"), Label)
                Dim lbId As Label = TryCast(e.Row.FindControl("lbId"), Label)
                Dim cbActive As CheckBox = TryCast(e.Row.FindControl("cbActive"), CheckBox)

                Dim HS = From a In TPDC.tblInventoryCheckOuts
                         Where a.HotspotId.Equals(lbId.Text)
                         Select a.Id, a.HotspotId, a.Reason

                Try
                    HS.First.Id.ToString()
                    If HS.First.Reason = 7 Or HS.First.Reason = 8 Then
                        lbStatus.Text = "Assigned"
                        e.Row.ForeColor = Drawing.Color.RoyalBlue
                    Else
                        lbStatus.Text = "Checked Out"
                        e.Row.ForeColor = Drawing.Color.Red
                    End If
                Catch ex As Exception
                    If cbActive.Checked = True Then
                        lbStatus.Text = "Available"
                        e.Row.ForeColor = Drawing.Color.Green
                    Else
                        lbStatus.Text = "Unavailable"
                        e.Row.ForeColor = Drawing.Color.DarkGray
                    End If

                End Try

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

                Dim lbStatus As Label = TryCast(e.Row.FindControl("lbStatus"), Label)
                Dim lbId As Label = TryCast(e.Row.FindControl("lbId"), Label)
                Dim cbActive As CheckBox = TryCast(e.Row.FindControl("cbActive"), CheckBox)

                Dim HS = From a In TPDC.tblInventoryCheckOuts
                         Where a.HotspotId.Equals(lbId.Text)
                         Select a.Id, a.HotspotId, a.Reason

                Try
                    HS.First.Id.ToString()
                    If HS.First.Reason = 7 Or HS.First.Reason = 8 Then
                        lbStatus.Text = "Assigned"
                        e.Row.ForeColor = Drawing.Color.RoyalBlue
                    Else
                        lbStatus.Text = "Checked Out"
                        e.Row.ForeColor = Drawing.Color.Red
                    End If
                Catch ex As Exception
                    If cbActive.Checked = True Then
                        lbStatus.Text = "Available"
                        e.Row.ForeColor = Drawing.Color.Green
                    Else
                        lbStatus.Text = "Unavailable"
                        e.Row.ForeColor = Drawing.Color.DarkGray
                    End If

                End Try

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub GridViewHotspots_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Add" Then

                If Page.IsValid Then

                    Dim INV As New ListDictionary
                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                    INV.Add("Id", Guid.NewGuid)
                    If DirectCast(row.FindControl("txtDescription"), TextBox).Text <> Nothing Then
                        INV.Add("Description", DirectCast(row.FindControl("txtDescription"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtTagId"), TextBox).Text <> Nothing Then
                        INV.Add("TagId", DirectCast(row.FindControl("txtTagId"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtModel"), TextBox).Text <> Nothing Then
                        INV.Add("Model", DirectCast(row.FindControl("txtModel"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtNotes"), TextBox).Text <> Nothing Then
                        INV.Add("Notes", DirectCast(row.FindControl("txtNotes"), TextBox).Text)
                    End If

                    INV.Add("UH", DirectCast(row.FindControl("cbUH"), CheckBox).Checked)
                    INV.Add("UT", DirectCast(row.FindControl("cbUT"), CheckBox).Checked)
                    INV.Add("Active", "True")
                    INV.Add("EnterBy", hfUser.Value)
                    INV.Add("EnterDate", Now.ToString("G"))

                    Try
                        LinqHotspots.Insert(INV)
                        INV.Clear()
                        SQLHotspots.SelectCommand = Me.ViewState("SQLHotspots")
                        GridViewHotspots.DataBind()
                        lbHotspotsMessage.Text = "Hotspot has been added! </br>"
                        lbHotspotsMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbHotspotsMessage.Text = "Your Record was Not Saved! </br>"
                        lbHotspotsMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "UpdateHotspot" Then

                If Page.IsValid Then

                    Try
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                        Dim UP = (From p In TPDC.lkpInventoryHotspots
                                  Where p.Id.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)

                        UP.Description = DirectCast(row.FindControl("txtDescription"), TextBox).Text
                        If DirectCast(row.FindControl("txtTagId"), TextBox).Text IsNot Nothing Then
                            UP.TagId = DirectCast(row.FindControl("txtTagId"), TextBox).Text
                        Else
                            UP.TagId = Nothing
                        End If
                        If DirectCast(row.FindControl("txtModel"), TextBox).Text IsNot Nothing Then
                            UP.Model = DirectCast(row.FindControl("txtModel"), TextBox).Text
                        Else
                            UP.Model = Nothing
                        End If
                        If DirectCast(row.FindControl("txtNotes"), TextBox).Text IsNot Nothing Then
                            UP.Notes = DirectCast(row.FindControl("txtNotes"), TextBox).Text
                        Else
                            UP.Notes = Nothing
                        End If
                        UP.UH = DirectCast(row.FindControl("cbUH"), CheckBox).Checked
                        UP.UT = DirectCast(row.FindControl("cbUT"), CheckBox).Checked
                        UP.Active = DirectCast(row.FindControl("cbActive"), CheckBox).Checked
                        UP.ModifyBy = hfUser.Value
                        UP.ModifyDate = Now.ToString("G")

                        TPDC.SubmitChanges()
                        GridViewHotspots.EditIndex = -1
                        SQLHotspots.SelectCommand = Me.ViewState("SQLHotspots")
                        GridViewHotspots.DataBind()
                        lbHotspotsMessage.Text = "Record has been updated! </br>"
                        lbHotspotsMessage.ForeColor = Drawing.Color.Green

                    Catch ex As Exception
                        lbHotspotsMessage.Text = "Record could not be updated! </br>"
                        lbHotspotsMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "Edit" Then

                SQLHotspots.SelectCommand = Me.ViewState("SQLHotspots")
                GridViewHotspots.DataBind()

            ElseIf e.CommandName = "Cancel" Then

                SQLHotspots.SelectCommand = Me.ViewState("SQLHotspots")
                GridViewHotspots.DataBind()

            ElseIf e.CommandName = "DeleteHotspot" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                    Try
                        Dim Delete = From a In TPDC.lkpInventoryHotspots
                                     Where a.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                     Select a

                        For Each a In Delete
                            TPDC.lkpInventoryHotspots.DeleteOnSubmit(a)
                        Next

                        TPDC.SubmitChanges()
                        SQLHotspots.SelectCommand = Me.ViewState("SQLHotspots")
                        GridViewHotspots.DataBind()

                        lbHotspotsMessage.Text = "Item has been deleted! </br>"
                        lbHotspotsMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception

                        If ex.Message.Contains("REFERENCE constraint") Then
                            lbHotspotsMessage.Text = "*Error! Could not delete Hotspot item because it is linked to a user.  <br />Please uncheck Active if this item is no longer in use. </br>"
                        Else
                            lbHotspotsMessage.Text = ex.Message
                        End If
                        lbHotspotsMessage.ForeColor = Drawing.Color.Red

                    End Try

                End If

        End With

    End Sub

    Protected Sub GridViewHotspots_RowDeleted(ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)

        lbHotspotsMessage.Text = String.Empty

        Try
            If TypeOf e.Exception Is Exception Then
                Dim sqlErrorCode As String = (CType(e.Exception, Exception)).Message
                If sqlErrorCode.Contains("REFERENCE constraint") Then
                    lbHotspotsMessage.Text = "*Error! Could not delete Hot Spot because it is linked to a user.  <br />Please uncheck Active if this Hotspot is no longer in use. </br>"
                    e.ExceptionHandled = True
                    lbHotspotsMessage.ForeColor = Drawing.Color.Red

                End If
            Else
                lbHotspotsMessage.Text = "Hotspot has been deleted! </br>"
                lbHotspotsMessage.ForeColor = Drawing.Color.Green
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub HotspotSort(ByVal Sender As Object, ByVal e As EventArgs)
        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkHotspotsDescriptionText"
                sortDirection = If(Me.ViewState("Description") Is Nothing, "ASC", If(Me.ViewState("Description") = "ASC", "DESC", "ASC"))
                Me.ViewState("Description") = sortDirection
                sortExpression = "Description"
            Case "linkHotspotsTagIdText"
                sortDirection = If(Me.ViewState("TagId") Is Nothing, "ASC", If(Me.ViewState("TagId") = "ASC", "DESC", "ASC"))
                Me.ViewState("TagId") = sortDirection
                sortExpression = "TagId"
            Case "linkHotspotsModelText"
                sortDirection = If(Me.ViewState("Model") Is Nothing, "ASC", If(Me.ViewState("Model") = "ASC", "DESC", "ASC"))
                Me.ViewState("Model") = sortDirection
                sortExpression = "Model"
            Case "linkHotspotsNotesText"
                sortDirection = If(Me.ViewState("Notes") Is Nothing, "ASC", If(Me.ViewState("Notes") = "ASC", "DESC", "ASC"))
                Me.ViewState("Notes") = sortDirection
                sortExpression = "Notes"
            Case "linkHotspotsUHText"
                sortDirection = If(Me.ViewState("UH") Is Nothing, "ASC", If(Me.ViewState("UH") = "ASC", "DESC", "ASC"))
                Me.ViewState("UH") = sortDirection
                sortExpression = "UH"
            Case "linkHotspotsUTText"
                sortDirection = If(Me.ViewState("UT") Is Nothing, "ASC", If(Me.ViewState("UT") = "ASC", "DESC", "ASC"))
                Me.ViewState("UT") = sortDirection
                sortExpression = "UT"
            Case "linkHotspotsStatusText"
                sortDirection = If(Me.ViewState("Active") Is Nothing, "ASC", If(Me.ViewState("Active") = "ASC", "DESC", "ASC"))
                Me.ViewState("Active") = sortDirection
                sortExpression = "Active"
            Case "linkHotspotsActiveText"
                sortDirection = If(Me.ViewState("Active") Is Nothing, "ASC", If(Me.ViewState("Active") = "ASC", "DESC", "ASC"))
                Me.ViewState("Active") = sortDirection
                sortExpression = "Active"
            Case Else
                Return
        End Select

        SQLHotspots.SelectCommand = SQLHotspotsCommand(Nothing).Replace("hot.Description ASC ", sortExpression) & " " & sortDirection
        Me.ViewState("SQLHotspots") = SQLHotspots.SelectCommand
        GridViewHotspots.DataBind()
    End Sub

    Protected Sub SearchHotspots_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            SQLHotspots.SelectCommand = SQLHotspotsCommand(Nothing)
            Me.ViewState("SqlHotspots") = SQLHotspots.SelectCommand
            GridViewHotspots.DataBind()

        End If

    End Sub

    'Laptops
    Protected Function SQLLaptopsCommand(ByVal MyCommand As String) As String

        MyCommand += "SELECT        lap.Id, lap.Description, lap.PCName, lap.TagId, lap.Model, lap.Notes, lap.UH, lap.UT, lap.Active, "
        MyCommand += "lap.EnterBy, lap.EnterDate, lap.ModifyBy, lap.ModifyDate, "
        MyCommand += "CASE WHEN ISNULL(co.Reason, '') = '' THEN 1 WHEN co.Reason = 7 OR co.Reason = 8 THEN 3 ELSE 2 END AS Assigned "
        MyCommand += "From            lkpInventoryLaptops AS lap LEFT OUTER JOIN "
        MyCommand += "tblInventoryCheckOut AS co ON co.LaptopId = lap.Id "

        MyCommand += "WHERE lap.Id like '%" & txtSearchLaptops.Text & "%' OR lap.Description like '%" & txtSearchLaptops.Text & "%' "
        MyCommand += "OR lap.TagId like '%" & txtSearchLaptops.Text & "%' OR lap.Model like '%" & txtSearchLaptops.Text & "%' "
        MyCommand += "OR lap.Notes like '%" & txtSearchLaptops.Text & "%' OR lap.PCName like '%" & txtSearchLaptops.Text & "%' "

        MyCommand += "ORDER BY lap.Active DESC, Assigned ASC, lap.Description ASC "

        Return MyCommand

    End Function

    Protected Sub GridViewLaptops_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

                Dim lbStatus As Label = TryCast(e.Row.FindControl("lbStatus"), Label)
                Dim lbId As Label = TryCast(e.Row.FindControl("lbId"), Label)
                Dim cbActive As CheckBox = TryCast(e.Row.FindControl("cbActive"), CheckBox)

                Dim HS = From a In TPDC.tblInventoryCheckOuts
                         Where a.LaptopId.Equals(lbId.Text)
                         Select a.Id, a.LaptopId, a.Reason

                Try
                    HS.First.Id.ToString()
                    If HS.First.Reason = 7 Or HS.First.Reason = 8 Then
                        lbStatus.Text = "Assigned"
                        e.Row.ForeColor = Drawing.Color.RoyalBlue
                    Else
                        lbStatus.Text = "Checked Out"
                        e.Row.ForeColor = Drawing.Color.Red
                    End If
                Catch ex As Exception
                    If cbActive.Checked = True Then
                        lbStatus.Text = "Available"
                        e.Row.ForeColor = Drawing.Color.Green
                    Else
                        lbStatus.Text = "Unavailable"
                        e.Row.ForeColor = Drawing.Color.DarkGray
                    End If
                End Try

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

                Dim lbStatus As Label = TryCast(e.Row.FindControl("lbStatus"), Label)
                Dim lbId As Label = TryCast(e.Row.FindControl("lbId"), Label)
                Dim cbActive As CheckBox = TryCast(e.Row.FindControl("cbActive"), CheckBox)

                Dim HS = From a In TPDC.tblInventoryCheckOuts
                         Where a.LaptopId.Equals(lbId.Text)
                         Select a.Id, a.LaptopId, a.Reason

                Try
                    HS.First.Id.ToString()
                    If HS.First.Reason = 7 Or HS.First.Reason = 8 Then
                        lbStatus.Text = "Assigned"
                        e.Row.ForeColor = Drawing.Color.RoyalBlue
                    Else
                        lbStatus.Text = "Checked Out"
                        e.Row.ForeColor = Drawing.Color.Red
                    End If
                Catch ex As Exception
                    If cbActive.Checked = True Then
                        lbStatus.Text = "Available"
                        e.Row.ForeColor = Drawing.Color.Green
                    Else
                        lbStatus.Text = "Unavailable"
                        e.Row.ForeColor = Drawing.Color.DarkGray
                    End If
                End Try

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub GridViewLaptops_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Add" Then

                If Page.IsValid Then

                    Dim INV As New ListDictionary
                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                    INV.Add("Id", Guid.NewGuid)
                    If DirectCast(row.FindControl("txtDescription"), TextBox).Text <> Nothing Then
                        INV.Add("Description", DirectCast(row.FindControl("txtDescription"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtPCName"), TextBox).Text <> Nothing Then
                        INV.Add("PCName", DirectCast(row.FindControl("txtPCName"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtTagId"), TextBox).Text <> Nothing Then
                        INV.Add("TagId", DirectCast(row.FindControl("txtTagId"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtModel"), TextBox).Text <> Nothing Then
                        INV.Add("Model", DirectCast(row.FindControl("txtModel"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtNotes"), TextBox).Text <> Nothing Then
                        INV.Add("Notes", DirectCast(row.FindControl("txtNotes"), TextBox).Text)
                    End If

                    INV.Add("UH", DirectCast(row.FindControl("cbUH"), CheckBox).Checked)
                    INV.Add("UT", DirectCast(row.FindControl("cbUT"), CheckBox).Checked)
                    INV.Add("Active", "True")
                    INV.Add("EnterBy", hfUser.Value)
                    INV.Add("EnterDate", Now.ToString("G"))

                    Try
                        LinqLaptops.Insert(INV)
                        INV.Clear()
                        SQLLaptops.SelectCommand = Me.ViewState("SQLLaptops")
                        GridViewLaptops.DataBind()
                        lbLaptopsMessage.Text = "Laptop has been added! </br>"
                        lbLaptopsMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbLaptopsMessage.Text = "Your Record was Not Saved! </br>"
                        lbLaptopsMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "UpdateLaptop" Then

                If Page.IsValid Then

                    Try
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                        Dim UP = (From p In TPDC.lkpInventoryLaptops
                                  Where p.Id.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)

                        UP.Description = DirectCast(row.FindControl("txtDescription"), TextBox).Text
                        If DirectCast(row.FindControl("txtPCName"), TextBox).Text IsNot Nothing Then
                            UP.TagId = DirectCast(row.FindControl("txtPCName"), TextBox).Text
                        Else
                            UP.TagId = Nothing
                        End If
                        If DirectCast(row.FindControl("txtTagId"), TextBox).Text IsNot Nothing Then
                            UP.TagId = DirectCast(row.FindControl("txtTagId"), TextBox).Text
                        Else
                            UP.TagId = Nothing
                        End If
                        If DirectCast(row.FindControl("txtModel"), TextBox).Text IsNot Nothing Then
                            UP.Model = DirectCast(row.FindControl("txtModel"), TextBox).Text
                        Else
                            UP.Model = Nothing
                        End If
                        If DirectCast(row.FindControl("txtNotes"), TextBox).Text IsNot Nothing Then
                            UP.Notes = DirectCast(row.FindControl("txtNotes"), TextBox).Text
                        Else
                            UP.Notes = Nothing
                        End If
                        UP.UH = DirectCast(row.FindControl("cbUH"), CheckBox).Checked
                        UP.UT = DirectCast(row.FindControl("cbUT"), CheckBox).Checked
                        UP.Active = DirectCast(row.FindControl("cbActive"), CheckBox).Checked
                        UP.ModifyBy = hfUser.Value
                        UP.ModifyDate = Now.ToString("G")

                        TPDC.SubmitChanges()
                        GridViewLaptops.EditIndex = -1
                        SQLLaptops.SelectCommand = Me.ViewState("SQLLaptops")
                        GridViewLaptops.DataBind()
                        lbLaptopsMessage.Text = "Record has been updated! </br>"
                        lbLaptopsMessage.ForeColor = Drawing.Color.Green

                    Catch ex As Exception
                        lbLaptopsMessage.Text = "Record could not be updated! </br>"
                        lbLaptopsMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "Edit" Then

                SQLLaptops.SelectCommand = Me.ViewState("SQLLaptops")
                GridViewLaptops.DataBind()

            ElseIf e.CommandName = "Cancel" Then

                SQLLaptops.SelectCommand = Me.ViewState("SQLLaptops")
                GridViewLaptops.DataBind()

            ElseIf e.CommandName = "DeleteLaptop" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                Try
                    Dim Delete = From a In TPDC.lkpInventoryLaptops
                                 Where a.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                 Select a

                    For Each a In Delete
                        TPDC.lkpInventoryLaptops.DeleteOnSubmit(a)
                    Next

                    TPDC.SubmitChanges()
                    SQLLaptops.SelectCommand = Me.ViewState("SQLLaptops")
                    GridViewLaptops.DataBind()

                    lbLaptopsMessage.Text = "Item has been deleted! </br>"
                    lbLaptopsMessage.ForeColor = Drawing.Color.Green
                Catch ex As Exception

                    If ex.Message.Contains("REFERENCE constraint") Then
                        lbLaptopsMessage.Text = "*Error! Could not delete Laptop item because it is linked to a user.  <br />Please uncheck Active if this item is no longer in use. </br>"
                    Else
                        lbLaptopsMessage.Text = ex.Message
                    End If
                    lbLaptopsMessage.ForeColor = Drawing.Color.Red

                End Try

            End If

        End With

    End Sub

    Protected Sub GridViewLaptops_RowDeleted(ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)

        lbLaptopsMessage.Text = String.Empty

        Try
            If TypeOf e.Exception Is Exception Then
                Dim sqlErrorCode As String = (CType(e.Exception, Exception)).Message
                If sqlErrorCode.Contains("REFERENCE constraint") Then
                    lbLaptopsMessage.Text = "*Error! Could not delete Laptop because it is linked to a user.  <br />Please uncheck Active if this Laptop is no longer in use. </br>"
                    e.ExceptionHandled = True
                    lbLaptopsMessage.ForeColor = Drawing.Color.Red

                End If
            Else
                lbLaptopsMessage.Text = "Laptop has been deleted! </br>"
                lbLaptopsMessage.ForeColor = Drawing.Color.Green
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub LaptopSort(ByVal Sender As Object, ByVal e As EventArgs)
        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkLaptopDescriptionText"
                sortDirection = If(Me.ViewState("Description") Is Nothing, "ASC", If(Me.ViewState("Description") = "ASC", "DESC", "ASC"))
                Me.ViewState("Description") = sortDirection
                sortExpression = "Description"
            Case "linkLaptopPCNameText"
                sortDirection = If(Me.ViewState("PCName") Is Nothing, "ASC", If(Me.ViewState("PCName") = "ASC", "DESC", "ASC"))
                Me.ViewState("PCName") = sortDirection
                sortExpression = "PCName"
            Case "linkLaptopTagIdText"
                sortDirection = If(Me.ViewState("TagId") Is Nothing, "ASC", If(Me.ViewState("TagId") = "ASC", "DESC", "ASC"))
                Me.ViewState("TagId") = sortDirection
                sortExpression = "TagId"
            Case "linkLaptopModelText"
                sortDirection = If(Me.ViewState("Model") Is Nothing, "ASC", If(Me.ViewState("Model") = "ASC", "DESC", "ASC"))
                Me.ViewState("Model") = sortDirection
                sortExpression = "Model"
            Case "linkLaptopNotesText"
                sortDirection = If(Me.ViewState("Notes") Is Nothing, "ASC", If(Me.ViewState("Notes") = "ASC", "DESC", "ASC"))
                Me.ViewState("Notes") = sortDirection
                sortExpression = "Notes"
            Case "linkLaptopUHText"
                sortDirection = If(Me.ViewState("UH") Is Nothing, "ASC", If(Me.ViewState("UH") = "ASC", "DESC", "ASC"))
                Me.ViewState("UH") = sortDirection
                sortExpression = "UH"
            Case "linkLaptopUTText"
                sortDirection = If(Me.ViewState("UT") Is Nothing, "ASC", If(Me.ViewState("UT") = "ASC", "DESC", "ASC"))
                Me.ViewState("UT") = sortDirection
                sortExpression = "UT"
            Case "linkLaptopStatusText"
                sortDirection = If(Me.ViewState("Active") Is Nothing, "ASC", If(Me.ViewState("Active") = "ASC", "DESC", "ASC"))
                Me.ViewState("Active") = sortDirection
                sortExpression = "Active"
            Case "linkLaptopActiveText"
                sortDirection = If(Me.ViewState("Active") Is Nothing, "ASC", If(Me.ViewState("Active") = "ASC", "DESC", "ASC"))
                Me.ViewState("Active") = sortDirection
                sortExpression = "Active"
            Case Else
                Return
        End Select

        SQLLaptops.SelectCommand = SQLLaptopsCommand(Nothing).Replace("lap.Description ASC", sortExpression) & " " & sortDirection
        Me.ViewState("SQLLaptops") = SQLLaptops.SelectCommand
        GridViewLaptops.DataBind()

    End Sub

    Protected Sub SearchLaptops_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            SQLLaptops.SelectCommand = SQLLaptopsCommand(Nothing)
            Me.ViewState("SQLLaptops") = SQLLaptops.SelectCommand
            GridViewLaptops.DataBind()

        End If

    End Sub

    'Miscellaneous
    Protected Function SQLMiscellaneousCommand(ByVal MyCommand As String) As String

        MyCommand += "SELECT pri.Id, pri.Model, pri.Description, pri.TagId, pri.Notes, pri.UH, pri.UT, pri.Active, "
        MyCommand += "invorg.InventoryOrganization, invtow.InventoryTower, invflo.InventoryFloor, invhal.InventoryHall, invrom.InventoryRoom, "
        MyCommand += "CASE WHEN ISNULL(co.Reason, '') = '' THEN 1 WHEN co.Reason = 7 OR co.Reason = 8 THEN 3 ELSE 2 END AS Assigned "

        MyCommand += "From lkpInventoryMiscellaneous AS pri left outer join "
        MyCommand += "tblInventoryMiscellaneous AS inv on inv.MiscellaneousId = pri.Id left outer join "
        MyCommand += "tblInventoryCheckOut AS co ON co.MiscellaneousId = pri.Id left outer join "
        MyCommand += "lkpInventoryOrganization AS invorg on invorg.Organization = inv.OrganizationId left outer join "
        MyCommand += "lkpInventoryTower AS invtow on invtow.Organization = inv.OrganizationId AND invtow.Tower = inv.TowerId left outer join "
        MyCommand += "lkpInventoryFloor as invflo on invflo.Organization = inv.OrganizationId AND invflo.Tower = inv.TowerId AND invflo.Floor = inv.FloorId left outer join "
        MyCommand += "lkpInventoryHall as invhal on invhal.Organization = inv.OrganizationId AND invhal.Tower = inv.TowerId AND invhal.Floor = inv.FloorId AND invhal.Hall = inv.HallId left outer join "
        MyCommand += "lkpInventoryRoom as invrom on invrom.Organization = inv.OrganizationId AND invrom.Tower = inv.TowerId AND invrom.Floor = inv.FloorId AND invrom.Hall = inv.HallId AND invrom.Room = inv.RoomId "

        MyCommand += "WHERE pri.Model like '%" & txtSearchMiscellaneous.Text & "%' OR pri.Description like '%" & txtSearchMiscellaneous.Text & "%' "
        MyCommand += "OR pri.TagId like '%" & txtSearchMiscellaneous.Text & "%' OR pri.Notes like '%" & txtSearchMiscellaneous.Text & "%' "
        MyCommand += "OR invorg.InventoryOrganization like '%" & txtSearchMiscellaneous.Text & "%' OR invtow.InventoryTower like '%" & txtSearchMiscellaneous.Text & "%' "
        MyCommand += "OR invflo.InventoryFloor like '%" & txtSearchMiscellaneous.Text & "%' OR invhal.InventoryHall like '%" & txtSearchMiscellaneous.Text & "%' "
        MyCommand += "OR invrom.InventoryRoom like '%" & txtSearchMiscellaneous.Text & "%'"

        MyCommand += "Order By pri.Active DESC, Assigned ASC, pri.Description ASC "

        Return MyCommand

    End Function

    Protected Sub GridViewMiscellaneousInventory_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

                Dim ddOrganization As DropDownList = TryCast(e.Row.FindControl("ddInventoryOrganization"), DropDownList)
                Dim ddTower As DropDownList = TryCast(e.Row.FindControl("ddInventoryTower"), DropDownList)
                Dim ddFloor As DropDownList = TryCast(e.Row.FindControl("ddInventoryFloor"), DropDownList)
                Dim ddHall As DropDownList = TryCast(e.Row.FindControl("ddInventoryHall"), DropDownList)
                Dim ddRoom As DropDownList = TryCast(e.Row.FindControl("ddInventoryRoom"), DropDownList)
                Dim rfvInventoryTower As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryTower"), RequiredFieldValidator)
                Dim rfvInventoryFloor As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryFloor"), RequiredFieldValidator)
                Dim rfvInventoryHall As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryHall"), RequiredFieldValidator)
                Dim rfvInventoryRoom As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryRoom"), RequiredFieldValidator)

                Dim ED = From p In TPDC.tblInventoryMiscellaneous
                         Where p.MiscellaneousId.Equals(Guid.Parse(TryCast(e.Row.FindControl("lbId"), Label).Text))
                         Select p.OrganizationId, p.TowerId, p.FloorId, p.HallId, p.RoomId

                Try
                    ddOrganization.SelectedValue = ED.First.OrganizationId
                    dropdownlistSetMiscellaneousLogistics("ddInventoryOrganization", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception

                End Try
                Try
                    ddTower.SelectedValue = ED.First.TowerId
                    dropdownlistSetMiscellaneousLogistics("ddInventoryTower", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception

                End Try
                Try
                    ddFloor.SelectedValue = ED.First.FloorId
                    dropdownlistSetMiscellaneousLogistics("ddInventoryFloor", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception
                End Try
                Try
                    ddHall.SelectedValue = ED.First.HallId
                    dropdownlistSetMiscellaneousLogistics("ddInventoryHall", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception
                End Try
                Try
                    ddRoom.SelectedValue = ED.First.RoomId
                    dropdownlistSetMiscellaneousLogistics("ddInventoryRoom", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception
                End Try

                Dim lbStatus As Label = TryCast(e.Row.FindControl("lbStatus"), Label)
                Dim lbId As Label = TryCast(e.Row.FindControl("lbId"), Label)
                Dim cbActive As CheckBox = TryCast(e.Row.FindControl("cbActive"), CheckBox)

                Dim HS = From a In TPDC.tblInventoryCheckOuts
                         Where a.MiscellaneousId.Equals(lbId.Text)
                         Select a.Id, a.MiscellaneousId, a.Reason

                Try
                    HS.First.Id.ToString()
                    If HS.First.Reason = 7 Or HS.First.Reason = 8 Then
                        lbStatus.Text = "Assigned"
                        e.Row.ForeColor = Drawing.Color.RoyalBlue
                    Else
                        lbStatus.Text = "Checked Out"
                        e.Row.ForeColor = Drawing.Color.Red
                    End If
                Catch ex As Exception
                    If cbActive.Checked = True Then
                        lbStatus.Text = "Available"
                        e.Row.ForeColor = Drawing.Color.Green
                    Else
                        lbStatus.Text = "Unavailable"
                        e.Row.ForeColor = Drawing.Color.DarkGray
                    End If

                End Try

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

                Dim lbStatus As Label = TryCast(e.Row.FindControl("lbStatus"), Label)
                Dim lbId As Label = TryCast(e.Row.FindControl("lbId"), Label)
                Dim cbActive As CheckBox = TryCast(e.Row.FindControl("cbActive"), CheckBox)

                Dim HS = From a In TPDC.tblInventoryCheckOuts
                         Where a.MiscellaneousId.Equals(lbId.Text)
                         Select a.Id, a.MiscellaneousId, a.Reason

                Try
                    HS.First.Id.ToString()
                    If HS.First.Reason = 7 Or HS.First.Reason = 8 Then
                        lbStatus.Text = "Assigned"
                        e.Row.ForeColor = Drawing.Color.RoyalBlue
                    Else
                        lbStatus.Text = "Checked Out"
                        e.Row.ForeColor = Drawing.Color.Red
                    End If
                Catch ex As Exception
                    If cbActive.Checked = True Then
                        lbStatus.Text = "Available"
                        e.Row.ForeColor = Drawing.Color.Green
                    Else
                        lbStatus.Text = "Unavailable"
                        e.Row.ForeColor = Drawing.Color.DarkGray
                        e.Row.Font.Strikeout = True
                    End If
                End Try

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub GridViewMiscellaneousInventory_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Add" Then

                If Page.IsValid Then

                    Dim INV As New ListDictionary
                    Dim PRI As New ListDictionary
                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                    Dim MiscellaneousId As Guid = Guid.NewGuid
                    INV.Add("Id", MiscellaneousId)
                    If DirectCast(row.FindControl("txtMiscellaneousDescription"), TextBox).Text <> Nothing Then
                        INV.Add("Description", DirectCast(row.FindControl("txtMiscellaneousDescription"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtTagId"), TextBox).Text <> Nothing Then
                        INV.Add("TagId", DirectCast(row.FindControl("txtTagId"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtModel"), TextBox).Text <> Nothing Then
                        INV.Add("Model", DirectCast(row.FindControl("txtModel"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtNotes"), TextBox).Text <> Nothing Then
                        INV.Add("Notes", DirectCast(row.FindControl("txtNotes"), TextBox).Text)
                    End If
                    INV.Add("UH", DirectCast(row.FindControl("cbUH"), CheckBox).Checked)
                    INV.Add("UT", DirectCast(row.FindControl("cbUT"), CheckBox).Checked)
                    INV.Add("Active", "True")
                    INV.Add("EnterBy", hfUser.Value)
                    INV.Add("EnterDate", Now.ToString("G"))

                    PRI.Add("MiscellaneousId", MiscellaneousId)
                    If DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("OrganizationId", DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("TowerId", DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue)
                    End If

                    If DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("FloorId", DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("HallId", DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("RoomId", DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue)
                    End If
                    PRI.Add("EnterBy", hfUser.Value)
                    PRI.Add("EnterDate", Now.ToString("G"))

                    Try
                        LinqMiscellaneousInventory.Insert(INV)
                        INV.Clear()
                        LinqMiscellaneousLocation.Insert(PRI)
                        PRI.Clear()
                        SQLMiscellaneous.SelectCommand = Me.ViewState("SQLMiscellaneous")
                        GridViewMiscellaneousInventory.DataBind()
                        lbMiscellaneousMessage.Text = "Miscellaneous has been added! </br>"
                        lbMiscellaneousMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbMiscellaneousMessage.Text = "Your Record was Not Saved! </br>"
                        lbMiscellaneousMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "UpdateMiscellaneous" Then

                If Page.IsValid Then

                    Try
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                        Dim UP = (From p In TPDC.lkpInventoryMiscellaneous
                                  Where p.Id.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)

                        If DirectCast(row.FindControl("txtMiscellaneousDescription"), TextBox).Text <> Nothing Then
                            UP.Description = DirectCast(row.FindControl("txtMiscellaneousDescription"), TextBox).Text
                        Else
                            UP.Description = Nothing
                        End If
                        If DirectCast(row.FindControl("txtTagId"), TextBox).Text <> Nothing Then
                            UP.TagId = DirectCast(row.FindControl("txtTagId"), TextBox).Text
                        Else
                            UP.TagId = Nothing
                        End If
                        If DirectCast(row.FindControl("txtModel"), TextBox).Text <> Nothing Then
                            UP.Model = DirectCast(row.FindControl("txtModel"), TextBox).Text
                        Else
                            UP.Model = Nothing
                        End If
                        If DirectCast(row.FindControl("txtNotes"), TextBox).Text <> Nothing Then
                            UP.Notes = DirectCast(row.FindControl("txtNotes"), TextBox).Text
                        Else
                            UP.Notes = Nothing
                        End If

                        UP.UH = DirectCast(row.FindControl("cbUH"), CheckBox).Checked
                        UP.UT = DirectCast(row.FindControl("cbUT"), CheckBox).Checked
                        UP.Active = DirectCast(row.FindControl("cbActive"), CheckBox).Checked
                        UP.ModifyBy = hfUser.Value
                        UP.ModifyDate = Now.ToString("G")

                        Dim UPII = (From p In TPDC.tblInventoryMiscellaneous
                                    Where p.MiscellaneousId.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)

                        If DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue <> Nothing Then
                            UPII.OrganizationId = DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue
                        Else
                            UPII.OrganizationId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue <> Nothing Then
                            UPII.TowerId = DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue
                        Else
                            UPII.TowerId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue <> Nothing Then
                            UPII.FloorId = DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue
                        Else
                            UPII.FloorId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue <> Nothing Then
                            UPII.HallId = DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue
                        Else
                            UPII.HallId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue <> Nothing Then
                            UPII.RoomId = DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue
                        Else
                            UPII.RoomId = Nothing
                        End If
                        UPII.ModifyBy = hfUser.Value
                        UPII.ModifyDate = Now.ToString("G")

                        TPDC.SubmitChanges()

                        GridViewMiscellaneousInventory.EditIndex = -1
                        SQLMiscellaneous.SelectCommand = Me.ViewState("SQLMiscellaneous")
                        GridViewMiscellaneousInventory.DataBind()
                        lbMiscellaneousMessage.Text = "Record has been updated! </br>"
                        lbMiscellaneousMessage.ForeColor = Drawing.Color.Green

                    Catch ex As Exception
                        lbMiscellaneousMessage.Text = "Record could not be updated! </br>"
                        lbMiscellaneousMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "Edit" Then

                SQLMiscellaneous.SelectCommand = Me.ViewState("SQLMiscellaneous")
                GridViewMiscellaneousInventory.DataBind()

            ElseIf e.CommandName = "Cancel" Then

                SQLMiscellaneous.SelectCommand = Me.ViewState("SQLMiscellaneous")
                GridViewMiscellaneousInventory.DataBind()

            ElseIf e.CommandName = "DeleteMiscellaneous" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                Try
                    Dim Delete = From p In TPDC.tblInventoryMiscellaneous
                                 Where p.MiscellaneousId.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                 Select p

                    For Each p In Delete
                        TPDC.tblInventoryMiscellaneous.DeleteOnSubmit(p)
                    Next

                    Dim DeleteII = From a In TPDC.lkpInventoryMiscellaneous
                                   Where a.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                   Select a

                    For Each a In DeleteII
                        TPDC.lkpInventoryMiscellaneous.DeleteOnSubmit(a)
                    Next

                    TPDC.SubmitChanges()
                    SQLMiscellaneous.SelectCommand = Me.ViewState("SQLMiscellaneous")
                    GridViewMiscellaneousInventory.DataBind()

                    lbMiscellaneousMessage.Text = "Item has been deleted! </br>"
                    lbMiscellaneousMessage.ForeColor = Drawing.Color.Green
                Catch ex As Exception

                    If ex.Message.Contains("REFERENCE constraint") Then
                        lbMiscellaneousMessage.Text = "*Error! Could not delete Miscellaneous item because it is linked to a user.  <br />Please uncheck Active if this item is no longer in use. </br>"
                    Else
                        lbMiscellaneousMessage.Text = ex.Message
                    End If
                    lbMiscellaneousMessage.ForeColor = Drawing.Color.Red

                End Try

            End If

        End With

    End Sub

    Protected Sub MiscellaneousInventorySort(ByVal Sender As Object, ByVal e As EventArgs)

        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkMiscellaneousDescription"
                sortDirection = If(Me.ViewState("MiscellaneousDescription") Is Nothing, "ASC", If(Me.ViewState("MiscellaneousDescription") = "ASC", "DESC", "ASC"))
                Me.ViewState("MiscellaneousDescription") = sortDirection
                sortExpression = "pri.Description"
            Case "linkModel"
                sortDirection = If(Me.ViewState("Model") Is Nothing, "ASC", If(Me.ViewState("Model") = "ASC", "DESC", "ASC"))
                Me.ViewState("Model") = sortDirection
                sortExpression = "pri.Model"
            Case "linkTagId"
                sortDirection = If(Me.ViewState("TagId") Is Nothing, "ASC", If(Me.ViewState("TagId") = "ASC", "DESC", "ASC"))
                Me.ViewState("TagId") = sortDirection
                sortExpression = "pri.TagId"
            Case "linkNotes"
                sortDirection = If(Me.ViewState("Notes") Is Nothing, "ASC", If(Me.ViewState("Notes") = "ASC", "DESC", "ASC"))
                Me.ViewState("Notes") = sortDirection
                sortExpression = "pri.Notes"
            Case "linkUH"
                sortDirection = If(Me.ViewState("UH") Is Nothing, "ASC", If(Me.ViewState("UH") = "ASC", "DESC", "ASC"))
                Me.ViewState("UH") = sortDirection
                sortExpression = "pri.UH"
            Case "linkUT"
                sortDirection = If(Me.ViewState("UT") Is Nothing, "ASC", If(Me.ViewState("UT") = "ASC", "DESC", "ASC"))
                Me.ViewState("UT") = sortDirection
                sortExpression = "pri.UT"
            Case "linkActive"
                sortDirection = If(Me.ViewState("Active") Is Nothing, "ASC", If(Me.ViewState("Active") = "ASC", "DESC", "ASC"))
                Me.ViewState("Active") = sortDirection
                sortExpression = "pri.Active"
            Case "linkInventoryOrganization"
                sortDirection = If(Me.ViewState("Organization") Is Nothing, "ASC", If(Me.ViewState("Organization") = "ASC", "DESC", "ASC"))
                Me.ViewState("Organization") = sortDirection
                sortExpression = "invorg.InventoryOrganization"
            Case "linkInventoryTower"
                sortDirection = If(Me.ViewState("Tower") Is Nothing, "ASC", If(Me.ViewState("Tower") = "ASC", "DESC", "ASC"))
                Me.ViewState("Tower") = sortDirection
                sortExpression = "invtow.InventoryTower"
            Case "linkInventoryFloor"
                sortDirection = If(Me.ViewState("Floor") Is Nothing, "ASC", If(Me.ViewState("Floor") = "ASC", "DESC", "ASC"))
                Me.ViewState("Floor") = sortDirection
                sortExpression = "invflo.InventoryFloor"
            Case "linkInventoryHall"
                sortDirection = If(Me.ViewState("Hall") Is Nothing, "ASC", If(Me.ViewState("Hall") = "ASC", "DESC", "ASC"))
                Me.ViewState("Hall") = sortDirection
                sortExpression = "invhal.InventoryHall"
            Case "linkInventoryRoom"
                sortDirection = If(Me.ViewState("Room") Is Nothing, "ASC", If(Me.ViewState("Room") = "ASC", "DESC", "ASC"))
                Me.ViewState("Room") = sortDirection
                sortExpression = "invrom.InventoryRoom"
            Case Else
                Return
        End Select

        SQLMiscellaneous.SelectCommand = SQLMiscellaneousCommand(Nothing).Replace("pri.Description ASC ", sortExpression) & " " & sortDirection
        Me.ViewState("SQLMiscellaneous") = SQLMiscellaneous.SelectCommand
        GridViewMiscellaneousInventory.DataBind()

    End Sub

    Protected Sub SearchMiscellaneous_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            SQLMiscellaneous.SelectCommand = SQLMiscellaneousCommand(Nothing)
            Me.ViewState("SQLMiscellaneous") = SQLMiscellaneous.SelectCommand
            GridViewMiscellaneousInventory.DataBind()

        End If

    End Sub

    Protected Sub dropdownlistMiscellaneousLocation_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ddInventoryOrganization As DropDownList = CType(GridViewMiscellaneousInventory.HeaderRow.FindControl("ddInventoryOrganization"), DropDownList)
        Dim ddInventoryTower As DropDownList = CType(GridViewMiscellaneousInventory.HeaderRow.FindControl("ddInventoryTower"), DropDownList)
        Dim ddInventoryFloor As DropDownList = CType(GridViewMiscellaneousInventory.HeaderRow.FindControl("ddInventoryFloor"), DropDownList)
        Dim ddInventoryHall As DropDownList = CType(GridViewMiscellaneousInventory.HeaderRow.FindControl("ddInventoryHall"), DropDownList)
        Dim ddInventoryRoom As DropDownList = CType(GridViewMiscellaneousInventory.HeaderRow.FindControl("ddInventoryRoom"), DropDownList)
        Dim rfvInventoryTower As RequiredFieldValidator = CType(GridViewMiscellaneousInventory.HeaderRow.FindControl("rfvInventoryTower"), RequiredFieldValidator)
        Dim rfvInventoryFloor As RequiredFieldValidator = CType(GridViewMiscellaneousInventory.HeaderRow.FindControl("rfvInventoryFloor"), RequiredFieldValidator)
        Dim rfvInventoryHall As RequiredFieldValidator = CType(GridViewMiscellaneousInventory.HeaderRow.FindControl("rfvInventoryHall"), RequiredFieldValidator)
        Dim rfvInventoryRoom As RequiredFieldValidator = CType(GridViewMiscellaneousInventory.HeaderRow.FindControl("rfvInventoryRoom"), RequiredFieldValidator)

        dropdownlistSetMiscellaneousLogistics(sender.Id, ddInventoryOrganization, ddInventoryTower, ddInventoryFloor, ddInventoryHall, ddInventoryRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)

    End Sub

    Protected Sub dropdownlistMiscellaneousLocationEdit_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ddType As DropDownList = DirectCast(sender, DropDownList)
        Dim rowType As GridViewRow = DirectCast(ddType.NamingContainer, GridViewRow)
        Dim ddInventoryOrganization As DropDownList = CType(rowType.FindControl("ddInventoryOrganization"), DropDownList)
        Dim ddInventoryTower As DropDownList = CType(rowType.FindControl("ddInventoryTower"), DropDownList)
        Dim ddInventoryFloor As DropDownList = CType(rowType.FindControl("ddInventoryFloor"), DropDownList)
        Dim ddInventoryHall As DropDownList = CType(rowType.FindControl("ddInventoryHall"), DropDownList)
        Dim ddInventoryRoom As DropDownList = CType(rowType.FindControl("ddInventoryRoom"), DropDownList)
        Dim rfvInventoryTower As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryTower"), RequiredFieldValidator)
        Dim rfvInventoryFloor As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryFloor"), RequiredFieldValidator)
        Dim rfvInventoryHall As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryHall"), RequiredFieldValidator)
        Dim rfvInventoryRoom As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryRoom"), RequiredFieldValidator)

        dropdownlistSetMiscellaneousLogistics(sender.Id, ddInventoryOrganization, ddInventoryTower, ddInventoryFloor, ddInventoryHall, ddInventoryRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)

    End Sub

    Protected Function dropdownlistSetMiscellaneousLogistics(ByVal sender As String, ddInventoryOrganization As DropDownList, ddInventoryTower As DropDownList, ddInventoryFloor As DropDownList, ddInventoryHall As DropDownList, ddInventoryRoom As DropDownList, rfvInventoryTower As RequiredFieldValidator, rfvInventoryFloor As RequiredFieldValidator, rfvInventoryHall As RequiredFieldValidator, rfvInventoryRoom As RequiredFieldValidator) As String

        Select Case sender
            Case "ddInventoryOrganization"
                If ddInventoryOrganization.SelectedIndex > 0 Then
                    LinqMiscellaneousTower.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Active = True"
                    ddInventoryTower.Items.Clear()
                    ddInventoryTower.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryTower.SelectedIndex = 0
                    ddInventoryTower.DataBind()
                    ddInventoryTower.Enabled = True
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                    rfvInventoryTower.Enabled = True
                    rfvInventoryFloor.Enabled = True
                    rfvInventoryHall.Enabled = True
                    rfvInventoryRoom.Enabled = True
                Else
                    ddInventoryTower.SelectedIndex = 0
                    ddInventoryTower.Enabled = False
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                    rfvInventoryTower.Enabled = False
                    rfvInventoryFloor.Enabled = False
                    rfvInventoryHall.Enabled = False
                    rfvInventoryRoom.Enabled = False
                End If
            Case "ddInventoryTower"
                If ddInventoryTower.SelectedIndex > 0 Then
                    LinqMiscellaneousFloor.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Active = True"
                    ddInventoryFloor.Items.Clear()
                    ddInventoryFloor.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.DataBind()
                    ddInventoryFloor.Enabled = True
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                Else
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryFloor"
                If ddInventoryFloor.SelectedIndex > 0 Then
                    LinqMiscellaneousHall.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Floor=" & ddInventoryFloor.SelectedValue & " AND Active = True"
                    ddInventoryHall.Items.Clear()
                    ddInventoryHall.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.DataBind()
                    ddInventoryHall.Enabled = True
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                Else
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryHall"
                If ddInventoryHall.SelectedIndex > 0 Then
                    LinqMiscellaneousRoom.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Floor=" & ddInventoryFloor.SelectedValue & " AND Hall=" & ddInventoryHall.SelectedValue & " AND Active = True"
                    ddInventoryRoom.Items.Clear()
                    ddInventoryRoom.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.DataBind()
                    ddInventoryRoom.Enabled = True
                Else
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryRoom"
            Case Else
        End Select


        Return True
    End Function

    'PCs
    Protected Function SQLPCCommand(ByVal MyCommand As String) As String

        MyCommand += "SELECT pri.Id, pri.Model, pri.PCName, pri.TagId, pri.Notes, pri.UH, pri.UT, pri.Active, "
        MyCommand += "invorg.InventoryOrganization, invtow.InventoryTower, invflo.InventoryFloor, invhal.InventoryHall, invrom.InventoryRoom, "
        MyCommand += "staff.FName + ISNULL(' ' + NULLIF(staff.MName, '') + ' ', ' ') + staff.LName AS StaffList, staff.UserId "

        MyCommand += "From lkpInventoryPCs AS pri left outer join "
        MyCommand += "tblInventoryPCs AS inv on inv.PCId = pri.Id left outer join "
        MyCommand += "lkpInventoryOrganization AS invorg on invorg.Organization = inv.OrganizationId left outer join "
        MyCommand += "lkpInventoryTower AS invtow on invtow.Organization = inv.OrganizationId AND invtow.Tower = inv.TowerId left outer join "
        MyCommand += "lkpInventoryFloor as invflo on invflo.Organization = inv.OrganizationId AND invflo.Tower = inv.TowerId AND invflo.Floor = inv.FloorId left outer join "
        MyCommand += "lkpInventoryHall as invhal on invhal.Organization = inv.OrganizationId AND invhal.Tower = inv.TowerId AND invhal.Floor = inv.FloorId AND invhal.Hall = inv.HallId left outer join "
        MyCommand += "lkpInventoryRoom as invrom on invrom.Organization = inv.OrganizationId AND invrom.Tower = inv.TowerId AND invrom.Floor = inv.FloorId AND invrom.Hall = inv.HallId AND invrom.Room = inv.RoomId left outer join "
        MyCommand += "tblInventoryUsers as users on users.PCId = pri.Id left outer join "
        MyCommand += "tblStaff as staff on staff.UserId = users.UserId OUTER APPLY "
        MyCommand += "(SELECT TOP 1 Staff.LName + ', ' + Staff.FName AS Name FROM tblStaff AS Staff WHERE Staff.UserId = users.UserId) AS StaffName "

        MyCommand += "WHERE pri.Model like '%" & txtSearchPCs.Text & "%' OR pri.PCName like '%" & txtSearchPCs.Text & "%' "
        MyCommand += "OR pri.TagId like '%" & txtSearchPCs.Text & "%' OR pri.Notes like '%" & txtSearchPCs.Text & "%' "
        MyCommand += "OR invorg.InventoryOrganization like '%" & txtSearchPCs.Text & "%' OR invtow.InventoryTower like '%" & txtSearchPCs.Text & "%' "
        MyCommand += "OR invflo.InventoryFloor like '%" & txtSearchPCs.Text & "%' OR invhal.InventoryHall like '%" & txtSearchPCs.Text & "%' "
        MyCommand += "OR invrom.InventoryRoom like '%" & txtSearchPCs.Text & "%' OR StaffName.Name like '%" & txtSearchPCs.Text & "%' "

        MyCommand += "Order By pri.Active DESC, inv.EnterDate DESC "

        Return MyCommand

    End Function

    Protected Sub GridViewPCsInventory_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

                Dim ddOrganization As DropDownList = TryCast(e.Row.FindControl("ddInventoryOrganization"), DropDownList)
                Dim ddTower As DropDownList = TryCast(e.Row.FindControl("ddInventoryTower"), DropDownList)
                Dim ddFloor As DropDownList = TryCast(e.Row.FindControl("ddInventoryFloor"), DropDownList)
                Dim ddHall As DropDownList = TryCast(e.Row.FindControl("ddInventoryHall"), DropDownList)
                Dim ddRoom As DropDownList = TryCast(e.Row.FindControl("ddInventoryRoom"), DropDownList)
                Dim rfvInventoryTower As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryTower"), RequiredFieldValidator)
                Dim rfvInventoryFloor As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryFloor"), RequiredFieldValidator)
                Dim rfvInventoryHall As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryHall"), RequiredFieldValidator)
                Dim rfvInventoryRoom As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryRoom"), RequiredFieldValidator)

                Dim ED = From p In TPDC.tblInventoryPCs
                         Where p.PCId.Equals(Guid.Parse(TryCast(e.Row.FindControl("lbId"), Label).Text))
                         Select p.OrganizationId, p.TowerId, p.FloorId, p.HallId, p.RoomId, p.PCId

                Try
                    ddOrganization.SelectedValue = ED.First.OrganizationId
                    dropdownlistSetPCLogistics("ddInventoryOrganization", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception

                End Try
                Try
                    ddTower.SelectedValue = ED.First.TowerId
                    dropdownlistSetPCLogistics("ddInventoryTower", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception

                End Try
                Try
                    ddFloor.SelectedValue = ED.First.FloorId
                    dropdownlistSetPCLogistics("ddInventoryFloor", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception
                End Try
                Try
                    ddHall.SelectedValue = ED.First.HallId
                    dropdownlistSetPCLogistics("ddInventoryHall", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception
                End Try
                Try
                    ddRoom.SelectedValue = ED.First.RoomId
                    dropdownlistSetPCLogistics("ddInventoryRoom", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception
                End Try

                Dim ddStaffList As DropDownList = TryCast(e.Row.FindControl("ddStaffList"), DropDownList)

                Dim UTC = (From u In TPDC.tblStaffs
                           Where u.EndDate Is Nothing
                           Let MyName = u.FName.ToString & If(u.MName IsNot Nothing, " " & u.MName.ToString() & " ", " ") & u.LName.ToString()
                           Order By MyName Ascending
                           Select MyName, u.UserId).ToList()

                Dim USE = From p In TPDC.tblInventoryUsers
                          Where p.PCId.Equals(ED.First.PCId)
                          Select p.PCId, MyName = p.tblStaff.FName.ToString & If(p.tblStaff.MName IsNot Nothing, " " & p.tblStaff.MName.ToString() & " ", " ") & p.tblStaff.LName.ToString,
                                  p.tblStaff.LName, p.tblStaff.FName

                ddStaffList.DataSource = UTC

                Try
                    ddStaffList.SelectedIndex = UTC.FindIndex(Function(a) a.MyName.Contains(USE.First.MyName)) + 1
                Catch ex As Exception

                End Try

                ddStaffList.DataBind()

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

                Dim ddStaffList As DropDownList = TryCast(e.Row.FindControl("ddStaffList"), DropDownList)

                Try
                    Dim UTC = (From u In TPDC.tblStaffs
                               Where u.EndDate Is Nothing
                               Let MyName = u.FName.ToString & If(u.MName IsNot Nothing, " " & u.MName.ToString() & " ", " ") & u.LName.ToString()
                               Order By MyName Ascending
                               Select MyName, u.UserId).Distinct

                    ddStaffList.DataSource = UTC.ToList
                    ddStaffList.DataBind()
                Catch ex As Exception

                End Try

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub GridViewPCsInventory_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Add" Then

                If Page.IsValid Then

                    Dim INV As New ListDictionary
                    Dim PRI As New ListDictionary
                    Dim USE As New ListDictionary
                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                    Dim PCId As Guid = Guid.NewGuid
                    INV.Add("Id", PCId)
                    If DirectCast(row.FindControl("txtPCName"), TextBox).Text <> Nothing Then
                        INV.Add("PCName", DirectCast(row.FindControl("txtPCName"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtTagId"), TextBox).Text <> Nothing Then
                        INV.Add("TagId", DirectCast(row.FindControl("txtTagId"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtModel"), TextBox).Text <> Nothing Then
                        INV.Add("Model", DirectCast(row.FindControl("txtModel"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtNotes"), TextBox).Text <> Nothing Then
                        INV.Add("Notes", DirectCast(row.FindControl("txtNotes"), TextBox).Text)
                    End If
                    INV.Add("UH", DirectCast(row.FindControl("cbUH"), CheckBox).Checked)
                    INV.Add("UT", DirectCast(row.FindControl("cbUT"), CheckBox).Checked)
                    INV.Add("Active", "True")
                    INV.Add("EnterBy", hfUser.Value)
                    INV.Add("EnterDate", Now.ToString("G"))

                    PRI.Add("PCId", PCId)
                    If DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("OrganizationId", DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("TowerId", DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue)
                    End If

                    If DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("FloorId", DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("HallId", DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("RoomId", DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue)
                    End If
                    PRI.Add("EnterBy", hfUser.Value)
                    PRI.Add("EnterDate", Now.ToString("G"))

                    Try
                        LinqPCsInventory.Insert(INV)
                        INV.Clear()
                        LinqPCsLocation.Insert(PRI)
                        PRI.Clear()

                        If DirectCast(row.FindControl("ddStaffList"), DropDownList).SelectedValue <> Nothing Then

                            USE.Add("UserId", Guid.Parse(DirectCast(row.FindControl("ddStaffList"), DropDownList).SelectedValue))
                            USE.Add("PCId", PCId)
                            USE.Add("EnterBy", hfUser.Value)
                            USE.Add("EnterDate", Now.ToString("G"))

                            LinqPCsUsers.Insert(USE)
                            USE.Clear()
                        End If

                        GridViewPCsInventory.DataBind()
                        SQLPCs.SelectCommand = Me.ViewState("SQLPCs")
                        lbPCsMessage.Text = "PC has been added! </br>"
                        lbPCsMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbPCsMessage.Text = "Your Record was Not Saved! </br>"
                        lbPCsMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "UpdatePC" Then

                If Page.IsValid Then

                    Try
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                        Dim UP = (From p In TPDC.lkpInventoryPCs
                                  Where p.Id.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)

                        If DirectCast(row.FindControl("txtPCName"), TextBox).Text <> Nothing Then
                            UP.PCName = DirectCast(row.FindControl("txtPCName"), TextBox).Text
                        Else
                            UP.PCName = Nothing
                        End If
                        If DirectCast(row.FindControl("txtTagId"), TextBox).Text <> Nothing Then
                            UP.TagId = DirectCast(row.FindControl("txtTagId"), TextBox).Text
                        Else
                            UP.TagId = Nothing
                        End If
                        If DirectCast(row.FindControl("txtModel"), TextBox).Text <> Nothing Then
                            UP.Model = DirectCast(row.FindControl("txtModel"), TextBox).Text
                        Else
                            UP.Model = Nothing
                        End If

                        If DirectCast(row.FindControl("txtNotes"), TextBox).Text <> Nothing Then
                            UP.Notes = DirectCast(row.FindControl("txtNotes"), TextBox).Text
                        Else
                            UP.Notes = Nothing
                        End If

                        UP.UH = DirectCast(row.FindControl("cbUH"), CheckBox).Checked
                        UP.UT = DirectCast(row.FindControl("cbUT"), CheckBox).Checked
                        UP.Active = DirectCast(row.FindControl("cbActive"), CheckBox).Checked
                        UP.ModifyBy = hfUser.Value
                        UP.ModifyDate = Now.ToString("G")

                        Dim UPII = (From p In TPDC.tblInventoryPCs
                                    Where p.PCId.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)

                        If DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue <> Nothing Then
                            UPII.OrganizationId = DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue
                        Else
                            UPII.OrganizationId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue <> Nothing Then
                            UPII.TowerId = DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue
                        Else
                            UPII.TowerId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue <> Nothing Then
                            UPII.FloorId = DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue
                        Else
                            UPII.FloorId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue <> Nothing Then
                            UPII.HallId = DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue
                        Else
                            UPII.HallId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue <> Nothing Then
                            UPII.RoomId = DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue
                        Else
                            UPII.RoomId = Nothing
                        End If
                        UPII.ModifyBy = hfUser.Value
                        UPII.ModifyDate = Now.ToString("G")

                        'Check if entry exists in tblInventoryUsers
                        Dim check = From p In TPDC.tblInventoryUsers
                                    Where p.PCId.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))

                        Try
                            check.First.PCId.ToString()
                            'If exists, update
                            Dim UPIII = (From p In TPDC.tblInventoryUsers
                                         Where p.PCId.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)
                            If DirectCast(row.FindControl("ddStaffList"), DropDownList).SelectedValue <> Nothing Then
                                UPIII.UserId = Guid.Parse(DirectCast(row.FindControl("ddStaffList"), DropDownList).SelectedValue)
                            Else
                                UPIII.UserId = Nothing
                            End If
                            UPIII.ModifyBy = hfUser.Value
                            UPIII.ModifyDate = Now.ToString("G")
                        Catch ex As Exception
                            'Does not exist, Insert
                            If DirectCast(row.FindControl("ddStaffList"), DropDownList).SelectedValue <> Nothing Then
                                Dim USE As New ListDictionary
                                USE.Add("UserId", Guid.Parse(DirectCast(row.FindControl("ddStaffList"), DropDownList).SelectedValue))
                                USE.Add("PCId", DirectCast(row.FindControl("lbId"), Label).Text)
                                USE.Add("EnterBy", hfUser.Value)
                                USE.Add("EnterDate", Now.ToString("G"))

                                LinqPCsUsers.Insert(USE)
                                USE.Clear()
                            End If
                        End Try

                        TPDC.SubmitChanges()

                        GridViewPCsInventory.EditIndex = -1
                        SQLPCs.SelectCommand = Me.ViewState("SQLPCs")
                        GridViewPCsInventory.DataBind()
                        lbPCsMessage.Text = "Record has been updated! </br>"
                        lbPCsMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbPCsMessage.Text = "Record could not be updated! </br>"
                        lbPCsMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "Edit" Then

                SQLPCs.SelectCommand = Me.ViewState("SQLPCs")
                GridViewPCsInventory.DataBind()

            ElseIf e.CommandName = "Cancel" Then

                SQLPCs.SelectCommand = Me.ViewState("SQLPCs")
                GridViewPCsInventory.DataBind()

            ElseIf e.CommandName = "DeletePC" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                Try
                    Dim Delete = From p In TPDC.tblInventoryPCs
                                 Where p.PCId.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                 Select p

                    For Each p In Delete
                        TPDC.tblInventoryPCs.DeleteOnSubmit(p)
                    Next

                    Dim DeleteII = From a In TPDC.tblInventoryUsers
                                   Where a.PCId.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                   Select a

                    For Each a In DeleteII
                        TPDC.tblInventoryUsers.DeleteOnSubmit(a)
                    Next

                    Dim DeleteIII = From a In TPDC.lkpInventoryPCs
                                    Where a.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                    Select a

                    For Each a In DeleteIII
                        TPDC.lkpInventoryPCs.DeleteOnSubmit(a)
                    Next

                    TPDC.SubmitChanges()
                    SQLPCs.SelectCommand = Me.ViewState("SQLPCs")
                    GridViewPCsInventory.DataBind()
                Catch ex As Exception

                End Try

            ElseIf e.CommandName = "Staff" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                ScriptManager.RegisterStartupScript(Me, [GetType](), "Users", "window.open('~/Pages/UserFrame.aspx?U=" & DirectCast(row.FindControl("lbStaffUserId"), Label).Text & "&F=" & hfFrom.Value & "','Users','height=980,width=1040,status=no,resizable=yes,scrollbars=yes,toolbar=no,location=no,menubar=no');", True)

            End If

        End With

    End Sub

    Protected Sub PCsInventorySort(ByVal Sender As Object, ByVal e As EventArgs)

        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkPCName"
                sortDirection = If(Me.ViewState("PCName") Is Nothing, "ASC", If(Me.ViewState("PCName") = "ASC", "DESC", "ASC"))
                Me.ViewState("PCName") = sortDirection
                sortExpression = "pri.PCName"
            Case "linkStaffList"
                sortDirection = If(Me.ViewState("StaffList") Is Nothing, "ASC", If(Me.ViewState("StaffList") = "ASC", "DESC", "ASC"))
                Me.ViewState("StaffList") = sortDirection
                sortExpression = "StaffList"
            Case "linkTagId"
                sortDirection = If(Me.ViewState("TagId") Is Nothing, "ASC", If(Me.ViewState("TagId") = "ASC", "DESC", "ASC"))
                Me.ViewState("TagId") = sortDirection
                sortExpression = "pri.TagId"
            Case "linkModel"
                sortDirection = If(Me.ViewState("Model") Is Nothing, "ASC", If(Me.ViewState("Model") = "ASC", "DESC", "ASC"))
                Me.ViewState("Model") = sortDirection
                sortExpression = "pri.Model"
            Case "linkNotes"
                sortDirection = If(Me.ViewState("Notes") Is Nothing, "ASC", If(Me.ViewState("Notes") = "ASC", "DESC", "ASC"))
                Me.ViewState("Notes") = sortDirection
                sortExpression = "pri.Notes"
            Case "linkUH"
                sortDirection = If(Me.ViewState("UH") Is Nothing, "ASC", If(Me.ViewState("UH") = "ASC", "DESC", "ASC"))
                Me.ViewState("UH") = sortDirection
                sortExpression = "pri.UH"
            Case "linkUT"
                sortDirection = If(Me.ViewState("UT") Is Nothing, "ASC", If(Me.ViewState("UT") = "ASC", "DESC", "ASC"))
                Me.ViewState("UT") = sortDirection
                sortExpression = "pri.UT"
            Case "linkActive"
                sortDirection = If(Me.ViewState("Active") Is Nothing, "ASC", If(Me.ViewState("Active") = "ASC", "DESC", "ASC"))
                Me.ViewState("Active") = sortDirection
                sortExpression = "pri.Active"
            Case "linkInventoryOrganization"
                sortDirection = If(Me.ViewState("Organization") Is Nothing, "ASC", If(Me.ViewState("Organization") = "ASC", "DESC", "ASC"))
                Me.ViewState("Organization") = sortDirection
                sortExpression = "invorg.InventoryOrganization"
            Case "linkInventoryTower"
                sortDirection = If(Me.ViewState("Tower") Is Nothing, "ASC", If(Me.ViewState("Tower") = "ASC", "DESC", "ASC"))
                Me.ViewState("Tower") = sortDirection
                sortExpression = "invtow.InventoryTower"
            Case "linkInventoryFloor"
                sortDirection = If(Me.ViewState("Floor") Is Nothing, "ASC", If(Me.ViewState("Floor") = "ASC", "DESC", "ASC"))
                Me.ViewState("Floor") = sortDirection
                sortExpression = "invflo.InventoryFloor"
            Case "linkInventoryHall"
                sortDirection = If(Me.ViewState("Hall") Is Nothing, "ASC", If(Me.ViewState("Hall") = "ASC", "DESC", "ASC"))
                Me.ViewState("Hall") = sortDirection
                sortExpression = "invhal.InventoryHall"
            Case "linkInventoryRoom"
                sortDirection = If(Me.ViewState("Room") Is Nothing, "ASC", If(Me.ViewState("Room") = "ASC", "DESC", "ASC"))
                Me.ViewState("Room") = sortDirection
                sortExpression = "invrom.InventoryRoom"
            Case Else
                Return
        End Select

        SQLPCs.SelectCommand = SQLPCCommand(Nothing).Replace("inv.EnterDate DESC ", sortExpression) & " " & sortDirection
        Me.ViewState("SQLPCs") = SQLPCs.SelectCommand
        GridViewPCsInventory.DataBind()

    End Sub

    Protected Sub SearchPCs_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            SQLPCs.SelectCommand = SQLPCCommand(Nothing)
            Me.ViewState("SQLPCs") = SQLPCs.SelectCommand
            GridViewPCsInventory.DataBind()

        End If

    End Sub

    Protected Sub dropdownlistPCLocation_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ddInventoryOrganization As DropDownList = CType(GridViewPCsInventory.HeaderRow.FindControl("ddInventoryOrganization"), DropDownList)
        Dim ddInventoryTower As DropDownList = CType(GridViewPCsInventory.HeaderRow.FindControl("ddInventoryTower"), DropDownList)
        Dim ddInventoryFloor As DropDownList = CType(GridViewPCsInventory.HeaderRow.FindControl("ddInventoryFloor"), DropDownList)
        Dim ddInventoryHall As DropDownList = CType(GridViewPCsInventory.HeaderRow.FindControl("ddInventoryHall"), DropDownList)
        Dim ddInventoryRoom As DropDownList = CType(GridViewPCsInventory.HeaderRow.FindControl("ddInventoryRoom"), DropDownList)
        Dim rfvInventoryTower As RequiredFieldValidator = CType(GridViewPCsInventory.HeaderRow.FindControl("rfvInventoryTower"), RequiredFieldValidator)
        Dim rfvInventoryFloor As RequiredFieldValidator = CType(GridViewPCsInventory.HeaderRow.FindControl("rfvInventoryFloor"), RequiredFieldValidator)
        Dim rfvInventoryHall As RequiredFieldValidator = CType(GridViewPCsInventory.HeaderRow.FindControl("rfvInventoryHall"), RequiredFieldValidator)
        Dim rfvInventoryRoom As RequiredFieldValidator = CType(GridViewPCsInventory.HeaderRow.FindControl("rfvInventoryRoom"), RequiredFieldValidator)

        dropdownlistSetPCLogistics(sender.Id, ddInventoryOrganization, ddInventoryTower, ddInventoryFloor, ddInventoryHall, ddInventoryRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)

    End Sub

    Protected Sub dropdownlistPCLocationEdit_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ddType As DropDownList = DirectCast(sender, DropDownList)
        Dim rowType As GridViewRow = DirectCast(ddType.NamingContainer, GridViewRow)
        Dim ddInventoryOrganization As DropDownList = CType(rowType.FindControl("ddInventoryOrganization"), DropDownList)
        Dim ddInventoryTower As DropDownList = CType(rowType.FindControl("ddInventoryTower"), DropDownList)
        Dim ddInventoryFloor As DropDownList = CType(rowType.FindControl("ddInventoryFloor"), DropDownList)
        Dim ddInventoryHall As DropDownList = CType(rowType.FindControl("ddInventoryHall"), DropDownList)
        Dim ddInventoryRoom As DropDownList = CType(rowType.FindControl("ddInventoryRoom"), DropDownList)
        Dim rfvInventoryTower As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryTower"), RequiredFieldValidator)
        Dim rfvInventoryFloor As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryFloor"), RequiredFieldValidator)
        Dim rfvInventoryHall As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryHall"), RequiredFieldValidator)
        Dim rfvInventoryRoom As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryRoom"), RequiredFieldValidator)

        dropdownlistSetPCLogistics(sender.Id, ddInventoryOrganization, ddInventoryTower, ddInventoryFloor, ddInventoryHall, ddInventoryRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)

    End Sub

    Protected Function dropdownlistSetPCLogistics(ByVal sender As String, ddInventoryOrganization As DropDownList, ddInventoryTower As DropDownList, ddInventoryFloor As DropDownList, ddInventoryHall As DropDownList, ddInventoryRoom As DropDownList, rfvInventoryTower As RequiredFieldValidator, rfvInventoryFloor As RequiredFieldValidator, rfvInventoryHall As RequiredFieldValidator, rfvInventoryRoom As RequiredFieldValidator) As String

        Select Case sender
            Case "ddInventoryOrganization"
                If ddInventoryOrganization.SelectedIndex > 0 Then
                    LinqPCTower.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Active = True"
                    ddInventoryTower.Items.Clear()
                    ddInventoryTower.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryTower.SelectedIndex = 0
                    ddInventoryTower.DataBind()
                    ddInventoryTower.Enabled = True
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                    rfvInventoryTower.Enabled = True
                    rfvInventoryFloor.Enabled = True
                    rfvInventoryHall.Enabled = True
                    rfvInventoryRoom.Enabled = True
                Else
                    ddInventoryTower.SelectedIndex = 0
                    ddInventoryTower.Enabled = False
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                    rfvInventoryTower.Enabled = False
                    rfvInventoryFloor.Enabled = False
                    rfvInventoryHall.Enabled = False
                    rfvInventoryRoom.Enabled = False
                End If
            Case "ddInventoryTower"
                If ddInventoryTower.SelectedIndex > 0 Then
                    LinqPCFloor.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Active = True"
                    ddInventoryFloor.Items.Clear()
                    ddInventoryFloor.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.DataBind()
                    ddInventoryFloor.Enabled = True
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                Else
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryFloor"
                If ddInventoryFloor.SelectedIndex > 0 Then
                    LinqPCHall.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Floor=" & ddInventoryFloor.SelectedValue & " AND Active = True"
                    ddInventoryHall.Items.Clear()
                    ddInventoryHall.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.DataBind()
                    ddInventoryHall.Enabled = True
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                Else
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryHall"
                If ddInventoryHall.SelectedIndex > 0 Then
                    LinqPCRoom.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Floor=" & ddInventoryFloor.SelectedValue & " AND Hall=" & ddInventoryHall.SelectedValue & " AND Active = True"
                    ddInventoryRoom.Items.Clear()
                    ddInventoryRoom.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.DataBind()
                    ddInventoryRoom.Enabled = True
                Else
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryRoom"
            Case Else
        End Select


        Return True
    End Function

    'Printers
    Protected Function SQLPrinterCommand(ByVal MyCommand As String) As String

        MyCommand += "SELECT pri.Id, pri.Model, pri.TagId, pri.PrinterName, pri.Fax, pri.Notes, pri.UH, pri.UT, pri.Active, "
        MyCommand += "invorg.InventoryOrganization, invtow.InventoryTower, invflo.InventoryFloor, invhal.InventoryHall, invrom.InventoryRoom "

        MyCommand += "From lkpInventoryPrinters AS pri left outer join "
        MyCommand += "tblInventoryPrinters AS inv on inv.PrinterId = pri.Id left outer join "
        MyCommand += "lkpInventoryOrganization AS invorg on invorg.Organization = inv.OrganizationId left outer join "
        MyCommand += "lkpInventoryTower AS invtow on invtow.Organization = inv.OrganizationId AND invtow.Tower = inv.TowerId left outer join "
        MyCommand += "lkpInventoryFloor as invflo on invflo.Organization = inv.OrganizationId AND invflo.Tower = inv.TowerId AND invflo.Floor = inv.FloorId left outer join "
        MyCommand += "lkpInventoryHall as invhal on invhal.Organization = inv.OrganizationId AND invhal.Tower = inv.TowerId AND invhal.Floor = inv.FloorId AND invhal.Hall = inv.HallId left outer join "
        MyCommand += "lkpInventoryRoom as invrom on invrom.Organization = inv.OrganizationId AND invrom.Tower = inv.TowerId AND invrom.Floor = inv.FloorId AND invrom.Hall = inv.HallId AND invrom.Room = inv.RoomId "

        MyCommand += "WHERE pri.Model like '%" & txtSearchPrinters.Text & "%' OR pri.PrinterName like '%" & txtSearchPrinters.Text & "%' "
        MyCommand += "OR pri.TagId like '%" & txtSearchPrinters.Text & "%' OR pri.Notes like '%" & txtSearchPrinters.Text & "%' "
        MyCommand += "OR invorg.InventoryOrganization like '%" & txtSearchPrinters.Text & "%' OR invtow.InventoryTower like '%" & txtSearchPrinters.Text & "%' "
        MyCommand += "OR invflo.InventoryFloor like '%" & txtSearchPrinters.Text & "%' OR invhal.InventoryHall like '%" & txtSearchPrinters.Text & "%' "
        MyCommand += "OR invrom.InventoryRoom like '%" & txtSearchPrinters.Text & "%' OR pri.Fax like '%" & txtSearchPrinters.Text & "%' "

        MyCommand += "Order By pri.Active DESC, inv.EnterDate DESC "

        Return MyCommand

    End Function

    Protected Sub GridViewPrintersInventory_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

                Dim ddOrganization As DropDownList = TryCast(e.Row.FindControl("ddInventoryOrganization"), DropDownList)
                Dim ddTower As DropDownList = TryCast(e.Row.FindControl("ddInventoryTower"), DropDownList)
                Dim ddFloor As DropDownList = TryCast(e.Row.FindControl("ddInventoryFloor"), DropDownList)
                Dim ddHall As DropDownList = TryCast(e.Row.FindControl("ddInventoryHall"), DropDownList)
                Dim ddRoom As DropDownList = TryCast(e.Row.FindControl("ddInventoryRoom"), DropDownList)
                Dim rfvInventoryTower As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryTower"), RequiredFieldValidator)
                Dim rfvInventoryFloor As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryFloor"), RequiredFieldValidator)
                Dim rfvInventoryHall As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryHall"), RequiredFieldValidator)
                Dim rfvInventoryRoom As RequiredFieldValidator = TryCast(e.Row.FindControl("rfvInventoryRoom"), RequiredFieldValidator)

                Dim ED = From p In TPDC.tblInventoryPrinters
                         Where p.PrinterId.Equals(Guid.Parse(TryCast(e.Row.FindControl("lbId"), Label).Text))
                         Select p.OrganizationId, p.TowerId, p.FloorId, p.HallId, p.RoomId

                Try
                    ddOrganization.SelectedValue = ED.First.OrganizationId
                    dropdownlistSetPrinterLogistics("ddInventoryOrganization", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception

                End Try
                Try
                    ddTower.SelectedValue = ED.First.TowerId
                    dropdownlistSetPrinterLogistics("ddInventoryTower", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception

                End Try
                Try
                    ddFloor.SelectedValue = ED.First.FloorId
                    dropdownlistSetPrinterLogistics("ddInventoryFloor", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception
                End Try
                Try
                    ddHall.SelectedValue = ED.First.HallId
                    dropdownlistSetPrinterLogistics("ddInventoryHall", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception
                End Try
                Try
                    ddRoom.SelectedValue = ED.First.RoomId
                    dropdownlistSetPrinterLogistics("ddInventoryRoom", ddOrganization, ddTower, ddFloor, ddHall, ddRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)
                Catch ex As Exception
                End Try

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub GridViewPrintersInventory_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Add" Then

                If Page.IsValid Then

                    Dim INV As New ListDictionary
                    Dim PRI As New ListDictionary
                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                    Dim PrinterId As Guid = Guid.NewGuid
                    INV.Add("Id", PrinterId)
                    If DirectCast(row.FindControl("txtPrinterName"), TextBox).Text <> Nothing Then
                        INV.Add("PrinterName", DirectCast(row.FindControl("txtPrinterName"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtModel"), TextBox).Text <> Nothing Then
                        INV.Add("Model", DirectCast(row.FindControl("txtModel"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtTagId"), TextBox).Text <> Nothing Then
                        INV.Add("TagId", DirectCast(row.FindControl("txtTagId"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtFaxNumber"), TextBox).Text <> Nothing Then
                        INV.Add("Fax", DirectCast(row.FindControl("txtFaxNumber"), TextBox).Text)
                    End If
                    If DirectCast(row.FindControl("txtNotes"), TextBox).Text <> Nothing Then
                        INV.Add("Notes", DirectCast(row.FindControl("txtNotes"), TextBox).Text)
                    End If
                    INV.Add("UH", DirectCast(row.FindControl("cbUH"), CheckBox).Checked)
                    INV.Add("UT", DirectCast(row.FindControl("cbUT"), CheckBox).Checked)
                    INV.Add("Active", "True")
                    INV.Add("EnterBy", hfUser.Value)
                    INV.Add("EnterDate", Now.ToString("G"))

                    PRI.Add("PrinterId", PrinterId)
                    If DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("OrganizationId", DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("TowerId", DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("FloorId", DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("HallId", DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue)
                    End If
                    If DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue <> Nothing Then
                        PRI.Add("RoomId", DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue)
                    End If
                    PRI.Add("EnterBy", hfUser.Value)
                    PRI.Add("EnterDate", Now.ToString("G"))

                    Try
                        LinqPrintersInventory.Insert(INV)
                        INV.Clear()
                        LinqPrintersLocation.Insert(PRI)
                        PRI.Clear()
                        GridViewPrintersInventory.DataBind()
                        SQLPrinters.SelectCommand = Me.ViewState("SQLPrinters")
                        lbPrintersMessage.Text = "Printer has been added! </br>"
                        lbPrintersMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbPrintersMessage.Text = "Your Record was Not Saved! </br>"
                        lbPrintersMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "UpdatePrinter" Then

                If Page.IsValid Then

                    Try
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                        Dim UP = (From p In TPDC.lkpInventoryPrinters
                                  Where p.Id.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)

                        If DirectCast(row.FindControl("txtPrinterName"), TextBox).Text <> Nothing Then
                            UP.PrinterName = DirectCast(row.FindControl("txtPrinterName"), TextBox).Text
                        Else
                            UP.PrinterName = Nothing
                        End If

                        If DirectCast(row.FindControl("txtModel"), TextBox).Text <> Nothing Then
                            UP.Model = DirectCast(row.FindControl("txtModel"), TextBox).Text
                        Else
                            UP.Model = Nothing
                        End If

                        If DirectCast(row.FindControl("txtTagId"), TextBox).Text <> Nothing Then
                            UP.TagId = DirectCast(row.FindControl("txtTagId"), TextBox).Text
                        Else
                            UP.TagId = Nothing
                        End If

                        If DirectCast(row.FindControl("txtFaxNumber"), TextBox).Text <> Nothing Then
                            UP.Fax = DirectCast(row.FindControl("txtFaxNumber"), TextBox).Text
                        Else
                            UP.Fax = Nothing
                        End If

                        If DirectCast(row.FindControl("txtNotes"), TextBox).Text <> Nothing Then
                            UP.Notes = DirectCast(row.FindControl("txtNotes"), TextBox).Text
                        Else
                            UP.Notes = Nothing
                        End If

                        UP.UH = DirectCast(row.FindControl("cbUH"), CheckBox).Checked
                        UP.UT = DirectCast(row.FindControl("cbUT"), CheckBox).Checked
                        UP.Active = DirectCast(row.FindControl("cbActive"), CheckBox).Checked
                        UP.ModifyBy = hfUser.Value
                        UP.ModifyDate = Now.ToString("G")

                        Dim UPII = (From p In TPDC.tblInventoryPrinters
                                    Where p.PrinterId.Equals(Guid.Parse(DirectCast(row.FindControl("lbId"), Label).Text))).ToList()(0)

                        If DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue <> Nothing Then
                            UPII.OrganizationId = DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue
                        Else
                            UPII.OrganizationId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue <> Nothing Then
                            UPII.TowerId = DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue
                        Else
                            UPII.TowerId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue <> Nothing Then
                            UPII.FloorId = DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue
                        Else
                            UPII.FloorId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue <> Nothing Then
                            UPII.HallId = DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue
                        Else
                            UPII.HallId = Nothing
                        End If
                        If DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue <> Nothing Then
                            UPII.RoomId = DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue
                        Else
                            UPII.RoomId = Nothing
                        End If
                        UPII.ModifyBy = hfUser.Value
                        UPII.ModifyDate = Now.ToString("G")

                        TPDC.SubmitChanges()

                        GridViewPrintersInventory.EditIndex = -1
                        SQLPrinters.SelectCommand = Me.ViewState("SQLPrinters")
                        GridViewPrintersInventory.DataBind()
                        lbPrintersMessage.Text = "Record has been updated! </br>"
                        lbPrintersMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbPrintersMessage.Text = "Record could not be updated! </br>"
                        lbPrintersMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "Edit" Then

                SQLPrinters.SelectCommand = Me.ViewState("SQLPrinters")
                GridViewPrintersInventory.DataBind()

            ElseIf e.CommandName = "Cancel" Then

                SQLPrinters.SelectCommand = Me.ViewState("SQLPrinters")
                GridViewPrintersInventory.DataBind()

            ElseIf e.CommandName = "DeletePrinter" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                Try
                    Dim Delete = From p In TPDC.tblInventoryPrinters
                                 Where p.PrinterId.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                 Select p

                    For Each p In Delete
                        TPDC.tblInventoryPrinters.DeleteOnSubmit(p)
                    Next

                    Dim DeleteII = From a In TPDC.lkpInventoryPrinters
                                   Where a.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                   Select a

                    For Each a In DeleteII
                        TPDC.lkpInventoryPrinters.DeleteOnSubmit(a)
                    Next

                    TPDC.SubmitChanges()
                    SQLPrinters.SelectCommand = Me.ViewState("SQLPrinters")
                    GridViewPrintersInventory.DataBind()
                    lbPrintersMessage.Text = "Record has been deleted! </br>"
                    lbPrintersMessage.ForeColor = Drawing.Color.Green
                Catch ex As Exception

                End Try

            End If

        End With

    End Sub

    Protected Sub PrintersInventorySort(ByVal Sender As Object, ByVal e As EventArgs)

        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkPrinterName"
                sortDirection = If(Me.ViewState("PrinterName") Is Nothing, "ASC", If(Me.ViewState("PrinterName") = "ASC", "DESC", "ASC"))
                Me.ViewState("PrinterName") = sortDirection
                sortExpression = "pri.PrinterName"
            Case "linkModel"
                sortDirection = If(Me.ViewState("Model") Is Nothing, "ASC", If(Me.ViewState("Model") = "ASC", "DESC", "ASC"))
                Me.ViewState("Model") = sortDirection
                sortExpression = "pri.Model"
            Case "linkTagId"
                sortDirection = If(Me.ViewState("TagId") Is Nothing, "ASC", If(Me.ViewState("TagId") = "ASC", "DESC", "ASC"))
                Me.ViewState("TagId") = sortDirection
                sortExpression = "pri.TagId"
            Case "linkFaxNumber"
                sortDirection = If(Me.ViewState("Fax") Is Nothing, "ASC", If(Me.ViewState("Fax") = "ASC", "DESC", "ASC"))
                Me.ViewState("Fax") = sortDirection
                sortExpression = "pri.Fax"
            Case "linkNotes"
                sortDirection = If(Me.ViewState("Notes") Is Nothing, "ASC", If(Me.ViewState("Notes") = "ASC", "DESC", "ASC"))
                Me.ViewState("Notes") = sortDirection
                sortExpression = "pri.Notes"
            Case "linkUH"
                sortDirection = If(Me.ViewState("UH") Is Nothing, "ASC", If(Me.ViewState("UH") = "ASC", "DESC", "ASC"))
                Me.ViewState("UH") = sortDirection
                sortExpression = "pri.UH"
            Case "linkUT"
                sortDirection = If(Me.ViewState("UT") Is Nothing, "ASC", If(Me.ViewState("UT") = "ASC", "DESC", "ASC"))
                Me.ViewState("UT") = sortDirection
                sortExpression = "pri.UT"
            Case "linkActive"
                sortDirection = If(Me.ViewState("Active") Is Nothing, "ASC", If(Me.ViewState("Active") = "ASC", "DESC", "ASC"))
                Me.ViewState("Active") = sortDirection
                sortExpression = "pri.Active"
            Case "linkInventoryOrganization"
                sortDirection = If(Me.ViewState("Organization") Is Nothing, "ASC", If(Me.ViewState("Organization") = "ASC", "DESC", "ASC"))
                Me.ViewState("Organization") = sortDirection
                sortExpression = "invorg.InventoryOrganization"
            Case "linkInventoryTower"
                sortDirection = If(Me.ViewState("Tower") Is Nothing, "ASC", If(Me.ViewState("Tower") = "ASC", "DESC", "ASC"))
                Me.ViewState("Tower") = sortDirection
                sortExpression = "invtow.InventoryTower"
            Case "linkInventoryFloor"
                sortDirection = If(Me.ViewState("Floor") Is Nothing, "ASC", If(Me.ViewState("Floor") = "ASC", "DESC", "ASC"))
                Me.ViewState("Floor") = sortDirection
                sortExpression = "invflo.InventoryFloor"
            Case "linkInventoryHall"
                sortDirection = If(Me.ViewState("Hall") Is Nothing, "ASC", If(Me.ViewState("Hall") = "ASC", "DESC", "ASC"))
                Me.ViewState("Hall") = sortDirection
                sortExpression = "invhal.InventoryHall"
            Case "linkInventoryRoom"
                sortDirection = If(Me.ViewState("Room") Is Nothing, "ASC", If(Me.ViewState("Room") = "ASC", "DESC", "ASC"))
                Me.ViewState("Room") = sortDirection
                sortExpression = "invrom.InventoryRoom"
            Case Else
                Return
        End Select

        SqlPrinters.SelectCommand = SQLPrinterCommand(Nothing).Replace("inv.EnterDate DESC ", sortExpression) & " " & sortDirection
        Me.ViewState("SQLPrinters") = SQLPrinters.SelectCommand
        GridViewPrintersInventory.DataBind()

    End Sub

    Protected Sub SearchPrinters_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            SQLPrinters.SelectCommand = SQLPrinterCommand(Nothing)
            Me.ViewState("SQLPrinters") = SQLPrinters.SelectCommand
            GridViewPrintersInventory.DataBind()

        End If

    End Sub

    Protected Sub dropdownlistPrinterLocation_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ddInventoryOrganization As DropDownList = CType(GridViewPrintersInventory.HeaderRow.FindControl("ddInventoryOrganization"), DropDownList)
        Dim ddInventoryTower As DropDownList = CType(GridViewPrintersInventory.HeaderRow.FindControl("ddInventoryTower"), DropDownList)
        Dim ddInventoryFloor As DropDownList = CType(GridViewPrintersInventory.HeaderRow.FindControl("ddInventoryFloor"), DropDownList)
        Dim ddInventoryHall As DropDownList = CType(GridViewPrintersInventory.HeaderRow.FindControl("ddInventoryHall"), DropDownList)
        Dim ddInventoryRoom As DropDownList = CType(GridViewPrintersInventory.HeaderRow.FindControl("ddInventoryRoom"), DropDownList)
        Dim rfvInventoryTower As RequiredFieldValidator = CType(GridViewPrintersInventory.HeaderRow.FindControl("rfvInventoryTower"), RequiredFieldValidator)
        Dim rfvInventoryFloor As RequiredFieldValidator = CType(GridViewPrintersInventory.HeaderRow.FindControl("rfvInventoryFloor"), RequiredFieldValidator)
        Dim rfvInventoryHall As RequiredFieldValidator = CType(GridViewPrintersInventory.HeaderRow.FindControl("rfvInventoryHall"), RequiredFieldValidator)
        Dim rfvInventoryRoom As RequiredFieldValidator = CType(GridViewPrintersInventory.HeaderRow.FindControl("rfvInventoryRoom"), RequiredFieldValidator)

        dropdownlistSetPrinterLogistics(sender.Id, ddInventoryOrganization, ddInventoryTower, ddInventoryFloor, ddInventoryHall, ddInventoryRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)

    End Sub

    Protected Sub dropdownlistPrinterLocationEdit_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ddType As DropDownList = DirectCast(sender, DropDownList)
        Dim rowType As GridViewRow = DirectCast(ddType.NamingContainer, GridViewRow)
        Dim ddInventoryOrganization As DropDownList = CType(rowType.FindControl("ddInventoryOrganization"), DropDownList)
        Dim ddInventoryTower As DropDownList = CType(rowType.FindControl("ddInventoryTower"), DropDownList)
        Dim ddInventoryFloor As DropDownList = CType(rowType.FindControl("ddInventoryFloor"), DropDownList)
        Dim ddInventoryHall As DropDownList = CType(rowType.FindControl("ddInventoryHall"), DropDownList)
        Dim ddInventoryRoom As DropDownList = CType(rowType.FindControl("ddInventoryRoom"), DropDownList)
        Dim rfvInventoryTower As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryTower"), RequiredFieldValidator)
        Dim rfvInventoryFloor As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryFloor"), RequiredFieldValidator)
        Dim rfvInventoryHall As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryHall"), RequiredFieldValidator)
        Dim rfvInventoryRoom As RequiredFieldValidator = CType(rowType.FindControl("rfvInventoryRoom"), RequiredFieldValidator)

        dropdownlistSetPrinterLogistics(sender.Id, ddInventoryOrganization, ddInventoryTower, ddInventoryFloor, ddInventoryHall, ddInventoryRoom, rfvInventoryTower, rfvInventoryFloor, rfvInventoryHall, rfvInventoryRoom)

    End Sub

    Protected Function dropdownlistSetPrinterLogistics(ByVal sender As String, ddInventoryOrganization As DropDownList, ddInventoryTower As DropDownList, ddInventoryFloor As DropDownList, ddInventoryHall As DropDownList, ddInventoryRoom As DropDownList, rfvInventoryTower As RequiredFieldValidator, rfvInventoryFloor As RequiredFieldValidator, rfvInventoryHall As RequiredFieldValidator, rfvInventoryRoom As RequiredFieldValidator) As String

        Select Case sender
            Case "ddInventoryOrganization"
                If ddInventoryOrganization.SelectedIndex > 0 Then
                    LinqPrinterTower.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Active = True"
                    ddInventoryTower.Items.Clear()
                    ddInventoryTower.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryTower.SelectedIndex = 0
                    ddInventoryTower.DataBind()
                    ddInventoryTower.Enabled = True
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                    rfvInventoryTower.Enabled = True
                    rfvInventoryFloor.Enabled = True
                    rfvInventoryHall.Enabled = True
                    rfvInventoryRoom.Enabled = True
                Else
                    ddInventoryTower.SelectedIndex = 0
                    ddInventoryTower.Enabled = False
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                    rfvInventoryTower.Enabled = False
                    rfvInventoryFloor.Enabled = False
                    rfvInventoryHall.Enabled = False
                    rfvInventoryRoom.Enabled = False
                End If
            Case "ddInventoryTower"
                If ddInventoryTower.SelectedIndex > 0 Then
                    LinqPrinterFloor.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Active = True"
                    ddInventoryFloor.Items.Clear()
                    ddInventoryFloor.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.DataBind()
                    ddInventoryFloor.Enabled = True
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                Else
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryFloor"
                If ddInventoryFloor.SelectedIndex > 0 Then
                    LinqPrinterHall.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Floor=" & ddInventoryFloor.SelectedValue & " AND Active = True"
                    ddInventoryHall.Items.Clear()
                    ddInventoryHall.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.DataBind()
                    ddInventoryHall.Enabled = True
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                Else
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryHall"
                If ddInventoryHall.SelectedIndex > 0 Then
                    LinqPrinterRoom.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Floor=" & ddInventoryFloor.SelectedValue & " AND Hall=" & ddInventoryHall.SelectedValue & " AND Active = True"
                    ddInventoryRoom.Items.Clear()
                    ddInventoryRoom.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.DataBind()
                    ddInventoryRoom.Enabled = True
                Else
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryRoom"
            Case Else
        End Select


        Return True
    End Function

    'Overview
    Protected Function SQLOverviewCommand(ByVal MyCommand As String) As String

        MyCommand += "SELECT Org.InventoryOrganization, Org.Organization, Tow.InventoryTower, Tow.Tower, Flo.InventoryFloor, Flo.Floor, Hall.InventoryHall, Hall.Hall, Roo.InventoryRoom, Roo.Room, "

        MyCommand += "(STUFF((SELECT ',<br />' + pri.PrinterName "
        MyCommand += "FROM tblInventoryPrinters as inprinter "
        MyCommand += "left outer join lkpInventoryPrinters as pri on pri.Id = inprinter.Printerid "
        MyCommand += "WHERE inprinter.OrganizationId = roo.Organization AND inprinter.TowerId = Roo.Tower AND "
        MyCommand += "inprinter.FloorId = Roo.Floor AND inprinter.HallId = Roo.Hall AND inprinter.RoomId = Roo.Room "
        MyCommand += "For XML Path, Type).value('.','nvarchar(max)'), 1, 7, '')) As Printers, "

        MyCommand += "(STUFF((SELECT ',<br />' + pri.PCName + ISNULL(NULLIF('(' + sta.FName + ' ' + sta.LName + ')', ''), '') "
        MyCommand += "FROM tblInventoryPCs as inPC "
        MyCommand += "left outer join lkpInventoryPCs as pri on pri.Id = inPC.PCId "
        MyCommand += "left outer join tblInventoryUsers as us on us.PCId = pri.Id "
        MyCommand += "left outer join tblStaff as sta on sta.UserId = us.UserId "
        MyCommand += "WHERE inPC.OrganizationId = roo.Organization AND inPC.TowerId = Roo.Tower AND "
        MyCommand += "inPC.FloorId = Roo.Floor AND inPC.HallId = Roo.Hall AND inPC.RoomId = Roo.Room "
        MyCommand += "For XML Path, Type).value('.','nvarchar(max)'), 1, 7, '')) As PCs, "

        MyCommand += "(STUFF((SELECT ',<br />' + ISNULL(NULLIF(sta.FName + ' ' + sta.LName, ''), '') + "
        MyCommand += "ISNULL('(' + NULLIF((STUFF((SELECT ', ' + ISNULL(NULLIF(la.Description, ''), '') "
        MyCommand += "+ ISNULL(NULLIF(ho.Description, ''), '') "
        MyCommand += "+ ISNULL(NULLIF(mi.Description, ''), '') "
        MyCommand += "FROM tblInventoryCheckOut as co "
        MyCommand += "left outer join lkpInventoryLaptops as la on la.id = co.LaptopId "
        MyCommand += "left outer join lkpInventoryHotspots as ho on ho.id = co.HotspotId "
        MyCommand += "left outer join lkpInventoryMiscellaneous as mi on mi.id = co.MiscellaneousId "
        MyCommand += "WHERE co.StaffId = sta.UserId "
        MyCommand += "For XML Path('')), 1, 2, '')), '') + ')', '') "
        MyCommand += "FROM tblStaffOffice as offi "
        MyCommand += "left outer join tblStaff as sta on sta.UserId = offi.UserId "
        MyCommand += "WHERE offi.StaffOrganization = roo.Organization AND offi.StaffTower = Roo.Tower AND "
        MyCommand += "offi.StaffFloor = Roo.Floor AND offi.StaffHall = Roo.Hall AND offi.StaffRoom = Roo.Room "
        MyCommand += "For XML Path, Type).value('.','nvarchar(max)'), 1, 7, '')) As Staff "

        MyCommand += "FROM lkpInventoryOrganization as Org "
        MyCommand += "LEFT OUTER JOIN lkpInventoryTower as Tow on Org.Organization = Tow.Organization "
        MyCommand += "LEFT OUTER JOIN lkpInventoryFloor as Flo on Org.Organization = Flo.Organization AND Tow.Tower = Flo.Tower "
        MyCommand += "LEFT OUTER JOIN lkpInventoryHall as Hall on Org.Organization = Hall.Organization AND Tow.Tower = Hall.Tower AND Flo.Floor = Hall.Floor "
        MyCommand += "LEFT OUTER JOIN lkpInventoryRoom as Roo on Org.Organization = Roo.Organization AND Tow.Tower = Roo.Tower AND Flo.Floor = Roo.Floor AND Hall.Hall = Roo.Hall "

        MyCommand += "OUTER APPLY "
        MyCommand += "(SELECT TOP 1 pri.PrinterName FROM tblInventoryPrinters as inprinter "
        MyCommand += "LEFT OUTER JOIN lkpInventoryPrinters as pri on pri.id = inprinter.PrinterId "
        MyCommand += "WHERE pri.PrinterName like '%" & txtSearchOverview.Text & "%' AND inprinter.OrganizationId = org.Organization AND "
        MyCommand += "inprinter.TowerId = tow.Tower AND inprinter.FloorId = Flo.Floor AND inprinter.HallId = Hall.Hall AND inprinter.RoomId = Roo.Room) As OAPrinter "

        MyCommand += "OUTER APPLY "
        MyCommand += "(SELECT TOP 1 pri.PCName FROM tblInventoryPCs as inPC "
        MyCommand += "LEFT OUTER JOIN lkpInventoryPCs as pri on pri.id = inPC.PCId "
        MyCommand += "WHERE pri.PCName like '%" & txtSearchOverview.Text & "%' AND inPC.OrganizationId = org.Organization AND "
        MyCommand += "inPC.TowerId = tow.Tower AND inPC.FloorId = Flo.Floor AND inPC.HallId = Hall.Hall AND inPC.RoomId = Roo.Room) As OAPC "

        MyCommand += "WHERE Org.InventoryOrganization <> '' "

        MyCommand += "Order By Org.InventoryOrganization, Tow.InventoryTower, Flo.Floor, Hall.InventoryHall, Roo.InventoryRoom "

        Return MyCommand

    End Function

    Protected Sub GridViewOverview_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

                Dim lbOrganization As Label = TryCast(e.Row.FindControl("lbOrganization"), Label)
                Dim lbTower As Label = TryCast(e.Row.FindControl("lbTower"), Label)
                Dim lbFloor As Label = TryCast(e.Row.FindControl("lbFloor"), Label)
                Dim lbHall As Label = TryCast(e.Row.FindControl("lbHall"), Label)
                Dim lbRoom As Label = TryCast(e.Row.FindControl("lbRoom"), Label)
                Dim Mysql As String = Nothing

                Try
                    'Databinding the Printers Gridview
                    Mysql = "SELECT pri.PrinterName "
                    Mysql += "FROM tblInventoryPrinters as inprinter "
                    Mysql += "LEFT OUTER JOIN lkpInventoryPrinters as pri on pri.Id = inprinter.Printerid "
                    Mysql += "WHERE "

                    If lbOrganization.Text <> Nothing Then
                        Mysql += "inprinter.OrganizationId = " & lbOrganization.Text & " "
                    End If
                    If lbTower.Text <> Nothing Then
                        Mysql += "And inprinter.TowerId = " & lbTower.Text & " "
                    End If
                    If lbFloor.Text <> Nothing Then
                        Mysql += "And inprinter.FloorId = " & lbFloor.Text & " "
                    End If
                    If lbHall.Text <> Nothing Then
                        Mysql += "And inprinter.HallId = " & lbHall.Text & " "
                    End If
                    If lbRoom.Text <> Nothing Then
                        Mysql += "And inprinter.RoomId = " & lbRoom.Text & " "
                    End If


                    Dim GridViewOverviewPrinters As GridView = TryCast(e.Row.FindControl("GridViewOverviewPrinters"), GridView)
                    If e.Row.RowState = DataControlRowState.Alternate Then
                        GridViewOverviewPrinters.RowStyle.BackColor = GridViewOverview.AlternatingRowStyle.BackColor
                    Else
                        GridViewOverviewPrinters.RowStyle.BackColor = GridViewOverview.RowStyle.BackColor
                    End If

                    Dim SqlOverviewPrinters As SqlDataSource = TryCast(e.Row.FindControl("SqlOverviewPrinters"), SqlDataSource)
                    SqlOverviewPrinters.SelectCommand = Mysql
                    GridViewOverviewPrinters.DataBind()

                Catch ex As Exception

                End Try

                Try
                    'Databinding the PCs Gridview
                    Mysql = "SELECT (PC.PCName + ISNULL(NULLIF('(' + sta.FName + ' ' + sta.LName + ')', ''), '')) AS PCName "
                    Mysql += "FROM tblInventoryPCs as inPC "
                    Mysql += "LEFT OUTER JOIN lkpInventoryPCs as PC on PC.Id = inPC.PCid "
                    Mysql += "LEFT OUTER JOIN tblInventoryUsers as us on us.PCId = PC.Id "
                    Mysql += "LEFT OUTER JOIN tblStaff as sta on sta.UserId = us.UserId "
                    Mysql += "WHERE "

                    If lbOrganization.Text <> Nothing Then
                        Mysql += "inPC.OrganizationId = " & lbOrganization.Text & " "
                    End If
                    If lbTower.Text <> Nothing Then
                        Mysql += "And inPC.TowerId = " & lbTower.Text & " "
                    End If
                    If lbFloor.Text <> Nothing Then
                        Mysql += "And inPC.FloorId = " & lbFloor.Text & " "
                    End If
                    If lbHall.Text <> Nothing Then
                        Mysql += "And inPC.HallId = " & lbHall.Text & " "
                    End If
                    If lbRoom.Text <> Nothing Then
                        Mysql += "And inPC.RoomId = " & lbRoom.Text & " "
                    End If

                    Dim GridViewOverviewPCs As GridView = TryCast(e.Row.FindControl("GridViewOverviewPCs"), GridView)
                    If e.Row.RowState = DataControlRowState.Alternate Then
                        GridViewOverviewPCs.RowStyle.BackColor = GridViewOverview.AlternatingRowStyle.BackColor
                    Else
                        GridViewOverviewPCs.RowStyle.BackColor = GridViewOverview.RowStyle.BackColor
                    End If

                    Dim SqlOverviewPCs As SqlDataSource = TryCast(e.Row.FindControl("SqlOverviewPCs"), SqlDataSource)
                    SqlOverviewPCs.SelectCommand = Mysql
                    GridViewOverviewPCs.DataBind()

                Catch ex As Exception

                End Try

                Try
                    'Databinding the Staff Gridview
                    Mysql = "SELECT ISNULL(NULLIF(sta.FName + ' ' + sta.LName, ''), '') + "
                    Mysql += "ISNULL('(' + NullIf((STUFF((SELECT ', ' + ISNULL(NULLIF(la.Description, ''), '') + "
                    Mysql += "ISNULL(NULLIF(ho.Description, ''), '') + "
                    Mysql += "ISNULL(NULLIF(mi.Description, ''), '') "
                    Mysql += "FROM tblInventoryCheckOut as co "
                    Mysql += "left outer join lkpInventoryLaptops as la on la.id = co.LaptopId "
                    Mysql += "left outer join lkpInventoryHotspots as ho on ho.id = co.HotspotId "
                    Mysql += "left outer join lkpInventoryMiscellaneous as mi on mi.id = co.MiscellaneousId "
                    Mysql += "WHERE co.StaffId = sta.UserId "
                    Mysql += "For XML Path('')), 1, 2, '')), '') + ')', '') AS StaffName, "
                    Mysql += "sta.UserId As StaffUserId "
                    Mysql += "FROM tblStaffOffice as offi "
                    Mysql += "left outer join tblStaff as sta on sta.UserId = offi.UserId "
                    Mysql += "WHERE "

                    If lbOrganization.Text <> Nothing Then
                        Mysql += "offi.StaffOrganization = " & lbOrganization.Text & " "
                    End If
                    If lbTower.Text <> Nothing Then
                        Mysql += "And offi.StaffTower = " & lbTower.Text & " "
                    End If
                    If lbFloor.Text <> Nothing Then
                        Mysql += "And offi.StaffFloor = " & lbFloor.Text & " "
                    End If
                    If lbHall.Text <> Nothing Then
                        Mysql += "And offi.StaffHall = " & lbHall.Text & " "
                    End If
                    If lbRoom.Text <> Nothing Then
                        Mysql += "And offi.StaffRoom = " & lbRoom.Text & " "
                    End If

                    Dim GridViewOverviewStaff As GridView = TryCast(e.Row.FindControl("GridViewOverviewStaff"), GridView)
                    If e.Row.RowState = DataControlRowState.Alternate Then
                        GridViewOverviewStaff.RowStyle.BackColor = GridViewOverview.AlternatingRowStyle.BackColor
                    Else
                        GridViewOverviewStaff.RowStyle.BackColor = GridViewOverview.RowStyle.BackColor
                    End If

                    Dim SqlOverviewStaff As SqlDataSource = TryCast(e.Row.FindControl("SqlOverviewStaff"), SqlDataSource)
                    SqlOverviewStaff.SelectCommand = Mysql
                    GridViewOverviewStaff.DataBind()

                Catch ex As Exception

                End Try

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub GridViewOverview_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "View" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                If DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue <> Nothing Then

                    txtSearchOverview.Text = Nothing

                    SqlOverview.SelectCommand = SQLOverviewCommand(Nothing).Replace("WHERE Org.InventoryOrganization <> '' ", "WHERE Org.Organization = " & DirectCast(row.FindControl("ddInventoryOrganization"), DropDownList).SelectedValue & " [!]")

                    If DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue <> Nothing Then
                        SqlOverview.SelectCommand = SqlOverview.SelectCommand.Replace("[!]", "AND Tow.Tower = " & DirectCast(row.FindControl("ddInventoryTower"), DropDownList).SelectedValue & " [!]")
                    End If

                    If DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue <> Nothing Then
                        SqlOverview.SelectCommand = SqlOverview.SelectCommand.Replace("[!]", "AND Flo.Floor = " & DirectCast(row.FindControl("ddInventoryFloor"), DropDownList).SelectedValue & " [!]")
                    End If

                    If DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue <> Nothing Then
                        SqlOverview.SelectCommand = SqlOverview.SelectCommand.Replace("[!]", "AND Hall.Hall = " & DirectCast(row.FindControl("ddInventoryHall"), DropDownList).SelectedValue & " [!]")
                    End If

                    If DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue <> Nothing Then
                        SqlOverview.SelectCommand = SqlOverview.SelectCommand.Replace("[!]", "AND Roo.Room = " & DirectCast(row.FindControl("ddInventoryRoom"), DropDownList).SelectedValue & " ")
                    End If

                    SqlOverview.SelectCommand = SqlOverview.SelectCommand.Replace("[!]", "")

                Else

                    SqlOverview.SelectCommand = SQLOverviewCommand(Nothing)

                End If

                Me.ViewState("SQLOverview") = SqlOverview.SelectCommand
                GridViewOverview.DataBind()

            End If

        End With

    End Sub

    Protected Sub SearchOverview_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            Dim MyCommand As String
            MyCommand = "WHERE Org.InventoryOrganization like '%" & txtSearchOverview.Text & "%' "
            MyCommand += "OR Tow.InventoryTower like '%" & txtSearchOverview.Text & "%' "
            MyCommand += "OR Flo.InventoryFloor like '%" & txtSearchOverview.Text & "%' "
            MyCommand += "OR Hall.InventoryHall like '%" & txtSearchOverview.Text & "%' "
            MyCommand += "OR Roo.InventoryRoom like '%" & txtSearchOverview.Text & "%' "
            MyCommand += "OR "
            MyCommand += "OAPrinter.PrinterName like '%" & txtSearchOverview.Text & "%' "
            MyCommand += "OR "
            MyCommand += "OAPC.PCName like '%" & txtSearchOverview.Text & "%' "
            MyCommand += "OR "
            MyCommand += "(STUFF((SELECT ',<br />' + ISNULL(NULLIF(sta.FName + ' ' + sta.LName, ''), '') + "
            MyCommand += "ISNULL('(' + NULLIF((STUFF((SELECT ', ' + ISNULL(NULLIF(la.Description, ''), '') "
            MyCommand += "+ ISNULL(NULLIF(ho.Description, ''), '') "
            MyCommand += "+ ISNULL(NULLIF(mi.Description, ''), '') "
            MyCommand += "FROM tblInventoryCheckOut as co "
            MyCommand += "left outer join lkpInventoryLaptops as la on la.id = co.LaptopId "
            MyCommand += "left outer join lkpInventoryHotspots as ho on ho.id = co.HotspotId "
            MyCommand += "left outer join lkpInventoryMiscellaneous as mi on mi.id = co.MiscellaneousId "
            MyCommand += "WHERE co.StaffId = sta.UserId "
            MyCommand += "For XML Path('')), 1, 2, '')), '') + ')', '') "
            MyCommand += "FROM tblStaffOffice as offi "
            MyCommand += "left outer join tblStaff as sta on sta.UserId = offi.UserId "
            MyCommand += "WHERE offi.StaffOrganization = roo.Organization AND offi.StaffTower = Roo.Tower AND "
            MyCommand += "offi.StaffFloor = Roo.Floor AND offi.StaffHall = Roo.Hall AND offi.StaffRoom = Roo.Room "
            MyCommand += "For XML Path, Type).value('.','nvarchar(max)'), 1, 7, '')) "
            MyCommand += "like '%" & txtSearchOverview.Text & "%' "

            SqlOverview.SelectCommand = SQLOverviewCommand(Nothing).Replace("WHERE Org.InventoryOrganization <> ''", MyCommand)
            Me.ViewState("SQLOverview") = SqlOverview.SelectCommand
            GridViewOverview.DataBind()

        End If

    End Sub

    Protected Sub dropdownlistOverviewLocation_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ddInventoryOrganization As DropDownList = CType(GridViewOverview.HeaderRow.FindControl("ddInventoryOrganization"), DropDownList)
        Dim ddInventoryTower As DropDownList = CType(GridViewOverview.HeaderRow.FindControl("ddInventoryTower"), DropDownList)
        Dim ddInventoryFloor As DropDownList = CType(GridViewOverview.HeaderRow.FindControl("ddInventoryFloor"), DropDownList)
        Dim ddInventoryHall As DropDownList = CType(GridViewOverview.HeaderRow.FindControl("ddInventoryHall"), DropDownList)
        Dim ddInventoryRoom As DropDownList = CType(GridViewOverview.HeaderRow.FindControl("ddInventoryRoom"), DropDownList)

        dropdownlistSetOverviewLogistics(sender.Id, ddInventoryOrganization, ddInventoryTower, ddInventoryFloor, ddInventoryHall, ddInventoryRoom)

    End Sub

    Protected Function dropdownlistSetOverviewLogistics(ByVal sender As String, ddInventoryOrganization As DropDownList, ddInventoryTower As DropDownList, ddInventoryFloor As DropDownList, ddInventoryHall As DropDownList, ddInventoryRoom As DropDownList) As String

        Select Case sender
            Case "ddInventoryOrganization"
                If ddInventoryOrganization.SelectedIndex > 0 Then
                    LinqOverviewTower.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Active = True"
                    ddInventoryTower.Items.Clear()
                    ddInventoryTower.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryTower.SelectedIndex = 0
                    ddInventoryTower.DataBind()
                    ddInventoryTower.Enabled = True
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                Else
                    ddInventoryTower.SelectedIndex = 0
                    ddInventoryTower.Enabled = False
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryTower"
                If ddInventoryTower.SelectedIndex > 0 Then
                    LinqOverviewFloor.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Active = True"
                    ddInventoryFloor.Items.Clear()
                    ddInventoryFloor.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.DataBind()
                    ddInventoryFloor.Enabled = True
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                Else
                    ddInventoryFloor.SelectedIndex = 0
                    ddInventoryFloor.Enabled = False
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryFloor"
                If ddInventoryFloor.SelectedIndex > 0 Then
                    LinqOverviewHall.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Floor=" & ddInventoryFloor.SelectedValue & " AND Active = True"
                    ddInventoryHall.Items.Clear()
                    ddInventoryHall.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.DataBind()
                    ddInventoryHall.Enabled = True
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                Else
                    ddInventoryHall.SelectedIndex = 0
                    ddInventoryHall.Enabled = False
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryHall"
                If ddInventoryHall.SelectedIndex > 0 Then
                    LinqOverviewRoom.Where = "Organization=" & ddInventoryOrganization.SelectedValue & " AND Tower=" & ddInventoryTower.SelectedValue & " AND Floor=" & ddInventoryFloor.SelectedValue & " AND Hall=" & ddInventoryHall.SelectedValue & " AND Active = True"
                    ddInventoryRoom.Items.Clear()
                    ddInventoryRoom.Items.Insert(0, New ListItem(String.Empty, String.Empty))
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.DataBind()
                    ddInventoryRoom.Enabled = True
                Else
                    ddInventoryRoom.SelectedIndex = 0
                    ddInventoryRoom.Enabled = False
                End If
            Case "ddInventoryRoom"
            Case Else
        End Select


        Return True
    End Function

    Protected Sub OverviewInventorySort(ByVal Sender As Object, ByVal e As EventArgs)

        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id

            Case "linkInventoryOrganization"
                sortDirection = If(Me.ViewState("Organization") Is Nothing, "ASC", If(Me.ViewState("Organization") = "ASC", "DESC", "ASC"))
                Me.ViewState("Organization") = sortDirection
                sortExpression = "Org.InventoryOrganization"
            Case "linkInventoryTower"
                sortDirection = If(Me.ViewState("Tower") Is Nothing, "ASC", If(Me.ViewState("Tower") = "ASC", "DESC", "ASC"))
                Me.ViewState("Tower") = sortDirection
                sortExpression = "Tow.InventoryTower"
            Case "linkInventoryFloor"
                sortDirection = If(Me.ViewState("Floor") Is Nothing, "ASC", If(Me.ViewState("Floor") = "ASC", "DESC", "ASC"))
                Me.ViewState("Floor") = sortDirection
                sortExpression = "Flo.InventoryFloor"
            Case "linkInventoryHall"
                sortDirection = If(Me.ViewState("Hall") Is Nothing, "ASC", If(Me.ViewState("Hall") = "ASC", "DESC", "ASC"))
                Me.ViewState("Hall") = sortDirection
                sortExpression = "Hall.InventoryHall"
            Case "linkInventoryRoom"
                sortDirection = If(Me.ViewState("Room") Is Nothing, "ASC", If(Me.ViewState("Room") = "ASC", "DESC", "ASC"))
                Me.ViewState("Room") = sortDirection
                sortExpression = "Roo.InventoryRoom"
            Case Else
                Return
        End Select

        SqlOverview.SelectCommand = SQLOverviewCommand(Nothing).Replace("Order By Org.InventoryOrganization, Tow.InventoryTower, Flo.Floor, Hall.InventoryHall, Roo.InventoryRoom", "Order By " & sortExpression) & " " & sortDirection
        Me.ViewState("SQLOverview") = SqlOverview.SelectCommand
        GridViewOverview.DataBind()

    End Sub

    Protected Sub GridviewOverviewStaff_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Staff" Then

                'Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                'ScriptManager.RegisterStartupScript(Me, [GetType](), "Users", "window.open('~/Pages/UserFrame.aspx?U=" & DirectCast(row.FindControl("lbStaffUserId"), Label).Text & "&F=" & hfFrom.Value & "','Users','height=980,width=1040,status=no,resizable=yes,scrollbars=yes,toolbar=no,location=no,menubar=no');", True)

            End If

        End With

    End Sub

    Protected Sub OverviewLinkButton_Click(ByVal Sender As Object, ByVal e As EventArgs)

        Select Case Sender.Id
            Case "linkPrinters"
                TabContainerInventory.ActiveTabIndex = 5
                txtSearchPrinters.Text = Sender.Text
                SearchPrinters_Onclick(Nothing, Nothing)
            Case "linkPCs"
                TabContainerInventory.ActiveTabIndex = 4
                txtSearchPCs.Text = Sender.Text
                SearchPCs_Onclick(Nothing, Nothing)
        End Select

    End Sub

    Protected Sub btnReport_Click(sender As Object, e As System.EventArgs)

        Response.Redirect("BackOfficeReportPage.aspx?S=" & sender.Id & "&P=Inventory")

    End Sub

    Protected Sub btnReturn_Click(sender As Object, e As System.EventArgs) Handles btnReturn.Click

        Response.Redirect(hfBack.Value.ToString)

    End Sub


End Class
