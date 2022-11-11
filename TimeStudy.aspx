<%@ Page Title="Time Study" Language="VB" MasterPageFile="~/Pages/TimeStudyMP.master" AutoEventWireup="false" CodeFile="TimeStudy.aspx.vb" Inherits="Pages_TimeStudy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <script type="text/javascript">
        window.scrollTo = function (x, y) {
            return true;
        }

        function valNew(btn) {
            Page_ClientValidate("New");
            if (Page_IsValid) {
                return true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_GridViewTimeStudy_ctl01_ddPreTransplantType').hidden = true;
                document.getElementById('ctl00_ContentPlaceHolder1_GridViewTimeStudy_ctl01_ddPreTransplantType').hidden = false;
                return false;
            }
        }

        function valAdd(btn) {
            Page_ClientValidate("Add");
            if (Page_IsValid) {
                return true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_GridViewTimeStudy_ctl01_ddPreTransplantType').hidden = true;
                document.getElementById('ctl00_ContentPlaceHolder1_GridViewTimeStudy_ctl01_ddPreTransplantType').hidden = false;
                return false;
            }
        }

        function valEdit(btn) {
            Page_ClientValidate("Edit");
            if (Page_IsValid) {
                return true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_GridViewTimeStudy_ctl01_ddPreTransplantType').hidden = true;
                document.getElementById('ctl00_ContentPlaceHolder1_GridViewTimeStudy_ctl01_ddPreTransplantType').hidden = false;
                return false;
            }
        }

        function setTotalHoursEmpty(MySunday, MyMonday, MyTuesday, MyWednesday, MyThursday, MyFriday, MySaturday, MyTotalHours, e) {
            var MySunday = document.getElementById(MySunday);
            var MyMonday = document.getElementById(MyMonday);
            var MyTuesday = document.getElementById(MyTuesday);
            var MyWednesday = document.getElementById(MyWednesday);
            var MyThursday = document.getElementById(MyThursday);
            var MyFriday = document.getElementById(MyFriday);
            var MySaturday = document.getElementById(MySaturday);
            var MyTotalHours = document.getElementById(MyTotalHours);
            var TotalHours = 0;

            if (MySunday.value > 0) {
                TotalHours = TotalHours + Number(MySunday.value);
            }
            if (MyMonday.value > 0) {
                TotalHours = TotalHours + Number(MyMonday.value);
            }
            if (MyTuesday.value > 0) {
                TotalHours = TotalHours + Number(MyTuesday.value);
            }
            if (MyWednesday.value > 0) {
                TotalHours = TotalHours + Number(MyWednesday.value);
            }
            if (MyThursday.value > 0) {
                TotalHours = TotalHours + Number(MyThursday.value);
            }
            if (MyFriday.value > 0) {
                TotalHours = TotalHours + Number(MyFriday.value);
            }
            if (MySaturday.value > 0) {
                TotalHours = TotalHours + Number(MySaturday.value);
            }
            MyTotalHours.value = TotalHours;
        }

        function setTotalHours(MySunday, MyMonday, MyTuesday, MyWednesday, MyThursday, MyFriday, MySaturday, MyTotalHours, MySundayAdj, MyMondayAdj, MyTuesdayAdj, MyWednesdayAdj, MyThursdayAdj, MyFridayAdj, MySaturdayAdj, e) {
            var MySunday = document.getElementById(MySunday);
            var MyMonday = document.getElementById(MyMonday);
            var MyTuesday = document.getElementById(MyTuesday);
            var MyWednesday = document.getElementById(MyWednesday);
            var MyThursday = document.getElementById(MyThursday);
            var MyFriday = document.getElementById(MyFriday);
            var MySaturday = document.getElementById(MySaturday);
            var MyTotalHours = document.getElementById(MyTotalHours);
            var MySundayAdj = MySundayAdj;
            var MyMondayAdj = MyMondayAdj;
            var MyTuesdayAdj = MyTuesdayAdj;
            var MyWednesdayAdj = MyWednesdayAdj;
            var MyThursdayAdj = MyThursdayAdj;
            var MyFridayAdj = MyFridayAdj;
            var MySaturdayAdj = MySaturdayAdj;
            var TotalHours = 0;
           
            if (MySunday.value > 0) {
                TotalHours = TotalHours + Number(MySunday.value);
            }
            if (MyMonday.value > 0) {
                TotalHours = TotalHours + Number(MyMonday.value);
            }
            if (MyTuesday.value > 0) {
                TotalHours = TotalHours + Number(MyTuesday.value);
            }
            if (MyWednesday.value > 0) {
                TotalHours = TotalHours + Number(MyWednesday.value);
            }
            if (MyThursday.value > 0) {
                TotalHours = TotalHours + Number(MyThursday.value);
            }
            if (MyFriday.value > 0) {
                TotalHours = TotalHours + Number(MyFriday.value);
            }
            if (MySaturday.value > 0) {
                TotalHours = TotalHours + Number(MySaturday.value);
            }
            MyTotalHours.value = TotalHours;

            document.getElementById('<%= lbSundayTotalText.ClientID %>').innerHTML = Number(MySundayAdj) + Number(MySunday.value);
            document.getElementById('<%= lbMondayTotalText.ClientID %>').innerHTML = Number(MyMondayAdj) + Number(MyMonday.value);
            document.getElementById('<%= lbTuesdayTotalText.ClientID %>').innerHTML = Number(MyTuesdayAdj) + Number(MyTuesday.value);
            document.getElementById('<%= lbWednesdayTotalText.ClientID %>').innerHTML = Number(MyWednesdayAdj) + Number(MyWednesday.value);
            document.getElementById('<%= lbThursdayTotalText.ClientID %>').innerHTML = Number(MyThursdayAdj) + Number(MyThursday.value);
            document.getElementById('<%= lbFridayTotalText.ClientID %>').innerHTML = Number(MyFridayAdj) + Number(MyFriday.value);
            document.getElementById('<%= lbSaturdayTotalText.ClientID %>').innerHTML = Number(MySaturdayAdj) + Number(MySaturday.value);
            document.getElementById('<%= lbWeeklyTotalText.ClientID %>').innerHTML = Number(MySundayAdj) + Number(MySunday.value) + Number(MyMondayAdj) + Number(MyMonday.value)+ Number(MyTuesdayAdj) + Number(MyTuesday.value) + Number(MyWednesdayAdj) + Number(MyWednesday.value) + Number(MyThursdayAdj) + Number(MyThursday.value) + Number(MyFridayAdj) + Number(MyFriday.value) + Number(MySaturdayAdj) + Number(MySaturday.value);
        }   

        function setTotalHoursHeader(MySunday, MyMonday, MyTuesday, MyWednesday, MyThursday, MyFriday, MySaturday, MyTotalHours, MySundayTotal, MyMondayTotal, MyTuesdayTotal, MyWednesdayTotal, MyThursdayTotal, MyFridayTotal, MySaturdayTotal, e) {
            var MySunday = document.getElementById(MySunday);
            var MyMonday = document.getElementById(MyMonday);
            var MyTuesday = document.getElementById(MyTuesday);
            var MyWednesday = document.getElementById(MyWednesday);
            var MyThursday = document.getElementById(MyThursday);
            var MyFriday = document.getElementById(MyFriday);
            var MySaturday = document.getElementById(MySaturday);
            var MyTotalHours = document.getElementById(MyTotalHours);
            var MySundayTotal = MySundayTotal;
            var MyMondayTotal = MyMondayTotal;
            var MyTuesdayTotal = MyTuesdayTotal;
            var MyWednesdayTotal = MyWednesdayTotal;
            var MyThursdayTotal = MyThursdayTotal;
            var MyFridayTotal = MyFridayTotal;
            var MySaturdayTotal = MySaturdayTotal;
            var TotalHours = 0;
           
            if (MySunday.value > 0) {
                TotalHours = TotalHours + Number(MySunday.value);
            }
            if (MyMonday.value > 0) {
                TotalHours = TotalHours + Number(MyMonday.value);
            }
            if (MyTuesday.value > 0) {
                TotalHours = TotalHours + Number(MyTuesday.value);
            }
            if (MyWednesday.value > 0) {
                TotalHours = TotalHours + Number(MyWednesday.value);
            }
            if (MyThursday.value > 0) {
                TotalHours = TotalHours + Number(MyThursday.value);
            }
            if (MyFriday.value > 0) {
                TotalHours = TotalHours + Number(MyFriday.value);
            }
            if (MySaturday.value > 0) {
                TotalHours = TotalHours + Number(MySaturday.value);
            }
            MyTotalHours.value = TotalHours;

            document.getElementById('<%= lbSundayTotalText.ClientID %>').innerHTML = Number(MySundayTotal) + Number(MySunday.value);
            document.getElementById('<%= lbMondayTotalText.ClientID %>').innerHTML = Number(MyMondayTotal) + Number(MyMonday.value);
            document.getElementById('<%= lbTuesdayTotalText.ClientID %>').innerHTML = Number(MyTuesdayTotal) + Number(MyTuesday.value);
            document.getElementById('<%= lbWednesdayTotalText.ClientID %>').innerHTML = Number(MyWednesdayTotal) + Number(MyWednesday.value);
            document.getElementById('<%= lbThursdayTotalText.ClientID %>').innerHTML = Number(MyThursdayTotal) + Number(MyThursday.value);
            document.getElementById('<%= lbFridayTotalText.ClientID %>').innerHTML = Number(MyFridayTotal) + Number(MyFriday.value);
            document.getElementById('<%= lbSaturdayTotalText.ClientID %>').innerHTML = Number(MySaturdayTotal) + Number(MySaturday.value);
            document.getElementById('<%= lbWeeklyTotalText.ClientID %>').innerHTML = Number(MySundayTotal) + Number(MySunday.value) + Number(MyMondayTotal) + Number(MyMonday.value)+ Number(MyTuesdayTotal) + Number(MyTuesday.value) + Number(MyWednesdayTotal) + Number(MyWednesday.value) + Number(MyThursdayTotal) + Number(MyThursday.value) + Number(MyFridayTotal) + Number(MyFriday.value) + Number(MySaturdayTotal) + Number(MySaturday.value);
        }   

        function setMinutesToHours(MyMinutes, MyHours, e) {
            var MyMinutes = document.getElementById(MyMinutes);
            var MyHours = document.getElementById(MyHours);

            if (MyMinutes) {
                MyHours.value = (Number(MyMinutes.value) / 60).toFixed(2);
            }
        }

        function RestrictDecimal() {
			var charCode = event.keyCode;
            if ((charCode < 48 || charCode > 57) && charCode != 46) {
                event.returnValue = false;
                return false;
            }

        }

        function setSundayTotal(MySunday, MySundayTotal, MySundayEditTotal, MySundayText, e) {
            var MySunday = document.getElementById(MySunday);
            var MySundayTotal = document.getElementById(MySundayTotal);
            var MySundayEditTotal;
            var MySundayText; 
            var TotalHours = 0;

            TotalHours = Number(MySundayEditTotal) - Number(MySundayText);
            aler(TotalHours);
        }   
        
    </script>
    <asp:UpdatePanel ID="UpdatePanelTimeStudyMain" runat="server" ChildrenAsTriggers="True" UpdateMode="Conditional">
        <ContentTemplate>
            <br />
            <panel>
            </panel>
            <asp:Panel ID="PanelTimeStudyInfo" runat="server" Width="1024px" Height="140px" BackColor="#6E6E6E" class="body" BorderColor="LightGray" BorderWidth="1px" HorizontalAlign="Center" >
                <br />
                    <asp:Label ID="lbTimeStudyInfo" runat="server" ForeColor="White" Font-Size="Large" Width="450px" style="text-align: left;"></asp:Label>
            </asp:Panel>
            <br />
            <asp:Panel ID="PanelSelectStudyDate" runat="server" Width="1024px" Height="100px" BackColor="#F9F9F9" class="body" BorderColor="LightGray" BorderWidth="1px">
                <table width="1024px" height="100px">
                    <tr>
                        <th style="width: 55px; height: 40px">
                            <div align="center">
                                <asp:UpdateProgress ID="UpdateProgressStudyMain" runat="server" DisplayAfter="0">
                                    <ProgressTemplate>
                                        <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </th>
                        <th style="width: 260px;" align="left">
                            <table>
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSelectStudyDate" runat="server" Display="Dynamic"
                                            ControlToValidate="ddSelectStudyDate" Text="*" ForeColor="Red" Font-Size="X-Large" ValidationGroup="Date"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lbSelectStudyDate" runat="server" Text="Study Date:"></asp:Label><br />
                                        <asp:DropDownList ID="ddSelectStudyDate" runat="server" DataSourceID="LinqPreTransplantDate" ValidationGroup="Date"
                                            AppendDataBoundItems="True" DataTextField="PreTransplantDate"
                                            DataValueField="Id" ToolTip="Select a date to view the Time Study.">
                                            <asp:ListItem Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td valign="middle">
                                        <asp:Button ID="btnSelectStudyDate" runat="server" Text="View Time Study" OnClick="btnSelectStudyDate_Click"  
                                            ToolTip="View the Time Study." ValidationGroup="Date" />
                                
                                    </td>
                                </tr>
                            </table>
                        </th>
                        <th>
                            <asp:Label ID="lbPreTransplantTimeStudy" runat="server" Text="" Font-Size="Large" Font-Bold="true" 
                                ToolTip="View the Time Study Form."></asp:Label>
                        </th>
                        <th style="width: 315px;">&nbsp;
                        </th>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PanelTimeStudy" runat="server" Width="1024px" BackColor="#F9F9F9" class="body" Visible="false" BorderColor="LightGray" BorderWidth="1">
                <asp:UpdatePanel ID="UpdatePanelTimeStudy" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="1024px">
                            <tr>
                                <th style="width: 55px; height: 40px">
                                    <div align="center">
                                        <asp:UpdateProgress ID="UpdateProgressCancer" runat="server" DisplayAfter="0" 
                                            AssociatedUpdatePanelID="UpdatePanelTimeStudy">
                                            <ProgressTemplate>
                                                <img src="../Images/Update.gif" alt="" style="width: 25px; height: 25px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </th>
                                <th style="width:200px;" align="left">
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lbStudyDateText" runat="server" Text="Study Date:"></asp:Label>
                                                <asp:Label ID="lbStudyDate" runat="server"></asp:Label>
                                                &nbsp;
                                                <asp:Button ID="btnReport" runat="server" Text="View Form" OnClick="btnReport_Click" 
                                                    ToolTip="View the Time Study Form." />
                                            </td>
                                        </tr>
                                    </table>
                                </th>
                                <th>
                                    <asp:Label ID="lbTitle" runat="server" Text="" Font-Size="Large" Font-Bold="true" 
                                        ToolTip="View the Time Study Form."></asp:Label>
                                </th>
                                <th style="width:255px;">
                                    <table align="right">
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="lbConversionText1" runat="server" Text="Min"></asp:Label><br />
                                            </td>
                                            <td>
                                                <asp:Label ID="lbConversionText2" runat="server" Text="to"></asp:Label><br />
                                            </td>
                                            <td>
                                                <asp:Label ID="lbConversionText3" runat="server" Text="Hrs"></asp:Label><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbConversion" runat="server" Text="Conversion:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMinutes" runat="server" Width="40px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbConversionText4" runat="server" Text=" = "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHours" runat="server" Width="40px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </th>
                            </tr>
                        </table>
                        <asp:GridView ID="GridViewTimeStudy" runat="server" 
                            DataSourceID="LinqTimeStudy" DataKeyNames="Id, UserId" 
                            Font-Size="12px" Width="1024px" AutoGenerateColumns="False"
                            PageSize="15" CellPadding="3"
                            ForeColor="Black" GridLines="None" BorderWidth="0px" ShowHeader="True"
                            OnRowCommand="GridViewTimeStudy_RowCommand"
                            OnRowDataBound="GridViewTimeStudy_RowDataBound"
                            OnRowUpdating="GridViewTimeStudy_RowUpdating"
                            ShowFooter="False" EnableViewState="True">
                            <RowStyle BackColor="#f0f0f0" />
                            <EmptyDataTemplate>
                                <table cellpadding="3px" cellspacing="1px" width="970px">
                                    <tr align="center">
                                        <td style="text-align: center; width: 60px">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Insert" CommandName="New" OnClientClick="valNew(this);" />
                                        </td>
                                        <td style="text-align: center; width: 120px">
                                            <asp:Label ID="lbPreTransplantDateText" runat="server" Text="Week Of <br />Date:"></asp:Label><br />
                                            <asp:Label ID="lbPreTransplantDate" runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: center; width: 100px; vertical-align:bottom">
                                            <asp:Label ID="lbPreTransplantType" runat="server" Text="Study<br />Type:"></asp:Label><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPreTransplantType" runat="server" ErrorMessage="Please Select a Type!"
                                                ControlToValidate="ddPreTransplantType" CssClass="validator" ValidationGroup="New"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddPreTransplantType" runat="server" DataSourceID="LinqPreTransplantType"
                                                ValidationGroup="New" AppendDataBoundItems="True" DataTextField="PreTransplantType"
                                                DataValueField="Id" ToolTip="Select the Type." SelectedValue='<%# Bind("PreTransplantType") %>'>
                                                <asp:ListItem Value=""></asp:ListItem>
                                            </asp:DropDownList><br />
                                        </td>
                                        <td style="text-align: center; width: 80px">
                                            <asp:Label ID="lbSundayHours" runat="server" Text="Sunday <br />Hours:"></asp:Label>
                                            <asp:RangeValidator ID="RangeValidatorSundayHours" runat="server"
                                                ErrorMessage="Sunday Hours is Invalid!" ControlToValidate="txtSundayHours" Type="Double" CssClass="validator"
                                                SetFocusOnError="True" ValidationGroup="New" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                            <asp:TextBox ID="txtSundayHours" runat="server" Text='<%# Bind("SundayHours") %>' onkeypress="return RestrictDecimal()"
                                                MaxLength="5" Width="60px" ToolTip="Enter the hours for Sunday." ValidationGroup="New"></asp:TextBox>
                                        </td>
                                        <td style="text-align: center; width: 80px">
                                            <asp:Label ID="lbMondayHours" runat="server" Text="Monday <br />Hours:"></asp:Label><br />
                                            <asp:RangeValidator ID="RangeValidatorMondayHours" runat="server" CssClass="validator"
                                                ErrorMessage="Monday Hours is Invalid!" ControlToValidate="txtMondayHours" Type="Double"
                                                SetFocusOnError="True" ValidationGroup="New" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                            <asp:TextBox ID="txtMondayHours" runat="server" Text='<%# Bind("MondayHours") %>' onkeypress="return RestrictDecimal()"
                                                MaxLength="5" Width="60px" ToolTip="Enter the hours for Monday." ValidationGroup="New"></asp:TextBox><br />
                                        </td>
                                        <td style="text-align: center; width: 80px">
                                            <asp:Label ID="lbTuesdayHours" runat="server" Text="Tuesday <br />Hours:"></asp:Label><br />
                                            <asp:RangeValidator ID="RangeValidatorTuesdayHours" runat="server" CssClass="validator"
                                                ErrorMessage="Tuesday Hours is Invalid!" ControlToValidate="txtTuesdayHours" Type="Double"
                                                SetFocusOnError="True" ValidationGroup="New" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                            <asp:TextBox ID="txtTuesdayHours" runat="server" Text='<%# Bind("TuesdayHours") %>' onkeypress="return RestrictDecimal()"
                                                MaxLength="5" Width="60px" ToolTip="Enter the hours for Tuesday." ValidationGroup="New"></asp:TextBox><br />
                                        </td>
                                        <td style="text-align: center; width: 80px">
                                            <asp:Label ID="lbWednesdayHours" runat="server" Text="Wednesday <br />Hours:"></asp:Label><br />
                                            <asp:RangeValidator ID="RangeValidatorWednesdayHours" runat="server" CssClass="validator"
                                                ErrorMessage="Wednesday Hours is Invalid!" ControlToValidate="txtWednesdayHours" Type="Double"
                                                SetFocusOnError="True" ValidationGroup="New" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                            <asp:TextBox ID="txtWednesdayHours" runat="server" Text='<%# Bind("WednesdayHours") %>' onkeypress="return RestrictDecimal()"
                                                MaxLength="5" Width="60px" ToolTip="Enter the hours for Wednesday." ValidationGroup="New"></asp:TextBox><br />
                                        </td>
                                        <td style="text-align: center; width: 80px">
                                            <asp:Label ID="lbThursdayHours" runat="server" Text="Thursday <br />Hours:"></asp:Label><br />
                                            <asp:RangeValidator ID="RangeValidatorThursdayHours" runat="server" CssClass="validator"
                                                ErrorMessage="Thursday Hours is Invalid!" ControlToValidate="txtThursdayHours" Type="Double"
                                                SetFocusOnError="True" ValidationGroup="New" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                            <asp:TextBox ID="txtThursdayHours" runat="server" Text='<%# Bind("ThursdayHours") %>' onkeypress="return RestrictDecimal()"
                                                MaxLength="5" Width="60px" ToolTip="Enter the hours for Thursday." ValidationGroup="New"></asp:TextBox><br />
                                        </td>
                                        <td style="text-align: center; width: 80px">
                                            <asp:Label ID="lbFridayHours" runat="server" Text="Friday <br />Hours:"></asp:Label><br />
                                            <asp:RangeValidator ID="RangeValidatorFridayHours" runat="server" CssClass="validator"
                                                ErrorMessage="Friday Hours is Invalid!" ControlToValidate="txtFridayHours" Type="Double"
                                                SetFocusOnError="True" ValidationGroup="New" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                            <asp:TextBox ID="txtFridayHours" runat="server" Text='<%# Bind("FridayHours") %>' onkeypress="return RestrictDecimal()"
                                                MaxLength="5" Width="60px" ToolTip="Enter the hours for Friday." ValidationGroup="New"></asp:TextBox><br />
                                        </td>
                                        <td style="text-align: center; width: 80px">
                                            <asp:Label ID="lbSaturdayHours" runat="server" Text="Saturday <br />Hours:"></asp:Label><br />
                                            <asp:RangeValidator ID="RangeValidatorSaturdayHours" runat="server" CssClass="validator"
                                                ErrorMessage="Saturday Hours is Invalid!" ControlToValidate="txtSaturdayHours" Type="Double"
                                                SetFocusOnError="True" ValidationGroup="New" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                            <asp:TextBox ID="txtSaturdayHours" runat="server" Text='<%# Bind("SaturdayHours") %>' onkeypress="return RestrictDecimal()"
                                                MaxLength="5" Width="60px" ToolTip="Enter the hours for Saturday." ValidationGroup="New"></asp:TextBox><br />
                                        </td>
                                        <td style="text-align: center; width: 80px;">
                                            <asp:Label ID="lbTotalHours" runat="server" Text="Total <br />Hours:"></asp:Label><br />
                                            <asp:TextBox ID="txtTotalHoursText" runat="server" Text="" Width="60px" Enabled="false"></asp:TextBox><br />
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField ShowHeader="True" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" OnClientClick="valAdd(this);" Font-Size="Smaller"  />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/EditFile.png" CausesValidation="False"
                                            CommandName="Edit" ToolTip="Edit Information." Width="17px" Height="17px" />
                                        &nbsp;
                                        <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/DeleteFile.png" CausesValidation="False"
                                            CommandName="Delete" ToolTip="Delete Information." Width="17px" Height="17px"
                                            OnClientClick="return confirm('Are you sure you want to Delete this File?');" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/Images/SaveFile.gif" OnClientClick="valEdit(this);"
                                            CommandName="Update" ToolTip="Update Information." Width="17px"
                                            Height="17px" />
                                        &nbsp;
                                        <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/Images/CancelFile.gif"
                                            CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update." Width="17px"
                                            Height="17px" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <table cellpadding="3px" cellspacing="1px" width="900px">
                                            <tr>
                                                <td style="text-align:center; width: 120px">
                                                    <asp:Label ID="lbPreTransplantDateText" runat="server" Text="Week Of <br />Date:"></asp:Label><br />
                                                    <asp:Label ID="lbPreTransplantDate" runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 100px">
                                                    <asp:Label ID="lbPreTransplantType" runat="server" Text="Study<br />Type:"></asp:Label><br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPreTransplantType" runat="server" ErrorMessage="Please Select a Type!"
                                                        ControlToValidate="ddPreTransplantType" CssClass="validator" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                    <asp:DropDownList ID="ddPreTransplantType" runat="server" DataSourceID="LinqPreTransplantType" 
                                                        OnSelectedIndexChanged="CheckIfExists" AutoPostBack="true" 
                                                        ValidationGroup="Add" AppendDataBoundItems="True" DataTextField="PreTransplantType"
                                                        DataValueField="Id" ToolTip="Select the Type." SelectedValue='<%# Bind("PreTransplantType") %>'>
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                    </asp:DropDownList><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbSundayHours" runat="server" Text="Sunday Hours:"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidatorSundayHours" runat="server" 
                                                        ErrorMessage="Sunday Hours is Invalid!" ControlToValidate="txtSundayHours" Type="Double" CssClass="validator"
                                                        SetFocusOnError="True" ValidationGroup="Add" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtSundayHours" runat="server" Text='<%# Bind("SundayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Sunday." ValidationGroup="Add"></asp:TextBox>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbMondayHours" runat="server" Text="Monday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorMondayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Monday Hours is Invalid!" ControlToValidate="txtMondayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Add" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtMondayHours" runat="server" Text='<%# Bind("MondayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Monday." ValidationGroup="Add"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbTuesdayHours" runat="server" Text="Tuesday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorTuesdayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Tuesday Hours is Invalid!" ControlToValidate="txtTuesdayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Add" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtTuesdayHours" runat="server" Text='<%# Bind("TuesdayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Tuesday." ValidationGroup="Add"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbWednesdayHours" runat="server" Text="Wednesday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorWednesdayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Wednesday Hours is Invalid!" ControlToValidate="txtWednesdayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Add" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtWednesdayHours" runat="server" Text='<%# Bind("WednesdayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Wednesday." ValidationGroup="Add"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbThursdayHours" runat="server" Text="Thursday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorThursdayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Thursday Hours is Invalid!" ControlToValidate="txtThursdayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Add" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtThursdayHours" runat="server" Text='<%# Bind("ThursdayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Thursday." ValidationGroup="Add"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbFridayHours" runat="server" Text="Friday <br />Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorFridayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Friday Hours is Invalid!" ControlToValidate="txtFridayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Add" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtFridayHours" runat="server" Text='<%# Bind("FridayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Friday." ValidationGroup="Add"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbSaturdayHours" runat="server" Text="Saturday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorSaturdayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Saturday Hours is Invalid!" ControlToValidate="txtSaturdayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Add" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtSaturdayHours" runat="server" Text='<%# Bind("SaturdayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Saturday." ValidationGroup="Add"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px;">
                                                    <asp:Label ID="lbTotalHours" runat="server" Text="Total <br />Hours:"></asp:Label><br />
                                                    <asp:TextBox ID="txtTotalHoursText" runat="server" Width="60px" Enabled="false"></asp:TextBox><br />
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table cellpadding="3px" cellspacing="1px" width="900px">
                                            <tr>
                                                <td style="text-align:center; width: 120px">
                                                    <asp:Label ID="lbPreTransplantDateText" runat="server" Text="Week Of <br />Date:"></asp:Label><br />
                                                    <asp:Label ID="lbPreTransplantDate" runat="server" Text='<%# Bind("lkpPreTransplantDate.PreTransplantDate")%>' ></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 100px">
                                                    <asp:Label ID="lbPreTransplantType" runat="server" Text="Study<br />Type:"></asp:Label><br />
                                                    <asp:Label ID="lbPreTransplantTypeText" runat="server" Text='<%# Bind("lkpPreTransplantType.PreTransplantType")%>' ></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbSundayHours" runat="server" Text="Sunday Hours:"></asp:Label><br />
                                                    <asp:Label ID="lbSundayHoursText" runat="server" Text='<%# Bind("SundayHours") %>'></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbMondayHours" runat="server" Text="Monday Hours:"></asp:Label><br />
                                                    <asp:Label ID="lbMondayHoursText" runat="server" Text='<%# Bind("MondayHours") %>'></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbTuesdayHours" runat="server" Text="Tuesday Hours:"></asp:Label><br />
                                                    <asp:Label ID="lbTuesdayHoursText" runat="server" Text='<%# Bind("TuesdayHours") %>'></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbWednesdayHours" runat="server" Text="Wednesday Hours:"></asp:Label><br />
                                                    <asp:Label ID="lbWednesdayHoursText" runat="server" Text='<%# Bind("WednesdayHours") %>'></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbThursdayHours" runat="server" Text="Thursday Hours:"></asp:Label><br />
                                                    <asp:Label ID="lbThursdayHoursText" runat="server" Text='<%# Bind("ThursdayHours") %>'></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbFridayHours" runat="server" Text="Friday <br />Hours:"></asp:Label><br />
                                                    <asp:Label ID="lbFridayHoursText" runat="server" Text='<%# Bind("FridayHours") %>'></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbSaturdayHours" runat="server" Text="Saturday Hours:"></asp:Label><br />
                                                    <asp:Label ID="lbSaturdayHoursText" runat="server" Text='<%# Bind("SaturdayHours") %>'></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbTotalHours" runat="server" Text="Total <br />Hours:"></asp:Label><br />
                                                    <asp:Label ID="lbTotalHoursText" runat="server" Text='<%# Bind("TotalHours") %>'></asp:Label><br />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lbId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbUserId" runat="server" Text='<%# Bind("UserId") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbPreTransplantDateId" runat="server" Text='<%# Bind("PreTransplantDate")%>' Visible="false" ></asp:Label>
                                        <asp:Label ID="lbPreTransplantTypeId" runat="server" Text='<%# Bind("PreTransplantType")%>' Visible="false" ></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <table cellpadding="3px" cellspacing="1px" width="900px">
                                            <tr>
                                                <td style="text-align:center; width: 120px">
                                                    <asp:Label ID="lbPreTransplantDateText" runat="server" Text="Week Of <br />Date:"></asp:Label><br />
                                                     <asp:Label ID="lbPreTransplantDate" runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align:center; width: 100px">
                                                    <asp:Label ID="lbPreTransplantTypeText" runat="server" Text="Study<br />Type:"></asp:Label><br />
                                                    <asp:Label ID="lbPreTransplantType" runat="server" Text='<%# Bind("lkpPreTransplantType.PreTransplantType")%>'></asp:Label><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbSundayHours" runat="server" Text="Sunday Hours:"></asp:Label>
                                                    <asp:RangeValidator ID="RangeValidatorSundayHours" runat="server" 
                                                        ErrorMessage="Sunday Hours is Invalid!" ControlToValidate="txtSundayHours" Type="Double" CssClass="validator"
                                                        SetFocusOnError="True" ValidationGroup="Edit" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtSundayHours" runat="server" Text='<%# Bind("SundayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Sunday." ValidationGroup="Edit"></asp:TextBox>
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbMondayHours" runat="server" Text="Monday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorMondayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Monday Hours is Invalid!" ControlToValidate="txtMondayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Edit" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtMondayHours" runat="server" Text='<%# Bind("MondayHours") %>' onkeypress="return RestrictDecimal()" 
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Monday." ValidationGroup="Edit"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbTuesdayHours" runat="server" Text="Tuesday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorTuesdayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Tuesday Hours is Invalid!" ControlToValidate="txtTuesdayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Edit" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtTuesdayHours" runat="server" Text='<%# Bind("TuesdayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Tuesday." ValidationGroup="Edit"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbWednesdayHours" runat="server" Text="Wednesday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorWednesdayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Wednesday Hours is Invalid!" ControlToValidate="txtWednesdayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Edit" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtWednesdayHours" runat="server" Text='<%# Bind("WednesdayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Wednesday." ValidationGroup="Edit"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbThursdayHours" runat="server" Text="Thursday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorThursdayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Thursday Hours is Invalid!" ControlToValidate="txtThursdayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Edit" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtThursdayHours" runat="server" Text='<%# Bind("ThursdayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Thursday." ValidationGroup="Edit"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbFridayHours" runat="server" Text="Friday <br />Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorFridayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Friday Hours is Invalid!" ControlToValidate="txtFridayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Edit" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtFridayHours" runat="server" Text='<%# Bind("FridayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Friday." ValidationGroup="Edit"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbSaturdayHours" runat="server" Text="Saturday Hours:"></asp:Label><br />
                                                    <asp:RangeValidator ID="RangeValidatorSaturdayHours" runat="server" CssClass="validator"
                                                        ErrorMessage="Saturday Hours is Invalid!" ControlToValidate="txtSaturdayHours" Type="Double"
                                                        SetFocusOnError="True" ValidationGroup="Edit" MinimumValue="0.0" MaximumValue="24.00"></asp:RangeValidator>
                                                    <asp:TextBox ID="txtSaturdayHours" runat="server" Text='<%# Bind("SaturdayHours") %>' onkeypress="return RestrictDecimal()"
                                                        MaxLength="5" Width="60px" ToolTip="Enter the hours for Saturday." ValidationGroup="Edit"></asp:TextBox><br />
                                                </td>
                                                <td style="text-align:center; width: 80px">
                                                    <asp:Label ID="lbTotalHours" runat="server" Text="Total <br />Hours:"></asp:Label><br />
                                                    <asp:TextBox ID="txtTotalHoursText" runat="server" Width="60px" Enabled="false"></asp:TextBox><br />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lbId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbUserId" runat="server" Text='<%# Bind("UserId") %>' Visible="false"></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CheckBoxField DataField="Approved" HeaderText="Approved" SortExpression="Approved" Visible="False" />
                                <asp:BoundField DataField="EnterBy" HeaderText="EnterBy" SortExpression="EnterBy" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="EnterDate" HeaderText="EnterDate" ReadOnly="True" SortExpression="EnterDate" Visible="false" />
                                <asp:BoundField DataField="ModifyBy" HeaderText="ModifyBy" ReadOnly="True" SortExpression="ModifyBy" Visible="false" />
                                <asp:BoundField DataField="ModifyDate" HeaderText="ModifyDate" ReadOnly="True" SortExpression="ModifyDate" Visible="false" />
                                <asp:BoundField DataField="Version" HeaderText="Version" InsertVisible="False" SortExpression="Version" Visible="False" />
                            </Columns>
                            <EditRowStyle BackColor="Wheat" Font-Bold="True" />
                            <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="Black" BorderWidth="1px" />
                            <RowStyle HorizontalAlign="Center" BackColor="#f0f0f0" />
                            <AlternatingRowStyle BackColor="#F9F9F9" />
                        </asp:GridView>
                        <asp:Panel ID="panelTotals" runat="server" HorizontalAlign="Left">
                        <table bgcolor="Gray" width="1024px">
                            <tr>
                                <td style="text-align: center; width:325px;">&nbsp;
                                </td>
                                <td style="text-align: center; width: 80px">
                                    <asp:Label ID="lbSundayTotal" runat="server" Text="Total:"></asp:Label><br />
                                    <asp:Label ID="lbSundayTotalText" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center; width: 80px">
                                    <asp:Label ID="lbMondayTotal" runat="server" Text="Total:"></asp:Label><br />
                                    <asp:Label ID="lbMondayTotalText" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center; width: 80px">
                                    <asp:Label ID="lbTuesdayTotal" runat="server" Text="Total:"></asp:Label><br />
                                    <asp:Label ID="lbTuesdayTotalText" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center; width: 80px">
                                    <asp:Label ID="lbWednesdayTotal" runat="server" Text="Total:"></asp:Label><br />
                                    <asp:Label ID="lbWednesdayTotalText" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center; width: 80px">
                                    <asp:Label ID="lbThursdayTotal" runat="server" Text="Total:"></asp:Label><br />
                                    <asp:Label ID="lbThursdayTotalText" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center; width: 80px">
                                    <asp:Label ID="lbFridayTotal" runat="server" Text="Total:"></asp:Label><br />
                                    <asp:Label ID="lbFridayTotalText" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center; width: 80px">
                                    <asp:Label ID="lbSaturdayTotal" runat="server" Text="Total:"></asp:Label><br />
                                    <asp:Label ID="lbSaturdayTotalText" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center; width: 80px">
                                    <asp:Label ID="lbWeeklyTotal" runat="server" Text="Weekly <br />Total:"></asp:Label><br />
                                    <asp:Label ID="lbWeeklyTotalText" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center; width: 15px">&nbsp;</td>
                            </tr>
                        </table>
                        </asp:Panel>
                        <asp:ValidationSummary ID="ValSumTimeStudy" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                            HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="New" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                            HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="Add" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="true" ForeColor="Red"
                            HeaderText="Please Review/Answer the Question/Questions Listed Below:" ValidationGroup="Edit" />
                        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </asp:Panel>
            <asp:ValidationSummary ID="ValSum1" runat="server" ForeColor="Red"
                HeaderText="Please Select a Time Study Date!" ValidationGroup="Date" />
            <br />
            <asp:Button ID="btnSelectStudyDateBack" Text="Select Another Time Study Date" runat="server" Font-Size="Medium" 
                OnClick="btnSelectStudyDateBack_Click" Visible="false"
                ToolTip="Closes current time study to select another time study date." /> 
            <br />
            <asp:LinqDataSource ID="LinqTimeStudy" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" OrderBy="PreTransplantDate Descending"
                TableName="tblStaffTimeStudies" Where="UserId = Guid(@UserId) AND PreTransplantDate = Convert.ToInt32(@StudyDate)">
                <WhereParameters>
                    <asp:ControlParameter ControlID="hfLookUpUserId" Name="UserId" PropertyName="Value" Type="Object" />
                    <asp:ControlParameter ControlID="hfStudyDate" Name="StudyDate" PropertyName="Value" Type="Object" DefaultValue="1" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqPreTransplantType" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" OrderBy="Id" TableName="lkpPreTransplantTypes" Where="Active=True">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqPreTransplantDate" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" OrderBy="Id" TableName="lkpPreTransplantDates" Where="Active=True">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqPreTransplantDateReport" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EntityTypeName="" OrderBy="Id Descending" TableName="lkpPreTransplantDates">
            </asp:LinqDataSource>
            <asp:LinqDataSource ID="LinqTimeStudyLog" runat="server" ContextTypeName="MyPortfolioDbDataContext"
                EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
                TableName="tblTimeStudyLogs">
            </asp:LinqDataSource>
            <asp:HiddenField ID="hfUser" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfLookUpUserId" runat="server" />
            <asp:HiddenField ID="hfLookUpUserName" runat="server" />
            <asp:HiddenField ID="hfBack" runat="server" />
            <asp:HiddenField ID="hfFrom" runat="server" />
            <asp:HiddenField ID="hfStudyDate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
