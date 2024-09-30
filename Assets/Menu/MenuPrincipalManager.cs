using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject imagemMenuInicial;

    public void Jogar()
    {
        // Mudar para adaptar o LoadGame depois !!!
        SceneManager.LoadScene(nomeDoLevelDeJogo);
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
        //apenas para teste
        Debug.Log("Saiu do jogo");

        Application.Quit();
    }
}
