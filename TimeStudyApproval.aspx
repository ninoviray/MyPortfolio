<%@ Page Title="Time Study Approval" Language="VB" MasterPageFile="~/Pages/TimeStudyMP.master" AutoEventWireup="false" CodeFile="TimeStudyApproval.aspx.vb" Inherits="Pages_TimeStudyApproval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <script type="text/javascript">
        window.scrollTo = function (x, y) {
            return true;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanelTimeStudyApprovalMain" runat="server" ChildrenAsTriggers="True" UpdateMode="Conditional">
        <ContentTemplate>
            <br />
            <asp:Panel ID="PanelTimeStudyInfo" runat="server" Width="1050px" Height="180px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbTimeStudyInfo" runat="server" ForeColor="White" Font-Size="Large" Width="1020px" style="text-align: left;"></asp:Label>
            </asp:Panel>
            <br />
            <asp:Panel ID="PanelTimeStudyDate" runat="server" Width="1024px" BackColor="#F9F9F9" class="body" BorderColor="LightGray" BorderWidth="1px">
                <table width="1024px">
                    <tr>
                        <th style="width: 55px; height: 40px">
                            <div align="center">
                                <asp:UpdateProgress ID="UpdateProgressTimeStudyDate" runat="server" DisplayAfter="0">
                                    <ProgressTemplate>
                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </th>
                        <th style="width: 200px;">&nbsp;
                        </th>
                        <th>
                            <asp:Label ID="lbViewTheTimeStudyForm" runat="server" Text="" Font-Size="Large" Font-Bold="true" 
                                ToolTip="View the Time Study Approval Form."></asp:Label>
                        </th>
                        <th style="width: 200px;">
                            <asp:DropDownList ID="ddyear" runat="server" ValidationGroup="Year" Visible="false" 
                                DataSourceID="SqlTransplantDate" DataTextField="dateyear"
                                AppendDataBoundItems="True" ToolTip="Select a Date to View the Yearly Report.">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btnYearlyReport" runat="server" Text="Yearly Report" OnClick="btnYearlyReport_Click" Font-Size="Smaller" 
                                ToolTip="View the Yearly Time Study." Visible="false" ValidationGroup="Year" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select a Year!"
                                ControlToValidate="ddyear" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="Year"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                            <asp:Button ID="btnReminder" runat="server" Text="Send Upcoming Reminder" OnClick="btnReminder_Click" Font-Size="Smaller"
                                ToolTip="Send a Reminder eMail to All Required Staff about Upcoming Time Study." Visible="False"/>
                            <ajax:ConfirmButtonExtender ID="CBEReminder" runat="server" TargetControlID="btnReminder" 
                                ConfirmText="Are you Sure You Want to Continue?" />
                            <br />
                            <br />
                            <asp:Button ID="btnDelinquent" runat="server" Text="Send Delinquent Reminder" OnClick="btnDelinquent_Click" Font-Size="Smaller"
                                ToolTip="Send a Reminder eMail to All Required Staff about Deliquent Time Study." Visible="False"/>
                            <ajax:ConfirmButtonExtender ID="CBEDelinquent" runat="server" TargetControlID="btnDelinquent" 
                                ConfirmText="Are you sure you want to continue?" />
                        </th>
                        <th style="width: 55px; height: 40px">&nbsp;
                        </th>
                    </tr>
                    <tr>
                        <th colspan="5">
                            <asp:Label ID="lbStudyDateText" runat="server" Text="Study Date:"></asp:Label>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSelectStudyDate" runat="server" ErrorMessage="Please Select a Study Date!"
                                ControlToValidate="ddStudyDate" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="Date"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddStudyDate" runat="server" DataSourceID="LinqPreTransplantStudyDate" ValidationGroup="Date"
                                AppendDataBoundItems="True" DataTextField="PreTransplantDate"
                                DataValueField="Id" ToolTip="Select a Date to View the Time Study Approvals.">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            &emsp;
                            <asp:Button ID="btnStudyDate" runat="server" Text="View Approvals" OnClick="btnStudyDate_Click" 
                                ToolTip="View the Time Study Approval List." ValidationGroup="Date" />
                        </th>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
                <br />
            </asp:Panel>
            <asp:Panel ID="PanelTimeStudyApproval" runat="server" Width="1024px" BackColor="#F9F9F9" class="body" BorderColor="LightGray" BorderWidth="1px" Visible="false">
                <asp:UpdatePanel ID="UpdatePanelTimeStudyApproval" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="1024px">
                            <tr>
                                <th style="width: 55px; height: 40px">
                                    <div align="center">
                                        <asp:UpdateProgress ID="UpdateProgressTimeStudyApproval" runat="server" DisplayAfter="0" 
                                            AssociatedUpdatePanelID="UpdatePanelTimeStudyApproval">
                                            <ProgressTemplate>
                                                <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </th>
                                <th align="center" style="width: 200px">
                                    <asp:Label ID="lbStudyDateApprovalText" runat="server" Text="Study Date:"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="lbStudyDate" runat="server" Text=""></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="lbTitle" runat="server" Text="" Font-Size="Large" Font-Bold="true" 
                                        ToolTip="View the Time Study Approval Form."></asp:Label>
                                </th>
                                <th align="center" style="width: 200px">&nbsp;
                                </th>
                                <th style="width: 55px; height: 40px">&nbsp;
                                </th>
                            </tr>
                        </table>
                        <asp:GridView ID="GridViewTimeStudy" runat="server"
                            DataSourceID="SQLTimeStudy" DataKeyNames="UserId" 
                            Font-Size="12px" Width="1024px" AutoGenerateColumns="False"
                            PageSize="30" CellPadding="3"
                            ForeColor="Black" GridLines="None" ShowHeader="True"
                            OnRowCommand="GridViewTimeStudy_RowCommand"
                            OnRowDataBound="GridViewTimeStudy_RowDataBound"
                            OnPageIndexChanging="GridViewTimeStudy_PageIndexChanging"
                            ShowFooter="False" AllowPaging="True">
                            <RowStyle BackColor="#f0f0f0" />
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" 
                                    FooterStyle-HorizontalAlign="Center" Visible="false">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbUserIdText" runat="server" Text="UserId"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbUserId" runat="server" Text='<%# Bind("UserId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbNameText" runat="server" Text="Name"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbDateText" runat="server" Text="Week Of Date"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbDate" runat="server" Text='<%# Bind("PreTransplantDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbTotalHoursText" runat="server" Text="Total Hours"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbTotalHours" runat="server" Text='<%# Bind("TotalHours") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbReportText" runat="server" Text="Report"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkViewReport" runat="server" Text="View Report" CommandName="Report"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbStatusLogText" runat="server" Text="Status Log"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbStatusLog" runat="server" Text='<%# Bind("StatusLog") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbStatusText" runat="server" Text="Status"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbApprovalText" runat="server" Text="Approval"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <th align="left">
                                                    <asp:CheckBox ID="cbApprove" runat="server" Text="Approve" OnCheckedChanged="cbApprove_Checked" AutoPostBack="true" />
                                                </th>
                                            </tr>
                                            <tr>
                                                <th align="left">
                                                    <asp:CheckBox ID="cbDisapprove" runat="server" Text="Disapprove" OnCheckedChanged="cbDisapprove_Checked" AutoPostBack="true" />
                                                </th>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Center" BackColor="#f0f0f0" />
                            <AlternatingRowStyle BackColor="#F9F9F9" />
                            <HeaderStyle Font-Bold="true" Font-Underline="true" BackColor="WhiteSmoke" />
                        </asp:GridView>
                        <br />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridViewTimeStudy" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="GridViewTimeStudy" EventName="PageIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridViewTimeStudy" EventName="PageIndexChanging" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:ValidationSummary ID="ValSum1" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="Date" />
            <asp:ValidationSummary ID="ValSum2" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="Year" />
            <br />
            <asp:Button ID="btnSelectStudyDateBack" Text="Select Another Time Study Date" runat="server" Font-Size="Medium"
                OnClick="btnSelectStudyDateBack_Click" Visible="false"
                ToolTip="Closes Current Time Study to Select Another Time Study Date." />
            &emsp;
            <br />
            <asp:SqlDataSource ID="SQLTimeStudy" runat="server" ConnectionString="<%$ connectionStrings:MyPortfolioConnectionString%>" 
                SelectCommand="SELECT staff.UserId, staff.LName + ', ' + staff.FName AS Name, ts.Status, ts.StatusLog, ts.TotalHours, ts.PreTransplantDate, tsd.PreTransplantDate FROM tblStaff AS staff LEFT OUTER JOIN tblStaffTimeStudy AS ts ON staff.UserId = ts.UserId LEFT OUTER JOIN lkpPreTransplantDate AS tsd ON tsd.Id = ts.PreTransplantDate ORDER BY staff.LName, staff.FName"></asp:SqlDataSource>
            <asp:LinqDataSource ID="LinqPreTransplantStudyDate" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" OrderBy="Id" TableName="lkpPreTransplantDates" Where="Active=True">
            </asp:LinqDataSource>
            <asp:SqlDataSource ID="SqlTransplantDate" runat="server" ConnectionString="<%$ connectionStrings:MyPortfolioConnectionString%>"
                SelectCommand="SELECT YEAR(PreTransplantDate) AS dateyear FROM lkpPreTransplantDate GROUP BY YEAR(PreTransplantDate) ORDER BY dateyear DESC"></asp:SqlDataSource>
             <asp:SqlDataSource ID="SQLReminder" runat="server" ConnectionString="<%$ connectionStrings:MyPortfolioConnectionString%>"
                SelectCommand=""></asp:SqlDataSource>
            <asp:HiddenField ID="hfUser" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfLookUpUserId" runat="server" />
            <asp:HiddenField ID="hfLookUpUserName" runat="server" />
            <asp:HiddenField ID="hfBack" runat="server" />
            <asp:HiddenField ID="hfFrom" runat="server" />
            <asp:HiddenField ID="hfStudyDate" runat="server" />
            <asp:HiddenField ID="hfUserType" runat="server" />
            <asp:HiddenField ID="hfDateText" runat="server" />
            <asp:HiddenField ID="hfMyUserQuery" runat="server" />
            <asp:HiddenField ID="hfYear" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
