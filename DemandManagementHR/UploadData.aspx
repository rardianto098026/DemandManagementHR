<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UploadData.aspx.vb" Inherits="DemandManagementHR.UploadData" %>
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
                    <td background="Images/borderleft.gif" width="21"><br /><br /><br />
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
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                        Attach File :  <br />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                        <asp:FileUpload ID="txtUpload" runat="server" CssClass="textbox" Width="450px" /> 
                        &nbsp; <asp:Label ID="lblErr_Upload" runat="server" Text="." Visible="false" ForeColor="Red" autopostback="true"></asp:Label>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
                
              <tr>
                    <td background="Images/borderleft.gif" width="21"> <br /><br /><br />
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="Confirm_Upload()" OnClick="Alert"/>
                       &nbsp; &nbsp;
                        <%--<asp:Button ID="btnBack" runat="server" Text="Back" />--%>
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>    

            <tr>
                    <td background="Images/borderleft.gif" width="21"><br /><br /><br /><br /><br /><br /><br /><br /><br />
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
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                        Attach File Department :<br /> 
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                        <asp:FileUpload ID="upload_depart" runat="server" CssClass="textbox" Width="450px" /> 
                        &nbsp; <asp:Label ID="Label1" runat="server" Text="." Visible="false" ForeColor="Red" autopostback="true"></asp:Label>
                        </td>
                    <td background="Images/borderRight.gif" width="21">
                        &nbsp;</td>
              </tr>
                
              <tr >
                    <td background="Images/borderleft.gif" width="21"><br /><br /><br />
                        &nbsp;</td>
                    <td class="style1" height="30" align ="left">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btn_submit_dep" runat="server" Text="Submit" OnClientClick="Confirm_Upload()" OnClick="Alert"/>
                       &nbsp; &nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back" />
                    </td>
                    <td background="Images/borderRight.gif" width="21">&nbsp;</td>
              </tr>    
        </table>
        <br /><br /><br />
                <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
     
                </table>
                
    </div>
     <div>
     <footer:my ID="My3" runat="server" /> 
     </div>   
    </form>
</body>
</html>