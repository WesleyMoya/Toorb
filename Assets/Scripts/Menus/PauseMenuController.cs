using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameInputsHandler gameInputsHandler;

    public void ResumeGame()
    {
        gameInputsHandler.ResumeGame();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneLoader.NextScene = "MenuPrincipal"; // Define a pr�xima cena a ser carregada
        SceneManager.LoadScene("Loading Scene"); // Carrega a cena de loading
    }

    public void SaveProgress()
    {
        Debug.Log("Progresso salvo!");
    }

    public void OpenOptions()
    {
        gameInputsHandler.TogglePause(); // Fecha o menu de pausa para abrir o menu de op��es
        GameObject pai = GameObject.Find("CanvasDoMenuOp��es");

        // Se o objeto "Pai" for encontrado, encontre o objeto "Filho" dentro dele
        if (pai != null)
        {
            GameObject filho = pai.transform.Find("Options").gameObject;

            // Se o objeto "Filho" for encontrado, ative-o
            if (filho != null)
            {
                filho.SetActive(true);
            }
        }
    }
    public void CloseOptions()
    {
 
    }
}