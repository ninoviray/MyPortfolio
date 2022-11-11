<%@ Page Title="Time Study Page" Language="VB" MasterPageFile="~/Pages/TimeStudyMP.master" AutoEventWireup="false" CodeFile="TimeStudyPage.aspx.vb" Inherits="Pages_TimeStudyPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanelReportTimeStudyPage" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
        <ContentTemplate>
            <asp:Panel ID="PanelTimeStudyInfo" runat="server" Width="1024px" Height="70px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbTimeStudyInfo" runat="server" ForeColor="White" Font-Size="Large" style="text-align:left" Width="1000px"></asp:Label>
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
            <asp:UpdatePanel ID="updatepanelApproval" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                     <asp:Panel ID="panelApproval" runat="server">
                <table width="600px">
                <tr>
                    <th style="width: 55px; height: 40px">
                        <div align="center">
                            <asp:UpdateProgress ID="UpdateProgressCancer" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="updatepanelApproval">
                                <ProgressTemplate>
                                    <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </th>
                    <th>
                        <asp:Button ID="btnApproval" runat="server" Text="Submit to Supervisor for Approval" Font-Size="Small"
                            ToolTip="Submit to Supervisor for Time study Approval." />
                    </th>
                    <th>
                        <asp:Button ID="btnCancel" runat="server" Text="Return to Time Study" Font-Size="Small"
                            ToolTip="Return to Time Study." />
                    </th>
                    <th style="width: 55px; height: 40px">
                        &nbsp;
                    </th>
                </tr>
            </table>
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
            </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:HiddenField ID="hfPID" runat="server" />
            <asp:HiddenField ID="hfBack" runat="server" />
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
