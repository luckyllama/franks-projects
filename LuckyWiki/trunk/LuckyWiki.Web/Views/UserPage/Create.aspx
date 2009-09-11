<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LuckyWiki.Data.IWikiPage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create UserPage
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% ViewData["Action"] = "Create"; %>
    <% Html.RenderPartial("PageEditedDetails"); %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <div class="FormItem PageContent">
                <label for="Content">Content:</label>
                <%= Html.TextArea("Content") %>
                <%= Html.ValidationMessage("Content", "*") %>
            </div>
            <div>
                <input type="submit" value="Create" />
            </div>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

