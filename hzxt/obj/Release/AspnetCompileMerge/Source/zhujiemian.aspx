<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhujiemian.aspx.cs" Inherits="hzxt.zhujiemian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>华师帮帮</title>
</head>

<body>
    <form id="form1" runat="server">
        <div id="headdiv" class="main">
            <ul class="nav">
                <a href="Login.aspx"><asp:Label ID="Label1" runat="server" Text="登录 "></asp:Label></a>
            </ul>
        </div>
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem Text="帮帮跑腿" Value="帮帮跑腿" Selectable="False">
                    <asp:MenuItem Text="去接单" Value="去接单"></asp:MenuItem>
                    <asp:MenuItem Text="发布任务" Value="发布任务"></asp:MenuItem>
                    <asp:MenuItem Text="我的任务" Value="我的任务"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="问卷中心" Value="问卷中心"></asp:MenuItem>
                <asp:MenuItem Text="帮帮问答" Value="帮帮问答"></asp:MenuItem>
                <asp:MenuItem Text="资料分享" Value="资料分享"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </form>
</body>

</html>
