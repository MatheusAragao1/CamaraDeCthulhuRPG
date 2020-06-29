using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    [Activity(Label = "Inventario", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Probabilidades : Activity
    {       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string probs = "---------------------------------------------------------------------------------------\n Ação PROCURAR ARMAMENTO -\n ---------------------------------------------------------------------------------------\n\n- Resultados:\n		0 a 2 - Nenhuma arma encontrada\n		3 a 5 - Armamento nível 1 encontrado (Adaga)\n		6 a 10 - Armamento nível 2 encontrado (Espada)\n		11 a 13- Armamento nível 3 encontrado (Machado)\n		14 a 16 - Armamento nível 4 encontrado (Lança)\n		17 a 20 - Armamento nível 5 encontrado (Munição de revólver)\n\n---------------------------------------------------------------------------------------\n Ação REMOVER SELO DO ANCIÃO -\n ---------------------------------------------------------------------------------------\n\n- Resultados:\n		0 a 13 - Falhou\n		14 a 20 - Sucesso\n\n---------------------------------------------------------------------------------------\n Ação SELAR PORTÃO -\n ---------------------------------------------------------------------------------------\n\n- Resultados:\n		0 a 13 - Falhou\n		14 a 20 - Sucesso\n\n---------------------------------------------------------------------------------------\n Ação RECUPERAR SANIDADE -\n ---------------------------------------------------------------------------------------\n\n- Resultados:\n		0 a 10 - Falhou\n		11 a 20 - Sucesso";


            SetContentView(Resource.Layout.probabilidades);

            TextView currentCharacterName = FindViewById<TextView>(Resource.Id.textProbs);
            currentCharacterName.Text = probs;


            Button btnVoltar = FindViewById<Button>(Resource.Id.btnVoltarMenu);
            btnVoltar.Click += delegate { Finish(); };

        }

    }
}