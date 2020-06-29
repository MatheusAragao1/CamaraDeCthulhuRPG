using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using System;

namespace Cthullu
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
             

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            // Relação botões x id no XML
           Button btnTuto = FindViewById<Button>(Resource.Id.btnTuto);         

           Button btnPlay = FindViewById<Button>(Resource.Id.btnPlay);

            // Clicks dos botões
            btnTuto.Click += delegate { StartActivity(typeof(Tutorial)); };

            btnPlay.Click += delegate { StartActivity(typeof(Dificuldade)); };

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }        
        
    }
}