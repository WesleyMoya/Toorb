using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima do inimigo
    private int currentHealth;  // Vida atual do inimigo

    public Animator anim;  // Referência ao Animator para animações de dano/morte

    // Referência ao script EnemyDeathManager
    private EnemyDeathManager deathManager;

    void Start()
    {
        // Tenta encontrar o objeto com o nome "EnemyDeathManager" e obter o componente EnemyDeathManager
        GameObject deathManagerObject = GameObject.Find("EnemyDeathManager");
        if (deathManagerObject != null)
        {
            deathManager = deathManagerObject.GetComponent<EnemyDeathManager>();
        }
        else
        {
            Debug.LogError("EnemyDeathManager não encontrado!");
        }

        currentHealth = maxHealth; // Define a vida atual para o valor máximo no início
    }

    // Método para o inimigo receber dano
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduz a vida pelo valor do dano recebido

        // Toca a animação de dano
        anim.SetTrigger("Hit");

        // Se a vida do inimigo chegar a 0, destrói o inimigo
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Nova função: Toca a animação de Hit com base na direção
    public void PlayHitAnimation(Vector2 direction)
    {
        anim.SetFloat("HitX", direction.x);
        anim.SetFloat("HitY", direction.y);
        anim.SetTrigger("Hit"); // Dispara a animação de hit
    }

    // Método chamado quando a vida chega a 0
    void Die()
    {
        Debug.Log("Inimigo destruído!");
        GetComponent<Collider2D>().enabled = false; // Desativa o collider para impedir novas interações

        // Incrementa a variável DerrotedEnemies no script EnemyDeathManager
        if (deathManager != null)
        {
            deathManager.IncrementDefeatedEnemies(); // Chama o método para incrementar e atualizar o texto
        }

        // Espera um tempo para a animação de morte e destrói o objeto
        StartCoroutine(DestroyAfterDeathAnimation());
    }

    // Corrotina para esperar pela animação de morte antes de destruir
    IEnumerator DestroyAfterDeathAnimation()
    {
        yield return new WaitForSeconds(1f); // Ajuste esse tempo para coincidir com a animação de morte
        Destroy(gameObject);  // Destrói o inimigo após a animação de morte
    }
}