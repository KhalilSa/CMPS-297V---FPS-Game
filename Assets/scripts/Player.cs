using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 100;
    public int armor = 0; 
    public int score = 0;
    [SerializeField] int initialArmor = 10;
    public Health_Bar health_bar;

    private AudioManager audioManager;
    private GameManager gameManager;
    private ScoreManager scoreManager;

    private Armor armorManager;
    void Awake()
    {
        health_bar.SetMaxHealth(100);
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        armorManager = FindObjectOfType<Armor>();
    }

    private void Start()
    {
        equipArmor(initialArmor);
    }


    public void equipArmor(int arm)
    {
        audioManager.play("Bonus");
        armor += arm;
        armorManager.updateArmor(armor);
    }

    public void takeDamage(int damage)
    {
        int actual_damage = damage * ( 1 - armor / 100);
        health -= actual_damage;
        if (armor > 0)
            armor--;
        health_bar.SetHealth(health);
        armorManager.updateArmor(armor);
        if (health <= 0)
        {
            gameManager.endGame();
        }
    }

    public int getHealth()
    {
        return health; 
    }

    public void healPlayer(int health_num)
    {
        audioManager.play("Bonus");
        health += health_num;
        health_bar.SetHealth(health);
    }

    public void incrementScore()
    {
        score++;
        scoreManager.IncrementScore(score);
    }

}
