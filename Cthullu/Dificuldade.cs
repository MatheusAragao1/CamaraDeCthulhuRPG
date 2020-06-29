using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace Cthullu
{
    [Activity(Label = "Dificuldade", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Dificuldade : Activity
    {       
       
        protected override void OnCreate(Bundle savedInstanceState)
        {            
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dificuldade);

            //Botões
            Button btnNormal = FindViewById<Button>(Resource.Id.btnNormal);
            Button btnDificil = FindViewById<Button>(Resource.Id.btnDificil);
            Button btnPesadelo = FindViewById<Button>(Resource.Id.btnPesadelo);

            //Clicks dos botões
            btnNormal.Click += delegate {
                Personagem.dificuldade = 1;
                Personagem.ResetarJogo();
                StartActivity(typeof(Menu));
                Finish();
            };

            btnDificil.Click += delegate {
                Personagem.dificuldade = 2;
                Personagem.ResetarJogo();
                StartActivity(typeof(Menu));
                Finish();
            };

            btnPesadelo.Click += delegate {
                Personagem.dificuldade = 3;
                Personagem.ResetarJogo();
                StartActivity(typeof(Menu));
                Finish();
            };

        }
    }
}