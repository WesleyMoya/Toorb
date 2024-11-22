using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText; // Usando TextMeshProUGUI em vez de Text
    private string baseText = "Loading"; // Texto fixo
    private int dotCount = 0; // Contador para os pontos
    private float dotTimer = 0f; // Timer para a troca dos pontos
    private float dotDelay = 0.5f; // Intervalo entre a troca dos pontos

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // Enquanto carrega, atualiza a contagem de pontos
        while (!operation.isDone)
        {
            // Atualiza o texto de carregamento com os pontos
            UpdateLoadingText();

            yield return null;
        }
    }

    private void Update()
    {
        // Atualiza o temporizador de troca dos pontos
        if (loadingText != null)
        {
            dotTimer += Time.deltaTime;

            // Se o tempo passar, troca os pontos
            if (dotTimer >= dotDelay)
            {
                dotCount = (dotCount % 3) + 1; // Alterna entre 1, 2 e 3
                dotTimer = 0f; // Reset o temporizador
                UpdateLoadingText(); // Atualiza o texto
            }
        }
    }

    private void UpdateLoadingText()
    {
        if (loadingText != null)
        {
            string dots = new string('.', dotCount); // Cria a quantidade de pontos
            loadingText.text = baseText + dots; // Atualiza o texto no UI
        }
    }
}