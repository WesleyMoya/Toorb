using System.Collections; // Namespace para cole��es gen�ricas e n�o gen�ricas (n�o utilizado diretamente aqui).
using System.Collections.Generic; // Necess�rio para cole��es como List<T>.
using UnityEngine; // Namespace principal para desenvolvimento no Unity.
using TMPro; // Importa o namespace do TextMeshPro, usado para manipular textos na UI.

public class EnemyDeathManager : MonoBehaviour
{
    // Vari�vel p�blica que mant�m o n�mero de inimigos derrotados.
    public int DerrotedEnemies = 0;

    // Refer�ncia ao componente TextMeshProUGUI, que ser� usado para exibir a contagem de inimigos derrotados na tela.
    public TextMeshProUGUI enemyCountText;

    // M�todo chamado uma vez no in�cio, logo ap�s o objeto ser instanciado ou ativado.
    void Start()
    {
        // Atualiza o texto exibido na UI com a contagem inicial de inimigos derrotados.
        UpdateEnemyCountText();
    }

    // M�todo p�blico para incrementar o n�mero de inimigos derrotados.
    public void IncrementDefeatedEnemies()
    {
        // Incrementa o contador de inimigos derrotados em 1.
        DerrotedEnemies++;

        // Atualiza o texto na UI para refletir a nova contagem.
        UpdateEnemyCountText();
    }

    // M�todo privado para atualizar o texto exibido na tela.
    private void UpdateEnemyCountText()
    {
        // Define o texto no componente TextMeshProUGUI, formatando a contagem no formato "x/5".
        enemyCountText.text = $"{DerrotedEnemies}/5";
    }

}
