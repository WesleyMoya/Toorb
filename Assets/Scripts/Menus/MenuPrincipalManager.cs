using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo = "Jogo1"; // Nome da cena do jogo
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private LoadingManager loadingManager; // Referência ao LoadingManager
    [SerializeField] private GameObject painelComoJogar;
    [SerializeField] private GameObject menuOpcoes;
    [SerializeField] private GameObject menuControles;
    public void Jogar()
    {
        SceneLoader.NextScene = nomeDoLevelDeJogo; // Define a próxima cena a ser carregada
        SceneManager.LoadScene("Loading Scene"); // Carrega a cena de loading
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }
    public void AbrirOpcoesComoJogar()
    {
        menuOpcoes.SetActive(false);
        painelComoJogar.SetActive(true);
    }

    public void FecharOpcoesComoJogar()
    {
        menuOpcoes.SetActive(true); ;
        painelComoJogar.SetActive(false);
    }
    public void AbrirOpcoesControles()
    {
        menuControles.SetActive(true); ;
    }

    public void FecharOpcoesControles()
    {
        menuControles.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }
}