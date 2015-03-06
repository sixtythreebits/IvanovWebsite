<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="IvanovWebsite.Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="//maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="map" class="map"></div>
<asp:HiddenField ID="HFCurrentLat" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="HFCurrentLng" runat="server" ClientIDMode="Static"  />   
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
</section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
<script>
    var CurrentLat = $("#HFCurrentLat").val();    
    var CurrentLng = $("#HFCurrentLng").val();
    var LastInfoWindow = null;

    var CurrentMarkerLatLng = null;

    if (CurrentLat.length > 0 && CurrentLng.length > 0) {
        CurrentMarkerLatLng = new google.maps.LatLng(CurrentLat, CurrentLng);
    }
    else {
        CurrentLat = "52.908746";
        CurrentLng = "23.854072";
    }

    function initialize() {
        MapCenter = new google.maps.LatLng(CurrentLat,CurrentLng);
            
        map = new google.maps.Map(document.getElementById("map"), {
            zoom: 4,
            center: MapCenter
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
                    content: $("#MapWindow").html()
                });
                LastInfoWindow.open(map, Marker);
            });

        });

        if (CurrentMarkerLatLng != null) {
            var m = new google.maps.Marker({
                position: CurrentMarkerLatLng,
                map: map,
                icon: "/images/icons/pin_current.png"
            });

            google.maps.event.addListener(m, "click", function (event) {

                if (LastInfoWindow != null) {
                    LastInfoWindow.close();
                }
                LastInfoWindow = new google.maps.InfoWindow({
                    content: $("#MapWindow").html()
                });
                LastInfoWindow.open(map, m);
            });
        }
    }
    google.maps.event.addDomListener(window, 'load', initialize);
</script>
<template id="MapWindow">
  <div class="item map-item">
      <figure><img src="/uploads/img2_871f029b.jpg?width=160&height=111" /></figure>
      <article>
          <span>Some text goes hereSome text goes hereSome text goes hereSome text goes hereSome text goes here</span>
          <a href="#" class="link">Inquery Price</a>
      </article>
  </div>
</template>
</asp:Content>
