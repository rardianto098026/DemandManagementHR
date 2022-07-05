<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PopUpEmpl.aspx.vb" Inherits="DemandManagementHR.PopUpEmpl" %>
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

      function Confirm_Upload() {

          var confirm_value = document.createElement("INPUT");

          confirm_value.type = "hidden";

          confirm_value.name = "confirm_value";

          if (confirm("Do you want to save the data?")) {

              confirm_value.value = "Yes";

          } else {

              confirm_value.value = "No";

          }

          document.forms[0].appendChild(confirm_value);
      }
   </script>
  <script type="text/javascript">
      function RefreshParent() {
          window.opener.document.getElementById('btn_Hidden').click();
          window.close();
      }
  </script>
  <%Response.WriteFile("Refresh.aspx")%>
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
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="10">
                        &nbsp;</td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblEmplID" runat="server" Text="Employee ID"></asp:Label>
                    <asp:Label ID="lblEmplID2" runat="server" style="margin-left:58px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblEmplName" runat="server" Text="Employee Name"></asp:Label>
                    <asp:Label ID="lblEmplName2" runat="server" style="margin-left:40px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblEntity" runat="server" Text="Entity"></asp:Label>
                    <asp:Label ID="lblEntity2" runat="server" style="margin-left:88px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblArea" runat="server" Text="Area Name"></asp:Label>
                    <asp:Label ID="lblArea2" runat="server" style="margin-left:59px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblDeptName" runat="server" Text="Department"></asp:Label>
                    <asp:Label ID="lblDeptName2" runat="server" style="margin-left:57px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblStatEmpl" runat="server" Text="Status Employee"></asp:Label>
                    <asp:Label ID="lblStatEmpl2" runat="server" style="margin-left:32px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblJoinDate" runat="server" Text="Join Date"></asp:Label>
                    <asp:Label ID="lblJoinDate2" runat="server" style="margin-left:68px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblDuration" runat="server" Text="Duration"></asp:Label>
                    <asp:Label ID="lblDuration2" runat="server" style="margin-left:72px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblExpDate" runat="server" Text="Expiry Date"></asp:Label>
                    <asp:Label ID="lblExpDate2" runat="server" style="margin-left:56px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblEmlMgr" runat="server" Text="Email Manager"></asp:Label>
                    <asp:Label ID="lblEmlMgr2" runat="server" style="margin-left:41px"></asp:Label>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                    <asp:Label ID="lblDisable" runat="server" Text="Disable Notif"></asp:Label>
                    <asp:CheckBoxList runat="server" ID="chkList" style="margin-left:105px"></asp:CheckBoxList>
                    </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
              
              <tr>
                    <td background="Images/borderleft.gif" width="21">
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="Confirm_Upload()" OnClick="Alert"/>
                       &nbsp; &nbsp;
                        <asp:Button ID="btnBack" OnClientClick="RefreshParent()"  runat="server" Text="Back" />
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>    
        </table>
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
     
                </table>
                
    </div>
     <div>
     <footer:my ID="My3" runat="server" /> 
     </div>   
    </form>
</body>
</html>