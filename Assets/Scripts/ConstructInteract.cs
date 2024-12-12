using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject constructMenu;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

    }
    public void Interact()
    {
        playerController.LockMovement();
        constructMenu.SetActive(true);
        GameObject hud = GameObject.Find("HUD");
        if (hud != null)
        {
            hud.SetActive(false);
        }
    }
}
