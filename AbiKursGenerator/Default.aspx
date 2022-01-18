<%@ Page Title="AbiKursGenerator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>AbiKursGenerator</h1>
        <p class="lead">&nbsp;</p>
        <p>
        </p>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table style="width:100%;">
                    <tr style="font-size: 15pt">
                        <td aria-label="F" style="height: 30px; width: 146px; font-size: 13pt;">Leistungskurs 1</td>
                        <td style="height: 30px; width: 146px;"><span style="font-size: 13pt">Leistungskurs 2</span></td>
                        <td style="height: 30px; width: 146px;"><span style="font-size: 13pt">Grundkurs 1</span></td>
                        <td style="height: 30px; width: 146px; font-size: 13pt;">Grundkurs 2</td>
                        <td style="height: 30px; width: 146px; font-size: 13pt;">Mündlich 1</td>
                        <td style="height: 30px; width: 146px; font-size: 13pt;">Mündlich 2</td>
                        <td style="height: 30px; width: 146px; font-size: 13pt;">Anrechnung 1</td>
                        <td style="height: 30px; width: 146px; font-size: 13pt;"><span></span></span style="font-size: medium">Anrechnung 2</td>
                    </tr>
                    <tr>
                        <td class="modal-lg" style="width: 146px">
                            <asp:DropDownList ID="DDP_LK1" runat="server" OnClientClick="return false;" Width="120px">
                                <asp:ListItem>- Nichts -</asp:ListItem>
                                <asp:ListItem>Deutsch</asp:ListItem>
                                <asp:ListItem>Mathematik</asp:ListItem>
                                <asp:ListItem>Englisch</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDP_LK2" runat="server" OnClientClick="return false;" Width="120px">
                                <asp:ListItem>- Nichts -</asp:ListItem>
                                <asp:ListItem>Deutsch</asp:ListItem>
                                <asp:ListItem>Englisch</asp:ListItem>
                                <asp:ListItem>Mathematik</asp:ListItem>
                                <asp:ListItem>Biologie</asp:ListItem>
                                <asp:ListItem>Chemie</asp:ListItem>
                                <asp:ListItem>Bildende Kunst</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 118px">
                            <asp:DropDownList ID="DDP_SGK1" runat="server" Width="120px">
                                <asp:ListItem>- Nichts -</asp:ListItem>
                                <asp:ListItem>Geographie</asp:ListItem>
                                <asp:ListItem>Politikwissenschaft</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDP_SGK2" runat="server" Width="120px">
                                <asp:ListItem>- Nichts -</asp:ListItem>
                                <asp:ListItem>Deutsch</asp:ListItem>
                                <asp:ListItem>Englisch</asp:ListItem>
                                <asp:ListItem>Mathematik</asp:ListItem>
                                <asp:ListItem>Chemie</asp:ListItem>
                                <asp:ListItem>Biologie</asp:ListItem>
                                <asp:ListItem>Politikwissenschaft</asp:ListItem>
                                <asp:ListItem>Geographie</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDP_MGK1" runat="server" Width="120px">
                                <asp:ListItem>- Nichts -</asp:ListItem>
                                <asp:ListItem>Russisch</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDP_MGK2" runat="server" Width="120px">
                                <asp:ListItem>- Nichts -</asp:ListItem>
                                <asp:ListItem>Englisch</asp:ListItem>
                                <asp:ListItem>Deutsch</asp:ListItem>
                                <asp:ListItem>Politikwissenschaft</asp:ListItem>
                                <asp:ListItem>Geographie</asp:ListItem>
                                <asp:ListItem>Chemie</asp:ListItem>
                                <asp:ListItem>Biologie</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDP_AK1" runat="server" Width="120px">
                                <asp:ListItem>- Nichts -</asp:ListItem>
                                <asp:ListItem>Darstellendes Spiel</asp:ListItem>
                                <asp:ListItem>Chemie</asp:ListItem>
                                <asp:ListItem>Biologie</asp:ListItem>
                                <asp:ListItem>Politikwissenschaft</asp:ListItem>
                                <asp:ListItem>Geographie</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDP_AK2" runat="server" Width="120px">
                                <asp:ListItem>- Nichts -</asp:ListItem>
                                <asp:ListItem>Darstellendes Spiel</asp:ListItem>
                                <asp:ListItem>Chemie</asp:ListItem>
                                <asp:ListItem>Biologie</asp:ListItem>
                                <asp:ListItem>Politikwissenschaft</asp:ListItem>
                                <asp:ListItem>Geographie</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:Button ID="CheckRulesButton" runat="server" Height="38px" OnClick="CheckButtonClicked" Text="Kursauswahl überprüfen" Width="213px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SaveKursButton" runat="server" Height="38px" OnClick="SaveButtonClicked" Text="Kursauswahl speichern" Width="213px" Visible="False" />
        <br />
        <br />
        <br />
        
    <div class="row">
        <div class="col-md-4">
            <asp:Panel ID="CheckListPanel" runat="server" Visible="False" Width="308px">
                    <asp:Label ID="ResultHeader" runat="server" Font-Bold="True">Auswahl Check:</asp:Label>
                    <br />
                    <asp:Label ID="RuleText1" runat="server" Font-Bold="False"></asp:Label>
                    <br />
                    <asp:Label ID="RuleText2" runat="server" Font-Bold="False"></asp:Label>
                    <br />
                    <asp:Label ID="RuleText3" runat="server" Font-Bold="False"></asp:Label>
                    <br />
                    <asp:Label ID="RuleText4" runat="server" Font-Bold="False"></asp:Label>
                    <br />
                    <asp:Label ID="RuleText5" runat="server" Font-Bold="False"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="ResultText" runat="server" Font-Bold="True"></asp:Label>
                </asp:Panel>
        </div>
        <div class="col-md-4">
            <asp:Panel ID="SaveKursPanel" runat="server" Visible="False" Width="320px">
                    <strong>Kursauswahl:&nbsp; </strong>
                    (Kopieren: STRG + C)<strong><br />
                    <br />
                    Leistungskurs 1:&nbsp;&nbsp;
                    <asp:Label ID="LK1_SaveText" runat="server"></asp:Label>
                    <br />
                    Leistungskurs 2:&nbsp;&nbsp;
                    <asp:Label ID="LK2_SaveText" runat="server"></asp:Label>
                    <br />
                    s. Grundkurs&nbsp;&nbsp; 1:&nbsp;&nbsp;
                    <asp:Label ID="SGK1_SaveText" runat="server"></asp:Label>
                    <br />
                    s. Grundkurs&nbsp;&nbsp; 2:&nbsp;&nbsp;
                    <asp:Label ID="SGK2_SaveText" runat="server"></asp:Label>
                    <br />
                    m. Grundkurs&nbsp; 1:<br /> m. Grundkurs&nbsp; 2:<br /> Anrechnungs. 1:<br /> Anrechnungs. 2:<br />
                    <br />
                    <br />
                    </strong>
                </asp:Panel>
        </div>
    </div>
               
        <br />
        <br />
        <div style="width: 1340px">
            <asp:Panel ID="Panel1" runat="server">
                <strong><span style="font-size: large">Bedingungen</span><br />
                <br />
                Bedingung 1:<br /> </strong>Unter den Prüfungsfächern* befinden sich die Fächer Deutsch, Geographie oder ein
                <br />
                anderes gesellschaftwissenschaftliches Fach, Mathematik, eine Naturwissenschaft und zwei Fremdsprachen.<strong><br />
                <br />
                Bedingung 2:<br /> </strong>Aus jedem der genannten <strong>Aufgabenfelder</strong> wurde mindestens ein schriftliches Prüfungsfach gewählt.<strong><br />
                <br />
                Bedingung 3:<br /> </strong>Unter den Fächern der schriftlichen Prüfung** befindet sich das Fach Mathematik und eines der Fächer Deutsch oder eine Fremdsprache.<br />
                <br />
                *alle Kurse<br /> **LK1-2 und schrift. GK1-2</asp:Panel>
            <br />
            <br />
            <span style="font-size: large"><strong>Aufgabenfelder<br />
            <br />
            </strong></span>
            <span style="font-size: medium">Aufgabenfeld I:&nbsp;&nbsp;&nbsp; Deutsch, Englisch, Russisch, Bildende Kunst, Darststellendes Spiel<strong><br />
            <br />
            </strong>Aufgabenfeld II:&nbsp;&nbsp; Geografie, Politikwissenschaft<strong><br />
            <br />
            </strong>Aufgabenfeld III:&nbsp; Mathematik, Biologie, Chemie</span></div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Kurse auswählen</h2>
            <p>
                Wähle zuerst deine lieblings Kurspräferenzen, berücksichtige dabei am besten bereits die Bedingungen.</p>
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
            <h2>Auswahl überprüfen</h2>
            <p>
                Mit einem klick auf den Knopf &quot;Kursauswahl Überprüfen&quot; kannst du gucken ob deine Kursauswahl regelkonform ist.</p>
        </div>
        <div class="col-md-4">
            <h2>Kursauswahl speichern</h2>
            <p>
                Es ist momentan noch nicht möglich, die Kursauswahl zu speicher. Um diese jedoch nicht zu verlieren, kannst du ein Screenshot davon machen.</p>
            <p>
                <strong>Windows:</strong> WIN + SHIFT + S)</p>
            <p>
                <strong>Mac:</strong> CMD + SHIFT + 4</p>
        </div>
    </div>
</asp:Content>
