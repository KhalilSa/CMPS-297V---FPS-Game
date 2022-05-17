using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GunManager gunManager;
    private Player player;

    void Start()
    {
        player = this.gameObject.GetComponent<Player>();
        print("Strated");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        LootSpawner spawner = collidedObject.GetComponentInParent<LootSpawner>();
        if(collidedObject.tag == "Health")
        {
            Player player = this.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.healPlayer(25);
                Destroy(other.gameObject);
                spawnReset(spawner, LootSpawner.HealthSpawnDelay);
            }
        }else if(collidedObject.tag == "Loot")
        {
            Player player = this.gameObject.GetComponent<Player>();
            if (player != null)
            {
                // cap armor at 90%
                if (player.armor <= 80)
                {
                    player.equipArmor(10);
                    Destroy(other.gameObject);
                    spawnReset(spawner, LootSpawner.ArmorSpawnDelay);
                }

                gunManager.IncMagazine();
            }

        }
        else if (collidedObject.tag == "Gun_Loot")
        {
            print("Weapon Updated: Damage increase");
            gunManager.upgradeWeapon();
            Destroy(other.gameObject);
            spawnReset(spawner, LootSpawner.GunSpawnDelay);
        }
        else if (collidedObject.tag == "Gun_Loot_2")
        {
            gunManager.upgradeWeapon();
            Destroy(other.gameObject);
            spawnReset(spawner, LootSpawner.GunSpawnDelay);

        }
    }

    public void spawnReset(LootSpawner spawner, float delay) {
        if (spawner)
        {
            StartCoroutine(spawner.SpawnTimer(delay));
        }
    }


}
