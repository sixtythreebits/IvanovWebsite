<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Offers.aspx.cs" Inherits="IvanovWebsite.admin.Offers" Theme="DevEx" %>
<%@ MasterType VirtualPath="~/admin/Admin.Master" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <dx:ASPxGridView ID="OffersGrid" runat="server" Width="100%" DataSourceID="OffersDataSource" AutoGenerateColumns="False" KeyFieldName="ID" OnHtmlDataCellPrepared="OffersGrid_HtmlDataCellPrepared">
        <Columns>            
            <dx:GridViewDataTextColumn FieldName="OfferType" Caption="Offer Type" Width="120px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LocationFrom" Caption="From" Width="150px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LocationTo" Caption="To" Width="150px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Fullname" Caption="Client" Width="200px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Email" Caption="Email" Width="150px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ManagersString" Caption="Manager" Width="300px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="ExpDate" Caption="Exp Date" Width="150px">
                <PropertiesDateEdit DisplayFormatString="MMM dd, yyyy - HH:mm"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="CRTime" Caption="Date Created" Width="150px">
                <PropertiesDateEdit DisplayFormatString="MMM dd, yyyy - HH:mm"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataColumn Width="80px">
                <DataItemTemplate>
                    <a href="Offer.aspx?id=<%#Eval("ID") %>">More Info</a>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewCommandColumn ShowDeleteButton="true" Width="60px"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn></dx:GridViewDataColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="OffersDataSource" TypeName="Core.OfferRepository" SelectMethod="ListSubmitedOffers" runat="server" DeleteMethod="DeleteOffer">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        </asp:ObjectDataSource>
</div>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
