<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LuckyArmory.Web.Views.Home.Index" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    
    <div class="Box">
        <div class="BoxTitle">Favorites</div>
        
        <ul>
            <asp:Repeater ID="FavoritesRepeater" runat="server">
            <HeaderTemplate>
            <li>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="DataBox DataRow">
                    <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                    <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                    <div class="cleaner"></div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="DataBox DataRow Alt">
                    <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                    <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                    <div class="cleaner"></div>
                </div>
            </AlternatingItemTemplate>
            <FooterTemplate>
            </li>
            </FooterTemplate>
            </asp:Repeater>
        </ul>
        
        <div class="BottomBox"></div>
    </div>
    
    <div class="Box">
        <div class="BoxTitle">Character Lookup</div>
        
        <form action="/Home/LookUp" method="post">
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
                <!--input type="checkbox" id="Favorite" name="Favorite" checked="checked" /-->
                <%= Html.CheckBox("Favorite", "", "Save", true) %>
                <label for="Favorite">Save Character</label>
            </div>
            <div class="FormSubmit">
                <input type="submit" value="Get Character" />
            </div>
        </form>
        
        <div class="BottomBox"></div>
    </div>

</asp:Content>
