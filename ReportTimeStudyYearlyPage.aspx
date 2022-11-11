<%@ Page Title="Report Time Study Yearly Page" Language="VB" MasterPageFile="~/Pages/TimeStudyMP.master" AutoEventWireup="false" CodeFile="ReportTimeStudyYearlyPage.aspx.vb" Inherits="Pages_ReportTimeStudyYearlyPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanelReportTimeStudyYearlyPage" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
        <ContentTemplate>
            <asp:Panel ID="PanelTimeStudyInfo" runat="server" Width="1024px" Height="90px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbTimeStudyInfo" runat="server" ForeColor="White" Font-Size="Large" Width="800px" style="text-align: left;"></asp:Label>
            </asp:Panel>
            <br />
            <table style="margin-left: auto; margin-right: auto;">
                <tr>
                    <th align="center">
                        <div align="left">
                            <CR:CrystalReportViewer ID="CrystalReportViewerTS" runat="server" AutoDataBind="True"
                                ToolPanelView="None" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False"
                                GroupTreeStyle-ShowLines="False" HasDrillUpButton="False" HasDrilldownTabs="False"
                                EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" HasPageNavigationButtons="True" />
                        </div>
                        <br />
                    </th>
                </tr>
            </table>
            <asp:Button ID="btnCancel" runat="server" Text="Return to Approvals" UseSubmitBehavior="False" Font-Size="X-Small"
                CausesValidation="False" Width="150px" />
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
            <asp:HiddenField ID="hfPID" runat="server" />
            <asp:HiddenField ID="hfBack" runat="server" />
            <asp:HiddenField ID="hfFrom" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfDate" runat="server" />
            <asp:HiddenField ID="hfDateText" runat="server" />
            <asp:HiddenField ID="hfUserName" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="CrystalReportViewerTS" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
