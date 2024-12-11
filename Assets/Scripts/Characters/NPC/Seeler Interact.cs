using UnityEngine;

public class SeelerInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite npcIcon;
    [SerializeField] private string npcName = "Mercante";
    [SerializeField] private string buttonText = "Loja";
    [SerializeField] private string dialogContent = "Ola, aqui vendemos equipamentos! Quer um?";
    [SerializeField] private GameObject seelermenu; // Menu específico do ferreiro

    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    public void Interact()
    {
        if (dialogManager != null)
        {
            dialogManager.StartDialog(npcIcon, npcName, dialogContent, buttonText, seelermenu); // Inicia o diálogo com o menu do ferreiro
        }
    }
}