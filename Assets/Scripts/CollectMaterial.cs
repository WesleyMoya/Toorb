using UnityEngine;
using System.Collections;

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
        string animationTrigger = GetAnimationTrigger();
        animator.SetTrigger(animationTrigger);
        StartCoroutine(DestroyAfterAnimation());
        //GameManager.instance.AddMaterial(materialType, value);
    }

    private string GetAnimationTrigger()
    {
        return $"{materialType}_{size}Disappear"; // Exemplo: "Plastic_MiniDisappear"
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
