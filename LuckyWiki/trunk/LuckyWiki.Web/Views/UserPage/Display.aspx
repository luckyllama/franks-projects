<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LuckyWiki.Data.IWikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.Encode(Model.Title) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% ViewData["Action"] = "Display"; %>
    <% Html.RenderPartial("PageEditedDetails"); %>

    <div id="PageContent">
        <%= Html.Encode(Model.Content) %>
    </div>

</asp:Content>

