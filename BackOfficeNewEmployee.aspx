<%@ Page Title="New Employee" Language="VB" MasterPageFile="~/Pages/BackOfficeMP.master" AutoEventWireup="false" CodeFile="BackOfficeNewEmployee.aspx.vb" Inherits="Pages_BackOfficeNewEmployee" %>
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
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('<%=divNewEmployee.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos = $get('<%=divNewEmployee.ClientID%>').scrollLeft;
                yPos = $get('<%=divNewEmployee.ClientID%>').scrollTop;
            }
        }

        function EndRequestHandler(sender, args) {
            if ($get('<%=divNewEmployee.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=divNewEmployee.ClientID%>').scrollLeft = xPos;
                $get('<%=divNewEmployee.ClientID%>').scrollTop = yPos;
            }
        }

        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

    </script>
    <asp:UpdatePanel ID="UpdatePanelNewEmployee" runat="server" ChildrenAsTriggers="True" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelInfo" runat="server" Width="1024px" Height="140px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbInfo" runat="server" ForeColor="White" Font-Size="Large" Width="1000px" style="text-align: left;"></asp:Label>
            </asp:Panel>
            <br />
            <asp:Label ID="lbNewEmployee" runat="server" Text="New Employee Process Checklist" Font-Size="X-Large" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="PanelNewEmployee" runat="server" BackColor="#F9F9F9" class="body" Width="1400px">
                <table width="1370px">
                    <tr>
                        <td style="width: 60px; height: 30px;" align="center">
                            <asp:UpdateProgress ID="UpdateProgressStudyMain" runat="server" DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                        <td style="width: 450px;">
                            <asp:Label ID="lbLegendText" runat="server" Text="Created By: "></asp:Label>
                            <asp:Label ID="lbLegend" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td style="width: 450px;" align="right">
                            <asp:Label ID="lbRestore" Text="Completed Records: " runat="server" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="ddEmployee" runat="server" DataTextField="EmployeeTemp" DataValueField="Id" Width="150px"
                                        DataSourceID="LinqCompleted" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        </asp:DropDownList>        
                            <asp:Button ID="btnRestore" runat="server" Text="Restore" Font-Size="Smaller" OnClientClick="return confirm('Are you sure you want to restore this record?');" />
                        </td>
                        <td style="width: 60px">&nbsp;
                        </td>
                    </tr>
                </table>
                <div id="divNewEmployee" runat="server" style="overflow:auto; width:1360px; max-height:700px">
                    <asp:GridView ID="GridViewNewEmployee" runat="server" Font-Size="12px" AutoGenerateColumns="False" AllowPaging="true"  
                        PageSize="100" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" BorderWidth="1px" ShowHeader="True" ShowHeaderWhenEmpty="True"
                        DataKeyNames="Id" DataSourceID="LinqNewEmployee" ShowFooter="False" EnableViewState="True"
                        OnRowCommand="GridViewNewEmployee_RowCommand"
                        OnRowDataBound="GridViewNewEmployee_RowDataBound"
                        OnRowUpdated="GridViewNewEmployee_RowUpdated"
                        OnRowUpdating="GridViewNewEmployee_RowUpdating">
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-Height="75px" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="NewEmployee" CommandName="Add" ToolTip="Add New Contact" Font-Size="Smaller"/>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/EditFile.png" CausesValidation="false"
                                        CommandName="Edit" ToolTip="Edit Information." Width="17px" Height="17px" />
                                    &nbsp;
                                 <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/DeleteFile.png" CausesValidation="False"
                                     CommandName="Delete" ToolTip="Delete Information." Width="17px" Height="17px"
                                     OnClientClick="return confirm('Are you sure you want to Delete this File?');" />
                                    <br />
                                    <asp:Label ID="lbId" runat="server" Text='<%# Bind("Id") %>' Visible="false" Width="50px"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/Images/SaveFile.gif" ValidationGroup="NewEmployeeEdit"
                                        CommandName="Update" ToolTip="Update Information." Width="17px"
                                        Height="17px" />
                                    &nbsp;
                                <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/Images/CancelFile.gif"
                                    CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update." Width="17px"
                                    Height="17px" />
                                    <asp:Label ID="lbId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkEmployee" runat="server" Text="New Employee" ToolTip="Type the employee name or select from dropdownlist." OnClick="Sort_OnClick"></asp:LinkButton>
                                    <br /><br />
                                    <asp:TextBox ID="txtEmployeeTemp" runat="server" Text="" Width="110px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmployeeTemp" runat="server" ControlToValidate="txtEmployeeTemp" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Enter an Employee!" ValidationGroup="NewEmployee" 
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                    <br /><br />
                                    <asp:DropDownList ID="ddEmployee" runat="server" DataTextField="Name" DataValueField="UserId" Width="110px" AutoPostBack="true" OnSelectedIndexChanged="ddEmployee_SelectedIndexChanged"
                                        DataSourceID="LinqEmployee" AppendDataBoundItems="True" Visible="false">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbEmployee" runat="server" Width="110px" Text='<%# String.Concat(Eval("tblStaff1.FName"), " ", Eval("tblStaff1.LName")) %>'></asp:Label>
                                    <asp:Label ID="lbEmployeeTemp" runat="server" Text='<%# Eval("EmployeeTemp") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmployeeTemp" runat="server" Text='<%# Bind("EmployeeTemp") %>' Width="110px" MaxLength="50" Display="Dynamic" onkeydown="setTooltip(this);" ToolTip='<%# Eval("EmployeeTemp") %>'></asp:TextBox>
                                    <asp:DropDownList ID="ddEmployee" runat="server" DataTextField="Name" DataValueField="UserId" Width="110px" SelectedValue='<%# Bind("Employee") %>' Visible="false"
                                        DataSourceID="LinqEmployee" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvEmployeeTemp" runat="server" ControlToValidate="txtEmployeeTemp" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Enter an Employee!" ValidationGroup="NewEmployeeEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkIT" runat="server" Text="Created By" OnClick="Sort_OnClick"></asp:LinkButton>
                                    <br /><br />
                                    <asp:DropDownList ID="ddIT" runat="server" DataTextField="Name" DataValueField="Id" Width="110px"
                                        DataSourceID="LinqIT" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvIT" runat="server" ControlToValidate="ddIT" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select an IT staff!" ValidationGroup="NewEmployee"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbIT" runat="server" Width="110px" Text='<%# String.Concat(Eval("lkpBackOfficeWorkOrderUser.tblStaff.FName"), " ", Eval("lkpBackOfficeWorkOrderUser.tblStaff.LName")) %>'></asp:Label>
                                    <asp:Label ID="lbITBy" runat="server" Text='<%# Eval("IT") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddIT" runat="server" DataTextField="Name" DataValueField="Id" width="110px" SelectedValue='<%# Bind("IT") %>'
                                        DataSourceID="LinqIT" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvIT" runat="server" ControlToValidate="ddIT" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select an IT staff!" ValidationGroup="NewEmployeeEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkIncomingStatus" runat="server" Text="IncomingStatus" OnClick="Sort_OnClick"></asp:LinkButton>
                                    <br /><br />
                                    <asp:DropDownList ID="ddIncomingStatus" runat="server" DataTextField="Status" DataValueField="Id" Width="110px"
                                        DataSourceID="LinqIncomingStatus" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvIncomingStatus" runat="server" ControlToValidate="ddIncomingStatus" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select an IncomingStatus!" ValidationGroup="NewEmployee"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbIncomingStatus" runat="server" Width="110px" Text='<%# Eval("lkpBackOfficeIncomingStatus.Status") %>'></asp:Label>
                                    <asp:Label ID="lbIncomingStatusBy" runat="server" Text='<%# Eval("IncomingStatusBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddIncomingStatus" runat="server" DataTextField="Status" DataValueField="Id" Width="110px" SelectedValue='<%# Bind("IncomingStatus") %>'
                                        DataSourceID="LinqIncomingStatus" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvIncomingStatus" runat="server" ControlToValidate="ddIncomingStatus" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select an IncomingStatus!" ValidationGroup="NewEmployeeEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkSupervisor" runat="server" Text="Supervisor" OnClick="Sort_OnClick"></asp:LinkButton>
                                    <br /><br />
                                    <asp:DropDownList ID="ddSupervisor" runat="server" DataTextField="Name" DataValueField="UserId" Width="110px"
                                        DataSourceID="LinqSupervisor" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvSupervisor" runat="server" ControlToValidate="ddSupervisor" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select an Supervisor!" ValidationGroup="NewEmployee"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbSupervisor" runat="server" Width="110px" Text='<%# String.Concat(Eval("tblStaff.FName"), " ", Eval("tblStaff.LName")) %>'></asp:Label>
                                    <asp:Label ID="lbSupervisorBy" runat="server" Text='<%# Eval("SupervisorBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddSupervisor" runat="server" DataTextField="Name" DataValueField="UserId" Width="110px" SelectedValue='<%# Bind("Supervisor") %>'
                                        DataSourceID="LinqSupervisor" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvSupervisor" runat="server" ControlToValidate="ddSupervisor" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Please Select an Supervisor!" ValidationGroup="NewEmployeeEdit"
                                        Text="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkStartDate" runat="server" Text="StartDate" OnClick="Sort_OnClick"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtStartDate" runat="server" Text="" Width="70px" MaxLength="10" onkeydown="setDate(this);"></asp:TextBox>
                                    <asp:RangeValidator ID="rvStartDate" runat="server" ControlToValidate="txtStartDate" ValidationGroup="NewEmployee" Display="Dynamic"
                                        ErrorMessage="Checked Out Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="1/1/3000" MinimumValue="1/1/1900"></asp:RangeValidator>
                                    <ajax:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtStartDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajax:TextBoxWatermarkExtender ID="tbweStartDate" runat="server" TargetControlID="txtStartDate"
                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbStartDate" runat="server" Text='<%# Eval("StartDate", "{0:MM/dd/yyyy}") %>' Width="70px"></asp:Label>
                                    <asp:Label ID="lbStartDateBy" runat="server" Text='<%# Eval("StartDateBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStartDate" runat="server" Text='<%# Eval("StartDate", "{0:MM/dd/yyyy}") %>' Width="70px" MaxLength="10" onkeydown="setDate(this);"></asp:TextBox>
                                    <asp:RangeValidator ID="rvStartDate" runat="server" ControlToValidate="txtStartDate" ValidationGroup="NewEmployeeEdit" Display="Dynamic"
                                        ErrorMessage="Checked Out Date is not valid." Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red" MaximumValue="01/01/3000" MinimumValue="01/01/1900"></asp:RangeValidator>
                                    <ajax:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtStartDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajax:TextBoxWatermarkExtender ID="tbweStartDate" runat="server" TargetControlID="txtStartDate"
                                        WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkTitle" runat="server" Text="Title" OnClick="Sort_OnClick" ToolTip="Enter the employee title."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtTitle" runat="server" Text="" Width="110px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("Title") %>' Width="110px"></asp:Label>
                                    <asp:Label ID="lbTitleBy" runat="server" Text='<%# Eval("TitleBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' Width="110px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("Title") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkConfidentialityForm" runat="server" Text="Confidentiality Form" OnClick="Sort_OnClick" ToolTip="Enter the date when the Confidentiality Form was sent."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtConfidentialityForm" runat="server" Text="" Width="110px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbConfidentialityForm" runat="server" Text='<%# Eval("ConfidentialityForm") %>' Width="110px"></asp:Label>
                                    <asp:Label ID="lbConfidentialityFormBy" runat="server" Text='<%# Eval("ConfidentialityFormBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtConfidentialityForm" runat="server" Text='<%# Bind("ConfidentialityForm") %>' Width="110px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip='<%# Eval("ConfidentialityForm") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkSentToDataSecurity" runat="server" Text="Data Security" OnClick="Sort_OnClick" ToolTip="Enter the date the employee forms were sent to Data Security."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtSentToDataSecurity" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbSentToDataSecurity" runat="server" Text='<%# Eval("SentToDataSecurity") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbSentToDataSecurityBy" runat="server" Text='<%# Eval("SentToDataSecurityBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSentToDataSecurity" runat="server" Text='<%# Bind("SentToDataSecurity") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("SentToDataSecurity") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkWelcomeEmail" runat="server" Text="Welcome Email" OnClick="Sort_OnClick" ToolTip="Enter the date the welcome email was sent."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtWelcomeEmail" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbWelcomeEmail" runat="server" Text='<%# Eval("WelcomeEmail") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbWelcomeEmailBy" runat="server" Text='<%# Eval("WelcomeEmailBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtWelcomeEmail" runat="server" Text='<%# Bind("WelcomeEmail") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("WelcomeEmail") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkAccount" runat="server" Text=" Account" OnClick="Sort_OnClick" ToolTip="Enter the date when their  account was created.  Create their  Database profile, add users to the correct Time Study roles, employee ID, RC code, Location(Tower, Floor, Hall, Room#), etc."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtAccount" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbAccount" runat="server" Text='<%# Eval("Account") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbAccountBy" runat="server" Text='<%# Eval("AccountBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAccount" runat="server" Text='<%# Bind("Account") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("Account") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkUNETAccount" runat="server" Text="UNET Account" OnClick="Sort_OnClick" ToolTip="Enter the date the UNET account was created."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtUNETAccount" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbUNETAccount" runat="server" Text='<%# Eval("UNETAccount") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbUNETAccountBy" runat="server" Text='<%# Eval("UNETAccountBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtUNETAccount" runat="server" Text='<%# Bind("UNETAccount") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("UNETAccount") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkPhoneVoicemail" runat="server" Text="Phone/Voicemail" OnClick="Sort_OnClick" ToolTip="Enter the date or work order #. Create work order to have office phone assigned to them and include voice mail set up for user. " ></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtPhoneVoicemail" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbPhoneVoicemail" runat="server" Text='<%# Eval("PhoneVoicemail") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbPhoneVoicemailBy" runat="server" Text='<%# Eval("PhoneVoicemailBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPhoneVoicemail" runat="server" Text='<%# Bind("PhoneVoicemail") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("PhoneVoicemail") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkEFax" runat="server" Text="E-Fax" OnClick="Sort_OnClick" ToolTip="Enter a date. Add user to the E-fax folder requested.  Must do this on the efax spreadsheet and the properties of the folder itself (S:\department\Transplant\Information Systems Folder\Projects\Fax - XMedius Application\)."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtEFax" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbEFax" runat="server" Text='<%# Eval("EFax") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbEFaxBy" runat="server" Text='<%# Eval("EFaxBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEFax" runat="server" Text='<%# Bind("EFax") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("EFax") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkMailGroups" runat="server" Text="Mail Groups" OnClick="Sort_OnClick" ToolTip="Enter the date the user was added to the Transplant Mail group list and Transplant Event list."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtMailGroups" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbMailGroups" runat="server" Text='<%# Eval("MailGroups") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbMailGroupsBy" runat="server" Text='<%# Eval("MailGroupsBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMailGroups" runat="server" Text='<%# Bind("MailGroups") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("MailGroups") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkAdobe" runat="server" Text="Adobe DC" OnClick="Sort_OnClick" ToolTip="Enter the date the user was given an Adobe DC account."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtAdobe" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbAdobe" runat="server" Text='<%# Eval("Adobe") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbAdobeBy" runat="server" Text='<%# Eval("AdobeBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAdobe" runat="server" Text='<%# Bind("Adobe") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("Adobe") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkWebEx" runat="server" Text="WebEx" OnClick="Sort_OnClick" ToolTip="Enter the date the user was given a WebEx account."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtWebEx" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbWebEx" runat="server" Text='<%# Eval("WebEx") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbWebExBy" runat="server" Text='<%# Eval("WebExBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtWebEx" runat="server" Text='<%# Bind("WebEx") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("WebEx") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkPremier" runat="server" Text="Premier" OnClick="Sort_OnClick" ToolTip="Enter the date the user was given Premier access."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtPremier" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbPremier" runat="server" Text='<%# Eval("Premier") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbPremierBy" runat="server" Text='<%# Eval("PremierBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPremier" runat="server" Text='<%# Bind("Premier") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip='<%# Eval("Premier") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkOfficeDepot" runat="server" Text="Office Depot" OnClick="Sort_OnClick" ToolTip="Enter the date the user was given Office Depot access."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtOfficeDepot" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbOfficeDepot" runat="server" Text='<%# Eval("OfficeDepot") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbOfficeDepotBy" runat="server" Text='<%# Eval("OfficeDepotBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtOfficeDepot" runat="server" Text='<%# Bind("OfficeDepot") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("OfficeDepot") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkTMHPAccess" runat="server" Text="TMHP Access" OnClick="Sort_OnClick" ToolTip="Enter the date TMHP access to TMHP.Request@uhs-sa.com."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtTMHPAccess" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbTMHPAccess" runat="server" Text='<%# Eval("TMHPAccess") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbTMHPAccessBy" runat="server" Text='<%# Eval("TMHPAccessBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTMHPAccess" runat="server" Text='<%# Bind("TMHPAccess") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("TMHPAccess") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkMedicareAccess" runat="server" Text="Medicare" OnClick="Sort_OnClick" ToolTip="Enter the date. Send email to Lucila Gonzalez for Medicare Access."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtMedicareAccess" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbMedicareAccess" runat="server" Text='<%# Eval("MedicareAccess") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbMedicareAccessBy" runat="server" Text='<%# Eval("MedicareAccessBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMedicareAccess" runat="server" Text='<%# Bind("MedicareAccess") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("MedicareAccess") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkAllscriptsAccess" runat="server" Text="Allscripts" OnClick="Sort_OnClick" ToolTip="Enter the date. Send email to Regina.Reed @uhs-sa.com for allscripts access."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtAllscriptsAccess" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbAllscriptsAccess" runat="server" Text='<%# Eval("AllscriptsAccess") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbAllscriptsAccessBy" runat="server" Text='<%# Eval("AllscriptsAccessBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAllscriptsAccess" runat="server" Text='<%# Bind("AllscriptsAccess") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("AllscriptsAccess") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkAMBNurseClass" runat="server" Text="AMB Nurse Class" OnClick="Sort_OnClick" ToolTip="Denise-Schedule all New employees for the AMB Nurse share class. Next available."></asp:LinkButton>
                                    <br />
                                    <asp:TextBox ID="txtAMBNurseClass" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbAMBNurseClass" runat="server" Text='<%# Eval("AMBNurseClass") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbAMBNurseClassBy" runat="server" Text='<%# Eval("AMBNurseClassBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAMBNurseClass" runat="server" Text='<%# Bind("AMBNurseClass") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("AMBNurseClass") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="linkSentAccessToEmployee" runat="server" Text="Sent Access" OnClick="Sort_OnClick" ToolTip="Enter the date the access was sent to employee."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtSentAccessToEmployee" runat="server" Text="" Width="90px" MaxLength="50" onkeydown="setTooltip(this);"></asp:TextBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbSentAccessToEmployee" runat="server" Text='<%# Eval("SentAccessToEmployee") %>' Width="90px"></asp:Label>
                                    <asp:Label ID="lbSentAccessToEmployeeBy" runat="server" Text='<%# Eval("SentAccessToEmployeeBy") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSentAccessToEmployee" runat="server" Text='<%# Bind("SentAccessToEmployee") %>' Width="90px" MaxLength="50" onkeydown="setTooltip(this);" ToolTip ='<%# Eval("SentAccessToEmployee") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="50px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top">
                                <HeaderTemplate>
                                    <asp:Label ID="lbCompleted" runat="server" Text="Completed" Font-Bold="true" Font-Underline="true" ForeColor="Blue" ></asp:Label>
                                    <br />
                                    <br />
                                    <asp:CheckBox ID="cbCompleted" runat="server" Enabled="false" ToolTip="Mark only if all items on this list has been completed.  This will remove the entire row from this table and will no longer be viewable." />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbCompleted" runat="server" Enabled="false" ToolTip="Mark only if all items on this list has been completed.  This will remove the entire row from this table and will no longer be viewable." />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="cbCompleted" runat="server" Enabled="true" Checked='<%# Bind("Completed") %>' OnClick="if(!confirm('Are you sure you want to mark this as Complete? This will remove the entire row from this table and will no longer be viewable.'))return false;" ToolTip="Mark only if all items on this list has been completed.  This will remove the entire row from this table and will no longer be viewable." />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#FFEAD5" Font-Bold="True" />
                        <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Black" BorderWidth="2px" />
                        <RowStyle HorizontalAlign="Center" BackColor="White" />
                        <AlternatingRowStyle BackColor="#f0f0f0" />
                    </asp:GridView>
                    <br />
                    <br />
                    </div>
                <br />
                <asp:ValidationSummary ID="ValidationSummaryNewEmployee" runat="server" ShowMessageBox="True" ShowSummary="True" ForeColor="Red"
                    HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="NewEmployee" DisplayMode="List" />
                <asp:ValidationSummary ID="ValidationSummaryNewEmployeeEdit" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                    HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="NewEmployeeEdit" DisplayMode="List" />
                <asp:Label ID="lbNewEmployeeMessage" runat="server" Text=""></asp:Label>
                <br />
                <br />
            </asp:Panel>
            <asp:LinqDataSource ID="LinqNewEmployee" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="tblBackOfficeNewEmployeeProcesses" OrderBy="StartDate DESC" Where="Completed == False"
                EnableInsert="true" EnableUpdate="true" EnableDelete="true">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqIT" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="lkpBackOfficeWorkOrderUsers" Select="new(Id, (tblStaff.FName + ' ' + tblStaff.LName) AS Name)"
                Where="Active==True" OrderBy="tblStaff.FName, tblStaff.LName">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqEmployee" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="tblStaffs" Select="new(UserId, (FName + ' ' + LName) AS Name)"
                OrderBy="FName, LName">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqIncomingStatus" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="lkpBackOfficeIncomingStatus" Select="new(Id, Status)"
                OrderBy="Status">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqSupervisor" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="tblStaffs" Select="new(UserId, (FName + ' ' + LName) AS Name)"
                OrderBy="FName, LName">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqCompleted" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" TableName="tblBackOfficeNewEmployeeProcesses" Select="new(Id, (tblStaff1.FName + ' ' + tblStaff1.LName) AS Name, EmployeeTemp)"
                Where="Completed == True" OrderBy="StartDate DESCENDING">
            </asp:LinqDataSource>
            <br />
            <asp:Button ID="btnReturn" Text="Return to Menu" runat="server" Width="160px"
                CausesValidation="False" UseSubmitBehavior="False" ToolTip="Return to Menu" Font-Size="Smaller" />
            <br />
            <asp:HiddenField ID="hfUser" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfBack" runat="server" />
            <asp:HiddenField ID="hfFrom" runat="server" />
            </ContentTemplate>
        <Triggers>
           <asp:AsyncPostBackTrigger ControlID="GridViewNewEmployee" EventName="RowCommand" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
