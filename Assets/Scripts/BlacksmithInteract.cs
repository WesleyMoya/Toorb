using UnityEngine;

public class Blacksmith : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite npcIcon;
    [SerializeField] private string npcName = "Ferreiro";
    [SerializeField] private string dialogContent = "Bem-vindo ao ferreiro! O que você gostaria de fazer?";
    
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    public void Interact()
    {
        if (dialogManager != null)
        {
            dialogManager.StartDialog(npcIcon, npcName, dialogContent); // Inicia o diálogo
        }
    }
}