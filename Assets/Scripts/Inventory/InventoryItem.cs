using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    private Image itemIcon;
    public CanvasGroup canvasGroup { get; private set; }
    public Item myItem { get; private set; }
    public InventorySlot activeSlot { get; set; }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemIcon = GetComponent<Image>();
    }

    public void Initialize(Item item, InventorySlot parent)
    {
        myItem = item;
        activeSlot = parent;
        activeSlot.myItem = this;
        itemIcon.sprite = item.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Inventory.Singleton.SetCarriedItem(this);
        }
    }
}