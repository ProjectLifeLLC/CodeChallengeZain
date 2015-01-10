<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarChooser.aspx.cs" Inherits="ProjLife_Zain_Test.CalendarChooser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblInstruct"></asp:Label>
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
               <tr>
                <td>
                    <asp:Label runat="server" ID="lblName" />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblStartTime" />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblEndTime" />
                </td>
               </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
        <asp:Panel runat="server" ID="pnlNewEvent" Visible="false" CssClass="padding-top: 5cm;">
                <asp:Label runat="server" ID="lblNewEventSummary" Text="Event Name"></asp:Label>
                <asp:TextBox runat="server" ID="tbxNewEventSummary"></asp:TextBox>
                <br />
                <asp:Label runat="server" ID="lblNewEventStartTime" Text="Start Time"></asp:Label>
                <asp:Calendar ID="cldrNewEventStartTime" runat="server"></asp:Calendar>
                <asp:Label runat="server" ID="lblNewEventEndTime" Text="End Time"></asp:Label>
                <asp:Calendar ID="cldrNewEventEndTime" runat="server"></asp:Calendar>
                <asp:Button runat="server" ID="btnNewEvent" Text="Add New Event" OnClick="btnNewEvent_Click"/>
        </asp:Panel>
    </form>
</body>
</html>
