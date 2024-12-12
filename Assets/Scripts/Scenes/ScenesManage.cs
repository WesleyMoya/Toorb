using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManage : MonoBehaviour
{
    public static ScenesManage instance;

    [SerializeField] private GameObject hud; // Referência ao HUD
    [SerializeField] private PlayerController playerController; // Referência ao script do Player

    void Awake()
    {
        // Garante que este objeto é único e persistente
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Vincula o evento de cena carregada
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Chame esta função para iniciar a transição de cena
    public void TransitionToScene(string sceneName)
    {
        // Desativa o HUD e bloqueia o movimento antes da transição
        if (hud != null) hud.SetActive(false);
        if (playerController != null) playerController.LockMovement();

        // Carrega a nova cena
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica se estamos na cena "Jogo2"
        if (scene.name == "Jogo2")
        {
            // Reativa o HUD e desbloqueia o movimento do jogador
            if (hud != null) hud.SetActive(true);
            if (playerController != null) playerController.UnlockMovement();
        }
    }
}
