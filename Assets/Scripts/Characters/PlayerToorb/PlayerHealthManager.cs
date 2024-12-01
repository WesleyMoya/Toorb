using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private GameObject healthIcon1;
    [SerializeField] private GameObject healthIcon2;
    [SerializeField] private GameObject healthIcon3;
    [SerializeField] private GameObject playerHUD;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject toorbIcon;
    [SerializeField] private GameObject toorbDamagedIcon;
    [SerializeField] private GameObject gameoverScreen;
    [SerializeField] private int baseMaxHealth = 3; // Vida base do jogador
    public int playerHealth;
    public int itemDefense; // Defesa do item, que pode ser alterada a qualquer momento.
    public bool withItemDefense;

    void Start()
    {
        // Inicializa a vida do jogador e o m�ximo de vida, sem considerar a defesa.
        playerHealth = baseMaxHealth;
        UpdateHealthIcons();
    }

    void UpdateHealthIcons()
    {
        // Atualiza os �cones de sa�de de acordo com a vida.
        if (playerHealth <= 0)
        {
            GameOver();
        }
        else if (playerHealth == 1)
        {
            toorbDamagedIcon.SetActive(true);
            toorbIcon.SetActive(false);
            healthIcon1.SetActive(true);
            healthIcon2.SetActive(false);
            healthIcon3.SetActive(false);
        }
        else if (playerHealth == 2)
        {
            toorbDamagedIcon.SetActive(false);
            toorbIcon.SetActive(true);
            healthIcon1.SetActive(false);
            healthIcon2.SetActive(true);
            healthIcon3.SetActive(false);
        }
        else if (playerHealth >= 3)
        {
            toorbDamagedIcon.SetActive(false);
            toorbIcon.SetActive(true);
            healthIcon1.SetActive(false);
            healthIcon2.SetActive(false);
            healthIcon3.SetActive(true);
        }
    }

    // M�todo para equipar o item de defesa, que aumenta o n�mero de hits que o jogador pode tomar.
    public void EquipItemDefense(int defense)
    {
        withItemDefense = true;
        itemDefense = defense;
        UpdateHealthIcons(); // Atualiza os �cones considerando a defesa do item.
    }

    // M�todo para retirar a defesa do item, reduzindo o n�mero de hits.
    public void UnequipItemDefense()
    {
        withItemDefense = false;
        itemDefense = 0;
        UpdateHealthIcons(); // Atualiza os �cones ap�s remover a defesa.
    }

    // M�todo para aplicar dano no jogador. A defesa ser� descontada primeiro, antes de afetar a vida.
    public void TakeDamage(int damage)
    {
        // Se houver defesa, subtrai da defesa primeiro.
        if (itemDefense > 0)
        {
            itemDefense -= damage;
            if (itemDefense < 0) itemDefense = 0; // Garante que a defesa n�o fique negativa.
        }
        else
        {
            playerHealth -= damage; // Se n�o houver defesa, subtrai diretamente da vida.
        }

        // Garante que a vida n�o seja negativa.
        if (playerHealth < 0) playerHealth = 0;

        UpdateHealthIcons(); // Atualiza os �cones com base no novo valor de vida.
    }

    void GameOver()
    {
        // Desativa o jogador e mostra a tela de Game Over.
        playerHUD.SetActive(false);
        player.SetActive(false);
        gameoverScreen.SetActive(true);
    }
}