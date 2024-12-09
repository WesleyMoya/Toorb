using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para usar o Button

public class SceneTransitionAsk : MonoBehaviour
{
    // Referência ao GameObject que será habilitado
    public GameObject transitionSceneAskScreen;
    // Referências ao HUD e UIManager
    public GameObject hud;
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
            // Habilita o GameObject TransitionSceneAskScreen
            transitionSceneAskScreen.SetActive(true);
            // Desabilita o HUD
            hud.SetActive(false);
            // Bloqueia o movimento e ataque do jogador
            playerController.LockMovement();
        }
    }

    // Método chamado quando o botão "Sim" é pressionado
    private void OnYesButtonPressed()
    {
        // Lógica para o botão "Sim"
        Debug.Log("Sim pressionado. Continuando a transição...");
        // Aqui você pode adicionar a lógica para continuar a transição de cena ou o que for necessário
    }

    // Método chamado quando o botão "Não" é pressionado
    private void OnNoButtonPressed()
    {
        // Lógica para o botão "Não"
        Debug.Log("Não pressionado. Desbloqueando movimento e reabilitando HUD.");
        // Habilita o HUD
        hud.SetActive(true);
        // Desbloqueia o movimento e ataque do jogador
        playerController.UnlockMovement(); // Supondo que você tenha um método UnlockMovement no PlayerController
        // Desabilita a tela de transição
        transitionSceneAskScreen.SetActive(false);
    }
}