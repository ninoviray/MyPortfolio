<%@ Control Language="VB" AutoEventWireup="false" CodeFile="HeightWeightBMI.ascx.vb" Inherits="Controls_HeightWeightBMI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="../Content/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
<script type="text/javascript" lang="javascript">

    window.scrollTo = function (x, y) {
        return true;
    };

    function setBMINew(MyHtCM, MyWtKG, MyHtFt, MyHtIN, MyWtLB, MyCal, e) {
        var MyHtCM = document.getElementById(MyHtCM);
        var MyWtKG = document.getElementById(MyWtKG);
        var MyHtFt = document.getElementById(MyHtFt);
        var MyHtIN = document.getElementById(MyHtIN);
        var MyWtLB = document.getElementById(MyWtLB);
        var MyCal = document.getElementById(MyCal);
        var CalCM = 0;
        var CalKG = 0;

        if (MyHtFt.value != '' && MyHtIN.value == '') {
            CalCM = ((Number(MyHtFt.value) * 12) / 0.39370);
        }

        if (MyHtFt.value != '' && MyHtIN.value != '') {
            CalCM = (((Number(MyHtFt.value) * 12) + Number(MyHtIN.value)) / 0.39370);
        }

        if (MyHtFt.value == '' && MyHtIN.value != '') {
            CalCM = (Number(MyHtIN.value) / 0.39370);
        }

        if (CalCM > 0) {
            MyHtCM.value = CalCM.toFixed(2);
        }
        else {
            MyHtCM.value = 0;
            CalCM.value = '';
        }

        if (MyWtLB.value != '') {
            CalKG = (Number(MyWtLB.value) / 2.2046);
            MyWtKG.value = CalKG.toFixed(2);
        }
        else {
            MyWtKG.value = 0;
            CalKG.value = '';
        }

        if (CalCM.value != '' && MyWtLB.value != '') {
            var CalBMI = (MyWtLB.value * 703) / (Number(CalCM) * 0.39370 * Number(CalCM) * 0.39370);
            if (CalBMI > 0) {
                MyCal.value = CalBMI.toFixed(2);
            }
            else {
                MyCal.value = '';
            }
        }
        else {
            MyCal.value = '';
        }
    }

</script>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanelHeightWeightBMI" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="PanelHeightWeightBMI" runat="server">
            <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
                <tr>
                    <td style="width: 48%; vertical-align: text-top;">
                        <asp:Label ID="lbHeightFeetText" runat="server" Text="" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtHeightFeet" runat="server" Text="" MaxLength="1" Width="40px" ValidationGroup="HeightWeightBMI" placeholder="#"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvHeightFeet" runat="server" ErrorMessage=""
                            ControlToValidate="txtHeightFeet" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="HeightWeightBMI"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvHeightFeet" runat="server" ErrorMessage="" Text="*" ForeColor="Red" Font-Size="X-Large"
                            ValidationGroup="HeightWeightBMI" SetFocusOnError="true" ControlToValidate="txtHeightFeet"
                            MaximumValue="8" MinimumValue="3" Type="Integer"></asp:RangeValidator>
                        &nbsp;
                        <asp:Label ID="lbHeightInchesText" runat="server" Text="" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtHeightInches" runat="server" Text="" MaxLength="2" Width="40px" ValidationGroup="HeightWeightBMI" placeholder="##"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvHeightInches" runat="server" ErrorMessage=""
                            ControlToValidate="txtHeightInches" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="HeightWeightBMI"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvHeightInches" runat="server" ErrorMessage="" Text="*" ForeColor="Red" Font-Size="X-Large"
                            ValidationGroup="HeightWeightBMI" SetFocusOnError="true" ControlToValidate="txtHeightInches"
                            MaximumValue="11" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                        <br />
                        <asp:Label ID="lbWeightPoundsText" runat="server" Text="wp" Width="120px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtWeightPounds" runat="server" Text="" MaxLength="3" Width="40px" ValidationGroup="HeightWeightBMI" placeholder="###"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvWeightPounds" runat="server" ErrorMessage=""
                            ControlToValidate="txtWeightPounds" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="HeightWeightBMI"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvWeightPounds" runat="server" ErrorMessage="" Text="*" ForeColor="Red" Font-Size="X-Large"
                            ValidationGroup="HeightWeightBMI" SetFocusOnError="true" ControlToValidate="txtWeightPounds"
                            MaximumValue="400" MinimumValue="50" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td style="width: 26%; vertical-align: text-top;">
                        <asp:Label ID="lbHeightCMText" runat="server" Text="hc" Width="100px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtHeightCM" runat="server" Text="" MaxLength="6" Width="50px" ValidationGroup="HeightWeightBMI"
                            placeholder="##.#" Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvHeightCM" runat="server" ErrorMessage="" ControlToValidate="txtHeightCM"
                            Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="HeightWeightBMI"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbWeightKGText" runat="server" Text="wk" Width="100px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtWeightKG" runat="server" Text="" MaxLength="6" Width="50px" ValidationGroup="HeightWeightBMI" placeholder="###.#"
                            Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvWeightKG" runat="server" ErrorMessage="" ControlToValidate="txtWeightKG"
                            Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="HeightWeightBMI"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 26%; vertical-align: text-top;">
                        <asp:Label ID="lbBMIText" runat="server" Text="" Width="80px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtBMI" runat="server" Text="" MaxLength="5" Width="50px" Enabled="False"
                            ForeColor="Blue" ValidationGroup="HeightWeightBMI"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBMI" runat="server" ErrorMessage=""
                            ControlToValidate="txtBMI" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="HeightWeightBMI" 
                            Enabled="false"></asp:RequiredFieldValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender10" runat="server" TargetControlID="txtBMI"
                            WatermarkCssClass="watermark" WatermarkText="Auto"></ajax:TextBoxWatermarkExtender>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hfTabPanelHeightWeightBMI" runat="server" Value="False" />
            <asp:HiddenField ID="hfPID" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfLanguage" runat="server" />
            <asp:HiddenField ID="hfLanguageText" runat="server" />
            <asp:HiddenField ID="hfPleaseEnter" runat="server" />
            <asp:HiddenField ID="hfIsInvalid" runat="server" />
            <asp:HiddenField ID="hfBMI" runat="server" />
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtHeightFeet" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtHeightInches" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtWeightPounds" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtHeightCM" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtWeightKG" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtBMI" EventName="TextChanged" />
    </Triggers>
</asp:UpdatePanel>

