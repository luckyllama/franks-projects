<%@ Control Language="C#" Inherits="LuckyWiki.Mvc.LuckyWikiBaseViewUserControl" %>

<div id="LoginDisplay">
        
    <% if (User.IsAnonymous) { %>

    <div id="LoginFormsContainer">
        <div id="LoginFormsContent">
            <% using (Html.BeginForm("Login", "Account")) { %>
            <fieldset id="LoginPanel">
                <legend>User Login</legend>
                <div class="ErrorMessages">
                    <%= Html.ValidationMessage("username")%>
                    <%= Html.ValidationMessage("password")%>
                </div>
                <div class="FormItem">
                    <label for="username">Username:</label>
                    <%= Html.TextBox("username")%>
                </div>
                <div class="FormItem">
                    <label for="password">Password:</label>
                    <%= Html.Password("password")%>
                </div>
                <div class="FormItem FormCheckBox">
                    <%= Html.CheckBox("rememberMe", true)%> <label for="rememberMe">Remember me?</label>
                </div>
                <div class="LoginSubmit">
                    <input type="submit" value="Login" />
                </div>
            </fieldset>
            <% } %>
            
            <% using (Html.BeginForm("Login", "Register")) { %>
            <fieldset id="RegisterPanel">
                <legend>Need a login? Register!</legend>
                <div class="FormItem">
                    <label for="username">Username:</label>
                    <%= Html.TextBox("username")%>
                    <%= Html.ValidationMessage("username")%>
                </div>
                <div class="FormItem">
                    <label for="email">Email:</label>
                    <%= Html.TextBox("email")%>
                    <%= Html.ValidationMessage("email")%>
                </div>
                <div>
                    A password will be emailed to you.
                </div>        
                <div class="RegisterSubmit">
                    <input type="submit" value="Register" />
                </div>
            </fieldset>
            <% } %>
        </div>
    </div>
    <% } %>
            
    <div id="LoginTabs">
        <ul id="Tabs">
            <li class="FirstTab"></li>
            
            <% if (User.IsAnonymous) { %>
            <li>
                You're current logged in anonymously: 
                <%= Html.ActionLink(User.Username, "Display", "UserPage", new { username = User.Username }, null)%>
            </li>
            <li>
                <a href="#Login" class="TabToggleButton">Log In / Register</a>
                <a id="LoginHideFormButton" href="#Close" class="TabToggleButton">Close</a>
            </li>
            
            <% } else { %>
            
            <li>
                Welcome <%= Html.ActionLink(User.Username, "Display", "UserPage", new { username = User.Username }, null)%>! 
                <%= Html.ActionLink("Log Out", "LogOut", "Account") %>
            </li>
            <% } %>
            
            <li class="LastTab"></li>
        </ul>
    </div>

</div>