using UnityEngine; // Namespace principal do Unity.

public class SeelerInteract : MonoBehaviour, IInteractable
{
    // Propriedades do NPC (mercador/ferreiro).
    [SerializeField] private Sprite npcIcon; // �cone do NPC a ser exibido no di�logo.
    [SerializeField] private string npcName = "Mercante"; // Nome do NPC.
    [SerializeField] private string buttonText = "Loja"; // Texto do bot�o de intera��o no di�logo.
    [SerializeField] private string dialogContent = "Ola, aqui vendemos equipamentos! Quer um?"; // Mensagem exibida no di�logo.
    [SerializeField] private GameObject seelermenu; // Refer�ncia ao menu do mercador.

    private DialogManager dialogManager; // Refer�ncia ao gerenciador de di�logos.

    // M�todo chamado uma vez no in�cio do script, quando o objeto � ativado.
    private void Start()
    {
        // Busca na cena um objeto com o componente DialogManager.
        dialogManager = FindObjectOfType<DialogManager>();
    }

    // M�todo implementado da interface IInteractable, chamado ao interagir com o NPC.
    public void Interact()
    {
        // Verifica se o gerenciador de di�logos foi encontrado.
        if (dialogManager != null)
        {
            // Inicia o di�logo passando os par�metros necess�rios:
            // - �cone do NPC
            // - Nome do NPC
            // - Texto do di�logo
            // - Texto do bot�o
            // - Refer�ncia ao menu espec�fico do NPC.
            dialogManager.StartDialog(npcIcon, npcName, dialogContent, buttonText, seelermenu);
        }
    }
}