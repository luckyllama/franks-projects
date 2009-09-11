<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LuckyWiki.Data.IWikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% ViewData["Action"] = "Create"; %>
    <% Html.RenderPartial("PageEditedDetails"); %>
    
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <div class="FormItem PageTitle">
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title", Model.Title) %>
                <%= Html.ValidationMessage("Title", "*") %>
            </div>
            <div class="FormItem PageContent">
                <label for="Content">Content:</label>
                <%= Html.TextArea("Content", new { rows = 10 })%>
                <%= Html.ValidationMessage("Content", "*") %>
            </div>
            <div>
                <input type="submit" value="Create" />
            </div>
        </fieldset>

    <% } %>

</asp:Content>

