using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Jogo1");
    }

    public void Sair()
    {
        
    }
}
