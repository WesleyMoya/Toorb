using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    // Variável para armazenar a direção e a ultima direção de movimento
    private Vector2 movement;
    private Vector2 lastMoveDirection;

    public Animator anim;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isAttacking) // Só processa inputs de movimento se não estiver atacando
        {
            ProcessInputs();
        }
        Animate();
        
        // Detecta o input de ataque
        if (Input.GetKeyDown(KeyCode.Q) && !isAttacking)
        {
            Attack();
        }
    }

    void ProcessInputs()
    {
        // Captura a entrada do teclado
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Define a direção de movimento, garantindo que o personagem se mova apenas em uma direção por vez
        if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
        {
            movement = new Vector2(moveX, 0).normalized;
        }
        else
        {
            movement = new Vector2(0, moveY).normalized;
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

    void Attack()
    {
        anim.SetTrigger("Attack");
        isAttacking = true;

        // Inicia a rotina para terminar o ataque após a animação
        StartCoroutine(EndAttack());
    }

    // Corrotina
    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }

}