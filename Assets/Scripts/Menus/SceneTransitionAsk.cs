using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para usar o Button

public class SceneTransitionAsk : MonoBehaviour
{
    // Refer�ncia ao GameObject que ser� habilitado
    public GameObject transitionSceneAskScreen;
    // Refer�ncias ao HUD e UIManager
    public GameObject hud;
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
            // Habilita o GameObject TransitionSceneAskScreen
            transitionSceneAskScreen.SetActive(true);
            // Desabilita o HUD
            hud.SetActive(false);
            // Bloqueia o movimento e ataque do jogador
            playerController.LockMovement();
        }
    }

    // M�todo chamado quando o bot�o "Sim" � pressionado
    private void OnYesButtonPressed()
    {
        // L�gica para o bot�o "Sim"
        Debug.Log("Sim pressionado. Continuando a transi��o...");
        // Aqui voc� pode adicionar a l�gica para continuar a transi��o de cena ou o que for necess�rio
    }

    // M�todo chamado quando o bot�o "N�o" � pressionado
    private void OnNoButtonPressed()
    {
        // L�gica para o bot�o "N�o"
        Debug.Log("N�o pressionado. Desbloqueando movimento e reabilitando HUD.");
        // Habilita o HUD
        hud.SetActive(true);
        // Desbloqueia o movimento e ataque do jogador
        playerController.UnlockMovement(); // Supondo que voc� tenha um m�todo UnlockMovement no PlayerController
        // Desabilita a tela de transi��o
        transitionSceneAskScreen.SetActive(false);
    }
}