<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>AbiKursGenerator</h1>
        <p class="lead">LOOOOOOOOSt</p>
        <p>
            <table style="width:100%;">
                <tr>
                    <td style="height: 30px; width: 146px; font-size: large;" aria-label="F">Leistungskurs 1</td>
                    <td style="height: 30px; width: 146px;"><span style="font-size: large">Leistungskurs 2</td>
                    <td style="height: 30px; width: 146px;"><span style="font-size: large">Grundkurs</span> 1</td>
                    <td style="height: 30px; width: 146px; font-size: large;">Grundkurs 2</td>
                    <td style="height: 30px; width: 146px; font-size: large;">grundKurs 1</td>
                    <td style="height: 30px; width: 146px; font-size: large;">grundKurs 2</td>
                    <td style="height: 30px; width: 146px; font-size: large;">AN KURS 1</td>
                    <td style="height: 30px; width: 146px;"></span><span style="font-size: large">AN KURS 2</span></td>
                </tr>
                <tr>
                    <td class="modal-lg" style="width: 146px">
                        <asp:DropDownList ID="DDP_LK1" runat="server" AutoPostBack="True" OnClientClick="return false;" Width="120px" OnTextChanged="UsedDropdron">
                            <asp:ListItem>Not Loaded</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDP_LK2" runat="server" AutoPostBack="True" OnClientClick="return false;" Width="120px" OnTextChanged="UsedDropdron">
                            <asp:ListItem>Not Loaded</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 118px">
                        <asp:DropDownList ID="DDP_SGK1" runat="server" AutoPostBack="True" Width="120px" OnTextChanged="UsedDropdron">
                            <asp:ListItem>Not Loaded</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDP_SGK2" runat="server" AutoPostBack="True" Width="120px" OnTextChanged="UsedDropdron">
                            <asp:ListItem>Not Loaded</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDP_MGK1" runat="server" AutoPostBack="True" Width="120px" OnTextChanged="UsedDropdron">
                            <asp:ListItem>Not Loaded</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDP_MGK2" runat="server" AutoPostBack="True" Width="120px" OnTextChanged="UsedDropdron">
                            <asp:ListItem>Not Loaded</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDP_AK1" runat="server" AutoPostBack="True" Width="120px" OnTextChanged="UsedDropdron">
                            <asp:ListItem>Not Loaded</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDP_AK2" runat="server" AutoPostBack="True" Width="120px" OnTextChanged="UsedDropdron">
                            <asp:ListItem>Not Loaded</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Kurse auswählen</h2>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            </asp:UpdatePanel>
            <p>
                Wähle in den verschiedenen Menüs deine Kurse, dabei beachtet der AbiKursGenerator Kurs regeln und zeigt dir nur mögliche kombinationen an, was deine auswahl vereinfacht!</p>
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
            <h2>Auswahl speichern</h2>
            <p>
                Es ist momentan noch nicht möglich, die Kursauswahl zu speicher. Um diese jedoch nicht zu verlieren, kannst du ein Screenshoot davon machen.</p>
            <p>
                &nbsp;</p>
        </div>
    </div>
</asp:Content>
