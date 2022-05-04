using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public static Player Instance;

    private int _health;
    public int health {get => _health; set => _health = value;}

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
