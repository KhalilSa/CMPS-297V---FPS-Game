using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombie;
    [SerializeField]
    private float spawnDelay = 6f;
    void Start()
    {
        StartCoroutine(nameof(spawnZombie));
    }

    private IEnumerator spawnZombie() {
        while (true)
        {
            Instantiate(zombie, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
