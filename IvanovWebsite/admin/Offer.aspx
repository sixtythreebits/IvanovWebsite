<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Offer.aspx.cs" Inherits="IvanovWebsite.admin.OfferPage" %>
<%@ MasterType VirtualPath="~/admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BreadcrumbPlaceHolder" runat="server">  
    <ul class="breadcrumb">
        <li><a href="/admin/offers.aspx">Client Submited Offers</a></li>
        <li><%=Master.PageTitle %></li>
    </ul> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ApplyButton" runat="server" CssClass="btn btn-success" Text="Apply To This Offer" OnClick="ApplyButton_Click" /> <br /><br />    
</div>
<asp:PlaceHolder ID="ManagerPlaceHolder" runat="server">
<div class="row">
    <div class="alert alert-success" role="alert">
        <strong>Manager:</strong> <%=Item.Manager %>
    </div>
</div>
</asp:PlaceHolder>
<asp:PlaceHolder ID="NoManagerPlaceHolder" runat="server">
<div class="row">
    <div class="alert alert-danger" role="alert">
        <strong>Nobody is assigned to this offer</strong> 
    </div>
</div>
</asp:PlaceHolder>
<div class="row">
<iframe width="650" height="3500" frameborder="0" src="OfferPage.aspx?id=<%=Request.QueryString["id"] %>">
</iframe>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
    
</asp:Content>
