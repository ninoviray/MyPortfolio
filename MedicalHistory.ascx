<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MedicalHistory.ascx.vb" Inherits="Controls_MedicalHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="../Content/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
<script type="text/javascript" lang="javascript">

    window.scrollTo = function (x, y) {
        return true;
    };

    function setDiabetes() {
        var ddd = document.getElementById('<%= ddDiabetes.ClientID %>');
        if (ddd.value == 1) {
            document.getElementById('<%= ddDiabetesInsulin.ClientID %>').value = "";
            document.getElementById('<%= ddDiabetesInsulin.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDiabetesInsulin.ClientID %>'), true);

            document.getElementById('<%= ddDiabetesOralMedication.ClientID %>').value = "";
            document.getElementById('<%= ddDiabetesOralMedication.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDiabetesOralMedication.ClientID %>'), true);


        } else {
            if (ddd.value == 0) {
                document.getElementById('<%= ddDiabetesInsulin.ClientID %>').value = "0";
                document.getElementById('<%= ddDiabetesInsulin.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDiabetesInsulin.ClientID %>'), false);
                document.getElementById('<%= ddDiabetesOralMedication.ClientID %>').value = "0";
                document.getElementById('<%= ddDiabetesOralMedication.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDiabetesOralMedication.ClientID %>'), false);
            }
            if (ddd.value == 2) {
                document.getElementById('<%= ddDiabetesInsulin.ClientID %>').value = "2";
                document.getElementById('<%= ddDiabetesInsulin.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDiabetesInsulin.ClientID %>'), false);
                document.getElementById('<%= ddDiabetesOralMedication.ClientID %>').value = "2";
                document.getElementById('<%= ddDiabetesOralMedication.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDiabetesOralMedication.ClientID %>'), false);
            }
        }
    }

    function setHeartProblems() {
        var ddhp = document.getElementById('<%= ddHeartProblems.ClientID %>');
        if (ddhp.value > 0) {
            document.getElementById('<%= txtHeartProblemsDescription.ClientID %>').disabled = false;
        } else {
            document.getElementById('<%= txtHeartProblemsDescription.ClientID %>').disabled = true;
        }
    }

    function setKidneyStones() {
        var ddks = document.getElementById('<%= ddKidneyStones.ClientID %>');
        if (ddks.value == 1) {
            document.getElementById('<%= ddKidneyStonesAmount.ClientID %>').value = "";
            document.getElementById('<%= ddKidneyStonesAmount.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvKidneyStonesAmount.ClientID %>'), true);
        } else {
            if (ddks.value == 0) {
                document.getElementById('<%= ddKidneyStonesAmount.ClientID %>').value = "0";
                document.getElementById('<%= ddKidneyStonesAmount.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvKidneyStonesAmount.ClientID %>'), false);
            }
            if (ddks.value == 2) {
                document.getElementById('<%= ddKidneyStonesAmount.ClientID %>').value = "0";
                document.getElementById('<%= ddKidneyStonesAmount.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvKidneyStonesAmount.ClientID %>'), false);
            }
        }
    }

    function setCancerMelanoma() {
        var ddc = document.getElementById('<%= ddCancerMelanoma.ClientID %>');
        var ddcn = document.getElementById('<%= ddCancerNonMelanoma.ClientID %>');
        if (ddc.value == 1 || ddcn.value == 1) {
            document.getElementById('<%= txtCancerDescription.ClientID %>').disabled = false;
        } else {
            if (ddc.value == 0 || ddcn.value == 0) {
                document.getElementById('<%= txtCancerDescription.ClientID %>').disabled = true;
            }
            if (ddc.value == 2 || ddcn.value == 2) {
                document.getElementById('<%= txtCancerDescription.ClientID %>').disabled = false;
            }
        }
    }

