using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private Image npcIcon;
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI Buttontext;
    [SerializeField] private TextMeshProUGUI dialogContent;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject hud;

    [SerializeField] private Button closeButton; // Botão para fechar o diálogo
    [SerializeField] private Button menuButton; // Botão para abrir o menu coringa
    private GameObject npcMenu; // Menu específico do NPC

    [SerializeField] private GameInputsHandler gameInputsHandler;

    private void Start()
    {
        gameInputsHandler = FindObjectOfType<GameInputsHandler>();
        dialogPanel.SetActive(false);

        // Associa os botões às funções
        closeButton.onClick.AddListener(CloseDialog);
        menuButton.onClick.AddListener(OpenNpcMenu);
    }

    // Método para iniciar o diálogo com os parâmetros
    public void StartDialog(Sprite icon, string name, string content, string buttonText, GameObject npcSpecificMenu)
    {
        gameInputsHandler.isPlayerMovementLocked = true;
        npcIcon.sprite = icon;
        npcName.text = name;
        dialogContent.text = content;
        npcMenu = npcSpecificMenu; // Recebe o menu específico do NPC
        Buttontext.text = buttonText;
        hud.SetActive(false);
        dialogPanel.SetActive(true);
    }

    // Método para fechar o diálogo
    public void CloseDialog()
    {
        gameInputsHandler.isPlayerMovementLocked = false;
        npcMenu.SetActive(false);
        dialogPanel.SetActive(false);
        hud.SetActive(true);
    }

    // Método para abrir o menu coringa (menu do NPC)
    public void OpenNpcMenu()
    {
        if (npcMenu != null)
        {
            npcMenu.SetActive(true); // Ativa o menu específico do NPC
            dialogPanel.SetActive(false); // Fecha a caixa de diálogo quando o menu é aberto
        }
    }
}