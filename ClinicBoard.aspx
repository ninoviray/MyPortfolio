<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ClinicBoard.aspx.vb" Inherits="Pages_ClinicBoard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> Clinical Board</title>
    <link href="../CSS/StyleSheet.css" rel="Stylesheet" type="text/css" media="all" />
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="Timer1" runat="server" Interval="21500" OnTick="Timer1_Tick">
        </asp:Timer>
        <asp:Timer ID="Timer2" runat="server" Interval="500" OnTick="Timer2_Tick" Enabled="false">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="margin-left: auto; margin-right: auto;" width="980px" border="0">
                    <tr>
                        <th align="center">
                            <asp:Label ID="lbClinicType" runat="server" Text="Clinical Board" Font-Size="20pt"></asp:Label>
                        </th>
                    </tr>
                </table>
                <asp:Panel ID="PanelCalendar" runat="server" Width="640px" BackColor="#B7CEEC">
                    <table style="margin-left: auto; margin-right: auto;" width="620px" border="0" cellspacing="0">
                        <tr align="center">
                            <td width="30px">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                                    <ProgressTemplate>
                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td>
                                <br />
                                <span class="styleSDtS"><b>Select a Date to View the Clinic Board&nbsp;<asp:Label
                                    ID="lbPatientType" runat="server" Text=""></asp:Label></b></span>
                                <br />
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Calendar ID="Calendar1" runat="server" Height="400px" Width="600px" BackColor="#FFEBCD"
                                    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                                    NextPrevFormat="FullMonth">
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                        Font-Size="12pt" ForeColor="#333399" />
                                </asp:Calendar>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">&nbsp; </td>
                        </tr>
                    </table>
                    <br />
                </asp:Panel>
                <asp:Panel ID="PanelBoardMorning" runat="server" Width="100%" Height="100%" Visible="false">
                    <asp:Table ID="TableBoardMorning" runat="server" BorderWidth="3" CellPadding="10"
                        CellSpacing="10" GridLines="Both" HorizontalAlign="Center" Visible="true" Width="100%"
                        Height="100%">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" ColumnSpan="10" BackColor="#ADD8E6">
                                <asp:Label ID="lable1" runat="server" Text="Morning Board: " Font-Bold="true" Font-Size="Larger" />
                                <asp:Label ID="LabelDate" runat="server" Font-Bold="true" Font-Size="Larger" />
                                <br />
                                <span style="float: right; color: Red">
                                    <asp:Label ID="NotReady" runat="server" Font-Bold="true" Font-Size="14" />
                                </span>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow BackColor="#2C3539" ForeColor="#FFFFFF">
                            <asp:TableCell HorizontalAlign="Center" Font-Size="14">
                            Room #
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                            Patient Name
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader1" runat="server" Width="300px" AutoPostBack="true" 
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader1" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader1" runat="server" Text="PA" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader1" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader2" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader2" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader2" runat="server" Text="Hepatology" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader2" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader3" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader3" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader3" runat="server" Text="Med/Onc" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader3" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader4" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader4" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader4" runat="server" Text="Social Work" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader4" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader5" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader5" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader5" runat="server" Text="Dietitian" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader5" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader6" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader6" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader6" runat="server" Text="Lab" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader6" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader7" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader7" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader7" runat="server" Text="Imaging" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader7" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader8" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader8" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader8" runat="server" Text="Notes" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader8" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom1" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom1" runat="server" Text="1" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom1" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom1" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone1" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat1" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat1" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#E5E4E2" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat1" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat1" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM11" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM11" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM11" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM11" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton11" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM12" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM12" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM12" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM12" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton12" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM13" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM13" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM13" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM13" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM14" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM14" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM14" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM14" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM15" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM15" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM15" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM15" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton15" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM16" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM16" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="Label1" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM16" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton16" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM17" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM17" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM17" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM17" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton17" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox1" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button1" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link1" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink1" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom2" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom2" runat="server" Text="2" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom2" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom2" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone2" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat2" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat2" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat2" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat2" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM21" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM21" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM21" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM21" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton21" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM22" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM22" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM22" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM22" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton22" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM23" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM23" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM23" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM23" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton23" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM24" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM24" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM24" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM24" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton24" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM25" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM25" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM25" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM25" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton25" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM26" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM26" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM26" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM26" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton26" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM27" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM27" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM27" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM27" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton27" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox2" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button2" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link2" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink2" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom3" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom3" runat="server" Text="3" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom3" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom3" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone3" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat3" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat3" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat3" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat3" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM31" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM31" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM31" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM31" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton31" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM32" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM32" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM32" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM32" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton32" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM33" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM33" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM33" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM33" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton33" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM34" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM34" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM34" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM34" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton34" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM35" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM35" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM35" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM35" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton35" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM36" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM36" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM36" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM36" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton36" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM37" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM37" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM37" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM37" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton37" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox3" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button3" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link3" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink3" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom4" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom4" runat="server" Text="4" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom4" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom4" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone4" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat4" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat4" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat4" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat4" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM41" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM41" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM41" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM41" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton41" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM42" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM42" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM42" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM42" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton42" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM43" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM43" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM43" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM43" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton43" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM44" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM44" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM44" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM44" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton44" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM45" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM45" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM45" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM45" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton45" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM46" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM46" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM46" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM46" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton46" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM47" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM47" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM47" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM47" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton47" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox4" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button4" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link4" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink4" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom5" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom5" runat="server" Text="5" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom5" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom5" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone5" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat5" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat5" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat5" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat5" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM51" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM51" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM51" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM51" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton51" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM52" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM52" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM52" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM52" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton52" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM53" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM53" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM53" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM53" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton53" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM54" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM54" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM54" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM54" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton54" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM55" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM55" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM55" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM55" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton55" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM56" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM56" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM56" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM56" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton56" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM57" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM57" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM57" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM57" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton57" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox5" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button5" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link5" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink5" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom6" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom6" runat="server" Text="6" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom6" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom6" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone6" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat6" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat6" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat6" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat6" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM61" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM61" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM61" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM61" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton61" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM62" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM62" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM62" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM62" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton62" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM63" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM63" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM63" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM63" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton63" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM64" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM64" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM64" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM64" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton64" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM65" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM65" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM65" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM65" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton65" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM66" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM66" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM66" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM66" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton66" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM67" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM67" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM67" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM67" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton67" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox6" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button6" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link6" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink6" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom7" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom7" runat="server" Text="7" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom7" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom7" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone7" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat7" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat7" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat7" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat7" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM71" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM71" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM71" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM71" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton71" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM72" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM72" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM72" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM72" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton72" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM73" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM73" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM73" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM73" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton73" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM74" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM74" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM74" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM74" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton74" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM75" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM75" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM75" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM75" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton75" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM76" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM76" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM76" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM76" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton76" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM77" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM77" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM77" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM77" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton77" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox7" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button7" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link7" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink7" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom8" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom8" runat="server" Text="8" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom8" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom8" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone8" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat8" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat8" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat8" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat8" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM81" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM81" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM81" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM81" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton81" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM82" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM82" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM82" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM82" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton82" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM83" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM83" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM83" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM83" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton83" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM84" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM84" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM84" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM84" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton84" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM85" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM85" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM85" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM85" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton85" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM86" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM86" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM86" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM86" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton86" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxM87" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonM87" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#1E90FF" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelM87" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonM87" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton87" runat="server" ImageUrl="~/Images/clear.png"
                                OnCommand="Change_Command" CommandName="15" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox8" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button8" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link8" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink8" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" ColumnSpan="10" BackColor="#ADD8E6">
                                <div style="float: Left; color: black">
                                    <asp:Button ID="UpdateNow" runat="server" Text="Update Now" Visible="True" OnClick="btnUpdateNow"
                                        CausesValidation="False" UseSubmitBehavior="False" />
                                    &nbsp &nbsp
                                    <asp:Label ID="TimerLabelText1" runat="server" Font-Bold="true" Font-Size="Medium" />
                                    <asp:Label ID="TimerLabel1" runat="server" Font-Bold="true" Font-Size="Medium" Text="" />
                                </div>
                                <div style="float: right; color: black">
                                    <asp:Button ID="btnReturnM" runat="server" Text="Return to Calendar" Visible="false"
                                        OnClick="btnReturn_Click" CausesValidation="False" UseSubmitBehavior="False" />
                                </div>
                                <br />
                                <div style="text-align: center;">
                                    <div style="width: 500px; margin: 0 auto; color: black;">
                                        <asp:Button ID="btnAfternoon" runat="server" Text="View Afternoon Board" Visible="false"
                                            OnClick="btnAfternoon_Click" CausesValidation="False" UseSubmitBehavior="False" />
                                    </div>
                                </div>
                                <br />
                            </asp:TableCell></asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                                                HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="ValMorning" />
                </asp:Panel>
                <!--New Panel for Afternoon-->
                <asp:Panel ID="PanelBoardAfternoon" runat="server" Width="100%" Visible="false" Height="100%">
                    <asp:Table ID="TableBoardAfternoon" runat="server" CellPadding="10" GridLines="Both"
                        BorderWidth="3" HorizontalAlign="Center" Visible="false" Width="100%" Height="100%">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" ColumnSpan="9" BackColor="#FFE87C">
                                <asp:Label ID="Label1a" runat="server" Text="Afternoon Board: " Font-Bold="true"
                                    Font-Size="Larger" />
                                <asp:Label ID="LabelDatea" runat="server" Font-Bold="true" Font-Size="Larger" />
                                <br />
                                <span style="float: right; color: Red">
                                    <asp:Label ID="notreadya" runat="server" Font-Bold="true" Font-Size="14" />
                                </span>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow BackColor="#2C3539" ForeColor="#FFFFFF">
                            <asp:TableCell HorizontalAlign="Center" Font-Size="14">
                            Room #
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                            Patient Name
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader1a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader1a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader1a" runat="server" Text="PA" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader1a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader2a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader2a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader2a" runat="server" Text="Surgeon" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader2a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader3a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader3a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader3a" runat="server" Text="IR" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader3a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader4a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader4a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader4a" runat="server" Text="Dietitian" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader4a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader5a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader5a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader5a" runat="server" Text="SW" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader5a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader6a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader6a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader6a" runat="server" Text="Med/Onc" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader6a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Font-Size="14">
                                <asp:TextBox ID="TextBoxHeader7a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" Rows="4" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonHeader7a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="White" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelHeader7a" runat="server" Text="Notes" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonHeader7a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom1a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom1a" runat="server" Text="1" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom1a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom1a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone1a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat1a" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat1a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat1a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat1a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA11" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA11" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA11" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA11" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton11a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA12" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA12" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA12" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA12" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton12a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA13" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA13" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA13" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA13" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton13a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA14" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA14" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA14" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA14" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton14a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA15" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA15" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA15" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA15" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton15a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA16" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA16" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA16" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA16" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton16a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox1a" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button1a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link1a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink1a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom2a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom2a" runat="server" Text="2" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom2a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom2a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone2a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat2a" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat2a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat2a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat2a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA21" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA21" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA21" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA21" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton21a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA22" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA22" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA22" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA22" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton22a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA23" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA23" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA23" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA23" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton23a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA24" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA24" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA24" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA24" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton24a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA25" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA25" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA25" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA25" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton25a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA26" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA26" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA26" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA26" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton26a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox2a" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button2a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link2a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink2a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom3a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom3a" runat="server" Text="3" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom3a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom3a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone3a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat3a" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat3a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat3a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat3a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA31" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA31" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA31" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA31" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton31a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA32" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA32" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA32" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA32" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton32a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA33" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA33" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA33" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA33" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton33a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA34" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA34" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA34" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA34" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton34a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA35" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA35" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA35" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA35" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton35a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA36" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA36" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA36" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA36" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton36a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox3a" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button3a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link3a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink3a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom4a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom4a" runat="server" Text="4" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom4a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom4a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone4a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat4a" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat4a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat4a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat4a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA41" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA41" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA41" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA41" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton41a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA42" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA42" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA42" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA42" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton42a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA43" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA43" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA43" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA43" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton43a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA44" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA44" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA44" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA44" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton44a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA45" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA45" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA45" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA45" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton45a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA46" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA46" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA46" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA46" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton46a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox4a" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button4a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link4a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink4a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom5a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom5a" runat="server" Text="5" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom5a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom5a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone5a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat5a" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat5a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat5a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat5a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA51" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA51" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA51" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA51" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton51a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA52" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA52" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA52" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA52" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton52a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA53" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA53" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA53" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA53" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton53a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA54" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA54" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA54" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA54" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton54a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA55" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA55" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA55" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA55" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton55a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA56" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA56" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA56" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA56" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton56a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox5a" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button5a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link5a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink5a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom6a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom6a" runat="server" Text="6" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom6a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom6a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone6a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat6a" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat6a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat6a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat6a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA61" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA61" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA61" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA61" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton61a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA62" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA62" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA62" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA62" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton62a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA63" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA63" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA63" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA63" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton63a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA64" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA64" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA64" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA64" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton64a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA65" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA65" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA65" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA65" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton65a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA66" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA66" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA66" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA66" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton66a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox6a" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button6a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link6a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink6a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom7a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom7a" runat="server" Text="7" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom7a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom7a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone7a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat7a" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat7a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat7a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat7a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA71" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA71" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA71" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA71" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton71a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA72" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA72" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA72" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA72" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton72a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA73" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA73" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA73" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA73" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton73a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA74" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA74" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA74" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA74" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton74a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA75" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA75" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA75" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA75" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton75a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA76" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA76" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA76" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA76" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton76a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox7a" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button7a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link7a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink7a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18">
                                <asp:LinkButton ID="LinkButtonRoom8a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelRoom8a" runat="server" Text="8" />
                                </asp:LinkButton>
                                <asp:TextBox ID="TextBoxRoom8a" runat="server" Width="300px" AutoPostBack="true"
                                    Enabled="true" TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <br />
                                <asp:Button ID="ButtonRoom8a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="LinkButtonDone8a" runat="server" Visible="true" Font="Ariel"
                                    Font-Underline="false" ForeColor="Blue" Text="Close" Font-Size="Small" OnCommand="Room_Command"></asp:LinkButton>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxPat8a" runat="server" Width="300px" AutoPostBack="true" Enabled="true"
                                    TextMode="SingleLine" Rows="2" OnTextChanged="TextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkPat8a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLinkPat8a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                                <br />
                                <asp:Button ID="ButtonPat8a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA81" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA81" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA81" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA81" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton81a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="11" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA82" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA82" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA82" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA82" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="Imagebutton82a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="12" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA83" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA83" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA83" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA83" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton83a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="13" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA84" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA84" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA84" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA84" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton84a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA85" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA85" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA85" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA85" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton85a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:TextBox ID="TextBoxA86" runat="server" Width="100px" AutoPostBack="true" Enabled="true"
                                    Rows="4" OnTextChanged="ImgBtnTextChanged" Visible="false" />
                                <asp:LinkButton ID="LinkButtonA86" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="#D2691E" OnCommand="ImgBtnText_Command">
                                    <asp:Label ID="LabelA86" runat="server" Text="Add Note" />
                                </asp:LinkButton>
                                <asp:Button ID="ButtonA86" runat="server" Text="Save" Visible="false" OnCommand="ImgBtnTextChanged" />
                                <br />
                                <asp:ImageButton ID="ImageButton86a" runat="server" ImageUrl="~/Images/nottobeseen.png"
                                OnCommand="Change_Command" CommandName="14" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:TextBox ID="TextBox8a" runat="server" Width="500px" AutoPostBack="true" Enabled="true"
                                    Rows="6" MaxLength="500" OnTextChanged="TextChanged" TextMode="MultiLine" Visible="false" />
                                &nbsp
                                <asp:Button ID="Button8a" runat="server" Text="Save" Visible="false" OnCommand="TextChanged" />
                                <asp:LinkButton ID="Link8a" runat="server" Visible="true" Font="Ariel" Font-Underline="false"
                                    ForeColor="Black" OnCommand="Notes_Command">
                                    <asp:Label ID="LabelLink8a" runat="server" Text="Click to Edit" />
                                </asp:LinkButton>
                            </asp:TableCell></asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" ColumnSpan="9" BackColor="#FFE87C">
                                <div style="float: Left; color: black">
                                    <asp:Button ID="UpdateNow2" runat="server" Text="Update Now" Visible="True" OnClick="btnUpdateNow"
                                        CausesValidation="False" UseSubmitBehavior="False" />
                                    &nbsp &nbsp
                                    <asp:Label ID="TimerLabelText2" runat="server" Font-Bold="true" Font-Size="Medium" />
                                    <asp:Label ID="TimerLabel2" runat="server" Font-Bold="true" Font-Size="Medium" Text="" />
                                </div>
                                <div style="float: right; color: black">
                                    <asp:Button ID="btnReturnA" runat="server" Text="Return to Calendar" Visible="True"
                                        OnClick="btnReturn_Click" CausesValidation="False" UseSubmitBehavior="False" />
                                </div>
                                <br />
                                <div style="text-align: center;">
                                    <div style="width: 500px; margin: 0 auto; color: black;">
                                        <asp:Button ID="btnMorning" runat="server" Text="View Morning Board" Visible="false"
                                            OnClick="btnMorning_Click" CausesValidation="False" UseSubmitBehavior="False" />
                                    </div>
                                </div>
                                <br />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                </asp:Panel>
                <asp:LinqDataSource ID="LinqClinic" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                    EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
                    OrderBy="ClinicDate" TableName="tblClinics">
                </asp:LinqDataSource>
                <asp:HiddenField ID="hfUserName" runat="server" />
                <asp:HiddenField ID="hfUserId" runat="server" />
                <asp:HiddenField ID="hfBack" runat="server" />
                <asp:HiddenField ID="hfFrom" runat="server" />
                <asp:HiddenField ID="hfPatientType" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxHeader1" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonHeader1" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonHeader1" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxHeader2" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonHeader2" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonHeader2" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxHeader3" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonHeader3" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonHeader3" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxHeader4" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonHeader4" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonHeader4" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxHeader5" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonHeader5" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonHeader5" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxHeader6" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonHeader6" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonHeader6" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxHeader7" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonHeader7" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonHeader7" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxHeader8" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonHeader8" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonHeader8" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonRoom1" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxPat1" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkPat1" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonPat1" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxM11" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonM11" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonM11" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Imagebutton11" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxM12" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonM12" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonM12" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Imagebutton12" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxM13" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonM13" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonM13" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Imagebutton13" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxM14" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonM14" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonM14" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Imagebutton14" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxM15" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonM15" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonM15" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Imagebutton15" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxM16" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonM16" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonM16" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Imagebutton16" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBoxM17" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonM17" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonM17" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Imagebutton17" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="TextBox1" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="Link1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </form>
    </center>
    <script type="text/javascript" language="javascript">

        var panel = document.getElementById('<%= PanelBoardMorning.ClientID %>');
        if (panel) {
            var count = 21;
            var counter = setInterval(timer, 1000); //1000 will  run it every 1 second
            function timer() {
                var panelloop = document.getElementById('<%= PanelBoardMorning.ClientID %>');
                if (panelloop) {
                    count = count - 1;
                    if (count < 0) {
                        clearInterval(counter);
                        return;
                    }
                    document.getElementById("TimerLabel1").innerHTML = "Next Update in . . . " + count + " seconds"; // watch for spelling
                }
            }
        }
        else {
        }

        var panela = document.getElementById('<%= PanelBoardAfternoon.ClientID %>');
        if (panela) {
            var count = 21;
            var counter = setInterval(timer, 1000); //1000 will  run it every 1 second
            function timer() {
                var panelloopa = document.getElementById('<%= PanelBoardAfternoon.ClientID %>');
                if (panelloopa) {
                    count = count - 1;
                    if (count < 0) {
                        clearInterval(counter);
                        return;
                    }
                    document.getElementById("TimerLabel2").innerHTML = "Next Update in . . . " + count + " seconds"; // watch for spelling
                }
            }
        }
        else {
        }
        
    </script>
</body>
</html>
