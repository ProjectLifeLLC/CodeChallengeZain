<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarChooser.aspx.cs" Inherits="ProjLife_Zain_Test.CalendarChooser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 runat="server" id="h1Instruct" text="Choose a Calendar"/>
        <asp:DropDownList runat="server" ID="ddCalendarsList" OnDataBound="ddCalendarsList_OnDataBound"
        AutoPostBack="true" OnSelectedIndexChanged="ddCalendarsList_OnSelectedIndexChanged">
    </asp:DropDownList>
    </div>
    <asp:Panel runat="server" ID="pnlCalendarView">
        <asp:Repeater runat="server" ID="rptCalendarView" OnItemDataBound="rptCalendarView_ItemDataBound" Visible="false">
            <HeaderTemplate>
                <table>
                    <tr>
                 <th>Name</th>
                 <th>Sart Time</th>
                 <th>End Time</th>
              </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <td>
                    <asp:Label runat="server" ID="lblName" />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblStartTime" />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblEndTime" />
                </td>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
    </form>
</body>
</html>
