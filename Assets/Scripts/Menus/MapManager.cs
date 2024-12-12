using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public GameObject BackgroundMap1;
    public GameObject BackgroundMap2;

    private void Update()
    {
        // Verifica a cena atual
        string currentScene = SceneManager.GetActiveScene().name;

        // Ativa o GameObject correspondente à cena atual
        if (currentScene == "Jogo1")
        {
            BackgroundMap1.SetActive(true);
            BackgroundMap2.SetActive(false);
        }
        else if (currentScene == "Jogo2")
        {
            BackgroundMap1.SetActive(false);
            BackgroundMap2.SetActive(true);
        }
    }
}