<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gettask.aspx.cs" Inherits="hzxt.gettask" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:huzhuxtConnectionString %>" SelectCommand="SELECT [title], [releaser], [place], [endtime], [content] FROM [task]"></asp:SqlDataSource>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:DataList ID="DataListHuoList" runat="server" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" Width="427px">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#E3EAEB" />
                <ItemTemplate>
                    title:
                    <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    <br />
                    releaser:
                    <asp:Label ID="releaserLabel" runat="server" Text='<%# Eval("releaser") %>' />
                    <br />
                    place:
                    <asp:Label ID="placeLabel" runat="server" Text='<%# Eval("place") %>' />
                    <br />
                    endtime:
                    <asp:Label ID="endtimeLabel" runat="server" Text='<%# Eval("endtime") %>' />
                    <br />
                    content:
                    <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
                    <br />
<br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList>
            <asp:LinkButton ID="linkbtnone" runat="server" OnClick="linkbtnone_Click">首页</asp:LinkButton>
            <asp:LinkButton ID="linkbtnpre" runat="server" OnClick="linkbtnpre_Click">上一页</asp:LinkButton>
            <asp:LinkButton ID="linkbtnnext" runat="server" OnClick="linkbtnnext_Click">下一页</asp:LinkButton>
            <asp:LinkButton ID="linkbtnlast" runat="server" OnClick="linkbtnlast_Click">尾页</asp:LinkButton>
            <asp:Label ID="labcp" runat="server"></asp:Label>[<asp:Label ID="labpage" runat="server" Text="1"></asp:Label>/<asp:Label ID="labtp" runat="server"></asp:Label>]
            <asp:Label ID="labgoto" runat="server" Text="转到："></asp:Label>
            <asp:TextBox ID="txtgo" runat="server" Height="15px" Width="30px"></asp:TextBox>页
            <asp:Button ID="BtnGo" runat="server" Text="GO" Width="36px" OnClick="BtnGo_Click" />
            <br />
            <br />
            <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataSourceID="SqlDataSource1" Height="50px" Width="125px">
                <Fields>
                    <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                    <asp:BoundField DataField="releaser" HeaderText="releaser" SortExpression="releaser" />
                    <asp:BoundField DataField="place" HeaderText="place" SortExpression="place" />
                    <asp:BoundField DataField="endtime" HeaderText="endtime" SortExpression="endtime" />
                    <asp:BoundField DataField="content" HeaderText="content" SortExpression="content" />
                </Fields>
            </asp:DetailsView>
            <br />
            </td>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                    <asp:BoundField DataField="releaser" HeaderText="releaser" SortExpression="releaser" />
                    <asp:BoundField DataField="place" HeaderText="place" SortExpression="place" />
                    <asp:BoundField DataField="endtime" HeaderText="endtime" SortExpression="endtime" />
                    <asp:BoundField DataField="content" HeaderText="content" SortExpression="content" />
                </Columns>
            </asp:GridView>
            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
                <AlternatingItemTemplate>
                    <li style="background-color: #FFF8DC;">title:
                        <asp:DynamicControl runat="server" DataField="title" Mode="ReadOnly" />
                        <br />
                        releaser:
                        <asp:DynamicControl runat="server" DataField="releaser" Mode="ReadOnly" />
                        <br />
                        place:
                        <asp:DynamicControl runat="server" DataField="place" Mode="ReadOnly" />
                        <br />
                        endtime:
                        <asp:DynamicControl runat="server" DataField="endtime" Mode="ReadOnly" />
                        <br />
                        content:
                        <asp:DynamicControl runat="server" DataField="content" Mode="ReadOnly" />
                        <br />
                    </li>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <li style="background-color: #008A8C;color: #FFFFFF;">title:
                        <asp:DynamicControl runat="server" DataField="title" Mode="Edit" />
                        <br />
                        releaser:
                        <asp:DynamicControl runat="server" DataField="releaser" Mode="Edit" />
                        <br />
                        place:
                        <asp:DynamicControl runat="server" DataField="place" Mode="Edit" />
                        <br />
                        endtime:
                        <asp:DynamicControl runat="server" DataField="endtime" Mode="Edit" />
                        <br />
                        content:
                        <asp:DynamicControl runat="server" DataField="content" Mode="Edit" />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </li>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    未返回数据。
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <li style="">title:
                        <asp:DynamicControl runat="server" DataField="title" Mode="Insert" ValidationGroup="Insert" />
                        <br />releaser:
                        <asp:DynamicControl runat="server" DataField="releaser" Mode="Insert" ValidationGroup="Insert" />
                        <br />place:
                        <asp:DynamicControl runat="server" DataField="place" Mode="Insert" ValidationGroup="Insert" />
                        <br />endtime:
                        <asp:DynamicControl runat="server" DataField="endtime" Mode="Insert" ValidationGroup="Insert" />
                        <br />content:
                        <asp:DynamicControl runat="server" DataField="content" Mode="Insert" ValidationGroup="Insert" />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" ValidationGroup="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </li>
                </InsertItemTemplate>
                <ItemSeparatorTemplate>
<br />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <li style="background-color: #DCDCDC;color: #000000;">title:
                        <asp:DynamicControl runat="server" DataField="title" Mode="ReadOnly" />
                        <br />
                        releaser:
                        <asp:DynamicControl runat="server" DataField="releaser" Mode="ReadOnly" />
                        <br />
                        place:
                        <asp:DynamicControl runat="server" DataField="place" Mode="ReadOnly" />
                        <br />
                        endtime:
                        <asp:DynamicControl runat="server" DataField="endtime" Mode="ReadOnly" />
                        <br />
                        content:
                        <asp:DynamicControl runat="server" DataField="content" Mode="ReadOnly" />
                        <br />
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <li style="background-color: #008A8C;font-weight: bold;color: #FFFFFF;">title:
                        <asp:DynamicControl runat="server" DataField="title" Mode="ReadOnly" />
                        <br />
                        releaser:
                        <asp:DynamicControl runat="server" DataField="releaser" Mode="ReadOnly" />
                        <br />
                        place:
                        <asp:DynamicControl runat="server" DataField="place" Mode="ReadOnly" />
                        <br />
                        endtime:
                        <asp:DynamicControl runat="server" DataField="endtime" Mode="ReadOnly" />
                        <br />
                        content:
                        <asp:DynamicControl runat="server" DataField="content" Mode="ReadOnly" />
                        <br />
                    </li>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
