using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructManager : MonoBehaviour
{
    // Refer�ncia ao HUD
    public GameObject hud;

    // Refer�ncia ao Construct Menu
    public GameObject constructMenu;

    // Refer�ncia ao PlayerController
    private PlayerController playerController;

    // Refer�ncia ao InventoryManager
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        // Tenta encontrar o PlayerController e o InventoryManager
        GameObject playerControllerObject = GameObject.Find("Toorb");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogError("PlayerController n�o encontrado!");
        }

        GameObject inventoryManagerObject = GameObject.Find("InventoryManager");
        if (inventoryManagerObject != null)
        {
            inventoryManager = inventoryManagerObject.GetComponent<InventoryManager>();
        }
        else
        {
            Debug.LogError("InventoryManager n�o encontrado!");
        }
    }

    // M�todo para abrir o Construct Menu
    public void OpenConstructMenu()
    {
        // Habilita o Construct Menu
        constructMenu.SetActive(true);

        // Desabilita o HUD
        hud.SetActive(false);

        // Bloqueia o movimento do jogador
        if (playerController != null)
        {
            playerController.LockMovement();
        }
    }

    // M�todo para fechar o Construct Menu
    public void CloseConstructMenu()
    {
        // Desabilita o Construct Menu
        constructMenu.SetActive(false);

        // Habilita o HUD
        hud.SetActive(true);

        // Desbloqueia o movimento do jogador
        if (playerController != null)
        {
            playerController.UnlockMovement();
        }
    }
}