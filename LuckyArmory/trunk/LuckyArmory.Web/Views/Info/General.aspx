<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="General.aspx.cs" Inherits="LuckyArmory.Web.Views.Info.General" %>

<asp:Content ID="GeneralView" ContentPlaceHolderID="MainContent" runat="server">

<div id="GeneralInfo">

<ul id="GeneralInfoSections">
    <li>
        <h3>
            <a href="#General" class="<%= data.General.Class %>">
                <img src="/Images/Avatar/<%= data.General.GenderId %>-<%= data.General.RaceId %>-<%= data.General.ClassId %>.gif" />
                <%= data.General.Name %> <br />
                <%= data.General.Level%> 
                <%= data.General.Class%>
            </a>
            <span>+</span>
        </h3>
        <div class="cleaner"></div>
        <div class="collapse">
            <div class="DataBox">
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
            </div>
        </div>
        <div class="BottomBox"></div>
    </li>
    
    <li>
        <div class="DataBox">
            <span class="Left"><%= data.Talents.Talents %></span>
            <span class="Right"><%= data.Talents.TalentSpec%></span>
        </div>
        <div class="BottomBox"></div>
    </li>
    
    <li>
        <div class="HealthBarBox">
            <%= data.Bars.Health %>
        </div>
        <div class="PowerBarBox <%= data.Bars.PowerBarType %>">
            <%= data.Bars.PowerBar%>
        </div>
        <div class="BottomBox"></div>
    </li>
    
    <li>
        <h3>
            <a href="#BaseStats">Base Stats</a>
            <span>+</span>
        </h3>
        <div class="collapse">
        
        <asp:Repeater ID="BaseStatsRepeater" runat="server">
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
        </asp:Repeater>
        
        </div>
        
        <div class="BottomBox"></div>
    </li>
    
    <li>
        <h3>
            <a href="#Melee">Melee</a>
            <span>+</span>
        </h3>
        <div class="collapse">
        
        <asp:Repeater ID="MeleeRepeater" runat="server">
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
        </asp:Repeater>
            
        </div>

        <div class="BottomBox"></div>
    </li>
    
    <% if (data.Ranged.HasRanged) { %>
    <li>
        <h3>
            <a href="#Ranged">Ranged</a>
            <span>+</span>
        </h3>
        <div class="collapse">
        
        <asp:Repeater ID="RangedRepeater" runat="server">
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
        </asp:Repeater>
        
        </div>
    
        <div class="BottomBox"></div>
    </li>
    <% } %>
    <% if (data.Spell.HasSpell) { %>
    <li>
        <h3>
            <a href="#Spell">Spell</a>
            <span>+</span>
        </h3>
        <div class="collapse">
        
        <asp:Repeater ID="SpellRepeater" runat="server">
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
        </asp:Repeater>
            
        </div>
        
        <div class="BottomBox"></div>
    </li>
    <% } %>
    
    <li>
        <h3>
            <a href="#Defenses">Defenses</a>
            <span>+</span>
        </h3>
        <div class="collapse">
        
        <asp:Repeater ID="DefensesRepeater" runat="server">
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
        </asp:Repeater>
            
        </div>
        
        <div class="BottomBox"></div>
    </li>
    
    <li>
        <h3>
            <a href="#Resistances">Resistances</a>
            <span>+</span>
        </h3>
        <div class="collapse">
        
        <asp:Repeater ID="ResistancesRepeater" runat="server">
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
        </asp:Repeater>
            
        </div>
        
        <div class="BottomBox"></div>
    </li>
    
    <li>
        <h3>
            <a href="#CacheDate">As of: <%= data.CacheDate.ToShortDateString() %></a>
            <span>+</span>
        </h3>
        <div class="collapse">
            TODO: Refresh Data
        </div>
        <div class="BottomBox"></div>
    </li>
</ul>

</div>

</asp:Content>
