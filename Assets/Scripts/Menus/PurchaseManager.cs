using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory; // Referência ao inventário
    [SerializeField] private InventoryManager inventoryManager; // Referência ao gerenciador de materiais
    [SerializeField] private TextMeshProUGUI insufficientMaterialsText; // Texto para materiais insuficientes
    [SerializeField] private TextMeshProUGUI inventoryFullText; // Texto para inventário cheio
    [SerializeField] private Button purchaseButton; // Botão de compra
    [SerializeField] private Item itemToPurchase; // Item a ser comprado
    [SerializeField] private int requiredPlastic; // Quantidade de plástico necessária
    [SerializeField] private int requiredMetal; // Quantidade de metal necessária
    [SerializeField] private int requiredWood; // Quantidade de madeira necessária

    private void Start()
    {
        // Configurações iniciais de mensagens
        insufficientMaterialsText?.gameObject.SetActive(false);
        inventoryFullText?.gameObject.SetActive(false);

        // Configura o botão de compra
        purchaseButton?.onClick.AddListener(() => TryPurchase(itemToPurchase, requiredPlastic, requiredMetal, requiredWood));
    }

    public void TryPurchase(Item item, int requiredPlastic, int requiredMetal, int requiredWood)
    {
        // Verifica se o inventário tem espaço disponível
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

            // Adiciona o item ao inventário
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