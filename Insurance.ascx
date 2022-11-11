<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Insurance.ascx.vb" Inherits="Controls_Insurance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="../Content/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
<script type="text/javascript" lang="javascript">

    window.scrollTo = function (x, y) {
        return true;
    };

    function setHyphensPriIns() {
        var txtpip = document.getElementById('<%= txtPrimaryInsurancePhone.ClientID %>');
        var pip = "0";
        pip = txtpip.value;
        var keypip = event.key || event.keyCode;
        if (pip.length > 1 && (pip.length === 3 || pip.length === 7) && (keypip != "Backspace")) {
            txtpip.value += '-';
        }
    }

    function setHyphensSecIns() {
        var txtsip = document.getElementById('<%= txtSecondaryInsurancePhone.ClientID %>');
        var sip = "0";
        sip = txtsip.value;
        var keysip = event.key || event.keyCode;
        if (sip.length > 1 && (sip.length === 3 || sip.length === 7) && (keysip != "Backspace")) {
            txtsip.value += '-';
        }
    }

</script>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanelInsurance" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="PanelInsurance" runat="server">
            <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
                <tr>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbPrimaryInsuranceText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtPrimaryInsurance" runat="server" Text="" MaxLength="200" Width="200px" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrimaryInsurance" runat="server" ErrorMessage=""
                            ControlToValidate="txtPrimaryInsurance" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Insurance"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPrimaryInsurance" runat="server" ControlToValidate="txtPrimaryInsurance"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="Insurance"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,200}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbPrimaryInsuranceIdText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtPrimaryInsuranceId" runat="server" Text="" MaxLength="100" Width="200px" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrimaryInsuranceId" runat="server" ErrorMessage=""
                            ControlToValidate="txtPrimaryInsuranceId" Font-Size="X-Large" Text="*" ForeColor="Red" Enabled="false"
                            ValidationGroup="Insurance"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPrimaryInsuranceId" runat="server" ControlToValidate="txtPrimaryInsuranceId"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="Insurance"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbPrimaryInsuranceGroupText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtPrimaryInsuranceGroup" runat="server" Text="" MaxLength="100" Width="200px" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrimaryInsuranceGroup" runat="server" ErrorMessage=""
                            ControlToValidate="txtPrimaryInsurance" Font-Size="X-Large" Text="*" ForeColor="Red" Enabled="false"
                            ValidationGroup="Insurance"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPrimaryInsuranceGroup" runat="server" ControlToValidate="txtPrimaryInsuranceGroup"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="Insurance"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbPrimaryInsurancePhoneText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtPrimaryInsurancePhone" runat="server" Text="" Width="100px" MaxLength="12" onkeydown="setHyphensPriIns();" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revPrimaryInsurancePhone" runat="server" ValidationGroup="Insurance"
                            ErrorMessage="" ControlToValidate="txtPrimaryInsurancePhone" Font-Size="X-Large"
                            ValidationExpression="(###-###-####)|((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server" TargetControlID="txtPrimaryInsurancePhone"
                            WatermarkCssClass="watermark" WatermarkText="###-###-####"></ajax:TextBoxWatermarkExtender>
                        <br />
                        <asp:Label ID="lbEmploymentText" runat="server" Text="" Width="220px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtEmployment" runat="server" Text="" MaxLength="200" Width="200px" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmployment" runat="server" ErrorMessage=""
                            ControlToValidate="txtEmployment" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Insurance"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmployment" runat="server" ControlToValidate="txtEmployment"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="Insurance"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,200}$"></asp:RegularExpressionValidator>
                    </td>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbSecondaryInsuranceText" runat="server" Text="" Width="230px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtSecondaryInsurance" runat="server" Text="" MaxLength="200" Width="200px" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revSecondaryInsurance" runat="server" ControlToValidate="txtSecondaryInsurance"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="Insurance"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,200}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbSecondaryInsuranceIdText" runat="server" Text="" Width="230px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtSecondaryInsuranceId" runat="server" Text="" MaxLength="100" Width="200px" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revSecondaryInsuranceId" runat="server" ControlToValidate="txtSecondaryInsuranceId"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="Insurance"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbSecondaryInsuranceGroupText" runat="server" Text="" Width="230px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtSecondaryInsuranceGroup" runat="server" Text="" MaxLength="100" Width="200px" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revSecondaryInsuranceGroup" runat="server" ControlToValidate="txtSecondaryInsuranceGroup"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="Insurance"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbSecondaryInsurancePhoneText" runat="server" Text="" Width="230px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtSecondaryInsurancePhone" runat="server" Text="" Width="100px" MaxLength="12" onkeydown="setHyphensSecIns();" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revSecondaryInsurancePhone" runat="server" ValidationGroup="Insurance"
                            ErrorMessage="" ControlToValidate="txtSecondaryInsurancePhone" Font-Size="X-Large"
                            ValidationExpression="(###-###-####)|((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" TargetControlID="txtSecondaryInsurancePhone"
                            WatermarkCssClass="watermark" WatermarkText="###-###-####"></ajax:TextBoxWatermarkExtender>
                        <br />
                        <asp:Label ID="lbInsuranceCommentsText" runat="server" Text="" Width="230px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtInsuranceComments" runat="server" Text="" MaxLength="200" Width="200px" ValidationGroup="Insurance"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revInsuranceComments" runat="server" ControlToValidate="txtInsuranceComments"
                            ErrorMessage="Insurance Comments has Invalid Character!" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="Insurance"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,200}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hfTabPanelInsurance" runat="server" Value="False" />
            <asp:HiddenField ID="hfPID" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfLanguage" runat="server" />
            <asp:HiddenField ID="hfLanguageText" runat="server" />
            <asp:HiddenField ID="hfPleaseEnter" runat="server" />
            <asp:HiddenField ID="hfIsInvalid" runat="server" />
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtPrimaryInsurancePhone" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtSecondaryInsurancePhone" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>

