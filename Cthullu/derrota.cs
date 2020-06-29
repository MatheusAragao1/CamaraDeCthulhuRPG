using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cthullu
{
    [Activity(Label = "derrota", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Derrota : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.derrota);

            Acoes acoes = new Acoes();

            // Atribuição da relação XML x ID

            TextView logMorte = FindViewById<TextView>(Resource.Id.aCausa);
            Button btnPlayAgain = FindViewById<Button>(Resource.Id.playAgain);

            acoes.TextosCausaDeDerrota(logMorte);
            
            btnPlayAgain.Click += delegate {
                Finish();
                Personagem.ResetarJogo();

            };
        }
        public override void OnBackPressed()
        {
            Finish();
            Personagem.ResetarJogo();
        }
    }
}