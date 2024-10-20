using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclodrillController : MonoBehaviour
{
    public float Cyclodrill_moveSpeed = 3.5f;
    public Animator anim;
    public EnemyDetection detectionArea;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Enemy enemy; // Referência ao componente de atributos do enemy

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>(); // Obtém o componente dos atributos do enemy no Start
    }

    private void FixedUpdate()
    {
        if(detectionArea.detectedObjs.Count > 0)
        {
            Vector2 targetPosition = detectionArea.detectedObjs[0].transform.position;
            Vector2 direction = targetPosition - (Vector2)transform.position;

            // Normaliza a direção para garantir que o movimento tenha magnitude constante
            movement = direction.normalized;

            // Movimenta o inimigo na direção calculada (combinando X e Y)
            rb.MovePosition(rb.position + movement * Cyclodrill_moveSpeed * Time.fixedDeltaTime);

            // Atualizar animação de movimento
            anim.SetBool("IsMoving", true);

            // Determinar a direção dominante (plano cartesiano)
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Se X for dominante, animação de movimento horizontal (direita/esquerda)
                anim.SetFloat("MoveX", movement.x);
                anim.SetFloat("MoveY", 0);
            }
            else
            {
                // Se Y for dominante, animação de movimento vertical (cima/baixo)
                anim.SetFloat("MoveX", 0);
                anim.SetFloat("MoveY", movement.y);
            }
        }
        else
        {
            // Parar animação de movimento quando o inimigo não está se movendo
            anim.SetBool("IsMoving", false);
        }
    }
}