<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="Demo.Meetup.CustomMembership.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
        <table>
            <tr>
                <td><asp:Label runat="server" ID="lblUser">Username :</asp:Label> </td>
                <td>
        <asp:TextBox runat="server" ID="txtUsername"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>
            <asp:Label runat="server" ID="Label1">Password</asp:Label> 

                </td>
                <td>
        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>
            <asp:Button runat="server" ID="btnSubmit" Text="LOG IN" OnClick="btnSubmit_Click" />       

                </td>
            </tr>
        </table>
    

    </div>
    </form>
</body>
</html>
