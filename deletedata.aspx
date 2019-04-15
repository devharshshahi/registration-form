<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deletedata.aspx.cs" Inherits="WebApplication1.deletedata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>delete data</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>delete registartion data</h1>
            
           <table>
                <tr>
                    <td>FIRST NAME:</td>
                    <td>
                        <asp:Label ID="LF" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>LAST NAME:</td>
                    <td> <asp:Label ID="LL" runat="server" Text=""></asp:Label> </td>
                </tr>
                <tr>
                    <td>USER NAME:</td>
                    <td>  <asp:Label ID="LU" runat="server" Text=""></asp:Label></td>
                </tr>
                
                <tr>
                    <td>PASSWORD:</td>
                    <td>
                        <asp:Label ID="LP" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>EMAIL ID:</td>
                    <td>
                        <asp:Label ID="LE" runat="server" Text=""></asp:Label></td>
                </tr>
               <tr>
                   <td></td>
                   <td>
                       <asp:Button ID="bdelete" runat="server" Text="DELETE" OnClick="bdelete_Click" /></td>
                   <asp:Label ID="Lmessage" runat="server" Text=""></asp:Label>
               </tr>
                </table>

        </div>
    </form>
</body>
</html>
