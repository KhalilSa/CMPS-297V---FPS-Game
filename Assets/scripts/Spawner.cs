using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombie;
    [SerializeField]
    private float minSpawnDelay = 6f;
    [SerializeField]
    private float maxSpawnDelay = 12f;
    [SerializeField]
    private int difficulty = 1;
    void Start()
    {
        StartCoroutine(nameof(spawnZombie));
    }

    private IEnumerator spawnZombie() {
        while (true)
        {
            Instantiate(zombie, transform.position, Quaternion.identity);
            float spawnDelay = Random.Range(minSpawnDelay / difficulty, maxSpawnDelay / difficulty);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
