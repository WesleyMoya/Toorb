using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInputsHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameHUD;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject mapUI;
    [SerializeField] private GameObject pauseMenu;

    private bool isInventoryOpen = false;
    private bool isMapOpen = false;
    private bool isPauseMenuOpen = false;
    public bool isPlayerMovementLocked = false; // Variável para bloquear o movimento do jogador

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) ToggleInventory();
        if (Input.GetKeyDown(KeyCode.M)) ToggleMap();
        if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
    }

    public void ToggleInventory()
    {
        // Permite fechar o inventário mesmo se o movimento estiver bloqueado
        if (isInventoryOpen)
        {
            CloseInventory();
            return;
        }

        // Verifica se o movimento do jogador está bloqueado
        if (isPlayerMovementLocked) return;

        if (isMapOpen || isPauseMenuOpen) return;
        isInventoryOpen = true;
        isPlayerMovementLocked = true;

        OpenInventory();
    }

    public void ToggleMap()
    {
        // Permite fechar o mapa mesmo se o movimento estiver bloqueado
        if (isMapOpen)
        {
            CloseMap();
            return;
        }

        // Verifica se o movimento do jogador está bloqueado
        if (isPlayerMovementLocked) return;

        if (isInventoryOpen || isPauseMenuOpen) return;
        isMapOpen = true;
        isPlayerMovementLocked = true;

        OpenMap();
    }

    public void TogglePause()
    {
        // Permite fechar o menu de pausa mesmo se o movimento estiver bloqueado
        if (isPauseMenuOpen)
        {
            ResumeGame();
            return;
        }

        // Verifica se o movimento do jogador está bloqueado
        if (isPlayerMovementLocked) return;

        isPauseMenuOpen = true;
        isPlayerMovementLocked = true;

        OpenPauseMenu();
    }

    private void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        gameHUD.SetActive(false);
        Time.timeScale = 0; // Pausa o jogo
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gameHUD.SetActive(true);
        isPauseMenuOpen = false;
        isPlayerMovementLocked = false;
        Time.timeScale = 1; // Retoma o jogo
    }

    private void OpenMap()
    {
        gameHUD.SetActive(false);
        mapUI.SetActive(true);
    }

    private void CloseMap()
    {
        mapUI.SetActive(false);
        gameHUD.SetActive(true);
        isMapOpen = false;
        isPlayerMovementLocked = false; // Permite movimento ao fechar o mapa
    }

    private void OpenInventory()
    {
        gameHUD.SetActive(false);
        inventoryUI.SetActive(true);
    }

    private void CloseInventory()
    {
        inventoryUI.SetActive(false);
        gameHUD.SetActive(true);
        isInventoryOpen = false;
        isPlayerMovementLocked = false; // Permite movimento ao fechar o inventário
    }

    
}