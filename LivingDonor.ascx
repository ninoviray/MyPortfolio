<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LivingDonor.ascx.vb" Inherits="Controls_LivingDonor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="../Content/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
<script type="text/javascript" lang="javascript">

    window.scrollTo = function (x, y) {
        return true;
    };

    function setHyphensHM() {
        var txthp = document.getElementById('<%= txtHomePhone.ClientID %>');
        var hp = "0";
        hp = txthp.value;
        var keyhp = event.key || event.keyCode;
        if (hp.length > 1 && (hp.length === 3 || hp.length === 7) && (keyhp != "Backspace")) {
            txthp.value += '-';
        }
    }

    function setHyphensCE() {
        var txtcp = document.getElementById('<%= txtCellPhone.ClientID %>');
        var cp = "0";
        cp = txtcp.value;
        var keycp = event.key || event.keyCode;
        if (cp.length > 1 && (cp.length === 3 || cp.length === 7) && (keycp != "Backspace")) {
            txtcp.value += '-';
        }
    }

    function setHyphensWK() {
        var txtwp = document.getElementById('<%= txtWorkPhone.ClientID %>');
        var wp = "0";
        wp = txtwp.value;
        var keywp = event.key || event.keyCode;
        if (wp.length > 1 && (wp.length === 3 || wp.length === 7) && (keywp != "Backspace")) {
            txtwp.value += '-';
        }
    }

    function setHyphensAlt() {
        var txtap = document.getElementById('<%= txtAlternativePhone.ClientID %>');
        var ap = "0";
        ap = txtap.value;
        var keyap = event.key || event.keyCode;
        if (ap.length > 1 && (ap.length === 3 || ap.length === 7) && (keyap != "Backspace")) {
            txtap.value += '-';
        }
    }

    function PhoneValidation() {
        var pptc = document.getElementById('<%= ddPrimaryPhoneToCall.ClientID %>');
        if (pptc.value == 1) {
            ValidatorEnable(document.getElementById('<%= rfvHomePhone.ClientID %>'), true);
        } else {
            ValidatorEnable(document.getElementById('<%= rfvHomePhone.ClientID %>'), false);
        }
        if (pptc.value == 2) {
            ValidatorEnable(document.getElementById('<%= rfvCellPhone.ClientID %>'), true);
        } else {
            ValidatorEnable(document.getElementById('<%= rfvCellPhone.ClientID %>'), false);
        }
        if (pptc.value == 3) {
            ValidatorEnable(document.getElementById('<%= rfvWorkPhone.ClientID %>'), true);
        } else {
            ValidatorEnable(document.getElementById('<%= rfvWorkPhone.ClientID %>'), false);
        }
        if (pptc.value == 4) {
            ValidatorEnable(document.getElementById('<%= rfvAlternativePhone.ClientID %>'), true);
        } else {
            ValidatorEnable(document.getElementById('<%= rfvAlternativePhone.ClientID %>'), false);
        }
    }

    function setHyphensSSNAdd() {
        var txtssn = document.getElementById('<%= txtSocialSecurityNumber.ClientID %>');
        var ssn = "0";
        ssn = txtssn.value;
        var keyssn = event.key || event.keyCode;
        if (ssn.length > 1 && (ssn.length === 3 || ssn.length === 6) && (keyssn != "Backspace")) {
            txtssn.value += '-';
        }
    }

