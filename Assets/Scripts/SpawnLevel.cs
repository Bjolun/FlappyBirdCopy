using System.Collections;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    // Den overordnede tanken her er at når spilleren treffer en usynlig trigger skal vi
    // instansiere en ny del av levelet. På denne måten lager vi en illusjon av et "uendelig" langt level.
    // Dette scriptet settes på spilleren.

    // Vi må holde på alle prefabs vi vil bruke i levelet vårt.
    // Vi ønsker å kunne bruke flere prefabs, og lagrer derfor informasjonen vår i en array
    [SerializeField] private GameObject[] prefabs;

    // Vi må ha en posisjon vi ønsker at prefabene skal instansieres på
    [SerializeField] private Transform spawnPosition;

    // For sikkerhets skyld ønsker vi en måte å kontrollere om vi skal få lov til å instansiere noe eller ikke.
    private bool canSpawn = true;

    // Vi ønsker at all logikken knyttet til instansiering av objektene skal utløses av at spilleren treffer en trigger
    private void OnTriggerEnter(Collider other)
    {
        // Vi ønsker å velge en tilfeldig prefab fra arrayen vi lagde lenger opp slik at vi får variasjon i levelet vårt
        int randomIndex = Random.Range(0, prefabs.Length);

        // Hvis spilleren treffer en trigger med tag "Spawner" og canSpawn er true så ønsker vi å instansiere en prefab
        if (other.CompareTag("Spawner") && canSpawn) 
        {
            // Vi instansierer en tilfeldig valgt prefab på posisjonen vi lagrer i spawnPosition. Vi ønsker ingen endring i rotasjon
            Instantiate(prefabs[randomIndex], spawnPosition.position, Quaternion.identity);

            // Sett canSpawn til false og start en timer på ett sekund før vi setter den tilbake til true
            canSpawn = false;
            StartCoroutine(ResetSpawnTimer(1));
        }
    }

    private IEnumerator ResetSpawnTimer(int time)
    {
        // Venter ett sekund før vi setter canSpawn tilbake til true.
        yield return new WaitForSeconds(time);
        canSpawn = true;
    }
}
