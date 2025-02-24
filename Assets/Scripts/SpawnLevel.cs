using System.Collections;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    // Den overordnede tanken her er at n�r spilleren treffer en usynlig trigger skal vi
    // instansiere en ny del av levelet. P� denne m�ten lager vi en illusjon av et "uendelig" langt level.
    // Dette scriptet settes p� spilleren.

    // Vi m� holde p� alle prefabs vi vil bruke i levelet v�rt.
    // Vi �nsker � kunne bruke flere prefabs, og lagrer derfor informasjonen v�r i en array
    [SerializeField] private GameObject[] prefabs;

    // Vi m� ha en posisjon vi �nsker at prefabene skal instansieres p�
    [SerializeField] private Transform spawnPosition;

    // For sikkerhets skyld �nsker vi en m�te � kontrollere om vi skal f� lov til � instansiere noe eller ikke.
    private bool canSpawn = true;

    // Vi �nsker at all logikken knyttet til instansiering av objektene skal utl�ses av at spilleren treffer en trigger
    private void OnTriggerEnter(Collider other)
    {
        // Vi �nsker � velge en tilfeldig prefab fra arrayen vi lagde lenger opp slik at vi f�r variasjon i levelet v�rt
        int randomIndex = Random.Range(0, prefabs.Length);

        // Hvis spilleren treffer en trigger med tag "Spawner" og canSpawn er true s� �nsker vi � instansiere en prefab
        if (other.CompareTag("Spawner") && canSpawn) 
        {
            // Vi instansierer en tilfeldig valgt prefab p� posisjonen vi lagrer i spawnPosition. Vi �nsker ingen endring i rotasjon
            Instantiate(prefabs[randomIndex], spawnPosition.position, Quaternion.identity);

            // Sett canSpawn til false og start en timer p� ett sekund f�r vi setter den tilbake til true
            canSpawn = false;
            StartCoroutine(ResetSpawnTimer(1));
        }
    }

    private IEnumerator ResetSpawnTimer(int time)
    {
        // Venter ett sekund f�r vi setter canSpawn tilbake til true.
        yield return new WaitForSeconds(time);
        canSpawn = true;
    }
}
