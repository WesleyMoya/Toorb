using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private Image npcIcon;
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI dialogContent;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject hud;
    
    [SerializeField] private Button closeButton; // Botão para fechar o diálogo
    [SerializeField] private Button menuButton; // Botão para abrir o menu coringa
    private GameObject npcMenu; // Menu específico do NPC

    private void Start()
    {
        dialogPanel.SetActive(false);

        // Associa os botões às funções
        closeButton.onClick.AddListener(CloseDialog);
        menuButton.onClick.AddListener(OpenNpcMenu);
    }

    // Método para iniciar o diálogo com os parâmetros
    public void StartDialog(Sprite icon, string name, string content, GameObject npcSpecificMenu)
    {
        npcIcon.sprite = icon;
        npcName.text = name;
        dialogContent.text = content;
        npcMenu = npcSpecificMenu; // Recebe o menu específico do NPC

        hud.SetActive(false);
        dialogPanel.SetActive(true);
    }

    // Método para fechar o diálogo
    public void CloseDialog()
    {
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
        else
        {
            Debug.LogWarning("Nenhum menu específico para este NPC.");
        }
    }
}