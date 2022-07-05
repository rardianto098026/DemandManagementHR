<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListEdit_Employee.aspx.vb" Inherits="DemandManagementHR.ListEdit_Employee" %>
<%@ Register TagName="My" TagPrefix="Menu" Src="Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="~/Menu/Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript">

    function openWindow(idx) {
        // Note: you cannot use ~/ at client side.
        var url = "Frm_Edit.aspx?idx=" + idx.toString();
        window.open(url, "", "titlebar=no'");
    }

</script>

<script type="text/javascript">
    function EnterKeyDown(event) {
        var keycode = (event.which) ? event.which : event.keyCode;
        //debugger;
        if (keycode == 13) {
            debugger;
            //document.getElementById("lblENTER").value() = "CLICK";
            $('#lblENTER').val("CLICK");
            var enter = document.getElementById("lblENTER").val();
            var enter2 = document.getElementById("lblENTER").value();
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title> 
    <link href="css/Surrounding.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" href="css/jquery-ui.css" />
<link rel="stylesheet" href="css/style.css" />
<script type="text/javascript" src="js/jquery-1.10.2.js"></script>
<script type="text/javascript" src="js/jquery-ui.js"></script>
<link rel="stylesheet" href="css/style.css" />
  <link rel="shortcut icon" href="Images/icon.ico" />
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
  
<%--<script type="text/javascript">
    function openWindowedit(idx) {
        debugger;
        // Note: you cannot use ~/ at client side.
        var url = "Frm_Insert.aspx?idx=" + idx.toString();
        var session = "Edit_MST"
        '<% Session("Command") =  "Edit_MST" %>' ;

        window.open(url, "", "width=1800,height=1600,titlebar=no'");
    }
 </script>--%>
</head>
<body onbeforeUnload="bodyUnload();" onclick="clicked=true;" oncontextmenu="return false">
    <form id="form1" runat="server">
    <div>
         <table width="1200px" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td background="Images/borderleft.gif" width="21">
                </td>
                <td align="center">
                 <Head:My ID="head" runat="server" />
                 </td>
                <td background="Images/borderRight.gif" width="21">
                </td>
            </tr>
            <tr>
                 <td width="21px" background="Images/borderleft.gif">
                    </td>
                    <td align="left" bgcolor="#0055AA">
                        <Menu:My ID="My1" runat="Server" />
                    </td>
                    <td width="21px" background="Images/borderRight.gif">
                    </td>
            </tr>
            
              
             </table>
        <asp:Label runat="server" Visible="false" ID="lblENTER" autopostback="true"></asp:Label>
              <br /> 
               <h1 align="center"> List Employee <asp:Label ID="lblupdate" runat="server"></asp:Label></h1>
            <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td background="Images/borderleft.gif" width="21" style="height: 13px">
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                       
                                           <td align ="left" height="20px">
                                            SEARCH 
                                            </td>
                                      
                                    </tr>
            
                                   <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="ChkEmplID" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                            Employee ID <asp:Label ID="lblEmplID1" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="txtEmplID" runat="server" CssClass="textbox" Width ="145px" AutoPostBack="true" onkeydown="EnterKeyDown(event)"></asp:TextBox>
                                            &nbsp; <asp:Label ID="lblEmplID2" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align ="right">
                                            <asp:CheckBox ID="ChkName" runat="server" Text="" TextAlign="left" />
                                        </td>
                                        <td align ="left" height="20px" class="style2">
                                          Employee Name <asp:Label ID="lblempname" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                         <td align ="left" width="10px">
                                            :
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox" Width ="145px" AutoPostBack="true" onkeydown="EnterKeyDown(event)"></asp:TextBox>
                                            &nbsp; <asp:Label ID="lblName" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                  <tr>
                                        <td align ="right">
                                            &nbsp;</td>
                                        <td align ="left" height="20px" class="style2">
                                            &nbsp;</td>
                                         <td align ="left" width="100px">
                                            
                                        </td>
                                        <td width="75%"  align ="left">
                                            <asp:LinkButton ID="Search" runat="server" Width="50px" >SEARCH</asp:LinkButton>
                                            <asp:LinkButton ID="Download" runat="server" Width="50px">EXPORT</asp:LinkButton>    
                                            <asp:Button ID="btn_Hidden" runat="server" Text="Button" style="display:none" OnClick="btn_Hidden_Click" />
                                        </td>
                                        
                                   </tr>
                                 </table>
                         </td>
                     </tr>
                                    
                    </table>

                         <div style='overflow:auto;width:1200px;text-align:center;margin:0 auto';align="center">
                                    <asp:gridview ID="dgListEditEmployee2" runat="server"
                                     AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                     BorderStyle="None" BorderWidth="1px" CellPadding="1" CssClass="tDatagridITReview"
                                     Height="100%" AllowSorting="True" PageSize="10" AllowPaging="true" OnRowCommand="dgListEditEmployee2_RowCommand"
                                     Width="100%">

                                     <HeaderStyle CssClass="GridHeader" ForeColor="White" Font-Bold="True" HorizontalAlign="Center"/>
                                     <FooterStyle BackColor="White" ForeColor="#000066"/>
                                  <Columns>
                                         <asp:TemplateField HeaderStyle-Width="10px" HeaderText="ACTION">
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="cmdEdit" CommandArgument="<%# Container.DataItemIndex %>"
                                            ImageUrl="~/images/Edit2.jpg" Width="20px"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:BoundField  DataField="IDX" HeaderText="IDX" HeaderStyle-Width="10px" Visible="true">
                                <HeaderStyle Width="10px" CssClass="hidden"></HeaderStyle>
                                <ItemStyle CssClass="hidden"/>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="NUMBER" HeaderText="No." HeaderStyle-Width="10px" Visible="true">
                                <HeaderStyle Width="10px"></HeaderStyle>
                                </asp:BoundField>
                               
								<asp:BoundField  DataField="EmployeeID" HeaderText="Employee ID" HeaderStyle-Width="150px" Visible="true">
                                <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="EmployeeName" HeaderText="Employee Name" HeaderStyle-Width="200px" Visible="true">
                                <HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="AreaName" HeaderText="Area Name" HeaderStyle-Width="200px" Visible="true">
                                <HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundField>
                              
                                <asp:BoundField  DataField="DepartmentName" HeaderText="Department" HeaderStyle-Width="200px" Visible="true">
                                <HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="JoinDate" HeaderText="Join Date" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="10px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="EndDate" HeaderText="Expired Date" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="Entity" HeaderText="Entity" HeaderStyle-Width="90px" Visible="true">
                                <HeaderStyle Width="90px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="StatusEmployee" HeaderText="Status Employee" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="Duration" HeaderText="Duration" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                             
                                <asp:BoundField  DataField="EmailManager" HeaderText="Email Manager" HeaderStyle-Width="700px" Visible="true">
                                <HeaderStyle Width="700px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField  DataField="WorkerType" HeaderText="WorkerType" HeaderStyle-Width="100px"  Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                             
                                <asp:BoundField  DataField="EmailHR" HeaderText="Email HR" HeaderStyle-Width="100px"  Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                             
                                <asp:BoundField  DataField="1 Days" HeaderText="1 Days" HeaderStyle-Width="100px"  Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                               
                                <asp:BoundField  DataField="1 Week" HeaderText="1 Week" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="2 Week" HeaderText="2 Week" HeaderStyle-Width="90px" Visible="true">
                                <HeaderStyle Width="90px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="3 Week" HeaderText="3 Week" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="1 Month" HeaderText="1 Month" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="2 Month" HeaderText="2 Month" HeaderStyle-Width="100px"  Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField  DataField="3 Month" HeaderText="3 Months" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField  DataField="4 Month" HeaderText="4 Months" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField  DataField="5 Month" HeaderText="5 Months" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField  DataField="6 Month" HeaderText="6 Months" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField  DataField="7 Month" HeaderText="7 Months" HeaderStyle-Width="100px" Visible="true">
                                <HeaderStyle Width="100px"></HeaderStyle>
                                </asp:BoundField>
                           </Columns>          
                         <PagerSettings Visible="false"/>
                       </asp:gridview>
              </div>
              </div>
              <div style='overflow:auto;width:1000px;text-align:center;margin:0 auto';align="center">
                    <asp:Panel ID="pnlfooter" runat="server">
                        <table id="tablepaging" runat="server" width="1000px">
                        <tr>
                            <td align="left" width="15px">
                                <asp:LinkButton ID="lbFirst" runat="server">First </asp:LinkButton>
                            </td>
                            <td align="left" width="10px">
                                <asp:LinkButton ID="lbPrev" runat="server">Prev </asp:LinkButton>
                            </td>
                            <td align="center" width="120px" valign="middle" >
                                <input type="text" class="textbox_2" runat="server" id="txtGO"/> OF 
                                <asp:Label ID="lblTotal" runat="server" Text="-"></asp:Label>
                                &nbsp; <asp:LinkButton ID="lnkGo" runat="server">GO </asp:LinkButton>
                            </td>
                            <td align="left" width="10px">
                                 <asp:LinkButton ID="lnkNext" runat="server">Next </asp:LinkButton>
                            </td>
                             <td align="left" width="10px">
                                 <asp:LinkButton ID="lnkLast" runat="server">Last </asp:LinkButton>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;Total Records : <asp:Label ID="lblTotalRecords" runat="server" Text="0 record(s)"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        
                    </table>
                   </asp:Panel>
                   
                   <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    
                    <td height="30" >
                        Data per View :
                        <asp:DropDownList ID="ddl_View" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_View_SelectedIndexChanged">
                            <asp:ListItem>-- Choose --</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>70</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td background="Images/borderRight.gif" width="21" style="height: 13px">
                    </td>
                </tr>
                
        </table>
                </div> 
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
                
     
                </table>
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
                <tr>
                    <td background="Images/borderleft.gif" width="21">
                    </td>
                    <td background="Images/bg_line.gif" class="style1">
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                    </td>
                </tr>
                
        </table>
        
              <br />
              <Footer:My ID="My3" runat="server" />
    
                            
    </form>
</body>
</html>