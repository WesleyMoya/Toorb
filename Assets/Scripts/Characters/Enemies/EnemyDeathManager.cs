using System.Collections; // Namespace para coleções genéricas e não genéricas (não utilizado diretamente aqui).
using System.Collections.Generic; // Necessário para coleções como List<T>.
using UnityEngine; // Namespace principal para desenvolvimento no Unity.
using TMPro; // Importa o namespace do TextMeshPro, usado para manipular textos na UI.

public class EnemyDeathManager : MonoBehaviour
{
    // Variável pública que mantém o número de inimigos derrotados.
    public int DerrotedEnemies = 0;

    // Referência ao componente TextMeshProUGUI, que será usado para exibir a contagem de inimigos derrotados na tela.
    public TextMeshProUGUI enemyCountText;

    // Método chamado uma vez no início, logo após o objeto ser instanciado ou ativado.
    void Start()
    {
        // Atualiza o texto exibido na UI com a contagem inicial de inimigos derrotados.
        UpdateEnemyCountText();
    }

    // Método público para incrementar o número de inimigos derrotados.
    public void IncrementDefeatedEnemies()
    {
        // Incrementa o contador de inimigos derrotados em 1.
        DerrotedEnemies++;

        // Atualiza o texto na UI para refletir a nova contagem.
        UpdateEnemyCountText();
    }

    // Método privado para atualizar o texto exibido na tela.
    private void UpdateEnemyCountText()
    {
        // Define o texto no componente TextMeshProUGUI, formatando a contagem no formato "x/5".
        enemyCountText.text = $"{DerrotedEnemies}/5";
    }

}
