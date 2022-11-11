<%@ Page Title="Work Orders" Language="VB" MasterPageFile="~/Pages/BackOfficeMP.master" AutoEventWireup="false" CodeFile="BackOfficeWorkOrder.aspx.vb" Inherits="Pages_BackOfficeWorkOrder" %>

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

        function setDate(obj) {
            var s = obj.value;
            var key = event.key || event.keyCode;
            if (s.length > 1 && (s.length === 2 || s.length === 5) && (key != "Backspace") && (key != "/")) {
                obj.value += '/';
            }
        }

        function setTooltip(obj) {
            obj.setAttribute('title', obj.value);
        }

        //Maintain position of Div scrollbar
        var xPos, yPos, xPosLog, yPosLog, xPosMain, yPosMain;
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('<%=divGridViewWorkOrder.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos = $get('<%=divGridViewWorkOrder.ClientID%>').scrollLeft;
                yPos = $get('<%=divGridViewWorkOrder.ClientID%>').scrollTop;
            }
            if ($get('<%=divGridViewWorkOrderLog.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPosLog = $get('<%=divGridViewWorkOrderLog.ClientID%>').scrollLeft;
                yPosLog = $get('<%=divGridViewWorkOrderLog.ClientID%>').scrollTop;
            }
        }

        function EndRequestHandler(sender, args) {
            if ($get('<%=divGridViewWorkOrder.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=divGridViewWorkOrder.ClientID%>').scrollLeft = xPos;
                $get('<%=divGridViewWorkOrder.ClientID%>').scrollTop = yPos;
            }
            if ($get('<%=divGridViewWorkOrderLog.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=divGridViewWorkOrderLog.ClientID%>').scrollLeft = xPosLog;
                $get('<%=divGridViewWorkOrderLog.ClientID%>').scrollTop = yPosLog;
            }
        }

        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

    </script>
    <asp:UpdatePanel ID="UpdatePanelWorkOrder" runat="server" ChildrenAsTriggers="True" UpdateMode="Conditional">
        <ContentTemplate>
            <br />
            <asp:Panel ID="PanelInfo" runat="server" Width="1024px" Height="160px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbInfo" runat="server" ForeColor="White" Font-Size="Large" Width="1000px" style="text-align: left;"></asp:Label>
            </asp:Panel>
            <br />

            <asp:Label ID="lbWorkOrder" runat="server" Text="Work Orders" Font-Size="X-Large" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="PanelWorkOrder" runat="server" CssClass="Panel" BackColor="#F9F9F9" class="body" DefaultButton="btnSearch">
                <br />
                <table width="1690px">
                    <tr>
                        <td style="width: 60px; height: 30px;" align="center">
                            <asp:UpdateProgress ID="UpdateProgressStudyMain" runat="server" DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                        <td style="width: 500px" align="left">&nbsp;
                            <asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorWO" runat="server" ControlToValidate="txtSearch"
                                ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="Search_Onclick" Font-Size="X-Small" />
                        </td>
                        <td align="center">
                            <asp:Label ID="lbWorkOrderText" runat="server" Text="In Progress" Font-Size="Large" Font-Bold="true" Font-Underline="True"></asp:Label>
                        </td>
                        <td style="width: 500px">&nbsp;
                        </td>
                        <td style="width: 60px">&nbsp;
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <div id="divGridViewWorkOrder" runat="server" style="overflow: auto; max-height: 250px;">
                    <asp:GridView ID="GridViewWorkOrder" runat="server" Font-Size="12px" AutoGenerateColumns="False" AllowPaging="true" HeaderStyle-CssClass="FixedHeader"
                        PageSize="150" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3"
                        ForeColor="Black" GridLines="Vertical" BorderWidth="1px" ShowHeader="True" ShowHeaderWhenEmpty="false"
                        DataKeyNames="Id" DataSourceID="SqlWorkOrders" ShowFooter="False" EnableViewState="True"
                        OnRowCommand="GridViewWorkOrder_RowCommand"
                        OnRowDataBound="GridViewWorkOrder_RowDataBound"
                        OnPageIndexChanging="GridViewWorkOrder_PageIndexChanging">
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-Height="95px" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="WorkOrders" CommandName="Add" ToolTip="Add New Work Order" Font-Size="8px" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/EditFile.png" CausesValidation="false"
                                        CommandName="Edit" ToolTip="Edit Information." Width="17px" Height="17px" />
                                    &nbsp;
                                 <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/DeleteFile.png" CausesValidation="False"
                                     CommandName="DeleteRow" ToolTip="Delete Information." Width="17px" Height="17px"
                                     OnClientClick="return confirm('Are you sure you want to Delete this File?');" />
                                    <br />
                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false" Width="50px"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/Images/SaveFile.gif" ValidationGroup="WorkOrdersEdit"
                                        CommandName="UpdateRow" ToolTip="Update Information." Width="17px"
                                        Height="17px" />
                                    &nbsp;
                                <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/Images/CancelFile.gif"
                                    CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update." Width="17px"
                                    Height="17px" />
                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkTicketNumber" runat="server" Text="Ticket#" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtTicketNumber" runat="server" MaxLength="50" CssClass="TicketNumber"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTicketNumber" ValidationGroup="WorkOrders"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbTicketNumber" runat="server" Text='<%# Eval("TicketNumber") %>' CssClass="TicketNumber"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTicketNumber" runat="server" Text='<%# Eval("TicketNumber") %>' MaxLength="50" CssClass="TicketNumber"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTicketNumber" ValidationGroup="WorkOrdersEdit"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="122px" ItemStyle-Width="122px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkType" runat="server" Text="Type" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddType" runat="server" DataTextField="Type" DataValueField="Id" CssClass="Type"
                                        DataSourceID="LinqWorkOrdersType" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddType" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select a Type!" ValidationGroup="WorkOrders"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbType" runat="server" Text='<%# Eval("Type") %>' CssClass="Type"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddType" runat="server" DataTextField="Type" DataValueField="Id" CssClass="Type" SelectedValue='<%# Bind("TypeId") %>'
                                        DataSourceID="LinqWorkOrdersType" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddType" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select a Type!" ValidationGroup="WorkOrdersEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="202px" ItemStyle-Width="202px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkDescription" runat="server" Text="Description" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="Description" onkeydown="setTooltip(this);"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Enter a Description!" ValidationGroup="WorkOrders"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDescription" ValidationGroup="WorkOrders"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; width: 200px; height: 60px;">
                                        <asp:Label ID="lbDescription" runat="server" Text='<%# Eval("Description") %>' ToolTip='<%# Eval("Description") %>' CssClass="Description"></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>' TextMode="MultiLine" Rows="8" CssClass="Description" onkeydown="setTooltip(this);" ToolTip='<%# Eval("Description") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Enter a Description!" ValidationGroup="WorkOrdersEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDescription" ValidationGroup="WorkOrdersEdit"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="110px" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkCreatedBy" runat="server" Text="Created By" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddCreatedBy" runat="server" DataTextField="Name" DataValueField="Id" CssClass="CreatedBy"
                                        DataSourceID="LinqWorkOrderUsers" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCreatedBy" runat="server" ControlToValidate="ddCreatedBy" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select a Created By!" ValidationGroup="WorkOrders"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbCreatedBy" runat="server" Text='<%# Eval("Name") %>' CssClass="CreatedBy"></asp:Label>
                                    <asp:Label ID="lbCreatedById" runat="server" Text='<%# Eval("CreatedBy") %>' CssClass="CreatedBy" Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddCreatedBy" runat="server" DataTextField="Name" DataValueField="Id" CssClass="CreatedBy" SelectedValue='<%# Eval("CreatedBy") %>'
                                        DataSourceID="LinqWorkOrderUsers" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCreatedBy" runat="server" ControlToValidate="ddCreatedBy" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select a Created By!" ValidationGroup="WorkOrdersEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="122px" ItemStyle-Width="122px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkStatus" runat="server" Text="Status" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddStatus" runat="server" DataTextField="Status" DataValueField="Id" CssClass="Status" OnSelectedIndexChanged="IsCompletedClosed_Selected"
                                        DataSourceID="LinqWorkOrdersStatus" AppendDataBoundItems="True" AutoPostBack="true">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddStatus" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select a Status!" ValidationGroup="WorkOrders"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbStatus" runat="server" Text='<%# Eval("Status") %>' CssClass="Status"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddStatusEdit" runat="server" DataTextField="Status" DataValueField="Id" CssClass="Status" SelectedValue='<%# Eval("StatusId") %>'
                                        DataSourceID="LinqWorkOrdersStatus" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="IsCompletedClosed_Selected">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvStatusEdit" runat="server" ControlToValidate="ddStatusEdit" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select a Status!" ValidationGroup="WorkOrdersEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkDateRequested" runat="server" Text="Date<br />Requested" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtDateRequested" runat="server" MaxLength="10" CssClass="DateRequested" onkeydown="setDate(this);"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDateRequested" runat="server" ControlToValidate="txtDateRequested" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Enter a Date Requested!" ValidationGroup="WorkOrders"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rvDateRequested" runat="server" ControlToValidate="txtDateRequested" ValidationGroup="WorkOrders" Display="Dynamic"
                                        ErrorMessage="Checked Out Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="1/1/3000" MinimumValue="1/1/1900"></asp:RangeValidator>
                                    <ajax:CalendarExtender ID="ceDateRequested" runat="server" TargetControlID="txtDateRequested" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajax:TextBoxWatermarkExtender ID="tbweDateRequested" runat="server" TargetControlID="txtDateRequested"
                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbDateRequested" runat="server" Text='<%# Eval("DateRequested", "{0:MM/dd/yyyy}") %>' CssClass="DateRequested"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDateRequested" runat="server" Text='<%# Eval("DateRequested", "{0:MM/dd/yyyy}") %>' MaxLength="10" CssClass="DateRequested" onkeydown="setDate(this);"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDateRequested" runat="server" ControlToValidate="txtDateRequested" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Enter a Date Requested!" ValidationGroup="WorkOrdersEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rvDateRequested" runat="server" ControlToValidate="txtDateRequested" ValidationGroup="WorkOrdersEdit" Display="Dynamic"
                                        ErrorMessage="Checked Out Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="1/1/3000" MinimumValue="1/1/1900"></asp:RangeValidator>
                                    <ajax:CalendarExtender ID="ceDateRequested" runat="server" TargetControlID="txtDateRequested" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajax:TextBoxWatermarkExtender ID="tbweDateRequested" runat="server" TargetControlID="txtDateRequested"
                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkDateCompleted" runat="server" Text="Date<br />Completed" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtDateCompleted" runat="server" MaxLength="10" CssClass="DateCompleted" onkeydown="setDate(this);"></asp:TextBox>
                                    <asp:RangeValidator ID="rvDateCompleted" runat="server" ControlToValidate="txtDateCompleted" ValidationGroup="WorkOrders" Display="Dynamic"
                                        ErrorMessage="Checked Out Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="1/1/3000" MinimumValue="1/1/1900"></asp:RangeValidator>
                                    <ajax:CalendarExtender ID="ceDateCompleted" runat="server" TargetControlID="txtDateCompleted" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajax:TextBoxWatermarkExtender ID="tbweDateCompleted" runat="server" TargetControlID="txtDateCompleted"
                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="rfvDateCompleted" runat="server" ControlToValidate="txtDateCompleted" ForeColor="Red" Enabled="false"
                                        Display="Dynamic" ErrorMessage="Please Enter a Date Completed!" ValidationGroup="WorkOrders"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbDateCompleted" runat="server" Text='<%# Eval("DateCompleted", "{0:MM/dd/yyyy}") %>' CssClass="DateCompleted"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDateCompleted" runat="server" Text='<%# Eval("DateCompleted", "{0:MM/dd/yyyy}") %>' MaxLength="10" CssClass="DateCompleted" onkeydown="setDate(this);"></asp:TextBox>
                                    <asp:RangeValidator ID="rvDateCompleted" runat="server" ControlToValidate="txtDateCompleted" ValidationGroup="WorkOrdersEdit" Display="Dynamic"
                                        ErrorMessage="Checked Out Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="1/1/3000" MinimumValue="1/1/1900"></asp:RangeValidator>
                                    <ajax:CalendarExtender ID="ceDateCompleted" runat="server" TargetControlID="txtDateCompleted" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajax:TextBoxWatermarkExtender ID="tbweDateCompleted" runat="server" TargetControlID="txtDateCompleted"
                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="rfvDateCompletedEdit" runat="server" ControlToValidate="txtDateCompleted" ForeColor="Red" Enabled="false"
                                        Display="Dynamic" ErrorMessage="Please Enter a Date Completed!" ValidationGroup="WorkOrdersEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkDateClosed" runat="server" Text="Date<br />Closed" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtDateClosed" runat="server" MaxLength="10" CssClass="DateClosed" onkeydown="setDate(this);"></asp:TextBox>
                                    <asp:RangeValidator ID="rvDateClosed" runat="server" ControlToValidate="txtDateClosed" ValidationGroup="WorkOrders" Display="Dynamic"
                                        ErrorMessage="Checked Out Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="1/1/3000" MinimumValue="1/1/1900"></asp:RangeValidator>
                                    <ajax:CalendarExtender ID="ceDateClosed" runat="server" TargetControlID="txtDateClosed" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajax:TextBoxWatermarkExtender ID="tbweDateClosed" runat="server" TargetControlID="txtDateClosed"
                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="rfvDateClosed" runat="server" ControlToValidate="txtDateClosed" ForeColor="Red" Enabled="false"
                                        Display="Dynamic" ErrorMessage="Please Enter a Date Closed!" ValidationGroup="WorkOrders"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbDateClosed" runat="server" Text="" CssClass="DateClosed"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDateClosed" runat="server" MaxLength="10" CssClass="DateClosed" onkeydown="setDate(this);"></asp:TextBox>
                                    <asp:RangeValidator ID="rvDateClosed" runat="server" ControlToValidate="txtDateClosed" ValidationGroup="WorkOrdersEdit" Display="Dynamic"
                                        ErrorMessage="Checked Out Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="1/1/3000" MinimumValue="1/1/1900"></asp:RangeValidator>
                                    <ajax:CalendarExtender ID="ceDateClosed" runat="server" TargetControlID="txtDateClosed" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajax:TextBoxWatermarkExtender ID="tbweDateClosed" runat="server" TargetControlID="txtDateClosed"
                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="rfvDateClosedEdit" runat="server" ControlToValidate="txtDateClosed" ForeColor="Red" Enabled="false"
                                        Display="Dynamic" ErrorMessage="Please Enter a Date Closed!" ValidationGroup="WorkOrdersEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="202px" ItemStyle-Width="202px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkNotes" runat="server" Text="Notes" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="3" CssClass="Notes" onkeydown="setTooltip(this);"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNotes" ValidationGroup="WorkOrders"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; width: 200px; height: 60px;">
                                        <asp:Label ID="lbNotes" runat="server" Text='<%# Eval("Notes") %>' ToolTip='<%# Eval("Notes") %>' CssClass="Notes"></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNotes" runat="server" Text='<%# Eval("Notes") %>' TextMode="MultiLine" Rows="8" CssClass="Notes" onkeydown="setTooltip(this);" ToolTip='<%# Eval("Notes") %>'></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNotes" ValidationGroup="WorkOrdersEdit"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="102px" ItemStyle-Width="102px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkRevenueCode" runat="server" Text="RC#" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddRevenueCode" runat="server" DataTextField="RevenueCode" DataValueField="Id" CssClass="RevenueCode"
                                        DataSourceID="LinqRevenueCode" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbRevenueCode" runat="server" Text='<%# Eval("RevenueCode") %>' BorderWidth="0px" CssClass="RevenueCode"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddRevenueCode" runat="server" DataTextField="RevenueCode" DataValueField="Id" CssClass="RevenueCode" SelectedValue='<%# Eval("RevenueCodeId") %>'
                                        DataSourceID="LinqRevenueCode" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkRequisitionNumber" runat="server" Text="Requisition#" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtRequisitionNumber" runat="server" MaxLength="50" TextMode="MultiLine" Rows="3" CssClass="RequisitionNumber" onkeydown="setTooltip(this);"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRequisitionNumber" ValidationGroup="WorkOrders"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; width: 70px; height: 60px;">
                                        <asp:Label ID="lbRequisitionNumber" runat="server" Text='<%# Eval("RequisitionNumber") %>' ToolTip='<%# Eval("RequisitionNumber") %>' CssClass="RequisitionNumber"></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRequisitionNumber" runat="server" Text='<%# Eval("RequisitionNumber") %>' MaxLength="50" TextMode="MultiLine" Rows="8" CssClass="RequisitionNumber"
                                        onkeydown="setTooltip(this);" ToolTip='<%# Eval("RequisitionNumber") %>'></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRequisitionNumber" ValidationGroup="WorkOrdersEdit"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkREQAPP" runat="server" Text="REQ/APP" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtREQAPP" runat="server" MaxLength="250" TextMode="MultiLine" Rows="3" CssClass="REQAPP" onkeydown="setTooltip(this);"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtREQAPP" ValidationGroup="WorkOrders"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; width: 50px; height: 60px;">
                                        <asp:Label ID="lbREQAPP" runat="server" Text='<%# Eval("REQAPP") %>' ToolTip='<%# Eval("REQAPP") %>' CssClass="REQAPP"></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtREQAPP" runat="server" Text='<%# Eval("REQAPP") %>' MaxLength="250" TextMode="MultiLine" Rows="8" CssClass="REQAPP"
                                        onkeydown="setTooltip(this);" ToolTip='<%# Eval("REQAPP") %>'></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtREQAPP" ValidationGroup="WorkOrdersEdit"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkCost" runat="server" Text="Cost" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtCost" runat="server" MaxLength="50" CssClass="Cost"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtCost" ValidationGroup="WorkOrders"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbCost" runat="server" Text='<%# Eval("Cost") %>' CssClass="Cost"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCost" runat="server" Text='<%# Eval("Cost") %>' MaxLength="50" CssClass="Cost"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtCost" ValidationGroup="WorkOrdersEdit"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="110px" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkContact" runat="server" Text="Contact" OnClick="WorkOrderSort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtContact" runat="server" MaxLength="250" TextMode="MultiLine" Rows="3" CssClass="Contact" onkeydown="setTooltip(this);"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtContact" ValidationGroup="WorkOrders"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; height: 60px;">
                                        <asp:Label ID="lbContact" runat="server" Text='<%# Eval("Contact") %>' ToolTip='<%# Eval("Contact") %>' CssClass="Contact"></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtContact" runat="server" Text='<%# Eval("Contact") %>' MaxLength="250" TextMode="MultiLine" Rows="8" CssClass="Contact"
                                        onkeydown="setTooltip(this);" ToolTip='<%# Eval("Contact") %>'></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtContact" ValidationGroup="WorkOrdersEdit"
                                        ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                        ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#FFEAD5" Font-Bold="True" />
                        <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Black" BorderWidth="2px" />
                        <RowStyle HorizontalAlign="Center" BackColor="White" />
                        <AlternatingRowStyle BackColor="#f0f0f0" />
                    </asp:GridView>
                </div>
                <br />
                <asp:ValidationSummary ID="ValidationSummaryWorkOrders" runat="server" ShowMessageBox="True" ShowSummary="True" ForeColor="Red"
                    HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="WorkOrders" DisplayMode="List" />
                <asp:ValidationSummary ID="ValidationSummaryWorkOrdersEdit" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                    HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="WorkOrdersEdit" DisplayMode="List" />
                <hr />
                <asp:Label ID="lbWorkOrderMessage" runat="server" Text=""></asp:Label>
                <br />
            </asp:Panel>
            <br />
            <br />
            <asp:Panel ID="PanelWorkOrderLogShow" runat="server" CssClass="Panel" BackColor="#F9F9F9" class="body">
                <br />
                <table width="1700px">
                    <tr>
                        <td style="width: 60px; height: 30px;" align="center">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="linkWorkOrderShow" runat="server" Text="Show Closed Work Orders" Font-Names="Ariel" Font-Size="Large" Font-Bold="true" OnClick="ShowHideClosedWorkOrders_OnClick"></asp:LinkButton>
                        </td>
                        <td style="width: 60px">&nbsp;
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
            <asp:Panel ID="PanelWorkOrderLog" runat="server" CssClass="Panel" BackColor="#F9F9F9" class="body" Visible="False" DefaultButton="btnSearchLog">
                <br />
                <table width="1680px">
                    <tr>
                        <td style="width: 60px; height: 30px;" align="center">
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                        <td style="width: 500px" align="left">&nbsp;
                            <asp:TextBox ID="txtSearchLog" runat="server" Width="200px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorWOL" runat="server" ControlToValidate="txtSearchLog"
                                ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                            <asp:Button ID="btnSearchLog" runat="server" Text="Search" OnClick="SearchLog_Onclick" Font-Size="X-Small" />
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="linkWorkOrderHide" runat="server" Text="Hide Closed Work Orders" Font-Names="Ariel" Font-Size="Large" Font-Bold="true" OnClick="ShowHideClosedWorkOrders_OnClick"></asp:LinkButton>
                        </td>
                        <td style="width: 500px">&nbsp;
                        </td>
                        <td style="width: 60px">&nbsp;
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <div id="divGridViewWorkOrderLog" runat="server" style="overflow: auto; height: 300px;">
                    <asp:GridView ID="GridViewWorkOrderLog" runat="server" Font-Size="12px" AutoGenerateColumns="False" AllowPaging="true" HeaderStyle-CssClass="FixedHeaderLog"
                        PageSize="200" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3"
                        ForeColor="Black" GridLines="Vertical" BorderWidth="1px" ShowHeader="True" ShowHeaderWhenEmpty="false"
                        DataKeyNames="Id" DataSourceID="SqlWorkOrdersLog" ShowFooter="False" EnableViewState="True"
                        OnRowDataBound="GridViewWorkOrderLog_RowDataBound"
                        OnRowCommand="GridViewWorkOrderLog_RowCommand"
                        OnPageIndexChanging="GridViewWorkOrderLog_PageIndexChanging">
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="30px" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnRestore" runat="server" ImageUrl="~/Images/RestoreFile.png" CausesValidation="false"
                                        CommandName="Restore" ToolTip="Restore the Work Order" Width="22px" Height="17px" OnClientClick="return confirm('Are you sure you want to Restore this File?');" />
                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkTicketNumber" runat="server" Text="Ticket#" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbTicketNumber" runat="server" Text='<%# Eval("TicketNumber") %>' CssClass="TicketNumberLog"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkType" runat="server" Text="Type" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbType" runat="server" Text='<%# Eval("Type") %>' CssClass="TypeLog"></asp:Label>
                                    <asp:Label ID="lbTypeId" runat="server" Text='<%# Eval("TypeId") %>' CssClass="TypeLog" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="290px" ItemStyle-Width="290px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkDescription" runat="server" Text="Description" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; width: 280px; height: 60px;">
                                        <asp:Label ID="lbDescription" runat="server" Text='<%# Bind("Description") %>' ToolTip='<%# Eval("Description") %>'
                                            CssClass="DescriptionLog"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkCreatedBy" runat="server" Text="Created By" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbCreatedBy" runat="server" Text='<%# Eval("Name") %>' CssClass="CreatedByLog"></asp:Label>
                                    <asp:Label ID="lbCreatedById" runat="server" Text='<%# Eval("CreatedBy") %>' CssClass="CreatedByLog" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkStatus" runat="server" Text="Status" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbStatus" runat="server" Text='<%# Eval("Status") %>' CssClass="StatusLog"></asp:Label>
                                    <asp:Label ID="lbStatusId" runat="server" Text='<%# Eval("StatusId") %>' CssClass="StatusLog" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkDateRequested" runat="server" Text="Date<br />Requested" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbDateRequested" runat="server" Text='<%# Eval("DateRequested", "{0:MM/dd/yyyy}") %>' CssClass="DateRequested"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="70px" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkDateCompleted" runat="server" Text="Date<br />Completed" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbDateCompleted" runat="server" Text='<%# Eval("DateCompleted", "{0:MM/dd/yyyy}") %>' CssClass="DateCompletedLog"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkDateClosed" runat="server" Text="Date<br />Closed" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbDateClosed" runat="server" Text='<%# Eval("DateClosed", "{0:MM/dd/yyyy}") %>' CssClass="DateClosed"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="290px" ItemStyle-Width="290px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkNotes" runat="server" Text="Notes" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; width: 280px; height: 60px;">
                                        <asp:Label ID="lbNotes" runat="server" Text='<%# Eval("Notes") %>' ToolTip='<%# Eval("Notes") %>'
                                            CssClass="NotesLog"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkRevenueCode" runat="server" Text="RC#" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbRevenueCode" runat="server" Text='<%# Eval("RevenueCode") %>' CssClass="RevenueCode"></asp:Label>
                                    <asp:Label ID="lbRevenueCodeId" runat="server" Text='<%# Eval("RevenueCodeId") %>' CssClass="RevenueCode" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkRequisitionNumber" runat="server" Text="Requisition#" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; height: 60px;">
                                        <asp:Label ID="lbRequisitionNumber" runat="server" Text='<%# Bind("RequisitionNumber") %>' ToolTip='<%# Eval("RequisitionNumber") %>'
                                            CssClass="RequisitionNumber"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkREQAPP" runat="server" Text="REQ/APP" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; height: 60px;">
                                        <asp:Label ID="lbREQAPP" runat="server" Text='<%# Bind("REQAPP") %>' ToolTip='<%# Eval("REQAPP") %>'
                                            CssClass="REQAPP"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkCost" runat="server" Text="Cost" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbCost" runat="server" Text='<%# Eval("Cost") %>' CssClass="Cost"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="110px" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkContact" runat="server" Text="Contact" OnClick="WorkOrderLogSort_Onclick"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="overflow: auto; height: 60px;">
                                        <asp:Label ID="lbContact" runat="server" Text='<%# Bind("Contact") %>' ToolTip='<%# Eval("Contact") %>'
                                            CssClass="Contact"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#FFEAD5" Font-Bold="True" />
                        <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Black" BorderWidth="2px" />
                        <RowStyle HorizontalAlign="Center" BackColor="White" />
                        <AlternatingRowStyle BackColor="#f0f0f0" />
                    </asp:GridView>
                </div>
                <hr />
                <br />
            </asp:Panel>
            <asp:LinqDataSource ID="LinqWorkOrders" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="tblBackOfficeWorkOrders"
                EnableInsert="true" EnableUpdate="true" EnableDelete="true">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqWorkOrdersLog" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="tblBackOfficeWorkOrdersLogs"
                EnableInsert="true" EnableDelete="true">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqWorkOrdersType" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="lkpBackOfficeWorkOrderTypes" Select="new(Id, Type)" Where="Active==True">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqWorkOrdersStatus" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="lkpBackOfficeWorkOrderStatus" Select="new(Id, Status)" Where="Active==True">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqWorkOrderUsers" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="lkpBackOfficeWorkOrderUsers" Select="new(Id, (tblStaff.FName + ' ' + tblStaff.LName) AS Name)"
                Where="Active==True" OrderBy="tblStaff.FName, tblStaff.LName">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqRevenueCode" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="lkpRevenueCodes" Select="new(Id, ('(' & Id & ')' & ' ' & RevenueCode) AS RevenueCode)">
            </asp:LinqDataSource>
            <asp:SqlDataSource ID="SqlWorkOrders" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlWorkOrdersLog" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
            <br />
            <asp:Button ID="btnReturn" Text="Return to Menu" runat="server" Font-Size="Small"
                CausesValidation="False" UseSubmitBehavior="False" ToolTip="Return to Menu" />
            <br />
            <asp:HiddenField ID="hfUser" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfBack" runat="server" />
            <asp:HiddenField ID="hfFrom" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridViewWorkOrder" EventName="RowCommand" />
            <asp:AsyncPostBackTrigger ControlID="GridViewWorkOrderLog" EventName="RowCommand" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
