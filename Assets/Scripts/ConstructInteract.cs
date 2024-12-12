using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject constructMenu;
    [SerializeField] private GameObject hud;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void Interact()
    {
        playerController.LockMovement();
        constructMenu.SetActive(true);
        hud.SetActive(false);
    }
}
