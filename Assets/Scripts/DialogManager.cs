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

    private void Start()
    {
        dialogPanel.SetActive(false);
    }

    // Método para iniciar o diálogo com os parâmetros
    public void StartDialog(Sprite icon, string name, string content)
    {
        npcIcon.sprite = icon;
        npcName.text = name;
        dialogContent.text = content;
        hud.SetActive(false);
        dialogPanel.SetActive(true);
    }

    public void CloseDialog()
    {
        dialogPanel.SetActive(false);
        hud.SetActive(true);
    }
}
