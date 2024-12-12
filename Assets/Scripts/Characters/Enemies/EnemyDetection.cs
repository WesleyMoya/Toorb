using System.Collections; // Namespace para cole��es gen�ricas e n�o gen�ricas (n�o utilizado diretamente aqui).
using System.Collections.Generic; // Necess�rio para usar List<T>.
using UnityEngine; // Namespace principal para desenvolvimento no Unity, que inclui classes essenciais como MonoBehaviour e Collider2D.

public class EnemyDetection : MonoBehaviour
{
    // String que define a tag dos objetos que o inimigo deve detectar, aqui configurado como "Player".
    public string _tagTargetDetection = "Player";

    // Lista para armazenar os objetos detectados que entram no trigger.
    public List<Collider2D> detectedObjs = new List<Collider2D>();

    // M�todo chamado automaticamente pelo Unity quando outro objeto entra no collider com a propriedade "Is Trigger" ativada.
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que entrou no trigger tem a tag correspondente � configurada (_tagTargetDetection).
        if (collision.gameObject.tag == _tagTargetDetection)
        {
            // Adiciona o collider do objeto detectado � lista de objetos detectados.
            detectedObjs.Add(collision);
        }
    }

    // M�todo chamado automaticamente pelo Unity quando um objeto sai do collider com a propriedade "Is Trigger" ativada.
    void OnTriggerExit2D(Collider2D collision)
    {
        // Verifica se o objeto que saiu do trigger tem a tag correspondente (_tagTargetDetection).
        if (collision.gameObject.tag == _tagTargetDetection)
        {
            // Remove o collider do objeto da lista de objetos detectados.
            detectedObjs.Remove(collision);
        }
    }
}