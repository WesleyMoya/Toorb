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

    // Variáveis para priorizar o eixo do movimento
    private bool prioritizeX; // Armazena se o eixo X foi o primeiro pressionado
    private bool moving; // Armazena se o personagem está se movendo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        prioritizeX = false; // Começa sem priorizar nenhum eixo
        moving = false; // Começa parado
    }

    void Update()
    {
        if (!isAttacking) // Só processa inputs de movimento se não estiver atacando
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
        // Só aplica movimento se não estiver atacando
        if (!isAttacking)
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
    }
}