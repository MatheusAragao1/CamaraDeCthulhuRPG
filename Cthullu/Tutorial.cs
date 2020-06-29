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
            var textoTutorial = "=> Dinâmica do jogo\n\nProteja a câmara contra as forças das trevas por 12 turnos e colete 4 memórias do ancião até o final(Cada turno representa 1 hora no relógio do jogo).\n\nO jogador inicia o jogo com as seguintes condições:\n> 1 Revólver com 1 munição.\n> Sob o efeito de Pesadelo do ancião.	\n> 1 tocha.\n\nA cada turno o jogador pode realizar 4 ações sendo elas:\n\n- Procurar por armamento.\n- Remover selo do ancião.\n- Selar portão.\n- Recuperar sanidade.\n\nApós realizar suas ações e avançar para o próximo turno o jogo irá realizar suas próprias ações também a isso chamamos de turno das trevas.\n\n   ___O turno das trevas____\n\n1 eventos sombrios ocorrerá e você precisa lidar com ele para sobreviver (A cada 4 turnos o evento sombrio Pesadelo do Ancião ocorrerá simultaneamento com o surgir criatura).\n\n Eventos sombrios:\n\n   - Criatura surgir pelo portão da câmara\n      > Existem 5 criaturas diferentes possíveis de surgir, cada uma de um respectivel nível [1 ao 5],\n	quando a criatura aparecer você terá 2 opcões que são usar armamentos armamento ou tentar expulsar a criatura da câmara com a sua tocha (Dado para efetividade da tocha),\n		Exemplo: armamento nível 2 mata criatura nível 2,\n			 armamento nível 4 mata qualquer criatura do nível 4 para baixo,\n			 armamento nível 1 só mata criaturas do nível 1.\n		\n		Exemplo: Usar a tocha para expulsar criaturas e os valores do dado:\n				> Criatura nível 1 - Qualquer valor acima de 4\n				> Criatura nível 2 - Qualquer valor acima de 8\n				> Criatura nível 3 - Qualquer valor acima de 10\n				> Criatura nível 4 - Qualquer valor acima de 12\n				> Criatura nível 5 - Qualquer valor acima de 14\n\n\n   - Pesadelo do ancião:\n	> O pesadelo do ancião recai sobre o seu personagem e o levará a morte em 3 turnos caso não seja retirada com a ação recuperar sanidade.\n\nPara cada ação que o jogador tentar executar um dado do destino será rolado, o dado tem números entre 1 a 20,\ncaso o jogador selecione mais de uma vez a mesma ação no seu turno o dado irá fortificar a cada tentativa subsequente, detalharei adiante.\n\n---------\n Ação PROCURAR ARMAMENTO -\n ---------\n - O jogador irá procurar entre as salas da câmara por algum armamento perdido pertencente a algum guardião que sucumbiu perante as forças das trevas.\n   (Armamentos são usados para derrotar inimigos que surgirem durante o turno das trevas.)\n\n  > Ao selecionar a ação no seu turno o dado do destino é lançado:\n	- Resultados:\n		0 a 2 - Nenhuma arma encontrada\n		3 a 5 - Armamento nível 1 encontrado (Adaga)\n		6 a 8 - Armamento nível 2 encontrado (Espada)\n		9 a 11- Armamento nível 3 encontrado (Machado)\n		12 a 14 - Armamento nível 4 encontrado (Lança)\n		15 a 20 - Armamento nível 5 encontrado (Munição de revólver)\n\n\n---------\n Ação REMOVER SELO DO ANCIÃO -\n ---------\n - O jogador irá tentar remover um selo do ancião para destruir o ritual e impedir que o ancião desperte\n	O jogador precisa se remover os 4 selos do ancião e chegar ao fim dos 12 turnos para vencer o jogo.\n	Caso o jogador tente usar essa ação após já ter removido os 4 selos do ancião, será informado ao jogador que a ação está indisponivel.\n\n	- Resultados:\n		0 a 10 - Falhou\n		11 a 20 - Sucesso\n\n---------\n Ação SELAR PORTÃO -\n ---------\n	- O jogador irá tentar selar o portão da câmara em caso de sucesso no próximo turno das trevas nenhum evento sombrio de surgimento de criatura acontecerá.\n\n	- Resultados:\n		0 a 13 - Falhou\n		13 a 20 - Sucesso\n\n---------\n Ação RECUPERAR SANIDADE -\n ---------\n   - O jogador irá tentar recuperar sua sanidade para remover o status de Pesadelo do ancião.\n 		- Resultados:\n		0 a 10 - Falhou\n		10 a 20 - Sucesso";

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tutorial);

            Button btnVoltarTuto = FindViewById<Button>(Resource.Id.btnVoltarTuto);

            btnVoltarTuto.Click += delegate { Finish(); };

            TextView currentCharacterName = FindViewById<TextView>(Resource.Id.textTutorial); 
            currentCharacterName.Text= textoTutorial;
        }
    }
}