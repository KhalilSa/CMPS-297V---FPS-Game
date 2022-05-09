using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Manager : MonoBehaviour
{



 
    public GameObject grenade;
    public Camera PlayerCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();

        }
        
    }

    //function ThrowGrenade that throws a grenade prefab as a projectile towards mouse direction
    void ThrowGrenade()
    {
        RaycastHit hit; //hit info
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, 200)) //raycast
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>(); //get the target script
            if (target != null) //if the target is not null
            {
                 //call the take damage function

            }
        }
    }
  
}
