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
        if (collidedObject.tag == "Item")
        {
            print("Sup");   
            if(player != null)
            {
                if (player.armor <= 70)
                {
                    player.equipArmor(20);
                    Destroy(other.gameObject);
                }
            }
        } else if(collidedObject.tag == "Health")
        {
            Player player = this.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.healPlayer(25);
                Destroy(other.gameObject);
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
                    gunManager.IncMagazine();
                    Destroy(other.gameObject);
                }
            }

        }
        else if (collidedObject.tag == "Gun_Loot")
        {
            
            Destroy(other.gameObject);
        }
        else if (collidedObject.tag == "Gun_Loot_2")
        {

            gunManager.upgradeWeapon();
            Destroy(other.gameObject);
        }
    }


}
