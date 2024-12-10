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
    [SerializeField] private LoadingManager loadingManager; // Refer�ncia ao LoadingManager

    public void Jogar()
    {
        SceneLoader.NextScene = nomeDoLevelDeJogo; // Define a pr�xima cena a ser carregada
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