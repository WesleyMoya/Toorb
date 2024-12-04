using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public InventoryItem myItem { get; set; }
    public SlotTag myTag;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        if (Inventory.carriedItem == null)
        {
            if (myItem != null)
            {
                // Pega o item do slot e o torna o item carregado
                Inventory.Singleton.SetCarriedItem(myItem);
            }
        }
        else
        {
            // Verifica se o item carregado é compatível com o slot
            if (myTag != SlotTag.None && Inventory.carriedItem.myItem.itemTag != myTag)
            {
                Debug.Log($"Não é possível colocar {Inventory.carriedItem.myItem.itemTag} no slot {myTag}.");
                return;
            }

            // Solta o item carregado no slot atual
            SetItem(Inventory.carriedItem);
        }
    }

    public void SetItem(InventoryItem item)
    {
        if (item == null) return;

        // Verifica se o item é compatível com o tipo de slot
        if (myTag != SlotTag.None && item.myItem.itemTag != myTag)
        {
            Debug.Log($"Item incompatível com o slot. Item: {item.myItem.itemTag}, Slot: {myTag}");
            return;
        }

        // Libera o slot anterior do item carregado
        if (Inventory.carriedItem != null)
        {
            Inventory.carriedItem.activeSlot.myItem = null;
        }

        // Configura o item no slot atual
        myItem = item;
        myItem.activeSlot = this;
        myItem.transform.SetParent(transform);
        myItem.canvasGroup.blocksRaycasts = true; // Reativa a interação com o item
        myItem.transform.localPosition = Vector3.zero; // Garante que o item esteja centralizado no slot

        // Limpa o item carregado globalmente
        Inventory.carriedItem = null;
    }
}