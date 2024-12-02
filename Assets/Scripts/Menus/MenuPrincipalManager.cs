using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo = "Jogo1"; // Nome da cena do jogo
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject imagemMenuInicial;
    [SerializeField] private LoadingManager loadingManager; // Referência ao LoadingManager

    public void Jogar()
    {
        if (loadingManager != null)
        {
            loadingManager.LoadScene("Loading Scene"); // Carregar a cena de loading
        }
        else
        {
            Debug.LogError("LoadingManager não foi atribuído no inspetor.");
        }
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
        imagemMenuInicial.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
        imagemMenuInicial.SetActive(false);
    }

    public void Sair()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }
}