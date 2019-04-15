<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>registration form</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <style type="text/css">
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
            <h1>REGISTRATION FORM</h1>
            <table>
                <tr>
                    <td>FIRST NAME:</td>
                    <td><asp:TextBox ID="FNAME" MaxLength="50" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RFfirstname" runat="server" ErrorMessage="please insert first name" ControlToValidate="FNAME"></asp:RequiredFieldValidator>
 </td>
                </tr>
                <tr>
                    <td>LAST NAME:</td>
                    <td><asp:TextBox ID="LNAME" MaxLength="50" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="please insert last name" ControlToValidate="LNAME"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>USER NAME:</td>
                    <td><asp:TextBox ID="USER"  MaxLength="50" runat="server"></asp:TextBox> 
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="please insert username" ControlToValidate="USER"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td>PASSWORD:</td>
                    <td><asp:TextBox ID="PASS" TextMode="Password" MaxLength="10" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="please insert password" ControlToValidate="PASS"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>EMAIL ID:</td>
                    <td><asp:TextBox ID="MAIL" TextMode="Email" MaxLength="50"  runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="please insert mail" ControlToValidate="MAIL"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>STATE:</td>
                    <td><asp:DropDownList ID="ddlsatate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlsatate_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                <tr>
                    <td>CITY:</td>
                    <td><asp:DropDownList ID="ddlcity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                <tr>
                    <td>PINCODE:</td>
                    <td>
                        <asp:TextBox ID="txtpincode" runat="server" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                    </td>
                    </tr>
               <tr>
                    <td>Gender</td>
                   <td>
                   <asp:RadioButton ID="Rdfemale" runat="server" GroupName="gender" Text="Female"></asp:RadioButton>
<asp:RadioButton ID="Rdmale" runat="server"  GroupName="gender" Text="Male" ></asp:RadioButton>
                    </td>
                   </tr>
                   
                   
                   <td>programming</td>
                    <td>
<asp:CheckBox ID="Chkjava" runat="server" Text="JAVA"></asp:CheckBox>
<asp:CheckBox ID="Chkdotnet" runat="server" Text="dot net"></asp:CheckBox>
<asp:CheckBox ID="Chkpython" runat="server" Text="Python"></asp:CheckBox>
<asp:CheckBox ID="Chkcplus" runat="server" Text="c++"></asp:CheckBox>
    </td>
                    </tr>

                
             

                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1">
                        <asp:Button ID="Button1" runat="server" Text="SUBMIT" OnClick="Button1_Click" CssClass="btn alert-success"/>             
                        <asp:Label ID="lblmessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                    </tr>
            </table>
            </center>
         
            </div>
    </form>
</body>
</html>
