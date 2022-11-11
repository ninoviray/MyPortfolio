Partial Class Pages_TimeStudy
    Inherits System.Web.UI.Page

    Dim SundayTotal As New Double
    Dim SundayEditTotal As New Double
    Dim MondayTotal As New Double
    Dim MondayEditTotal As New Double
    Dim TuesdayTotal As New Double
    Dim TuesdayEditTotal As New Double
    Dim WednesdayTotal As New Double
    Dim WednesdayEditTotal As New Double
    Dim ThursdayTotal As New Double
    Dim ThursdayEditTotal As New Double
    Dim FridayTotal As New Double
    Dim FridayEditTotal As New Double
    Dim SaturdayTotal As New Double
    Dim SaturdayEditTotal As New Double
    Dim WeeklyTotal As New Double
    Dim WeeklyEditTotal As New Double
    Dim CancelUpdate As New Boolean

    Dim TPDC As New MyPortfolioDbDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        With Me

            hfUser.Value = "viray"

            If Not IsPostBack Then

                If Not Request.QueryString("D") Is Nothing Then
                    IsInStudyDate(CInt(Request.QueryString("D")).ToString)
                Else
                    hfStudyDate.Value = Nothing
                    ddSelectStudyDate.SelectedValue = Nothing
                End If

                Try
                    Dim TPDCStaff As New MyPortfolioDbDataContext
                    hfLookUpUserId.Value = "123abc7e-21e4-4142-86ea-70aad3abc123"
                    Dim STF = From u In TPDC.tblStaffs
                          Where u.UserId.Equals(Trim(hfLookUpUserId.Value))
                          Select u.UserId, u.FName, u.LName

                lbPreTransplantTimeStudy.Text = "Pre-Transplant Time Study:<br/>" & Trim(STF.First.LName) & ", " & Trim(STF.First.FName)
                Catch ex As Exception
                    lbPreTransplantTimeStudy.Text = "Pre-Transplant Time Study"
                End Try
                lbTitle.Text = lbPreTransplantTimeStudy.Text

            txtMinutes.Attributes.Add("onkeyup", "setMinutesToHours('" + txtMinutes.ClientID + "','" + txtHours.ClientID + "',event)")

                lbTimeStudyInfo.Text = "&bull; In this section users can fill out their Time Study. <br />"
                lbTimeStudyInfo.Text += "&bull; Gridview handles the processing of the data. <br />"
                lbTimeStudyInfo.Text += "&bull; Validators insure data integrity. <br />"
                lbTimeStudyInfo.Text += "&bull; Javascript to track the Total Hours. <br />"
                lbTimeStudyInfo.Text += "&bull; Crystal Reports displays the data in a printable form. <br />"


            End If

        End With

    End Sub

    Protected Sub GridViewTimeStudy_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        With Me

            If ((e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit) Then

                GridViewTimeStudy.HeaderRow.Enabled = False

                Dim txtSundayHours As TextBox = TryCast(e.Row.FindControl("txtSundayHours"), TextBox)
                Dim txtMondayHours As TextBox = TryCast(e.Row.FindControl("txtMondayHours"), TextBox)
                Dim txtTuesdayHours As TextBox = TryCast(e.Row.FindControl("txtTuesdayHours"), TextBox)
                Dim txtWednesdayHours As TextBox = TryCast(e.Row.FindControl("txtWednesdayHours"), TextBox)
                Dim txtThursdayHours As TextBox = TryCast(e.Row.FindControl("txtThursdayHours"), TextBox)
                Dim txtFridayHours As TextBox = TryCast(e.Row.FindControl("txtFridayHours"), TextBox)
                Dim txtSaturdayHours As TextBox = TryCast(e.Row.FindControl("txtSaturdayHours"), TextBox)
                Dim txtTotalHoursText As TextBox = TryCast(e.Row.FindControl("txtTotalHoursText"), TextBox)
                Dim lbId As Label = TryCast(e.Row.FindControl("lbId"), Label)

                SundayEditTotal = 0
                MondayEditTotal = 0
                TuesdayEditTotal = 0
                WednesdayEditTotal = 0
                ThursdayEditTotal = 0
                FridayEditTotal = 0
                SaturdayEditTotal = 0
                WeeklyEditTotal = 0

                SundayEditTotal = Convert.ToDouble(lbSundayTotalText.Text)
                MondayEditTotal = Convert.ToDouble(lbMondayTotalText.Text)
                TuesdayEditTotal = Convert.ToDouble(lbTuesdayTotalText.Text)
                WednesdayEditTotal = Convert.ToDouble(lbWednesdayTotalText.Text)
                ThursdayEditTotal = Convert.ToDouble(lbThursdayTotalText.Text)
                FridayEditTotal = Convert.ToDouble(lbFridayTotalText.Text)
                SaturdayEditTotal = Convert.ToDouble(lbSaturdayTotalText.Text)
                WeeklyEditTotal = Convert.ToDouble(lbWeeklyTotalText.Text)

                lbSundayTotalText.Text = SundayEditTotal
                lbMondayTotalText.Text = MondayEditTotal
                lbTuesdayTotalText.Text = TuesdayEditTotal
                lbWednesdayTotalText.Text = WednesdayEditTotal
                lbThursdayTotalText.Text = ThursdayEditTotal
                lbFridayTotalText.Text = FridayEditTotal
                lbSaturdayTotalText.Text = SaturdayEditTotal
                lbWeeklyTotalText.Text = WeeklyEditTotal

                Dim SundayAdjust As Double = Nothing
                Dim MondayAdjust As Double = Nothing
                Dim TuesdayAdjust As Double = Nothing
                Dim WednesdayAdjust As Double = Nothing
                Dim ThursdayAdjust As Double = Nothing
                Dim FridayAdjust As Double = Nothing
                Dim SaturdayAdjust As Double = Nothing

                If txtSundayHours.Text <> Nothing Then
                    SundayAdjust = Convert.ToDouble(lbSundayTotalText.Text) - Convert.ToDouble(txtSundayHours.Text)
                Else
                    SundayAdjust = Convert.ToDouble(lbSundayTotalText.Text)
                End If
                If txtMondayHours.Text <> Nothing Then
                    MondayAdjust = Convert.ToDouble(lbMondayTotalText.Text) - Convert.ToDouble(txtMondayHours.Text)
                Else
                    MondayAdjust = Convert.ToDouble(lbMondayTotalText.Text)
                End If
                If txtTuesdayHours.Text <> Nothing Then
                    TuesdayAdjust = Convert.ToDouble(lbTuesdayTotalText.Text) - Convert.ToDouble(txtTuesdayHours.Text)
                Else
                    TuesdayAdjust = Convert.ToDouble(lbTuesdayTotalText.Text)
                End If
                If txtWednesdayHours.Text <> Nothing Then
                    WednesdayAdjust = Convert.ToDouble(lbWednesdayTotalText.Text) - Convert.ToDouble(txtWednesdayHours.Text)
                Else
                    WednesdayAdjust = Convert.ToDouble(lbWednesdayTotalText.Text)
                End If
                If txtThursdayHours.Text <> Nothing Then
                    ThursdayAdjust = Convert.ToDouble(lbThursdayTotalText.Text) - Convert.ToDouble(txtThursdayHours.Text)
                Else
                    ThursdayAdjust = Convert.ToDouble(lbThursdayTotalText.Text)
                End If
                If txtFridayHours.Text <> Nothing Then
                    FridayAdjust = Convert.ToDouble(lbFridayTotalText.Text) - Convert.ToDouble(txtFridayHours.Text)
                Else
                    FridayAdjust = Convert.ToDouble(lbFridayTotalText.Text)
                End If
                If txtSaturdayHours.Text <> Nothing Then
                    SaturdayAdjust = Convert.ToDouble(lbSaturdayTotalText.Text) - Convert.ToDouble(txtSaturdayHours.Text)
                Else
                    SaturdayAdjust = Convert.ToDouble(lbSaturdayTotalText.Text)
                End If

                txtSundayHours.Attributes.Add("onkeyup", "setTotalHours('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayAdjust.ToString + "','" + MondayAdjust.ToString + "','" + TuesdayAdjust.ToString + "','" + WednesdayAdjust.ToString + "','" + ThursdayAdjust.ToString + "','" + FridayAdjust.ToString + "','" + SaturdayAdjust.ToString + "',event)")
                txtMondayHours.Attributes.Add("onkeyup", "setTotalHours('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayAdjust.ToString + "','" + MondayAdjust.ToString + "','" + TuesdayAdjust.ToString + "','" + WednesdayAdjust.ToString + "','" + ThursdayAdjust.ToString + "','" + FridayAdjust.ToString + "','" + SaturdayAdjust.ToString + "',event)")
                txtTuesdayHours.Attributes.Add("onkeyup", "setTotalHours('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayAdjust.ToString + "','" + MondayAdjust.ToString + "','" + TuesdayAdjust.ToString + "','" + WednesdayAdjust.ToString + "','" + ThursdayAdjust.ToString + "','" + FridayAdjust.ToString + "','" + SaturdayAdjust.ToString + "',event)")
                txtWednesdayHours.Attributes.Add("onkeyup", "setTotalHours('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayAdjust.ToString + "','" + MondayAdjust.ToString + "','" + TuesdayAdjust.ToString + "','" + WednesdayAdjust.ToString + "','" + ThursdayAdjust.ToString + "','" + FridayAdjust.ToString + "','" + SaturdayAdjust.ToString + "',event)")
                txtThursdayHours.Attributes.Add("onkeyup", "setTotalHours('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayAdjust.ToString + "','" + MondayAdjust.ToString + "','" + TuesdayAdjust.ToString + "','" + WednesdayAdjust.ToString + "','" + ThursdayAdjust.ToString + "','" + FridayAdjust.ToString + "','" + SaturdayAdjust.ToString + "',event)")
                txtFridayHours.Attributes.Add("onkeyup", "setTotalHours('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayAdjust.ToString + "','" + MondayAdjust.ToString + "','" + TuesdayAdjust.ToString + "','" + WednesdayAdjust.ToString + "','" + ThursdayAdjust.ToString + "','" + FridayAdjust.ToString + "','" + SaturdayAdjust.ToString + "',event)")
                txtSaturdayHours.Attributes.Add("onkeyup", "setTotalHours('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayAdjust.ToString + "','" + MondayAdjust.ToString + "','" + TuesdayAdjust.ToString + "','" + WednesdayAdjust.ToString + "','" + ThursdayAdjust.ToString + "','" + FridayAdjust.ToString + "','" + SaturdayAdjust.ToString + "',event)")

                Dim lbPreTransplantDate As Label = TryCast(e.Row.FindControl("lbPreTransplantDate"), Label)
                lbPreTransplantDate.Text = lbStudyDate.Text

            ElseIf e.Row.RowType = DataControlRowType.DataRow Then

                panelTotals.Visible = True

                Dim lbPreTransplantDate As Label = TryCast(e.Row.FindControl("lbPreTransplantDate"), Label)
                lbPreTransplantDate.Text = lbStudyDate.Text

                Try
                    Dim TS = From p In TPDC.tblStaffTimeStudies
                             Where p.UserId.Equals(hfLookUpUserId.Value) And p.PreTransplantDate.Equals(hfStudyDate.Value)

                    If TS.First.Locked = True Then
                        GridViewTimeStudy.Visible = False
                        lbMessage.Text = "Status: " & TS.First.Status
                        lbMessage.ForeColor = Drawing.Color.Red
                        panelTotals.Visible = False
                    Else
                        GridViewTimeStudy.Visible = True
                        lbMessage.Text = ""
                        panelTotals.Visible = True
                    End If
                Catch ex As Exception

                End Try

                btnReport.Visible = True

                'Tally up the totals for each day and the whole week
                Dim lbSundayHoursText As Label = TryCast(e.Row.FindControl("lbSundayHoursText"), Label)
                Dim lbMondayHoursText As Label = TryCast(e.Row.FindControl("lbMondayHoursText"), Label)
                Dim lbTuesdayHoursText As Label = TryCast(e.Row.FindControl("lbTuesdayHoursText"), Label)
                Dim lbWednesdayHoursText As Label = TryCast(e.Row.FindControl("lbWednesdayHoursText"), Label)
                Dim lbThursdayHoursText As Label = TryCast(e.Row.FindControl("lbThursdayHoursText"), Label)
                Dim lbFridayHoursText As Label = TryCast(e.Row.FindControl("lbFridayHoursText"), Label)
                Dim lbSaturdayHoursText As Label = TryCast(e.Row.FindControl("lbSaturdayHoursText"), Label)
                Dim lbTotalHoursText As Label = TryCast(e.Row.FindControl("lbTotalHoursText"), Label)

                If e.Row.RowIndex = 0 Then
                    SundayTotal = 0
                    MondayTotal = 0
                    TuesdayTotal = 0
                    WednesdayTotal = 0
                    ThursdayTotal = 0
                    FridayTotal = 0
                    SaturdayTotal = 0
                    WeeklyTotal = 0
                End If

                Try
                    If lbSundayHoursText.Text <> Nothing Then
                        SundayTotal += lbSundayHoursText.Text
                    End If
                    If lbMondayHoursText.Text <> Nothing Then
                        MondayTotal += lbMondayHoursText.Text
                    End If
                    If lbTuesdayHoursText.Text <> Nothing Then
                        TuesdayTotal += lbTuesdayHoursText.Text
                    End If
                    If lbWednesdayHoursText.Text <> Nothing Then
                        WednesdayTotal += lbWednesdayHoursText.Text
                    End If
                    If lbThursdayHoursText.Text <> Nothing Then
                        ThursdayTotal += lbThursdayHoursText.Text
                    End If
                    If lbFridayHoursText.Text <> Nothing Then
                        FridayTotal += lbFridayHoursText.Text
                    End If
                    If lbSaturdayHoursText.Text <> Nothing Then
                        SaturdayTotal += lbSaturdayHoursText.Text
                    End If
                    If lbTotalHoursText.Text <> Nothing Then
                        WeeklyTotal += lbTotalHoursText.Text
                    End If
                Catch ex As Exception

                End Try

            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then

                panelTotals.Visible = False

                Dim txtSundayHours As TextBox = TryCast(e.Row.FindControl("txtSundayHours"), TextBox)
                Dim txtMondayHours As TextBox = TryCast(e.Row.FindControl("txtMondayHours"), TextBox)
                Dim txtTuesdayHours As TextBox = TryCast(e.Row.FindControl("txtTuesdayHours"), TextBox)
                Dim txtWednesdayHours As TextBox = TryCast(e.Row.FindControl("txtWednesdayHours"), TextBox)
                Dim txtThursdayHours As TextBox = TryCast(e.Row.FindControl("txtThursdayHours"), TextBox)
                Dim txtFridayHours As TextBox = TryCast(e.Row.FindControl("txtFridayHours"), TextBox)
                Dim txtSaturdayHours As TextBox = TryCast(e.Row.FindControl("txtSaturdayHours"), TextBox)
                Dim txtTotalHoursText As TextBox = TryCast(e.Row.FindControl("txtTotalHoursText"), TextBox)

                txtSundayHours.Attributes.Add("onkeyup", "setTotalHoursEmpty('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "',event)")
                txtMondayHours.Attributes.Add("onkeyup", "setTotalHoursEmpty('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "',event)")
                txtTuesdayHours.Attributes.Add("onkeyup", "setTotalHoursEmpty('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "',event)")
                txtWednesdayHours.Attributes.Add("onkeyup", "setTotalHoursEmpty('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "',event)")
                txtThursdayHours.Attributes.Add("onkeyup", "setTotalHoursEmpty('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "',event)")
                txtFridayHours.Attributes.Add("onkeyup", "setTotalHoursEmpty('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "',event)")
                txtSaturdayHours.Attributes.Add("onkeyup", "setTotalHoursEmpty('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "',event)")

                Dim lbPreTransplantDate As Label = TryCast(e.Row.FindControl("lbPreTransplantDate"), Label)
                lbPreTransplantDate.Text = lbStudyDate.Text

                btnReport.Visible = False

                GridViewTimeStudy.Visible = True
                lbMessage.Text = ""

            ElseIf e.Row.RowType = DataControlRowType.Header Then

                Dim lbPreTransplantDate As Label = TryCast(e.Row.FindControl("lbPreTransplantDate"), Label)
                lbPreTransplantDate.Text = lbStudyDate.Text

            ElseIf e.Row.RowType = DataControlRowType.Footer Then

                If GridViewTimeStudy.HeaderRow.Enabled = True Then
                    lbSundayTotalText.Text = SundayTotal
                    lbMondayTotalText.Text = MondayTotal
                    lbTuesdayTotalText.Text = TuesdayTotal
                    lbWednesdayTotalText.Text = WednesdayTotal
                    lbThursdayTotalText.Text = ThursdayTotal
                    lbFridayTotalText.Text = FridayTotal
                    lbSaturdayTotalText.Text = SaturdayTotal
                    lbWeeklyTotalText.Text = WeeklyTotal
                End If

                'Setting Header attribute here because Totals are not calculated at time of header row
                Dim txtSundayHours As TextBox = DirectCast(GridViewTimeStudy.HeaderRow.FindControl("txtSundayHours"), TextBox)
                Dim txtMondayHours As TextBox = DirectCast(GridViewTimeStudy.HeaderRow.FindControl("txtMondayHours"), TextBox)
                Dim txtTuesdayHours As TextBox = DirectCast(GridViewTimeStudy.HeaderRow.FindControl("txtTuesdayHours"), TextBox)
                Dim txtWednesdayHours As TextBox = DirectCast(GridViewTimeStudy.HeaderRow.FindControl("txtWednesdayHours"), TextBox)
                Dim txtThursdayHours As TextBox = DirectCast(GridViewTimeStudy.HeaderRow.FindControl("txtThursdayHours"), TextBox)
                Dim txtFridayHours As TextBox = DirectCast(GridViewTimeStudy.HeaderRow.FindControl("txtFridayHours"), TextBox)
                Dim txtSaturdayHours As TextBox = DirectCast(GridViewTimeStudy.HeaderRow.FindControl("txtSaturdayHours"), TextBox)
                Dim txtTotalHoursText As TextBox = DirectCast(GridViewTimeStudy.HeaderRow.FindControl("txtTotalHoursText"), TextBox)

                txtSundayHours.Attributes.Add("onkeyup", "setTotalHoursHeader('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayTotal.ToString + "','" + MondayTotal.ToString + "','" + TuesdayTotal.ToString + "','" + WednesdayTotal.ToString + "','" + ThursdayTotal.ToString + "','" + FridayTotal.ToString + "','" + SaturdayTotal.ToString + "',event)")
                txtMondayHours.Attributes.Add("onkeyup", "setTotalHoursHeader('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayTotal.ToString + "','" + MondayTotal.ToString + "','" + TuesdayTotal.ToString + "','" + WednesdayTotal.ToString + "','" + ThursdayTotal.ToString + "','" + FridayTotal.ToString + "','" + SaturdayTotal.ToString + "',event)")
                txtTuesdayHours.Attributes.Add("onkeyup", "setTotalHoursHeader('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayTotal.ToString + "','" + MondayTotal.ToString + "','" + TuesdayTotal.ToString + "','" + WednesdayTotal.ToString + "','" + ThursdayTotal.ToString + "','" + FridayTotal.ToString + "','" + SaturdayTotal.ToString + "',event)")
                txtWednesdayHours.Attributes.Add("onkeyup", "setTotalHoursHeader('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayTotal.ToString + "','" + MondayTotal.ToString + "','" + TuesdayTotal.ToString + "','" + WednesdayTotal.ToString + "','" + ThursdayTotal.ToString + "','" + FridayTotal.ToString + "','" + SaturdayTotal.ToString + "',event)")
                txtThursdayHours.Attributes.Add("onkeyup", "setTotalHoursHeader('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayTotal.ToString + "','" + MondayTotal.ToString + "','" + TuesdayTotal.ToString + "','" + WednesdayTotal.ToString + "','" + ThursdayTotal.ToString + "','" + FridayTotal.ToString + "','" + SaturdayTotal.ToString + "',event)")
                txtFridayHours.Attributes.Add("onkeyup", "setTotalHoursHeader('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayTotal.ToString + "','" + MondayTotal.ToString + "','" + TuesdayTotal.ToString + "','" + WednesdayTotal.ToString + "','" + ThursdayTotal.ToString + "','" + FridayTotal.ToString + "','" + SaturdayTotal.ToString + "',event)")
                txtSaturdayHours.Attributes.Add("onkeyup", "setTotalHoursHeader('" + txtSundayHours.ClientID + "','" + txtMondayHours.ClientID + "','" + txtTuesdayHours.ClientID + "','" + txtWednesdayHours.ClientID + "','" + txtThursdayHours.ClientID + "','" + txtFridayHours.ClientID + "','" + txtSaturdayHours.ClientID + "','" + txtTotalHoursText.ClientID + "','" + SundayTotal.ToString + "','" + MondayTotal.ToString + "','" + TuesdayTotal.ToString + "','" + WednesdayTotal.ToString + "','" + ThursdayTotal.ToString + "','" + FridayTotal.ToString + "','" + SaturdayTotal.ToString + "',event)")

            End If

        End With

    End Sub

    'Protected Sub GridViewTimeStudy_RowCreated(sender As Object, e As GridViewRowEventArgs)

    '    If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowIndex <> GridViewTimeStudy.EditIndex Then

    '        Dim EditButton As ImageButton = TryCast(e.Row.FindControl("ibtnEdit"), ImageButton)
    '        EditButton.Visible = User.IsInRole("")

    '    End If

    'End Sub

    Protected Sub GridViewTimeStudy_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        With Me

            If e.CommandName = "New" Then

                If Page.IsValid Then

                    Try
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                        'Check if entire row is empty or 0's, if it is return with error
                        Dim SundayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtSundayHours"), TextBox).Text = Nothing Then
                            SundayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtSundayHours"), TextBox).Text) = "0" Then
                            SundayEmpty = True
                        End If
                        Dim MondayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtMondayHours"), TextBox).Text = Nothing Then
                            MondayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtMondayHours"), TextBox).Text) = "0" Then
                            MondayEmpty = True
                        End If
                        Dim TuesdayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text = Nothing Then
                            TuesdayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text) = "0" Then
                            TuesdayEmpty = True
                        End If
                        Dim WednesdayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text = Nothing Then
                            WednesdayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text) = "0" Then
                            WednesdayEmpty = True
                        End If
                        Dim ThursdayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text = Nothing Then
                            ThursdayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text) = "0" Then
                            ThursdayEmpty = True
                        End If
                        Dim FridayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtFridayHours"), TextBox).Text = Nothing Then
                            FridayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtFridayHours"), TextBox).Text) = "0" Then
                            FridayEmpty = True
                        End If
                        Dim SaturdayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text = Nothing Then
                            SaturdayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text) = "0" Then
                            SaturdayEmpty = True
                        End If
                        If SundayEmpty = True And MondayEmpty = True And TuesdayEmpty = True And WednesdayEmpty = True And ThursdayEmpty = True And FridayEmpty = True And SaturdayEmpty = True Then
                            lbMessage.Text = "</br>Please enter a value greater than 0 for at least one of the days!</br>"
                            lbMessage.Visible = True
                            lbMessage.ForeColor = Drawing.Color.Red
                            Return
                        End If

                        Dim LD As New ListDictionary
                        LD.Add("UserId", hfLookUpUserId.Value)

                        If hfStudyDate.Value <> Nothing Then
                            LD.Add("PreTransplantDate", hfStudyDate.Value)
                        End If
                        If DirectCast(row.FindControl("ddPreTransplantType"), DropDownList).SelectedValue <> Nothing Then
                            LD.Add("PreTransplantType", DirectCast(row.FindControl("ddPreTransplantType"), DropDownList).SelectedValue)
                        End If
                        If DirectCast(row.FindControl("txtSundayHours"), TextBox).Text <> Nothing Then
                            LD.Add("SundayHours", DirectCast(row.FindControl("txtSundayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtMondayHours"), TextBox).Text <> Nothing Then
                            LD.Add("MondayHours", DirectCast(row.FindControl("txtMondayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text <> Nothing Then
                            LD.Add("TuesdayHours", DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text <> Nothing Then
                            LD.Add("WednesdayHours", DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text <> Nothing Then
                            LD.Add("ThursdayHours", DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtFridayHours"), TextBox).Text <> Nothing Then
                            LD.Add("FridayHours", DirectCast(row.FindControl("txtFridayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text <> Nothing Then
                            LD.Add("SaturdayHours", DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text)
                        End If

                        LD.Add("Status", "Open/Not Submitted")
                        LD.Add("StatusLog", "")
                        LD.Add("Locked", False)
                        LD.Add("EnterBy", hfUser.Value)
                        LD.Add("EnterDate", Now.ToString("G"))
                        LinqTimeStudy.Insert(LD)
                        LD.Clear()

                        GridViewTimeStudy.DataBind()
                        GridViewTimeStudy.SelectedIndex = -1
                        UpdatePanelTimeStudy.Update()
                    Catch ex2 As Exception

                    End Try

                End If

            ElseIf e.CommandName = "Add" Then

                If Page.IsValid Then

                    Try
                        Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                        'Check if entire row is empty or 0's, if it is return with error
                        Dim SundayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtSundayHours"), TextBox).Text = Nothing Then
                            SundayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtSundayHours"), TextBox).Text) = "0" Then
                            SundayEmpty = True
                        End If
                        Dim MondayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtMondayHours"), TextBox).Text = Nothing Then
                            MondayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtMondayHours"), TextBox).Text) = "0" Then
                            MondayEmpty = True
                        End If
                        Dim TuesdayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text = Nothing Then
                            TuesdayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text) = "0" Then
                            TuesdayEmpty = True
                        End If
                        Dim WednesdayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text = Nothing Then
                            WednesdayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text) = "0" Then
                            WednesdayEmpty = True
                        End If
                        Dim ThursdayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text = Nothing Then
                            ThursdayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text) = "0" Then
                            ThursdayEmpty = True
                        End If
                        Dim FridayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtFridayHours"), TextBox).Text = Nothing Then
                            FridayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtFridayHours"), TextBox).Text) = "0" Then
                            FridayEmpty = True
                        End If
                        Dim SaturdayEmpty As Boolean = False
                        If DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text = Nothing Then
                            SaturdayEmpty = True
                        ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text) = "0" Then
                            SaturdayEmpty = True
                        End If
                        If SundayEmpty = True And MondayEmpty = True And TuesdayEmpty = True And WednesdayEmpty = True And ThursdayEmpty = True And FridayEmpty = True And SaturdayEmpty = True Then
                            lbMessage.Text = "</br>Please enter a value greater than 0 for at least one of the days!</br>"
                            lbMessage.Visible = True
                            lbMessage.ForeColor = Drawing.Color.Red
                            Return
                        End If

                        Dim LD As New ListDictionary
                        LD.Add("UserId", hfLookUpUserId.Value)

                        If hfStudyDate.Value <> Nothing Then
                            LD.Add("PreTransplantDate", hfStudyDate.Value)
                        End If
                        If DirectCast(row.FindControl("ddPreTransplantType"), DropDownList).SelectedValue <> Nothing Then
                            LD.Add("PreTransplantType", DirectCast(row.FindControl("ddPreTransplantType"), DropDownList).SelectedValue)
                        End If
                        If DirectCast(row.FindControl("txtSundayHours"), TextBox).Text <> Nothing Then
                            LD.Add("SundayHours", DirectCast(row.FindControl("txtSundayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtMondayHours"), TextBox).Text <> Nothing Then
                            LD.Add("MondayHours", DirectCast(row.FindControl("txtMondayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text <> Nothing Then
                            LD.Add("TuesdayHours", DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text <> Nothing Then
                            LD.Add("WednesdayHours", DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text <> Nothing Then
                            LD.Add("ThursdayHours", DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtFridayHours"), TextBox).Text <> Nothing Then
                            LD.Add("FridayHours", DirectCast(row.FindControl("txtFridayHours"), TextBox).Text)
                        End If
                        If DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text <> Nothing Then
                            LD.Add("SaturdayHours", DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text)
                        End If

                        LD.Add("Status", "Open/Not Submitted")
                        LD.Add("StatusLog", "")
                        LD.Add("Locked", False)
                        LD.Add("EnterBy", hfUser.Value)
                        LD.Add("EnterDate", Now.ToString("G"))
                        LinqTimeStudy.Insert(LD)
                        LD.Clear()

                        GridViewTimeStudy.DataBind()
                        GridViewTimeStudy.SelectedIndex = -1
                        UpdatePanelTimeStudy.Update()
                    Catch ex2 As Exception

                    End Try

                End If

            ElseIf e.CommandName = "Edit" Then


            ElseIf e.CommandName = "Update" Then

                If Page.IsValid Then

                    Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                    'Check if entire row is empty or 0's, if it is return with error
                    Dim SundayEmpty As Boolean = False
                    If DirectCast(row.FindControl("txtSundayHours"), TextBox).Text = Nothing Then
                        SundayEmpty = True
                    ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtSundayHours"), TextBox).Text) = "0" Then
                        SundayEmpty = True
                    End If
                    Dim MondayEmpty As Boolean = False
                    If DirectCast(row.FindControl("txtMondayHours"), TextBox).Text = Nothing Then
                        MondayEmpty = True
                    ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtMondayHours"), TextBox).Text) = "0" Then
                        MondayEmpty = True
                    End If
                    Dim TuesdayEmpty As Boolean = False
                    If DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text = Nothing Then
                        TuesdayEmpty = True
                    ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtTuesdayHours"), TextBox).Text) = "0" Then
                        TuesdayEmpty = True
                    End If
                    Dim WednesdayEmpty As Boolean = False
                    If DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text = Nothing Then
                        WednesdayEmpty = True
                    ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtWednesdayHours"), TextBox).Text) = "0" Then
                        WednesdayEmpty = True
                    End If
                    Dim ThursdayEmpty As Boolean = False
                    If DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text = Nothing Then
                        ThursdayEmpty = True
                    ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtThursdayHours"), TextBox).Text) = "0" Then
                        ThursdayEmpty = True
                    End If
                    Dim FridayEmpty As Boolean = False
                    If DirectCast(row.FindControl("txtFridayHours"), TextBox).Text = Nothing Then
                        FridayEmpty = True
                    ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtFridayHours"), TextBox).Text) = "0" Then
                        FridayEmpty = True
                    End If
                    Dim SaturdayEmpty As Boolean = False
                    If DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text = Nothing Then
                        SaturdayEmpty = True
                    ElseIf Convert.ToDouble(DirectCast(row.FindControl("txtSaturdayHours"), TextBox).Text) = "0" Then
                        SaturdayEmpty = True
                    End If
                    If SundayEmpty = True And MondayEmpty = True And TuesdayEmpty = True And WednesdayEmpty = True And ThursdayEmpty = True And FridayEmpty = True And SaturdayEmpty = True Then
                        lbMessage.Text = "</br>Please enter a value greater than 0 for at least one of the days!</br>"
                        lbMessage.Visible = True
                        lbMessage.ForeColor = Drawing.Color.Red
                        CancelUpdate = True
                    End If

                    Try
                        Dim TS = From p In TPDC.tblStaffTimeStudies
                                 Where p.Id.Equals(DirectCast(row.FindControl("lbId"), Label).Text)

                        Dim LD As New ListDictionary
                        LD.Add("UId", Guid.NewGuid)
                        LD.Add("UserId", hfLookUpUserId.Value)
                        LD.Add("Id", TS.First.Id)
                        LD.Add("PreTransplantDate", TS.First.PreTransplantDate)
                        LD.Add("PreTransplantType", TS.First.PreTransplantType)
                        LD.Add("SundayHours", Trim(TS.First.SundayHours))
                        LD.Add("MondayHours", Trim(TS.First.MondayHours))
                        LD.Add("TuesdayHours", Trim(TS.First.TuesdayHours))
                        LD.Add("WednesdayHours", Trim(TS.First.WednesdayHours))
                        LD.Add("ThursdayHours", Trim(TS.First.ThursdayHours))
                        LD.Add("FridayHours", Trim(TS.First.FridayHours))
                        LD.Add("SaturdayHours", Trim(TS.First.SaturdayHours))
                        LD.Add("Status", TS.First.Status)
                        LD.Add("StatusLog", TS.First.StatusLog)
                        LD.Add("Locked", TS.First.Locked)
                        LD.Add("EnterBy", hfUser.Value)
                        LD.Add("EnterDate", Now.ToString("G"))
                        LinqTimeStudyLog.Insert(LD)
                        LD.Clear()
                    Catch ex As Exception

                    End Try

                    Try
                        Dim ANS = (From AN In TPDC.tblStaffTimeStudies
                                   Where AN.UserId.ToString().Equals(hfLookUpUserId.Value) And AN.Id.Equals(DirectCast(row.FindControl("lbId"), Label).Text)).ToList()(0)

                        ANS.ModifyBy = hfUser.Value
                        ANS.ModifyDate = Now.ToString("G")
                        TPDC.SubmitChanges()
                    Catch ex As Exception

                    End Try

                    GridViewTimeStudy.DataBind()

                End If

            ElseIf e.CommandName = "Delete" Then

                Dim row As GridViewRow = DirectCast(DirectCast(e.CommandSource, Control).NamingContainer, GridViewRow)

                Try
                    Dim TS = From p In TPDC.tblStaffTimeStudies
                             Where p.Id.Equals(DirectCast(row.FindControl("lbId"), Label).Text)

                    Dim LD As New ListDictionary
                    LD.Add("UId", Guid.NewGuid)
                    LD.Add("UserId", hfLookUpUserId.Value)
                    LD.Add("Id", TS.First.Id)
                    LD.Add("PreTransplantDate", TS.First.PreTransplantDate)
                    LD.Add("PreTransplantType", TS.First.PreTransplantType)
                    LD.Add("SundayHours", TS.First.SundayHours)
                    LD.Add("MondayHours", TS.First.MondayHours)
                    LD.Add("TuesdayHours", TS.First.TuesdayHours)
                    LD.Add("WednesdayHours", TS.First.WednesdayHours)
                    LD.Add("ThursdayHours", TS.First.ThursdayHours)
                    LD.Add("FridayHours", TS.First.FridayHours)
                    LD.Add("SaturdayHours", TS.First.SaturdayHours)
                    LD.Add("Status", TS.First.Status)
                    LD.Add("StatusLog", TS.First.StatusLog)
                    LD.Add("Locked", TS.First.Locked)
                    LD.Add("EnterBy", hfUser.Value)
                    LD.Add("EnterDate", Now.ToString("G"))
                    LinqTimeStudyLog.Insert(LD)
                    LD.Clear()
                Catch ex As Exception

                End Try

            ElseIf e.CommandName = "First" Then

                GridViewTimeStudy.PageIndex = 0

            ElseIf e.CommandName = "Prev" Then

                If GridViewTimeStudy.PageIndex > 0 Then
                    GridViewTimeStudy.PageIndex = GridViewTimeStudy.PageIndex - 1
                End If

            ElseIf e.CommandName = "Next" Then

                If GridViewTimeStudy.PageIndex < GridViewTimeStudy.PageCount - 1 Then
                    GridViewTimeStudy.PageIndex = GridViewTimeStudy.PageIndex + 1
                End If

            ElseIf e.CommandName = "Last" Then

                GridViewTimeStudy.PageIndex = GridViewTimeStudy.PageCount - 1

            End If

        End With

    End Sub

    Protected Sub GridViewTimeStudy_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        If CancelUpdate = True Then
            e.Cancel = True
            CancelUpdate = False
        End If

    End Sub

    Protected Sub CheckIfExists(sender As Object, e As System.EventArgs)

        Dim ddType As DropDownList = DirectCast(sender, DropDownList)
        Dim rowType As GridViewRow = DirectCast(ddType.NamingContainer, GridViewRow)
        Dim vDate As String = hfStudyDate.Value
        Dim vType As String = DirectCast(rowType.FindControl("ddPreTransplantType"), DropDownList).SelectedValue

        Try

            If vDate <> Nothing And vType <> Nothing Then
                Dim TS = From p In TPDC.tblStaffTimeStudies
                         Where p.UserId.Equals(hfLookUpUserId.Value) And p.PreTransplantDate.Equals(vDate) And p.PreTransplantType.Equals(vType)
                         Select p.UserId, p.Id

                If TS.First.Id = Nothing Then
                Else
                    DirectCast(rowType.FindControl("ddPreTransplantType"), DropDownList).SelectedIndex = 0

                    ScriptManager.RegisterStartupScript(UpdatePanelTimeStudy, UpdatePanelTimeStudy.GetType(),
                                                "MyAlert", "alert('This record already exists!');", True)
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnReport_Click(sender As Object, e As System.EventArgs) Handles btnReport.Click

        Response.Redirect("TimeStudyPageImage.aspx")

    End Sub

    Protected Sub btnSelectStudyDate_Click(sender As Object, e As System.EventArgs)

        If Page.IsValid Then

            IsInStudyDate(ddSelectStudyDate.SelectedValue)

        End If

    End Sub

    Protected Function IsInStudyDate(ByVal CkStudyDate As Integer) As String

        Try
            hfStudyDate.Value = CkStudyDate
            PanelTimeStudy.Visible = True
            PanelSelectStudyDate.Visible = False
            btnSelectStudyDateBack.Visible = True

            Dim lkp = From p In TPDC.lkpPreTransplantDates
                      Where p.Id.Equals(hfStudyDate.Value)
                      Select p.Id, p.PreTransplantDate

            lbStudyDate.Text = lkp.First.PreTransplantDate
            GridViewTimeStudy.DataBind()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Protected Sub btnSelectStudyDateBack_Click(sender As Object, e As System.EventArgs)

        PanelSelectStudyDate.Visible = True
        PanelTimeStudy.Visible = False
        btnSelectStudyDateBack.Visible = False

    End Sub

End Class
