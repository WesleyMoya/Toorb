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
        SceneLoader.NextScene = nomeDoLevelDeJogo; // Define a próxima cena a ser carregada
        SceneManager.LoadScene("Loading Scene"); // Carrega a cena de loading
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
        Application.Quit();
    }
}