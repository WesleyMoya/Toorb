using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    // Variáveis para armazenar a direção e a última direção de movimento
    private Vector2 movement;
    private Vector2 lastMoveDirection;

    public Animator anim;
    private bool isAttacking = false;

    public GameObject playerAttack; // GameObject que contém o BoxCollider2D para o ataque

    // Variáveis para priorizar o eixo do movimento
    private bool prioritizeX; // Armazena se o eixo X foi o primeiro pressionado
    private bool moving; // Armazena se o personagem está se movendo

    // Referência ao GameInputsHandler
    [SerializeField] private GameInputsHandler gameInputsHandler;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        prioritizeX = false; // Começa sem priorizar nenhum eixo
        moving = false; // Começa parado
        playerAttack.SetActive(false); // Desativa o PlayerAttack inicialmente

        // Obtém a referência ao GameInputsHandler
        gameInputsHandler = FindObjectOfType<GameInputsHandler>();
    }

    void Update()
    {
        // Só processa inputs de movimento se não estiver atacando e se o movimento não estiver bloqueado
        if (!isAttacking && !gameInputsHandler.isPlayerMovementLocked)
        {
            ProcessInputs();
        }
        Animate();

        // Detecta o input de ataque com o clique do mouse
        if (Input.GetMouseButtonDown(0) && !isAttacking) // Clique esquerdo do mouse para atacar
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Attack(mousePosition);
        }
    }

    void ProcessInputs()
    {
        // Captura a entrada do teclado
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Verifica se o jogador está se movendo
        if (!moving)
        {
            // Prioriza o primeiro eixo pressionado
            if (Mathf.Abs(moveX) > 0)
            {
                prioritizeX = true;
                moving = true; // O personagem está se movendo
            }
            else if (Mathf.Abs(moveY) > 0)
            {
                prioritizeX = false;
                moving = true; // O personagem está se movendo
            }
        }

        // Movimento baseado no eixo priorizado
        if (moving)
        {
            if (prioritizeX)
            {
                movement = new Vector2(moveX, 0).normalized;
                if (Mathf.Abs(moveX) == 0) // Para de se mover no eixo X se a tecla for solta
                {
                    moving = false;
                    movement = Vector2.zero;
                }
            }
            else
            {
                movement = new Vector2(0, moveY).normalized;
                if (Mathf.Abs(moveY) == 0) // Para de se mover no eixo Y se a tecla for solta
                {
                    moving = false;
                    movement = Vector2.zero;
                }
            }
        }

        // Atualiza a última direção de movimento apenas se o personagem estiver se movendo
        if (movement != Vector2.zero)
        {
            lastMoveDirection = movement;
        }
    }

    void FixedUpdate()
    {
        // Só aplica movimento se não estiver atacando e se o movimento não estiver bloqueado
        if (!isAttacking && !gameInputsHandler.isPlayerMovementLocked)
        {
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Animate()
    {
        anim.SetFloat("X", movement.x);
        anim.SetFloat("Y", movement.y);
        anim.SetFloat("MoveMagnitude", movement.magnitude);
        anim.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        anim.SetFloat("AnimLastMoveY", lastMoveDirection.y);
        anim.SetBool("IsAttacking", isAttacking);
    }

    void Attack(Vector2 targetPosition)
    {
        // Calcula a direção entre o personagem e a posição do clique do mouse
        Vector2 attackDirection = (targetPosition - (Vector2)transform.position).normalized;

        // Define os parâmetros do Blend Tree para ataque
        anim.SetFloat("AttackX", attackDirection.x);
        anim.SetFloat("AttackY", attackDirection.y);

        // Ativa o PlayerAttack para o alcance do ataque
        playerAttack.SetActive(true);

        // Ajusta a posição do PlayerAttack de acordo com a direção do ataque
        playerAttack.transform.localPosition = attackDirection * 0.5f; // Ajusta a distância para o alcance do ataque

        // Ajusta o tamanho do collider baseado na direção do ataque
        if (Mathf.Abs(attackDirection.x) > Mathf.Abs(attackDirection.y))
        {
            // Ataque na horizontal, ajuste o BoxCollider para ser mais largo e menos alto
            playerAttack.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 0.5f);
        }
        else
        {
            // Ataque na vertical, ajuste o BoxCollider para ser mais alto e menos largo
            playerAttack.GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 1.5f);
        }

        isAttacking = true;
        anim.SetTrigger("Attack");

        // Inicia a rotina para terminar o ataque após a animação
        StartCoroutine(EndAttack());
    }

    // Corrotina para finalizar o estado de ataque
    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.5f); // Ajuste para o tempo da animação
        isAttacking = false;
        playerAttack.SetActive(false); // Desativa o collider após o ataque
    }
}