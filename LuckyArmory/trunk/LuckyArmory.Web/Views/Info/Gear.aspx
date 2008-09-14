<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Gear.aspx.cs" Inherits="LuckyArmory.Web.Views.Info.Gear" %>

<asp:Content ID="GearContent" ContentPlaceHolderID="MainContent" runat="server">
    
<script type="text/javascript">
    $(function() {
        $('a[rel*=facebox]').facebox();
        $(".Tooltip").hide();
        $("div.GearItem").each(function() {
            var id = $(this).attr("id");
            var path = "/Info/Item/" + id;

            $.getJSON(path, function(data) {
                var name = $("wowhead", data).text();
                //$("#" + id).find(".Name").text(data);
                $("#" + id).find(".Name").text(data.Name);
                $("#" + id).find(".Name").addClass(data.Quality);
                $("#Tooltip" + id).html(data.HtmlTooltip);
            });
        });
    });
</script>

<asp:Repeater ID="GearRepeater" runat="server">
<ItemTemplate>

<div id="<%# DataBinder.Eval(Container.DataItem, "Id") %>" class="GearItem">
    <input type="hidden" class="GetWoWHeadItemXmlPath" value="><%# GetWoWHeadItemXmlPath(DataBinder.Eval(Container.DataItem, "id")) %>" />
    
    <a href="#Tooltip<%# DataBinder.Eval(Container.DataItem, "Id") %>" rel="facebox">
        <div class="Icon"><img src="<%# GetIconImagePath(DataBinder.Eval(Container.DataItem, "Icon")) %>" /></div>
        <h2><%# GetSlotName(DataBinder.Eval(Container.DataItem, "Slot")) %></h2>
        <div class="Name">Loading...</div>
    </a>
    
    <div id="Tooltip<%# DataBinder.Eval(Container.DataItem, "Id") %>" class="Tooltip" rel="facebox"></div>
    <div class="cleaner"></div>
</div>

<div class="Seperator"></div>
</ItemTemplate>
</asp:Repeater>

</asp:Content>
