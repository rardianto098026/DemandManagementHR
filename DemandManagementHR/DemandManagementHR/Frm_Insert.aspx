<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Insert.aspx.vb" Inherits="DemandManagementHR.Frm_Insert" %>

<%@ Register TagName="My" TagPrefix="Menu" Src="Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="Menu/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Surrounding.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="css/jquery-ui.css" />
    <script type="text/javascript" src="js/jquery-1.10.2.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <link rel="stylesheet" href="css/style4.css" />
    <style type="text/css">
        .style2
        {
            height: 30px;
        }
        .style3
        {
            width: 695px;
            height: 30px;
        }
        inputxxx {
            display: none;
        }

    </style>
    <script type="text/javascript">

        function Confirm_Add() {

            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden";

            confirm_value.name = "confirm_value";

            if (confirm("Are you sure want to Add New Request?")) {

                confirm_value.value = "Yes";

            } else {

                confirm_value.value = "No";

            }

            document.forms[0].appendChild(confirm_value);
        }
   </script>
    <script type="text/javascript">
        $(function() {
            $("#txtdatehire").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "yy-mm-dd",
                yearRange: "-100:+100"
            });
        });
    </script> 
    <%--<script type="text/javascript">
        $(function() {
            $("#txtdateexpire").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy",
                yearRange: "-100:+100"
            });
        });--%>
  <%--  </script> --%>
    <script type="text/javascript">
		function hanyaAngka(evt) {
		  var charCode = (evt.which) ? evt.which : event.keyCode
		   if (charCode > 31 && (charCode < 48 || charCode > 57))
 
		    return false;
		  return true;
		}
	</script>
</head>
<body>
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
    </div>
    <div>
    
        <table width="1200px" align="center" cellpadding="0" cellspacing="0">
           
            <br />
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                    <asp:Label ID="Label1" runat="server" Text="Employee ID :" width="150px" height="30px"></asp:Label>
                    <asp:TextBox ID="txtempid" runat="server" style="margin-left: 30px" Width="141px" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                    <asp:Label ID="Label2" runat="server" Text="Employee Name :" width="150px" height="30px"></asp:Label>
                    <asp:TextBox ID="txtempname" runat="server" style="margin-left: 30px" Width="141px" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
		        <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                    <asp:Label ID="Label4" runat="server" Text="Department :" width="150px" height="30px"></asp:Label>
                    <asp:TextBox ID="txtdepartment" runat="server" style="margin-left: 30px" Width="141px" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
		        <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                        <asp:Label ID="Label3" runat="server" Text="Entity :" width="150px" height="30px"></asp:Label>
			            <asp:DropDownList ID="ddl_Entity" runat="server" style="margin-left:30px" Width="145px ">   
		                </asp:DropDownList>  
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                    <asp:Label ID="Label5" runat="server" Text="Area Name :" width="150px" height="30px"></asp:Label>
                    <asp:TextBox ID="txtarea" runat="server" style="margin-left: 30px" Width="141px" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                        <asp:Label ID="Label6" runat="server" Text="Manager :" width="150px" height="30px"></asp:Label>
			            <asp:DropDownList ID="ddl_Manager" runat="server" style="margin-left:30px" Width="145px" >  
		                </asp:DropDownList>  
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                     <asp:Label ID="Label7" runat="server" Text="Hired Date :" width="150px" height="30px"></asp:Label>
                     <asp:TextBox ID="txtdatehire"  runat="server" style="margin-left: 30px" Width="141px" AutoPostBack ="true" OnTextChanged ="txtdatehire_TextChanged" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                     <asp:Label ID="Label8" runat="server" Text="Contract Expire Date :" width="150px" height="30px"></asp:Label>
                     <asp:TextBox ID="txtdateexpire"  runat="server" style="margin-left: 30px" Width="141px"  ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                    </td>
                <td class="style3" align ="left">
                    <asp:Label ID="Label9" runat="server" Text="Duration (Month) :" width="150px" height="30px"></asp:Label>
                    <asp:TextBox ID="txtduration" runat="server" style="margin-left: 30px" Width="141px" AutoPostBack ="true" OnTextChanged ="txtduration_TextChanged" onkeypress="return hanyaAngka(event)" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21">
                    &nbsp;</td>
                <td class="style1" height="30" align ="left">
                    <asp:Label runat="server" ID="Label10" Text="Status :" width="150px" height="30px"></asp:Label> 
                    <asp:Dropdownlist ID="ddl_Status" runat="server" style="margin-left: 30px" Width="145px">
                    <asp:ListItem Text="--Choose--"  Value="0"></asp:ListItem>
                    <asp:ListItem Text="Contract"  Value="CONTRACT"></asp:ListItem>
                    <asp:ListItem Text="Permanent" Value="PERMANENT"></asp:ListItem>
                    <asp:ListItem Text="Probation" Value="PROBATION"></asp:ListItem>
                    </asp:Dropdownlist>
                    <asp:Label style="margin-left:5px"  Visible="false" ID="Label14" runat="server" ForeColor="Red" Text="* Please Choose Remarks"></asp:Label>
                </td>
                <td background="Images/borderRight.gif" width="21">
                    &nbsp;</td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21">
                     &nbsp;</td>
                <td class="style1" height="30" align ="left">
                    <asp:Button ID="btnSubmit" runat="server" Width="65px" height="25" Text="Submit" OnClientClick="Confirm_Add()" OnClick="Alert_Add"/>
                    &nbsp; &nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="Back" Width="60px" height="25"/>
                    &nbsp; &nbsp;
                    
                    </td>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                    </td>
            </tr>
        </table>
               
        <table width="1200px" align="center" cellpadding="0" cellspacing="0">
                
        </table>
    </div>
    <br />
    <div>
     <footer:my ID="My3" runat="server" /> 
     </div>  
    </form>
</body>
</html>
