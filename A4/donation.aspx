<%@ Page Language="C#" AutoEventWireup="true" CodeFile="donation.aspx.cs" Inherits="donation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
       <p>Donation Amount &nbsp $<asp:TextBox ID="DonationTextBox" runat="server"></asp:TextBox></p>
        <asp:Button ID="DonationButton" runat="server" Text="Submit" OnClick="DonationButton_Click" />
         </div>

    </form>
</body>
</html>
