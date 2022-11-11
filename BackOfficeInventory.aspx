<%@ Page Title="Inventory" Language="VB" MasterPageFile="~/Pages/BackOfficeMP.master" AutoEventWireup="false" CodeFile="BackOfficeInventory.aspx.vb" Inherits="PagesStaff_BackOfficeInventory" %>
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

        function setCheckOutDate() {
            var pt = document.getElementById('ctl00_ContentPlaceHolder1_TabContainerInventory_TabPanelCheckOut_GridViewCheckOut_ctl01_txtCheckedOutDate');
            var s = "0";
            s = pt.value;
            var key = event.key || event.keyCode;
            if (s.length > 1 && (s.length === 2 || s.length === 5) && (key != "Backspace") && (key != "/")) {
                pt.value += '/';
            }
        }

        function setReturnDate() {
            var pt = document.getElementById('ctl00_ContentPlaceHolder1_TabContainerInventory_TabPanelCheckOut_GridViewCheckOut_ctl01_txtReturnDate');
            var s = "0";
            s = pt.value;
            var key = event.key || event.keyCode;
            if (s.length > 1 && (s.length === 2 || s.length === 5) && (key != "Backspace") && (key != "/")) {
                pt.value += '/';
            }
        }

        function Tab_SelectionChanged(sender, e) {
            document.getElementById('<%=hfTabIndex.ClientID %>').value = sender.get_activeTabIndex();
        }

        function setHyphensFax() {
            var pt = document.getElementById('ctl00_ContentPlaceHolder1_TabContainerInventory_TabPanelPrinters_GridViewPrintersInventory_ctl01_txtFaxNumber');
            var s = "0";
            s = pt.value;
            var key = event.key || even.keyCode;
            if (s.length > 1 && (s.length === 3 || s.length === 7) && (key != "Backspace") && (key != "-")) {
                pt.value += '-';
            }
        }

       //Maintain position of Div scrollbar
        var xPosCheckOut, yPosCheckOut, xPosHotspots, yPosHotspots, xPosLaptops, yPosLaptops, xPosMisc, yPosMisc, xPosPC, yPosPC, xPosPrinter, yPosPrinter, xPosOverview, yPosOverview;
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('<%=divCheckOut.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPosCheckOut = $get('<%=divCheckOut.ClientID%>').scrollLeft;
                yPosCheckOut = $get('<%=divCheckOut.ClientID%>').scrollTop;
            }
            if ($get('<%=divHotspots.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPosHotspots = $get('<%=divHotspots.ClientID%>').scrollLeft;
                yPosHotspots = $get('<%=divHotspots.ClientID%>').scrollTop;
            }
            if ($get('<%=divLaptops.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPosLaptops = $get('<%=divLaptops.ClientID%>').scrollLeft;
                yPosLaptops = $get('<%=divLaptops.ClientID%>').scrollTop;
            }
            if ($get('<%=divGridViewMiscellaneousInventory.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPosMisc = $get('<%=divGridViewMiscellaneousInventory.ClientID%>').scrollLeft;
                yPosMisc = $get('<%=divGridViewMiscellaneousInventory.ClientID%>').scrollTop;
            }
            if ($get('<%=divGridViewPCsInventory.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPosPC = $get('<%=divGridViewPCsInventory.ClientID%>').scrollLeft;
                yPosPC = $get('<%=divGridViewPCsInventory.ClientID%>').scrollTop;
            }
            if ($get('<%=divGridViewPrintersInventory.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPosPrinter = $get('<%=divGridViewPrintersInventory.ClientID%>').scrollLeft;
                yPosPrinter = $get('<%=divGridViewPrintersInventory.ClientID%>').scrollTop;
            }
            if ($get('<%=divGridViewOverview.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPosOverview = $get('<%=divGridViewOverview.ClientID%>').scrollLeft;
                yPosOverview = $get('<%=divGridViewOverview.ClientID%>').scrollTop;
            }
        }

        function EndRequestHandler(sender, args) {
            if ($get('<%=divCheckOut.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=divCheckOut.ClientID%>').scrollLeft = xPosCheckOut;
                $get('<%=divCheckOut.ClientID%>').scrollTop = yPosCheckOut;
            }
            if ($get('<%=divHotspots.ClientID%>') != null) {
             // Set X and Y positions back to the scrollbar
             // after partial postback
                $get('<%=divHotspots.ClientID%>').scrollLeft = xPosHotspots;
                $get('<%=divHotspots.ClientID%>').scrollTop = yPosHotspots;
            }
            if ($get('<%=divLaptops.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=divLaptops.ClientID%>').scrollLeft = xPosLaptops;
                $get('<%=divLaptops.ClientID%>').scrollTop = yPosLaptops;
            }
            if ($get('<%=divGridViewMiscellaneousInventory.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=divGridViewMiscellaneousInventory.ClientID%>').scrollLeft = xPosMisc;
                $get('<%=divGridViewMiscellaneousInventory.ClientID%>').scrollTop = yPosMisc;
            }
            if ($get('<%=divGridViewPCsInventory.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=divGridViewPCsInventory.ClientID%>').scrollLeft = xPosPC;
                $get('<%=divGridViewPCsInventory.ClientID%>').scrollTop = yPosPC;
            }
            if ($get('<%=divGridViewPrintersInventory.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=divGridViewPrintersInventory.ClientID%>').scrollLeft = xPosPrinter;
                $get('<%=divGridViewPrintersInventory.ClientID%>').scrollTop = yPosPrinter;
            }
            if ($get('<%=divGridViewOverview.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=divGridViewOverview.ClientID%>').scrollLeft = xPosOverview;
                $get('<%=divGridViewOverview.ClientID%>').scrollTop = yPosOverview;
            }
        }

        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

    </script>
    <asp:UpdatePanel ID="UpdatePanelInventory" runat="server" ChildrenAsTriggers="True" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelInfo" runat="server" Width="1024px" Height="80px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbInfo" runat="server" ForeColor="White" Font-Size="Large" Width="1000px" style="text-align: left;"></asp:Label>
            </asp:Panel>
            <br />
            <br />
            <asp:Label ID="lbInventory" runat="server" Text="Equipment Inventory and Check Out" Font-Size="X-Large" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <ajax:TabContainer ID="TabContainerInventory" runat="server" ActiveTabIndex="0" CssClass="body" Width="1280" AutoPostBack="True" OnClientActiveTabChanged="Tab_SelectionChanged">
                <ajax:TabPanel ID="TabPanelCheckOut" runat="server" HeaderText="Check Out" Enabled="true" CssClass="body">
                    <ContentTemplate>
                        <asp:Panel ID="PanelCheckOut" runat="server" Width="1230px" BackColor="#F9F9F9" class="body" DefaultButton="btnSearchCheckOut">
                            <asp:UpdatePanel ID="UpdatePanelCheckOut" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" >
                                <ContentTemplate>
                                    <br />
                                    <table width="1170px">
                                        <tr>
                                            <td style="width: 60px; height: 30px;" align="center">
                                                <asp:UpdateProgress ID="UpdateProgressStudyMain" runat="server" DisplayAfter="0">
                                                    <ProgressTemplate>
                                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            <td style="width: 350px" align="left">&nbsp;
                                                <asp:TextBox ID="txtSearchCheckOut" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSearchCheckOut"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                <asp:Button ID="btnSearchCheckOut" runat="server" Text="Search" OnClick="SearchCheckOut_Onclick" Font-Size="Smaller"  />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbCheckOutText" runat="server" Text="Check Out" Font-Size="Large" Font-Bold="true" Font-Underline="True"></asp:Label>
                                            </td>
                                            <td style="width: 350px" align="right">
                                                <asp:Button ID="btnReportCheckOuts" runat="server" Text="View Report" OnClick="btnReport_Click" Font-Size="Smaller" />
                                            </td>
                                            <td style="width: 60px">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div id="divCheckOut" runat="server" style="overflow:auto; max-height: 200px;">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    <asp:GridView ID="GridViewCheckOut" runat="server" Font-Size="12px" AutoGenerateColumns="False" HeaderStyle-CssClass="CheckOutHeader"
                                        PageSize="100" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3"
                                        ForeColor="Black" GridLines="Vertical" BorderWidth="1px" ShowHeader="True" ShowHeaderWhenEmpty="False"
                                        DataKeyNames="Id" DataSourceID="SQLCheckOut" ShowFooter="False" EnableViewState="True"
                                        OnRowCommand="GridViewCheckOut_RowCommand"
                                        OnRowDataBound="GridViewCheckOut_RowDataBound">
                                        <RowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="True" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px"
                                                HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="CheckOut" CommandName="Add" ToolTip="Add New Item" Font-Size="8px" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/EditFile.png" CausesValidation="false"
                                                        CommandName="Edit" ToolTip="Edit Information." Width="17px" Height="17px" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/DeleteFile.png" CausesValidation="False"
                                                        CommandName="DeleteCheckOut" ToolTip="Delete Information." Width="17px" Height="17px"
                                                        OnClientClick="return confirm('Are you sure you want to Delete this File?');" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/Images/SaveFile.gif" ValidationGroup="Return"
                                                        CommandName="UpdateLog" ToolTip="Update Information." Width="17px"
                                                        Height="17px" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/Images/CancelFile.gif"
                                                        CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update." Width="17px"
                                                        Height="17px" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkStaffList" runat="server" Text="Staff" Font-Bold="true" OnClick="CheckOutSort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddStaffList" runat="server" DataTextField="MyName" DataValueField="UserId" Width="190px"
                                                        DataSourceID="" AppendDataBoundItems="True" ValidationGroup="StaffList" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistHeader_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvStaffList" runat="server" ControlToValidate="ddStaffList" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Staff Memmber!" ValidationGroup="CheckOut"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbStaffList" runat="server" Text='<%# Eval("StaffList") %>' Width="190px"></asp:Label>
                                                    <asp:Label ID="lbStaffId" runat="server" Text='<%# Eval("StaffId") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbStaffList" runat="server" Text='<%# Eval("StaffList") %>' Width="190px"></asp:Label>
                                                    <asp:Label ID="lbStaffId" runat="server" Text='<%# Eval("StaffId") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkType" runat="server" Text="Type" Font-Bold="true" OnClick="CheckOutSort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddItemType" runat="server" DataSourceID="LinqItemType" ValidationGroup="CheckOut" Width="90px" Enabled="False"
                                                        AppendDataBoundItems="True" DataTextField="EquipmentType" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistHeader_SelectedIndexChanged"
                                                        DataValueField="Id" ToolTip="Select an Inventory Type.">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvItemType" runat="server" ControlToValidate="ddItemType" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select an Inventory Type!" ValidationGroup="CheckOut"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbItemType" runat="server" Text='<%# Eval("ItemType") %>' Width="90px"></asp:Label>
                                                    <asp:Label ID="lbItemTypeId" runat="server" Text='<%# Eval("ItemTypeId") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbItemType" runat="server" Text='<%# Eval("ItemType") %>' Width="90px"></asp:Label>
                                                    <asp:Label ID="lbItemTypeId" runat="server" Text='<%# Eval("ItemTypeId") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="160px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="160px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkDevice" runat="server" Text="Device" Font-Bold="true" OnClick="CheckOutSort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddDevice" runat="server" DataSourceID="LinqDevice" ValidationGroup="CheckOut" Width="150px" Enabled="False"
                                                        AppendDataBoundItems="True" DataTextField="Description" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistHeader_SelectedIndexChanged"
                                                        DataValueField="Id" ToolTip="Select a Device.">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvDevice" runat="server" ControlToValidate="ddDevice" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Device!" ValidationGroup="CheckOut"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbDeviceType" runat="server" Text='<%# Eval("Device") %>' Width="150px"></asp:Label>
                                                    <asp:Label ID="lbDeviceTypeId" runat="server" Text='<%# Eval("DeviceId") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbDeviceType" runat="server" Text='<%# Eval("Device") %>' Width="150px"></asp:Label>
                                                    <asp:Label ID="lbDeviceTypeId" runat="server" Text='<%# Eval("DeviceId") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="180px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkReason" runat="server" Text="Reason" Font-Bold="true" OnClick="CheckOutSort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddReason" runat="server" DataSourceID="LinqCheckOutReason" ValidationGroup="CheckOut" Width="170px" Enabled="False"
                                                        AppendDataBoundItems="True" DataTextField="Reason" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistHeader_SelectedIndexChanged"
                                                        DataValueField="Id" ToolTip="Select a Reason.">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvReason" runat="server" ControlToValidate="ddReason" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Reason!" ValidationGroup="CheckOut"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason") %>' Width="170px"></asp:Label>
                                                    <asp:Label ID="lbReasonId" runat="server" Text='<%# Eval("ReasonId") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason") %>' Width="170px"></asp:Label>
                                                    <asp:Label ID="lbReasonId" runat="server" Text='<%# Eval("ReasonId") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkCheckedOut" runat="server" Text="Checked Out" Font-Bold="true" OnClick="CheckOutSort" />
                                                    <br /><br />
                                                    <asp:TextBox ID="txtCheckedOutDate" runat="server" Text="" Width="70px" MaxLength="10" onkeydown="setCheckOutDate();" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvCheckedOutDate" runat="server" ControlToValidate="txtCheckedOutDate"
                                                        ErrorMessage="Please Enter Checked Out Date." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                        ValidationGroup="CheckOut"></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="rvCheckedOutDate" runat="server" ControlToValidate="txtCheckedOutDate" ValidationGroup="CheckOut" Display="Dynamic"
                                                        ErrorMessage="Checked Out Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="1/1/3000" MinimumValue="1/1/1900"></asp:RangeValidator>
                                                    <ajax:CalendarExtender ID="ceCheckedOutDate" runat="server" TargetControlID="txtCheckedOutDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                    <ajax:TextBoxWatermarkExtender ID="tbweCheckedOutDate" runat="server" TargetControlID="txtCheckedOutDate"
                                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbCheckedOutDate" runat="server" Text='<%# Eval("CheckedOutDate", "{0:MM/dd/yyyy}") %>' Width="70px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbCheckedOutDate" runat="server" Text='<%# Eval("CheckedOutDate", "{0:MM/dd/yyyy}") %>' Width="70px"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkReturnDate" runat="server" Text="Returned" Font-Bold="true" OnClick="CheckOutSort" />
                                                    <br /><br />
                                                    <asp:TextBox ID="txtReturned" runat="server" Text="" Width="70px" Enabled="false"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkReturnDate" runat="server" Text="Returned" CommandName="Edit" ToolTip="Edit Information." />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtReturnDate" runat="server" Text='<%# Eval("ReturnDate", "{0:MM/dd/yyyy}") %>' Width="70px" MaxLength="10" onkeydown="setReturnDate();" ValidationGroup="Return"></asp:TextBox>
                                                    <asp:RangeValidator ID="rvReturnDate" runat="server" ControlToValidate="txtReturnDate" ValidationGroup="Return" Display="Dynamic"
                                                        ErrorMessage="Return Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="1/1/3000" MinimumValue="1/1/1900"></asp:RangeValidator>
                                                    <ajax:CalendarExtender ID="ceReturnDate" runat="server" TargetControlID="txtReturnDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                    <ajax:TextBoxWatermarkExtender ID="tbweReturnDate" runat="server" TargetControlID="txtReturnDate"
                                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="240px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="240px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkComments" runat="server" Text="Comments" Font-Bold="true" OnClick="CheckOutSort" />
                                                    <br /><br />
                                                    <asp:TextBox ID="txtComments" runat="server" Text="" Width="230px" MaxLength="250" Enabled="false"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtComments" ValidationGroup="CheckOut"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbComments" runat="server" Text='<%# Eval("Comments") %>' Width="230px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtComments" runat="server" Text='<%# Bind("Comments") %>' Width="230px" MaxLength="250" ></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtComments" ValidationGroup="CheckOut"
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
                                    <br />
                                    <hr />
                                    <br />
                                    <table width="1170px">
                                        <tr>
                                            <td style="width: 60px; height: 30px;" align="center">
                                                <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="0">
                                                    <ProgressTemplate>
                                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            <td style="width: 350px" align="left">&nbsp;
                                                <asp:TextBox ID="txtSearchCheckOutLog" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSearchCheckOutLog"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                <asp:Button ID="btnSearchCheckOutLog" runat="server" Text="Search" OnClick="SearchCheckOutLog_Onclick" Font-Size="Smaller" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbCheckOutLog" runat="server" Text="Check Out Log" Font-Size="Large" Font-Bold="true" Font-Underline="True"></asp:Label>
                                            </td>
                                            <td style="width: 350px" align="right">
                                                <asp:Button ID="btnReportCheckOutsLog" runat="server" Text="View Report" OnClick="btnReport_Click" Font-Size="Smaller"/>
                                            </td>
                                            <td style="width: 60px">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div style="overflow: auto; height: 200px;">
                                        <br />
                                        <asp:GridView ID="GridViewCheckOutLog" runat="server" Font-Size="12px" AutoGenerateColumns="False" AllowPaging="true"
                                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3" HeaderStyle-CssClass="CheckOutLogHeader"
                                            ForeColor="Black" GridLines="Vertical" BorderWidth="0px" ShowHeader="True" ShowHeaderWhenEmpty="False"
                                            DataSourceID="SQLCheckOutLog" ShowFooter="False" EnableViewState="True"
                                            OnRowDataBound="GridViewCheckOutLog_RowDataBound" PageSize="100">
                                            <RowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField ShowHeader="True" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px"
                                                    HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkDate" runat="server" Text="Date" Font-Bold="true" OnClick="CheckOutLogSort" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbDate" runat="server" Text='<%# Eval("EnterDate", "{0:MM/dd/yyyy}") %>' Width="60px"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkStaffList" runat="server" Text="Staff" Font-Bold="true" OnClick="CheckOutLogSort" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbStaffList" runat="server" Text='<%# Eval("StaffList") %>' Visible="True" Width="190px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkType" runat="server" Text="Type" Font-Bold="true" OnClick="CheckOutLogSort" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbItemType" runat="server" Text='<%# Eval("ItemType") %>' Width="90px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="160px" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-Width="160px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkDevice" runat="server" Text="Device" Font-Bold="true" OnClick="CheckOutLogSort" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbDeviceType" runat="server" Text='<%# Eval("Device") %>' Width="150px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-Width="180px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkReason" runat="server" Text="Reason" Font-Bold="true" OnClick="CheckOutLogSort" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason") %>' Width="170px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkCheckedOut" runat="server" Text="Checked Out" Font-Bold="true" OnClick="CheckOutLogSort" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbCheckedOutDate" runat="server" Text='<%# Eval("CheckedOutDate", "{0:MM/dd/yyyy}") %>' Width="70px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkReturnDate" runat="server" Text="Returned" Font-Bold="true" OnClick="CheckOutLogSort" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbReturnDate" runat="server" Text='<%# Eval("ReturnDate", "{0:MM/dd/yyyy}") %>' Width="70px"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="240px" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-Width="240px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="linkComments" runat="server" Text="Comments" Font-Bold="true" OnClick="CheckOutLogSort" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbComments" runat="server" Text='<%# Eval("Comments") %>' Width="230px"></asp:Label>
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
                                    <asp:ValidationSummary ID="ValSumCheckOut" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="CheckOut" />
                                    <asp:ValidationSummary ID="ValSumReturn" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="Return" />
                                    <asp:Label ID="lbCheckOutMessage" runat="server" Text=""></asp:Label>
                                    <br />
                                    <br />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridViewCheckOut" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                        <asp:LinqDataSource ID="LinqCheckOut" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Id DESC" TableName="tblInventoryCheckOuts"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqCheckOutLog" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="UId DESC" TableName="tblInventoryCheckOutLogs"
                            EnableInsert="true">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqStaff" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="EnterDate DESC" TableName="tblStaffs">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqItemType" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="EnterDate DESC" TableName="lkpInventoryTypes">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqDevice" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="EnterDate DESC" TableName="lkpInventoryHotspots">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqCheckOutHotspots" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="EnterDate DESC" TableName="lkpInventoryHotspots">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqCheckOutLaptops" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="EnterDate DESC" TableName="lkpInventoryLaptops">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqCheckOutReason" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Reason" TableName="lkpInventoryReasons">
                        </asp:LinqDataSource>
                        <asp:SqlDataSource ID="SQLDevice" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SQLCheckOut" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SQLCheckOutLog" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="TabPanelHotspots" runat="server" HeaderText="Hotspots" Enabled="true" CssClass="body">
                    <ContentTemplate>
                        <asp:Panel ID="PanelHotspots" runat="server" Width="1260px" BackColor="#F9F9F9" class="body" DefaultButton="btnSearchHotspots">
                            <asp:UpdatePanel ID="UpdatePanelHotspots" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <br />
                                    <table width="1100px">
                                        <tr>
                                            <td style="width: 60px; height:30px;" align="center">
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                                                    <ProgressTemplate>
                                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            <td style="width: 400px" align="left">
                                                <asp:TextBox ID="txtSearchHotspots" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtSearchHotspots"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                <asp:Button ID="btnSearchHotspots" runat="server" Text="Search" OnClick="SearchHotspots_Onclick" Font-Size="10px" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbHotspotsText" runat="server" Text="Hotspots" Font-Size="Large" Font-Bold="true" Font-Underline="True"></asp:Label>
                                            </td>
                                            <td style="width: 400px" align="right">
                                                <asp:Button ID="btnReportHotspots" runat="server" Text="View Report" OnClick="btnReport_Click" Font-Size="Smaller"/>
                                            </td>
                                            <td style="width: 60px">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div id="divHotspots" runat="server" style="overflow: auto; max-height: 500px;">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <asp:GridView ID="GridViewHotspots" runat="server" Font-Size="12px" AutoGenerateColumns="False"
                                            PageSize="50" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3" HeaderStyle-CssClass="HotspotsHeader"
                                            ForeColor="Black" GridLines="Vertical" BorderWidth="0px" ShowHeader="True" EmptyDataText="There are no data records to display."
                                            DataKeyNames="Id" DataSourceID="SQLHotspots" ShowFooter="False" EnableViewState="True" ShowHeaderWhenEmpty="false"
                                            OnRowCommand="GridViewHotspots_RowCommand"
                                            OnRowDeleted="GridViewHotspots_RowDeleted"
                                            OnRowDataBound="GridViewHotspots_RowDatabound">
                                        <RowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="True" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" 
                                                HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" ToolTip="Add New Hotspot." ValidationGroup="Hotspots" Font-Size="8px"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/EditFile.png" CausesValidation="False"
                                                        CommandName="Edit" ToolTip="Edit Information." Width="17px" Height="17px" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/DeleteFile.png" CausesValidation="False"
                                                        CommandName="DeleteHotspot" ToolTip="Delete Information." Width="17px" Height="17px"
                                                        OnClientClick="return confirm('Are you sure you want to Delete this File?');" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/Images/SaveFile.gif" OnClientClick="valEdit(this);"
                                                        CommandName="UpdateHotspot" ToolTip="Update Information." Width="17px" ValidationGroup="HotspotsEdit"
                                                        Height="17px" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/Images/CancelFile.gif"
                                                        CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update." Width="17px"
                                                        Height="17px" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="250px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkHotspotsDescriptionText" runat="server" Text="Description" Font-Bold="true" OnClick="HotspotSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtDescription" runat="server" Text="" Width="240px" MaxLength="256"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                                                        ErrorMessage="Please Enter a Description." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                        ValidationGroup="Hotspots"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtDescription" ValidationGroup="Hotspots"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbDescription" runat="server" Text='<%# Eval("Description") %>' Width="240px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>' Width="240px" MaxLength="256"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                                                        ErrorMessage="Please Enter a Description." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                        ValidationGroup="HotspotsEdit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtSearchCheckOut" ValidationGroup="HotspotsEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkHotspotsTagIdText" runat="server" Text="Tag Id" Font-Bold="true" OnClick="HotspotSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtTagId" runat="server" Text="" Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtTagId" ValidationGroup="Hotspots"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbTagId" runat="server" Text='<%# Eval("TagId") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTagId" runat="server" Text='<%# Eval("TagId") %>' Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtTagId" ValidationGroup="HotspotsEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkHotspotsModelText" runat="server" Text="Model" Font-Bold="true" OnClick="HotspotSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtModel" runat="server" Text="" Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtModel" ValidationGroup="Hotspots"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbModel" runat="server" Text='<%# Eval("Model") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtModel" runat="server" Text='<%# Eval("Model") %>' Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtModel" ValidationGroup="HotspotsEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="250px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkHotspotsNotesText" runat="server" Text="Notes" Font-Bold="true" OnClick="HotspotSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtNotes" runat="server" Text="" Width="240px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtNotes" ValidationGroup="Hotspots"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbNotes" runat="server" Text='<%# Eval("Notes") %>' Width="240px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNotes" runat="server" Text='<%# Eval("Notes") %>' Width="240px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtNotes" ValidationGroup="HotspotsEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkHotspotsUHText" runat="server" Text="UH" Font-Bold="true" OnClick="HotspotSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUH" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Text="UH" Checked='<%# Eval("UH") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Text="UH" Checked='<%# Eval("UH") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkHotspotsUTText" runat="server" Text="UT" Font-Bold="true" OnClick="HotspotSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUT" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Text="UT" Checked='<%# Eval("UT") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Text="UT" Checked='<%# Eval("UT") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lbHotspotsStatusText" runat="server" Text="Status" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:Label>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtStatus" runat="server" Text="" Width="90px" Enabled="false"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbStatus" runat="server" Text="" Width="90px"/>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbStatus" runat="server" Text="" Width="90px"/>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lbHotspotsActiveText" runat="server" Text="Active" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:Label>
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbActive" runat="server" Enabled="false" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' />
                                                </EditItemTemplate>
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
                                    <asp:ValidationSummary ID="ValSumHotspots" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="Hotspots" />
                                    <asp:ValidationSummary ID="ValSumHotspotsEdit" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="HotspotsEdit" />
                                    <asp:Label ID="lbHotspotsMessage" runat="server" Text=""></asp:Label>
                                    <br />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridViewHotspots" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                        <asp:LinqDataSource ID="LinqHotspots" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" TableName="lkpInventoryHotspots"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true" >
                        </asp:LinqDataSource>
                        <asp:SqlDataSource ID="SQLHotspots" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="TabPaneLaptops" runat="server" HeaderText="Laptops" Enabled="true" CssClass="body">
                    <ContentTemplate>
                        <asp:Panel ID="PanelLaptops" runat="server" Width="1260px" BackColor="#F9F9F9" class="body" DefaultButton="btnSearchLaptops">
                            <asp:UpdatePanel ID="UpdatePanelLaptops" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <br />
                                    <table width="1170px">
                                        <tr>
                                            <td style="width: 60px; height:30px;" align="center">
                                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="0">
                                                    <ProgressTemplate>
                                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            <td style="width: 400px" align="left">
                                                <asp:TextBox ID="txtSearchLaptops" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorH1" runat="server" ControlToValidate="txtSearchLaptops"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                <asp:Button ID="btnSearchLaptops" runat="server" Text="Search" OnClick="SearchLaptops_Onclick" Font-Size="10px" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbLaptopsText" runat="server" Text="Laptops" Font-Size="Large" Font-Bold="true" Font-Underline="True"></asp:Label>
                                            </td>
                                            <td style="width: 400px" align="right">
                                                <asp:Button ID="btnReportLaptops" runat="server" Text="View Report" OnClick="btnReport_Click" Font-Size="10px" />
                                            </td>
                                            <td style="width: 60px">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div id="divLaptops" runat="server" style="overflow:auto; max-height: 500px;">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    <asp:GridView ID="GridViewLaptops" runat="server" Font-Size="12px" AutoGenerateColumns="False"
                                        PageSize="100" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3" HeaderStyle-CssClass="LaptopsHeader"
                                        ForeColor="Black" GridLines="Vertical" BorderWidth="0px" ShowHeader="True" EmptyDataText="There are no data records to display."
                                        DataKeyNames="Id" DataSourceID="SQLLaptops" ShowFooter="False" EnableViewState="True" ShowHeaderWhenEmpty="false"
                                        OnRowCommand="GridViewLaptops_RowCommand"
                                        OnRowDeleted="GridViewLaptops_RowDeleted"
                                        OnRowDataBound="GridViewLaptops_RowDataBound">
                                        <RowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="True" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" 
                                                HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" ToolTip="Add New Laptop." ValidationGroup="Laptops" Font-Size="8px" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/EditFile.png" CausesValidation="False"
                                                        CommandName="Edit" ToolTip="Edit Information." Width="17px" Height="17px" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/DeleteFile.png" CausesValidation="False"
                                                        CommandName="DeleteLaptop" ToolTip="Delete Information." Width="17px" Height="17px"
                                                        OnClientClick="return confirm('Are you sure you want to Delete this File?');" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/Images/SaveFile.gif" OnClientClick="valEdit(this);"
                                                        CommandName="UpdateLaptop" ToolTip="Update Information." Width="17px" Height="17px" ValidationGroup="HotspotsEdit" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/Images/CancelFile.gif"
                                                        CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update." Width="17px"
                                                        Height="17px" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkLaptopDescriptionText" runat="server" Text="Description" Font-Bold="true" OnClick="LaptopSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtDescription" runat="server" Text="" Width="140px" MaxLength="256"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                                                        ErrorMessage="Please Enter a Description." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                        ValidationGroup="Laptops"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDescription" ValidationGroup="Laptops"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbDescription" runat="server" Text='<%# Eval("Description") %>' Width="140px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>' Width="140px" MaxLength="256"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                                                        ErrorMessage="Please Enter a Description." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                        ValidationGroup="LaptopsEdit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDescription" ValidationGroup="LaptopsEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkLaptopPCNameText" runat="server" Text="PC Name" Font-Bold="true" OnClick="LaptopSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtPCName" runat="server" Text="" Width="140px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPCName" ValidationGroup="Laptops"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbPCName" runat="server" Text='<%# Eval("PCName") %>' Width="140px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtPCName" runat="server" Text='<%# Eval("PCName") %>' Width="140px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPCName" ValidationGroup="LaptopsEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkLaptopTagIdText" runat="server" Text="Tag Id" Font-Bold="true" OnClick="LaptopSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtTagId" runat="server" Text="" Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTagId" ValidationGroup="Laptops"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbTagId" runat="server" Text='<%# Eval("TagId") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTagId" runat="server" Text='<%# Eval("TagId") %>' Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtTagId" ValidationGroup="LaptopsEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkLaptopModelText" runat="server" Text="Model" Font-Bold="true" OnClick="LaptopSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtModel" runat="server" Text="" Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtModel" ValidationGroup="Laptops"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbModel" runat="server" Text='<%# Eval("Model") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtModel" runat="server" Text='<%# Eval("Model") %>' Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtModel" ValidationGroup="LaptopsEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="250px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkLaptopNotesText" runat="server" Text="Notes" Font-Bold="true" OnClick="LaptopSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtNotes" runat="server" Text="" Width="240px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtNotes" ValidationGroup="Laptops"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbNotes" runat="server" Text='<%# Eval("Notes") %>' Width="240px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNotes" runat="server" Text='<%# Eval("Notes") %>' Width="240px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtNotes" ValidationGroup="LaptopsEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkLaptopUHText" runat="server" Text="UH" Font-Bold="true" OnClick="LaptopSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUH" runat="server"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Text="UH" Checked='<%# Eval("UH") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Text="UH" Checked='<%# Eval("UH") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkLaptopUTText" runat="server" Text="UT" Font-Bold="true" OnClick="LaptopSort"></asp:LinkButton>
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUT" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Text="UT" Checked='<%# Eval("UT") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Text="UT" Checked='<%# Eval("UT") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lbLaptopStatusText" runat="server" Text="Status" Font-Bold="true" Font-Underline="true" ForeColor="Blue" ></asp:Label>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtLaptopStatusText" runat="server" Text="" Width="90px" Enabled="false"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbStatus" runat="server" Text="" Width="90px"/>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbStatus" runat="server" Text="" Width="90px"/>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:label ID="lbLaptopActiveText" runat="server" Text="Active" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:label>
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbActive" runat="server" Enabled="false" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' />
                                                </EditItemTemplate>
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
                                    <asp:ValidationSummary ID="ValSumLaptops" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="Laptops" />
                                    <asp:ValidationSummary ID="ValSumLaptopsEdit" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="LaptopsEdit" />
                                    <asp:Label ID="lbLaptopsMessage" runat="server" Text=""></asp:Label>
                                    <br />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridViewLaptops" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                        <asp:LinqDataSource ID="LinqLaptops" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" TableName="lkpInventoryLaptops"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
                        </asp:LinqDataSource>
                        <asp:SqlDataSource ID="SQLLaptops" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="TabPanelMiscellaneous" runat="server" HeaderText="Miscellaneous" Enabled="true" CssClass="body">
                    <ContentTemplate>
                        <asp:Panel ID="PanelMiscellaneous" runat="server" Width="1260px" BackColor="#F9F9F9" class="body" DefaultButton="btnSearchMiscellaneous">
                            <asp:UpdatePanel ID="UpdatePanelMiscellaneous" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <br />
                                    <table width="1240px">
                                        <tr>
                                            <td style="width: 60px; height:30px;" align="center">
                                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="0">
                                                    <ProgressTemplate>
                                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            <td style="width: 400px" align="left">
                                                <asp:TextBox ID="txtSearchMiscellaneous" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMisc" runat="server" ControlToValidate="txtSearchMiscellaneous" 
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                <asp:Button ID="btnSearchMiscellaneous" runat="server" Text="Search" OnClick="SearchMiscellaneous_Onclick" Font-Size="10px" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbMiscellaneous" runat="server" Text="Miscellaneous" Font-Size="Large" Font-Bold="true" Font-Underline="True"></asp:Label>
                                            </td>
                                            <td style="width: 400px" align="right">
                                                <asp:Button ID="btnReportMiscellaneous" runat="server" Text="View Report" OnClick="btnReport_Click" Font-Size="10px" />
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
                                    <div id="divGridViewMiscellaneousInventory" runat="server" style="overflow:auto; max-height: 500px;">
                                    <asp:GridView ID="GridViewMiscellaneousInventory" runat="server" Font-Size="12px" AutoGenerateColumns="False"  
                                        PageSize="200" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3" HeaderStyle-CssClass="MiscellaneousHeader"
                                        ForeColor="Black" GridLines="Vertical" BorderWidth="0px" ShowHeader="True" ShowHeaderWhenEmpty ="false"
                                        ShowFooter="False" EnableViewState="True" DataSourceID="SQLMiscellaneous" DataKeyNames="Id" 
                                        OnRowCommand="GridViewMiscellaneousInventory_RowCommand"
                                        OnRowDataBound="GridViewMiscellaneousInventory_RowDataBound">
                                        <RowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" ToolTip="Add New Miscellaneous." ValidationGroup="MiscellaneousInventory" Font-Size="8px" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/EditFile.png" CausesValidation="False"
                                                        CommandName="Edit" ToolTip="Edit Information." Width="17px" Height="17px" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/DeleteFile.png" CausesValidation="False"
                                                        CommandName="DeleteMiscellaneous" ToolTip="Delete Information." Width="17px" Height="17px"
                                                        OnClientClick="return confirm('Are you sure you want to Delete this File?');" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/Images/SaveFile.gif" OnClientClick="valEdit(this);"
                                                        CommandName="UpdateMiscellaneous" ToolTip="Update Information." Width="17px" Height="17px" ValidationGroup="MiscellaneousInventoryEdit" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/Images/CancelFile.gif"
                                                        CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update." Width="17px"
                                                        Height="17px" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkMiscellaneousDescription" runat="server" Text="Description" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtMiscellaneousDescription" runat="server" Text="" Width="90px" MaxLength="50"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvMiscellaneousDescription" runat="server" ControlToValidate="txtMiscellaneousDescription"
                                                                ErrorMessage="Please Enter a Miscellaneous Description." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                                ValidationGroup="MiscellaneousInventory"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMiscellaneousDescription" ValidationGroup="MiscellaneousInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbMiscellaneousDescription" runat="server" Text='<%# Eval("Description") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtMiscellaneousDescription" runat="server" Text='<%# Eval("Description") %>' Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvMiscellaneousDescription" runat="server" ControlToValidate="txtMiscellaneousDescription"
                                                        ErrorMessage="Please Enter a Miscellaneous Description." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                        ValidationGroup="MiscellaneousInventoryEdit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMiscellaneousDescription" ValidationGroup="MiscellaneousInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkModel" runat="server" Text="Model" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtModel" runat="server" Text="" Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtModel" ValidationGroup="MiscellaneousInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbModel" runat="server" Text='<%# Eval("Model") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtModel" runat="server" Text='<%# Eval("Model") %>' Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtModel" ValidationGroup="MiscellaneousInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkTagId" runat="server" Text="Tag Id" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtTagId" runat="server" Text="" Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtTagId" ValidationGroup="MiscellaneousInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbTagId" runat="server" Text='<%# Eval("TagId") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTagId" runat="server" Text='<%# Eval("TagId") %>' Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTagId" ValidationGroup="MiscellaneousInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="150px" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkNotes" runat="server" Text="Notes" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtNotes" runat="server" Text="" Width="140px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtNotes" ValidationGroup="MiscellaneousInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbNotes" runat="server" Text='<%# Eval("Notes") %>' Width="140px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNotes" runat="server" Text='<%# Eval("Notes") %>' Width="140px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtNotes" ValidationGroup="MiscellaneousInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="30px" ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkUH" runat="server" Text="UH" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUH" runat="server"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Checked='<%# Eval("UH") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Checked='<%# Eval("UH") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="30px" ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkUT" runat="server" Text="UT" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUT" runat="server"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Checked='<%# Eval("UT") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Checked='<%# Eval("UT") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lbMiscellaneousStatusText" runat="server" Text="Status" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:Label>
                                                    <br /><br />
                                                    <asp:TextBox ID="txtMiscellaneousStatusText" runat="server" Text="" Width="90px" Enabled="false"></asp:TextBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbStatus" runat="server" Text="" Width="90px"/>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbStatus" runat="server" Text="" Width="90px"/>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40px" ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lbActive" runat="server" Text="Active" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:Label>
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbActive" runat="server" Enabled="false" Checked="true" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="92px" ItemStyle-Width="92px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryOrganization" runat="server" Text="Organization" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryOrganization" runat="server" DataTextField="InventoryOrganization" DataValueField="Organization" Width="90px" ValidationGroup="MiscellaneousInventory" 
                                                        DataSourceID="LinqMiscellaneousOrganization" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryOrganization" runat="server" Text='<%# Eval("InventoryOrganization") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryOrganization" runat="server" DataTextField="InventoryOrganization" DataValueField="Organization" Width="90px" ValidationGroup="MiscellaneousInventoryEdit" 
                                                        DataSourceID="LinqMiscellaneousOrganization" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="92px" ItemStyle-Width="92px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryTower" runat="server" Text="Tower" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryTower" runat="server" DataTextField="InventoryTower" DataValueField="Tower" Width="90px" ValidationGroup="MiscellaneousInventory" Enabled="false" 
                                                        DataSourceID="LinqMiscellaneousTower" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryTower" runat="server" ControlToValidate="ddInventoryTower" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Tower!" ValidationGroup="MiscellaneousInventory" Enabled="False"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryTower" runat="server" Text='<%# Eval("InventoryTower") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryTower" runat="server" DataTextField="InventoryTower" DataValueField="Tower" Width="90px" ValidationGroup="MiscellaneousInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqMiscellaneousTower" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryTower" runat="server" ControlToValidate="ddInventoryTower" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Tower!" ValidationGroup="MiscellaneousInventoryEdit" Enabled="False"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="92px" ItemStyle-Width="92px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryFloor" runat="server" Text="Floor" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryFloor" runat="server" DataTextField="InventoryFloor" DataValueField="Floor" Width="90px" ValidationGroup="MiscellaneousInventory" Enabled="false"  
                                                        DataSourceID="LinqMiscellaneousFloor" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryFloor" runat="server" ControlToValidate="ddInventoryFloor" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Floor!" ValidationGroup="MiscellaneousInventory" Enabled="False"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryFloor" runat="server" Text='<%# Eval("InventoryFloor") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryFloor" runat="server" DataTextField="InventoryFloor" DataValueField="Floor" Width="90px" ValidationGroup="MiscellaneousInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqMiscellaneousFloor" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryFloor" runat="server" ControlToValidate="ddInventoryFloor" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Floor!" ValidationGroup="MiscellaneousInventoryEdit" Enabled="False"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="72px" ItemStyle-Width="72px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryHall" runat="server" Text="Hall" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryHall" runat="server" DataTextField="InventoryHall" DataValueField="Hall" Width="70px" ValidationGroup="MiscellaneousInventory" Enabled="false"  
                                                        DataSourceID="LinqMiscellaneousHall" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryHall" runat="server" ControlToValidate="ddInventoryHall" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Hall!" ValidationGroup="MiscellaneousInventory" Enabled="False"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryHall" runat="server" Text='<%# Eval("InventoryHall") %>' Width="70px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryHall" runat="server" DataTextField="InventoryHall" DataValueField="Hall" Width="70px" ValidationGroup="MiscellaneousInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqMiscellaneousHall" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryHall" runat="server" ControlToValidate="ddInventoryHall" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Hall!" ValidationGroup="MiscellaneousInventoryEdit" Enabled="False"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="72px" ItemStyle-Width="72px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryRoom" runat="server" Text="Room" Font-Bold="true" OnClick="MiscellaneousInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryRoom" runat="server" DataTextField="InventoryRoom" DataValueField="Room" Width="70px" ValidationGroup="MiscellaneousInventory" Enabled="false"  
                                                        DataSourceID="LinqMiscellaneousRoom" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryRoom" runat="server" ControlToValidate="ddInventoryRoom" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Room!" ValidationGroup="MiscellaneousInventory" Enabled="False"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryRoom" runat="server" Text='<%# Eval("InventoryRoom") %>' Width="70px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryRoom" runat="server" DataTextField="InventoryRoom" DataValueField="Room" Width="70px" ValidationGroup="MiscellaneousInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqMiscellaneousRoom" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistMiscellaneousLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryRoom" runat="server" ControlToValidate="ddInventoryRoom" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Room!" ValidationGroup="MiscellaneousInventoryEdit" Enabled="False"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
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
                                    <asp:ValidationSummary ID="ValidationSummaryMiscellaneousInventory" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="MiscellaneousInventory" />
                                    <asp:ValidationSummary ID="ValidationSummaryMiscellaneousInventoryEdit" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="MiscellaneousInventoryEdit" />
                                    <asp:Label ID="lbMiscellaneousMessage" runat="server" Text=""></asp:Label>
                                    <br />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridViewMiscellaneousInventory" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                        <asp:LinqDataSource ID="LinqMiscellaneousInventory" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Active DESC, Description" TableName="lkpInventoryMiscellaneous"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqMiscellaneousLocation" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" TableName="tblInventoryMiscellaneous"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
                        </asp:LinqDataSource>
                        <asp:SqlDataSource ID="SQLMiscellaneous" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                        <asp:LinqDataSource ID="LinqMiscellaneousOrganization" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Organization" TableName="lkpInventoryOrganizations" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqMiscellaneousTower" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Tower" TableName="lkpInventoryTowers" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqMiscellaneousFloor" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Floor" TableName="lkpInventoryFloors" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqMiscellaneousHall" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Hall" TableName="lkpInventoryHalls" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqMiscellaneousRoom" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Room" TableName="lkpInventoryRooms" Where="Active == True">
                        </asp:LinqDataSource>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="TabPanelPCs" runat="server" HeaderText="PCs" Enabled="true" CssClass="body">
                    <ContentTemplate>
                        <asp:Panel ID="PanelPCs" runat="server" Width="1260px" BackColor="#F9F9F9" class="body" DefaultButton="btnSearchPCs">
                            <asp:UpdatePanel ID="UpdatePanelPCs" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <br />
                                    <table width="1210px">
                                        <tr>
                                            <td style="width: 60px; height: 30px;" align="center">
                                                <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="0">
                                                    <ProgressTemplate>
                                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            <td style="width: 400px" align="left">
                                                <asp:TextBox ID="txtSearchPCs" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPC" runat="server" ControlToValidate="txtSearchPCs"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                <asp:Button ID="btnSearchPCs" runat="server" Text="Search" OnClick="SearchPCs_Onclick" Font-Size="10px" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbPCs" runat="server" Text="PCs" Font-Size="Large" Font-Bold="true" Font-Underline="True"></asp:Label>
                                            </td>
                                            <td style="width:400px" align="right">
                                                <asp:Button ID="btnReportPCs" runat="server" Text="View Report" OnClick="btnReport_Click" Font-Size="10px"/>
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
                                    <div id="divGridViewPCsInventory" runat="server" style="overflow:auto; max-height: 500px;">
                                    <asp:GridView ID="GridViewPCsInventory" runat="server" Font-Size="12px" AutoGenerateColumns="False"  
                                        PageSize="500" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3" HeaderStyle-CssClass="PCHeader"
                                        ForeColor="Black" GridLines="Vertical" BorderWidth="0px" ShowHeader="True" ShowHeaderWhenEmpty ="False"
                                        ShowFooter="False" EnableViewState="True" DataSourceID="SQLPCs" DataKeyNames="Id" 
                                        OnRowCommand="GridViewPCsInventory_RowCommand"
                                        OnRowDataBound="GridViewPCsInventory_RowDataBound">
                                        <RowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" ToolTip="Add New PC." ValidationGroup="PCsInventory" Font-Size="8px" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/EditFile.png" CausesValidation="False"
                                                        CommandName="Edit" ToolTip="Edit Information." Width="17px" Height="17px" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/DeleteFile.png" CausesValidation="False"
                                                        CommandName="DeletePC" ToolTip="Delete Information." Width="17px" Height="17px"
                                                        OnClientClick="return confirm('Are you sure you want to Delete this File?');" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/Images/SaveFile.gif" OnClientClick="valEdit(this);"
                                                        CommandName="UpdatePC" ToolTip="Update Information." Width="17px" Height="17px" ValidationGroup="PCsInventoryEdit" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/Images/CancelFile.gif"
                                                        CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update." Width="17px"
                                                        Height="17px" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lbUserId" runat="server" Text='<%# Eval("UserId") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="120px" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkPCName" runat="server" Text="PC Name" Font-Bold="true" OnClick="PCsInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtPCName" runat="server" Text="" Width="110px" MaxLength="250"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPCName" runat="server" ControlToValidate="txtPCName"
                                                                ErrorMessage="Please Enter a PC Name." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                                ValidationGroup="PCsInventory"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPCName" ValidationGroup="PCsInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbPCName" runat="server" Text='<%# Eval("PCName") %>' Width="110px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtPCName" runat="server" Text='<%# Eval("PCName") %>' Width="110px" MaxLength="250"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPCName" runat="server" ControlToValidate="txtPCName"
                                                        ErrorMessage="Please Enter a PC Name." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                        ValidationGroup="PCsInventoryEdit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPCName" ValidationGroup="PCsInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkStaffList" runat="server" Text="Staff" Font-Bold="true" OnClick="PCsInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddStaffList" runat="server" DataTextField="MyName" DataValueField="UserId" Width="110px"
                                                        DataSourceID="" AppendDataBoundItems="True">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkStaffList" runat="server" Text='<%# Eval("StaffList") %>' CommandName="Staff" Width="110px"></asp:LinkButton>
                                                    <asp:Label ID ="lbStaffUserId" runat="server" Text='<%# Eval("UserId") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddStaffList" runat="server" DataTextField="MyName" DataValueField="UserId" Width="110px"
                                                        DataSourceID="" AppendDataBoundItems="True">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="70px" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkTagId" runat="server" Text="TagId" Font-Bold="true" OnClick="PCsInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtTagId" runat="server" Text="" Width="60px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTagId" ValidationGroup="PCsInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbTagId" runat="server" Text='<%# Eval("TagId") %>' Width="60px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTagId" runat="server" Text='<%# Eval("TagId") %>' Width="60px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTagId" ValidationGroup="PCsInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkModel" runat="server" Text="Model" Font-Bold="true" OnClick="PCsInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtModel" runat="server" Text="" Width="90px" MaxLength="250"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtTagId" ValidationGroup="PCsInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbModel" runat="server" Text='<%# Eval("Model") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtModel" runat="server" Text='<%# Eval("Model") %>' Width="90px" MaxLength="250"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTagId" ValidationGroup="PCsInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="150px" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkNotes" runat="server" Text="Notes" Font-Bold="true" OnClick="PCsInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtNotes" runat="server" Text="" Width="140px" MaxLength="250"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtTagId" ValidationGroup="PCsInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbNotes" runat="server" Text='<%# Eval("Notes") %>' Width="140px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNotes" runat="server" Text='<%# Eval("Notes") %>' Width="140px" MaxLength="250"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtTagId" ValidationGroup="PCsInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="30px" ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkUH" runat="server" Text="UH" Font-Bold="true" OnClick="PCsInventorySort" />
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUH" runat="server"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Checked='<%# Eval("UH") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Checked='<%# Eval("UH") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="30px" ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkUT" runat="server" Text="UT" Font-Bold="true" OnClick="PCsInventorySort" />
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUT" runat="server"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Checked='<%# Eval("UT") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Checked='<%# Eval("UT") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40px" ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lbActive" runat="server" Text="Active" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:Label>
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbActive" runat="server" Enabled="false" Checked="true" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="92px" ItemStyle-Width="92px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryOrganization" runat="server" Text="Organization" Font-Bold="true" OnClick="PCsInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryOrganization" runat="server" DataTextField="InventoryOrganization" DataValueField="Organization" Width="90px" 
                                                        DataSourceID="LinqPCOrganization" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryOrganization" runat="server" Text='<%# Eval("InventoryOrganization") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryOrganization" runat="server" DataTextField="InventoryOrganization" DataValueField="Organization" Width="90px" 
                                                        DataSourceID="LinqPCOrganization" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="92px" ItemStyle-Width="92px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryTower" runat="server" Text="Tower" Font-Bold="true" OnClick="PCsInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryTower" runat="server" DataTextField="InventoryTower" DataValueField="Tower" Width="90px" ValidationGroup="PCsInventory" Enabled="false" 
                                                        DataSourceID="LinqPCTower" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryTower" runat="server" ControlToValidate="ddInventoryTower" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Tower!" ValidationGroup="PCsInventory" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryTower" runat="server" Text='<%# Eval("InventoryTower") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryTower" runat="server" DataTextField="InventoryTower" DataValueField="Tower" Width="90px" ValidationGroup="PCsInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqPCTower" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryTower" runat="server" ControlToValidate="ddInventoryTower" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Tower!" ValidationGroup="PCsInventoryEdit" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="92px" ItemStyle-Width="92px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryFloor" runat="server" Text="Floor" Font-Bold="true" OnClick="PCsInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryFloor" runat="server" DataTextField="InventoryFloor" DataValueField="Floor" Width="90px" ValidationGroup="PCsInventory" Enabled="false"  
                                                        DataSourceID="LinqPCFloor" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryFloor" runat="server" ControlToValidate="ddInventoryFloor" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Floor!" ValidationGroup="PCsInventory" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryFloor" runat="server" Text='<%# Eval("InventoryFloor") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryFloor" runat="server" DataTextField="InventoryFloor" DataValueField="Floor" Width="90px" ValidationGroup="PCsInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqPCFloor" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryFloor" runat="server" ControlToValidate="ddInventoryFloor" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Floor!" ValidationGroup="PCsInventoryEdit" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="72px" ItemStyle-Width="72px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryHall" runat="server" Text="Hall" Font-Bold="true" OnClick="PCsInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryHall" runat="server" DataTextField="InventoryHall" DataValueField="Hall" Width="70px" ValidationGroup="PCsInventory" Enabled="false"  
                                                        DataSourceID="LinqPCHall" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryHall" runat="server" ControlToValidate="ddInventoryHall" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Hall!" ValidationGroup="PCsInventory" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryHall" runat="server" Text='<%# Eval("InventoryHall") %>' Width="70px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryHall" runat="server" DataTextField="InventoryHall" DataValueField="Hall" Width="70px" ValidationGroup="PCsInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqPCHall" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryHall" runat="server" ControlToValidate="ddInventoryHall" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Hall!" ValidationGroup="PCsInventoryEdit" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="72px" ItemStyle-Width="72px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryRoom" runat="server" Text="Room" Font-Bold="true" OnClick="PCsInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryRoom" runat="server" DataTextField="InventoryRoom" DataValueField="Room" Width="70px" ValidationGroup="PCsInventory" Enabled="false"  
                                                        DataSourceID="LinqPCRoom" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryRoom" runat="server" ControlToValidate="ddInventoryRoom" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Room!" ValidationGroup="PCsInventory" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryRoom" runat="server" Text='<%# Eval("InventoryRoom") %>' Width="70px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryRoom" runat="server" DataTextField="InventoryRoom" DataValueField="Room" Width="70px" ValidationGroup="PCsInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqPCRoom" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPCLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryRoom" runat="server" ControlToValidate="ddInventoryRoom" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Room!" ValidationGroup="PCsInventoryEdit" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
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
                                    <asp:ValidationSummary ID="ValidationSummaryPCsInventory" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="PCsInventory" />
                                    <asp:ValidationSummary ID="ValidationSummaryPCsInventoryEdit" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="PCsInventoryEdit" />
                                    <asp:Label ID="lbPCsMessage" runat="server" Text=""></asp:Label>
                                    <br />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridViewPCsInventory" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                        <asp:LinqDataSource ID="LinqPCsInventory" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Active DESC, PCName" TableName="lkpInventoryPCs"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPCsLocation" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" TableName="tblInventoryPCs"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPCsUsers" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" TableName="tblInventoryUsers"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
                        </asp:LinqDataSource>
                        <asp:SqlDataSource ID="SQLPCs" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                        <asp:LinqDataSource ID="LinqPCOrganization" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Organization" TableName="lkpInventoryOrganizations" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPCTower" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Tower" TableName="lkpInventoryTowers" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPCFloor" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Floor" TableName="lkpInventoryFloors" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPCHall" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Hall" TableName="lkpInventoryHalls" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPCRoom" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Room" TableName="lkpInventoryRooms" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqStaffList" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="EnterDate DESC" TableName="tblStaffs">
                        </asp:LinqDataSource>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="TabPanelPrinters" runat="server" HeaderText="Printers" Enabled="true" CssClass="body">
                    <ContentTemplate>
                        <asp:Panel ID="PanelPrinters" runat="server" Width="1260px" BackColor="#F9F9F9" class="body" DefaultButton="btnSearchPrinters">
                            <asp:UpdatePanel ID="UpdatePanelPrinters" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <br />
                                    <table width="1200px">
                                        <tr>
                                            <td style="width: 60px; height:30px;" align="center">
                                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="0">
                                                    <ProgressTemplate>
                                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            <td style="width: 400px" align="left">
                                                <asp:TextBox ID="txtSearchPrinters" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPrinter" runat="server" ControlToValidate="txtSearchPrinters"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                <asp:Button ID="btnSearchPrinters" runat="server" Text="Search" OnClick="SearchPrinters_Onclick" Font-Size="10px" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbPrinters" runat="server" Text="Printers" Font-Size="Large" Font-Bold="true" Font-Underline="True"></asp:Label>
                                            </td>
                                            <td style="width: 400px" align="right">
                                                <asp:Button ID="btnReportPrinters" runat="server" Text="View Report" OnClick="btnReport_Click" Font-Size="10px"/>
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
                                    <div id="divGridViewPrintersInventory" runat="server" style="overflow:auto; max-height: 500px;">
                                    <asp:GridView ID="GridViewPrintersInventory" runat="server" Font-Size="12px" AutoGenerateColumns="False"  
                                        PageSize="300" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3" HeaderStyle-CssClass="PrinterHeader"
                                        ForeColor="Black" GridLines="Vertical" BorderWidth="0px" ShowHeader="True" ShowHeaderWhenEmpty ="false"
                                        ShowFooter="False" EnableViewState="True" DataSourceID="SQLPrinters" DataKeyNames="Id" 
                                        OnRowCommand="GridViewPrintersInventory_RowCommand"
                                        OnRowDataBound="GridViewPrintersInventory_RowDataBound">
                                        <RowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" ToolTip="Add New Printer." ValidationGroup="PrintersInventory" Font-Size="8px"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/EditFile.png" CausesValidation="False"
                                                        CommandName="Edit" ToolTip="Edit Information." Width="17px" Height="17px" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/DeleteFile.png" CausesValidation="False"
                                                        CommandName="DeletePrinter" ToolTip="Delete Information." Width="17px" Height="17px"
                                                        OnClientClick="return confirm('Are you sure you want to Delete this File?');" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/Images/SaveFile.gif" OnClientClick="valEdit(this);"
                                                        CommandName="UpdatePrinter" ToolTip="Update Information." Width="17px" Height="17px" ValidationGroup="PrintersInventoryEdit" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/Images/CancelFile.gif"
                                                        CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update." Width="17px"
                                                        Height="17px" />
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkPrinterName" runat="server" Text="Printer Name" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtPrinterName" runat="server" Text="" Width="90px" MaxLength="50"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPrinterName" runat="server" ControlToValidate="txtPrinterName"
                                                                ErrorMessage="Please Enter a Printer Name." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                                ValidationGroup="PrintersInventory"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrinterName" ValidationGroup="PrintersInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbPrinterName" runat="server" Text='<%# Eval("PrinterName") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtPrinterName" runat="server" Text='<%# Eval("PrinterName") %>' Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPrinterName" runat="server" ControlToValidate="txtPrinterName"
                                                        ErrorMessage="Please Enter a Printer Name." Font-Size="X-Large" Text="*" ForeColor="Red" Display="Dynamic"
                                                        ValidationGroup="PrintersInventoryEdit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPrinterName" ValidationGroup="PrintersInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="70px" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" >
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkTagId" runat="server" Text="Tag Id" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtTagId" runat="server" Text="" Width="60px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTagId" ValidationGroup="PrintersInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbTagId" runat="server" Text='<%# Eval("TagId") %>' Width="60px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTagId" runat="server" Text='<%# Eval("TagId") %>' Width="60px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTagId" ValidationGroup="PrintersInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkModel" runat="server" Text="Model" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtModel" runat="server" Text="" Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtModel" ValidationGroup="PrintersInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbModel" runat="server" Text='<%# Eval("Model") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtModel" runat="server" Text='<%# Eval("Model") %>' Width="90px" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtModel" ValidationGroup="PrintersInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkFaxNumber" runat="server" Text="Fax Number" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtFaxNumber" runat="server" Text="" Width="90px" MaxLength="12" onkeydown="setHyphensFax();"></asp:TextBox>
                                                            <ajax:TextBoxWatermarkExtender ID="tbweFaxNumber" runat="server" TargetControlID="txtFaxNumber"
                                                                WatermarkCssClass="watermark" WatermarkText="###-###-####"></ajax:TextBoxWatermarkExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtFaxNumber" ValidationGroup="PrintersInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbFaxNumber" runat="server" Text='<%# Eval("Fax") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtFaxNumber" runat="server" Text='<%# Eval("Fax") %>' Width="90px" MaxLength="12" onkeydown="setHyphensFax();"></asp:TextBox>
                                                    <ajax:TextBoxWatermarkExtender ID="tbweFaxNumber" runat="server" TargetControlID="txtFaxNumber"
                                                        WatermarkCssClass="watermark" WatermarkText="###-###-####"></ajax:TextBoxWatermarkExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtFaxNumber" ValidationGroup="PrintersInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="150px" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                            <asp:LinkButton ID="linkNotes" runat="server" Text="Notes" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                            <br /><br />
                                                            <asp:TextBox ID="txtNotes" runat="server" Text="" Width="140px" MaxLength="250"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtNotes" ValidationGroup="PrintersInventory"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbNotes" runat="server" Text='<%# Eval("Notes") %>' Width="140px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNotes" runat="server" Text='<%# Eval("Notes") %>' Width="140px" MaxLength="250"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtNotes" ValidationGroup="PrintersInventoryEdit"
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="30px" ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkUH" runat="server" Text="UH" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUH" runat="server"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Checked='<%# Eval("UH") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUH" runat="server" Checked='<%# Eval("UH") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="30px" ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="linkUT" runat="server" Text="UT" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbUT" runat="server"/>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Checked='<%# Eval("UT") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbUT" runat="server" Checked='<%# Eval("UT") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="40px" ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lbActive" runat="server" Text="Active" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:Label>
                                                    <br /><br />
                                                    <asp:CheckBox ID="cbActive" runat="server" Enabled="false" Checked="true" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' Enabled="false" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Eval("Active") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="92px" ItemStyle-Width="92px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryOrganization" runat="server" Text="Organization" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryOrganization" runat="server" DataTextField="InventoryOrganization" DataValueField="Organization" Width="90px" ValidationGroup="PrintersInventory" 
                                                        DataSourceID="LinqPrinterOrganization" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryOrganization" runat="server" Text='<%# Eval("InventoryOrganization") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryOrganization" runat="server" DataTextField="InventoryOrganization" DataValueField="Organization" Width="90px" ValidationGroup="PrintersInventoryEdit" 
                                                        DataSourceID="LinqPrinterOrganization" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="92px" ItemStyle-Width="92px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryTower" runat="server" Text="Tower" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryTower" runat="server" DataTextField="InventoryTower" DataValueField="Tower" Width="90px" ValidationGroup="PrintersInventory" Enabled="false" 
                                                        DataSourceID="LinqPrinterTower" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryTower" runat="server" ControlToValidate="ddInventoryTower" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Tower!" ValidationGroup="PrintersInventory" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryTower" runat="server" Text='<%# Eval("InventoryTower") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryTower" runat="server" DataTextField="InventoryTower" DataValueField="Tower" Width="90px" ValidationGroup="PrintersInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqPrinterTower" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryTower" runat="server" ControlToValidate="ddInventoryTower" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Tower!" ValidationGroup="PrintersInventoryEdit" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="92px" ItemStyle-Width="92px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryFloor" runat="server" Text="Floor" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryFloor" runat="server" DataTextField="InventoryFloor" DataValueField="Floor" Width="90px" ValidationGroup="PrintersInventory" Enabled="false"  
                                                        DataSourceID="LinqPrinterFloor" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryFloor" runat="server" ControlToValidate="ddInventoryFloor" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Floor!" ValidationGroup="PrintersInventory" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryFloor" runat="server" Text='<%# Eval("InventoryFloor") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryFloor" runat="server" DataTextField="InventoryFloor" DataValueField="Floor" Width="90px" ValidationGroup="PrintersInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqPrinterFloor" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryFloor" runat="server" ControlToValidate="ddInventoryFloor" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Floor!" ValidationGroup="PrintersInventoryEdit" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="72px" ItemStyle-Width="72px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryHall" runat="server" Text="Hall" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryHall" runat="server" DataTextField="InventoryHall" DataValueField="Hall" Width="70px" ValidationGroup="PrintersInventory" Enabled="false"  
                                                        DataSourceID="LinqPrinterHall" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryHall" runat="server" ControlToValidate="ddInventoryHall" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Hall!" ValidationGroup="PrintersInventory" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryHall" runat="server" Text='<%# Eval("InventoryHall") %>' Width="70px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryHall" runat="server" DataTextField="InventoryHall" DataValueField="Hall" Width="70px" ValidationGroup="PrintersInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqPrinterHall" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryHall" runat="server" ControlToValidate="ddInventoryHall" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Hall!" ValidationGroup="PrintersInventoryEdit" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="72px" ItemStyle-Width="72px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                                <HeaderTemplate>
                                                   <asp:LinkButton ID="linkInventoryRoom" runat="server" Text="Room" Font-Bold="true" OnClick="PrintersInventorySort" />
                                                    <br /><br />
                                                    <asp:DropDownList ID="ddInventoryRoom" runat="server" DataTextField="InventoryRoom" DataValueField="Room" Width="70px" ValidationGroup="PrintersInventory" Enabled="false"  
                                                        DataSourceID="LinqPrinterRoom" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocation_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryRoom" runat="server" ControlToValidate="ddInventoryRoom" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Room!" ValidationGroup="PrintersInventory" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbInventoryRoom" runat="server" Text='<%# Eval("InventoryRoom") %>' Width="70px"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddInventoryRoom" runat="server" DataTextField="InventoryRoom" DataValueField="Room" Width="70px" ValidationGroup="PrintersInventoryEdit" Enabled="false"  
                                                        DataSourceID="LinqPrinterRoom" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistPrinterLocationEdit_SelectedIndexChanged">
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvInventoryRoom" runat="server" ControlToValidate="ddInventoryRoom" ForeColor="Red"
                                                        Display="Dynamic" ErrorMessage="Please Select a Room!" ValidationGroup="PrintersInventoryEdit" Enabled="false"
                                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
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
                                    <asp:ValidationSummary ID="ValidationSummaryPrintersInventory" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="PrintersInventory" />
                                    <asp:ValidationSummary ID="ValidationSummaryPrintersInventoryEdit" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                        HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="PrintersInventoryEdit" />
                                    <asp:Label ID="lbPrintersMessage" runat="server" Text=""></asp:Label>
                                    <br />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridViewPrintersInventory" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                        <asp:LinqDataSource ID="LinqPrintersInventory" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Active DESC, PrinterName" TableName="lkpInventoryPrinters"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPrintersLocation" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" TableName="tblInventoryPrinters"
                            EnableInsert="true" EnableUpdate="true" EnableDelete="true">
                        </asp:LinqDataSource>
                        <asp:SqlDataSource ID="SQLPrinters" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                        <asp:LinqDataSource ID="LinqPrinterOrganization" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Organization" TableName="lkpInventoryOrganizations" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPrinterTower" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Tower" TableName="lkpInventoryTowers" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPrinterFloor" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Floor" TableName="lkpInventoryFloors" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPrinterHall" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Hall" TableName="lkpInventoryHalls" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqPrinterRoom" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Room" TableName="lkpInventoryRooms" Where="Active == True">
                        </asp:LinqDataSource>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="TabPanelOverview" runat="server" HeaderText="Overview" Enabled="true" CssClass="body">
                    <ContentTemplate>
                        <asp:Panel ID="PanelOverview" runat="server" Width="1260px" BackColor="#F9F9F9" class="body" DefaultButton="btnSearchOverview">
                            <br />
                            <table width="1200px">
                                <tr>
                                    <td style="width: 60px; height: 30px;" align="center">
                                        <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="0">
                                            <ProgressTemplate>
                                                <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td style="width: 400px" align="left">
                                        <asp:TextBox ID="txtSearchOverview" runat="server" Width="200px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorOverview" runat="server" ControlToValidate="txtSearchOverview" 
                                                    ErrorMessage="Invalid Character" ForeColor="Red" Text="*" Font-Size="X-Large" Display="Dynamic"
                                                    ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,99999}$"></asp:RegularExpressionValidator>
                                        <asp:Button ID="btnSearchOverview" runat="server" Text="Search" OnClick="SearchOverview_Onclick" Font-Size="10px" />

                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbOverview" runat="server" Text="Overview" Font-Size="Large" Font-Bold="true" Font-Underline="True"></asp:Label>
                                    </td>
                                    <td style="width: 400px" align="right">
                                        <asp:Button ID="btnReportOverview" runat="server" Text="View Report" OnClick="btnReport_Click" Font-Size="10px"/>
                                        <asp:Button ID="btnReportOverviewUngrouped" runat="server" Text="View Report(Ungrouped)" OnClick="btnReport_Click" Font-Size="10px"/>
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
                            <div id="divGridviewOverview" runat="server" style="overflow: auto; max-height: 500px;">
                                <asp:GridView ID="GridViewOverview" runat="server" Font-Size="12px" AutoGenerateColumns="False"
                                    PageSize="300" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3" HeaderStyle-CssClass="OverviewHeader"
                                    ForeColor="Black" GridLines="Vertical" BorderWidth="0px" ShowHeader="True" ShowHeaderWhenEmpty="False"
                                    ShowFooter="False" EnableViewState="True" DataSourceID="SQLOverview"
                                    OnRowCommand="GridViewOverview_RowCommand"
                                    OnRowDataBound="GridViewOverview_RowDataBound">
                                    <RowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" Font-Size="8px"/>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="linkInventoryOrganization" runat="server" Text="Hall" Font-Bold="true" OnClick="OverviewInventorySort" />
                                                <br />
                                                <br />
                                                <asp:DropDownList ID="ddInventoryOrganization" runat="server" DataTextField="InventoryOrganization" DataValueField="Organization" Width="90px"
                                                    DataSourceID="LinqOverviewOrganization" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistOverviewLocation_SelectedIndexChanged">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbInventoryOrganization" runat="server" Text='<%# Eval("InventoryOrganization") %>' Width="70px"></asp:Label>
                                                <asp:Label ID="lbOrganization" runat="server" Text='<%# Eval("Organization") %>' Width="70px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="linkInventoryTower" runat="server" Text="Tower" Font-Bold="true" OnClick="OverviewInventorySort" />
                                                <br />
                                                <br />
                                                <asp:DropDownList ID="ddInventoryTower" runat="server" DataTextField="InventoryTower" DataValueField="Tower" Width="90px" Enabled="false"
                                                    DataSourceID="LinqOverviewTower" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistOverviewLocation_SelectedIndexChanged">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbInventoryTower" runat="server" Text='<%# Eval("InventoryTower") %>' Width="70px"></asp:Label>
                                                <asp:Label ID="lbTower" runat="server" Text='<%# Eval("Tower") %>' Width="70px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="linkInventoryFloor" runat="server" Text="Floor" Font-Bold="true" OnClick="OverviewInventorySort" />
                                                <br />
                                                <br />
                                                <asp:DropDownList ID="ddInventoryFloor" runat="server" DataTextField="InventoryFloor" DataValueField="Floor" Width="90px" Enabled="false"
                                                    DataSourceID="LinqOverviewFloor" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistOverviewLocation_SelectedIndexChanged">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbInventoryFloor" runat="server" Text='<%# Eval("InventoryFloor") %>' Width="70px"></asp:Label>
                                                <asp:Label ID="lbFloor" runat="server" Text='<%# Eval("Floor") %>' Width="70px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="linkInventoryHall" runat="server" Text="Hall" Font-Bold="true" OnClick="OverviewInventorySort" />
                                                <br />
                                                <br />
                                                <asp:DropDownList ID="ddInventoryHall" runat="server" DataTextField="InventoryHall" DataValueField="Hall" Width="70px" Enabled="false"
                                                    DataSourceID="LinqOverviewHall" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistOverviewLocation_SelectedIndexChanged">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbInventoryHall" runat="server" Text='<%# Eval("InventoryHall") %>' Width="70px"></asp:Label>
                                                <asp:Label ID="lbHall" runat="server" Text='<%# Eval("Hall") %>' Width="70px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="linkInventoryRoom" runat="server" Text="Room" Font-Bold="true" OnClick="OverviewInventorySort" />
                                                <br />
                                                <br />
                                                <asp:DropDownList ID="ddInventoryRoom" runat="server" DataTextField="InventoryRoom" DataValueField="Room" Width="70px" Enabled="false"
                                                    DataSourceID="LinqOverviewRoom" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="dropdownlistOverviewLocation_SelectedIndexChanged">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbInventoryRoom" runat="server" Text='<%# Eval("InventoryRoom") %>' Width="70px"></asp:Label>
                                                <asp:Label ID="lbRoom" runat="server" Text='<%# Eval("Room") %>' Width="70px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="140px" ItemStyle-Width="140px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Label ID="lbPrinters" runat="server" Text="Printers" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:Label>
                                                <br />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:GridView ID="GridViewOverviewPrinters" runat="server" Font-Size="12px" AutoGenerateColumns="False"
                                                    PageSize="300" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3"
                                                    ForeColor="Black" GridLines="None" BorderWidth="0px" ShowHeader="False" ShowHeaderWhenEmpty="False"
                                                    ShowFooter="False" EnableViewState="True" DataSourceID="SqlOverviewPrinters">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="130px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkPrinters" runat="server" Text='<%# Eval("PrinterName") %>' UseSubmitBehavior="True" OnClick="OverviewLinkButton_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:SqlDataSource ID="SqlOverviewPrinters" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="220px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-Width="220px" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Label ID="lbPCs" runat="server" Text="PCs" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:Label>
                                                <br />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:GridView ID="GridViewOverviewPCs" runat="server" Font-Size="12px" AutoGenerateColumns="False"
                                                    PageSize="300" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3"
                                                    ForeColor="Black" GridLines="None" BorderWidth="0px" ShowHeader="False" ShowHeaderWhenEmpty="False"
                                                    ShowFooter="False" EnableViewState="True" DataSourceID="SqlOverviewPCs">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="210px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkPCs" runat="server" Text='<%# Eval("PCName") %>' OnClick="OverviewLinkButton_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:SqlDataSource ID="SqlOverviewPCs" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="220px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-Width="220px" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Label ID="lbStaff" runat="server" Text="Staff" Font-Bold="true" Font-Underline="true" ForeColor="Blue"></asp:Label>
                                                <br />
                                                <br />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:GridView ID="GridViewOverviewStaff" runat="server" Font-Size="12px" AutoGenerateColumns="False"
                                                    PageSize="300" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3"
                                                    ForeColor="Black" GridLines="None" BorderWidth="0px" ShowHeader="False" ShowHeaderWhenEmpty="False"
                                                    ShowFooter="False" EnableViewState="True" DataSourceID="SqlOverviewStaff"
                                                    OnRowCommand="GridviewOverviewStaff_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="210px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkStaff" runat="server" Text='<%# Eval("StaffName") %>' CommandName="Staff" ></asp:LinkButton>
                                                                <asp:Label ID ="lbStaffUserId" runat="server" Text='<%# Eval("StaffUserId") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:SqlDataSource ID="SqlOverviewStaff" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
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
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="Overview" />
                            <br />
                        </asp:Panel>
                        <asp:SqlDataSource ID="SqlOverview" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlOverviewPrinters" runat="server" ConnectionString="<%$ ConnectionStrings:MyPortfolioConnectionString %>"></asp:SqlDataSource>
                        <asp:LinqDataSource ID="LinqOverviewOrganization" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Organization" TableName="lkpInventoryOrganizations" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqOverviewTower" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Tower" TableName="lkpInventoryTowers" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqOverviewFloor" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Floor" TableName="lkpInventoryFloors" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqOverviewHall" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Hall" TableName="lkpInventoryHalls" Where="Active == True">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqOverviewRoom" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                            EntityTypeName="" OrderBy="Room" TableName="lkpInventoryRooms" Where="Active == True">
                        </asp:LinqDataSource>
                    </ContentTemplate>
                </ajax:TabPanel>
            </ajax:TabContainer>
            <br />
            <asp:Button ID="btnReturn" Text="Return to Menu" runat="server" Font-Size="Small"
                CausesValidation="False" UseSubmitBehavior="False" ToolTip="Return to Menu" />
            <br />
            <asp:HiddenField ID="hfUser" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfBack" runat="server" />
            <asp:HiddenField ID="hfFrom" runat="server" />
            <asp:HiddenField ID="hfTabIndex" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
