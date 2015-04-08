<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="IvanovWebsite.admin.Users" Theme="DevEx" %>
<%@ MasterType VirtualPath="~/admin/Admin.Master" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register src="UserControls/SuccessErrorControl.ascx" tagname="SuccessErrorControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row margin-bottom">
    <button class="btn btn-primary create-new" type="button">Create New</button>
</div>
<div class="row">
    <dx:ASPxGridView ID="UsersGrid" ClientInstanceName="UsersGrid" runat="server" AutoGenerateColumns="False" Width="100%" DataSourceID="UsersDataSource" KeyFieldName="ID">
        <Columns>                        
            <dx:GridViewDataComboBoxColumn FieldName="RoleID" Caption="Role" Width="100px">
                <PropertiesComboBox DataSourceID="RolesDataSource" TextField="Caption" ValueField="ID" ValueType="System.Int32"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn FieldName="Email" Caption="Email" Width="200px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Password" Caption="Password" Width="100px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Fname" Caption="Fname" Width="100px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Lname" Caption="Lname" Width="100px">
            </dx:GridViewDataTextColumn>            
            <dx:GridViewDataCheckColumn FieldName="IsActive" Caption="Active?" Width="100px">
            </dx:GridViewDataCheckColumn>            
            <dx:GridViewDataDateColumn FieldName="CRTime" Caption="Reg. Date" Width="150px">
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
    <asp:ObjectDataSource ID="UsersDataSource" runat="server" TypeName="Core.UsersRepository" DeleteMethod="TSP_Users" InsertMethod="TSP_Users" SelectMethod="ListUsers" UpdateMethod="TSP_Users">
        <DeleteParameters>
            <asp:Parameter Name="iud" Type="Byte" DefaultValue="2" />
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Fname" Type="String" />
            <asp:Parameter Name="Lname" Type="String" />
            <asp:Parameter Name="IsActive" Type="Boolean" />
            <asp:Parameter Name="RoleID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="iud" Type="Byte" DefaultValue="0" />
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Fname" Type="String" />
            <asp:Parameter Name="Lname" Type="String" />
            <asp:Parameter Name="IsActive" Type="Boolean" />
            <asp:Parameter Name="RoleID" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="iud" Type="Byte" DefaultValue="1" />
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Fname" Type="String" />
            <asp:Parameter Name="Lname" Type="String" />
            <asp:Parameter Name="IsActive" Type="Boolean" />
            <asp:Parameter Name="RoleID" Type="Int32" />
        </UpdateParameters>        
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="RolesDataSource" runat="server" TypeName="Core.DictionaryRepository" SelectMethod="ListDictionary">
        <SelectParameters>
            <asp:Parameter Name="Level" Type="Int32" DefaultValue="1" />
            <asp:Parameter Name="DictionaryCode" Type="Int32" DefaultValue="1" />
            <asp:Parameter Name="IsVisible" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
<script>
    $(function () {
        $(".create-new").click(function () {
            UsersGrid.AddNewRow();
            return false;
        });
    });
</script>

</asp:Content>
