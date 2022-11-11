<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Demographics.ascx.vb" Inherits="Controls_Demographics" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="../Content/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
<script type="text/javascript" lang="javascript">

    window.scrollTo = function (x, y) {
        return true;
    };

    function setDateOfBirth() {
        var txtrdob = document.getElementById('<%= txtDateOfBirth.ClientID %>');
        var rdob = "0";
        rdob = txtrdob.value;
        var keyrdob = event.key || event.keyCode;
        if (rdob.length > 1 && (rdob.length === 2 || rdob.length === 5) && (keyrdob != "Backspace")) {
            txtrdob.value += '/';
        }
    }

    function Age(birthday) {

        if (Page_ClientValidate("CkDOB")) {

            if (birthday.value !== '') {
                birthdayDate = new Date(birthday.value);
                dateNow = new Date();
                var years = dateNow.getFullYear() - birthdayDate.getFullYear();
                var months = dateNow.getMonth() - birthdayDate.getMonth();
                var days = dateNow.getDate() - birthdayDate.getDate();

                if (months < 0 || months === 0 && days < 0) {
                    years = parseInt(years) - 1;
                    months = parseInt(months) + 12;
                    document.getElementById('<%= txtAge.ClientID %>').value = years;
                    document.getElementById('<%= txtAgeMo.ClientID %>').value = months;
                }
                else {
                    document.getElementById('<%= txtAge.ClientID %>').value = years;
                    document.getElementById('<%= txtAgeMo.ClientID %>').value = months;
                }
            }
            else {
                document.getElementById('<%= txtAge.ClientID %>').value = '';
                document.getElementById('<%= txtAgeMo.ClientID %>').value = '';
            }
        }
        else {
            return false;
        }
    }

</script>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanelDemographics" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="PanelDemographics" runat="server">
            <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
                <tr>
                    <td style="width: 42%; vertical-align: text-top;">
                        <asp:Label ID="lbDateOfBirthText" runat="server" Text="" Width="140px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtDateOfBirth" runat="server" Text="" MaxLength="10" Width="80px" ValidationGroup="Demographics" 
                            onkeydown="setDateOfBirth();"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Demographics"></asp:RequiredFieldValidator>
                        <asp:Label ID="lbDateOfBirthErr" runat="server" Text="*" ForeColor="Red" Font-Size="X-Large" Visible="False"></asp:Label>
                        <asp:RangeValidator ID="rvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth" ValidationGroup="Demographics"
                            ErrorMessage="" Font-Size="X-Large" Type="Date" Text="*" ForeColor="Red"></asp:RangeValidator>
                        <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="txtDateOfBirth"
                            WatermarkCssClass="watermark" WatermarkText="mm/dd/yyyy"></ajax:TextBoxWatermarkExtender>
                        <br />
                        <asp:Label ID="lbAgeText" runat="server" Text="" Width="140px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtAge" runat="server" Text="" MaxLength="3" Width="30px" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbYearText" runat="server" Text="" Width="40px" Style="text-align: left"></asp:Label>
                        <asp:TextBox ID="txtAgeMo" runat="server" Text="" MaxLength="2" Width="30px" Enabled="False"></asp:TextBox>
                        <asp:Label ID="lbMonthText" runat="server" Text="" Width="40px" Style="text-align: left"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Demographics"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbGenderText" runat="server" Text="" Width="140px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddGender" runat="server" ValidationGroup="Demographics" AppendDataBoundItems="True" Width="100px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="ddGender"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Demographics"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbEthnicityText" runat="server" Text="" Width="140px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddEthnicity" runat="server" ValidationGroup="Demographics" AppendDataBoundItems="True" Width="200px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEthnicity" runat="server" ControlToValidate="ddEthnicity"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Demographics"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbLanguageText" runat="server" Text="" Width="140px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddLanguage" runat="server" ValidationGroup="Demographics" AppendDataBoundItems="True" Width="200px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="ddLanguage"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Demographics"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 58%; vertical-align: text-top;">
                        <asp:Label ID="lbMaritalText" runat="server" Text="" Width="180px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddMarital" runat="server" ValidationGroup="Demographics" AppendDataBoundItems="True" Width="200px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMarital" runat="server" ControlToValidate="ddMarital"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Demographics"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbReligionText" runat="server" Text="" Width="180px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddReligion" runat="server" ValidationGroup="Demographics" AppendDataBoundItems="True" Width="240px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvReligion" runat="server" ControlToValidate="ddReligion"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Demographics"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbResidencyText" runat="server" Text="" Width="180px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddResidency" runat="server" ValidationGroup="Demographics" AppendDataBoundItems="True" Width="200px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvResidency" runat="server" ControlToValidate="ddResidency"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Demographics"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lbHighestLevelOfEducationText" runat="server" Text="" Width="180px" Style="text-align: right" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="ddHighestLevelOfEducation" runat="server" ValidationGroup="Demographics" AppendDataBoundItems="True" Width="240px">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvHighestLevelOfEducation" runat="server" ControlToValidate="ddHighestLevelOfEducation"
                            ErrorMessage="" Font-Size="X-Large" Text="*" ForeColor="Red"
                            ValidationGroup="Demographics"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:LinqDataSource ID="LinqDonorGender" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpGenderReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorEthnicity" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpEthnicityReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorLanguage" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpLanguageReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorMarital" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpMaritalReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorReligion" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpReligionReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorResidency" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpResidencyReferrals">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqDonorHighestLevelOfEducation" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                TableName="lkpUNOSHLOEducationReferrals">
            </asp:LinqDataSource>
            <asp:HiddenField ID="hfTabPanelDemographics" runat="server" Value="False" />
            <asp:HiddenField ID="hfPID" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfLanguage" runat="server" />
            <asp:HiddenField ID="hfLanguageText" runat="server" />
            <asp:HiddenField ID="hfPleaseEnter" runat="server" />
            <asp:HiddenField ID="hfIsInvalid" runat="server" />
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtDateOfBirth" EventName="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddGender" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddEthnicity" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddLanguage" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddMarital" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddReligion" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddResidency" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddHighestLevelOfEducation" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>

