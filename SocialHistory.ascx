<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SocialHistory.ascx.vb" Inherits="Controls_SocialHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="../Content/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
<script type="text/javascript" lang="javascript">

    window.scrollTo = function (x, y) {
        return true;
    };

    function setSmoking() {
        var dds = document.getElementById('<%= ddSmoking.ClientID %>');
        if (dds.value == 1) {
            document.getElementById('<%= ddSmokingCurrently.ClientID %>').value = "";
            document.getElementById('<%= ddSmokingCurrently.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvSmokingCurrently.ClientID %>'), true);
            document.getElementById('<%= txtSmokingHowManyYears.ClientID %>').value = "";
            document.getElementById('<%= txtSmokingHowManyYears.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvSmokingHowManyYears.ClientID %>'), true);
            ValidatorEnable(document.getElementById('<%= rvSmokingHowManyYears.ClientID %>'), true);
            document.getElementById('<%= ddSmokingFrequency.ClientID %>').value = "";
            document.getElementById('<%= ddSmokingFrequency.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvSmokingFrequency.ClientID %>'), true);
            document.getElementById('<%= cbSmokingCigarettes.ClientID %>').checked = false;
            document.getElementById('<%= cbSmokingCigarettes.ClientID %>').disabled = false;
            document.getElementById('<%= cbSmokingECigarettes.ClientID %>').checked = false;
            document.getElementById('<%= cbSmokingECigarettes.ClientID %>').disabled = false;
            document.getElementById('<%= cbSmokingCigars.ClientID %>').checked = false;
            document.getElementById('<%= cbSmokingCigars.ClientID %>').disabled = false;
            document.getElementById('<%= cbSmokingPipeHookah.ClientID %>').checked = false;
            document.getElementById('<%= cbSmokingPipeHookah.ClientID %>').disabled = false;
            document.getElementById('<%= cbSmokingVapes.ClientID %>').checked = false;
            document.getElementById('<%= cbSmokingVapes.ClientID %>').disabled = false;
        } else {
            if (dds.value == 0) {
                document.getElementById('<%= ddSmokingCurrently.ClientID %>').value = "0";
                document.getElementById('<%= ddSmokingCurrently.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvSmokingCurrently.ClientID %>'), false);
                document.getElementById('<%= txtSmokingHowManyYears.ClientID %>').value = "0";
                document.getElementById('<%= txtSmokingHowManyYears.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvSmokingHowManyYears.ClientID %>'), false);
                ValidatorEnable(document.getElementById('<%= rvSmokingHowManyYears.ClientID %>'), false);
                document.getElementById('<%= ddSmokingFrequency.ClientID %>').value = "0";
                document.getElementById('<%= ddSmokingFrequency.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvSmokingFrequency.ClientID %>'), false);
                document.getElementById('<%= ddSmokingQuit.ClientID %>').value = "2";
                document.getElementById('<%= ddSmokingQuit.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvSmokingQuit.ClientID %>'), false);
                document.getElementById('<%= cbSmokingCigarettes.ClientID %>').checked = false;
                document.getElementById('<%= cbSmokingCigarettes.ClientID %>').disabled = true;
                document.getElementById('<%= cbSmokingECigarettes.ClientID %>').checked = false;
                document.getElementById('<%= cbSmokingECigarettes.ClientID %>').disabled = true;
                document.getElementById('<%= cbSmokingCigars.ClientID %>').checked = false;
                document.getElementById('<%= cbSmokingCigars.ClientID %>').disabled = true;
                document.getElementById('<%= cbSmokingPipeHookah.ClientID %>').checked = false;
                document.getElementById('<%= cbSmokingPipeHookah.ClientID %>').disabled = true;
                document.getElementById('<%= cbSmokingVapes.ClientID %>').checked = false;
                document.getElementById('<%= cbSmokingVapes.ClientID %>').disabled = true;
            }
        }
    }

    function setSmokingCurrently() {
        var ddsc = document.getElementById('<%= ddSmokingCurrently.ClientID %>');
        if (ddsc.value == 1) {
            document.getElementById('<%= ddSmokingQuit.ClientID %>').value = "";
            document.getElementById('<%= ddSmokingQuit.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvSmokingQuit.ClientID %>'), true);
        } else {
            if (ddsc.value == 0) {
                document.getElementById('<%= ddSmokingQuit.ClientID %>').value = "2";
                document.getElementById('<%= ddSmokingQuit.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvSmokingQuit.ClientID %>'), false);
            }
        }
    }

    function setDrinking() {
        var dddr = document.getElementById('<%= ddDrinking.ClientID %>');
        if (dddr.value == 1) {
            document.getElementById('<%= ddDrinkingCurrently.ClientID %>').value = "";
            document.getElementById('<%= ddDrinkingCurrently.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDrinkingCurrently.ClientID %>'), true);
            document.getElementById('<%= ddDrinkingFrequency.ClientID %>').value = "";
            document.getElementById('<%= ddDrinkingFrequency.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDrinkingFrequency.ClientID %>'), true);
            document.getElementById('<%= ddDrinkingAlcoholAbuse.ClientID %>').value = "";
            document.getElementById('<%= ddDrinkingAlcoholAbuse.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDrinkingAlcoholAbuse.ClientID %>'), true);
        } else {
            if (dddr.value == 0) {
                document.getElementById('<%= ddDrinkingCurrently.ClientID %>').value = "0";
                document.getElementById('<%= ddDrinkingCurrently.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrinkingCurrently.ClientID %>'), false);
                document.getElementById('<%= ddDrinkingFrequency.ClientID %>').value = "0";
                document.getElementById('<%= ddDrinkingFrequency.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrinkingFrequency.ClientID %>'), false);
                document.getElementById('<%= ddDrinkingAlcoholAbuse.ClientID %>').value = "2";
                document.getElementById('<%= ddDrinkingAlcoholAbuse.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrinkingAlcoholAbuse.ClientID %>'), false);
                document.getElementById('<%= ddDrinkingQuit.ClientID %>').value = "2";
                document.getElementById('<%= ddDrinkingQuit.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrinkingQuit.ClientID %>'), false);
            }
        }
    }

    function setDrinkingCurrently() {
        var dddc = document.getElementById('<%= ddDrinkingCurrently.ClientID %>');
        if (dddc.value == 1) {
            document.getElementById('<%= ddDrinkingQuit.ClientID %>').value = "";
            document.getElementById('<%= ddDrinkingQuit.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDrinkingQuit.ClientID %>'), true);
        } else {
            if (dddc.value == 0) {
                document.getElementById('<%= ddDrinkingQuit.ClientID %>').value = "2";
                document.getElementById('<%= ddDrinkingQuit.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrinkingQuit.ClientID %>'), false);
            }
        }
    }

    function setDrugPrescription() {
        var dddp = document.getElementById('<%= ddDrugPrescription.ClientID %>');
        if (dddp.value == 1) {
            document.getElementById('<%= ddDrugPrescriptionCurrently.ClientID %>').value = "";
            document.getElementById('<%= ddDrugPrescriptionCurrently.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDrugPrescriptionCurrently.ClientID %>'), true);
        } else {
            if (dddp.value == 0) {
                document.getElementById('<%= ddDrugPrescriptionCurrently.ClientID %>').value = "0";
                document.getElementById('<%= ddDrugPrescriptionCurrently.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrugPrescriptionCurrently.ClientID %>'), false);
                document.getElementById('<%= ddDrugPrescriptionQuit.ClientID %>').value = "2";
                document.getElementById('<%= ddDrugPrescriptionQuit.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrugPrescriptionQuit.ClientID %>'), false);
            }
        }
    }

    function setDrugPrescriptionCurrently() {
        var dddpc = document.getElementById('<%= ddDrugPrescriptionCurrently.ClientID %>');
        if (dddpc.value == 1) {
            document.getElementById('<%= ddDrugPrescriptionQuit.ClientID %>').value = "";
            document.getElementById('<%= ddDrugPrescriptionQuit.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDrugPrescriptionQuit.ClientID %>'), true);
        } else {
            if (dddpc.value == 0) {
                document.getElementById('<%= ddDrugPrescriptionQuit.ClientID %>').value = "2";
                document.getElementById('<%= ddDrugPrescriptionQuit.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrugPrescriptionQuit.ClientID %>'), false);
            }
        }
    }

    function setDrugRecreational() {
        var dddre = document.getElementById('<%= ddDrugRecreational.ClientID %>');
        if (dddre.value == 1) {
            document.getElementById('<%= ddDrugRecreationalCurrently.ClientID %>').value = "";
            document.getElementById('<%= ddDrugRecreationalCurrently.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDrugRecreationalCurrently.ClientID %>'), true);
            document.getElementById('<%= cbDrugRecreationalMarijuana.ClientID %>').checked = false;
            document.getElementById('<%= cbDrugRecreationalMarijuana.ClientID %>').disabled = false;
            document.getElementById('<%= cbDrugRecreationalSyntheticMarijuana.ClientID %>').checked = false;
            document.getElementById('<%= cbDrugRecreationalSyntheticMarijuana.ClientID %>').disabled = false;
            document.getElementById('<%= cbDrugRecreationalCocaine.ClientID %>').checked = false;
            document.getElementById('<%= cbDrugRecreationalCocaine.ClientID %>').disabled = false;
            document.getElementById('<%= cbDrugRecreationalCrackCocaine.ClientID %>').checked = false;
            document.getElementById('<%= cbDrugRecreationalCrackCocaine.ClientID %>').disabled = false;
            document.getElementById('<%= cbDrugRecreationalHeroin.ClientID %>').checked = false;
            document.getElementById('<%= cbDrugRecreationalHeroin.ClientID %>').disabled = false;
            document.getElementById('<%= cbDrugRecreationalMethamphetamines.ClientID %>').checked = false;
            document.getElementById('<%= cbDrugRecreationalMethamphetamines.ClientID %>').disabled = false;
            document.getElementById('<%= cbDrugRecreationalCrystalMeth.ClientID %>').checked = false;
            document.getElementById('<%= cbDrugRecreationalCrystalMeth.ClientID %>').disabled = false;
            document.getElementById('<%= cbDrugRecreationalEcstasy.ClientID %>').checked = false;
            document.getElementById('<%= cbDrugRecreationalEcstasy.ClientID %>').disabled = false;
            document.getElementById('<%= cbDrugRecreationalLysergicAcidDiethylamide.ClientID %>').checked = false;
            document.getElementById('<%= cbDrugRecreationalLysergicAcidDiethylamide.ClientID %>').disabled = false;

        } else {
            if (dddre.value == 0) {
                document.getElementById('<%= ddDrugRecreationalCurrently.ClientID %>').value = "0";
                document.getElementById('<%= ddDrugRecreationalCurrently.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrugRecreationalCurrently.ClientID %>'), false);
                document.getElementById('<%= ddDrugRecreationalQuit.ClientID %>').value = "2";
                document.getElementById('<%= ddDrugRecreationalQuit.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrugRecreationalQuit.ClientID %>'), false);
                document.getElementById('<%= cbDrugRecreationalMarijuana.ClientID %>').checked = false;
                document.getElementById('<%= cbDrugRecreationalMarijuana.ClientID %>').disabled = true;
                document.getElementById('<%= cbDrugRecreationalSyntheticMarijuana.ClientID %>').checked = false;
                document.getElementById('<%= cbDrugRecreationalSyntheticMarijuana.ClientID %>').disabled = true;
                document.getElementById('<%= cbDrugRecreationalCocaine.ClientID %>').checked = false;
                document.getElementById('<%= cbDrugRecreationalCocaine.ClientID %>').disabled = true;
                document.getElementById('<%= cbDrugRecreationalCrackCocaine.ClientID %>').checked = false;
                document.getElementById('<%= cbDrugRecreationalCrackCocaine.ClientID %>').disabled = true;
                document.getElementById('<%= cbDrugRecreationalHeroin.ClientID %>').checked = false;
                document.getElementById('<%= cbDrugRecreationalHeroin.ClientID %>').disabled = true;
                document.getElementById('<%= cbDrugRecreationalMethamphetamines.ClientID %>').checked = false;
                document.getElementById('<%= cbDrugRecreationalMethamphetamines.ClientID %>').disabled = true;
                document.getElementById('<%= cbDrugRecreationalCrystalMeth.ClientID %>').checked = false;
                document.getElementById('<%= cbDrugRecreationalCrystalMeth.ClientID %>').disabled = true;
                document.getElementById('<%= cbDrugRecreationalEcstasy.ClientID %>').checked = false;
                document.getElementById('<%= cbDrugRecreationalEcstasy.ClientID %>').disabled = true;
                document.getElementById('<%= cbDrugRecreationalLysergicAcidDiethylamide.ClientID %>').checked = false;
                document.getElementById('<%= cbDrugRecreationalLysergicAcidDiethylamide.ClientID %>').disabled = true;

            }
        }
    }

    function setDrugRecreationalCurrently() {
        var dddrc = document.getElementById('<%= ddDrugRecreationalCurrently.ClientID %>');
        if (dddrc.value == 1) {
            document.getElementById('<%= ddDrugRecreationalQuit.ClientID %>').value = "";
            document.getElementById('<%= ddDrugRecreationalQuit.ClientID %>').disabled = false;
            ValidatorEnable(document.getElementById('<%= rfvDrugRecreationalQuit.ClientID %>'), true);
        } else {
            if (dddrc.value == 0) {
                document.getElementById('<%= ddDrugRecreationalQuit.ClientID %>').value = "2";
                document.getElementById('<%= ddDrugRecreationalQuit.ClientID %>').disabled = true;
                ValidatorEnable(document.getElementById('<%= rfvDrugRecreationalQuit.ClientID %>'), false);
            }
        }
    }

    function setDrugUseOther() {
        var ddduo = document.getElementById('<%= ddDrugUseOther.ClientID %>');
        if (ddduo.value > 0) {
            document.getElementById('<%= txtDrugUseOtherComments.ClientID %>').disabled = false;
        } else {
            document.getElementById('<%= txtDrugUseOtherComments.ClientID %>').disabled = true;
            document.getElementById('<%= txtDrugUseOtherComments.ClientID %>').value = "";
        }
    }