</script>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanelLivingDonor" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="PanelLivingDonor" runat="server">
            <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
                <tr>
                    <td style="width: 45%; vertical-align: text-top;">
                        <asp:Label ID="lbFirstNameText" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtFirstName" runat="server" Text="" Width="150px" MaxLength="25" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage=""
                            ControlToValidate="txtFirstName" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage=""
                            ControlToValidate="txtFirstName" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,25}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbMiddleNameText" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtMiddleName" runat="server" Text="" Width="40px" MaxLength="2" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMiddleName" runat="server" ErrorMessage=""
                            ControlToValidate="txtMiddleName" Font-Size="X-Large" Enabled="False" Text="*" ForeColor="Red"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revMiddleName" runat="server" ErrorMessage=""
                            ControlToValidate="txtMiddleName" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,2}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbLastNameText" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtLastName" runat="server" Text="" Width="150px" MaxLength="25" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage=""
                            ControlToValidate="txtLastName" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revLastName" runat="server" ErrorMessage=""
                            ControlToValidate="txtLastName" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,25}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbAddress1Text" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtAddress1" runat="server" Text="" Width="230px" MaxLength="100" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ErrorMessage=""
                            Text="*" ForeColor="Red" ControlToValidate="txtAddress1" Font-Size="X-Large"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revAddress1" runat="server" ErrorMessage=""
                            ControlToValidate="txtAddress1" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbAddress2Text" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtAddress2" runat="server" Text="" Width="230px" MaxLength="100" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress2" runat="server" ErrorMessage=""
                            Text="*" ForeColor="Red" ControlToValidate="txtAddress2" Font-Size="X-Large" Enabled="False"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revAddress2" runat="server" ErrorMessage=""
                            ControlToValidate="txtAddress2" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbCityText" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" Text="" Width="180px" MaxLength="100" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCity" runat="server" ErrorMessage=""
                            ControlToValidate="txtCity" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \& | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,50}$"></asp:RegularExpressionValidator>
                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" BehaviorID="AutoCityEx"
                            TargetControlID="txtCity" ServicePath="~/Services/AutoCity.asmx" ServiceMethod="GetCompletionCity"
                            MinimumPrefixLength="1" CompletionInterval="50" CompletionSetCount="20"
                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" DelimiterCharacters=";, :"
                            ShowOnlyCurrentWordInCompletionListItem="True">
                            <Animations>
                                    <OnShow>
                                        <Sequence>
                                            <OpacityAction Opacity="0" />
                                            <HideAction Visible="true" />
                                            <ScriptAction Script="
                                                var behavior = $find('AutoCityEx');
                                                if (!behavior._height) {
                                                    var target = behavior.get_completionList();
                                                    behavior._height = target.offsetHeight - 2;
                                                    target.style.height = '0px';
                                                }" />
                                            <Parallel Duration=".4">
                                                <FadeIn />
                                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCityEx')._height" />
                                            </Parallel>
                                        </Sequence>
                                    </OnShow>
                                    <OnHide>
                                        <Parallel Duration=".4">
                                            <FadeOut />
                                            <Length PropertyKey="height" StartValueScript="$find('AutoCityEx')._height" EndValue="0" />
                                        </Parallel>
                                    </OnHide></Animations>
                        </ajax:AutoCompleteExtender>
                        <br />
                        <asp:Label ID="lbStateText" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddState" runat="server" ValidationGroup="LivingDonor" AppendDataBoundItems="True" Width="230px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddState"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbZipCodeText" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtZipCode" runat="server" Text="" MaxLength="10" Width="80px" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="txtZipCode"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revZipCode" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtZipCode" ErrorMessage="" ValidationExpression="\d{5}(-\d{4})?"
                            Font-Size="X-Large" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtZipCode"
                            WatermarkCssClass="watermark" WatermarkText="#####"></ajax:TextBoxWatermarkExtender>
                        <br />
                        <asp:Label ID="lbCountryText" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtCountry" runat="server" Text="USA" MaxLength="30" Width="140px" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="txtCountry"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCountry" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtCountry" ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" 
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,30}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbCountryOfOriginText" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtCountryOfOrigin" runat="server" Text="" MaxLength="30" Width="140px" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revCountryOfOrigin" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtCountryOfOrigin" ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" 
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,30}$"></asp:RegularExpressionValidator>
                    </td>
                    <td style="width: 55%; vertical-align: text-top;">
                        <asp:Label ID="lbHomePhoneText" runat="server" Text="" Width="200px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtHomePhone" runat="server" Text="" Width="100px" MaxLength="12" onkeydown="setHyphensHM();"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvHomePhone" runat="server" ControlToValidate="txtHomePhone" Enabled="false"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revHomePhone" runat="server" ValidationGroup="LivingDonor"
                            ErrorMessage="" ControlToValidate="txtHomePhone" Font-Size="X-Large"
                            ValidationExpression="(###-###-####)|((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtHomePhone"
                            WatermarkCssClass="watermark" WatermarkText="###-###-####"></ajax:TextBoxWatermarkExtender>
                        <asp:TextBox ID="txtHomePhoneNotes" runat="server" Text="" Width="120px" MaxLength="100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revHomePhoneNotes" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtHomePhoneNotes" ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" 
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="tbweHomePhoneNotes" runat="server" TargetControlID="txtHomePhoneNotes"
                            WatermarkCssClass="watermark" WatermarkText=" "></ajax:TextBoxWatermarkExtender>
                        <br />
                        <asp:Label ID="lbCellPhoneText" runat="server" Text="" Width="200px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtCellPhone" runat="server" Text="" Width="100px" MaxLength="12" onkeydown="setHyphensCE();" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCellPhone" runat="server" ControlToValidate="txtCellPhone" Enabled="false"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCellPhone" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtCellPhone" ErrorMessage="" Font-Size="X-Large"
                            ValidationExpression="(###-###-####)|((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtCellPhone"
                            WatermarkCssClass="watermark" WatermarkText="###-###-####"></ajax:TextBoxWatermarkExtender>
                        <asp:TextBox ID="txtCellPhoneNotes" runat="server" Text="" Width="120px" MaxLength="100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revCellPhoneNotes" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtCellPhoneNotes" ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" 
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="tbweCellPhoneNotes" runat="server" TargetControlID="txtCellPhoneNotes"
                            WatermarkCssClass="watermark" WatermarkText=" "></ajax:TextBoxWatermarkExtender>
                        <br />
                        <asp:Label ID="lbWorkPhoneText" runat="server" Text="" Width="200px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtWorkPhone" runat="server" Text="" Width="100px" MaxLength="12" onkeydown="setHyphensWK();" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvWorkPhone" runat="server" ControlToValidate="txtWorkPhone" Enabled="false"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revWorkPhone" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtWorkPhone" ErrorMessage="" Font-Size="X-Large"
                            ValidationExpression="(###-###-####)|((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" TargetControlID="txtWorkPhone"
                            WatermarkCssClass="watermark" WatermarkText="###-###-####"></ajax:TextBoxWatermarkExtender>
                        <asp:TextBox ID="txtWorkPhoneNotes" runat="server" Text="" Width="120px" MaxLength="100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revWorkPhoneNotes" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtWorkPhoneNotes" ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" 
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="tbweWorkPhoneNotes" runat="server" TargetControlID="txtWorkPhoneNotes"
                            WatermarkCssClass="watermark" WatermarkText=" "></ajax:TextBoxWatermarkExtender>
                        <br />
                        <asp:Label ID="lbAlternativePhoneText" runat="server" Text="" Width="200px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtAlternativePhone" runat="server" Text="" Width="100px" MaxLength="12" onkeydown="setHyphensAlt();" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAlternativePhone" runat="server" ControlToValidate="txtAlternativePhone" Enabled="false"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revAlternativePhone" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtAlternativePhone" ErrorMessage="" Font-Size="X-Large"
                            ValidationExpression="(###-###-####)|((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="txtAlternativePhone"
                            WatermarkCssClass="watermark" WatermarkText="###-###-####"></ajax:TextBoxWatermarkExtender>
                        <asp:TextBox ID="txtAlternativePhoneNotes" runat="server" Text="" Width="120px" MaxLength="100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revAlternativePhoneNotes" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtAlternativePhoneNotes" ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" 
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="tbweAlternativePhoneNotes" runat="server" TargetControlID="txtAlternativePhoneNotes"
                            WatermarkCssClass="watermark" WatermarkText=" "></ajax:TextBoxWatermarkExtender>
                        <br />
                        <asp:Label ID="lbPrimaryPhoneToCallText" runat="server" Text="" Width="200px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddPrimaryPhoneToCall" runat="server" ValidationGroup="LivingDonor" AppendDataBoundItems="True"
                            Width="140px" onchange='PhoneValidation();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvPrimaryPhoneToCall" runat="server" ControlToValidate="ddPrimaryPhoneToCall"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="LivingDonor"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbPrimaryeMailText" runat="server" Text="" Width="200px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtPrimaryeMail" runat="server" Text="" Width="240px" MaxLength="100" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revPrimaryeMail" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtPrimaryeMail" ErrorMessage="" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Font-Size="X-Large" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbSecondaryeMailText" runat="server" Text="" Width="200px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtSecondaryeMail" runat="server" Text="" Width="240px" MaxLength="100" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revSecondaryeMail" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtSecondaryeMail" ErrorMessage="" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Font-Size="X-Large" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbBestTimeToContactText" runat="server" Text="" Width="200px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtBestTimeToContact" runat="server" Text="" Width="240px" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBestTimeToContact" runat="server" ControlToValidate="txtBestTimeToContact" ForeColor="Red"
                            ErrorMessage="" Font-Size="X-Large" ValidationGroup="LivingDonor" Text="*" Enabled="false"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revBestTimeToContact" runat="server" ValidationGroup="LivingDonor"
                            ControlToValidate="txtBestTimeToContact" ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" 
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,100}$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lbSocialSecurityNumberText" runat="server" Text="" Width="200px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtSocialSecurityNumber" runat="server" Text="" Width="100px" onkeydown="setHyphensSSNAdd();" MaxLength="11" ValidationGroup="LivingDonor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSocialSecurityNumber" runat="server" ControlToValidate="txtSocialSecurityNumber" ForeColor="Red"
                            ErrorMessage="" Font-Size="X-Large" ValidationGroup="LivingDonor" Text="*" Enabled="false"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revSocialSecurityNumber" runat="server" ValidationGroup="LivingDonor" Text="*"
                            ControlToValidate="txtSocialSecurityNumber" ValidationExpression="\d{3}-\d{2}-\d{4}" ForeColor="Red"
                            ErrorMessage="" Font-Size="X-Large"></asp:RegularExpressionValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtSocialSecurityNumber"
                            WatermarkCssClass="watermark" WatermarkText="###-##-####"></ajax:TextBoxWatermarkExtender>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:LinqDataSource ID="LinqDonorState" runat="server" ContextTypeName="MyPortfolioDbDataContext"
            TableName="lkpStateReferrals">
        </asp:LinqDataSource>
        <asp:LinqDataSource ID="LinqDonorPrimaryPhoneToCall" runat="server" ContextTypeName="MyPortfolioDbDataContext"
            TableName="lkpPrimaryPhoneToCallReferrals">
        </asp:LinqDataSource>
        <asp:HiddenField ID="hfTabPanelLivingDonor" runat="server" Value="False" />
        <asp:HiddenField ID="hfPID" runat="server" />
        <asp:HiddenField ID="hfUserId" runat="server" />
        <asp:HiddenField ID="hfLanguage" runat="server" />
        <asp:HiddenField ID="hfLanguageText" runat="server" />
        <asp:HiddenField ID="hfPleaseEnter" runat="server" />
        <asp:HiddenField ID="hfIsInvalid" runat="server" />
        <asp:HiddenField ID="hfSSN" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtCity" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddState" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtHomePhone" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtCellPhone" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtWorkPhone" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtAlternativePhone" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddPrimaryPhoneToCall" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtSocialSecurityNumber" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>

