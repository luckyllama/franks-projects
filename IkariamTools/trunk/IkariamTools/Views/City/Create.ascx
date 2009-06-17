<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ICity>" %>
<%@ Import Namespace="IkariamTools.Data.Models" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="CityName">City Name:</label>
                <%= Html.TextBox("CityName") %>
                <%= Html.ValidationMessage("CityName", "*") %>
            </p>
            <p>
                <label for="PlayerName">Player Name:</label>
                <%= Html.TextBox("PlayerName")%>
                <%= Html.ValidationMessage("PlayerName", "*")%>
            </p>
            <p>
                <label for="X">X:</label>
                <%= Html.TextBox("X") %>
                <%= Html.ValidationMessage("X", "*") %>
            </p>
            <p>
                <label for="Y">Y:</label>
                <%= Html.TextBox("Y") %>
                <%= Html.ValidationMessage("Y", "*") %>
            </p>
            <p>
                <label for="ResourceType">ResourceType:</label>
                <%= Html.TextBox("ResourceType") %>
                <%= Html.ValidationMessage("ResourceType", "*") %>
            </p>
            <p>
                <label for="Size">Size:</label>
                <%= Html.TextBox("Size") %>
                <%= Html.ValidationMessage("Size", "*") %>
            </p>
            <p>
                <label for="Wall">Wall:</label>
                <%= Html.TextBox("Wall") %>
                <%= Html.ValidationMessage("Wall", "*") %>
            </p>
            <p>
                <label for="Warehouse">Warehouse:</label>
                <%= Html.TextBox("Warehouse") %>
                <%= Html.ValidationMessage("Warehouse", "*") %>
            </p>
            <p>
                <label for="IsCapital">IsCapital:</label>
                <%= Html.TextBox("IsCapital") %>
                <%= Html.ValidationMessage("IsCapital", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>