</script>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanelMedicalHistory" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="PanelMedicalHistory" runat="server">
            <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
                <tr>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbDiabetesText" runat="server" Text="" Width="320px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDiabetes" runat="server" ValidationGroup="MedicalHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setDiabetes();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDiabetes" runat="server" ErrorMessage=""
                            ControlToValidate="ddDiabetes" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="MedicalHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDiabetesInsulinText" runat="server" Text="" Width="320px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDiabetesInsulin" runat="server" ValidationGroup="MedicalHistory" AppendDataBoundItems="True"
                            Width="100px" Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDiabetesInsulin" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDiabetesInsulin" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="MedicalHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDiabetesOralMedicationText" runat="server" Text="" Width="320px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDiabetesOralMedication" runat="server" ValidationGroup="MedicalHistory" AppendDataBoundItems="True"
                            Width="100px" Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDiabetesOralMedication" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDiabetesOralMedication" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="MedicalHistory"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbCurrentMedicationText" runat="server" Text="" Width="320px" Style="text-align: left" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCurrentMedication" runat="server" Text="" Width="420px" Rows="4" TextMode="MultiLine" ValidationGroup="MedicalHistory"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revCurrentMedication" runat="server" ControlToValidate="txtCurrentMedication"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="MedicalHistory"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,500}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbHeartProblemsText" runat="server" Text="" Width="320px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddHeartProblems" runat="server" ValidationGroup="MedicalHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setHeartProblems();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvHeartProblems" runat="server" ErrorMessage=""
                            ControlToValidate="ddHeartProblems" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="MedicalHistory"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbHeartProblemsDescriptionText" runat="server" Text="" Width="380px" Style="text-align: left" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtHeartProblemsDescription" runat="server" Width="420px" Rows="4" TextMode="MultiLine" Enabled="false" ValidationGroup="MedicalHistory"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revHeartProblemsDescription" runat="server" ControlToValidate="txtHeartProblemsDescription"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="MedicalHistory"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,500}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbKidneyStonesText" runat="server" Text="" Width="320px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddKidneyStones" runat="server" ValidationGroup="MedicalHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setKidneyStones();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvKidneyStones" runat="server" ErrorMessage=""
                            ControlToValidate="ddKidneyStones" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="MedicalHistory"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbKidneyStonesAmountText" runat="server" Text="" Width="340px" Style="text-align: left" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddKidneyStonesAmount" runat="server" ValidationGroup="MedicalHistory" AppendDataBoundItems="True"
                            Width="80px" Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvKidneyStonesAmount" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddKidneyStonesAmount" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="MedicalHistory"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbCancerMelanomaText" runat="server" Text="" Width="320px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddCancerMelanoma" runat="server" ValidationGroup="MedicalHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setCancerMelanoma();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCancerMelanoma" runat="server" ErrorMessage=""
                            ControlToValidate="ddCancerMelanoma" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="MedicalHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbCancerNonMelanomaText" runat="server" Text="" Width="320px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddCancerNonMelanoma" runat="server" ValidationGroup="MedicalHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setCancerMelanoma();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCancerNonMelanoma" runat="server" ErrorMessage=""
                            ControlToValidate="ddCancerNonMelanoma" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="MedicalHistory"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbCancerDescriptionText" runat="server" Text="" Width="320px" Style="text-align: left" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCancerDescription" runat="server" Width="420px" Rows="4" TextMode="MultiLine" Enabled="false" ValidationGroup="MedicalHistory"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revCancerDescription" runat="server" ControlToValidate="txtCancerDescription"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="MedicalHistory"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,500}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; vertical-align: text-top;">
                        <asp:Label ID="lbPastSurgeriesText" runat="server" Text="" Width="320px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddPastSurgeries" runat="server" ValidationGroup="MedicalHistory" AppendDataBoundItems="True"
                            Width="100px" >
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddPastSurgeries" runat="server" ErrorMessage=""
                            ControlToValidate="ddPastSurgeries" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="MedicalHistory"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 50%; vertical-align: text-top;">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:LinqDataSource ID="LinqDonorDiabetes" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDiabetesReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDiabetesInsulin" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDiabetesInsulinReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDiabetesOralMedication" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDiabetesOralMedicationReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorHeartProblems" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpHeartProblemsReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorKidneyStones" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpKidneyStonesReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorKidneyStonesAmount" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpKidneyStonesAmountReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorCancerMelanoma" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpCancerMelanomaReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorCancerNonMelanoma" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpCancerNonMelanomaReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorPastSurgeries" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpPastSurgeriesReferrals">
            </asp:LinqDataSource>
            <asp:HiddenField ID="hfTabPanelMedicalHistory" runat="server" Value="False" />
            <asp:HiddenField ID="hfPID" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfLanguage" runat="server" />
            <asp:HiddenField ID="hfLanguageText" runat="server" />
            <asp:HiddenField ID="hfPleaseEnter" runat="server" />
            <asp:HiddenField ID="hfIsInvalid" runat="server" />
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddDiabetes" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDiabetesInsulin" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDiabetesOralMedication" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddHeartProblems" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddKidneyStones" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddKidneyStonesAmount" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddCancerMelanoma" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddCancerNonMelanoma" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
