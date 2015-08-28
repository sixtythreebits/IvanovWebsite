<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Offer.aspx.cs" Inherits="IvanovWebsite.admin.OfferPage" %>
<%@ MasterType VirtualPath="~/admin/Admin.Master" %>
<%@ Register Src="~/admin/UserControls/SuccessErrorControl.ascx" TagPrefix="uc1" TagName="SuccessErrorControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
    <link href="/admin/css/comments.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BreadcrumbPlaceHolder" runat="server">  
    <ul class="breadcrumb">
        <li><a href="/admin/offers.aspx">Client Submited Offers</a></li>
        <li><%=Master.PageTitle %></li>
    </ul> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row">
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:PlaceHolder ID="ApplyButtonPlaceHolder" runat="server">
    <asp:Button ID="ApplyButton" runat="server" CssClass="btn btn-success" Text="Apply To This Offer" OnClick="ApplyButton_Click" />
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="RemoveButtonPlaceHolder" runat="server">
    <asp:Button ID="RemoveFromOfferButton" runat="server" CssClass="btn btn-danger" Text="Remove Me From This Offer" OnClick="RemoveFromOfferButton_Click" /> 
    </asp:PlaceHolder>
    <br /><br />    
</div>

<asp:PlaceHolder ID="ManagerPlaceHolder" runat="server">
<div class="row">
    <div class="alert alert-success" role="alert">
        <strong>Manager:</strong> <%=Item.ManagersString %>
    </div>
</div>
</asp:PlaceHolder>
<asp:PlaceHolder ID="ExpiredPlaceHolder" runat="server">
<div class="row">
    <div class="alert alert-danger" role="alert">
        <strong>Expired:</strong> <%=Item.ExpDate.HasValue? Item.ExpDate.Value.ToString("MMM dd, yyyy - HH:mm"): null %>
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
<ul class="nav nav-tabs offer-tabs">
  <li class="active offer-item"><a href="#">Offer</a></li>  
  <li class="comments-item"><a href="#">Comments - <%=CommentCount %></a></li>
</ul>
<div class="row offer-div">
<iframe width="650" height="3500" frameborder="0" src="OfferPage.aspx?id=<%=Request.QueryString["id"] %>">
</iframe>
</div>
<div class="row comments-div">
    <div class="detailBox">
    <div class="titleBox">
      <label>Comment Box</label>        
    </div>
    
    <div class="actionBox">
        
        <div class="form-group">
            <asp:TextBox ID="CommentsTextBox" runat="server" CssClass="form-control" MaxLength="200" placeholder="Your comments"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="AddCommentButton" runat="server" Text="Add" CssClass="btn btn-default" OnClick="AddCommentButton_Click" />            
        </div>
        
        <ul class="commentList">
            <asp:Repeater ID="CommentsRepeater" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="commenterImage">
                          <img src="/admin/img/default_profile.jpg" />
                        </div>
                        <div class="commentText">
                            <p class=""><%#Eval("Comment") %></p> 
                            <strong class="sub-text"><%#Eval("Fullname") %></strong>
                            <span class="date sub-text">on <%#Eval("CRTime","{0:MMM dd, yyyy - HH:mm}") %></span>

                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>            
        </ul>        
    </div>
</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
<script>
    $(function () {
        $(".offer-item").click(function () {
            if (!$(this).hasClass("active")) {
                $(".comments-div").hide();
                $(".offer-div").fadeIn(300);
                
                $(this).addClass("active");
                $(this).next().removeClass("active");
            }
            return false;
        });

        $(".comments-item").click(function () {
            if (!$(this).hasClass("active")) {
                $(".comments-div").fadeIn(500);
                $(".offer-div").hide();

                $(this).addClass("active");
                $(this).prev().removeClass("active");
            }
            return false;
        });
    });
</script>    

<asp:PlaceHolder ID="CommentsTabActivePlaceHolder" runat="server" ViewStateMode="Disabled" Visible="false">
    <script>
        $(function () {
            $(".comments-item").trigger("click");
        });

    </script>

</asp:PlaceHolder>
<uc1:SuccessErrorControl runat="server" ID="SuccessErrorControl" />
</asp:Content>
