using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameInputsHandler gameInputsHandler;

    public void ResumeGame()
    {
        gameInputsHandler.ResumeGame();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveProgress()
    {
        Debug.Log("Progresso salvo!");
    }

    public void OpenOptions()
    {
        gameInputsHandler.TogglePause(); // Fecha o menu de pausa para abrir o menu de opções
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        gameInputsHandler.TogglePause(); // Retorna para o menu de pausa
    }
}