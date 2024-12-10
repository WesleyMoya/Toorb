using System.Collections;
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

    [SerializeField] private PlayerAttack playerAttackScript;
    [SerializeField] private GameInputsHandler gameInputsHandler;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        prioritizeX = false; // Começa sem priorizar nenhum eixo
        moving = false; // Começa parado

        // Garante que o PlayerAttack está desativado inicialmente
        playerAttackScript.DeactivateAttack();

        // Obtém a referência ao GameInputsHandler se não foi atribuído no Inspector
        if (gameInputsHandler == null)
        {
            gameInputsHandler = FindObjectOfType<GameInputsHandler>();
        }
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
        if (Input.GetMouseButtonDown(0) && !isAttacking && !gameInputsHandler.isPlayerMovementLocked) // Clique esquerdo do mouse para atacar
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Attack(); // Chama o ataque sem parâmetros, usando a direção da última movimentação
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (!moving)
        {
            if (Mathf.Abs(moveX) > 0)
            {
                prioritizeX = true;
                moving = true;
            }
            else if (Mathf.Abs(moveY) > 0)
            {
                prioritizeX = false;
                moving = true;
            }
        }

        if (moving)
        {
            if (prioritizeX)
            {
                movement = new Vector2(moveX, 0).normalized;
                if (Mathf.Abs(moveX) == 0)
                {
                    moving = false;
                    movement = Vector2.zero;
                }
            }
            else
            {
                movement = new Vector2(0, moveY).normalized;
                if (Mathf.Abs(moveY) == 0)
                {
                    moving = false;
                    movement = Vector2.zero;
                }
            }
        }

        if (movement != Vector2.zero)
        {
            lastMoveDirection = movement;
        }
    }

    void FixedUpdate()
    {
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

    public void Attack()
    {
        // Não permite atacar se o movimento está bloqueado ou se já está atacando
        if (isAttacking || gameInputsHandler.isPlayerMovementLocked) return;

        // Define os parâmetros do Blend Tree para ataque
        anim.SetFloat("AttackX", lastMoveDirection.x);
        anim.SetFloat("AttackY", lastMoveDirection.y);

        // Ativa o ataque na direção fixa (baseada na última direção de movimento)
        playerAttackScript.ActivateAttack(lastMoveDirection);

        // Configura o estado de ataque
        isAttacking = true;
        anim.SetTrigger("Attack");

        StartCoroutine(EndAttack());
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.5f); // Tempo da animação
        isAttacking = false;
        playerAttackScript.DeactivateAttack();
    }

    // Método para bloquear o movimento do jogador
    public void LockMovement()
    {
        gameInputsHandler.isPlayerMovementLocked = true;
    }

    // Método para desbloquear o movimento do jogador
    public void UnlockMovement()
    {
        gameInputsHandler.isPlayerMovementLocked = false;
    }
}