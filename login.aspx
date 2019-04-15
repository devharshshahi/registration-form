<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>LOGIN PAGE</title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
        <div>
            <h1>LOGIN HERE</h1>
                <table>
                    <tr>
                        <td>USERNAME:</td>
                        <td><asp:TextBox ID="user" runat="server"></asp:TextBox></td>
                    </tr>
                      <tr>
                        <td>PASSWORD:</td>
                        <td><asp:TextBox ID="pass" TextMode="Password" runat="server"></asp:TextBox></td>
                    </tr>
                      <tr>
                        <td><asp:Button ID="Button1" runat="server" Text="LOGIN" OnClick="Button1_Click" CssClass="btn alert-primary"></asp:Button></td>
                        <td><asp:Button ID="Button2" runat="server" Text="SIGNUP" OnClick="Button2_Click" CssClass="btn alert-primary"></asp:Button></td>
                    <asp:Label ID="Lblmessage" runat="server" Text=""></asp:Label></tr>




                </table>
       </div>
         </form>
      </center>      
   
</body>
</html>
