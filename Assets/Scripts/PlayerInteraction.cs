using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] public GameObject interactionIcon; // Ícone de interação no personagem
    public KeyCode interactionKey = KeyCode.E; // Tecla de interação
    private bool isPlayerInRange = false; // Verifica se o jogador está no alcance de algum objeto interativo
    private GameObject currentInteractableObject; // Armazena o objeto atual com o qual o player pode interagir

    void Start()
    {
        // O ícone de interação começa desativado
        interactionIcon.SetActive(false);
    }

    void Update()
    {
        // Verifica se o jogador está no alcance de algum objeto e se a tecla de interação foi pressionada
        if (isPlayerInRange && Input.GetKeyDown(interactionKey) && currentInteractableObject != null)
        {
            // Chama o método de interação do objeto
            currentInteractableObject.GetComponent<IInteractable>().Interact();
        }

        // Atualiza a posição do ícone ao lado do personagem
        if (interactionIcon.activeSelf)
        {
            Vector3 iconPosition = transform.position + new Vector3(0.8f, 0.8f, 0); // Ajusta o deslocamento conforme necessário
            interactionIcon.transform.position = iconPosition;
        }
    }

    // Detecta quando o jogador entra no alcance de um objeto interativo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            currentInteractableObject = collision.gameObject; // Armazena o objeto com o qual o jogador pode interagir
            interactionIcon.SetActive(true); // Mostra o ícone de interação
            isPlayerInRange = true; // Define que o jogador está no alcance
        }
    }

    // Detecta quando o jogador sai do alcance de um objeto interativo
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactionIcon.SetActive(false); // Esconde o ícone de interação
            isPlayerInRange = false; // Define que o jogador saiu do alcance
            currentInteractableObject = null; // Reseta o objeto interativo atual
        }
    }
}