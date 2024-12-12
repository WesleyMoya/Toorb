using UnityEngine; // Namespace principal do Unity.

public class Blacksmith : MonoBehaviour, IInteractable
{
    // Propriedades do NPC (ferreiro).
    [SerializeField] private Sprite npcIcon; // Ícone do NPC que será exibido no diálogo.
    [SerializeField] private string npcName = "Ferreiro"; // Nome do NPC.
    [SerializeField] private string buttonText = "Loja"; // Texto do botão exibido no diálogo.
    [SerializeField] private string dialogContent = "Bem-vindo ao ferreiro! O que você gostaria de fazer?"; // Mensagem de diálogo.
    [SerializeField] private GameObject blacksmithMenu; // Referência ao menu específico do ferreiro.

    private DialogManager dialogManager; // Referência ao gerenciador de diálogos.

    // Método chamado uma vez no início, quando o script é ativado.
    private void Start()
    {
        // Busca na cena um objeto com o componente DialogManager.
        dialogManager = FindObjectOfType<DialogManager>();
    }

    // Método da interface IInteractable, chamado ao interagir com o NPC.
    public void Interact()
    {
        // Verifica se o DialogManager foi encontrado na cena.
        if (dialogManager != null)
        {
            // Inicia o diálogo com os seguintes parâmetros:
            // - Ícone do NPC
            // - Nome do NPC
            // - Texto do diálogo
            // - Texto do botão
            // - Referência ao menu do ferreiro.
            dialogManager.StartDialog(npcIcon, npcName, dialogContent, buttonText, blacksmithMenu);
        }
    }
}