using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace Cthullu
{
    [Activity(Label = "Tutorial", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Tutorial : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var textoTutorial = "Proteja a câmara contra as forças das trevas por (12 - Normal, 15 - Difícil, 20 - Pesadelo) turnos e colhete 4 memórias do ancião até o final.\n\nA cada turno o jogador pode realizar 4 ações sendo elas:\n\n- Procurar por armamento.\n- Remover selo do ancião.\n- Selar portão.\n- Recuperar sanidade.\n\nApós realizar suas ações e avançar para o próximo turno o jogo irá realizar suas próprias ações também a isso chamamos de turno das trevas.\n\n Eventos sombrios:\n\n   - Criatura surgir pelo portão da câmara\n      > Existem 5 criaturas diferentes possíveis de surgir, cada uma de um respectivel nível [1 ao 5],\n	quando a criatura aparecer você terá 2 opcões que são usar armamentos adquiridos durante o jogo para destrui-lá dependendo do nível da criatura e do armamento ou tentar lutar com a critura usando uma arma mais fraca.\n		Exemplo: armamento nível 2 mata criatura nível 2,\n			 armamento nível 4 mata qualquer criatura do nível 4 para baixo,\n			 armamento nível 1 só mata criaturas do nível 1.\n		\n		Exemplo: Caso não tenha uma arma do mesmo nível da criatura ou superior sua arma mais forte será usada em uma batalha até a morte com a criatura e essa batalha o resultado é dado por: Dado do jogador + nível da arma VERSUS Dado da criatura + nível da criatura.\n								 \n__________________________________________________________________________________________________________________________________________\n\nPara cada ação que o jogador tentar executar um dado do destino será rolado, o dado tem números entre 1 a 20.\n\n---------------------------------------------------------------------------------------\n Ação PROCURAR ARMAMENTO -\n ---------------------------------------------------------------------------------------\n - O jogador irá procurar entre as salas da câmara por algum armamento perdido pertencente a algum guardião que sucumbiu perante as forças das trevas.\n   (Armamentos são usados para derrotar inimigos que surgirem durante o turno das trevas.)\n\n  > Ao selecionar a ação no seu turno o dado do destino é lançado:\n	- Resultados:\n		0 a 2 - Nenhuma arma encontrada\n		3 a 5 - Armamento nível 1 encontrado (Adaga)\n		6 a 10 - Armamento nível 2 encontrado (Espada)\n		11 a 13- Armamento nível 3 encontrado (Machado)\n		14 a 16 - Armamento nível 4 encontrado (Lança)\n		17 a 20 - Armamento nível 5 encontrado (Munição de revólver)\n\n\n---------------------------------------------------------------------------------------\n Ação REMOVER SELO DO ANCIÃO -\n ---------------------------------------------------------------------------------------\n - O jogador irá tentar remover um selo do ancião para destruir o ritual e impedir que o ancião desperte\n	O jogador precisa se remover os 4 selos do ancião e chegar ao fim dos turnos para vencer o jogo.\n	Caso o jogador tente usar essa ação após já ter removido os 4 selos do ancião, será informado ao jogador que a ação está indisponivel.\n\n	- Resultados:\n		0 a 13 - Falhou\n		14 a 20 - Sucesso\n\n---------------------------------------------------------------------------------------\n Ação SELAR PORTÃO -\n ---------------------------------------------------------------------------------------\n	- O jogador irá tentar selar o portão da câmara em caso de sucesso no próximo turno das trevas nenhum evento sombrio de surgimento de criatura acontecerá.\n\n	- Resultados:\n		0 a 13 - Falhou\n		14 a 20 - Sucesso\n\n---------------------------------------------------------------------------------------\n Ação RECUPERAR SANIDADE -\n ---------------------------------------------------------------------------------------\n   - O jogador irá tentar recuperar sua sanidade para remover o status de Pesadelo do ancião.\n 		- Resultados:\n		0 a 10 - Falhou\n		11 a 20 - Sucesso";

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tutorial);

            Button btnVoltarTuto = FindViewById<Button>(Resource.Id.btnVoltarTuto);

            btnVoltarTuto.Click += delegate { Finish(); };

            TextView currentCharacterName = FindViewById<TextView>(Resource.Id.textTutorial); 
            currentCharacterName.Text= textoTutorial;
        }
    }
}