using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace Cthullu
{
    [Activity(Label = "vitoria", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Vitoria : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.vitoria);

            // Botões
            Button btnPlayAgain = FindViewById<Button>(Resource.Id.playAgain);

            // Clicks

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