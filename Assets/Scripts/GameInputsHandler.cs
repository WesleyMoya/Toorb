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
        if (isMapOpen || isPauseMenuOpen) return;
        isInventoryOpen = !isInventoryOpen;
        isPlayerMovementLocked = isInventoryOpen;

        if (isInventoryOpen) OpenInventory();
        else CloseInventory();
    }

    public void ToggleMap()
    {
        if (isInventoryOpen || isPauseMenuOpen) return;
        isMapOpen = !isMapOpen;
        isPlayerMovementLocked = isMapOpen;

        if (isMapOpen) OpenMap();
        else CloseMap();
    }

    public void TogglePause()
    {
        isPauseMenuOpen = !isPauseMenuOpen;
        isPlayerMovementLocked = isPauseMenuOpen;

        if (isPauseMenuOpen) OpenPauseMenu();
        else ResumeGame();
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
    }
}