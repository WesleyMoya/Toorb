using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;
    public static InventoryItem carriedItem;

    [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private Transform draggablesTransform;
    [SerializeField] private InventoryItem itemPrefab;
    [SerializeField] private Button giveItemBtn;

    private void Awake()
    {
        Singleton = this;

        // Configura��o do bot�o de dar item, se necess�rio
        // if (giveItemBtn != null)
        // {
        //     giveItemBtn.onClick.AddListener(() => SpawnInventoryItem());
        // }
    }

    private void Update()
    {
        if (carriedItem == null) return;

        // Sincroniza a posi��o do item carregado com o mouse
        carriedItem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(InventoryItem item)
    {
        if (carriedItem != null)
        {
            // Verifica se o slot atual aceita o item carregado
            if (item.activeSlot.myTag != carriedItem.myItem.itemTag && item.activeSlot.myTag != SlotTag.None)
            {
                Debug.Log("Tag incompat�vel. N�o � poss�vel colocar o item aqui.");
                return;
            }

            // Move o item carregado para o novo slot
            item.activeSlot.SetItem(carriedItem);
        }

        // Define o item clicado como carregado
        carriedItem = item;
        carriedItem.canvasGroup.blocksRaycasts = false; // Impede a intera��o do item com outros objetos enquanto est� sendo arrastado
        carriedItem.transform.SetParent(draggablesTransform); // Move o item para a hierarquia de arrast�veis
        carriedItem.transform.localPosition = Vector3.zero; // Garante que a posi��o relativa seja zerada
        carriedItem.GetComponent<RectTransform>().SetAsLastSibling(); // Garante que o item fique no topo da hierarquia de renderiza��o
    }

    public void SpawnInventoryItem(Item item)
    {
        if (item == null)
        {
            Debug.LogError("Nenhum item foi passado para SpawnInventoryItem.");
            return;
        }

        // Verifica se h� espa�o no invent�rio
        foreach (var slot in inventorySlots)
        {
            if (slot.myItem == null)
            {
                // Cria o item no slot dispon�vel
                var newItem = Instantiate(itemPrefab, slot.transform);
                newItem.Initialize(item, slot);
                return; // Item adicionado, sai do m�todo
            }
        }

        Debug.LogWarning("Invent�rio cheio! O item n�o foi adicionado.");
        // Aqui voc� pode exibir uma mensagem de erro no UI, se necess�rio
    }

    public bool HasAvailableSlot()
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.myItem == null)
                return true;
        }
        return false;
    }
}