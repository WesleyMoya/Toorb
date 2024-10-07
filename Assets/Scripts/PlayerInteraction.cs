using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] public GameObject interactionIcon;
    public KeyCode interactionKey = KeyCode.E;
    private bool isPlayerInRange = false;
    private GameObject currentInteractableObject; // Armazena o objeto atual com o qual o player pode interagir

    void Start()
    {
        interactionIcon.SetActive(false);
    }

    void Update()
    {
        // Verifica se o jogador está no alcance de algum objeto e se a tecla de interação foi pressionada
        if (isPlayerInRange && Input.GetKeyDown(interactionKey) && currentInteractableObject != null)
        {
            currentInteractableObject.GetComponent<IInteractable>().Interact();
        }

        // Atualiza a posição do ícone ao lado do personagem
        if (interactionIcon.activeSelf)
        {
            Vector3 iconPosition = transform.position + new Vector3(0.8f, 0.8f, 0); // Ajusta o deslocamento conforme necessário
            interactionIcon.transform.position = iconPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            currentInteractableObject = collision.gameObject;
            interactionIcon.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactionIcon.SetActive(false); 
            isPlayerInRange = false;
            currentInteractableObject = null;
        }
    }
}