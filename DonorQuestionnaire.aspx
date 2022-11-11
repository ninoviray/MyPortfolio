<%@ Page Title="Living Donor Questionnaire" Language="VB" MasterPageFile="~/Pages/DonorMP.master" AutoEventWireup="false" CodeFile="DonorQuestionnaire.aspx.vb" Inherits="Pages_DonorQuestionnaire" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/Controls/TransplantInstitute.ascx" TagName="UHTITI" TagPrefix="uhtiti" %>
<%@ Register Src="~/Controls/LivingDonor.ascx" TagName="UHTILD" TagPrefix="uhtild" %>
<%@ Register Src="~/Controls/Demographics.ascx" TagName="UHTIDE" TagPrefix="uhtide" %>
<%@ Register Src="~/Controls/Insurance.ascx" TagName="UHTIIN" TagPrefix="uhtiin" %>
<%@ Register Src="~/Controls/HeightWeightBMI.ascx" TagName="UHTIHWBMI" TagPrefix="uhtihwbmi" %>
<%@ Register Src="~/Controls/BloodHistory.ascx" TagName="UHTIBH" TagPrefix="uhtibh" %>
<%@ Register Src="~/Controls/MedicalHistory.ascx" TagName="UHTIMH" TagPrefix="uhtimh" %>
<%@ Register Src="~/Controls/SocialHistory.ascx" TagName="UHTISH" TagPrefix="uhtish" %>
<%@ Register Src="~/Controls/QuestionnaireCompletion.ascx" TagName="UHTIQC" TagPrefix="uhtiqc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanelLivingDonorQuestionnaire" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:Panel ID="PanelInfo" runat="server" Width="1024px" Height="90px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbInfo" runat="server" ForeColor="White" Font-Size="Large" Width="1000px" style="text-align: left;"></asp:Label>
            </asp:Panel>
            <br />
            <asp:Panel ID="PanelContainerTransplantInstitute" runat="server" Width="982px">
                <ajax:TabContainer ID="TabContainerTransplantInstitute" runat="server" Width="980px" CssClass="body"
                    Style="margin-left: auto; margin-right: auto;" ActiveTabIndex="0">
                    <ajax:TabPanel ID="TabPanelTransplantInstitute" runat="server" HeaderText="" Enabled="true" CssClass="body">
                        <ContentTemplate>
                            <asp:Label ID="lbTabPanelTransplantInstituteText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Style="text-align: left"></asp:Label>
                            <hr />
                            <uhtiti:UHTITI ID="MyTransplantInstitute" runat="server" UpdateMode="Conditional" />
                            <asp:HiddenField ID="hfTabPanelTransplantInstitute" runat="server" Value="False" />
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanelLivingDonor" runat="server" HeaderText="" Enabled="false" CssClass="body">
                        <ContentTemplate>
                            <asp:Label ID="lbTabPanelLivingDonorText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Style="text-align: left"></asp:Label>
                            <hr />
                            <uhtild:UHTILD ID="MyLivingDonor" runat="server" UpdateMode="Conditional" />
                            <asp:HiddenField ID="hfTabPanelLivingDonor" runat="server" Value="False" />
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanelDemographics" runat="server" HeaderText="" Enabled="false" CssClass="body">
                        <ContentTemplate>
                            <asp:Label ID="lbTabPanelDemographicsText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Style="text-align: left"></asp:Label>
                            <hr />
                            <uhtide:UHTIDE ID="MyDemographics" runat="server" UpdateMode="Conditional" />
                            <asp:HiddenField ID="hfTabPanelDemographics" runat="server" Value="False" />
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanelInsurance" runat="server" HeaderText="" Enabled="false" CssClass="body">
                        <ContentTemplate>
                            <asp:Label ID="lbTabPanelInsuranceText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Style="text-align: left"></asp:Label>
                            <hr />
                            <uhtiin:UHTIIN ID="MyInsurance" runat="server" UpdateMode="Conditional" />
                            <asp:HiddenField ID="hfTabPanelInsurance" runat="server" Value="False" />
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanelHeightWeightBMI" runat="server" HeaderText="" Enabled="false" CssClass="body">
                        <ContentTemplate>
                            <asp:Label ID="lbTabPanelHeightWeightBMIText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Style="text-align: left"></asp:Label>
                            <hr />
                            <uhtihwbmi:UHTIHWBMI ID="MyHeightWeightBMI" runat="server" UpdateMode="Conditional" />
                            <asp:HiddenField ID="hfTabPanelHeightWeightBMI" runat="server" Value="False" />
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanelBloodHistory" runat="server" HeaderText="" Enabled="false" CssClass="body">
                        <ContentTemplate>
                            <asp:Label ID="lbTabPanelBloodHistoryText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Style="text-align: left"></asp:Label>
                            <hr />
                            <uhtibh:UHTIBH ID="MyBloodHistory" runat="server" UpdateMode="Conditional" />
                            <asp:HiddenField ID="hfTabPanelBloodHistory" runat="server" Value="False" />
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanelMedicalHistory" runat="server" HeaderText="" Enabled="false" CssClass="body">
                        <ContentTemplate>
                            <asp:Label ID="lbTabPanelMedicalHistoryText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Style="text-align: left"></asp:Label>
                            <hr />
                            <uhtimh:UHTIMH ID="MyMedicalHistory" runat="server" UpdateMode="Conditional" />
                            <asp:HiddenField ID="hfTabPanelMedicalHistory" runat="server" Value="False" />
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanelSocialHistory" runat="server" HeaderText="" Enabled="false" CssClass="body">
                        <ContentTemplate>
                            <asp:Label ID="lbTabPanelSocialHistoryText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Style="text-align: left"></asp:Label>
                            <hr />
                            <uhtish:UHTISH ID="MySocialHistory" runat="server" UpdateMode="Conditional" />
                            <asp:HiddenField ID="hfTabPanelSocialHistory" runat="server" Value="False" />
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanelQuestionnaireCompletion" runat="server" HeaderText="" Enabled="false" CssClass="body">
                        <ContentTemplate>
                            <asp:Label ID="lbTabPanelQuestionnaireCompletionText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Style="text-align: left"></asp:Label>
                            <hr />
                            <uhtiqc:UHTIQC ID="MyQuestionnaireCompletion" runat="server" UpdateMode="Conditional" />
                            <asp:HiddenField ID="hfTabPanelQuestionnaireCompletion" runat="server" Value="False" />
                        </ContentTemplate>
                    </ajax:TabPanel>
                </ajax:TabContainer>
                <br />
                <asp:Table ID="TableValidationSummary" runat="server" Width="980px" CssClass="body">
                    <asp:TableRow>
                        <asp:TableCell Width="28%">
                            &nbsp;
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Justify">
                            <asp:Label ID="lbLivingDonorQuestionnaireError" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:ValidationSummary ID="ValSumLivingDonorQuestionnaire" runat="server" ShowMessageBox="True" ForeColor="Red"
                                HeaderText="" ValidationGroup="" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Table ID="TablePreviousNextCancel" runat="server" Width="980px" CssClass="body">
                    <asp:TableRow Height="30px">
                        <asp:TableCell HorizontalAlign="Right" Width="470px">
                            <asp:Button ID="btnPrevious" Text="" runat="server" Width="100px" CssClass="PreviousNextCancelButtonCSS" Font-Size="Smaller"
                                CausesValidation="False" UseSubmitBehavior="False" ToolTip="" />
                            &nbsp;
                            <asp:Button ID="btnCancel" Text="" runat="server" Width="100px" CssClass="PreviousNextCancelButtonCSS" Font-Size="Smaller"
                                CausesValidation="false" UseSubmitBehavior="false" ToolTip="" />
                            <ajax:ConfirmButtonExtender ID="cbeCancel" runat="server" TargetControlID="btnCancel"
                                ConfirmText=""></ajax:ConfirmButtonExtender>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center" Width="40px">
                            <asp:UpdateProgress ID="UpdatePreviousNextCancel" runat="server" AssociatedUpdatePanelID="UpdatePanelLivingDonorQuestionnaire" DisplayAfter="0">
                                <ProgressTemplate>
                                    <img src="../Images/Update.gif" alt="progress" style="width: 25px; height: 25px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left" Width="470px">
                            <asp:Button ID="btnNext" Text="" runat="server" Width="100px" CssClass="PreviousNextCancelButtonCSS" Font-Size="Smaller"
                                CausesValidation="True" UseSubmitBehavior="True" ValidationGroup="" ToolTip="" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                            <br />
                            <asp:LinkButton ID="linkSpa" runat="server" Text="View in Spanish" PostBackUrl="~/Pages/DonorQuestionnaire.aspx?D=0ebfabd6-bfa6-4710-910f-fedb5f1beacb&L=Spa"></asp:LinkButton>
                            &emsp;
                            <asp:LinkButton ID="linkEng" runat="server" Text="View in English" PostBackUrl="~/Pages/DonorQuestionnaire.aspx?D=0ebfabd6-bfa6-4710-910f-fedb5f1beacb&L=Eng"></asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:HiddenField ID="hfKidneyDonor" runat="server" Value="False" />
                <asp:HiddenField ID="hfLiverDonor" runat="server" Value="False" />
                <asp:HiddenField ID="hfUserId" runat="server" />
                <asp:HiddenField ID="hfPID" runat="server" />
                <asp:HiddenField ID="hfLanguage" runat="server" />
                <asp:HiddenField ID="hfLanguageText" runat="server" />
                <asp:HiddenField ID="hfPleaseEnter" runat="server" />
                <asp:HiddenField ID="hfIsInvalid" runat="server" />
                <asp:HiddenField ID="hfValidationSummary" runat="server" />
                <asp:HiddenField ID="hfCancel" runat="server" />
                <asp:HiddenField ID="hfCancelToolTip" runat="server" />
                <asp:HiddenField ID="hfCancelConfirm" runat="server" />
                <asp:HiddenField ID="hfPrevious" runat="server" />
                <asp:HiddenField ID="hfPreviousToolTip" runat="server" />
                <asp:HiddenField ID="hfNext" runat="server" />
                <asp:HiddenField ID="hfNextToolTip" runat="server" />
                <asp:HiddenField ID="hfSSN" runat="server" />
                <asp:HiddenField ID="hfHardRejectionLiverText" runat="server" />
                <asp:HiddenField ID="hfHardRejectionLiver" runat="server" Value="False" />
                <asp:HiddenField ID="hfHardRejectionKidneyText" runat="server" />
                <asp:HiddenField ID="hfHardRejectionKidney" runat="server" Value="False" />
                <asp:HiddenField ID="hfSoftRejectionLiverText" runat="server" />
                <asp:HiddenField ID="hfSoftRejectionLiver" runat="server" Value="False" />
                <asp:HiddenField ID="hfSoftRejectionKidneyText" runat="server" />
                <asp:HiddenField ID="hfSoftRejectionKidney" runat="server" Value="False" />
                <asp:HiddenField ID="hfBMI" runat="server" />
                <asp:HiddenField ID="hfFrom" runat="server" />
                <asp:HiddenField ID="hfTab" runat="server" Value="0" />
            </asp:Panel>
            <ajax:DropShadowExtender ID="dseBody" runat="server" TargetControlID="PanelContainerTransplantInstitute" Opacity=".5" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNext" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnPrevious" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

