using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText; // Usando TextMeshProUGUI
    private string baseText = "Loading"; // Texto fixo
    private int dotCount = 0; // Contador para os pontos
    private float dotDelay = 0.5f; // Intervalo entre a troca dos pontos

    private void Start()
    {
        // Inicia a corrotina para carregar a cena e a animação de pontos
        StartCoroutine(LoadSceneCoroutine(SceneLoader.NextScene));
        StartCoroutine(UpdateLoadingTextCoroutine());
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // Exibir o texto de loading por 5 segundos
        float elapsed = 0f;
        while (elapsed < 5f)
        {
            elapsed += Time.deltaTime; // Aumenta o tempo decorrido
            yield return null; // Espera um frame
        }

        // Após 5 segundos, comece a carregar a cena
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // Enquanto a cena estiver carregando
        while (!operation.isDone)
        {
            yield return null; // Espera um frame
        }
    }

    private IEnumerator UpdateLoadingTextCoroutine()
    {
        while (true) // Loop infinito para atualizar a animação dos pontos
        {
            UpdateLoadingText();
            yield return new WaitForSeconds(dotDelay); // Espera um intervalo antes de atualizar novamente
        }
    }

    private void UpdateLoadingText()
    {
        loadingText.text = baseText + new string('.', dotCount);
        dotCount = (dotCount + 1) % 4; // Cicla entre 0 e 3
    }
}