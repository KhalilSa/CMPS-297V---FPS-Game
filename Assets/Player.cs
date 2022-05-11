using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 100;
    public int armor; 
    public int score = 0;
    public Health_Bar health_bar;
    void Start()
    {
        armor = 25;
        health_bar.SetMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void equipArmor(int arm)
    {
        armor += arm;
    }

    public void dealDamage(int damage)
    {
        int actual_damage = damage - armor;
        health -= actual_damage;
        armor--;
        health_bar.SetHealth(health);
        if (health <= 0)
            Debug.Log("Player has died");
    }

    public int getHealth()
    {
        return health; 
    }

    public void healPlayer(int health_num)
    {
        health += health_num;
    }

    public void incrementScore()
    {
        score++;
    }

}
