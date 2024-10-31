using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclodrillController : MonoBehaviour
{
    public float Cyclodrill_moveSpeed = 3.5f;
    public float attackRange = 0.5f; // Distância mínima para atacar o jogador
    public float attackCooldown = 1.5f; // Tempo de espera entre ataques
    private float lastAttackTime;

    public Animator anim;
    public EnemyDetection detectionArea;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastDirection; // Armazena a última direção do inimigo
    public Enemy enemy; // Referência ao componente de atributos do enemy
    private bool isAttacking; // Indica se o inimigo está no meio de um ataque

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            // Impede o movimento durante o ataque
            rb.velocity = Vector2.zero;
            anim.SetBool("IsMoving", false); // Certifique-se de que IsMoving é false durante o ataque
            return;
        }

        if (detectionArea.detectedObjs.Count > 0)
        {
            Transform player = detectionArea.detectedObjs[0].transform;
            Vector2 targetPosition = player.position;
            Vector2 direction = targetPosition - (Vector2)transform.position;
            movement = direction.normalized;

            // Checa a distância do inimigo ao jogador
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                // Tentar atacar se o cooldown tiver terminado
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    StartCoroutine(Attack()); // Inicia a coroutine de ataque
                    lastAttackTime = Time.time; // Atualiza o tempo do último ataque
                }

                rb.velocity = Vector2.zero; // Parar o movimento do inimigo ao atacar
                anim.SetBool("IsMoving", false); // Parar animação de movimento
                anim.SetBool("IsAttacking", true); // Atualiza para indicar que está atacando
            }
            else
            {
                // Movimento em direção ao jogador quando fora da distância de ataque
                rb.MovePosition(rb.position + movement * Cyclodrill_moveSpeed * Time.fixedDeltaTime);
                anim.SetBool("IsMoving", true); // Inicia animação de movimento
                anim.SetBool("IsAttacking", false); // Certifique-se de que não está atacando

                // Atualiza a animação de direção
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    anim.SetFloat("MoveX", movement.x);
                    anim.SetFloat("MoveY", 0);
                }
                else
                {
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", movement.y);
                }

                lastDirection = movement; // Atualiza última direção do movimento
            }
        }
        else
        {
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsAttacking", false); // Certifique-se de que não está atacando
            rb.velocity = Vector2.zero;
        }
    }

    // Função para realizar o ataque
    private IEnumerator Attack()
    {
        isAttacking = true; // Impede movimento durante o ataque

        // Define a direção do ataque com base na última direção do movimento
        anim.SetFloat("AttackX", lastDirection.x);
        anim.SetFloat("AttackY", lastDirection.y);
        anim.SetTrigger("Attack"); // Inicia a animação de ataque

        // Aguarda a duração da animação de ataque
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        isAttacking = false; // Permite movimento novamente após o ataque
        anim.SetBool("IsAttacking", false); // Certifique-se de que não está atacando
    }
}