# CamaraDeCthulhuRPG

Jogo RPG simples desenvolvido como experimento usando Xamarim Forms, existem comentários no código caso existam dúvidas sobre os métodos.
Caso você encontre algum bug irei aceitar o Pull requests com a correção.

OBS: Refatorações também são muito bem vindas! :shipit:
OBS2: Android only!

## Tutorial do jogo

Tive a ideia assistindo a um vídeo sobre Eldritch Horror então resolvi desenvolver esse app com base no mesmo.

>Proteja a câmara contra as forças das trevas por (12 - Normal, 15 - Difícil, 20 - Pesadelo) turnos e colete 4 memórias do ancião até o final.
>
>A cada turno o jogador pode realizar 4 ações sendo elas:
>
>- Procurar por armamento.
>- Remover selo do ancião.
>- Selar portão.
>- Recuperar sanidade.
>
>Após realizar suas ações e avançar para o próximo turno o jogo irá realizar suas próprias ações também a isso chamamos de turno das trevas.
>
>   - Surgiu criatura pelo portão da câmara
>
>Existem 5 criaturas diferentes possíveis de surgir, cada uma de um respectivel nível [1 ao 5],
>quando a criatura aparecer você terá 2 opcões que são usar armamentos adquiridos durante o jogo para destrui-lá dependendo do nível da criatura e do armamento ou tentar lutar com a critura usando uma arma mais fraca.
>
>		Exemplo: armamento nível 2 mata qualquer criatura do nível 2 para baixo,
>			 armamento nível 4 mata qualquer criatura do nível 4 para baixo,
>			 armamento nível 1 só mata criaturas do nível 1.
>		
>		Exemplo2: Caso não tenha uma arma do mesmo nível da criatura ou superior sua arma mais forte será usada em uma batalha até a morte com a criatura e essa batalha o resultado >é dado por: Dado do jogador + nível da arma VERSUS Dado da criatura + nível da criatura.
>								 
>_________________________________________________________________________________________________________________________________________
>
>Para cada ação que o jogador tentar executar um dado do destino será rolado, o dado tem números entre 1 a 20.
>
>---------------------------------------------------------------------------------------
> Ação PROCURAR ARMAMENTO -
> ---------------------------------------------------------------------------------------
> - O jogador irá procurar entre as salas da câmara por algum armamento perdido pertencente a algum guardião que sucumbiu perante as forças das trevas.
>   (Armamentos são usados para derrotar inimigos que surgirem durante o turno das trevas.)
>
  > Ao selecionar a ação no seu turno o dado do destino é lançado:
>	- Resultados:
>
>		0 a 2 - Nenhuma arma encontrada
>
>		3 a 5 - Armamento nível 1 encontrado (Adaga)
>
>		6 a 10 - Armamento nível 2 encontrado (Espada)
>
>		11 a 13- Armamento nível 3 encontrado (Machado)
>
>		14 a 16 - Armamento nível 4 encontrado (Lança)
>
>		17 a 20 - Armamento nível 5 encontrado (Munição de revólver)
>
>
>---------------------------------------------------------------------------------------
 >Ação REMOVER SELO DO ANCIÃO -
 >---------------------------------------------------------------------------------------
 >- O jogador irá tentar remover um selo do ancião para destruir o ritual e impedir que o ancião desperte
>	O jogador precisa remover os 4 selos do ancião e chegar ao fim dos turnos para vencer o jogo.
>	Caso o jogador tente usar essa ação após já ter removido os 4 selos do ancião, será informado ao jogador que a ação está indisponivel.
>
>	- Resultados:
>
>		0 a 13 - Falhou
>
>		14 a 20 - Sucesso
>
>-------------------------------------------------------------------------------------
 >Ação SELAR PORTÃO -
 >---------------------------------------------------------------------------------------
>	- O jogador irá tentar selar o portão da câmara em caso de sucesso no próximo turno das trevas nenhum evento sombrio de surgimento de criatura acontecerá.
>
>	- Resultados:
>
>		0 a 13 - Falhou
>
>		14 a 20 - Sucesso
>
>---------------------------------------------------------------------------------------
 >Ação RECUPERAR SANIDADE -
 >---------------------------------------------------------------------------------------
>   - O jogador irá tentar recuperar sua sanidade para prolongar o status de insanidade (caso o status zere o jogador perde o jogo).
> 	- Resultados:
>
>		0 a 10 - Falhou
>
>		11 a 20 - Sucesso
