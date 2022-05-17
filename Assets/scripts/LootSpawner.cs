using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public GameObject LootPrefab;

    public static float ArmorSpawnDelay = 3f;
    public static float GunSpawnDelay = 5f;
    public static float HealthSpawnDelay = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer(1));
    }

    public IEnumerator SpawnTimer(float SpawnTimeDelay)
    {
        yield return new WaitForSeconds(SpawnTimeDelay);
        GameObject loot = Instantiate(LootPrefab);
        loot.transform.SetParent(transform, true);
        loot.transform.localPosition = Vector3.zero;
        if (loot.tag == "Gun_Loot" || loot.tag == "Gun_Loot_2") {
            loot.transform.localScale = 0.15f * Vector3.one;
        }
    }
}
