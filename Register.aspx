<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Demo.Meetup.CustomMembership.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox runat="server" ID="txtUser" placeholder="User name"></asp:TextBox>
    </div>
  <div>
    <asp:TextBox runat="server" ID="txtPassword" placeholder="Password"></asp:TextBox>
    </div>
            <div>
    <asp:TextBox runat="server" ID="txtRole" placeholder="Staff or Admin"></asp:TextBox>
    </div>
          <div>
              <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </div>
        <div>
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
