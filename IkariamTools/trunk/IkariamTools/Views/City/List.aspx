<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ICity>>" %>
<%@ Import Namespace="IkariamTools.Data.Models" %>
<%@ Import Namespace="IkariamTools.Data.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>

    <table class="CitiesTable">
        <tr>
            <th>City</th>
            <th>Player</th>
            <th>Coords</th>
            <th><div class="Resources">Resource</div></th>
            <th><div class="TownHall">Size</div></th>
            <th><div class="Wall">Wall</div></th>
            <th><div class="Warehouse">Warehouse</div></th>
            <th colspan="2"><div class="Wood">Wood</div></th>
            <th colspan="2"><div class="Wine">Wine</div></th>
            <th colspan="2"><div class="Marble">Marble</div></th>
            <th colspan="2"><div class="Crystal">Crystal</div></th>
            <th colspan="2"><div class="Sulphur">Sulphur</div></th>
            <th colspan="2">Total Resources</th>
            <th>Time</th>
        </tr>

    <% int index = -1; foreach (var item in Model) { %>
    
        <% if (index % 10 == 0) { %>
        
        <% } %>
    
        <tr id="City_<%= item.Id %>" class="<%= index++ % 2 == 0 ? "CityAlternateRow" : "" %>">
            <td nowrap="true">
                <div class="<%= (item.IsCapital == true) ? "Capital" : "" %>"">
                    <%= Html.Encode(item.CityName)%>
                </div>
            </td>
            <td>
                <%= Html.Encode(item.Player.PlayerName)%>
                <div class="PlayerScores">
                    <% if (!string.IsNullOrEmpty(item.Player.TotalScore.ToString())) { %>
                    <span class="TotalScore"><%= Html.Encode(string.Format("{0:0,0}", item.Player.TotalScore))%></span>
                    <% } %>
                    <% if (!string.IsNullOrEmpty(item.Player.MilitaryScore.ToString())) { %>
                    <span class="MilitaryScore"><%= Html.Encode(string.Format("{0:0,0}", item.Player.MilitaryScore))%></span>
                    <% } %>
                </div>
            </td>
            <td nowrap="true">
                <% if (item.X != null && item.Y != null) { %>
                <%= Html.Encode(item.X)%>:<%= Html.Encode(item.Y)%>
                <% } else { %>
                ??
                <% } %>
            </td>
            <td>
                <% if (item.Resource != IkariamTools.Data.Models.ResourceType.Unknown) %>
                <div class="<%= Html.Encode(item.Resource.ToString()) %>"><%= Html.Encode(item.Resource.ToString())%></div>
            </td>
            <td>
                <%= Html.Encode(item.Size)%>
            </td>
            <td>
                <%= Html.Encode(item.Wall)%>
            </td>
            <td>
                <%= Html.Encode(item.Warehouse)%>
            </td>
            <td class="LootableResourceQuantity ResourceAlternateColumn">
                <% if (item.SpyReports.Count > 0) { %>
                <%= Html.Encode(SpyReportUtility.GetLootableQuantity(item.SpyReports[0].WoodQuantity, (int)item.Warehouse))%>
                <% } %>
            </td>
            <td class="TotalResourceQuantity ResourceAlternateColumn">
                <% if (item.SpyReports.Count > 0) { %>
                (<%= Html.Encode(item.SpyReports[0].WoodQuantity)%>)
                <% } else { %>
                ??
                <% } %>
            </td>
            <td class="LootableResourceQuantity">
                <% if (item.SpyReports.Count > 0) { %>
                <%= Html.Encode(SpyReportUtility.GetLootableQuantity(item.SpyReports[0].WineQuantity, (int)item.Warehouse))%>
                <% } %>
            </td>
            <td class="TotalResourceQuantity">
                <% if (item.SpyReports.Count > 0) { %>
                (<%= Html.Encode(item.SpyReports[0].WineQuantity)%>)
                <% } else { %>
                ??
                <% } %>
            </td>
            <td class="LootableResourceQuantity ResourceAlternateColumn">
                <% if (item.SpyReports.Count > 0) { %>
                <%= Html.Encode(SpyReportUtility.GetLootableQuantity(item.SpyReports[0].MarbleQuantity, (int)item.Warehouse))%>
                <% } %>
            </td>
            <td class="TotalResourceQuantity ResourceAlternateColumn">
                <% if (item.SpyReports.Count > 0) { %>
                (<%= Html.Encode(item.SpyReports[0].MarbleQuantity)%>)
                <% } else { %>
                ??
                <% } %>
            </td>
            <td class="LootableResourceQuantity">
                <% if (item.SpyReports.Count > 0) { %>
                <%= Html.Encode(SpyReportUtility.GetLootableQuantity(item.SpyReports[0].CrystalQuantity, (int)item.Warehouse))%>
                <% } %>
            </td>
            <td class="TotalResourceQuantity">
                <% if (item.SpyReports.Count > 0) { %>
                (<%= Html.Encode(item.SpyReports[0].CrystalQuantity)%>)
                <% } else { %>
                ??
                <% } %>
            </td>
            <td class="LootableResourceQuantity ResourceAlternateColumn">
                <% if (item.SpyReports.Count > 0) { %>
                <%= Html.Encode(SpyReportUtility.GetLootableQuantity(item.SpyReports[0].SulphurQuantity, (int)item.Warehouse))%>
                <% } %>
            </td>
            <td class="TotalResourceQuantity ResourceAlternateColumn">
                <% if (item.SpyReports.Count > 0) { %>
                (<%= Html.Encode(item.SpyReports[0].SulphurQuantity)%>)
                <% } else { %>
                ??
                <% } %>
            </td>
            <td class="LootableResourcesQuantity">
                <% if (item.SpyReports.Count > 0) { %>
                <%= Html.Encode(SpyReportUtility.GetTotalLootableQuantity(item.SpyReports[0], (int)item.Warehouse))%>
                <% } %>
            </td>
            <td class="TotalResourcesQuantity">
                <% if (item.SpyReports.Count > 0) { %>
                (<%= Html.Encode(SpyReportUtility.GetTotalQuantity(item.SpyReports[0])) %>)
                <% } else { %>
                ??
                <% } %>
            </td>
            <td>
                <% if (item.SpyReports.Count > 0) { %>
                <%= Html.Encode(item.SpyReports[0].Date.AddHours(-7.0)) %> (CST)
                <% } %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <div id="NewCity">
        <% Html.BeginForm("NewCity", "City"); %>
        
        <% Html.EndForm(); %>
    </div>

</asp:Content>

