using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 50f;
    public float range = 50f;
    [SerializeField]
    Camera PlayerCam;
    [SerializeField]
    GameObject _gun;

    public GameObject gun { get; }


    public int maxBullets = 30;
    public int currentBullets = -2;
    public float reloadTime = 1f;
    public bool isOutofBullets = false;
    public int magazine = 2;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        if(currentBullets == -2)
            currentBullets = maxBullets;

        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if this component is active or not
        if(!gameObject.activeInHierarchy)
            return;

        if (isOutofBullets)
        {
            return; 
        }

        if(magazine <= 0)
        {
            return ;
        }


        if(currentBullets <= 0)
        {

            StartCoroutine(Reload());
            return;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    public void incMagazine()
    {
        magazine++;
    }



    IEnumerator Reload()
    {
        print("Reloading...");
        audioManager.play("Out of ammo");
        isOutofBullets=true;
        yield return new WaitForSeconds(reloadTime);
        currentBullets = maxBullets;
        isOutofBullets = false;
        magazine--;
    }


    public void upgradeWeapon()
    {
        audioManager.play("Ammo pickup");
        damage += 10;
        range += 30;
    }

    //function shoot that shoots a raycast and saves the info in a variable
    void Shoot()
    {
        print("plying shooting sound");
        audioManager.play("Shooting");
        currentBullets--;
        RaycastHit hit; //hit info
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range)) //raycast
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>(); //get the target script
            if (target != null) //if the target is not null
            {
                target.takeDamage(damage); //call the take damage function
            }
        }
    }

    public float getDamage() {
        return damage;
    }
     
}
