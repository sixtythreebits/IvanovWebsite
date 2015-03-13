<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="VisitedDestinations.aspx.cs" Inherits="IvanovWebsite.admin.VisitedDestinations" Theme="DevEx" %>
<%@ MasterType VirtualPath="~/admin/Admin.Master" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<%@ Register src="UserControls/SuccessErrorControl.ascx" tagname="SuccessErrorControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row margin-bottom">
    <button class="btn btn-primary create-new" type="button">Create New</button>
</div>
<div class="row">
    <dx:ASPxGridView ID="DestinationsGrid" runat="server" AutoGenerateColumns="False" DataSourceID="DestinationsDataSource" KeyFieldName="ID" OnRowDeleting="DestinationsGrid_RowDeleting" Width="100%">
        <Columns>            
            <dx:GridViewDataTextColumn FieldName="Picture" Caption="Picture" Width="120px">
                <DataItemTemplate>
                    <img src="/uploads/<%#Eval("Picture") %>?height=100&width=100" />
                </DataItemTemplate>
                <EditItemTemplate>
                    <img src="/uploads/<%#Eval("Picture") %>?height=100&width=100" />
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>            
            <dx:GridViewDataTextColumn FieldName="Caption" Caption="Caption" Width="100px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ShortDesc" Caption="ShortDesc" Width="300px">
            </dx:GridViewDataTextColumn>            
            <dx:GridViewDataTextColumn FieldName="Lat" Caption="Latitude" Width="100px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Lng" Caption="Longitude"  Width="100px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="IsPublished" Caption="Published" Width="150px">
            </dx:GridViewDataCheckColumn>            
            <dx:GridViewDataDateColumn FieldName="CRTime" Caption="Date Created" Width="150px">
                <PropertiesDateEdit DisplayFormatString="MMM dd, yyyy HH:mm"></PropertiesDateEdit>
                <EditItemTemplate></EditItemTemplate>
            </dx:GridViewDataDateColumn>
            <dx:GridViewCommandColumn ShowEditButton="true" Width="60px"></dx:GridViewCommandColumn>
            <dx:GridViewCommandColumn ShowDeleteButton="true" Width="60px"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn>
                <EditItemTemplate></EditItemTemplate>
            </dx:GridViewDataColumn>            
        </Columns>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="DestinationsDataSource" runat="server" TypeName="Core.DestinationRepository" DeleteMethod="TSP_VisitedDestination" SelectMethod="ListVisitedDestinations" UpdateMethod="TSP_VisitedDestination">
        <DeleteParameters>
            <asp:Parameter Name="iud" Type="Byte" DefaultValue="2" />
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Caption" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="ShortDesc" Type="String" />
            <asp:Parameter Name="Lat" Type="String" />
            <asp:Parameter Name="Lng" Type="String" />
            <asp:Parameter Name="IsPublished" Type="Boolean" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="IsPublished" Type="Boolean" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="iud" Type="Byte" DefaultValue="1" />
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Caption" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="ShortDesc" Type="String" />
            <asp:Parameter Name="Lat" Type="String" />
            <asp:Parameter Name="Lng" Type="String" />
            <asp:Parameter Name="IsPublished" Type="Boolean" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</div>
    <dx:ASPxPopupControl ID="NewOfferPopup" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="NewOfferPopup"
        HeaderText="New Last Offer" AllowDragging="False" PopupAnimationType="None" MinWidth="450px"
        MinHeight="350px">
        <ContentCollection>
        <dx:PopupControlContentControl runat="server">
            <div class="col-lg-12">
                <div class="form-group">
                    <label>Caption</label>
                    <asp:TextBox ID="CaptionTextBox" runat="server" CssClass="form-control"></asp:TextBox>                    
                </div>
                <div class="form-group">
                    <label>Short Text</label>
                    <asp:TextBox ID="ShortDescriptionTextBox" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>                    
                </div>
                <div class="form-group">
                    <label>Upload Picture</label>
                    <asp:FileUpload ID="PictureUploader" runat="server" />
                </div>                
                <div class="form-group">
                    <label>Latitude</label>
                    <asp:TextBox ID="LatTextBox" runat="server" CssClass="form-control"></asp:TextBox>                    
                </div>
                <div class="form-group">
                    <label>Longitude</label>
                    <asp:TextBox ID="LngTextBox" runat="server" CssClass="form-control"></asp:TextBox>                    
                </div>
                <div class="form-group">
                    <label for="IsPublishedCheckBox">Published?</label>
                    <asp:CheckBox ID="IsPublishedCheckBox" runat="server" ClientIDMode="Static" />                    
                </div>
                <div class="form-group">
                    <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-success btn-lg btn-block" OnClick="SaveButton_Click" />
                </div>
            </div>
        </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
        <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
<script>
    $(function () {
        $(".create-new").click(function () {
            NewOfferPopup.Show();
            return false;
        });
    });
</script>
<uc1:SuccessErrorControl ID="SuccessErrorControl1" runat="server" />
</asp:Content>
