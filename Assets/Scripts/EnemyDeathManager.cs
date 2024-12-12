using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa o namespace para TextMeshPro

public class EnemyDeathManager : MonoBehaviour
{
    // Variável para armazenar o número de inimigos derrotados
    public int DerrotedEnemies = 0;

    // Referência ao componente TextMeshProUGUI
    public TextMeshProUGUI enemyCountText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateEnemyCountText(); // Atualiza o texto no início
    }

    // Método para incrementar o número de inimigos derrotados
    public void IncrementDefeatedEnemies()
    {
        DerrotedEnemies++;
        UpdateEnemyCountText(); // Atualiza o texto sempre que um inimigo é derrotado
    }

    // Método para atualizar o texto na tela
    private void UpdateEnemyCountText()
    {
        enemyCountText.text = $"{DerrotedEnemies}/5"; // Atualiza o texto com a contagem
    }

    // Update is called once per frame
    void Update()
    {

    }
}