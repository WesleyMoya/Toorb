using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverOptions : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    // Função para destruir todos os objetos que estão com DontDestroyOnLoad
    public void TransitionToMenu()
    {
        // Encontra todos os objetos do tipo MonoBehaviour na cena
        DontDestroy[] dontDestroyObjects = FindObjectsOfType<DontDestroy>();
        
        // Itera sobre cada objeto encontrado e o destrói
        foreach (DontDestroy obj in dontDestroyObjects)
        {
            Destroy(obj.gameObject);
        }

        SceneLoader.NextScene = nomeDoLevelDeJogo; // Define a próxima cena a ser carregada
        SceneManager.LoadScene("Loading Scene"); // Carrega a cena de loading
    }

    public void TransitionToJogo1()
    {
        // Encontra todos os objetos do tipo MonoBehaviour na cena
        DontDestroy[] dontDestroyObjects = FindObjectsOfType<DontDestroy>();

        // Itera sobre cada objeto encontrado e o destrói
        foreach (DontDestroy obj in dontDestroyObjects)
        {
            Destroy(obj.gameObject);
        }

        SceneLoader.NextScene = nomeDoLevelDeJogo; // Define a próxima cena a ser carregada
        SceneManager.LoadScene("Loading Scene"); // Carrega a cena de loading
    }
}