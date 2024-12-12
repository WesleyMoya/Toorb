using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para usar o Button

public class SceneTransitionAsk : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo = "Jogo2"; // Nome da cena do jogo
    [SerializeField] private LoadingManager loadingManager; // Refer�ncia ao LoadingManager
    // Refer�ncia ao GameObject que ser� habilitado
    public GameObject transitionSceneAskScreen;
    // Refer�ncia ao PlayerController
    private PlayerController playerController;

    // Refer�ncias aos bot�es
    public Button yesButton; // Arraste o bot�o "Sim" aqui no Inspector
    public Button noButton;  // Arraste o bot�o "N�o" aqui no Inspector

    private void Start()
    {
        GameObject playerMovementObject = GameObject.Find("Toorb");
        playerController = playerMovementObject.GetComponent<PlayerController>();

        // Adiciona listeners aos bot�es
        yesButton.onClick.AddListener(OnYesButtonPressed);
        noButton.onClick.AddListener(OnNoButtonPressed);
    }

    // M�todo chamado quando o collider 2D do objeto entra em contato com outro collider 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (collision.CompareTag("Player"))
        {

            transitionSceneAskScreen.SetActive(true);
            // Tenta encontrar o HUD na cena
            GameObject hud = GameObject.Find("HUD");
            if (hud != null)
            {
                // Desabilita o HUD se encontrado
                hud.SetActive(false);
            }

            // Bloqueia o movimento e ataque do jogador
            playerController.LockMovement();
        }
    }

    // M�todo chamado quando o bot�o "Sim" � pressionado
    private void OnYesButtonPressed()
    {
        GameObject constructions = GameObject.Find("ConstructionArea");
        if (constructions != null)
        {
            constructions.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Objeto com Constructors n�o encontrado na cena.");
        }
        SceneLoader.NextScene = nomeDoLevelDeJogo; // Define a pr�xima cena a ser carregada
        SceneManager.LoadScene("Loading Scene"); // Carrega a cena de loading
        
        
    }

    // M�todo chamado quando o bot�o "N�o" � pressionado
    private void OnNoButtonPressed()
    {
        // Tenta encontrar o HUD na cena
        GameObject hud = GameObject.Find("HUD");
        if (hud != null)
        {
            // Habilita o HUD se encontrado
            hud.SetActive(true);
        }
        // Desbloqueia o movimento e ataque do jogador
        playerController.UnlockMovement(); // Supondo que voc� tenha um m�todo UnlockMovement no PlayerController
        // Desabilita a tela de transi��o
        transitionSceneAskScreen.SetActive(false);
    }
    
}