using UnityEngine;

public class Blacksmith : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite npcIcon; // Ícone do NPC
    [SerializeField] private string npcName = "Ferreiro"; // Nome do NPC
    [SerializeField] private string dialogContent = "Bem-vindo ao ferreiro! O que você gostaria de fazer?";
    
    private DialogManager dialogManager; // Referência ao gerenciador de diálogo

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>(); // Encontra o gerenciador de diálogo na cena
    }

    public void Interact()
    {
        if (dialogManager != null)
        {
            dialogManager.StartDialog(npcIcon, npcName, dialogContent); // Inicia o diálogo
        }
    }
}
