﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LuckyArmory.Web.Views.Home.Index" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <dl id="FavoritesSection">
        <dt class="Header">
            Favorites:
        </dt>
        <dd class="Show">
        <asp:Repeater ID="FavoritesRepeater" runat="server">
        <ItemTemplate>
            <div class="FavoriteRow">
                <span class="Left"><a href="/Info/General<%# DataBinder.Eval(Container, "DataItem.Value") %>"><%# DataBinder.Eval(Container, "DataItem.Key") %></a></span>
                <span class="Right"><a href="/Home/Delete<%# DataBinder.Eval(Container, "DataItem.Value") %>" class="DeleteIcon" onclick="return confirm('Are you sure you want to delete this favorite character?');"></a></span>
                <div class="cleaner"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="FavoriteRow Alt">
                <span class="Left"><a href="/Info/General<%# DataBinder.Eval(Container, "DataItem.Value") %>"><%# DataBinder.Eval(Container, "DataItem.Key") %></a></span>
                <span class="Right"><a href="/Home/Delete<%# DataBinder.Eval(Container, "DataItem.Value") %>" class="DeleteIcon" onclick="return confirm('Are you sure you want to delete this favorite character?');"></a></span>
                <div class="cleaner"></div>
            </div>
        </AlternatingItemTemplate>
        </asp:Repeater>
        </dd>
    </dl>
    
    <dl id="CharacterLookupForm">
        <dt class="Header">
            Character Lookup:
        </dt>
        <dt class="Info">
        <form id="LookupForm" action="<%= Url.Action("LookUp", "Home") %>" method="post">
            <div class="FormError">
                <%= Html.Encode(ViewData["ErrorMessage"]) %>
            </div>
            <div class="FormItem">
                <label for="Name">Name:</label>
                <input type="text" id="Name" name="Name" />
            </div>
            <div class="FormItem">
                <label for="Realm">Realm:</label>
                <input type="text" id="Realm" name="Realm" />
            </div>
            <div class="FormOption">
                <input type="checkbox" id="Favorite" name="Favorite" checked="checked" value="Save" />
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
