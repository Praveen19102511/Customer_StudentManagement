<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Customer.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server" >
        <div class="container">
    <div class="row justify-content-center ">
        <div class="col-md-6">
            <div class="card mt-5">
                <div class="card-body">
                    <h5 class="card-title text-center">Simple Calculator</h5>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Number 1:"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Number 2:"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Operation:"></asp:Label>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                <asp:ListItem Value="+">Addition</asp:ListItem>
                                <asp:ListItem Value="-">Subtraction</asp:ListItem>
                                <asp:ListItem Value="*">Multiplication</asp:ListItem>
                                <asp:ListItem Value="/">Division</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group text-center">
                            <asp:Button ID="Button1" runat="server" Text="Calculate" OnClick="Button1_Click" CssClass="btn btn-primary" />
                        </div>
                        <div class="form-group text-center">
                            <asp:Label ID="LabelResult" runat="server" Text=""></asp:Label>
                        </div>
                </div>
            </div>
        </div>
    </div>
</div>
    </form>
</body>
</html>
