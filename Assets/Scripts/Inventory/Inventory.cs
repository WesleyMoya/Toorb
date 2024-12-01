using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;
    public static InventoryItem carriedItem;

    [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private InventorySlot[] equipmentSlots;
    [SerializeField] private Transform draggablesTransform;
    [SerializeField] private InventoryItem itemPrefab;
    [SerializeField] private Item[] items;
    [SerializeField] private Button giveItemBtn;

    public PlayerAttack playerAtk;
    public PlayerHealthManager playerHlt;

    private void Awake()
    {
        Singleton = this;

        if (giveItemBtn != null)
        {
            giveItemBtn.onClick.AddListener(() => SpawnInventoryItem());
        }
    }

    private void Update()
    {
        if (carriedItem == null) return;

        // Sincroniza a posição do item carregado com o mouse
        carriedItem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(InventoryItem item)
    {
        if (carriedItem != null)
        {
            // Verifica se o slot atual aceita o item carregado
            if (item.activeSlot.myTag != carriedItem.myItem.itemTag && item.activeSlot.myTag != SlotTag.None)
            {
                Debug.Log("Tag incompatível. Não é possível colocar o item aqui.");
                return;
            }

            // Move o item carregado para o novo slot
            item.activeSlot.SetItem(carriedItem);
        }

        // Define o item clicado como carregado
        carriedItem = item;

        // Garante que o item seja visível e arrastável
        carriedItem.canvasGroup.blocksRaycasts = false; // Impede a interação do item com outros objetos enquanto está sendo arrastado
        carriedItem.transform.SetParent(draggablesTransform); // Move o item para a hierarquia de arrastáveis
        carriedItem.transform.localPosition = Vector3.zero; // Garante que a posição relativa seja zerada
        carriedItem.GetComponent<RectTransform>().SetAsLastSibling(); // Garante que o item fique no topo da hierarquia de renderização
    }

    public void EquipEquipment(SlotTag tag, InventoryItem item = null)
    {
        switch (tag)
        {
            case SlotTag.Damage:
                if (item == null)
                {
                    Debug.Log("Removeu Item tag Damage");
                }
                else
                {
                    Debug.Log("Equipou Item tag Damage");
                }
                break;

            case SlotTag.Equipment:
                if (item == null)
                {
                    Debug.Log("Removeu Item tag Equipment");
                }
                else
                {
                    Debug.Log("Equipou Item tag Equipment");
                }
                break;

            default:
                Debug.LogWarning($"Unhandled SlotTag: {tag}");
                break;
        }
    }

    public void SpawnInventoryItem(Item item = null)
    {
        Item selectedItem = item ?? PickRandomItem();

        foreach (var slot in inventorySlots)
        {
            if (slot.myItem == null)
            {
                Instantiate(itemPrefab, slot.transform).Initialize(selectedItem, slot);
                break;
            }
        }
    }

    private Item PickRandomItem()
    {
        int randomIndex = Random.Range(0, items.Length);
        return items[randomIndex];
    }
}