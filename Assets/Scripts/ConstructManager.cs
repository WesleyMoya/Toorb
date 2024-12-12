using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructManager : MonoBehaviour
{

    [SerializeField] private int requiredPlastic; // Quantidade de pl�stico necess�ria
    [SerializeField] private int requiredMetal; // Quantidade de metal necess�ria
    [SerializeField] private int requiredWood; // Quantidade de madeira necess�ria

    public GameObject mensagemErro;
    public GameObject constructArea;
    public GameObject baseConstruct;
    public GameObject decoration;
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

    public void TryConstruct()
    {
        // Verifica se o jogador tem os materiais necess�rios
        if (inventoryManager.plasticQnt >= requiredPlastic &&
            inventoryManager.metalQnt >= requiredMetal &&
            inventoryManager.woodQnt >= requiredWood)
        {
            // Subtrai os materiais necess�rios do invent�rio do jogador
            inventoryManager.plasticQnt -= requiredPlastic;
            inventoryManager.metalQnt -= requiredMetal;
            inventoryManager.woodQnt -= requiredWood;

            inventoryManager.UpdateUI();
            // Constr�i o objeto
            ConstructObject();
        }
        else
        {
            // Mostra a mensagem de erro
            mensagemErro.SetActive(true);
            Invoke("HideErrorMessage", 3f);
        }
    }

    // M�todo para construir o objeto
    private void ConstructObject()
    {
        Destroy(constructArea.GetComponent<Collider2D>());
        decoration.SetActive(true);
        baseConstruct.SetActive(false);
        constructMenu.SetActive(false);
        hud.SetActive(true);
        playerController.UnlockMovement();
    }

    // M�todo para ocultar a mensagem de erro
    private void HideErrorMessage()
    {
        mensagemErro.SetActive(false);
    }
}