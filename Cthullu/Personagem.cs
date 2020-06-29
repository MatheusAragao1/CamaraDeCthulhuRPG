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
    public static class Personagem
    {
        public static int dificuldade; // 1 - Normal, 2 - Difícil, 3 - Pesadelo
        public static int? statusNegativo = dificuldade == 1 ? 4 : dificuldade == 2 ? 4 : 3;
        public static int acoesRestantes = dificuldade == 1 ? 4 : dificuldade == 2 ? 4 : 4;
        public static int selosDoAnciao = 0;
        public static int turnos = dificuldade == 1 ? 12 : dificuldade == 2 ? 15 : 20;
        public static List<Armamentos> ListArmamentos = new List<Armamentos> { };
        public static bool Portao = false;
        public static int criaturasPorTurno = dificuldade == 1 || dificuldade == 2 ? 1 : 2;


        public static void ResetarJogo()
        {
            statusNegativo = dificuldade == 1 ? 4 : dificuldade == 2 ? 4 : 3;
            acoesRestantes = dificuldade == 1 ? 4 : dificuldade == 2 ? 4 : 4;
            selosDoAnciao = 0;
            turnos = dificuldade == 1 ? 12 : dificuldade == 2 ? 15 : 20;
            ListArmamentos = new List<Armamentos> { };
            Portao = false;
            criaturasPorTurno = dificuldade == 1 || dificuldade == 2 ? 1 : 2;
        }

        public static void ResetarAcoes()
        {
            acoesRestantes = dificuldade == 1 ? 4 : dificuldade == 2 ? 4 : 4;
        }

        public static void ResetarCriaturas()
        {
            criaturasPorTurno = dificuldade == 1 || dificuldade == 2 ? 1 : 2;
        }

        public static void RecuperarSanidade()
        {
            statusNegativo = dificuldade == 1 ? 4 : dificuldade == 2 ? 4 : 3;
        }

        public static void AdquirirSelo()
        {
            if (selosDoAnciao >= 4)
            {
                selosDoAnciao += 1;
            }
        }

        public static void UsarAcao(TextView acoes)
        {
            if (acoesRestantes >= 0)
            {
                acoesRestantes -= 1;
                acoes.Text = $"Ações restantes no turno: {acoesRestantes}";
            }
        }

        public static void PerderSanidade()
        {

            statusNegativo -= 1;

        }

    }

    public class Armamentos
    {
        public string Nome;
        public int Nivel;

        public Armamentos(string nome, int nivel)
        {
            this.Nome = nome;
            this.Nivel = nivel;

        }

    }
}