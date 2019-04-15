<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registartiondata.aspx.cs" Inherits="WebApplication1.registartiondata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REGISTRATION DATA</title>
</head>
<body>
    <form id="form1" runat="server">
        <center>
        <h2>
            <asp:Label ID="Lblmessage" runat="server" Text=""></asp:Label></h2>
        <div>
            
            <h1>DETAILS OF USER:</h1>
            <table border="2">
                <tr>
                    <td>ID</td>
                    <td>FIRST NAME</td>
                    <td>LAST NAME</td>
                    <td>USER NAME</td>
                    <td>PASSWORD</td>
                    <td>Email Id</td>
                    <td>State</td>
                     <td>City</td>
                     <td>pincode</td>
                     <td>gender</td>
                     <td>programming</td>
                    <td>Edit data</td>
                    <td>Delete data</td>

                    </tr>
                <% for (int i = 0; i < o.Count; i++){ %>                 
                
                   <tr>
                        <td><%=o[i].Id %></td>
                        <td><%=o[i].Firstname %></td>
                        <td><%=o[i].Lastname %></td>
                        <td><%=o[i].Username %></td>
                        <td><%=o[i].Password %></td>
                        <td><%=o[i].Emailid %></td>
                        <td><%=o[i].State %></td>
                        <td><%=o[i].City %></td>
                        <td><%=o[i].Pincode %></td>
                        <td><%=o[i].Gender %></td>
                        <td><%=o[i].Programming %></td>


                       <td><a href="editregistartion.aspx?Id=<%=o[i].Id %>">Edit</a></td>
                       <td><a href="deletedata.aspx?Id=<%=o[i].Id %>">Delete</a></td>

                    </tr>


            <%  } %>

                </table>



              
        </div>
      </center>
            </form>
</body>
</html>
