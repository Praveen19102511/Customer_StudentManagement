<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Customer.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student-Management-System</title>
    <style type="text/css">
        .centered-form {
  display: flex;
  justify-content: center;
}
    </style>
</head>
<body>
    <form  class="centered-form" id="form1" runat="server">
        <div>
            
            <table align="center" style="background-color: khaki ">
                <caption> Student Data Management</caption>
                <tr>
                    <td ">Student id :</td>
                    <td >
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    </td>
                    <td rowspan="4">
                        
                        <asp:Image ID="imgPhoto" runat="server" Height="200px" style="margin-top: 0px" Width="200px"  BorderStyle="Groove"/>
                        
                    </td>
                </tr>
                <tr>
                    <td>Student Name :</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Student Class : </td>
                    <td>
                        <asp:TextBox ID="txtClass" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Annual Fee :</td>
                    <td>
                        <asp:TextBox ID="txtFee" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="BtnSelect" runat="server" Text="Select" Width="100px" OnClick="BtnSelect_Click" />
                        <asp:Button ID="BtnInsert" runat="server" Text="Insert" width="100px" OnClick="BtnInsert_Click"/>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="BtnUpdate" runat="server" Text="Update"  Width="100px" OnClick="BtnUpdate_Click" />
                        <asp:Button ID="BtnDelete" runat="server" Text="Delete"  Width="100px" OnClick="BtnDelete_Click" />
                        <asp:Button ID="BtnUpload" runat="server" Text="Upload Image" Width="270px" OnClick="BtnUpload_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="BtnReset" runat="server" Text="Reset All"  Width="478px" OnClick="BtnReset_Click"/>
                    </td>
                </tr>
            </table>
            <asp:Label ID="iblMsgs" runat="server" ForeColor="Red" />
            
        </div>
    </form>
</body>
</html>
