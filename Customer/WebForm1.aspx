<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Customer.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Details</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
     <form id="form1" runat="server">
        <div class="container">
            <h3>Customer Details | Accessing data from DataSet: </h3>
            <hr />
            <table class="table" align="center">
                <caption>Customer Details</caption>
                <tr>
                    <td>Customer Id:</td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server" /></td>
                </tr>
                <tr>
                    <td>Customer Name:</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" /></td>
                </tr>
                <tr>
                    <td>Customer Balance:</td>
                    <td>
                        <asp:TextBox ID="txtBalance" runat="server" /></td>
                </tr>
                <tr>
                    <td>Customer City:</td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" /></td>
                </tr>
                <tr>
                    <td>Customer Status:</td>
                    <td>
                        <asp:CheckBox ID="cbStatus" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnFirst" CssClass="btn btn-success" runat="server" Text="First" Width="50" OnClick="BtnFirst_Click" />
                        <asp:Button ID="btnPrev" CssClass="btn btn-info" runat="server" Text="Prev" Width="50" OnClick="BtnPrev_Click"  />
                        <asp:Button ID="btnNext" CssClass="btn btn-danger" runat="server" Text="Next" Width="50" OnClick="BtnNext_Click"  />
                        <asp:Button ID="btnLast" CssClass="btn btn-primary" runat="server" Text="Last" Width="50" OnClick="BtnLast_Click"  />
                        <br />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
