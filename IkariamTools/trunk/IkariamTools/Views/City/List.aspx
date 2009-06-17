<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ICity>>" %>

<%@ Import Namespace="IkariamTools.Data.Models" %>
<%@ Import Namespace="IkariamTools.Data.Utility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List</h2>
    <div id="Filters" style="display: none;">
        <% Html.BeginForm("Filter", "City"); %>
        <div class="Filter">
            <select class="FilterType" id="FilterType_1" name="FilterType_1">
                <option>Radius:</option>
                <option>Resource Type:</option>
                <option>City Name:</option>
                <option>Player Name:</option>
                <option>Town Hall Level:</option>
                <option>Wall Level:</option>
                <option>Minimum Loot:</option>
                <option>Warehouse Level:</option>
                <option>Military Score:</option>
            </select>
        </div>
        <% Html.EndForm(); %>
    </div>
    <table class="CitiesTable">
        <thead>
            <tr>
                <th colspan="3">
                    City
                </th>
                <th>
                    Player
                </th>
                <th>
                    <div class="TownHall">
                        Size</div>
                </th>
                <th>
                    <div class="Wall">
                        Wall</div>
                </th>
                <th>
                    <div class="Warehouse">
                        Warehouse</div>
                </th>
                <th colspan="2">
                    <div class="Wood">
                        Wood</div>
                </th>
                <th colspan="2">
                    <div class="Wine">
                        Wine</div>
                </th>
                <th colspan="2">
                    <div class="Marble">
                        Marble</div>
                </th>
                <th colspan="2">
                    <div class="Crystal">
                        Crystal</div>
                </th>
                <th colspan="2">
                    <div class="Sulphur">
                        Sulphur</div>
                </th>
                <th colspan="2">
                    Total Resources
                </th>
                <th>
                    Time
                </th>
            </tr>
        </thead>
        <tbody>
            <% int index = 1; foreach (var item in Model) { %>
            <% if (index % 16 == 0) { %>
            <tr>
                <th colspan="3">
                    City
                </th>
                <th>
                    Player
                </th>
                <th>
                    <div class="TownHall">
                        Size</div>
                </th>
                <th>
                    <div class="Wall">
                        Wall</div>
                </th>
                <th>
                    <div class="Warehouse">
                        Warehouse</div>
                </th>
                <th colspan="2">
                    <div class="Wood">
                        Wood</div>
                </th>
                <th colspan="2">
                    <div class="Wine">
                        Wine</div>
                </th>
                <th colspan="2">
                    <div class="Marble">
                        Marble</div>
                </th>
                <th colspan="2">
                    <div class="Crystal">
                        Crystal</div>
                </th>
                <th colspan="2">
                    <div class="Sulphur">
                        Sulphur</div>
                </th>
                <th colspan="2">
                    Total Resources
                </th>
                <th>
                    Last Action
                </th>
            </tr>
            <% } %>
            <tr id="City_<%= item.Id %>" class="CityRow <%= index % 2 == 0 ? "CityAlternateRow" : "" %>"
                onclick="CityRow_OnClick(<%= item.Id %>);">
                <td nowrap="nowrap">
                    <% if (item.Resource != IkariamTools.Data.Models.ResourceType.Unknown) %>
                    <span class="<%= Html.Encode(item.Resource.ToString()) %>">
                        <%= Html.Encode(item.Resource.ToString())%></span>
                </td>
                <td nowrap="nowrap">
                    <%= Html.Encode(item.CityName)%>
                </td>
                <td nowrap="nowrap">
                    <span class="Coordinates">
                        <% if (item.X != null && item.Y != null) { %>
                        (<%= Html.Encode(item.X)%>,<%= Html.Encode(item.Y)%>)
                        <% } else { %>
                        (?,?)
                        <% } %>
                    </span>
                </td>
                <td>
                    <%= Html.Encode(item.Player.PlayerName)%>
                    <div class="PlayerScores">
                        <% if (!string.IsNullOrEmpty(item.Player.TotalScore.ToString())) { %>
                        <span class="TotalScore">
                            <%= Html.Encode(string.Format("{0:0,0}", item.Player.TotalScore))%></span>
                        <% } %>
                        <% if (!string.IsNullOrEmpty(item.Player.MilitaryScore.ToString())) { %>
                        <span class="MilitaryScore">
                            <%= Html.Encode(string.Format("{0:0,0}", item.Player.MilitaryScore))%></span>
                        <% } %>
                    </div>
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
                    <% if (item.TotalWoodQuantity() >= 0) { %>
                    <span title="Total: <%= item.TotalWoodQuantity() >= 0 ? item.TotalWoodQuantity().ToString() : "??" %>" class="Tooltip">
                    <% if (item.TotalLootableWoodQuantity() >= 0) { %>
                    <%= item.TotalLootableWoodQuantity()%>
                    <% } else { %>
                        <%= item.TotalWoodQuantity() %>
                    <% } %>
                    </span>
                    <% } else { %>
                    <span title="Unknown Wood Quantity" class="Tooltip">??</span>
                    <% } %>
                </td>
                <td class="TotalResourceQuantity ResourceAlternateColumn">
                    <% if (item.TotalWoodQuantity() >= 0) { %>
                    (<%= Html.Encode(item.TotalWoodQuantity()) %>)
                    <% } else { %>
                    ??
                    <% } %>
                </td>
                <td class="LootableResourceQuantity">
                    <% if (item.TotalLootableWineQuantity() >= 0) { %>
                    <%= Html.Encode(item.TotalLootableWineQuantity()) %>
                    <% } %>
                </td>
                <td class="TotalResourceQuantity">
                    <% if (item.TotalWineQuantity() >= 0) { %>
                    (<%= Html.Encode(item.TotalWineQuantity()) %>)
                    <% } else { %>
                    ??
                    <% } %>
                </td>
                <td class="LootableResourceQuantity ResourceAlternateColumn">
                    <% if (item.TotalLootableWineQuantity() >= 0) { %>
                    <%= Html.Encode(item.TotalLootableWineQuantity()) %>
                    <% } %>
                </td>
                <td class="TotalResourceQuantity ResourceAlternateColumn">
                    <% if (item.TotalMarbleQuantity() >= 0) { %>
                    (<%= Html.Encode(item.TotalMarbleQuantity()) %>)
                    <% } else { %>
                    ??
                    <% } %>
                </td>
                <td class="LootableResourceQuantity">
                    <% if (item.TotalLootableCrystalQuantity() >= 0) { %>
                    <%= Html.Encode(item.TotalLootableCrystalQuantity()) %>
                    <% } %>
                </td>
                <td class="TotalResourceQuantity">
                    <% if (item.TotalCrystalQuantity() >= 0) { %>
                    (<%= Html.Encode(item.TotalCrystalQuantity()) %>)
                    <% } else { %>
                    ??
                    <% } %>
                </td>
                <td class="LootableResourceQuantity ResourceAlternateColumn">
                    <% if (item.TotalLootableSulphurQuantity() >= 0) { %>
                    <%= Html.Encode(item.TotalLootableSulphurQuantity()) %>
                    <% } %>
                </td>
                <td class="TotalResourceQuantity ResourceAlternateColumn">
                    <% if (item.TotalSulphurQuantity() >= 0) { %>
                    (<%= Html.Encode(item.TotalSulphurQuantity()) %>)
                    <% } else { %>
                    ??
                    <% } %>
                </td>
                <td class="LootableResourcesQuantity">
                    <% if (item.TotalLootableQuantity() >= 0) { %>
                    <%= Html.Encode(item.TotalLootableQuantity()) %>
                    <% } %>
                </td>
                <td class="TotalResourcesQuantity">
                    <% if (item.TotalResourceQuantity() >= 0) { %>
                    (<%= Html.Encode(item.TotalResourceQuantity()) %>)
                    <% } else { %>
                    ??
                    <% } %>
                </td>
                <td>
                    <% if (!string.IsNullOrEmpty(item.LastActionType())) { %>
                    <div class="LastActionTime"><%= Html.Encode(((DateTime)item.LastAction()).AddHours(-7.0)) %> (CST)</div>
                    <div class="LastActionType"><%= Html.Encode(item.LastActionType()) %></div>
                    <% } %>
                </td>
            </tr>
            <tr id="CityMoreDetails_<%= item.Id %>" class="CityMoreDetails <%= index % 2 == 0 ? "CityAlternateRow" : "" %>">
                <td colspan="3">
                    <% if (item.IsCapital.HasValue && (bool)item.IsCapital) { %>
                    Capital
                    <% } %>
                </td>
                <td>
                    &nbsp;
                </td>
                <td colspan="3">
                    &nbsp;
                </td>
                <td colspan="13">
                    <div id="SpyReports_<%= item.Id %>" class="SpyReports">
                        <div class="SpyReportsSelect">
                            <label for="SpyReportsSelect_<%= item.Id %>">Spy Reports: </label>
                            <select id="SpyReportsSelect_<%= item.Id %>" name="SpyReportsSelect_<%= item.Id %>" onchange="SpyReportsSelect_OnChange(<%= item.Id %>);">
                                <option id="">Select Report</option>
                                <% foreach (ISpyReport report in item.SpyReports) { %>
                                <option value="SpyReport_<%= item.Id %>_<%= report.Id %>">
                                    <%= TimeZone.CurrentTimeZone.ToLocalTime(report.Date).ToString() %>
                                </option>
                                <% } %>
                            </select>
                        </div>
                        
                        <% foreach (ISpyReport report in item.SpyReports) { %>
                            <div id="SpyReport_<%= item.Id %>_<%= report.Id %>" class="SpyReport">
                                <div class="Wood"><%= report.WoodQuantity %></div>
                                <div class="Wine"><%= report.WineQuantity %></div>
                                <div class="Marble"><%= report.MarbleQuantity%></div>
                                <div class="Crystal"><%= report.CrystalQuantity%></div>
                                <div class="Sulphur"><%= report.SulphurQuantity%></div>
                            </div>
                        <% } %>
                        <br class="Clear" />
                    </div>
                </td>
            </tr>
            <tr id="CityNotes_<%= item.Id %>" class="CityNotes <%= index % 2 == 0 ? "CityAlternateRow" : "" %>">
                <td colspan="20">
                    Notes: <%= Html.Encode(item.Notes) %>
                </td>
            </tr>
            
            <% index++; %>
            <% } %>
        </tbody>
    </table>
    <div id="NewCity">
        <%--<% Html.RenderPartial("~/Views/City/Create.ascx"); %>--%>
    </div>
</asp:Content>
