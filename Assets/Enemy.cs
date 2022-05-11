using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{

    [SerializeField]
    private int health = 100;
    [SerializeField]
    private GameObject enemyWeapon;
    [SerializeField]
    private float _movementSpeed = 2.5f;

    private bool isAttacking;
    [SerializeField]
    private float timeBetweenAttacks = 2f;

    [SerializeField]
    private float sightRange = 22f, attackRange = 10f;

    private Player player;
    private SightSense sightSense;
    private AttackSense attackSense;
    private Target target;
    private Gun playerWeapon;

    public float movementSpeed
    {
        get => _movementSpeed;
        set => _movementSpeed = value;
    }

    void Start()
    {
        sightSense = transform.Find("SightSense")?.GetComponent<SightSense>();
        attackSense = transform.Find("AttackSense")?.GetComponent<AttackSense>();
        target = gameObject.GetComponent<Target>();
        playerWeapon = gameObject.GetComponent<Gun>();
        player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
    }

    public void attack() {
        if (!isAttacking) {
            isAttacking = true;
            StartCoroutine(nameof(damageOpponant));
        }
    }

    private IEnumerator damageOpponant() {
        Rigidbody rb = Instantiate(enemyWeapon,
            transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

        player.dealDamage(10);
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    public bool isPlayerInSightRange()
    {
        return sightSense.Seeable;
    }   

    public bool isPlayerInAttackRange()
    {
        return attackSense.Attackable;
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) 
            StartCoroutine(die());
    }

    public IEnumerator die() {
        Destroy(transform.gameObject);
        yield return new WaitForSeconds(0.4f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            takeDamage(playerWeapon.getDamage());
    }

    public void takeDamage(float damage)
    {
        health -= (int) damage;
        if (health <= 0)
        {
            Killed();
            player.incrementScore();
        }
    }

    void Killed()
    {
        Destroy(gameObject);
    }
}
