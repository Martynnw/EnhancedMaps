using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;

using EnhancedMaps.Demo.Droid;
using Xamarin.Forms.Platform.Android;
using View = Xamarin.Forms.View;

[assembly: ExportRenderer(typeof(EnhancedMaps.Map), typeof(MapRenderer))]

namespace EnhancedMaps.Demo.Droid
{
    public class MapRenderer : ViewRenderer<Map, MapView>, IOnMapReadyCallback
    {
        public void OnMapReady(GoogleMap googleMap)
        {
            var sydney = new LatLng(-34, 151);
            ((MapView)Control).Map.MoveCamera(CameraUpdateFactory.NewLatLng(sydney));
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var mapView = new MapView(Context);
                mapView.OnCreate(new Bundle());
                mapView.OnResume();
                mapView.GetMapAsync(this);
                SetNativeControl(mapView);
                mapView.Map.UiSettings.ZoomControlsEnabled = true;
                mapView.Map.UiSettings.ZoomGesturesEnabled = true;
                mapView.Map.UiSettings.ScrollGesturesEnabled = true;
          //      mapView.Map.MyLocationEnabled = true;

                mapView.Map.MapType = GoogleMap.MapTypeSatellite;
            }
        }
    }
}