﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" Theme="Default" 
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

<div class="Box">
    <div class="BoxTitle">Favorites:</div>
    
    <ul>
        <asp:Literal ID="FavoritesDisplay" runat="server" />
    </ul>
    
    <div class="BottomBox"></div>
</div>

<form action="GeneralInfo.aspx" method="get">
    <div class="FormError">
        <asp:Literal ID="ErrorDisplay" runat="server" />
    </div>
    <div class="FormItem">
        <label for="n">Name:</label>
        <input type="text" id="n" name="n" />
    </div>
    <div class="FormItem">
        <label for="r">Realm:</label>
        <input type="text" id="r" name="r" />
    </div>
    <div class="FormOption">
        <input type="checkbox" id="favorite" name="favorite" checked="checked" />
        <label for="favorite">Save Character</label>
    </div>
    <div class="FormSubmit">
        <input type="submit" />
    </div>
</form>

</asp:Content>

