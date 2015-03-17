<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Offers.aspx.cs" Inherits="IvanovWebsite.admin.Offers" Theme="DevEx" %>
<%@ MasterType VirtualPath="~/admin/Admin.Master" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <dx:ASPxGridView ID="OffersGrid" runat="server" Width="100%" DataSourceID="OffersDataSource" AutoGenerateColumns="False" KeyFieldName="ID">
        <Columns>            
            <dx:GridViewDataTextColumn FieldName="OfferType" Caption="Offer Type" Width="120px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LocationFrom" Caption="From" Width="150">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LocationTo" Caption="To" Width="150">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Fullname" Caption="Client" Width="250">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Email" Caption="Email" Width="150">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Manager" Caption="Manager" Width="150">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="CRTime" Caption="Date Created" Width="150">
                <PropertiesDateEdit DisplayFormatString="MMM dd, yyyy HH:mm"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataColumn>
                <DataItemTemplate>
                    <a href="Offer.aspx?id=<%#Eval("ID") %>">More Info</a>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn></dx:GridViewDataColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="OffersDataSource" TypeName="Core.OfferRepository" SelectMethod="ListSubmitedOffers" runat="server"></asp:ObjectDataSource>
</div>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
