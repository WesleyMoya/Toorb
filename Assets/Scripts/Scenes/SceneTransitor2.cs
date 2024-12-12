using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransitor2 : MonoBehaviour
{
    public string nomeDoLevelDeJogo = "Jogo1"; // Nome da cena do jogo
    public GameObject transitionSceneAskScreen;
    public GameObject transitionSceneAskScreen2;

    private PlayerController playerController;
    private EnemyDeathManager enemyDeathManager;
    private InventoryManager inventoryManager;
    private void Start()
    {
        GameObject inventoryManagerObject = GameObject.Find("InventoryManager");
        GameObject playerMovementObject = GameObject.Find("Toorb");
        GameObject enemyDeathManagerObject = GameObject.Find("EnemyDeathManager");

        playerController = playerMovementObject.GetComponent<PlayerController>();
        inventoryManager = inventoryManagerObject.GetComponent<InventoryManager>();
        enemyDeathManager = enemyDeathManagerObject.GetComponent<EnemyDeathManager>();
    }

    // Método chamado quando o botão "Sim" é pressionado
    public void YesButtonPressed()
    {
        GameObject constructions = GameObject.Find("ConstructionArea");
        if (constructions != null)
        {
            constructions.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Objeto com Constructors não encontrado na cena.");
        }
        SceneLoader.NextScene = nomeDoLevelDeJogo; // Define a próxima cena a ser carregada
        SceneManager.LoadScene("Loading Scene"); // Carrega a cena de loading
        inventoryManager.upgradeKey++;
        inventoryManager.UpdateUI();

    }

    // Método chamado quando o botão "Não" é pressionado
    public void NoButtonPressed()
    {
        transitionSceneAskScreen.SetActive(false);
        transitionSceneAskScreen2.SetActive(false);
        playerController.UnlockMovement();
    }

    // Método chamado quando o collider 2D do objeto entra em contato com outro collider 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Verifica se existe um objeto com o nome "EnemyDeathManager"
            GameObject enemyDeathManagerObject = GameObject.Find("EnemyDeathManager");
            if (enemyDeathManagerObject != null && enemyDeathManager.DerrotedEnemies != 5)
            {
                transitionSceneAskScreen.SetActive(true);
                playerController.LockMovement();
            }
            else
            {
                transitionSceneAskScreen2.SetActive(true);
                playerController.LockMovement();
            }
        }
    }
}
    
    