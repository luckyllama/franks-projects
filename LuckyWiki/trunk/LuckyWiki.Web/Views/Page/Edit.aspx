<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LuckyWiki.Data.IWikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% ViewData["Action"] = "Edit"; %>
    <% Html.RenderPartial("PageEditedDetails"); %>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <div class="FormItem PageContent">
                <label for="Content">Content:</label>
                <%= Html.TextArea("Content", Model.Content, new { rows = 10 })%>
                <%= Html.ValidationMessage("Content", "*") %>
            </div>
            <div>
                <input type="submit" value="Save" />
            </div>
        </fieldset>

    <% } %>

</asp:Content>

