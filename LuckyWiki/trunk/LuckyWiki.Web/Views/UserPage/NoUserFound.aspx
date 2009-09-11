<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	No User Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>No User Found</h2>
    <% if (ViewData["QueriedUser"] == null || string.IsNullOrEmpty(ViewData["QueriedUser"].ToString())) { %>
    <p>No user was specified.</p>
    <% } else { %>
    <p>The user &#147;<%= Html.Encode(ViewData["QueriedUser"]) %>&#148; cannot be found. Please check your spelling and try again.</p>
    <% } %>

</asp:Content>
