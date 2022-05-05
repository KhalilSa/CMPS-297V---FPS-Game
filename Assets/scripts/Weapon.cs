using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private int _weaponDamage = 25;

    public GameObject weapon { get => _weapon; private set => _weapon = value; }
    public int weaponDamage { get => _weaponDamage; set => weaponDamage = value; }

    public int getDamage() {
        return (int) Random.Range(0.92f * weaponDamage, 1.05f * weaponDamage);
    }
}
