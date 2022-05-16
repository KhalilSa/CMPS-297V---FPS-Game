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

    private AudioManager audioManager;
    void Start()
    {
        armor = 25;
        health_bar.SetMaxHealth(100);
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void equipArmor(int arm)
    {
        audioManager.play("Bonus");
        armor += arm;
    }

    public void takeDamage(int damage)
    {
        int actual_damage = damage * ( 1 - armor / 100);
        health -= actual_damage;
        if (armor > 0)
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
        audioManager.play("Bonus");
        health += health_num;
    }

    public void incrementScore()
    {
        score++;
    }

}
