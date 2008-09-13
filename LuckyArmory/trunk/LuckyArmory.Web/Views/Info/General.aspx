<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="General.aspx.cs" Inherits="LuckyArmory.Web.Views.Info.General" %>

<asp:Content ID="GeneralView" ContentPlaceHolderID="MainContent" runat="server">

<div id="GeneralInfo">

<dl id="GeneralInfoSections">
    <dt class="Info">
        <div class="<%= data.General.Class %>">
            <img src="/Images/Avatar/<%= data.General.GenderId %>-<%= data.General.RaceId %>-<%= data.General.ClassId %>.gif" alt="Avatar"/>
            <%= data.General.Name %> <br />
            <%= data.General.Level%> 
            <%= data.General.Class%>
        </div>
        <% if (data.General.GuildName != "") { %>
        &lt;<%= data.General.GuildName%>&gt;
        <br />
        <% } %>
        
        <%= data.General.Faction%> - 
        <%= data.General.Gender%> - 
        <%= data.General.Race%>
        
        <br />
        
        <%= data.General.Realm%> - 
        <%= data.General.Battlegroup%>
    </dt>
    <dd>
        <% if (data.General.GuildName != "") { %>
        &lt;<%= data.General.GuildName%>&gt;
        <br />
        <% } %>
        
        <%= data.General.Faction%> - 
        <%= data.General.Gender%> - 
        <%= data.General.Race%>
        
        <br />
        
        <%= data.General.Realm%> - 
        <%= data.General.Battlegroup%>
    </dd>
    
    <dt class="Info">
        <span class="Left"><%= data.Talents.Talents %></span>
        <span class="Right"><%= data.Talents.TalentSpec%></span>
        <div class="cleaner"> </div>
    </dt>
    
    <dt class="Info">
        <div class="HealthBarBox">
            <%= data.Bars.Health %>
        </div>
        <div class="PowerBarBox <%= data.Bars.PowerBarType %>">
            <%= data.Bars.PowerBar%>
        </div>
    </dt>
    
    <dt class="Header">
        <a href="#BaseStats">Base Stats</a>
    </dt>
    <dd>
        <asp:Repeater ID="BaseStatsRepeater" runat="server">
        <ItemTemplate>
            <div>
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="Alt">
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </AlternatingItemTemplate>
        </asp:Repeater>
    </dd>
    
    <dt class="Header">
        <a href="#Melee">Melee</a>
    </dt>
    <dd>
        <asp:Repeater ID="MeleeRepeater" runat="server">
        <ItemTemplate>
            <div>
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="Alt">
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </AlternatingItemTemplate>
        </asp:Repeater>
    </dd>
    
    <% if (data.Ranged.HasRanged) { %>
    <dt class="Header">
        <a href="#Ranged">Ranged</a>
    </dt>
    <dd>
        <asp:Repeater ID="RangedRepeater" runat="server">
        <ItemTemplate>
            <div>
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="Alt">
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </AlternatingItemTemplate>
        </asp:Repeater>
    </dd>
    <% } %>
    <% if (data.Spell.HasSpell) { %>
    <dt class="Header">
        <a href="#Spell">Spell</a>
    </dt>
    <dd>
        <asp:Repeater ID="SpellRepeater" runat="server">
        <ItemTemplate>
            <div>
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="Alt">
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </AlternatingItemTemplate>
        </asp:Repeater>
    </dd>
    <% } %>
    
    <dt class="Header">
        <a href="#Defenses">Defenses</a>
    </dt>
    <dd>
        <asp:Repeater ID="DefensesRepeater" runat="server">
        <ItemTemplate>
            <div>
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="Alt">
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </AlternatingItemTemplate>
        </asp:Repeater>
    </dd>
    
    <dt class="Header">
        <a href="#Resistances">Resistances</a>
    </dt>
    <dd>
        <asp:Repeater ID="ResistancesRepeater" runat="server">
        <ItemTemplate>
            <div>
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="Alt">
                <span class="Left"><%# DataBinder.Eval(Container, "DataItem.Key") %></span>
                <span class="Right"><%# DataBinder.Eval(Container, "DataItem.Value") %></span>
                <div class="cleaner"></div>
            </div>
        </AlternatingItemTemplate>
        </asp:Repeater>
    </dd>
    
    <dt class="Header">
        <a href="#CacheDate">As of: <%= data.CacheDate.ToShortDateString() %></a>
    </dt>
    <dd class="collapse">
        TODO: Refresh Data
    </dd>
</dl>

</div>

</asp:Content>
