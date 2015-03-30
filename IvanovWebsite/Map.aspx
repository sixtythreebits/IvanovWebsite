<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="IvanovWebsite.Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="//maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br /><br />
<h1>Дестинации</h1>
<div id="map" class="map"></div>

<asp:HiddenField ID="HFCurrentMarker" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="HFMarkers" runat="server" ClientIDMode="Static" />
<section class="item-container">
    <asp:Repeater ID="ItemsRepeater" runat="server" ViewStateMode="Disabled" ItemType="Core.Destination">
        <ItemTemplate>
            <div class="item cl">
                <figure>
                    <img src="/uploads/<%#Item.Picture %>" alt="" />
                </figure>
                <article>
                    <h1><%#Item.Caption %></h1>
                    <p><%#Item.ShortDesc %></p>
                    <%--<a href="#" class="more">READ MORE</a>--%>
                </article>
            </div>
        </ItemTemplate>
    </asp:Repeater>    
    <div class="paging">
        <ul>
            <asp:Repeater ID="PagerRepeater" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:PlaceHolder ID="ActivePlaceHolder" runat="server" ViewStateMode="Disabled" Visible='<%#Container.ItemIndex+1==PageNum %>'>
                            <a class="active"><%#Container.ItemIndex + 1 %></a>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" Visible='<%#(Container.ItemIndex+1)!=PageNum %>'>
                            <a href="<%# CurrentID == null ? string.Format("/map/?page={0}",Container.ItemIndex + 1) : string.Format("/map/{0}/?page={1}",CurrentID,Container.ItemIndex + 1)%>"><%#Container.ItemIndex + 1 %></a>
                        </asp:PlaceHolder>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
<script>
    var CurrentMarkerData = $("#HFCurrentMarker").val();    
    var LastInfoWindow = null;

    var CurrentMarkerJson = null;

    if (CurrentMarkerData.length) {
        CurrentMarkerJson = JSON.parse(CurrentMarkerData);        
    }
    

    function initialize() {
        MapCenter = CurrentMarkerJson == null ? new google.maps.LatLng(52.908746, 23.854072) : new google.maps.LatLng(CurrentMarkerJson.lat, CurrentMarkerJson.lng);
            
        map = new google.maps.Map(document.getElementById("map"), {
            zoom: 4,
            center: MapCenter,
            scrollwheel: false
        });         
        var Markers = JSON.parse($("#HFMarkers").val());
        $(Markers).each(function(index,item){
                
            var Marker = new google.maps.Marker({
                position: new google.maps.LatLng(item.lat,item.lng),
                map: map                
            });
            
            google.maps.event.addListener(Marker, "click", function (event) {
                
                if (LastInfoWindow != null) {
                    LastInfoWindow.close();
                }
                LastInfoWindow = new google.maps.InfoWindow({
                    content: '<div class="item map-item"><figure><img src="' + item.image + '" /></figure><article><span>' + item.text + '</span><a href="/offer/new/#form-container" class="link">Inquery Price</a></article></div>'
                });
                LastInfoWindow.open(map, Marker);
            });

        });

        if (CurrentMarkerJson != null) {
            var m = new google.maps.Marker({
                position: new google.maps.LatLng(CurrentMarkerJson.lat, CurrentMarkerJson.lng),
                map: map,
                icon: "/images/icons/pin_current.png"
            });
            
            google.maps.event.addListener(m, "click", function (event) {

                if (LastInfoWindow != null) {
                    LastInfoWindow.close();
                }
                LastInfoWindow = new google.maps.InfoWindow({
                    content: '<div class="item map-item"><figure><img src="' + CurrentMarkerJson.image + '" /></figure><article><span>' + CurrentMarkerJson.text + '</span><a href="/offer/new/#form-container" class="link">Inquery Price</a></article></div>'
                });
                LastInfoWindow.open(map, m);
            });
        }
    }
    google.maps.event.addDomListener(window, 'load', initialize);
</script>
</asp:Content>
