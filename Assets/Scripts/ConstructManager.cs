using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructManager : MonoBehaviour
{

    [SerializeField] private int requiredPlastic; // Quantidade de plástico necessária
    [SerializeField] private int requiredMetal; // Quantidade de metal necessária
    [SerializeField] private int requiredWood; // Quantidade de madeira necessária

    public GameObject mensagemErro;
    public GameObject constructArea;
    public GameObject baseConstruct;
    public GameObject decoration;
    // Referência ao HUD
    public GameObject hud;

    // Referência ao Construct Menu
    public GameObject constructMenu;

    // Referência ao PlayerController
    private PlayerController playerController;

    // Referência ao InventoryManager
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
            Debug.LogError("PlayerController não encontrado!");
        }

        GameObject inventoryManagerObject = GameObject.Find("InventoryManager");
        if (inventoryManagerObject != null)
        {
            inventoryManager = inventoryManagerObject.GetComponent<InventoryManager>();
        }
        else
        {
            Debug.LogError("InventoryManager não encontrado!");
        }
    }

    public void TryConstruct()
    {
        // Verifica se o jogador tem os materiais necessários
        if (inventoryManager.plasticQnt >= requiredPlastic &&
            inventoryManager.metalQnt >= requiredMetal &&
            inventoryManager.woodQnt >= requiredWood)
        {
            // Subtrai os materiais necessários do inventário do jogador
            inventoryManager.plasticQnt -= requiredPlastic;
            inventoryManager.metalQnt -= requiredMetal;
            inventoryManager.woodQnt -= requiredWood;

            inventoryManager.UpdateUI();
            // Constrói o objeto
            ConstructObject();
        }
        else
        {
            // Mostra a mensagem de erro
            mensagemErro.SetActive(true);
            Invoke("HideErrorMessage", 3f);
        }
    }

    // Método para construir o objeto
    private void ConstructObject()
    {
        Destroy(constructArea.GetComponent<Collider2D>());
        decoration.SetActive(true);
        baseConstruct.SetActive(false);
        constructMenu.SetActive(false);
        hud.SetActive(true);
        playerController.UnlockMovement();
    }

    // Método para ocultar a mensagem de erro
    private void HideErrorMessage()
    {
        mensagemErro.SetActive(false);
    }
}