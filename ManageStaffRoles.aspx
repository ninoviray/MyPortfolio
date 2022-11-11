<%@ Page Title="Manage UTC Staff Roles" Language="VB" MasterPageFile="~/Pages/TimeStudyMP.master" AutoEventWireup="false" CodeFile="ManageStaffRoles.aspx.vb" Inherits="Pages_ManageStaffRoles"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:Panel ID="PanelTimeStudyInfo" runat="server" Width="1024px" Height="80px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbTimeStudyInfo" runat="server" ForeColor="White" Font-Size="Large" Width="1000px" style="text-align: left;"></asp:Label>
            </asp:Panel>
            <br />
            <div align="center">
                <h2>Manage Staff Position Roles</h2>
                <p>
                    <b>Create a New Position Role: </b>
                    <asp:TextBox ID="txtRoleName" runat="server" Text="" Width="140px" ValidationGroup="Role"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RoleNameReqField" runat="server"
                        ControlToValidate="txtRoleName" Display="Dynamic" 
                        ErrorMessage="You must Enter a Staff Position Role Name." ValidationGroup="Role" Text="*" ForeColor="Red"
                        Font-Size="X-Large"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Button ID="btnCreateRole" runat="server" Text="Create Role" ValidationGroup="Role" Font-Size="Small" />
                    <table style="margin-left: auto; margin-right: auto; width: 600px;">
                        <tr>
                            <td class="style1">
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:Label ID="lbError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                <asp:ValidationSummary ID="ValSumRole" runat="server" ValidationGroup="Role" ForeColor="Red"
                                    ShowMessageBox="True" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </p>
                <p>
                    <asp:Panel ID="GridPanel1" runat="server" Width="980px" BackColor="#F9F9F9">
                        <br />
                        <asp:GridView ID="GridViewRoleList" runat="server"
                            AllowSorting="True" AutoGenerateColumns="False"
                            Width="900px" CellPadding="3" Font-Size="12px"
                            ForeColor="Black" GridLines="None" AllowPaging="False"
                            BackColor="White" ShowFooter="false"
                            PageSize="200" EmptyDataText="There are no data records to display."
                            RowStyle-VerticalAlign="Middle" RowStyle-HorizontalAlign="Center"
                            DataSourceID="LinqStaffRoles"
                            DataKeyNames="StaffRoleId"
                            OnRowDataBound="GridviewRoleList_RowDataBound"
                            OnRowDeleting="GridviewRoleList_RowDeleting"
                            OnRowDeleted="GridviewRoleList_RowDeleted">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False"
                                            CommandName="Delete" ForeColor="Red" Text="Delete Role"
                                            OnClientClick="return confirm('Are you sure you want to delete this Role?');"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Position Role">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbRoleName" Text='<%# Bind("StaffRoleName") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Black" />
                            <AlternatingRowStyle BackColor="#f0f0f0" />
                        </asp:GridView>
                        <br />
                    </asp:Panel>
                    <br />
                    <asp:LinqDataSource ID="LinqStaffRoles" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                        EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
                        TableName="tblStaffRoles" OrderBy="StaffRoleName">
                    </asp:LinqDataSource>
                    <asp:Label ID="lbmessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                </p>
                <p>
                    <hr style="width:980px" />
                    <br />
                    <b>Link Employee Roles with Time Study Approver Roles</b>
                    <br />
                    <asp:Panel ID="GridPanel2" runat="server" Width="980px" BackColor="#F9F9F9">
                        <br />
                        <asp:UpdatePanel ID="upGridViewApproverLink" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewApproverLink" runat="server"
                                    AllowSorting="True" AutoGenerateColumns="False"
                                    Width="900px" CellPadding="3" Font-Size="12px" ShowFooter="true"
                                    ForeColor="Black" GridLines="None" AllowPaging="False"
                                    BackColor="White" 
                                    PageSize="100" EmptyDataText="There are no data records to display."
                                    RowStyle-VerticalAlign="Middle" RowStyle-HorizontalAlign="Center"
                                    DataSourceID="LinqStaffApproverLink"
                                    DataKeyNames="StaffRoleIdEmployee"
                                    OnRowCommand="GridviewApproverLink_RowCommand"
                                    OnRowDeleting="GridviewApproverLink_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False"
                                                    CommandName="Delete" ForeColor="Red" Text="Delete Link"
                                                    OnClientClick="return confirm('Are you sure you want to delete this Role?');"></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" ValidationGroup="Add" Font-Size="Small" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approver Role">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbApproverRoleName" Text='<%# Bind("tblStaffRole.StaffRoleName") %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddApprover" runat="server" DataSourceID="LinqStaffApprover"
                                                    ValidationGroup="Add" AppendDataBoundItems="True" DataTextField="StaffRoleName"
                                                    DataValueField="StaffRoleId" ToolTip="Select the Staff Approver Role.">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorApprover" runat="server" 
                                                    ErrorMessage="Please Select a Staff Approver Role!" Text="*" Font-Size="X-Large"
                                                    ControlToValidate="ddApprover" CssClass="validator" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Role">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbEmployeeRoleName" Text='<%# Bind("tblStaffRole1.StaffRoleName") %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddEmployee" runat="server" DataSourceID="LinqStaffEmployee"
                                                    ValidationGroup="Add" AppendDataBoundItems="True" DataTextField="StaffRoleName"
                                                    DataValueField="StaffRoleId" ToolTip="Select the Staff Employee Role.">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmployee" runat="server" 
                                                    ErrorMessage="Please Select a Staff Employee Role!" Text="*" Font-Size="X-Large"
                                                    ControlToValidate="ddEmployee" CssClass="validator" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="LightGray" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Black" />
                                    <AlternatingRowStyle BackColor="#f0f0f0" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:Label ID="lbErrorII" runat="server" ForeColor="Red" Text=""></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                            HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="Add" />
                        <br />
                    </asp:Panel>
                    <br />
                    <asp:LinqDataSource ID="LinqStaffApproverLink" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                        EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
                        TableName="tblStaffApproverLinks" OrderBy="tblStaffRole.StaffRoleName, tblStaffRole1.StaffRoleName">
                    </asp:LinqDataSource>
                    <asp:LinqDataSource ID="LinqStaffMatch" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                        EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
                        TableName="tblStaffApproverLinks">
                    </asp:LinqDataSource>
                    <asp:LinqDataSource ID="LinqStaffApprover" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                        EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
                        TableName="tblStaffRoles" OrderBy="StaffRoleName">
                    </asp:LinqDataSource>
                    <asp:LinqDataSource ID="LinqStaffEmployee" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                        EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
                        TableName="tblStaffRoles" OrderBy="StaffRoleName">
                    </asp:LinqDataSource>
                </p>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCreateRole" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="GridViewRoleList" EventName="RowCommand" />
            <asp:AsyncPostBackTrigger ControlID="GridViewApproverLink" EventName="RowCommand" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
