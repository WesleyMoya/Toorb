using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMaterial : MonoBehaviour, IInteractable
{
    public enum MaterialType { Plastic, Metal, Wood, Trash }
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
        // Verificar se o inventário tem espaço antes de continuar
        if (!CanAddMaterial())
        {
            Debug.Log("Inventário cheio, não é possível coletar mais " + materialType);
            return; // Impede a coleta e a destruição do objeto
        }

        // Desativa o colisor para evitar interações repetidas
        GetComponent<BoxCollider2D>().enabled = false;

        MaterialType materialToAdd = materialType;

        // Se o material for Trash, escolhe aleatoriamente um material para adicionar ao inventário
        if (materialType == MaterialType.Trash)
        {
            materialToAdd = GetRandomMaterialType();
        }

        // Toca a animação de desaparecimento
        string animationTrigger = GetAnimationTrigger();
        animator.SetTrigger(animationTrigger);

        // Inicia a destruição do objeto após a animação
        StartCoroutine(DestroyAfterAnimation());
        
        // Adiciona o valor do material ao inventário do jogador
        if (inventoryManager != null)
        {
            inventoryManager.AddMaterial(materialToAdd, value);
        }
    }

    private bool CanAddMaterial()
    {
        switch (materialType)
        {
            case MaterialType.Plastic:
                return inventoryManager.plasticQnt + value <= inventoryManager.maxPlastic;
            case MaterialType.Metal:
                return inventoryManager.metalQnt + value <= inventoryManager.maxMetal;
            case MaterialType.Wood:
                return inventoryManager.woodQnt + value <= inventoryManager.maxWood;
            case MaterialType.Trash:
                // Para Trash, verificar os limites para os três materiais possíveis
                return inventoryManager.plasticQnt + value <= inventoryManager.maxPlastic ||
                       inventoryManager.metalQnt + value <= inventoryManager.maxMetal ||
                       inventoryManager.woodQnt + value <= inventoryManager.maxWood;
            default:
                return false;
        }
    }

    private MaterialType GetRandomMaterialType()
    {
        // Escolhe aleatoriamente entre Plastic, Metal, ou Wood
        MaterialType[] possibleMaterials = { MaterialType.Plastic, MaterialType.Metal, MaterialType.Wood };
        int randomIndex = Random.Range(0, possibleMaterials.Length);
        return possibleMaterials[randomIndex];
    }

    private string GetAnimationTrigger()
    {
        // Para Trash, usa o trigger "Trash..._Disappear". Para outros, usa seu próprio trigger.
        if (materialType == MaterialType.Trash)
        {
            return $"Trash{size}_Disappear"; // Exemplo: "TrashMini_Disappear"
        }
        else
        {
            return $"{materialType}{size}_Disappear"; // Exemplo: "PlasticMini_Disappear", "MetalBig_Disappear"
        }
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