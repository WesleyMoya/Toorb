using UnityEngine;

public class Ancion : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite npcIcon;
    [SerializeField] private string npcName = "Anci�o";
    [SerializeField] private string buttonText = "Melhorias";
    [SerializeField] private string dialogContent = "O que voc� deseja, pequeno rob�?";
    [SerializeField] private GameObject ancionMenu; // Menu espec�fico do ferreiro

    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    public void Interact()
    {
        if (dialogManager != null)
        {
            dialogManager.StartDialog(npcIcon, npcName, dialogContent, buttonText, ancionMenu); // Inicia o di�logo com o menu do ferreiro
        }
    }
}