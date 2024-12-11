using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        // Verifica se já existe um objeto com o mesmo nome na cena
        DontDestroy[] existingObjects = FindObjectsOfType<DontDestroy>();
        foreach (DontDestroy obj in existingObjects)
        {
            if (obj.gameObject.name == this.gameObject.name && obj != this)
            {
                Destroy(this.gameObject); // Destroi a instância atual se já existir outra com o mesmo nome
                return; // Sai do método para evitar a execução adicional
            }
        }

        // Se não houver duplicatas, mantém o objeto
        DontDestroyOnLoad(this.gameObject);
    }
}