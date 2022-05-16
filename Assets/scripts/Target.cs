using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 100f;

    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Killed();
            GameObject.Find("Player").GetComponent<Player>().incrementScore();
        }
    }

    void Killed()
    {
        Destroy(gameObject);
    }
   
}
