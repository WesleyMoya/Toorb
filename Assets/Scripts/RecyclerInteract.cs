using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclerInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject recycleMenu;
    [SerializeField] private GameObject hud;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void Interact()
    {
        playerController.LockMovement();
        recycleMenu.SetActive(true);
        hud.SetActive(false);
    }
}
