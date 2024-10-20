using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima do inimigo
    private int currentHealth;  // Vida atual do inimigo

    public Animator anim;  // Referência ao Animator para animações de dano/morte

    void Start()
    {
        currentHealth = maxHealth; // Define a vida atual para o valor máximo no início
    }

    // Método para o inimigo receber dano
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduz a vida pelo valor do dano recebido
        Debug.Log("Vida restante do inimigo: " + currentHealth);

        // Toca a animação de dano
        anim.SetTrigger("Hit");

        // Se a vida do inimigo chegar a 0, destrói o inimigo
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método chamado quando a vida chega a 0
    void Die()
    {
        Debug.Log("Inimigo destruído!");
        anim.SetTrigger("Die");  // Toca a animação de morte (se houver)
        GetComponent<Collider2D>().enabled = false; // Desativa o collider para impedir novas interações

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