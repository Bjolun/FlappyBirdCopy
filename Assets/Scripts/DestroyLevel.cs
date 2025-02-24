using UnityEngine;

public class DestroyLevel : MonoBehaviour
{
    // �delegger prefabs etterhvert som de blir ute av "bildet" slik at vi ikke 
    // har mange un�dvendige objekter i scenen.

    // Vi vil at dette skal utl�ses av at vi treffer en usynlig trigger i levelet v�rt.
    private void OnTriggerEnter(Collider other)
    {
        // Hvis det vi treffer er en prefab, �delegg prefaben
        if (other.CompareTag("Prefab"))
        {
            Destroy(other.gameObject);
        }
    }
        
}
