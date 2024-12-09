using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // Referências ao HUD, PlayerController e Menu NPC
    public GameObject hud; // Arraste o GameObject do HUD aqui no Inspector
    public GameObject menuNPC; // Arraste o GameObject do Menu NPC aqui no Inspector
    private PlayerController playerController;

    private void Start()
    {
        // Encontra o GameObject do Player e obtém o PlayerController
        GameObject playerMovementObject = GameObject.Find("Toorb"); // Substitua "Toorb" pelo nome correto do seu GameObject
        playerController = playerMovementObject.GetComponent<PlayerController>();
    }

    // Método para habilitar o HUD, destravar o personagem e desabilitar o menu NPC
    public void OnButtonPressed()
    {
        hud.SetActive(true); // Habilita o HUD
        playerController.UnlockMovement(); // Desbloqueia o movimento do jogador
        menuNPC.SetActive(false); // Desabilita o menu NPC
    }
}
