<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BloodHistory.ascx.vb" Inherits="Controls_BloodHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="../Content/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
<script type="text/javascript" lang="javascript">

    window.scrollTo = function (x, y) {
        return true;
    };

    function setBloodType() {
        var ddbt = document.getElementById('<%= ddBloodType.ClientID %>');
        if (ddbt.value < 9) {
            if (ddbt.value == 0) {
                document.getElementById('<%= ddBloodRHFactor.ClientID %>').value = "";
                document.getElementById('<%= ddBloodRHFactor.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvBloodRHFactor.ClientID %>'), false);
            } else {
                document.getElementById('<%= ddBloodRHFactor.ClientID %>').value = "";
                document.getElementById('<%= ddBloodRHFactor.ClientID %>').disabled = false;
                ValidatorEnable(document.getElementById('<%= rfvBloodRHFactor.ClientID %>'), true);
            }

        } else {
            document.getElementById('<%= ddBloodRHFactor.ClientID %>').value = 3;
            document.getElementById('<%= ddBloodRHFactor.ClientID %>').disabled = true;
            ValidatorEnable(document.getElementById('<%= rfvBloodRHFactor.ClientID %>'), false);
        }
    }

    function setHighBloodPressure() {
        var ddhbp = document.getElementById('<%= ddHighBloodPressure.ClientID %>');
        if (ddhbp.value == 1) {
            document.getElementById('<%= ddHighBloodPressureMedication.ClientID %>').value = "";
            document.getElementById('<%= ddHighBloodPressureMedication.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvHighBloodPressureMedication.ClientID %>'), true);
            } else {
                if (ddhbp.value == 0) {
                    document.getElementById('<%= ddHighBloodPressureMedication.ClientID %>').value = "0";
                    document.getElementById('<%= ddHighBloodPressureMedication.ClientID %>').disabled = true;
                    ValidatorEnable(document.getElementById('<%= rfvHighBloodPressureMedication.ClientID %>'), false);
                    document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').value = "0";
                    document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').disabled = true;
                    ValidatorEnable(document.getElementById('<%= rfvHighBloodPressureMedicationAmount.ClientID %>'), false);
                }
                if (ddhbp.value == 2) {
                    document.getElementById('<%= ddHighBloodPressureMedication.ClientID %>').value = "2";
                    document.getElementById('<%= ddHighBloodPressureMedication.ClientID %>').disabled = true;
                    ValidatorEnable(document.getElementById('<%= rfvHighBloodPressureMedication.ClientID %>'), false);
                    document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').value = "0";
                    document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').disabled = true;
                    ValidatorEnable(document.getElementById('<%= rfvHighBloodPressureMedicationAmount.ClientID %>'), false);
            }
        }
    }

    function setHighBloodPressureMedication() {
        var ddhbpm = document.getElementById('<%= ddHighBloodPressureMedication.ClientID %>');
        if (ddhbpm.value == 1) {
            document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').value = "";
            document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvHighBloodPressureMedicationAmount.ClientID %>'), true);
            } else {
                if (ddhbpm.value == 0) {
                    document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').value = "0";
                    document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').disabled = true;
                    ValidatorEnable(document.getElementById('<%= rfvHighBloodPressureMedicationAmount.ClientID %>'), false);
                }
                if (ddhbpm.value == 2) {
                    document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').value = "0";
                    document.getElementById('<%= ddHighBloodPressureMedicationAmount.ClientID %>').disabled = true;
                    ValidatorEnable(document.getElementById('<%= rfvHighBloodPressureMedicationAmount.ClientID %>'), false);
            }
        }
    }

</script>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanelBloodHistory" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="PanelBloodHistory" runat="server">
            <table style="margin-left: auto; margin-right: auto; width: 900px;" border="0" class="body">
                <tr>
                    <td style="width: 100%; vertical-align: text-top;">
                        <asp:Label ID="lbBloodTypeText" runat="server" Text="Blood Type:" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddBloodType" runat="server" ValidationGroup="BloodHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setBloodType();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvBloodType" runat="server" ErrorMessage=""
                            ControlToValidate="ddBloodType" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="BloodHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbBloodRHFactorText" runat="server" Text="RH Factor:" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddBloodRHFactor" runat="server" ValidationGroup="BloodHistory" AppendDataBoundItems="True"
                            Width="100px" Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvBloodRHFactor" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddBloodRHFactor" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="BloodHistory"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; vertical-align: text-top;">
                        <asp:Label ID="lbHighBloodPressureText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddHighBloodPressure" runat="server" ValidationGroup="BloodHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setHighBloodPressure();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvHighBloodPressure" runat="server" ErrorMessage=""
                            ControlToValidate="ddHighBloodPressure" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="BloodHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbHighBloodPressureMedicationText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddHighBloodPressureMedication" runat="server" ValidationGroup="BloodHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setHighBloodPressureMedication();' Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvHighBloodPressureMedication" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddHighBloodPressureMedication" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="BloodHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbHighBloodPressureMedicationAmountText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddHighBloodPressureMedicationAmount" runat="server" ValidationGroup="BloodHistory" AppendDataBoundItems="True"
                            Width="100px" Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvHighBloodPressureMedicationAmount" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddHighBloodPressureMedicationAmount" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="BloodHistory"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; vertical-align: text-top;">
                        <asp:Label ID="lbBloodTransfusionText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddBloodTransfusion" runat="server" AppendDataBoundItems="True"
                            Width="100px" ValidationGroup="BloodHistory">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvBloodTransfusion" runat="server" ErrorMessage=""
                            ControlToValidate="ddBloodTransfusion" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="BloodHistory"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:LinqDataSource ID="LinqDonorBloodType" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpBloodTypeReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorBloodRHFactor" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpBloodRHFactorReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorBloodPressure" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpBloodPressureReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorBloodPressureMedication" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpBloodPressureMedicationReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorBloodPressureMedicationAmount" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpBloodPressureMedicationAmountReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorBloodTransfusion" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpBloodTransfusionReferrals">
            </asp:LinqDataSource>
            <asp:HiddenField ID="hfTabPanelBloodHistory" runat="server" Value="False" />
            <asp:HiddenField ID="hfPID" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfLanguage" runat="server" />
            <asp:HiddenField ID="hfLanguageText" runat="server" />
            <asp:HiddenField ID="hfPleaseEnter" runat="server" />
            <asp:HiddenField ID="hfIsInvalid" runat="server" />
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddBloodType" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddBloodRHFactor" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddHighBloodPressure" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddHighBloodPressureMedication" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddHighBloodPressureMedicationAmount" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddBloodTransfusion" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>

