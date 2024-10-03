using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMaterial : MonoBehaviour, IInteractable
{
       public enum MaterialType { Plastic, Metal, Wood }
    public enum Size { Mini, Medium, Big }

    [SerializeField] private MaterialType materialType; // Tipo de material
    [SerializeField] private Size size; // Tamanho do material
    [SerializeField] private int value; // Valor do material

    private Animator animator; // Referência ao Animator

    private void Start()
    {
        animator = GetComponent<Animator>(); // Obtém o componente Animator
    }

    public void Interact()
    {
        // Desativa o collider
        GetComponent<BoxCollider2D>().enabled = false;
        // Toca a animação de desaparecimento com o trigger específico
        string animationTrigger = GetAnimationTrigger();
        animator.SetTrigger(animationTrigger);

        // Inicia a destruição do objeto após a animação
        StartCoroutine(DestroyAfterAnimation());
        
        // Adiciona o valor ao inventário do jogador
        //GameManager.instance.AddMaterial(materialType, value);
    }

    private string GetAnimationTrigger()
    {
        // Define o trigger da animação baseado no tipo e tamanho do material
        return $"{materialType}{size}_Disappear"; // Exemplo: "PlasticMini_Disappear"
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Define o tempo exato da animação (ajuste conforme necessário)
        float animationDuration = 0.5f; // Substitua pelo tempo real da sua animação
        yield return new WaitForSeconds(animationDuration);

        // Destrói o objeto
        Destroy(gameObject);
    }


}