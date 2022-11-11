<%@ Control Language="VB" AutoEventWireup="false" CodeFile="QuestionnaireCompletion.ascx.vb" Inherits="Controls_QuestionnaireCompletion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link href="../Content/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
<script type="text/javascript" lang="javascript">

    window.scrollTo = function (x, y) {
        return true;
    };

</script>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<asp:Panel ID="PanelQuestionnaireCompletion" runat="server">
    <table style="width: 100%; margin-left: auto; margin-right: auto;" border="0" class="body">
        <tr style="text-align: left">
            <td colspan="2">
                <asp:Label ID="lbCompletionText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Visible="false"></asp:Label>
                <asp:Label ID="lbRejectionText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lbCompletionPreviousNextText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Visible="false"></asp:Label>
                <asp:Label ID="lbRejectionPreviousNextText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lbCompletionCloseText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Visible="false"></asp:Label>
                <asp:Label ID="lbRejectionCloseText" runat="server" Text="" Font-Bold="True" Font-Size="Large" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview1a" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview1b" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview2a" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview2b" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview3a" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview3b" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview4a" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview4b" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview5a" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview5b" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview6a" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview6b" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview7a" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview7b" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table style="margin-left: auto; margin-right: auto; width: 960px;" border="0" class="body">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview8a" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 50%; vertical-align: top">
                <asp:Label ID="lbReview8b" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <table style="width: 100%; margin-left: auto; margin-right: auto;" border="0" class="body">
        <tr>
            <td style="width: 50%; vertical-align: text-top; text-align: left;">
                <asp:Label ID="lbSoftRejectionKidneyText" runat="server" Text="" Font-Bold="True"></asp:Label>
                <asp:Label ID="lbSoftRejectionKidney" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                <hr />
                <asp:Label ID="lbSoftRejectionLiverText" runat="server" Text="" Font-Bold="True"></asp:Label>
                <asp:Label ID="lbSoftRejectionLiver" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 50%; vertical-align: text-top; text-align: left;">
                <asp:Label ID="lbHardRejectionKidneyText" runat="server" Text="" Font-Bold="True"></asp:Label>
                <asp:Label ID="lbHardRejectionKidney" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
                <hr />
                <asp:Label ID="lbHardRejectionLiverText" runat="server" Text="" Font-Bold="True"></asp:Label>
                <asp:Label ID="lbHardRejectionLiver" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfTabPanelQuestionnaireCompletion" runat="server" Value="False" />
    <asp:HiddenField ID="hfPID" runat="server" />
    <asp:HiddenField ID="hfUserId" runat="server" />
    <asp:HiddenField ID="hfLanguage" runat="server" />
    <asp:HiddenField ID="hfLanguageText" runat="server" />
    <asp:HiddenField ID="hfPleaseEnter" runat="server" />
    <asp:HiddenField ID="hfIsInvalid" runat="server" />
    <asp:HiddenField ID="hfHardRejectionLiverText" runat="server" />
    <asp:HiddenField ID="hfHardRejectionLiver" runat="server" Value="False" />
    <asp:HiddenField ID="hfHardRejectionKidneyText" runat="server" />
    <asp:HiddenField ID="hfHardRejectionKidney" runat="server" Value="False" />
    <asp:HiddenField ID="hfSoftRejectionLiverText" runat="server" />
    <asp:HiddenField ID="hfSoftRejectionLiver" runat="server" Value="False" />
    <asp:HiddenField ID="hfSoftRejectionKidneyText" runat="server" />
    <asp:HiddenField ID="hfSoftRejectionKidney" runat="server" Value="False" />
    <asp:HiddenField ID="hfCompletionRejectionText" runat="server" />
</asp:Panel>