</script>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanelSocialHistory" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="PanelSocialHistory" runat="server">
            <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
                <tr>
                    <td style="width: 64%; vertical-align: text-top;">
                        <asp:Label ID="lbSmokingText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddSmoking" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setSmoking();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSmoking" runat="server" ErrorMessage=""
                            ControlToValidate="ddSmoking" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbSmokingCurrentlyText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddSmokingCurrently" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setSmokingCurrently();' Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSmokingCurrently" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddSmokingCurrently" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbSmokingHowManyYearsText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtSmokingHowManyYears" runat="server" Width="40px" MaxLength="2" ValidationGroup="SocialHistory" Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSmokingHowManyYears" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="txtSmokingHowManyYears" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvSmokingHowManyYears" runat="server" ControlToValidate="txtSmokingHowManyYears" ValidationGroup="SocialHistory"
                            ErrorMessage="" Font-Size="X-Large" Type="Integer" SetFocusOnError="True" Text="*" ForeColor="Red" MaximumValue="50" MinimumValue="0"></asp:RangeValidator>
                        <br />
                        <asp:Label ID="lbSmokingFrequencyText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddSmokingFrequency" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True" Enabled="false"
                            Width="120px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSmokingFrequency" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddSmokingFrequency" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbSmokingQuitText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddSmokingQuit" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True" Enabled="false"
                            Width="100px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSmokingQuit" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddSmokingQuit" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 36%; vertical-align: text-top;">
                        <asp:CheckBox ID="cbSmokingCigarettes" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbSmokingECigarettes" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbSmokingCigars" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbSmokingPipeHookah" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbSmokingVapes" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <asp:Label ID="lbDrinkingText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrinking" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setDrinking();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrinking" runat="server" ErrorMessage=""
                            ControlToValidate="ddDrinking" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDrinkingCurrentlyText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrinkingCurrently" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setDrinkingCurrently();' Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrinkingCurrently" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDrinkingCurrently" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDrinkingFrequencyText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrinkingFrequency" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="240px" Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrinkingFrequency" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDrinkingFrequency" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDrinkingAlcoholAbuseText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrinkingAlcoholAbuse" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrinkingAlcoholAbuse" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDrinkingAlcoholAbuse" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDrinkingQuitText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrinkingQuit" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True" Enabled="false"
                            Width="100px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrinkingQuit" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDrinkingQuit" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <asp:Label ID="lbDrugPrescriptionText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrugPrescription" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setDrugPrescription();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrugPrescription" runat="server" ErrorMessage=""
                            ControlToValidate="ddDrugPrescription" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDrugPrescriptionCurrentlyText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrugPrescriptionCurrently" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setDrugPrescriptionCurrently();' Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrugPrescriptionCurrently" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDrugPrescriptionCurrently" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDrugPrescriptionQuitText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrugPrescriptionQuit" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True" Enabled="false"
                            Width="100px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrugPrescriptionQuit" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDrugPrescriptionQuit" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 64%; vertical-align: text-top;">
                        <asp:Label ID="lbDrugRecreationalText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrugRecreational" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setDrugRecreational();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrugRecreational" runat="server" ErrorMessage=""
                            ControlToValidate="ddDrugRecreational" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDrugRecreationalCurrentlyText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrugRecreationalCurrently" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setDrugRecreationalCurrently();' Enabled="false">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrugRecreationalCurrently" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDrugRecreationalCurrently" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbDrugRecreationalQuitText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrugRecreationalQuit" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True" Enabled="false"
                            Width="100px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrugRecreationalQuit" runat="server" ErrorMessage="" Enabled="false"
                            ControlToValidate="ddDrugRecreationalQuit" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 36%; vertical-align: text-top;">
                        <asp:CheckBox ID="cbDrugRecreationalMarijuana" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbDrugRecreationalSyntheticMarijuana" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbDrugRecreationalCocaine" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbDrugRecreationalCrackCocaine" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbDrugRecreationalHeroin" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbDrugRecreationalMethamphetamines" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbDrugRecreationalCrystalMeth" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbDrugRecreationalEcstasy" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                        <br />
                        <asp:CheckBox ID="cbDrugRecreationalLysergicAcidDiethylamide" runat="server" Text="" Width="260px" Style="text-align: left" Font-Bold="True" Enabled="false" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%; vertical-align: text-top;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 64%; vertical-align: text-top;">
                        <asp:Label ID="lbDrugUseOtherText" runat="server" Text="" Width="440px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddDrugUseOther" runat="server" ValidationGroup="SocialHistory" AppendDataBoundItems="True"
                            Width="100px" onchange='setDrugUseOther();'>
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDrugUseOther" runat="server" ErrorMessage=""
                            ControlToValidate="ddDrugUseOther" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="SocialHistory"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 36%; vertical-align: text-top;">
                        <asp:Label ID="lbDrugUseOtherCommentsText" runat="server" Text="" Width="200px" Style="text-align: left" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtDrugUseOtherComments" runat="server" Width="280px" Rows="4" TextMode="MultiLine"
                            ValidationGroup="SocialHistory" Enabled="false"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revDrugUseOtherComments" runat="server" ControlToValidate="txtDrugUseOtherComments"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red" ValidationGroup="SocialHistory"
                            ValidationExpression="^[a-zA-Z&quot;'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \{ | \} | \? | \ | \! | \% | \+ | \&amp; | \, | \! | \: | \; | \' | \’ | \# | \@ $]{1,200}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <asp:LinqDataSource ID="LinqDonorSmoking" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpSmokingReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorSmokingCurrently" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpSmokingCurrentlyReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorSmokingFrequency" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpSmokingFrequencyReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorSmokingQuit" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpSmokingQuitReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrinking" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrinkingReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrinkingCurrently" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrinkingCurrentlyReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrinkingFrequency" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrinkingFrequencyReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrinkingAlcoholAbuse" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrinkingAlcoholAbuseReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrinkingQuit" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrinkingQuitReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrugPrescription" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrugPrescriptionReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrugPrescriptionCurrently" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrugPrescriptionCurrentlyReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrugPrescriptionQuit" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrugPrescriptionQuitReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrugRecreational" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrugRecreationalReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrugRecreationalCurrently" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrugRecreationalCurrentlyReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrugRecreationalQuit" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrugRecreationalQuitReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorDrugUseOther" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpDrugUseOtherReferrals">
            </asp:LinqDataSource>
            <asp:HiddenField ID="hfTabPanelSocialHistory" runat="server" Value="False" />
            <asp:HiddenField ID="hfPID" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfLanguage" runat="server" />
            <asp:HiddenField ID="hfLanguageText" runat="server" />
            <asp:HiddenField ID="hfPleaseEnter" runat="server" />
            <asp:HiddenField ID="hfIsInvalid" runat="server" />
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddSmoking" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddSmokingCurrently" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddSmokingFrequency" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddSmokingQuit" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrinking" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrinkingCurrently" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrinkingFrequency" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrinkingAlcoholAbuse" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrinkingQuit" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrugPrescription" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrugPrescriptionCurrently" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrugPrescriptionQuit" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrugRecreational" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrugRecreationalCurrently" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrugRecreationalQuit" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddDrugUseOther" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>

