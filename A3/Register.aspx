<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Register </h1>
    <form id="form1" runat="server">
    <div>
    
        <table>
            <tr>
                <td>FisrtName</td>
                <td>
                    <asp:TextBox ID="FirstNametextBox" runat="server" OnTextChanged="FirstNametextBox_TextChanged"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name Is Required" ControlToValidate="FirstNameTextBox"></asp:RequiredFieldValidator></td>
            </tr>
            <tr><td>Last name</td>
            <td>
                <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox></td>
               
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email Is Required" ControlToValidate="EmailTextBox"></asp:RequiredFieldValidator>
               </td>
                     <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email"   ControlToValidate="EmailTextBox"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
 </asp:RegularExpressionValidator>
                </td>
               
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Passeword Is Required" ControlToValidate ="PasswordTextBox"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="RegisterButton" runat="server" Text="Resgiter" OnClick="RegisterButton_Click" /></td>
                
            </tr>

        </table>
    </div>
    </form>
</body>
</html>
