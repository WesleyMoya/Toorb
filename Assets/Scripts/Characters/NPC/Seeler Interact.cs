using UnityEngine; // Namespace principal do Unity.

public class SeelerInteract : MonoBehaviour, IInteractable
{
    // Propriedades do NPC (mercador/ferreiro).
    [SerializeField] private Sprite npcIcon; // Ícone do NPC a ser exibido no diálogo.
    [SerializeField] private string npcName = "Mercante"; // Nome do NPC.
    [SerializeField] private string buttonText = "Loja"; // Texto do botão de interação no diálogo.
    [SerializeField] private string dialogContent = "Ola, aqui vendemos equipamentos! Quer um?"; // Mensagem exibida no diálogo.
    [SerializeField] private GameObject seelermenu; // Referência ao menu do mercador.

    private DialogManager dialogManager; // Referência ao gerenciador de diálogos.

    // Método chamado uma vez no início do script, quando o objeto é ativado.
    private void Start()
    {
        // Busca na cena um objeto com o componente DialogManager.
        dialogManager = FindObjectOfType<DialogManager>();
    }

    // Método implementado da interface IInteractable, chamado ao interagir com o NPC.
    public void Interact()
    {
        // Verifica se o gerenciador de diálogos foi encontrado.
        if (dialogManager != null)
        {
            // Inicia o diálogo passando os parâmetros necessários:
            // - Ícone do NPC
            // - Nome do NPC
            // - Texto do diálogo
            // - Texto do botão
            // - Referência ao menu específico do NPC.
            dialogManager.StartDialog(npcIcon, npcName, dialogContent, buttonText, seelermenu);
        }
    }
}