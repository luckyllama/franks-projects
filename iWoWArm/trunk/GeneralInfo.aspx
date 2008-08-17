<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" 
    CodeFile="GeneralInfo.aspx.cs" Inherits="GeneralInfo" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

<div id="GeneralInfo">

<ul id="GeneralInfoSections">
    <li>
        <h3>
            <a href="#General" class="<%= data.General.Class %>">
                <img src="/Images/<%= data.General.GenderId %>-<%= data.General.RaceId %>-<%= data.General.ClassId %>.gif" />
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
            <div class="DataBox DataRow">
                <span class="Left">Strength</span>
                <span class="Right"><%= data.BaseStats.Strength %></span>
                <div class="cleaner"></div>
            </div>
            
            <div class="DataBox DataRow Alt">
                <span class="Left">Agility</span>
                <span class="Right"><%= data.BaseStats.Agility %></span>
                <div class="cleaner"></div>
            </div>
            
            <div class="DataBox DataRow">
                <span class="Left">Stamina</span>
                <span class="Right"><%= data.BaseStats.Stamina %></span>
                <div class="cleaner"></div>
            </div>
            
            <div class="DataBox DataRow Alt">
                <span class="Left">Intellect</span>
                <span class="Right"><%= data.BaseStats.Intellect %></span>
                <div class="cleaner"></div>
            </div>
            
            <div class="DataBox DataRow">
                <span class="Left">Spirit</span>
                <span class="Right"><%= data.BaseStats.Spirit %></span>
                <div class="cleaner"></div>
            </div>            
            
            <div class="DataBox DataRow Alt">
                <span class="Left">Armor</span>
                <span class="Right"><%= data.BaseStats.Armor %></span>
                <div class="cleaner"></div>
            </div>
        </div>
        
        <div class="BottomBox"></div>
    </li>
    
    <li>
        <h3>
            <a href="#Resistances">Resistances</a>
            <span>+</span>
        </h3>
        <div class="collapse">
            <div class="DataBox DataRow">
                <span class="Left">Arcane</span>
                <span class="Right"><%= data.Resistances.Arcane %></span>
                <div class="cleaner"></div>
            </div>
                
            <div class="DataBox DataRow Alt">
                <span class="Left">Fire</span>
                <span class="Right"><%= data.Resistances.Fire %></span>
                <div class="cleaner"></div>
            </div>
                
            <div class="DataBox DataRow">
                <span class="Left">Frost</span>
                <span class="Right"><%= data.Resistances.Frost %></span>
                <div class="cleaner"></div>
            </div>
            
            <div class="DataBox DataRow Alt">
                <span class="Left">Holy</span>
                <span class="Right"><%= data.Resistances.Holy %></span>
                <div class="cleaner"></div>
            </div>
            
            <div class="DataBox DataRow">
                <span class="Left">Nature</span>
                <span class="Right"><%= data.Resistances.Nature %></span>
                <div class="cleaner"></div>
            </div>
            
            <div class="DataBox DataRow Alt">
                <span class="Left">Shadow</span>
                <span class="Right"><%= data.Resistances.Shadow %></span>
                <div class="cleaner"></div>
            </div>
            
        </div>
        
        <div class="BottomBox"></div>
    </li>
</ul>

</div>

</asp:Content>

