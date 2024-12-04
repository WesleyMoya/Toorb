using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory; // Refer�ncia ao invent�rio
    [SerializeField] private InventoryManager inventoryManager; // Refer�ncia ao gerenciador de materiais
    [SerializeField] private TextMeshProUGUI insufficientMaterialsText; // Texto para materiais insuficientes
    [SerializeField] private TextMeshProUGUI inventoryFullText; // Texto para invent�rio cheio
    [SerializeField] private Button purchaseButton; // Bot�o de compra
    [SerializeField] private Item itemToPurchase; // Item a ser comprado
    [SerializeField] private int requiredPlastic; // Quantidade de pl�stico necess�ria
    [SerializeField] private int requiredMetal; // Quantidade de metal necess�ria
    [SerializeField] private int requiredWood; // Quantidade de madeira necess�ria

    private void Start()
    {
        // Configura��es iniciais de mensagens
        insufficientMaterialsText?.gameObject.SetActive(false);
        inventoryFullText?.gameObject.SetActive(false);

        // Configura o bot�o de compra
        purchaseButton?.onClick.AddListener(() => TryPurchase(itemToPurchase, requiredPlastic, requiredMetal, requiredWood));
    }

    public void TryPurchase(Item item, int requiredPlastic, int requiredMetal, int requiredWood)
    {
        // Verifica se o invent�rio tem espa�o dispon�vel
        if (!inventory.HasAvailableSlot())
        {
            StartCoroutine(ShowInventoryFullMessage());
            return;
        }

        // Verifica se o player tem materiais suficientes
        if (inventoryManager.plasticQnt >= requiredPlastic &&
            inventoryManager.metalQnt >= requiredMetal &&
            inventoryManager.woodQnt >= requiredWood)
        {
            // Deduz os materiais usados
            inventoryManager.plasticQnt -= requiredPlastic;
            inventoryManager.metalQnt -= requiredMetal;
            inventoryManager.woodQnt -= requiredWood;

            // Atualiza a UI
            inventoryManager.UpdateUI();

            // Adiciona o item ao invent�rio
            inventory.SpawnInventoryItem(item);
        }
        else
        {
            // Exibe a mensagem de materiais insuficientes
            StartCoroutine(ShowInsufficientMaterialsMessage());
        }
    }

    private IEnumerator ShowInsufficientMaterialsMessage()
    {
        if (insufficientMaterialsText != null)
        {
            insufficientMaterialsText.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            insufficientMaterialsText.gameObject.SetActive(false);
        }
    }

    private IEnumerator ShowInventoryFullMessage()
    {
        if (inventoryFullText != null)
        {
            inventoryFullText.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            inventoryFullText.gameObject.SetActive(false);
        }
    }
}