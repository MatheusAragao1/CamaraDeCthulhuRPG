using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Hardware.Camera2;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cthullu
{
    class Acoes
    {
        List<Armamentos> catalogo = new List<Armamentos> {

                new Armamentos("Adaga",1),
                new Armamentos("Espada",2),
                new Armamentos("Machado",3),
                new Armamentos("Lança",4),
                new Armamentos("Munição de revólver",5)

            };

        public int RolarDado()
        {
            Random rand = new Random();
            var dado = rand.Next(1, 21);
            return dado;
        }


        public void DadoArmamento(TextView consoleResultado, TextView acoes, int dado)
        {
            string resultado = "";
            if (Personagem.acoesRestantes > 0)
            {               

                if (dado <= 2) //Nenhuma arma
                {
                    Personagem.UsarAcao(acoes);
                    consoleResultado.Text = $"Resultado: Nenhuma arma encontrada!";

                }
                else if (dado <= 5) // Adaga
                {
                    Personagem.ListArmamentos.Add(catalogo[0]);
                    Personagem.UsarAcao(acoes);
                    resultado = $"{dado} - {catalogo[0].Nome}";
                }
                else if (dado <= 10) // Espada
                {
                    Personagem.ListArmamentos.Add(catalogo[1]);
                    Personagem.UsarAcao(acoes);
                    resultado = $"{dado} - {catalogo[1].Nome}";
                }
                else if (dado <= 13) // Machado
                {
                    Personagem.ListArmamentos.Add(catalogo[2]);
                    Personagem.UsarAcao(acoes);
                    resultado = $"{dado} - {catalogo[2].Nome}";
                }
                else if (dado <= 16) // Lança
                {
                    Personagem.ListArmamentos.Add(catalogo[3]);
                    Personagem.UsarAcao(acoes);
                    resultado = $"{dado} - {catalogo[3].Nome}";
                }
                else if (dado <= 20) // Munição de revólver
                {
                    Personagem.ListArmamentos.Add(catalogo[4]);
                    Personagem.UsarAcao(acoes);
                    resultado = $"{dado} - {catalogo[4].Nome}";
                }

            }
            else
            {
                consoleResultado.Text = $"Resultado: Suas ações no turno acabaram!";
            }
            
            if (Personagem.acoesRestantes >= 0 && dado > 2)
            {
                consoleResultado.Text = $"Resultado: {resultado} encontrada(o)!";
            }            
           

        }
        public void DadoPortao(Button btnPortao,TextView consoleResultado, TextView acoes, int dado)
        {
            if (Personagem.acoesRestantes > 0)
            {if (Personagem.Portao == false) {
                    if (dado >= 13) // Se o resultado do dado for maior que 13 o portão é fechado no turno
                    {
                        Personagem.Portao = true;
                        Personagem.UsarAcao(acoes);
                        btnPortao.Text = "SELAR PORTÃO\n(FECHADO)";
                        consoleResultado.Text = $"Resultado: {dado} -  Sucesso portão selado neste turno!";
                    }
                    else
                    {
                        Personagem.UsarAcao(acoes);
                        consoleResultado.Text = $"Resultado: {dado} -  Fracasso portão não foi selado neste turno!";
                    }
                }
                else
                {
                    consoleResultado.Text = $"Resultado: O Portão já foi selado neste turno!";
                }
            }
            else
            {
                consoleResultado.Text = $"Resultado: Suas ações no turno acabaram!";
            }
            
        }

        public void DadoSelo(TextView consoleResultado, TextView acoes, int dado)
        {
            if (Personagem.acoesRestantes > 0)
            {
                if(Personagem.selosDoAnciao < 4)
                {
                    if (dado > 13)
                    {
                        Personagem.selosDoAnciao += 1;
                        Personagem.UsarAcao(acoes);
                        consoleResultado.Text = $"Resultado: {dado} - Sucesso! Você possui {Personagem.selosDoAnciao} Selos do ancião!";
                    }
                    else
                    {
                        Personagem.UsarAcao(acoes);
                        consoleResultado.Text = $"Resultado: {dado} -  Fracasso! Você ainda possui {Personagem.selosDoAnciao} Selos do ancião!";
                    }
                }
                else
                {
                    consoleResultado.Text = $"Resultado: Você já possui os 4 selos do ancião!";
                }
            }
            else
            {
                consoleResultado.Text = $"Resultado: Suas ações no turno acabaram!";
            }
            
        }

        public void DadoSanidade(TextView consoleResultado, TextView acoes, int dado, TextView status)
        {
            if (Personagem.acoesRestantes > 0)
            {
                if(Personagem.statusNegativo == 4 && (Personagem.dificuldade.Equals(1) || Personagem.dificuldade.Equals(2)) || Personagem.statusNegativo == 3 && Personagem.dificuldade.Equals(3))
                {
                    consoleResultado.Text = $"Resultado: Você já está o mais longe possível da insanidade";
                }
                else
                {
                    if(dado > 10)
                    {
                        Personagem.UsarAcao(acoes);
                        Personagem.statusNegativo = Personagem.dificuldade == 1 ? 4 : Personagem.dificuldade == 2 ? 4 : 3; ;
                        status.Text = $"{Personagem.statusNegativo} turnos para insanidade";
                        consoleResultado.Text = $"Resultado: {dado} -  Sucesso! Sanidade recuperada!";
                    }
                    else
                    {
                        Personagem.UsarAcao(acoes);
                        consoleResultado.Text = $"Resultado: {dado} -  Fracasso!!";
                    }
                }
            }
            else
            {
                consoleResultado.Text = $"Resultado: Suas ações no turno acabaram!";
            }
           
        }

        // A PARTIR DAQUI OS MÉTODOS SERÃO RELACIONADOS AS AÇOES DA PARTIDA E N MAIS NAS AÇOES DO PERSONAGEM  (REFATORAÇÃO EM BREVE..)

        public void TextosCausaDeDerrota(TextView logMorte)
        {
            if (Personagem.turnos == 0 && Personagem.selosDoAnciao != 4)
            {
                logMorte.Text = $"Causa: não colhetou os 4 selos a tempo";
            }
            else if (Personagem.statusNegativo <= 0)
            {
                logMorte.Text = $"Causa: A insanidade corrompeu a mente do jogador";
            } else if (!Personagem.ListArmamentos.Any())
            {
                logMorte.Text = $"Causa: O jogador não tinha armas necessárias para enfrentar a próxima criatura";
            }
            else
            {
                logMorte.Text = $"Causa: O jogador não sobreviveu aos servos do ancião";
            }
        }

        public Criaturas DefinirCriaturaRodada()
        {
            Random rand = new Random();
            var num = rand.Next(0, 5);

            List<Criaturas> Criaturas = new List<Criaturas>
            {
                new Criaturas("Filho do oceano",1),
                new Criaturas("Devorador do oceano",2),
                new Criaturas("Terror do oceano",3),
                new Criaturas("Cria do Ancião",4),
                new Criaturas("Miragem do Ancião",5)
            };

            Duelo.criaturaNome = Criaturas[num].Nome;
            Duelo.criaturaNivel = Criaturas[num].Nivel;

            Personagem.criaturasPorTurno -= 1; // Conta como criatura já enfrentada.

            return Criaturas[num];
        }

        public int AcharPaginaDaCriatura()
        {
            var pagina = Resource.Layout.criatura1;

            if (Duelo.criaturaNivel == 1)
            {
                pagina = Resource.Layout.criatura1;
            }
            else if (Duelo.criaturaNivel == 2)
            {
                pagina = Resource.Layout.criatura2;
            }
            else if (Duelo.criaturaNivel == 3)
            {
                pagina = Resource.Layout.criatura3;
            }
            else if (Duelo.criaturaNivel == 4)
            {
                pagina = Resource.Layout.criatura4;
            }
            else if (Duelo.criaturaNivel == 5)
            {
                pagina = Resource.Layout.criatura5;
            }

            return pagina;
        }

        public bool ExisteArmaInventario(Criaturas criatura)
        {
            if (Personagem.ListArmamentos.OrderBy(x => x.Nivel).Where(x => x.Nivel >= criatura.Nivel).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DefinirArmaUsada(bool existeArmaNoInventario, TextView btnAtacar, Button btnAvancar, Criaturas criatura)
        {
            if (existeArmaNoInventario)
            {                
                var possuiArma = Personagem.ListArmamentos.OrderBy(x => x.Nivel).Where(x => x.Nivel >= criatura.Nivel).First();
                btnAtacar.Text = $"Você derrotará imediatamente a criatura usando\n {possuiArma.Nome} | {possuiArma.Nivel}";
                btnAvancar.Text = $"AVANCAR: Usando {possuiArma.Nome}";

            }
            else
            {
                var possuiArma = Personagem.ListArmamentos.OrderByDescending(x => x.Nivel).FirstOrDefault();
                btnAtacar.Text = $"Sem arma capaz de derrotar a criatura imediatamente\n - Lutar pela sobrevivência usando {possuiArma.Nome} | {possuiArma.Nivel}";
                btnAvancar.Text = $"AVANCAR: Tentar matar criatura com {possuiArma.Nome}";
                Duelo.armaPlayer = possuiArma.Nome;
                Duelo.armaNivel = possuiArma.Nivel;
            }
        }

        public bool HitKill(Criaturas criatura)
        {            
            if (Personagem.ListArmamentos.OrderBy(x => x.Nivel).Where(x => x.Nivel >= criatura.Nivel).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UsarArmaIdeal(Criaturas criatura)
        {            
            var ArmaIdeal = Personagem.ListArmamentos.OrderBy(x => x.Nivel).Where(x => x.Nivel >= criatura.Nivel).Distinct().First();
            Personagem.ListArmamentos.Remove(ArmaIdeal);
        }

        public void PrimeiroCombate(TextView logCriatura, TextView logPlayer, Button avancarSurv)
        {
            Random rand = new Random();
            Duelo.dadoCriatura = rand.Next(1, 21) + Duelo.criaturaNivel;
            Duelo.dadoPlayer = rand.Next(1, 21) + Duelo.armaNivel;

            logCriatura.Text = $"A criatura o golpeia causando {Duelo.dadoCriatura} de dano";
            logPlayer.Text = $"Você golpeia a criatura causando {Duelo.dadoPlayer} de dano";

            avancarSurv.Text = "Avançar";

        }

        public void UsarArma()
        {
            var armaUsada = Personagem.ListArmamentos.OrderBy(x => x.Nivel).Where(x => x.Nivel == Duelo.armaNivel).Distinct().First();
            Personagem.ListArmamentos.Remove(armaUsada);
        }        

    }
}