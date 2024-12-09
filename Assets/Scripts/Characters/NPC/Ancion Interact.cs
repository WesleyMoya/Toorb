using UnityEngine;

public class Ancion : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite npcIcon;
    [SerializeField] private string npcName = "Ancião";
    [SerializeField] private string buttonText = "Melhorias";
    [SerializeField] private string dialogContent = "O que você deseja, pequeno robô?";
    [SerializeField] private GameObject ancionMenu; // Menu específico do ferreiro

    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    public void Interact()
    {
        if (dialogManager != null)
        {
            dialogManager.StartDialog(npcIcon, npcName, dialogContent, buttonText, ancionMenu); // Inicia o diálogo com o menu do ferreiro
        }
    }
}