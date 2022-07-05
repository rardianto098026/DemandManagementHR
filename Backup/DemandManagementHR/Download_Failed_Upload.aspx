<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Download_Failed_Upload.aspx.vb" Inherits="DemandManagementHR.Download_Failed_Upload" %>
<%@ Register TagName="My" TagPrefix="Menu" Src="Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="~/Menu/Footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


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
  <script type="text/javascript">
        $(function() {
        $("#txtPolExpDateFrom").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

        $(function() {
        $("#txtPolExpDateTo").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });
   </script>
  <script type="text/javascript">

      function Confirm_Upload() {

          var confirm_value = document.createElement("INPUT");

          confirm_value.type = "hidden";

          confirm_value.name = "confirm_value";

          if (confirm("Do you want to upload the data?")) {

              confirm_value.value = "Yes";

          } else {

              confirm_value.value = "No";

          }

          document.forms[0].appendChild(confirm_value);
      }
   </script>
  
</head>
<body onbeforeUnload="bodyUnload();" onclick="clicked=true;" oncontextmenu="return false">
    <form id="form1" runat="server">
    <div>
     <table width="100%" align="center" cellpadding="0" cellspacing="0">
            <tr>
               
                <td align="center">
                 <Head:My ID="head" runat="server" />
                 </td>
               
            </tr>
            
            <tr>
                
                    <td align="left" bgcolor="#0055AA">
                        <Menu:My ID="My1" runat="Server" />
                    </td>
                   
            </tr>
            
    </table> 
        <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td >
                            </td>
                             <td align ="left" width="1500px" height="20px">
                                            Download 
                             </td>
                        </tr>
                         
                          <tr>
                            <td width="1%">
                            </td>
                            <td align="right" width="1%">
                                <asp:CheckBox ID="chkExpDate" runat="server" Text="" TextAlign=left />
                            </td>
                            <td width="1%"  align="left">
                                <asp:Label ID="Label14" runat="server" Text="Date Upload"></asp:Label><asp:Label ID="Label15" runat="server" Text="." Visible="false" ForeColor="Red"></asp:Label>
                            </td>
                            <td width="2%" align ="left">
                                <asp:TextBox ID="txtPolExpDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                                 &nbsp;
                                          
                             </td>
                             
                            <td align="Center" width="1%">
                                s/d
                                  
                            </td>
                            <td width="1%" align="left">
                                <asp:TextBox ID="txtPolExpDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                                  
                            </td>
                            <td width="10%" align ="left">
                                <asp:Label ID="lblpolExpDate" runat="server" ForeColor="Red" Text="." 
                                    Visible="false"></asp:Label>
                              </td>
                            
                           
                          </tr>
                           
                           
            </table>  
            <table>
            <tr>
                            
                             <td align ="left" width="1500px" height="20px" >
                            <asp:LinkButton ID="Search" OnClick="Search_Click" runat="server" Width="50px" 
                                     style="margin-left:165px; ">Download</asp:LinkButton>
                           
                             </td>
                        </tr>
            
            </table>
    </div>
     <div>
     <footer:my ID="My3" runat="server" /> 
     </div>  
    
    </form>
</body>
</html>