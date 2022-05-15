using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public int weapon_index = 0;


    // Start is called before the first frame update
    void Start()
    {
        EquipWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int prev_wep = weapon_index;

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            if(weapon_index >= transform.childCount - 1)
            {
                weapon_index = 0;
            }
            weapon_index++;


        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if (weapon_index <= transform.childCount - 1)
            {
                weapon_index = transform.childCount - 1 ;
            }
            weapon_index--;
        }

        if(prev_wep != weapon_index)
        {
            EquipWeapon();
        }

    }

    void EquipWeapon()
    {
        int x = 0;
        foreach (Transform weapon in transform)
        {
            if(x == weapon_index)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            x++;
        }
    }

    public void IncMagazine()
    {
        
        foreach (Transform weapon in transform)
        {
            if (weapon.gameObject.activeInHierarchy)
            {
                Gun gun = weapon.gameObject.GetComponent<Gun>();
                if(gun != null)
                {
                    gun.incMagazine();
                }
            }
        }
    }

    public void upgradeWeapon()
    {

        foreach (Transform weapon in transform)
        {
            if (weapon.gameObject.activeInHierarchy)
            {
                Gun gun = weapon.gameObject.GetComponent<Gun>();
                if (gun != null)
                {
                    gun.upgradeWeapon();
                }
            }
        }
    }
}
