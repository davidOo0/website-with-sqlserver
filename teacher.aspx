<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacher.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="查询学生信息" />
    <br />
    <asp:Panel ID="Panel1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DataGrid ID="stu_dg1" runat="server" 
            onselectedindexchanged="stu_dg1_SelectedIndexChanged1" Width="723px" 
            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" 
            style="margin-left: 37px" AllowPaging="True" 
            oncancelcommand="stu_dg1_CancelCommand" ondeletecommand="stu_dg1_DeleteCommand" 
            oneditcommand="stu_dg1_EditCommand" onitemcreated="stu_dg1_ItemCreated" 
            onupdatecommand="stu_dg1_UpdateCommand">
            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:EditCommandColumn CancelText="取消" EditText="编辑" UpdateText="更新">
                </asp:EditCommandColumn>
                <asp:ButtonColumn CommandName="Delete" Text="删除" ButtonType="PushButton"></asp:ButtonColumn>
            </Columns>
            <EditItemStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:DataGrid>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="添加学生" />
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel2" runat="server" Height="37px">
        <asp:Label ID="Label1" runat="server" Text="学号"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="姓名"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="性别"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="生日"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="成绩"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="班级"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="确认" />
    </asp:Panel>
    </form>
</body>
</html>
