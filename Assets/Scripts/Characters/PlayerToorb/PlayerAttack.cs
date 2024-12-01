using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackGhost; // Objeto com o Collider do ataque
    [SerializeField] private int attackDamage = 10; // Dano causado pelo ataque

    public void ActivateAttack(Vector2 attackDirection)
    {
        // Calcula a posição fixa baseada na direção
        Vector2 attackPosition = Vector2.zero;

        if (attackDirection == Vector2.up) // Ataque para cima
            attackPosition = new Vector2(0, 0.6f); // Ajuste a posição no Y para cima
        else if (attackDirection == Vector2.down) // Ataque para baixo
            attackPosition = new Vector2(0, 0); // Ajuste a posição no Y para baixo
        else if (attackDirection == Vector2.right) // Ataque para direita
            attackPosition = new Vector2(0.4f, 0.2f); // Posição ajustada para a direita
        else if (attackDirection == Vector2.left) // Ataque para esquerda
            attackPosition = new Vector2(-0.4f, 0.2f); // Posição ajustada para a esquerda

        // Posiciona o objeto de ataque e ativa
        attackGhost.transform.localPosition = attackPosition;
        attackGhost.SetActive(true);
    }

    /// <summary>
    /// Desativa o ataque e oculta o objeto fantasma.
    /// </summary>
    public void DeactivateAttack()
    {
        attackGhost.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto atingido é um inimigo
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemyHealth = collision.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                Debug.Log("Dano causado ao inimigo: " + attackDamage);
            }
        }
    }
}