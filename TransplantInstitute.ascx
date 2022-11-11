<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TransplantInstitute.ascx.vb" Inherits="Controls_TransplantInstitute" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="../Content/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
<script type="text/javascript" lang="javascript">

    window.scrollTo = function (x, y) {
        return true;
    };

    function setOrganValidation(sender, args) {

        if (document.getElementById('<%= cbKidneyDonor.ClientID %>').checked == false && document.getElementById('<%= cbLiverDonor.ClientID %>').checked == false) {
            args.IsValid = false;
        } else {
            args.IsValid = true;
        }
    }

    function setRecipientDOB() {
        var txtrdob = document.getElementById('<%= txtRecipientDateOfBirth.ClientID %>');
        var rdob = "0";
        rdob = txtrdob.value;
        var keyrdob = event.key || event.keyCode;
        if (rdob.length > 1 && (rdob.length === 2 || rdob.length === 5) && (keyrdob != "Backspace")) {
            txtrdob.value += '/';
        }
    }

</script>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanelTransplantInstitute" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="PanelTransplantInstitute" runat="server">
            <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
                <tr style="text-align: left">
                    <td style="width: 8%; vertical-align: text-top;">
                        &nbsp;
                    </td>
                    <td style="width: 84%; vertical-align: text-top;">
                        <asp:Label ID="lbInterestedInDonatingText" runat="server" Text="" Font-Bold="True"></asp:Label>
                        <asp:CustomValidator ID="cvInterestedInDonating" runat="server"
                            Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="TransplantInstitute" OnServerValidate="OrganDonating_Validate"
                            ClientValidationFunction="setOrganValidation"></asp:CustomValidator>
                        <br />
                        <asp:CheckBox ID="cbKidneyDonor" runat="server" Text="" />
                        <br />
                        <asp:CheckBox ID="cbLiverDonor" runat="server" Text="" />
                        <hr />
                        <asp:Label ID="lbDonationTypeText" runat="server" Text="" Font-Bold="True"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvDonationType" runat="server"
                            ControlToValidate="rblDonationType" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="TransplantInstitute"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RadioButtonList ID="rblDonationType" runat="server" ValidationGroup="TransplantInstitute" RepeatLayout="Flow"
                            OnSelectedIndexChanged="rblDonationType_SelectedIndexChanged" AutoPostBack="True">
                        </asp:RadioButtonList>
                    </td>
                    <td style="width: 8%; vertical-align: text-top;">
                        &nbsp;
                    </td>
                </tr>
                <tr style="text-align: left">
                    <td style="width: 8%; vertical-align: text-top;">
                        &nbsp;
                    </td>
                    <td style="width: 84%; vertical-align: text-top;">
                        <asp:UpdatePanel ID="UpdatePanelRecipient" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="rblDonationType" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Panel ID="PanelRecipient" runat="server" Visible="false">
                                    <hr />
                                    <table style="width: 100%; margin-left: auto; margin-right: auto;" border="0">
                                        <tr>
                                            <td style="width: 40%; vertical-align: text-top;">
                                                <asp:Label ID="lbRecipientCurrentlyPatientText" runat="server" Text="" Font-Bold="True"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvRecipientCurrentlyPatient" runat="server" ErrorMessage=""
                                                    ControlToValidate="rblRecipientCurrentlyPatient" Font-Size="X-Large" Text="*" ForeColor="Red"
                                                    ValidationGroup="TransplantInstitute"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RadioButtonList ID="rblRecipientCurrentlyPatient" runat="server" ValidationGroup="TransplantInstitute" RepeatLayout="Flow"
                                                    OnSelectedIndexChanged="rblRecipientCurrentlyPatient_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="width: 60%; vertical-align: text-top;">
                                                <asp:UpdatePanel ID="UpdatePanelRecipientCurrentlyPatient" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="rblRecipientCurrentlyPatient" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:Panel ID="PanelRecipientCurrentlyPatient" runat="server" Visible="false">
                                                            <asp:Label ID="lbRecipientFirstNameText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                                                            <asp:TextBox ID="txtRecipientFirstName" runat="server" Text="" Width="150px" MaxLength="25" ValidationGroup="TransplantInstitute"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvRecipientFirstName" runat="server" ErrorMessage=""
                                                                ControlToValidate="txtRecipientFirstName" Font-Size="X-Large" Text="*" ForeColor="Red"
                                                                ValidationGroup="TransplantInstitute"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revRecipientFirstName" runat="server" ErrorMessage=""
                                                                ControlToValidate="txtRecipientFirstName" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="TransplantInstitute"
                                                                ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,25}$"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <asp:Label ID="lbRecipientMiddleNameText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                                                            <asp:TextBox ID="txtRecipientMiddleName" runat="server" Text="" Width="40px" MaxLength="2" ValidationGroup="TransplantInstitute"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvRecipientMiddleName" runat="server" ErrorMessage=""
                                                                ControlToValidate="txtRecipientMiddleName" Font-Size="X-Large" Enabled="False" Text="*" ForeColor="Red"
                                                                ValidationGroup="TransplantInstitute"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revRecipientMiddleName" runat="server" ErrorMessage=""
                                                                ControlToValidate="txtRecipientMiddleName" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="TransplantInstitute"
                                                                ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,2}$"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <asp:Label ID="lbRecipientLastNameText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                                                            <asp:TextBox ID="txtRecipientLastName" runat="server" Text="" Width="150px" MaxLength="25" ValidationGroup="TransplantInstitute"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvRecipientLastName" runat="server" ErrorMessage=""
                                                                ControlToValidate="txtRecipientLastName" Font-Size="X-Large" Text="*" ForeColor="Red"
                                                                ValidationGroup="TransplantInstitute"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revRecipientLastName" runat="server" ErrorMessage=""
                                                                ControlToValidate="txtRecipientLastName" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="TransplantInstitute"
                                                                ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,25}$"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <asp:Label ID="lbRecipientDateOfBirthText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                                                            <asp:TextBox ID="txtRecipientDateOfBirth" runat="server" Text="" MaxLength="10" Width="100px" ValidationGroup="TransplantInstitute" onkeydown="setRecipientDOB();"></asp:TextBox>
                                                            <asp:RangeValidator ID="rvRecipientDateOfBirth" runat="server" ControlToValidate="txtRecipientDateOfBirth" ValidationGroup="TransplantInstitute"
                                                                ErrorMessage="" Font-Size="X-Large" Type="Date" SetFocusOnError="True" Text="*" ForeColor="Red"></asp:RangeValidator>
                                                            <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtRecipientDateOfBirth"
                                                                WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                                                            <br />
                                                            <asp:Label ID="lbRecipientRelationshipText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                                                            <asp:DropDownList ID="ddRecipientRelationship" runat="server" ValidationGroup="TransplantInstitute" AppendDataBoundItems="True" Width="120px">
                                                                <asp:ListItem Value=""></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvRecipientRelationship" runat="server" ControlToValidate="ddRecipientRelationship"
                                                                ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                                                                ValidationGroup="TransplantInstitute"></asp:RequiredFieldValidator>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                    <hr />
                                    <asp:Label ID="lbRecipientChildAdultText" runat="server" Text="" Font-Bold="True"></asp:Label>
                                    <asp:RequiredFieldValidator ID="rfvRecipientChildAdult" runat="server" ErrorMessage=""
                                        ControlToValidate="rblRecipientChildAdult" Font-Size="X-Large" Text="*" ForeColor="Red"
                                        ValidationGroup="TransplantInstitute"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RadioButtonList ID="rblRecipientChildAdult" runat="server" ValidationGroup="TransplantInstitute" RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 8%; vertical-align: text-top;">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:LinqDataSource ID="LinqDonationType" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDonationTypeReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqRecipientCurrentlyPatient" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpRecipientCurrentlyPatientReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqRecipientRelationship" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpRelationshipReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqRecipientChildAdult" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpRecipientChildAdultReferrals">
            </asp:LinqDataSource>
            <asp:HiddenField ID="hfTabPanelTransplantInstitute" runat="server" Value="False" />
            <asp:HiddenField ID="hfPID" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfLanguage" runat="server" />
            <asp:HiddenField ID="hfLanguageText" runat="server" />
            <asp:HiddenField ID="hfPleaseEnter" runat="server" />
            <asp:HiddenField ID="hfIsInvalid" runat="server" />
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rblRecipientChildAdult" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>

