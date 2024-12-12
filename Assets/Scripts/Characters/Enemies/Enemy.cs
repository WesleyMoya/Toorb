using UnityEngine; // Namespace principal para desenvolvimento no Unity.
using System.Collections; // Necessário para usar Corrotinas.
using System; // Não é usado diretamente no código, mas incluído aqui.

public class Enemy : MonoBehaviour
{
    public int maxHealth = 50; // Define a vida máxima do inimigo.
    private int currentHealth;  // Armazena a vida atual do inimigo.

    public Animator anim; // Referência ao componente Animator para controlar animações como "Hit" e "Death".

    // Referência ao script EnemyDeathManager para atualizar a contagem de inimigos derrotados.
    private EnemyDeathManager deathManager;

    // Método chamado uma vez no início da execução do jogo.
    void Start()
    {
        // Tenta localizar o objeto "EnemyDeathManager" na cena e obter seu componente EnemyDeathManager.
        GameObject deathManagerObject = GameObject.Find("EnemyDeathManager");
        if (deathManagerObject != null)
        {
            deathManager = deathManagerObject.GetComponent<EnemyDeathManager>();
        }
        else
        {
            // Exibe um erro no console se o objeto "EnemyDeathManager" não for encontrado.
            Debug.LogError("EnemyDeathManager não encontrado!");
        }

        // Inicializa a vida atual do inimigo com a vida máxima.
        currentHealth = maxHealth;
    }

    // Método público para o inimigo receber dano.
    public void TakeDamage(int damageAmount)
    {
        // Reduz a vida do inimigo pelo valor do dano recebido.
        currentHealth -= damageAmount;

        // Dispara a animação de dano usando o trigger "Hit".
        anim.SetTrigger("Hit");

        // Verifica se a vida chegou a 0 ou menos.
        if (currentHealth <= 0)
        {
            Die(); // Chama o método para lidar com a morte do inimigo.
        }
    }

    // Método para tocar a animação de dano direcionada (opcional, usado para animações que dependem da direção do ataque).
    public void PlayHitAnimation(Vector2 direction)
    {
        // Define os parâmetros da direção no Animator para ajustar a animação.
        anim.SetFloat("HitX", direction.x);
        anim.SetFloat("HitY", direction.y);
        anim.SetTrigger("Hit"); // Dispara a animação de hit.
    }

    // Método chamado quando o inimigo morre.
    void Die()
    {
        // Desativa o Collider2D do inimigo para evitar interações enquanto ele "morre".
        GetComponent<Collider2D>().enabled = false;

        // Atualiza a contagem de inimigos derrotados no EnemyDeathManager.
        if (deathManager != null)
        {
            deathManager.IncrementDefeatedEnemies(); // Incrementa o contador e atualiza o texto da UI.
        }

        // Inicia uma corrotina para esperar a animação de morte antes de destruir o objeto.
        StartCoroutine(DestroyAfterDeathAnimation());
    }

    // Corrotina para aguardar a animação de morte antes de destruir o objeto.
    IEnumerator DestroyAfterDeathAnimation()
    {
        // Aguarda 1 segundo (ou o tempo correspondente à animação de morte).
        yield return new WaitForSeconds(1f);

        // Remove o game object do inimigo da cena.
        Destroy(gameObject);
    }
}
