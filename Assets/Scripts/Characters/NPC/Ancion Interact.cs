using UnityEngine; // Importa o namespace base do Unity.

public class Ancion : MonoBehaviour, IInteractable // Define a classe Ancion que implementa a interface IInteractable.
{
    // Propriedades do NPC Ancião, configuráveis no Unity Inspector.
    [SerializeField] private Sprite npcIcon; // Ícone do NPC que será exibido no diálogo.
    [SerializeField] private string npcName = "Ancião"; // Nome do NPC que aparecerá no diálogo.
    [SerializeField] private string buttonText = "Melhorias"; // Texto do botão exibido no diálogo.
    [SerializeField] private string dialogContent = "O que você deseja, pequeno robô?"; // Mensagem inicial do diálogo.
    [SerializeField] private GameObject ancionMenu; // Referência ao menu associado ao NPC Ancião.

    private DialogManager dialogManager; // Referência ao gerenciador de diálogos.

    // Método chamado automaticamente pelo Unity quando o GameObject que contém este script é ativado.
    private void Start()
    {
        // Procura um objeto na cena que contenha o componente DialogManager e salva a referência.
        dialogManager = FindObjectOfType<DialogManager>();

        // Verifica se o DialogManager foi encontrado.
        if (dialogManager == null)
        {
            Debug.LogError("DialogManager não encontrado! Certifique-se de que ele está presente na cena.");
        }
    }

    // Método da interface IInteractable, chamado quando o jogador interage com o NPC.
    public void Interact()
    {
        // Verifica se o DialogManager está disponível antes de iniciar o diálogo.
        if (dialogManager != null)
        {
            // Inicia o diálogo com os seguintes parâmetros:
            // - Ícone do NPC (npcIcon).
            // - Nome do NPC (npcName).
            // - Mensagem do diálogo (dialogContent).
            // - Texto do botão (buttonText).
            // - Menu específico do NPC (ancionMenu).
            dialogManager.StartDialog(npcIcon, npcName, dialogContent, buttonText, ancionMenu);
        }
        else
        {
            // Mensagem de aviso caso o DialogManager não esteja configurado corretamente.
            Debug.LogWarning("Não foi possível iniciar o diálogo porque o DialogManager está ausente.");
        }
    }
}