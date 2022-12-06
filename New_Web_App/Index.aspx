<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="New_Web_App.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="cssdesign.css" rel="stylesheet" type="text/css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lbl_name" runat="server" Text="CategoryName"></asp:Label>

            <asp:TextBox ID="txt_input" runat="server" CssClass=".txtstyle" style="margin-top: 29px" Width="160px" OnTextChanged="txt_input_TextChanged"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" style="margin-left: 42px" Text="Search" CssClass=".btn_search"/>

        </div>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="datagrid" runat="server" OnPageIndexChanging="datagrid_PageIndexChanging" AllowPaging="True"  PageSize="4">
                <PagerSettings FirstPageText="&quot;First&quot;" LastPageImageUrl="&quot;Last&quot;" Mode="NumericFirstLast" PageButtonCount="4" />
            </asp:GridView>
        </p>
        <asp:Label ID="lbl_mes" runat="server"></asp:Label>
    </form>
</body>
</html>
