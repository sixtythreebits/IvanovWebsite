﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="LastOffers.aspx.cs" Inherits="IvanovWebsite.admin.LastOffers" Theme="DevEx"%>
<%@ MasterType VirtualPath="~/admin/Admin.Master" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register src="UserControls/SuccessErrorControl.ascx" tagname="SuccessErrorControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row margin-bottom">
    <button class="btn btn-primary create-new" type="button">Create New</button>
</div>
<div class="row">
    <dx:ASPxGridView ID="LastOffersGrid" runat="server" AutoGenerateColumns="False" DataSourceID="LastOffersDataSource" KeyFieldName="ID" Width="100%" OnRowDeleting="LastOffersGrid_RowDeleting" >
        <ClientSideEvents CustomButtonClick="function(s,e){ OnEditButtonClick(s,e) }" />
        <Columns>            
            <dx:GridViewDataTextColumn FieldName="Picture" Caption="Picture" Width="150px">
                <DataItemTemplate>
                    <img src="/uploads/<%#Eval("Picture") %>?height=54&width=80" />
                </DataItemTemplate>
                <EditItemTemplate>
                    <img src="/uploads/<%#Eval("Picture") %>?height=54&width=80" />
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Caption" Caption="Caption" Width="200px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Location" Caption="Location" Width="100px">
            </dx:GridViewDataTextColumn>            
            <dx:GridViewDataSpinEditColumn FieldName="UsersCount" Caption="User Count" Width="80px">
                <PropertiesSpinEdit AllowMouseWheel="false">
                    <SpinButtons ShowIncrementButtons="false"></SpinButtons>
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataMemoColumn FieldName="ShortDesc" Caption="ShortDesc" Width="300px">
            </dx:GridViewDataMemoColumn>
            <dx:GridViewDataTextColumn FieldName="PdfFile" Caption="Pdf" Width="100px">
                <DataItemTemplate>
                    <a href="/uploads/<%#Eval("PdfFile") %>" target="_blank">Download File</a>
                </DataItemTemplate>
                <EditItemTemplate>
                    <a href="/uploads/<%#Eval("PdfFile") %>" target="_blank">Download File</a>
                </EditItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="IsPublished" Caption="Published" Width="150px">
            </dx:GridViewDataCheckColumn>            
            <dx:GridViewDataDateColumn FieldName="CRTime" Caption="Date Created" Width="150px">
                <PropertiesDateEdit DisplayFormatString="MMM dd, yyyy HH:mm"></PropertiesDateEdit>
                <EditItemTemplate></EditItemTemplate>
            </dx:GridViewDataDateColumn>
            <%--<dx:GridViewCommandColumn ShowEditButton="true" Width="60px"></dx:GridViewCommandColumn>--%>
            <dx:GridViewCommandColumn Width="60px">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="EditButton" Text="Edit"></dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewCommandColumn ShowDeleteButton="true" Width="60px"></dx:GridViewCommandColumn>
            <dx:GridViewDataColumn>
                <EditItemTemplate></EditItemTemplate>
            </dx:GridViewDataColumn>            
        </Columns>        
                
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="LastOffersDataSource" runat="server" TypeName="Core.OfferRepository" DeleteMethod="TSP_LastOffer" UpdateMethod="TSP_LastOffer" SelectMethod="ListLastOffers">
        <DeleteParameters>
            <asp:Parameter Name="iud" Type="Byte" DefaultValue="2" />
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Caption" Type="String" />
            <asp:Parameter Name="Location" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="ShortDesc" Type="String" />
            <asp:Parameter Name="PdfFile" Type="String" />
            <asp:Parameter Name="UsersCount" Type="Int32" />
            <asp:Parameter Name="IsPublished" Type="Boolean" />
        </DeleteParameters>        
        <UpdateParameters>
            <asp:Parameter Name="iud" Type="Byte" DefaultValue="1" />
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Caption" Type="String" />
            <asp:Parameter Name="Location" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="ShortDesc" Type="String" />
            <asp:Parameter Name="PdfFile" Type="String" />
            <asp:Parameter Name="UsersCount" Type="Int32" />
            <asp:Parameter Name="IsPublished" Type="Boolean" />
        </UpdateParameters>
        <SelectParameters>
            <asp:Parameter Name="IsPublished" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
    <dx:ASPxPopupControl ID="NewOfferPopup" runat="server" CloseAction="CloseButton" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="NewOfferPopup"
        HeaderText="New Last Offer" AllowDragging="False" PopupAnimationType="None" MinWidth="450px"
        MinHeight="450px">
        <ContentCollection>
        <dx:PopupControlContentControl runat="server">
            <asp:HiddenField ID="HFID" runat="server" ClientIDMode="Static" />
            <div class="col-lg-12">
                <div class="form-group">
                    <label>Caption</label>
                    <asp:TextBox ID="CaptionTextBox" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Location</label>
                    <asp:TextBox ID="LocationTextBox" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>User Count</label>
                    <asp:TextBox ID="UsersCountTextBox" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Short Text</label>
                    <asp:TextBox ID="ShortDescriptionTextBox" runat="server" TextMode="MultiLine" Rows="3" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>                    
                </div>                
                <div class="form-group">
                    <label>Upload Picture (320 x 223)</label>
                    <asp:FileUpload ID="PictureUploader" runat="server" />
                </div>
                <div class="form-group">
                    <label>Upload pdf</label>
                    <asp:FileUpload ID="PdfUploader" runat="server" />                    
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
            $("#HFID").val('');
            $("#CaptionTextBox").val('');
            $("#LocationTextBox").val('');
            $("#UsersCountTextBox").val('');
            $("#ShortDescriptionTextBox").val('');
            $("#IsPublishedCheckBox").removeAttr("checked");
            NewOfferPopup.Show();
            return false;
        });        
    });
    function OnEditButtonClick(s,e) {        
        s.GetRowValues(e.visibleIndex, "ID;Caption;Location;UsersCount;ShortDesc;IsPublished", OnGetRowValues)
    }

    function OnGetRowValues(res)
    {
        $("#HFID").val(res[0]);
        $("#CaptionTextBox").val(res[1]);
        $("#LocationTextBox").val(res[2]);
        $("#UsersCountTextBox").val(res[3]);
        $("#ShortDescriptionTextBox").val(res[4]);
        if (res[5] == "true") {
            $("#IsPublishedCheckBox").attr("checked", "checked");
        }
        else {
            $("#IsPublishedCheckBox").removeAttr("checked");
        }
        NewOfferPopup.Show();        
    }
</script>
<uc1:SuccessErrorControl ID="SuccessErrorControl1" runat="server" />
</asp:Content>
