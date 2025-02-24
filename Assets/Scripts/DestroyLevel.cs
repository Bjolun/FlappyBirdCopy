using UnityEngine;

public class DestroyLevel : MonoBehaviour
{
    // Ødelegger prefabs etterhvert som de blir ute av "bildet" slik at vi ikke 
    // har mange unødvendige objekter i scenen.

    // Vi vil at dette skal utløses av at vi treffer en usynlig trigger i levelet vårt.
    private void OnTriggerEnter(Collider other)
    {
        // Hvis det vi treffer er en prefab, ødelegg prefaben
        if (other.CompareTag("Prefab"))
        {
            Destroy(other.gameObject);
        }
    }
        
}
