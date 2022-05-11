using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{


    public GameObject LootPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator SpawnTimer(int SpawnTimeDelay)
    {
        yield return new WaitForSeconds(SpawnTimeDelay);
        GameObject loot = Instantiate(LootPrefab);
        loot.transform.SetParent(transform, true);
        loot.transform.localPosition = new Vector3(0,0.55f,0);
    }
}
