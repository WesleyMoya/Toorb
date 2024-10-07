using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int plasticQnt = 0;
    public int metalQnt = 0;
    public int woodQnt = 0;

    [SerializeField] private TextMeshProUGUI plasticText;
    [SerializeField] private TextMeshProUGUI metalText;
    [SerializeField] private TextMeshProUGUI woodText;

    private void Start()
    {
        UpdateUI();
    }

    // Função para adicionar material ao inventário
    public void AddMaterial(CollectibleMaterial.MaterialType materialType, int value)
    {
        switch (materialType)
        {
            case CollectibleMaterial.MaterialType.Plastic:
                plasticQnt += value;
                Debug.Log("Plastic adicionado: " + value + ". Total: " + plasticQnt);
                break;
            case CollectibleMaterial.MaterialType.Metal:
                metalQnt += value;
                Debug.Log("Metal adicionado: " + value + ". Total: " + metalQnt);
                break;
            case CollectibleMaterial.MaterialType.Wood:
                woodQnt += value;
                Debug.Log("Wood adicionado: " + value + ". Total: " + woodQnt);
                break;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        plasticText.text = "Plastic: " + plasticQnt.ToString();
        metalText.text = "Metal: " + metalQnt.ToString();
        woodText.text = "Wood: " + woodQnt.ToString();
    }
}
