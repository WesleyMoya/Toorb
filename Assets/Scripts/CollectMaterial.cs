using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMaterial : MonoBehaviour, IInteractable
{
    public enum MaterialType { Plastic, Metal, Wood }
    public enum Size { Mini, Medium, Big }

    [SerializeField] private MaterialType materialType;
    [SerializeField] private Size size;
    [SerializeField] private int value;

    private Animator animator;
    private InventoryManager inventoryManager;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        inventoryManager = FindObjectOfType<InventoryManager>();

    }

    public void Interact()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        // Toca a animação de desaparecimento com o trigger específico
        string animationTrigger = GetAnimationTrigger();
        animator.SetTrigger(animationTrigger);

        // Inicia a destruição do objeto após a animação
        StartCoroutine(DestroyAfterAnimation());
        
        // Adiciona o valor ao inventário do jogador
        if (inventoryManager != null)
        {
            inventoryManager.AddMaterial(materialType, value);
        }
    }

    private string GetAnimationTrigger()
    {
        return $"{materialType}{size}_Disappear"; // Exemplo: "PlasticMini_Disappear"
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Corrotina para esperar a animação acabar
        float animationDuration = 0.5f; 
        yield return new WaitForSeconds(animationDuration);

        // Destrói o objeto
        Destroy(gameObject);
    }
}