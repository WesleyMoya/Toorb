using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Velocidade constante de movimento
    public float moveSpeed = 5f;

    //Referência ao Rigidbody2D do personagem
    private Rigidbody2D rb;

    //Variável para armazenar a direção de movimento
    private Vector2 movement;
    private Vector2 lastMoveDirection;  // Mudei a capitalização para seguir o padrão de camelCase

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Obtém o componente Rigidbody2D ao iniciar o jogo
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
    }

    void ProcessInputs()
    {
        //Captura a entrada do teclado
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Define a direção de movimento, garantindo que o personagem se mova apenas em uma direção por vez
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
        //Aplica a força de movimento ao Rigidbody2D
        rb.velocity = movement * moveSpeed;
    }

    void Animate()
    {
        anim.SetFloat("X", movement.x);
        anim.SetFloat("Y", movement.y);
        anim.SetFloat("MoveMagnitude", movement.magnitude);

        // Envia as últimas direções para o Animator
        anim.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        anim.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }
}
