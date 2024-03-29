<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<IkariamTools.LinqToSql.Player>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                PlayerName
            </th>
            <th>
                TotalScore
            </th>
            <th>
                MilitaryScore
            </th>
            <th>
                IsActive
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.Id })%>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.PlayerName) %>
            </td>
            <td>
                <%= Html.Encode(item.TotalScore) %>
            </td>
            <td>
                <%= Html.Encode(item.MilitaryScore) %>
            </td>
            <td>
                <%= Html.Encode(item.IsActive) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

