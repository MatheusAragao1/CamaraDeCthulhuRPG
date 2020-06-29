using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cthullu
{
    class Criaturas
    {
        public string Nome;
        public int Nivel;

        public Criaturas(string nome, int nivel)
        {
            this.Nome = nome;
            this.Nivel = nivel;
        }
    }
}