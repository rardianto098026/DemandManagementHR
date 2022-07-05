<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Insert.aspx.vb" Inherits="DemandManagementHR.Frm_Insert" %>

<%@ Register TagName="My" TagPrefix="Menu" Src="Menu/Menu.ascx" %>
<%@ Register TagName="My" TagPrefix="Head" Src="Menu/Header.ascx" %>
<%@ Register TagName="My" TagPrefix="Footer" Src="Menu/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/jquery-ui.min.css" rel="stylesheet" />
    <link href="css/select2.min.css" rel="stylesheet" />
    <link href="css/Surrounding.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="css/jquery-ui.css" />
    <script type="text/javascript" src="js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/select2.min.js"></script> 
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

            if (confirm("Do you want to create this notification?")) {

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
        $(function () {
            <%If Session("CHECKED") = "FALSE" Then%>
            var a = <% Session("CHECKED").ToString() %>
            //confirm_value.value = "Yes";
            $("#txtdateexpire").select({
            });
            <%Else%>
                $("#txtdateexpire").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "yy-mm-dd",
                yearRange: "-100:+100"
                });
            <%End If%>
            

            //$("#txtdateexpire").datepicker({
            //    changeMonth: true,
            //    changeYear: true,
            //    dateFormat: "yy-mm-dd",
            //    yearRange: "-100:+100"
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
     <script type="text/javascript">
         function huruf(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && charCode > 32)
                 return false;
             return true;
         }
	</script>

     <script type="text/javascript">
         $(document).ready(function () {

             $("#ddl_Entity").select2();
             $("#ddl_Department").select2();
             $("#ddl_Area").select2();
             $("#ddl_Manager").select2();
             $("#ddl_Status").select2();
             $("#ddl_Worker").select2();
             $("#ddl_nationality").select2();
             
         });
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
                    <asp:TextBox ID="txtempid" runat="server" Width="141px" onkeypress="return hanyaAngka(event)" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                    <asp:Label ID="Label2" runat="server" Text="Employee Name :" width="150px" height="30px"></asp:Label>
                    <asp:TextBox ID="txtempname" runat="server" Width="141px" onkeypress="return huruf(event)" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
             <tr>
		        <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                        <asp:Label ID="Label3" runat="server" Text="Entity :" width="150px" height="30px"></asp:Label>
			            <asp:DropDownList ID="ddl_Entity" runat="server" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Entity_SelectedIndexChanged">
		                </asp:DropDownList>  
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21">
                    &nbsp;</td>
                <td class="style1" height="30" align ="left">
                    <asp:Label runat="server" ID="Label11" Text="Worker Type :" width="150px" height="30px"></asp:Label> 
                    <asp:Dropdownlist ID="ddl_Worker" runat="server" Width="145px">
                    <asp:ListItem Text="--Choose--"  Value="0"></asp:ListItem>
                    <asp:ListItem Text="FTE"  Value="FTE"></asp:ListItem>
                    <asp:ListItem Text="Non FTE IMS" Value="Non FTE IMS"></asp:ListItem>
                    <asp:ListItem Text="Non FTE KPSG" Value="Non FTE KPSG"></asp:ListItem>
                    </asp:Dropdownlist>
                    <asp:Label style="margin-left:5px"  Visible="false" ID="Label12" runat="server" ForeColor="Red" Text="* Please Choose Remarks"></asp:Label>
                </td>
                <td background="Images/borderRight.gif" width="21">
                    &nbsp;</td>
            </tr>
            <tr>
		        <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                    <asp:Label ID="Label4" runat="server" Text="Department :" width="150px" height="30px"></asp:Label>
                     <asp:DropDownList ID="ddl_Department" runat="server" Width="145px ">   
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
                    <asp:DropDownList ID="ddl_Area" runat="server" Width="145px ">   
		             </asp:DropDownList> 
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                        <asp:Label ID="Label6" runat="server" Text="Manager :" width="150px" height="30px"></asp:Label>
			            <asp:DropDownList ID="ddl_Manager" runat="server" Width="145px" >  
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
                     <asp:TextBox ID="txtdatehire"  runat="server" Width="141px" AutoPostBack ="true" OnTextChanged ="txtdatehire_TextChanged" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                </td>
                <td class="style3" align ="left">
                     <asp:Label ID="Label8" runat="server" Text="Contract Expire Date :" width="150px" height="30px"></asp:Label>
                     <asp:TextBox ID="txtdateexpire"  runat="server" Width="141px" AutoPostBack ="true" ></asp:TextBox>
                     <asp:checkbox ID="chkexpire"  runat="server" Width="141px"  AutoPostBack ="true" ></asp:checkbox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21" class="style2">
                    </td>
                <td class="style3" align ="left">
                    <asp:Label ID="Label9" runat="server" Text="Duration (Month) :" width="150px" height="30px"></asp:Label>
                    <asp:TextBox ID="txtduration" runat="server" Width="141px" AutoPostBack ="true" OnTextChanged ="txtduration_TextChanged" onkeypress="return hanyaAngka(event)" ></asp:TextBox>
                </td>
                <td background="Images/borderRight.gif" width="21" class="style2">
                </td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21">
                    &nbsp;</td>
                <td class="style1" height="30" align ="left">
                    <asp:Label runat="server" ID="Label13" Text="Nationality :" width="150px" height="30px"></asp:Label> 
                    <asp:Dropdownlist ID="ddl_nationality" runat="server" Width="145px">
                        <asp:ListItem Text="--Choose--"  Value="0"></asp:ListItem>
                        <asp:ListItem Text="Indonesian"  Value="Indonesian"></asp:ListItem>
                        <asp:ListItem Text="Expatriate"  Value="Expatriate"></asp:ListItem>
                    </asp:Dropdownlist>
                    <asp:Label style="margin-left:5px"  Visible="false" ID="Label15" runat="server" ForeColor="Red" Text="* Please Choose Remarks"></asp:Label>
                </td>
                <td background="Images/borderRight.gif" width="21">
                    &nbsp;</td>
            </tr>
            <tr>
                <td background="Images/borderleft.gif" width="21">
                    &nbsp;</td>
                <td class="style1" height="30" align ="left">
                    <asp:Label runat="server" ID="Label10" Text="Status :" width="150px" height="30px"></asp:Label> 
                    <asp:Dropdownlist ID="ddl_Status" runat="server" Width="145px">
                    <asp:ListItem Text="--Choose--"  Value="0"></asp:ListItem>
                    <asp:ListItem Text="Contract"  Value="CONTRACT"></asp:ListItem>
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
