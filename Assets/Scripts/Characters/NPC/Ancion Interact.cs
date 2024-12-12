using UnityEngine; // Importa o namespace base do Unity.

public class Ancion : MonoBehaviour, IInteractable // Define a classe Ancion que implementa a interface IInteractable.
{
    // Propriedades do NPC Anci�o, configur�veis no Unity Inspector.
    [SerializeField] private Sprite npcIcon; // �cone do NPC que ser� exibido no di�logo.
    [SerializeField] private string npcName = "Anci�o"; // Nome do NPC que aparecer� no di�logo.
    [SerializeField] private string buttonText = "Melhorias"; // Texto do bot�o exibido no di�logo.
    [SerializeField] private string dialogContent = "O que voc� deseja, pequeno rob�?"; // Mensagem inicial do di�logo.
    [SerializeField] private GameObject ancionMenu; // Refer�ncia ao menu associado ao NPC Anci�o.

    private DialogManager dialogManager; // Refer�ncia ao gerenciador de di�logos.

    // M�todo chamado automaticamente pelo Unity quando o GameObject que cont�m este script � ativado.
    private void Start()
    {
        // Procura um objeto na cena que contenha o componente DialogManager e salva a refer�ncia.
        dialogManager = FindObjectOfType<DialogManager>();

        // Verifica se o DialogManager foi encontrado.
        if (dialogManager == null)
        {
            Debug.LogError("DialogManager n�o encontrado! Certifique-se de que ele est� presente na cena.");
        }
    }

    // M�todo da interface IInteractable, chamado quando o jogador interage com o NPC.
    public void Interact()
    {
        // Verifica se o DialogManager est� dispon�vel antes de iniciar o di�logo.
        if (dialogManager != null)
        {
            // Inicia o di�logo com os seguintes par�metros:
            // - �cone do NPC (npcIcon).
            // - Nome do NPC (npcName).
            // - Mensagem do di�logo (dialogContent).
            // - Texto do bot�o (buttonText).
            // - Menu espec�fico do NPC (ancionMenu).
            dialogManager.StartDialog(npcIcon, npcName, dialogContent, buttonText, ancionMenu);
        }
        else
        {
            // Mensagem de aviso caso o DialogManager n�o esteja configurado corretamente.
            Debug.LogWarning("N�o foi poss�vel iniciar o di�logo porque o DialogManager est� ausente.");
        }
    }
}