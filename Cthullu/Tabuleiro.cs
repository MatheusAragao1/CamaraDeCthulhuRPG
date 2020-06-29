using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace Cthullu
{
    [Activity(Label = "Tabuleiro", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Tabuleiro : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Acoes acoes = new Acoes();

            bool existeArmaNoInventario; // Se n tiver arma a criatura ganha o duelo

            bool hitKill = false;

            var criatura = acoes.DefinirCriaturaRodada();

            var pagina = acoes.AcharPaginaDaCriatura();

            SetContentView(pagina);

            // Atribuições XML e IDs

            TextView nomeEnivel = FindViewById<TextView>(Resource.Id.textView1);
            TextView btnAtacar = FindViewById<TextView>(Resource.Id.atacar);
            Button btnAvancar = FindViewById<Button>(Resource.Id.btnAvancar);

            //Informações da critura na tela
            nomeEnivel.Text = $"{criatura.Nome.ToUpper()} | Nível: {criatura.Nivel}";

            existeArmaNoInventario = acoes.ExisteArmaInventario(criatura);

            if (existeArmaNoInventario)
            {
                hitKill = acoes.HitKill(criatura);
            }

            acoes.DefinirArmaUsada(existeArmaNoInventario, btnAtacar, btnAvancar,criatura);


            // Clicks
            btnAvancar.Click += delegate
            {

                if (hitKill)
                {
                    acoes.UsarArmaIdeal(criatura);
                    Personagem.ResetarAcoes();
                    if (Personagem.criaturasPorTurno == 0)
                    {
                        Personagem.ResetarCriaturas();
                        Finish();
                        StartActivity(typeof(Menu));
                    }
                    else
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
                }
                else
                {

                    Finish();
                    Personagem.ResetarAcoes();
                    StartActivity(typeof(Survival));


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