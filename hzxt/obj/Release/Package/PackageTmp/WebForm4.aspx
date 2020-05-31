<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="hzxt.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="dlData" runat="server" RepeatColumns="1" DataKeyField="num" OnItemCommand="dlData_ItemCommand" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="342px">
                <AlternatingItemStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
            <ItemTemplate>
            
            <asp:Label ID="title" runat="server" Text="任务名："></asp:Label><%#DataBinder.Eval(Container.DataItem, "title" )%>&nbsp;
                <br />
            <asp:Label ID="releaser" runat="server" Text="发布人："></asp:Label><%#DataBinder.Eval(Container.DataItem, "releaser" )%>&nbsp;
                <br />
            <asp:Label ID="endtime" runat="server" Text="截止时间："></asp:Label><%#DataBinder.Eval(Container.DataItem, "endtime" )%>&nbsp;
                <br />
            <asp:Label ID="place" runat="server" Text="校区："></asp:Label><%#DataBinder.Eval(Container.DataItem, "place" )%>&nbsp;
                <br />
            <asp:Label ID="content" runat="server" Text="详细内容："></asp:Label><%#DataBinder.Eval(Container.DataItem, "[content]" )%>&nbsp;
                <br />
                <asp:Button ID="Button1" runat="server" Text="选择" CommandName="select" />
                <br />
            </ItemTemplate>
                <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:huzhuxtConnectionString2 %>" SelectCommand="SELECT [title], [releaser], [place], [endtime], [content] FROM [task]"></asp:SqlDataSource>
            <br />
        </div>
         <div>
            
             <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" Visible="False" />
            
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="返回" />
    </form>
</body>
</html>
