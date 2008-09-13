<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="General.aspx.cs" Inherits="LuckyArmory.Views.Info.General" %>

<asp:Content ID="GeneralView" ContentPlaceHolderID="MainContent" runat="server">
r= '<%= ViewData["Realm"] %>' n='<%= ViewData["Name"] %>'
</asp:Content>
