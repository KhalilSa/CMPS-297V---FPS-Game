using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private int weaponDamage = 25;

    public GameObject weapon { get => _weapon; private set => _weapon = value; }

    public int getDamage() {
        return (int) Random.Range(0.92f * weaponDamage, 1.05f * weaponDamage);
    }
}
