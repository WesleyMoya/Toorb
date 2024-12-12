using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para usar o Button

public class SceneTransitionAsk : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo = "Jogo2"; // Nome da cena do jogo
    [SerializeField] private LoadingManager loadingManager; // Referência ao LoadingManager
    // Referência ao GameObject que será habilitado
    public GameObject transitionSceneAskScreen;
    // Referência ao PlayerController
    private PlayerController playerController;

    // Referências aos botões
    public Button yesButton; // Arraste o botão "Sim" aqui no Inspector
    public Button noButton;  // Arraste o botão "Não" aqui no Inspector

    private void Start()
    {
        GameObject playerMovementObject = GameObject.Find("Toorb");
        playerController = playerMovementObject.GetComponent<PlayerController>();

        // Adiciona listeners aos botões
        yesButton.onClick.AddListener(OnYesButtonPressed);
        noButton.onClick.AddListener(OnNoButtonPressed);
    }

    // Método chamado quando o collider 2D do objeto entra em contato com outro collider 2D
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

    // Método chamado quando o botão "Sim" é pressionado
    private void OnYesButtonPressed()
    {
        GameObject constructions = GameObject.Find("ConstructionArea");
        if (constructions != null)
        {
            constructions.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Objeto com Constructors não encontrado na cena.");
        }
        SceneLoader.NextScene = nomeDoLevelDeJogo; // Define a próxima cena a ser carregada
        SceneManager.LoadScene("Loading Scene"); // Carrega a cena de loading
        
        
    }

    // Método chamado quando o botão "Não" é pressionado
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
        playerController.UnlockMovement(); // Supondo que você tenha um método UnlockMovement no PlayerController
        // Desabilita a tela de transição
        transitionSceneAskScreen.SetActive(false);
    }
    
}