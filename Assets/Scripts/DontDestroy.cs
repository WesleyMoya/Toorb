using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        // Verifica se j� existe um objeto com o mesmo nome na cena
        DontDestroy[] existingObjects = FindObjectsOfType<DontDestroy>();
        foreach (DontDestroy obj in existingObjects)
        {
            if (obj.gameObject.name == this.gameObject.name && obj != this)
            {
                Destroy(this.gameObject); // Destroi a inst�ncia atual se j� existir outra com o mesmo nome
                return; // Sai do m�todo para evitar a execu��o adicional
            }
        }

        // Se n�o houver duplicatas, mant�m o objeto
        DontDestroyOnLoad(this.gameObject);
    }
}