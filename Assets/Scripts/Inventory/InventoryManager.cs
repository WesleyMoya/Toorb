using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int plasticQnt = 0;
    public int metalQnt = 0;
    public int woodQnt = 0;

    // Limites máximos de cada material
    public int maxPlastic = 100;
    public int maxMetal = 100;
    public int maxWood = 100;

    public int upgradeKey = 0;

    [SerializeField] private TextMeshProUGUI plasticText;
    [SerializeField] private TextMeshProUGUI metalText;
    [SerializeField] private TextMeshProUGUI woodText;

    private void Start()
    {
        UpdateUI();
    }

    // Função para adicionar material ao inventário
    public bool AddMaterial(CollectibleMaterial.MaterialType materialType, int value)
    {
        bool added = false;

        switch (materialType)
        {
            case CollectibleMaterial.MaterialType.Plastic:
                if (plasticQnt + value <= maxPlastic)
                {
                    plasticQnt += value;
                    added = true;
                    Debug.Log("Plastic adicionado: " + value + ". Total: " + plasticQnt);
                }
                else
                {
                    Debug.Log("Inventário de plástico cheio!");
                }
                break;

            case CollectibleMaterial.MaterialType.Metal:
                if (metalQnt + value <= maxMetal)
                {
                    metalQnt += value;
                    added = true;
                    Debug.Log("Metal adicionado: " + value + ". Total: " + metalQnt);
                }
                else
                {
                    Debug.Log("Inventário de metal cheio!");
                }
                break;

            case CollectibleMaterial.MaterialType.Wood:
                if (woodQnt + value <= maxWood)
                {
                    woodQnt += value;
                    added = true;
                    Debug.Log("Wood adicionado: " + value + ". Total: " + woodQnt);
                }
                else
                {
                    Debug.Log("Inventário de madeira cheio!");
                }
                break;
        }

        UpdateUI();
        return added; // Retorna true se o material foi adicionado, false se não foi
    }

    public void UpdateUI()
    {
        // Mostra a quantidade atual e o limite máximo de cada material
        plasticText.text = "Plastic: " + plasticQnt.ToString() + "/" + maxPlastic.ToString();
        metalText.text = "Metal: " + metalQnt.ToString() + "/" + maxMetal.ToString();
        woodText.text = "Wood: " + woodQnt.ToString() + "/" + maxWood.ToString();
    }

    // Função para verificar se o material pode ser adicionado ao inventário
    public bool CanAddMaterial(CollectibleMaterial.MaterialType materialType, int value)
    {
        switch (materialType)
        {
            case CollectibleMaterial.MaterialType.Plastic:
                return plasticQnt + value <= maxPlastic;
            case CollectibleMaterial.MaterialType.Metal:
                return metalQnt + value <= maxMetal;
            case CollectibleMaterial.MaterialType.Wood:
                return woodQnt + value <= maxWood;
            default:
                return false;
        }
    }

}