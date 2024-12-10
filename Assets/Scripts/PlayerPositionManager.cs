using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Verifica a cena atual
        if (SceneManager.GetActiveScene().name == "Jogo2")
        {
            // Encontra o objeto com a tag "Player"
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                // Define a nova posição do jogador
                player.transform.position = new Vector3(41f, 33f, 0f);
            }
            else
            {
                Debug.LogWarning("Objeto com a tag 'Player' não foi encontrado na cena.");
            }
        }

        if (SceneManager.GetActiveScene().name == "Jogo1")
        {
            // Encontra o objeto com a tag "Player"
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                // Define a nova posição do jogador
                player.transform.position = new Vector3(40f, -5f, 0f);
            }
            else
            {
                Debug.LogWarning("Objeto com a tag 'Player' não foi encontrado na cena.");
            }
        }
    }
}
