<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Offers.aspx.cs" Inherits="IvanovWebsite.admin.Offers" Theme="DevEx" %>
<%@ MasterType VirtualPath="~/admin/Admin.Master" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    <dx:ASPxGridView ID="OffersGrid" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="OffersDataSource" KeyFieldName="OfferID">
        <Columns>            
            <dx:GridViewDataTextColumn FieldName="OfferType" Width="100px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataColumn Caption="Locations" Width="200px">
                <DataItemTemplate>
                    From: <b><%#Eval("LocationFrom") %></b> - To: <b><%#Eval("LocationTo") %></b>
                </DataItemTemplate>
            </dx:GridViewDataColumn>                        
            <dx:GridViewDataColumn Caption="Dates" Width="220px">
                <DataItemTemplate>
                    <b><%#Eval("StartDate","{0:MMM dd, yyyy}") %>  (<%#Eval("StartFelxBefore") %>  <%#Eval("StartFelxAfter") %>)</b> - <br />
                    <b><%#Eval("EndDate","{0:MMM dd, yyyy}") %>  (<%#Eval("EndFelxBefore") %>  <%#Eval("EndFelxAfter") %>)</b>
                </DataItemTemplate>
            </dx:GridViewDataColumn>                                   
            <dx:GridViewDataCheckColumn FieldName="IsOneWay" Caption="One Way" Width="70px">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="IsTwoWay" Caption="Two Way" Width="70px">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataTextColumn Caption="Travelers" Width="220px">
                <DataItemTemplate>
                    <b><%#Eval("Travelers") %></b> <br />
                    Adults - <%#Eval("AdultCount") %>,  Children - <%# Eval("ChildrenCount")%>, Luggage <%#Eval("LuggageCount") %><br />
                    Invant - <%#Eval("InvantCount") %>, Students - <%#Eval("StudentCount") %>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>                        
            <dx:GridViewDataTextColumn FieldName="Transport" Width="70px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TransportWebsite" Width="150px" Caption="Transport Website">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="StayPlace" Width="70px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="CarRental" Caption="Car Rent" Width="70px">
            </dx:GridViewDataCheckColumn>            
            <dx:GridViewDataCheckColumn FieldName="CarRentalCompany" Caption="Car Rent Company" Width="150px">
            </dx:GridViewDataCheckColumn>            
            <dx:GridViewDataTextColumn FieldName="FromWebsite" Caption="Price Website" Width="150px">
                 <DataItemTemplate>
                     <a href="<%#Eval("FromWebsite") %>" target="_blank"><%#Eval("FromWebsite") %></a>
                 </DataItemTemplate>
            </dx:GridViewDataTextColumn>            
            <dx:GridViewDataColumn Caption="Price" Width="120px">
                <DataItemTemplate>
                    Total: <b><%#Eval("Currency") %><%#Eval("TotalPrice") %></b> <br />
                    One Person: <b><%#Eval("Currency") %><%#Eval("PricePerPerson") %></b> 
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Personal Info" Width="150px">
                <DataItemTemplate>
                    <%#Eval("Fname") %> <%#Eval("Lname") %> <br />
                    <%#Eval("Email") %> <br />
                    <%#Eval("Nationality") %>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataTextColumn FieldName="TimeToResearch" Caption="Time" Width="70px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="ReceiveNewsletters" Caption="News Letters." Width="100px">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="ReceiveCommercialInfo" Caption="Commercial Info" Width="120px">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataDateColumn FieldName="CRTime" Caption="Date" Width="120px">
                <PropertiesDateEdit DisplayFormatString="MMM dd, yyyy"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataColumn FieldName="AddInfo"></dx:GridViewDataColumn>
        </Columns>
        <Settings HorizontalScrollBarMode="Auto" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="OffersDataSource" TypeName="Core.OfferRepository" SelectMethod="ListSubmitedOffers" runat="server"></asp:ObjectDataSource>
</div>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
