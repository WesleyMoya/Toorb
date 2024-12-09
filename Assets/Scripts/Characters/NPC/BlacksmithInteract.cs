using UnityEngine;

public class Blacksmith : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite npcIcon;
    [SerializeField] private string npcName = "Ferreiro";
    [SerializeField] private string buttonText = "Loja";
    [SerializeField] private string dialogContent = "Bem-vindo ao ferreiro! O que você gostaria de fazer?";
    [SerializeField] private GameObject blacksmithMenu; // Menu específico do ferreiro
    
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    public void Interact()
    {
        if (dialogManager != null)
        {
            dialogManager.StartDialog(npcIcon, npcName, dialogContent, buttonText, blacksmithMenu); // Inicia o diálogo com o menu do ferreiro
        }
    }
}