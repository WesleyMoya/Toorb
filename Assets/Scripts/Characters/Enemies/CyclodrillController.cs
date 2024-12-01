using UnityEngine;
using System.Collections;

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
            rb.velocity = Vector2.zero;
            anim.SetBool("IsMoving", false);
            return;
        }

        if (detectionArea.detectedObjs.Count > 0)
        {
            Transform player = detectionArea.detectedObjs[0].transform;
            Vector2 targetPosition = player.position;
            Vector2 direction = targetPosition - (Vector2)transform.position;
            movement = direction.normalized;

            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    StartCoroutine(Attack(player)); // Passa o jogador como alvo
                    lastAttackTime = Time.time;
                }

                rb.velocity = Vector2.zero;
                anim.SetBool("IsMoving", false);
                anim.SetBool("IsAttacking", true);
            }
            else
            {
                rb.MovePosition(rb.position + movement * Cyclodrill_moveSpeed * Time.fixedDeltaTime);
                anim.SetBool("IsMoving", true);
                anim.SetBool("IsAttacking", false);

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

                lastDirection = movement;
            }
        }
        else
        {
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsAttacking", false);
            rb.velocity = Vector2.zero;
        }
    }

    private IEnumerator Attack(Transform player)
    {
        isAttacking = true;

        anim.SetFloat("AttackX", lastDirection.x);
        anim.SetFloat("AttackY", lastDirection.y);
        anim.SetTrigger("Attack");

        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        // Toca a animação de Hit no inimigo com base na direção
        enemy.PlayHitAnimation(directionToPlayer);

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        isAttacking = false;
        anim.SetBool("IsAttacking", false);
    }
}