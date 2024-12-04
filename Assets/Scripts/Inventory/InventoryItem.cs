using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    private Image itemIcon;
    public CanvasGroup canvasGroup { get; private set; }
    public Item myItem { get; private set; }
    public InventorySlot activeSlot { get; set; }

    private bool isDragging = false;

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
            isDragging = true; // Inicia o arrasto
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            // Atualiza a posição do item para seguir o cursor do mouse
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 0; // Z deve ser 0 para 2D
            transform.position = mousePosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = false; // Para o arrasto
                                // Aqui você pode adicionar lógica para soltar o item no slot correto
        }
    }
}