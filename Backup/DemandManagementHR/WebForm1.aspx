<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="DemandManagementHR.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
	<BR>Dear Manager,<BR><BR>
	The Contract Status of the following employee is going to expire on + @ENDDATE + :<br><br>
	<table><tr><td>Employee ID</td><td>:</td><td></td></tr>
	<tr><td>Employee Name</td><td>:</td><td></td></tr>
	<tr><td>Hire Date</td><td>:</td><td></td></tr>
	<tr><td>Contract Expiry Date</td><td>:</td><td></td></tr>
	<tr><td>Area Name</td><td>:</td><td></td></tr>
	<tr><td>Department</td><td>:</td><td></td></tr>
	<tr><td>Entity</td><td>:</td><td></td></tr>
	</table><BR><BR>
	Please kindly complete the Contract Based Evaluation (CBE) Form for Non FTE or Probation Based Evaluation (PBE)<br>
	for FTE by attaching the Key Accountability Form, and obtain necessary approval, then <br>
	<font color="blue">submit to HR Department at the latest 10 days before contract expiry date</font>.<br><br>
	<font color="Red">Failure to submit the CBE or PBE with Key Accountability form on time will result in automatic employment contract status termination.</font><br><br>
	Should you have any further queries, please do not hesitate to contact HR administrator <br><br><br>
	Regards<br>
	HR Department
    </div>
    </form>
</body>
</html>
