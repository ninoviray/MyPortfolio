Imports System.Data
Imports ASP

Partial Class Pages_BackOfficeWorkOrder
    Inherits System.Web.UI.Page

    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        With Me

            SqlWorkOrders.SelectCommand = SQLWorkOrderCommand(Nothing)
            Me.ViewState("SelectCommand") = SqlWorkOrders.SelectCommand

            lbInfo.Text = "&bull; Users can manage and track current and completed work orders. <br />"
            lbInfo.Text += "&bull; The top panel is used for work orders that are in progress. <br />"
            lbInfo.Text += "&bull; If the user selects a status of 'closed' and provide a date closed, the work orders gets moved to the closed work orders section.   <br />"
            lbInfo.Text += "&bull;  Inside the closed work ordres section, the work orders can be reviewed and if needed, restored back to the in progress for further editing/updating. "

        End With

    End Sub

    Protected Sub GridViewWorkOrder_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then
                Try
                    Dim lbCreatedById As Label = TryCast(e.Row.FindControl("lbCreatedById"), Label)
                    Dim lbCreatedBy As Label = TryCast(e.Row.FindControl("lbCreatedBy"), Label)

                    Dim co = From p In TPDC.lkpBackOfficeWorkOrderUsers
                             Where p.Id.Equals(lbCreatedById.Text)
                             Select p.Id, p.Color

                    lbCreatedBy.ForeColor = Drawing.ColorTranslator.FromHtml(co.First.Color)
                Catch ex As Exception

                End Try

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub GridViewWorkOrderLog_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me


            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

                Try
                    Dim lbCreatedById As Label = TryCast(e.Row.FindControl("lbCreatedById"), Label)
                    Dim lbCreatedBy As Label = TryCast(e.Row.FindControl("lbCreatedBy"), Label)

                    Dim co = From p In TPDC.lkpBackOfficeWorkOrderUsers
                             Where p.Id.Equals(lbCreatedById.Text)
                             Select p.Id, p.Color

                    lbCreatedBy.ForeColor = Drawing.ColorTranslator.FromHtml(co.First.Color)
                Catch ex As Exception

                End Try


            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

            ElseIf e.Row.RowType = DataControlRowType.Header Then

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

            End If

        End With

    End Sub

    Protected Sub GridViewWorkOrder_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Add" Then

                If Page.IsValid Then

                    Try
                        Dim WO As New ListDictionary
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                        If DirectCast(row.FindControl("txtTicketNumber"), TextBox).Text <> Nothing Then
                            Dim Check = From p In TPDC.tblBackOfficeWorkOrders
                                        Where p.TicketNumber.Equals(DirectCast(row.FindControl("txtTicketNumber"), TextBox).Text)
                                        Select p.Id, p.TicketNumber

                            Try
                                Check.First.TicketNumber.ToString()
                                lbWorkOrderMessage.Text = "Ticket# already exists! </br>"
                                lbWorkOrderMessage.ForeColor = Drawing.Color.Red
                                Return
                            Catch ex As Exception
                            End Try
                        End If

                        WO.Add("TicketNumber", DirectCast(row.FindControl("txtTicketNumber"), TextBox).Text)
                        WO.Add("Type", DirectCast(row.FindControl("ddType"), DropDownList).SelectedValue)
                        WO.Add("Description", DirectCast(row.FindControl("txtDescription"), TextBox).Text)
                        WO.Add("CreatedBy", DirectCast(row.FindControl("ddCreatedBy"), DropDownList).SelectedValue)
                        If DirectCast(row.FindControl("txtDateRequested"), TextBox).Text <> Nothing Then
                            WO.Add("DateRequested", DirectCast(row.FindControl("txtDateRequested"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("ddRevenueCode"), DropDownList).SelectedValue <> Nothing Then
                            WO.Add("RevenueCode", DirectCast(row.FindControl("ddRevenueCode"), DropDownList).SelectedValue)
                        End If
                        WO.Add("RequisitionNumber", DirectCast(row.FindControl("txtRequisitionNumber"), TextBox).Text)
                        WO.Add("REQAPP", DirectCast(row.FindControl("txtREQAPP"), TextBox).Text)
                        WO.Add("Cost", DirectCast(row.FindControl("txtCost"), TextBox).Text)
                        WO.Add("Status", DirectCast(row.FindControl("ddStatus"), DropDownList).SelectedValue)
                        WO.Add("Notes", DirectCast(row.FindControl("txtNotes"), TextBox).Text)
                        If DirectCast(row.FindControl("txtDateCompleted"), TextBox).Text <> Nothing Then
                            WO.Add("DateCompleted", DirectCast(row.FindControl("txtDateCompleted"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtDateClosed"), TextBox).Text <> Nothing Then
                            WO.Add("DateClosed", DirectCast(row.FindControl("txtDateClosed"), TextBox).Text)
                        End If
                        WO.Add("Contact", DirectCast(row.FindControl("txtContact"), TextBox).Text)

                        WO.Add("EnterBy", hfUser.Value)
                        WO.Add("EnterDate", Now.ToString("G"))

                        If DirectCast(row.FindControl("ddStatus"), DropDownList).SelectedValue = 3 Or DirectCast(row.FindControl("ddStatus"), DropDownList).SelectedValue = 4 Then
                            DirectCast(row.FindControl("rfvDateClosed"), RequiredFieldValidator).Enabled = True

                            LinqWorkOrdersLog.Insert(WO)
                            SqlWorkOrdersLog.SelectCommand = Me.ViewState("SelectCommandLog")
                            GridViewWorkOrderLog.DataBind()
                        Else
                            LinqWorkOrders.Insert(WO)
                        End If

                        WO.Clear()
                        SqlWorkOrders.SelectCommand = Me.ViewState("SelectCommand")
                        GridViewWorkOrder.DataBind()

                        lbWorkOrderMessage.Text = "Record has been added! </br>"
                        lbWorkOrderMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbWorkOrderMessage.Text = "Your Record was Not Saved! </br>"
                        lbWorkOrderMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "UpdateRow" Then

                If Page.IsValid Then

                    Try
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                        If DirectCast(row.FindControl("ddStatusEdit"), DropDownList).SelectedValue = 3 Or DirectCast(row.FindControl("ddStatusEdit"), DropDownList).SelectedValue = 4 Then
                            Dim WO As New ListDictionary

                            WO.Add("Id", DirectCast(row.FindControl("lbId"), Label).Text)
                            WO.Add("TicketNumber", DirectCast(row.FindControl("txtTicketNumber"), TextBox).Text)
                            WO.Add("Type", DirectCast(row.FindControl("ddType"), DropDownList).SelectedValue)
                            WO.Add("Description", DirectCast(row.FindControl("txtDescription"), TextBox).Text)
                            WO.Add("CreatedBy", DirectCast(row.FindControl("ddCreatedBy"), DropDownList).SelectedValue)
                            If DirectCast(row.FindControl("txtDateRequested"), TextBox).Text <> Nothing Then
                                WO.Add("DateRequested", DirectCast(row.FindControl("txtDateRequested"), TextBox).Text)
                            End If
                            If DirectCast(row.FindControl("ddRevenueCode"), DropDownList).SelectedValue <> Nothing Then
                                WO.Add("RevenueCode", DirectCast(row.FindControl("ddRevenueCode"), DropDownList).SelectedValue)
                            End If
                            WO.Add("RequisitionNumber", DirectCast(row.FindControl("txtRequisitionNumber"), TextBox).Text)
                            WO.Add("REQAPP", DirectCast(row.FindControl("txtREQAPP"), TextBox).Text)
                            WO.Add("Cost", DirectCast(row.FindControl("txtCost"), TextBox).Text)
                            WO.Add("Status", DirectCast(row.FindControl("ddStatusEdit"), DropDownList).SelectedValue)
                            WO.Add("Notes", DirectCast(row.FindControl("txtNotes"), TextBox).Text)
                            If DirectCast(row.FindControl("txtDateCompleted"), TextBox).Text <> Nothing Then
                                WO.Add("DateCompleted", DirectCast(row.FindControl("txtDateCompleted"), TextBox).Text)
                            End If
                            If DirectCast(row.FindControl("txtDateClosed"), TextBox).Text <> Nothing Then
                                WO.Add("DateClosed", DirectCast(row.FindControl("txtDateClosed"), TextBox).Text)
                            End If
                            WO.Add("Contact", DirectCast(row.FindControl("txtContact"), TextBox).Text)

                            WO.Add("EnterBy", hfUser.Value)
                            WO.Add("EnterDate", Now.ToString("G"))

                            LinqWorkOrdersLog.Insert(WO)
                            WO.Clear()

                            Dim Delete = From p In TPDC.tblBackOfficeWorkOrders
                                         Where p.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                         Select p

                            For Each p In Delete
                                TPDC.tblBackOfficeWorkOrders.DeleteOnSubmit(p)
                            Next

                            TPDC.SubmitChanges()
                            SqlWorkOrders.SelectCommand = Me.ViewState("SelectCommand")
                            GridViewWorkOrder.DataBind()
                            SqlWorkOrdersLog.SelectCommand = Me.ViewState("SelectCommandLog")
                            GridViewWorkOrderLog.DataBind()
                            lbWorkOrderMessage.Text = "Record has been logged! </br>"
                            lbWorkOrderMessage.ForeColor = Drawing.Color.Green
                        Else
                            Dim WOU = (From p In TPDC.tblBackOfficeWorkOrders
                                       Where p.Id.Equals(DirectCast(row.FindControl("lbId"), Label).Text)).ToList()(0)

                            WOU.TicketNumber = DirectCast(row.FindControl("txtTicketNumber"), TextBox).Text
                            WOU.Type = DirectCast(row.FindControl("ddType"), DropDownList).SelectedValue
                            WOU.Description = DirectCast(row.FindControl("txtDescription"), TextBox).Text
                            WOU.CreatedBy = DirectCast(row.FindControl("ddCreatedBy"), DropDownList).SelectedValue
                            If DirectCast(row.FindControl("txtDateRequested"), TextBox).Text <> Nothing Then
                                WOU.DateRequested = DirectCast(row.FindControl("txtDateRequested"), TextBox).Text
                            End If
                            If DirectCast(row.FindControl("ddRevenueCode"), DropDownList).SelectedValue <> Nothing Then
                                WOU.RevenueCode = DirectCast(row.FindControl("ddRevenueCode"), DropDownList).SelectedValue
                            End If
                            WOU.RequisitionNumber = DirectCast(row.FindControl("txtRequisitionNumber"), TextBox).Text
                            WOU.REQAPP = DirectCast(row.FindControl("txtREQAPP"), TextBox).Text
                            WOU.Cost = DirectCast(row.FindControl("txtCost"), TextBox).Text
                            WOU.Status = DirectCast(row.FindControl("ddStatusEdit"), DropDownList).SelectedValue
                            WOU.Notes = DirectCast(row.FindControl("txtNotes"), TextBox).Text
                            If DirectCast(row.FindControl("txtDateCompleted"), TextBox).Text <> Nothing Then
                                WOU.DateCompleted = DirectCast(row.FindControl("txtDateCompleted"), TextBox).Text
                            End If
                            If DirectCast(row.FindControl("txtDateClosed"), TextBox).Text <> Nothing Then
                                WOU.DateClosed = DirectCast(row.FindControl("txtDateClosed"), TextBox).Text
                            End If
                            WOU.Contact = DirectCast(row.FindControl("txtContact"), TextBox).Text

                            WOU.ModifyBy = hfUser.Value
                            WOU.ModifyDate = Now.ToString("G")

                            TPDC.SubmitChanges()
                        End If

                        GridViewWorkOrder.SetEditRow(-1)
                        SqlWorkOrders.SelectCommand = Me.ViewState("SelectCommand")
                        GridViewWorkOrder.DataBind()
                        lbWorkOrderMessage.Text = "Record has been updated! </br>"
                        lbWorkOrderMessage.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lbWorkOrderMessage.Text = "Your Record was Not Saved! </br>"
                        lbWorkOrderMessage.ForeColor = Drawing.Color.Red
                    End Try

                End If

            ElseIf e.CommandName = "Edit" Then

                SqlWorkOrders.SelectCommand = Me.ViewState("SelectCommand")
                GridViewWorkOrder.DataBind()

            ElseIf e.CommandName = "Cancel" Then

                SqlWorkOrders.SelectCommand = Me.ViewState("SelectCommand")
                GridViewWorkOrder.DataBind()

            ElseIf e.CommandName = "DeleteRow" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)
                Try
                    Dim Delete = From p In TPDC.tblBackOfficeWorkOrders
                                 Where p.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                 Select p

                    For Each p In Delete
                        TPDC.tblBackOfficeWorkOrders.DeleteOnSubmit(p)
                    Next

                    TPDC.SubmitChanges()
                    SqlWorkOrders.SelectCommand = Me.ViewState("SelectCommand")
                    GridViewWorkOrder.DataBind()
                Catch ex As Exception

                End Try

            Else

            End If

        End With

    End Sub

    Protected Sub GridViewWorkOrderLog_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "Restore" Then

                Try
                    Dim WO As New ListDictionary
                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                    WO.Add("TicketNumber", DirectCast(row.FindControl("lbTicketNumber"), Label).Text)
                    WO.Add("Type", DirectCast(row.FindControl("lbTypeId"), Label).Text)
                    WO.Add("Description", DirectCast(row.FindControl("lbDescription"), Label).Text)
                    WO.Add("CreatedBy", DirectCast(row.FindControl("lbCreatedById"), Label).Text)
                    WO.Add("DateRequested", DirectCast(row.FindControl("lbDateRequested"), Label).Text)
                    If DirectCast(row.FindControl("lbRevenueCodeId"), Label).Text <> Nothing Then
                        WO.Add("RevenueCode", DirectCast(row.FindControl("lbRevenueCodeId"), Label).Text)
                    End If
                    WO.Add("RequisitionNumber", DirectCast(row.FindControl("lbRequisitionNumber"), Label).Text)
                    WO.Add("REQAPP", DirectCast(row.FindControl("lbREQAPP"), Label).Text)
                    WO.Add("Cost", DirectCast(row.FindControl("lbCost"), Label).Text)
                    WO.Add("Status", DirectCast(row.FindControl("lbStatusId"), Label).Text)
                    WO.Add("Notes", DirectCast(row.FindControl("lbNotes"), Label).Text)
                    If DirectCast(row.FindControl("lbDateCompleted"), Label).Text <> Nothing Then
                        WO.Add("DateCompleted", DirectCast(row.FindControl("lbDateCompleted"), Label).Text)
                    End If
                    WO.Add("Contact", DirectCast(row.FindControl("lbContact"), Label).Text)

                    WO.Add("EnterBy", hfUser.Value)
                    WO.Add("EnterDate", Now.ToString("G"))

                    LinqWorkOrders.Insert(WO)
                    SqlWorkOrders.SelectCommand = Me.ViewState("SelectCommand")
                    GridViewWorkOrder.DataBind()
                    WO.Clear()

                    Try
                        Dim Delete = From p In TPDC.tblBackOfficeWorkOrdersLogs
                                     Where p.Id.Equals((DirectCast(row.FindControl("lbId"), Label).Text))
                                     Select p

                        For Each p In Delete
                            TPDC.tblBackOfficeWorkOrdersLogs.DeleteOnSubmit(p)
                        Next

                        TPDC.SubmitChanges()
                        SqlWorkOrdersLog.SelectCommand = Me.ViewState("SelectCommand")
                        GridViewWorkOrder.DataBind()
                    Catch ex As Exception

                    End Try

                    PanelWorkOrderLogShow.Visible = True
                    PanelWorkOrderLog.Visible = False

                    lbWorkOrderMessage.Text = "Record has been restored! </br>"
                    lbWorkOrderMessage.ForeColor = Drawing.Color.Green
                Catch ex As Exception
                    lbWorkOrderMessage.Text = "Your record was not restored! </br>"
                    lbWorkOrderMessage.ForeColor = Drawing.Color.Red
                End Try

            Else

            End If

        End With

    End Sub

    Protected Sub WorkOrderSort_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkTicketNumber"
                sortDirection = If(Me.ViewState("TicketNumber") Is Nothing, "ASC", If(Me.ViewState("TicketNumber") = "ASC", "DESC", "ASC"))
                Me.ViewState("TicketNumber") = sortDirection
                sortExpression = "TicketNumber"
            Case "linkType"
                sortDirection = If(Me.ViewState("Type") Is Nothing, "ASC", If(Me.ViewState("Type") = "ASC", "DESC", "ASC"))
                Me.ViewState("Type") = sortDirection
                sortExpression = "Type"
            Case "linkDescription"
                sortDirection = If(Me.ViewState("Description") Is Nothing, "ASC", If(Me.ViewState("Description") = "ASC", "DESC", "ASC"))
                Me.ViewState("Description") = sortDirection
                sortExpression = "Description"
            Case "linkCreatedBy"
                sortDirection = If(Me.ViewState("CreatedBy") Is Nothing, "ASC", If(Me.ViewState("CreatedBy") = "ASC", "DESC", "ASC"))
                Me.ViewState("CreatedBy") = sortDirection
                sortExpression = "CreatedBy"
            Case "linkDateRequested"
                sortDirection = If(Me.ViewState("DateRequested") Is Nothing, "ASC", If(Me.ViewState("DateRequested") = "ASC", "DESC", "ASC"))
                Me.ViewState("DateRequested") = sortDirection
                sortExpression = "DateRequested"
            Case "linkRevenueCode"
                sortDirection = If(Me.ViewState("RevenueCode") Is Nothing, "ASC", If(Me.ViewState("RevenueCode") = "ASC", "DESC", "ASC"))
                Me.ViewState("RevenueCode") = sortDirection
                sortExpression = "RevenueCode"
            Case "linkRequisitionNumber"
                sortDirection = If(Me.ViewState("RequisitionNumber") Is Nothing, "ASC", If(Me.ViewState("RequisitionNumber") = "ASC", "DESC", "ASC"))
                Me.ViewState("RequisitionNumber") = sortDirection
                sortExpression = "RequisitionNumber"
            Case "linkREQAPP"
                sortDirection = If(Me.ViewState("REQAPP") Is Nothing, "ASC", If(Me.ViewState("REQAPP") = "ASC", "DESC", "ASC"))
                Me.ViewState("REQAPP") = sortDirection
                sortExpression = "REQAPP"
            Case "linkCost"
                sortDirection = If(Me.ViewState("Cost") Is Nothing, "ASC", If(Me.ViewState("Cost") = "ASC", "DESC", "ASC"))
                Me.ViewState("Cost") = sortDirection
                sortExpression = "Cost"
            Case "linkStatus"
                sortDirection = If(Me.ViewState("Status") Is Nothing, "ASC", If(Me.ViewState("Status") = "ASC", "DESC", "ASC"))
                Me.ViewState("Status") = sortDirection
                sortExpression = "Status"
            Case "linkNotes"
                sortDirection = If(Me.ViewState("Notes") Is Nothing, "ASC", If(Me.ViewState("Notes") = "ASC", "DESC", "ASC"))
                Me.ViewState("Notes") = sortDirection
                sortExpression = "Notes"
            Case "linkDateCompleted"
                sortDirection = If(Me.ViewState("DateCompleted") Is Nothing, "ASC", If(Me.ViewState("DateCompleted") = "ASC", "DESC", "ASC"))
                Me.ViewState("DateCompleted") = sortDirection
                sortExpression = "DateCompleted"
            Case "linkDateClosed"
                sortDirection = If(Me.ViewState("DateClosed") Is Nothing, "ASC", If(Me.ViewState("DateClosed") = "ASC", "DESC", "ASC"))
                Me.ViewState("DateClosed") = sortDirection
                sortExpression = "DateClosed"
            Case "linkContact"
                sortDirection = If(Me.ViewState("Contact") Is Nothing, "ASC", If(Me.ViewState("Contact") = "ASC", "DESC", "ASC"))
                Me.ViewState("Contact") = sortDirection
                sortExpression = "Contact"
            Case Else
                Return
        End Select

        SqlWorkOrders.SelectCommand = SQLWorkOrderCommand(Nothing).Replace("Id DESC ", sortExpression) & " " & sortDirection
        Me.ViewState("SelectCommand") = SqlWorkOrders.SelectCommand
        GridViewWorkOrder.DataBind()

    End Sub

    Protected Sub WorkOrderLogSort_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        Dim sortExpression As String = Nothing
        Dim sortDirection As String = Nothing

        Select Case Sender.Id
            Case "linkTicketNumber"
                sortDirection = If(Me.ViewState("LogTicketNumber") Is Nothing, "ASC", If(Me.ViewState("LogTicketNumber") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogTicketNumber") = sortDirection
                sortExpression = "TicketNumber"
            Case "linkType"
                sortDirection = If(Me.ViewState("LogType") Is Nothing, "ASC", If(Me.ViewState("LogType") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogType") = sortDirection
                sortExpression = "Type"
            Case "linkDescription"
                sortDirection = If(Me.ViewState("LogDescription") Is Nothing, "ASC", If(Me.ViewState("LogDescription") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogDescription") = sortDirection
                sortExpression = "Description"
            Case "linkCreatedBy"
                sortDirection = If(Me.ViewState("LogCreatedBy") Is Nothing, "ASC", If(Me.ViewState("LogCreatedBy") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogCreatedBy") = sortDirection
                sortExpression = "CreatedBy"
            Case "linkDateRequested"
                sortDirection = If(Me.ViewState("LogDateRequested") Is Nothing, "ASC", If(Me.ViewState("LogDateRequested") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogDateRequested") = sortDirection
                sortExpression = "DateRequested"
            Case "linkRevenueCode"
                sortDirection = If(Me.ViewState("LogRevenueCode") Is Nothing, "ASC", If(Me.ViewState("LogRevenueCode") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogRevenueCode") = sortDirection
                sortExpression = "RevenueCode"
            Case "linkRequisitionNumber"
                sortDirection = If(Me.ViewState("LogRequisitionNumber") Is Nothing, "ASC", If(Me.ViewState("LogRequisitionNumber") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogRequisitionNumber") = sortDirection
                sortExpression = "RequisitionNumber"
            Case "linkREQAPP"
                sortDirection = If(Me.ViewState("LogREQAPP") Is Nothing, "ASC", If(Me.ViewState("LogREQAPP") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogREQAPP") = sortDirection
                sortExpression = "REQAPP"
            Case "linkCost"
                sortDirection = If(Me.ViewState("LogCost") Is Nothing, "ASC", If(Me.ViewState("LogCost") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogCost") = sortDirection
                sortExpression = "Cost"
            Case "linkStatus"
                sortDirection = If(Me.ViewState("LogStatus") Is Nothing, "ASC", If(Me.ViewState("LogStatus") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogStatus") = sortDirection
                sortExpression = "Status"
            Case "linkNotes"
                sortDirection = If(Me.ViewState("LogNotes") Is Nothing, "ASC", If(Me.ViewState("LogNotes") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogNotes") = sortDirection
                sortExpression = "Notes"
            Case "linkDateCompleted"
                sortDirection = If(Me.ViewState("LogDateCompleted") Is Nothing, "ASC", If(Me.ViewState("LogDateCompleted") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogDateCompleted") = sortDirection
                sortExpression = "DateCompleted"
            Case "linkDateClosed"
                sortDirection = If(Me.ViewState("LogDateClosed") Is Nothing, "ASC", If(Me.ViewState("LogDateClosed") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogDateClosed") = sortDirection
                sortExpression = "DateClosed"
            Case "linkContact"
                sortDirection = If(Me.ViewState("LogContact") Is Nothing, "ASC", If(Me.ViewState("LogContact") = "ASC", "DESC", "ASC"))
                Me.ViewState("LogContact") = sortDirection
                sortExpression = "Contact"
            Case Else
                Return
        End Select

        SqlWorkOrdersLog.SelectCommand = SQLWorkOrderLogCommand(Nothing).Replace("UId DESC ", sortExpression) & " " & sortDirection
        Me.ViewState("SelectCommandLog") = SqlWorkOrdersLog.SelectCommand
        GridViewWorkOrderLog.DataBind()

    End Sub

    Protected Function SQLWorkOrderCommand(ByVal MyCommand As String) As String

        MyCommand = "SELECT WO.Id, WO.TicketNumber, WO.Type AS TypeId, WO.Description, WO.CreatedBy, WO.DateRequested, "
        MyCommand += "WO.RevenueCode AS RevenueCodeId, WO.RequisitionNumber, WO.REQAPP, WO.Cost, WO.Status AS StatusId, WO.Notes, WO.DateCompleted, "
        MyCommand += "Wo.DateClosed, WO.Contact, "
        MyCommand += "Type.Type, Status.Status, Staff.Name, '(' + CONVERT(varchar, RC.Id) + ') ' + RC.RevenueCode AS RevenueCode "
        MyCommand += "From tblBackOfficeWorkOrders AS WO LEFT OUTER JOIN "
        MyCommand += "lkpBackOfficeWorkOrderType AS Type ON Type.Id = WO.Type LEFT OUTER JOIN "
        MyCommand += "lkpBackOfficeWorkOrderStatus AS Status ON Status.Id = WO.Status LEFT OUTER JOIN "
        MyCommand += "lkpBackOfficeWorkOrderUser AS Us ON Us.Id = WO.CreatedBy OUTER APPLY "
        MyCommand += "(SELECT TOP 1 Staff.FName + ' ' + Staff.LName AS Name FROM tblStaff AS Staff WHERE Staff.UserId = Us.UserId) AS Staff LEFT OUTER JOIN "
        MyCommand += "lkpRevenueCode AS RC ON RC.Id = WO.RevenueCode "

        MyCommand += "WHERE WO.TicketNumber like '%" & txtSearch.Text & "%' OR WO.Description like '%" & txtSearch.Text & "%' OR WO.Notes like '%" & txtSearch.Text & "%' "
        MyCommand += "OR WO.Type like '%" & txtSearch.Text & "%' OR WO.CreatedBy like '%" & txtSearch.Text & "%' OR WO.Status like '%" & txtSearch.Text & "%' "
        MyCommand += "OR CONVERT(varchar, WO.DateRequested, 101) like '%" & txtSearch.Text & "%' "
        MyCommand += "OR CONVERT(varchar, WO.DateCompleted, 101) like '%" & txtSearch.Text & "%' "
        MyCommand += "OR CONVERT(varchar, WO.DateClosed, 101) like '%" & txtSearch.Text & "%' "
        MyCommand += "OR RC.RevenueCode Like '%" & txtSearch.Text & "%' OR WO.RequisitionNumber like '%" & txtSearch.Text & "%' "
        MyCommand += "OR WO.REQAPP like '%" & txtSearch.Text & "%' OR WO.Cost like '%" & txtSearch.Text & "%' OR WO.Contact like '%" & txtSearch.Text & "%' "
        MyCommand += "OR Staff.Name like '%" & txtSearch.Text & "%'"

        MyCommand += "Order By Id DESC "

        Return MyCommand

    End Function

    Protected Function SQLWorkOrderLogCommand(ByVal MyCommand As String) As String

        MyCommand = "SELECT WO.Id, WO.TicketNumber, WO.Type AS TypeId, WO.Description, WO.CreatedBy, WO.DateRequested, "
        MyCommand += "WO.RevenueCode AS RevenueCodeId, WO.RequisitionNumber, WO.REQAPP, WO.Cost, WO.Status AS StatusId, WO.Notes, WO.DateCompleted, "
        MyCommand += "Wo.DateClosed, WO.Contact, "
        MyCommand += "Type.Type, Status.Status, Staff.Name, '(' + CONVERT(varchar, RC.Id) + ') ' + RC.RevenueCode AS RevenueCode "
        MyCommand += "From tblBackOfficeWorkOrdersLog AS WO LEFT OUTER JOIN "
        MyCommand += "lkpBackOfficeWorkOrderType AS Type ON Type.Id = WO.Type LEFT OUTER JOIN "
        MyCommand += "lkpBackOfficeWorkOrderStatus AS Status ON Status.Id = WO.Status LEFT OUTER JOIN "
        MyCommand += "lkpBackOfficeWorkOrderUser AS Us ON Us.Id = WO.CreatedBy OUTER APPLY "
        MyCommand += "(SELECT TOP 1 Staff.FName + ' ' + Staff.LName AS Name FROM tblStaff AS Staff WHERE Staff.UserId = Us.UserId) AS Staff LEFT OUTER JOIN "
        MyCommand += "lkpRevenueCode AS RC ON RC.Id = WO.RevenueCode "

        MyCommand += "WHERE WO.TicketNumber like '%" & txtSearchLog.Text & "%' OR WO.Description like '%" & txtSearchLog.Text & "%' OR WO.Notes like '%" & txtSearchLog.Text & "%' "
        MyCommand += "OR WO.Type like '%" & txtSearchLog.Text & "%' OR WO.CreatedBy like '%" & txtSearchLog.Text & "%' OR WO.Status like '%" & txtSearchLog.Text & "%' "
        MyCommand += "OR CONVERT(varchar, WO.DateRequested, 101) like '%" & txtSearchLog.Text & "%' "
        MyCommand += "OR CONVERT(varchar, WO.DateCompleted, 101) like '%" & txtSearchLog.Text & "%' "
        MyCommand += "OR CONVERT(varchar, WO.DateClosed, 101) like '%" & txtSearchLog.Text & "%' "
        MyCommand += "OR RC.RevenueCode Like '%" & txtSearchLog.Text & "%' OR WO.RequisitionNumber like '%" & txtSearchLog.Text & "%' "
        MyCommand += "OR WO.REQAPP like '%" & txtSearchLog.Text & "%' OR WO.Cost like '%" & txtSearchLog.Text & "%' OR WO.Contact like '%" & txtSearchLog.Text & "%' "
        MyCommand += "OR Staff.Name like '%" & txtSearchLog.Text & "%'"

        MyCommand += "Order By UId DESC "

        Return MyCommand

    End Function

    Protected Sub IsCompletedClosed_Selected(ByVal sender As Object, ByVal e As EventArgs)

        Select Case sender.Id
            Case "ddStatus"
                Dim ddStatus As DropDownList = CType(GridViewWorkOrder.HeaderRow.FindControl("ddStatus"), DropDownList)
                Dim rfvDateClosed As RequiredFieldValidator = CType(GridViewWorkOrder.HeaderRow.FindControl("rfvDateClosed"), RequiredFieldValidator)
                Dim rfvDateCompleted As RequiredFieldValidator = CType(GridViewWorkOrder.HeaderRow.FindControl("rfvDateCompleted"), RequiredFieldValidator)
                If ddStatus.SelectedValue = 2 Then
                    rfvDateCompleted.Enabled = True
                    rfvDateClosed.Enabled = False
                ElseIf ddStatus.SelectedValue = 3 Then
                    rfvDateCompleted.Enabled = True
                    rfvDateClosed.Enabled = True
                ElseIf ddStatus.SelectedValue = 4 Then
                    rfvDateCompleted.Enabled = False
                    rfvDateClosed.Enabled = True
                Else
                    rfvDateClosed.Enabled = False
                    rfvDateCompleted.Enabled = False
                End If
            Case "ddStatusEdit"
                Dim ddType As DropDownList = DirectCast(sender, DropDownList)
                Dim rowType As GridViewRow = DirectCast(ddType.NamingContainer, GridViewRow)
                Dim ddStatusEdit As DropDownList = DirectCast(rowType.FindControl("ddStatusEdit"), DropDownList)
                Dim rfvDateClosedEdit As RequiredFieldValidator = DirectCast(rowType.FindControl("rfvDateClosedEdit"), RequiredFieldValidator)
                Dim rfvDateCompletedEdit As RequiredFieldValidator = DirectCast(rowType.FindControl("rfvDateCompletedEdit"), RequiredFieldValidator)
                If ddStatusEdit.SelectedValue = 2 Then
                    rfvDateCompletedEdit.Enabled = True
                    rfvDateClosedEdit.Enabled = False
                ElseIf ddStatusEdit.SelectedValue = 3 Then
                    rfvDateCompletedEdit.Enabled = True
                    rfvDateClosedEdit.Enabled = True
                ElseIf ddStatusEdit.SelectedValue = 4 Then
                    rfvDateCompletedEdit.Enabled = False
                    rfvDateClosedEdit.Enabled = True
                Else
                    rfvDateClosedEdit.Enabled = False
                    rfvDateCompletedEdit.Enabled = False
                End If
            Case Else
        End Select

    End Sub

    Protected Sub ShowHideClosedWorkOrders_OnClick(ByVal sender As Object, ByVal e As EventArgs)

        If PanelWorkOrderLogShow.Visible = True Then
            PanelWorkOrderLogShow.Visible = False
            PanelWorkOrderLog.Visible = True
            SqlWorkOrdersLog.SelectCommand = SQLWorkOrderLogCommand(Nothing)
            Me.ViewState("SelectCommandLog") = SqlWorkOrdersLog.SelectCommand
        Else
            PanelWorkOrderLogShow.Visible = True
            PanelWorkOrderLog.Visible = False
        End If

    End Sub

    Protected Sub GridViewWorkOrder_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

        GridViewWorkOrder.PageIndex = e.NewPageIndex
        SqlWorkOrders.SelectCommand = Me.ViewState("SelectCommand")
        GridViewWorkOrder.DataBind()

    End Sub

    Protected Sub GridViewWorkOrderLog_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

        GridViewWorkOrderLog.PageIndex = e.NewPageIndex
        SqlWorkOrdersLog.SelectCommand = Me.ViewState("SelectCommandLog")
        GridViewWorkOrderLog.DataBind()

    End Sub

    Protected Sub Search_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            SqlWorkOrders.SelectCommand = SQLWorkOrderCommand(Nothing)
            Me.ViewState("SelectCommand") = SqlWorkOrders.SelectCommand
            GridViewWorkOrder.DataBind()

        End If

    End Sub

    Protected Sub SearchLog_Onclick(ByVal Sender As Object, ByVal e As EventArgs)

        If Page.IsValid Then

            SqlWorkOrdersLog.SelectCommand = SQLWorkOrderLogCommand(Nothing)
            Me.ViewState("SelectCommandLog") = SqlWorkOrdersLog.SelectCommand
            GridViewWorkOrderLog.DataBind()

        End If

    End Sub

    Protected Sub btnReturn_Click(sender As Object, e As System.EventArgs) Handles btnReturn.Click

        Response.Redirect(hfBack.Value.ToString)

    End Sub

End Class
