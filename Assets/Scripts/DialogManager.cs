using UnityEngine;
using UnityEngine.UI;
using TMPro; // Certifique-se de incluir a namespace do TextMeshPro

public class DialogManager : MonoBehaviour
{
    [SerializeField] private Image npcIcon; // Referência à imagem do ícone do NPC
    [SerializeField] private TextMeshProUGUI npcName; // Referência ao texto do nome do NPC
    [SerializeField] private TextMeshProUGUI dialogContent; // Referência ao texto do conteúdo do diálogo
    [SerializeField] private GameObject dialogPanel; // Referência ao painel da caixa de diálogo
    [SerializeField] private GameObject hud;
    private void Start()
    {
        dialogPanel.SetActive(false); // Certifique-se de que o painel esteja desativado no início
    }

    // Método para iniciar o diálogo com os parâmetros
    public void StartDialog(Sprite icon, string name, string content)
    {
        npcIcon.sprite = icon; // Define o ícone do NPC
        npcName.text = name; // Define o nome do NPC
        dialogContent.text = content; // Define o conteúdo do diálogo
        hud.SetActive(false);
        dialogPanel.SetActive(true); // Ativa o painel da caixa de diálogo
    }

    // Método para fechar a caixa de diálogo
    public void CloseDialog()
    {
        dialogPanel.SetActive(false); // Desativa o painel da caixa de diálogo
        hud.SetActive(true);
    }
}
