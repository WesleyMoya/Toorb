using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCdialogue : MonoBehaviour
{
    [SerializeField] public GameObject interactionIcon; // GameObject do ícone de interação
    public KeyCode interactionKey = KeyCode.E; // Tecla de interação
    private bool isPlayerInRange = false; // Verifica se o jogador está no alcance

    // Start is called before the first frame update
    void Start()
    {
        // O ícone de interação começa desativado
        interactionIcon.SetActive(false);
    }

    // Detecta quando o jogador entra no alcance
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionIcon.SetActive(true); // Mostra o ícone de interação
            isPlayerInRange = true; // Define que o jogador está no alcance
        }
    }

    // Detecta quando o jogador sai do alcance
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionIcon.SetActive(false); // Esconde o ícone de interação
            isPlayerInRange = false; // Define que o jogador saiu do alcance
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se o jogador está no alcance e se a tecla de interação foi pressionada
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            Interact(); // Chama o método de interação
        }
    }

    // Método de interação (a ser personalizado conforme necessário)
    void Interact()
    {
        Debug.Log("Interagiu com o NPC!");
        // Aqui você pode adicionar a lógica de diálogo, iniciar uma conversa, etc.
    }
}