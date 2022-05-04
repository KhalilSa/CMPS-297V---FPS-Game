using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public static Player Instance;

    [SerializeField]
    private int _health;
    [SerializeField]
    private Weapon _weapon;
    public int health {get => _health; set => _health = value;}
    public Weapon weapon { get => _weapon; private set => _weapon = value; }

    public Player() {
        if (Instance == null)
        {
            health = 100;
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
}
