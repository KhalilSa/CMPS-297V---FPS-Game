using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 100f;
    private GameManager gameManager;

    private Player player;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Killed();
            player.incrementScore();
            gameManager.checkScore();
        }
    }

    void Killed()
    {
        Destroy(gameObject);
    }
   
}
