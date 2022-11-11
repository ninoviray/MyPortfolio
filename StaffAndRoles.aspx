<%@ Page Title="Staff and Roles" Language="VB" MasterPageFile="~/Pages/TimeStudyMP.master" AutoEventWireup="false" CodeFile="StaffAndRoles.aspx.vb" Inherits="Pages_StaffAndRoles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanelStaffAndRoles" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="PanelTimeStudyInfo" runat="server" Width="1024px" Height="80px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbTimeStudyInfo" runat="server" ForeColor="White" Font-Size="Large" Width="700px" style="text-align: left;"></asp:Label>
            </asp:Panel>
        <br />
    <div align="center">
    <h2>Staff Position Role Management</h2>
    <h3>Manage Position Roles By Staff</h3>
    <p>
        <b>Select a Staff:</b>
        <asp:DropDownList ID="ddUserList" runat="server" AutoPostBack="True" 
            DataTextField="MyName" DataValueField="UserId"
            ToolTip="Select a User to Manage Entity/Roles.">
        </asp:DropDownList>
    </p>
    <table style="margin-left: auto; margin-right: auto; width: 680px;">
        <tr align="left" valign="top">
            <td>
                <asp:Repeater ID="StaffRoleList" runat="server">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="cbRole" AutoPostBack="true" Text='<%# Container.DataItem %>'
                            OnCheckedChanged="cbRole_CheckChanged" />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
            <td>
                <asp:Repeater ID="StaffRoleListII" runat="server">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="cbRoleII" AutoPostBack="true" Text='<%# Container.DataItem %>'
                            OnCheckedChanged="cbRoleII_CheckChanged" />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p align="center">
                    <asp:Label ID="ActionStatusII" runat="server" Text="" CssClass="Important"></asp:Label>
                </p>
            </td>
        </tr>
    </table>
        <hr style="width:680px" />
    <h3>Manage Staff By Role</h3>
    <p>
        <b>Select a Staff Position Role:</b>
        <asp:DropDownList ID="ddRoleList" runat="server" AutoPostBack="true"
            DataTextField="StaffRoleName" DataValueField="StaffRoleId">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Panel ID="PanelRolesUserList" runat="server" Width="600px" BackColor="#F9F9F9">
        <br />
        <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False" 
            EmptyDataText="No Staff belong to this role."
            AllowSorting="True" Width="580px" CellPadding="3" 
            ForeColor="Black" GridLines="None" AllowPaging="False" 
            BackColor="#f0f0f0" 
            RowStyle-VerticalAlign="Middle" RowStyle-HorizontalAlign="Center"
            PageSize="20" Font-Size="12px" 
            PagerSettings-Mode="NextPreviousFirstLast"
            PagerSettings-FirstPageImageUrl="~/Images/a_Backward_01.png"  
            PagerSettings-PreviousPageImageUrl="~/Images/a_Backward.png" 
            PagerSettings-NextPageImageUrl="~/Images/a_Forward.png"
            PagerSettings-LastPageImageUrl="~/Images/a_Forward_01.png" 
            PagerSettings-FirstPageText="First Page" 
            PagerSettings-PreviousPageText="Previous Page"
            PagerSettings-NextPageText="Next Page" 
            PagerSettings-LastPageText="Last Page" EnableModelValidation="True">
            <PagerSettings FirstPageImageUrl="~/Images/a_Backward_01.png" 
                FirstPageText="First Page" LastPageImageUrl="~/Images/a_Forward_01.png" 
                LastPageText="Last Page" Mode="NextPreviousFirstLast" 
                NextPageImageUrl="~/Images/a_Forward.png" NextPageText="Next Page" 
                PreviousPageImageUrl="~/Images/a_Backward.png" 
                PreviousPageText="Previous Page" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" ForeColor="Red" Text="Remove"
                            ToolTip="Select This Staff to be Removed From the Above Selected Manage Staff By Role."
                            onclientclick="return confirm('Are you sure you want to remove this Staff from Role?');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Staff">
                    <ItemTemplate>
                        <asp:Label runat="server" id="lbUserName" Text='<%# Container.DataItem %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#f0f0f0" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Black" />
            <AlternatingRowStyle BackColor="#F9F9F9" />
        </asp:GridView>
        <br />
        </asp:Panel>
        <br/>
        <table style="margin-left: auto; margin-right: auto; width: 680px;">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <b>Select a Staff Name to Add to the Role:</b>
                    <asp:DropDownList ID="ddUserListAdd" runat="server" AutoPostBack="True" ValidationGroup="StaffRole"
                        DataTextField="MyName" DataValueField="UserId">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="UserNameReqField" runat="server" ControlToValidate="ddUserListAdd"
                        Display="Dynamic" ErrorMessage="You must Select a Staff Login Name!" ValidationGroup="StaffRole"
                        Text="*" Font-Size="X-Large">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Label ID="lbPositionRole" runat="server" Text="" Visible="false"></asp:Label>
                    <br />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Button ID="btnAddStaffRole" runat="server" Text="Add Staff to Position Role" Width="220px" ValidationGroup="StaffRole" Font-Size="Small" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table style="margin-left: auto; margin-right: auto; width: 660px;">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Label ID="ActionStatusIII" runat="server" Text="" CssClass="Important"></asp:Label>
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="StaffRole"
                        ShowMessageBox="True" ShowSummary="true" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </p>
    </div>
        <asp:LinqDataSource ID="LinqStaffUsersInRoles" runat="server" ContextTypeName="MyPortfolioDbDataContext"
            EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
            TableName="tblStaffUsersInRoles">
        </asp:LinqDataSource>
        <asp:HiddenField ID="hfUserId" runat="server" />
        <asp:HiddenField ID="hfUserName" runat="server" />
        <asp:HiddenField ID="hfBack" runat="server" />
        <asp:HiddenField ID="hfFrom" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
