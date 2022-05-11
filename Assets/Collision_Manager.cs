using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GunManager gunManager;

    void Start()
    {
        print("Strated");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.tag == "Item")
        {
            print("Sup");
            
            Player player = this.gameObject.GetComponent<Player>();    
            if(player != null)
            {
                player.equipArmor(200);
                Destroy(other.gameObject);
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
                player.equipArmor(25);
                gunManager.IncMagazine();
                Destroy(other.gameObject);
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
