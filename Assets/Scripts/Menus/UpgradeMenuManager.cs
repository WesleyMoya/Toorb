using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Não esqueça de incluir o namespace do TextMeshPro

public class UpgradeMenuManager : MonoBehaviour
{
    public string qntKey; // Armazena a quantidade de chaves de melhoria
    public string UpgradeText; // Texto que será exibido
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private GameObject mensagemErro; // Referência ao GameObject de mensagem de erro
    [SerializeField] private GameObject mensagemLimite; // Referência ao GameObject de mensagem de limite
    [SerializeField] private TextMeshProUGUI upgradeTextMeshPro; // Referência ao componente TextMeshPro

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        UpdateUpgradeText(); // Atualiza o texto no início
    }

    public void UpgradeInventory()
    {
        // Verifica se a variável upgradeKey é diferente de zero
        if (inventoryManager.upgradeKey > 0)
        {
            bool limitReached = false; // Flag para verificar se o limite foi atingido

            // Verifica se os limites máximos dos materiais são menores que 150
            if (inventoryManager.maxPlastic < 150)
            {
                inventoryManager.maxPlastic += 10;
            }
            else
            {
                limitReached = true; // Marca que o limite foi atingido
            }

            if (inventoryManager.maxMetal < 150)
            {
                inventoryManager.maxMetal += 10;
            }
            else
            {
                limitReached = true; // Marca que o limite foi atingido
            }

            if (inventoryManager.maxWood < 150)
            {
                inventoryManager.maxWood += 10;
            }
            else
            {
                limitReached = true; // Marca que o limite foi atingido
            }

            // Se o limite não foi atingido, reduz a quantidade de chaves de melhoria
            if (!limitReached)
            {
                inventoryManager.upgradeKey--;
            }

            // Atualiza o texto após o upgrade
            UpdateUpgradeText();
            inventoryManager.UpdateUI(); // Atualiza a UI do inventário

            // Se o limite foi atingido, atualiza o texto para indicar isso
            if (limitReached)
            {
                StartCoroutine(AtivarMensagemLimite());
            }
        }
        else
        {
            // Ativa a mensagem de erro
            StartCoroutine(AtivarMensagemErro());
        }
    }

    private IEnumerator AtivarMensagemErro()
    {
        // Ativa o GameObject de mensagem de erro
        mensagemErro.SetActive(true);

        // Espera por 5 segundos
        yield return new WaitForSeconds(5f);

        // Desativa o GameObject de mensagem de erro
        mensagemErro.SetActive(false);
    }

    private IEnumerator AtivarMensagemLimite()
    {
        // Ativa o GameObject de mensagem de limite
        mensagemLimite.SetActive(true);

        // Espera por 5 segundos
        yield return new WaitForSeconds(5f);

        // Desativa o GameObject de mensagem de limite
        mensagemLimite.SetActive(false);
    }

    private void UpdateUpgradeText()
    {
        // Verifica se o limite de melhorias foi atingido
        if (inventoryManager.maxPlastic >= 150 && inventoryManager.maxMetal >= 150 && inventoryManager.maxWood >= 150)
        {
            UpgradeText = "Atingiu o limite de melhoria."; // Texto quando o limite é atingido
        }
        else
        {
            qntKey = inventoryManager.upgradeKey.ToString(); // Converte a quantidade de chaves para string
            UpgradeText = "Tens " + qntKey + " chaves de melhoria para usar"; // Monta o texto
        }
        upgradeTextMeshPro.text = UpgradeText; // Atualiza o texto no TextMeshPro
    }
}