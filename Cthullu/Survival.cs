using System;
using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace Cthullu
{
    [Activity(Label = "Survival", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Survival : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.survival);

            Acoes acoes = new Acoes();

            // Atribuições XML por ID

            TextView logCriatura = FindViewById<TextView>(Resource.Id.criaturaSurvival);
            TextView logPlayer = FindViewById<TextView>(Resource.Id.playerSurvival);
            Button avancarSurv = FindViewById<Button>(Resource.Id.avancarSurvival);

            // Edições de texto

            logCriatura.Text = $"O {Duelo.criaturaNome} está faminto e avança em sua direção";
            logPlayer.Text = $"Segurando um(a) {Duelo.armaPlayer} você golpeia a criatura";
            avancarSurv.Text = $"Clique para lutar";

            // Click

            avancarSurv.Click += delegate
            {

                if (avancarSurv.Text.Contains("lutar"))
                {

                    acoes.PrimeiroCombate(logCriatura, logPlayer, avancarSurv);

                }
                else
                {
                    if (Duelo.dadoCriatura > Duelo.dadoPlayer)
                    {
                        Finish();
                        StartActivity(typeof(Derrota));
                    }
                    else
                    {
                        acoes.UsarArma();
                        Personagem.ResetarAcoes();
                        if (Personagem.criaturasPorTurno > 0)
                        {
                            if (Personagem.ListArmamentos.Any())
                            {
                                Finish();
                                StartActivity(typeof(Tabuleiro));
                            }
                            else
                            {
                                Finish();
                                StartActivity(typeof(Derrota));
                            }
                        }
                        else
                        {
                            Personagem.ResetarCriaturas();
                            Finish();
                            StartActivity(typeof(Menu));
                        }
                    }
                }
            };
        }
        public override void OnBackPressed()
        {
            Finish();
            Personagem.ResetarJogo();
        }
    }
}