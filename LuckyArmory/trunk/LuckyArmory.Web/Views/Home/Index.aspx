<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LuckyArmory.Web.Views.Home.Index" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <dl id="FavoritesSection">
        <dt class="Header">
            Favorites:
        </dt>
        <dt class="Info">
        <asp:Repeater ID="FavoritesRepeater" runat="server">
        <ItemTemplate>
            <div class="FavoriteRow">
                <span class="Left"><a href="/Info/General<%# DataBinder.Eval(Container, "DataItem.Value") %>"><%# DataBinder.Eval(Container, "DataItem.Key") %></a></span>
                <span class="Right"><a href="#" class="DeleteIcon"></a></span>
                <div class="cleaner"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="FavoriteRow Alt">
                <span class="Left"><a href="/Info/General<%# DataBinder.Eval(Container, "DataItem.Value") %>"><%# DataBinder.Eval(Container, "DataItem.Key") %></a></span>
                <span class="Right"><a href="#" class="DeleteIcon"></a></span>
                <div class="cleaner"></div>
            </div>
        </AlternatingItemTemplate>
        </asp:Repeater>
        </dt>
    </dl>
    
    <dl id="CharacterLookupForm">
        <dt class="Header">
            Character Lookup:
        </dt>
        <dt class="Info">        
        <form id="LookupForm" action="/Home/LookUp" method="post">
            <div class="FormError">
                <%= Html.Encode(ViewData["ErrorMessage"]) %>
            </div>
            <div class="FormItem">
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name") %>
            </div>
            <div class="FormItem">
                <label for="Realm">Realm:</label>
                <%= Html.TextBox("Realm") %>
            </div>
            <div class="FormOption">
                <input type="checkbox" id="Favorite" name="Favorite" checked="checked" value="Save" />
                <% //Html.CheckBox("Favorite", "", "Save", true) %>
                <label for="Favorite">Save Character</label>
            </div>
            <div class="FormSubmit">
                <input type="submit" visible="false" />
            </div>
        </form>    
        </dt>
    </dl>
    
    <a href="#Submit" onclick="$('#LookupForm').submit()" class="Button">Get Character</a>

</asp:Content>
