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
    [Activity(Label = "Inventario", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Inventario : Activity
    {
        MainActivity controlador = new MainActivity();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.inventario);

            TextView selos = FindViewById<TextView>(Resource.Id.selosAnciao);
            selos.Text = $"Selos do Ancião obtidos: {Personagem.selosDoAnciao}";

            TextView lista = FindViewById<TextView>(Resource.Id.lista);

            lista.Text = "Seus itens são:\n\n";

            foreach (var cada in Personagem.ListArmamentos.OrderBy(x => x.Nivel))
            {
                if (!lista.Text.Contains($"{cada.Nome}"))
                {
                    lista.Text += $"- {Personagem.ListArmamentos.Where(x => x.Nome == cada.Nome).Count()}x {cada.Nome} | Nível: {cada.Nivel}\n";
                }
            }
            

            Button btnVoltar = FindViewById<Button>(Resource.Id.btnVoltarMenu);
            btnVoltar.Click += delegate { Finish(); };

        }
       
    }
   }