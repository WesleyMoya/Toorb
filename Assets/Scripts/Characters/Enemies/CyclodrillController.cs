using UnityEngine; // Namespace principal do Unity.
using System.Collections; // Necessário para usar Corrotinas.

public class CyclodrillController : MonoBehaviour
{
    // Configurações de movimento e ataque
    public float Cyclodrill_moveSpeed = 3.5f; // Velocidade de movimento do inimigo.
    public float attackRange = 0.5f; // Distância mínima para iniciar o ataque ao jogador.
    public float attackCooldown = 1.5f; // Intervalo mínimo entre ataques.
    private float lastAttackTime; // Armazena o tempo do último ataque.

    public Animator anim; // Referência ao Animator para controlar animações.
    public EnemyDetection detectionArea; // Referência ao script que detecta os jogadores.
    private Rigidbody2D rb; // Referência ao componente Rigidbody2D para movimentação física.
    private Vector2 movement; // Direção atual de movimento.
    private Vector2 lastDirection; // Última direção registrada, usada para animações.
    public Enemy enemy; // Referência ao componente que controla atributos do inimigo.
    private bool isAttacking; // Indica se o inimigo está realizando um ataque no momento.

    // Inicialização do script.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém o componente Rigidbody2D.
        enemy = GetComponent<Enemy>(); // Obtém o componente Enemy.
    }

    // Usado para física e movimentação.
    private void FixedUpdate()
    {
        // Interrompe a movimentação se o inimigo estiver atacando.
        if (isAttacking)
        {
            rb.velocity = Vector2.zero; // Para o movimento.
            anim.SetBool("IsMoving", false); // Desativa a animação de movimento.
            return;
        }

        // Verifica se há jogadores detectados.
        if (detectionArea.detectedObjs.Count > 0)
        {
            // Obtém a posição do primeiro jogador detectado.
            Transform player = detectionArea.detectedObjs[0].transform;
            Vector2 targetPosition = player.position;
            Vector2 direction = targetPosition - (Vector2)transform.position;
            movement = direction.normalized; // Normaliza a direção para limitar a magnitude.

            // Verifica se o jogador está ao alcance para ataque.
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                // Verifica o cooldown para o próximo ataque.
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    StartCoroutine(Attack(player)); // Inicia o ataque passando o jogador como alvo.
                    lastAttackTime = Time.time; // Atualiza o tempo do último ataque.
                }

                // Para o movimento e ativa a animação de ataque.
                rb.velocity = Vector2.zero;
                anim.SetBool("IsMoving", false);
                anim.SetBool("IsAttacking", true);
            }
            else
            {
                // Movimenta o inimigo em direção ao jogador.
                rb.MovePosition(rb.position + movement * Cyclodrill_moveSpeed * Time.fixedDeltaTime);
                anim.SetBool("IsMoving", true);
                anim.SetBool("IsAttacking", false);

                // Define a direção da animação com base no movimento.
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

                lastDirection = movement; // Armazena a última direção de movimento.
            }
        }
        else
        {
            // Quando não há jogadores detectados, o inimigo permanece parado.
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsAttacking", false);
            rb.velocity = Vector2.zero;
        }
    }

    // Corrotina para gerenciar o ataque ao jogador.
    private IEnumerator Attack(Transform player)
    {
        isAttacking = true; // Indica que o inimigo está atacando.

        // Define os parâmetros da direção para a animação de ataque.
        anim.SetFloat("AttackX", lastDirection.x);
        anim.SetFloat("AttackY", lastDirection.y);
        anim.SetTrigger("Attack"); // Dispara a animação de ataque.

        // Calcula a direção do ataque em relação ao jogador.
        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        // Toca a animação de "Hit" no jogador com base na direção.
        enemy.PlayHitAnimation(directionToPlayer);

        // Aguarda o tempo da animação de ataque antes de finalizar o estado de ataque.
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        isAttacking = false; // Finaliza o estado de ataque.
        anim.SetBool("IsAttacking", false);
    }
}