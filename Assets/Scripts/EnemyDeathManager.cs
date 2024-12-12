using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa o namespace para TextMeshPro

public class EnemyDeathManager : MonoBehaviour
{
    // Vari�vel para armazenar o n�mero de inimigos derrotados
    public int DerrotedEnemies = 0;

    // Refer�ncia ao componente TextMeshProUGUI
    public TextMeshProUGUI enemyCountText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateEnemyCountText(); // Atualiza o texto no in�cio
    }

    // M�todo para incrementar o n�mero de inimigos derrotados
    public void IncrementDefeatedEnemies()
    {
        DerrotedEnemies++;
        UpdateEnemyCountText(); // Atualiza o texto sempre que um inimigo � derrotado
    }

    // M�todo para atualizar o texto na tela
    private void UpdateEnemyCountText()
    {
        enemyCountText.text = $"{DerrotedEnemies}/5"; // Atualiza o texto com a contagem
    }

    // Update is called once per frame
    void Update()
    {

    }
}