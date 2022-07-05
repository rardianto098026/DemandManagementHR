<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="DemandManagementHR.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta charset="UTF-8">
    <title>Reminder HR Applictaion</title>
    <link rel="shortcut icon" href="Images/icon.ico" />
    <link rel='stylesheet prefetch' href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css'/>
    <link rel="stylesheet" href="css/style.css"/>
</head>
<body>
  <form id="Form1" runat="server">
   <link href='http://fonts.googleapis.com/css?family=Ubuntu:500' rel='stylesheet' type='text/css'>
    <div class="login">
  <%--<div class="login-header">--%>
        <br /> <br />
    <h1 align="center">Reminder HR</h1>
  <%--</div>--%>
        <div class="login-form">
    <h3>Username:</h3>
    <asp:TextBox runat="server" ID="txtUser" placeholder="Username" ></asp:TextBox><br>
    <h3>Password:</h3>
    <asp:TextBox runat="server" ID="txtPass" TextMode="Password" placeholder="Password"></asp:TextBox>
    <br>
    <br>
    <asp:Button runat="server" ForeColor="#2c3e50"  ID="btnSubmit" Text="Login" class="login-button" />
    <asp:Label runat="server" ForeColor="Red" ID="lblLogin" style="margin-left:2px" Visible="false"></asp:Label>
   
  </div>
</div>

<script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
<script src='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js'></script>
<script src="js/index.js"></script>

    
  </form>  
</body>
</html>
