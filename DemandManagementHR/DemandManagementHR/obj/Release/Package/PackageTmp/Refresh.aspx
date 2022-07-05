<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Refresh.aspx.vb" Inherits="DemandManagementHR.Refresh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <script>
     var clicked = false;
     function CheckBrowser() {
         if (clicked == false) {
             //Browser closed
         }
         else {
             //redirected 
             clicked = false;
         }
     }

     function bodyUnload() {
         if (clicked == false)//browser is closed
         {
             window.opener.document.getElementById('btn_Hidden').click();
         }
     }
     
function RefreshParent() {
            window.opener.document.getElementById('btn_Hidden').click();
            window.close();
        }
</script>