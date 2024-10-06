using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameInputsHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameHUD; 
    [SerializeField] private GameObject inventoryUI; 
    [SerializeField] private GameObject mapUI;
    //[SerializeField] private GameObject healthUI; GameObject pauseMenuUI;   // Referência ao painel do menu de pausa

    private bool isInventoryOpen = false;
    private bool isMapOpen = false;
    private bool isPauseMenuOpen = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap();
        }
    }
    public void ToggleInventory()
    {   
        if (isMapOpen) return;
        isInventoryOpen = !isInventoryOpen;

        if (isInventoryOpen)
        {
            OpenInventory();
        }
        else
        {
            CloseInventory();
        }
    }
    public void ToggleMap()
    {
        if (isInventoryOpen) return;
        isMapOpen = !isMapOpen;

        if(isMapOpen)
        {
            OpenMap();
        }
        else
        {
            CloseMap();
        }
    }
    private void TogglePause()
    {
        
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