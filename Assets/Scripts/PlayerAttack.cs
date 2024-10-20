using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10; // Dano base, pode ser modificado pelo item equipado

    // Dentro do script PlayerAttack (ou equivalente), onde se detecta a colisão
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemyHealth = collision.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage); // Aplica o dano ao inimigo
                Debug.Log("Dano causado ao inimigo: " + attackDamage);
            }
        }
    }

}