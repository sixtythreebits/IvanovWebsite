<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="IvanovWebsite.Contact" %>
<%@ MasterType VirtualPath="~/Master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="static">
        <article>
            <h1><%=Master.PageTitle  %></h1>
            <p class="center">Ако имате въпроси, моля пишете ни на <a href="mailto:info@bezbileti.bg">info@bezbileti.bg</a></p>
            <p class="center">За проблеми със сайта, моля пишете на <a href="support@bezbileti.bg">support@bezbileti.bg</a></p>            
        </article>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
