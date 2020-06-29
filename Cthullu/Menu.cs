using System.Linq;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content.PM;

namespace Cthullu
{
    [Activity(Label = "Menu", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Menu : Activity
    {        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.menu);

            //Atribuições de elementos XML e IDS
            TextView horas = FindViewById<TextView>(Resource.Id.horas);
            TextView status = FindViewById<TextView>(Resource.Id.status); ;
            TextView acoesRestantes = FindViewById<TextView>(Resource.Id.actions);
            TextView consoleResultado = FindViewById<TextView>(Resource.Id.consoleResultado);
            Button btnInventario = FindViewById<Button>(Resource.Id.inventario);
            Button btnArmamento = FindViewById<Button>(Resource.Id.actionArmamento);
            Button btnRemoverSelo = FindViewById<Button>(Resource.Id.actionRemoveSelo);
            Button btnPortao = FindViewById<Button>(Resource.Id.actionSelarPortao);
            Button btnRecSanidade = FindViewById<Button>(Resource.Id.actionSanidade);
            Button btnProxTurno = FindViewById<Button>(Resource.Id.btnTurno);
            Button btnProbs = FindViewById<Button>(Resource.Id.btnProbs);

            //Atribuições gerais
            Acoes acao = new Acoes();
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            


            //Textos iniciais                       
            horas.Text = $"Turnos restantes: {Personagem.turnos}";                   

            status.Text = $"{Personagem.statusNegativo} turnos para insanidade";                       

            acoesRestantes.Text = $"Ações restantes no turno: {Personagem.acoesRestantes}";

            btnPortao.Text = "SELAR PORTÃO\n(ABERTO)";


            // Clicks e efeitos

            btnProbs.Click += delegate {
                StartActivity(typeof(Probabilidades));
            };

            btnInventario.Click += delegate {
                this.ConfigurarAlertaInventario(builder);
            };

            btnArmamento.Click += delegate {

                if (Personagem.acoesRestantes > 0)
                {

                    var dado = acao.RolarDado();

                    acao.DadoArmamento(consoleResultado, acoesRestantes, dado);                                       

                    this.ConfigurarAlerta(builder, dado, consoleResultado);
                }
                else
                {
                    consoleResultado.Text = "Sem ações restantes no turno.";
                }
                
            };
            
            btnPortao.Click += delegate {

                if (Personagem.acoesRestantes > 0)
                {

                    var dado = acao.RolarDado();

                    acao.DadoPortao(btnPortao, consoleResultado, acoesRestantes, dado);

                    this.ConfigurarAlerta(builder, dado, consoleResultado);
                }
                else
                {
                    consoleResultado.Text = "Sem ações restantes no turno.";
                }
            };


            btnRemoverSelo.Click += delegate {

                if (Personagem.acoesRestantes > 0)
                {
                    var dado = acao.RolarDado();

                    acao.DadoSelo(consoleResultado, acoesRestantes, dado);

                    this.ConfigurarAlerta(builder, dado, consoleResultado);
                }
                else
                {
                    consoleResultado.Text = "Sem ações restantes no turno.";
                }
            };

            btnRecSanidade.Click += delegate {

                if (Personagem.acoesRestantes > 0)
                {
                    var dado = acao.RolarDado();

                    acao.DadoSanidade(consoleResultado, acoesRestantes, dado, status);

                    this.ConfigurarAlerta(builder, dado, consoleResultado);
                }
                else
                {
                    consoleResultado.Text = "Sem ações restantes no turno.";
                }
            };
            

            btnProxTurno.Click += delegate {

                if (Personagem.acoesRestantes > 0)
                {
                    consoleResultado.Text = "Resultado: Use todas as suas ações antes de avançar de turno!";
                }
                else
                {
                    if (Personagem.turnos == 0)
                    {
                        if (Personagem.selosDoAnciao == 4)
                        {
                            Finish();
                            StartActivity(typeof(Vitoria));
                        }
                        else
                        {
                            Finish();
                            StartActivity(typeof(Derrota));
                        }
                    }
                    else
                    {
                        Personagem.turnos -= 1;
                    }
                    if (Personagem.statusNegativo == 0)
                    {
                        Finish();
                        StartActivity(typeof(Derrota));
                    } else if (!Personagem.ListArmamentos.Any()) {
                        Finish();
                        StartActivity(typeof(Derrota));
                    }
                    else
                    { if (!Personagem.Portao && Personagem.turnos != 0) {
                            if (Personagem.turnos <= 5) { Personagem.criaturasPorTurno = 2; } // Modifica a quantidade de criaturas a partir do turno 5
                            Personagem.PerderSanidade();
                            StartActivity(typeof(Tabuleiro));
                            Finish();
                        }
                        else if (Personagem.Portao && Personagem.turnos != 0)
                        {
                            if (Personagem.turnos <= 5) { Personagem.criaturasPorTurno = 2; } // Modifica a quantidade de criaturas a partir do turno 5
                            Personagem.ResetarAcoes();
                            Personagem.PerderSanidade();
                            Personagem.Portao = false;
                            StartActivity(typeof(Menu));
                            Finish();
                        }
                    }
                    
                }

                
            };


        }

        public void ConfigurarAlerta(AlertDialog.Builder builder, int dado, TextView consoleResultado)
        {            
            AlertDialog alerta = builder.Create();
            alerta.SetTitle($"Resultado do dado: {dado}");
            alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alerta.SetMessage($"{consoleResultado.Text.Replace($"Resultado: {dado}", "")}");
            alerta.SetButton("OK", (s, ev) =>
            {
                Toast.MakeText(this, "Ok", ToastLength.Short).Show();
            });
            alerta.Show();

        }

        public void ConfigurarAlertaInventario(AlertDialog.Builder builder)
        {
            string lista = "Seus itens são:\n\n";

            foreach (var cada in Personagem.ListArmamentos.OrderBy(x => x.Nivel))
            {
                if (!lista.Contains($"{cada.Nome}"))
                {
                    lista += $"- {Personagem.ListArmamentos.Where(x => x.Nome == cada.Nome).Count()}x {cada.Nome} | Nível: {cada.Nivel}\n";
                }
            }

            if (lista.Equals("Seus itens são:\n\n"))
            {
                lista += " - Sem nenhum item";
            }

            AlertDialog alerta = builder.Create();
            alerta.SetTitle($"Selos do ancião obtidos: {Personagem.selosDoAnciao}");
            alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alerta.SetMessage($"{lista}");
            alerta.SetButton("OK", (s, ev) =>
            {
                Toast.MakeText(this, "Ok", ToastLength.Short).Show();
            });
            alerta.Show();

        }

        public override void OnBackPressed()
        {
            Finish();
            Personagem.ResetarJogo();

        }

    }
}