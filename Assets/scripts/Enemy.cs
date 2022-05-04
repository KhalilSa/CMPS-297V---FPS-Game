using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    [SerializeField]
    private Weapon _weapon;

    [SerializeField]
    private int _health = 80;
    [SerializeField]
    private float _movementSpeed = 2.5f;

    private bool isAttacking;
    [SerializeField]
    private float timeBetweenAttacks = 2f;

    [SerializeField]
    private float sightRange = 22f, attackRange = 10f;

    [SerializeField]
    LayerMask playerMask;

    private SightSense sightSense;
    private AttackSense attackSense;

    public float movementSpeed { 
        get => _movementSpeed;
        set => _movementSpeed = value; 
    }
    public int health { get => _health; set => _health = value; }

    void Start()
    {
        _health = health;
        sightSense = transform.Find("SightSense")?.GetComponent<SightSense>();
        attackSense = transform.Find("AttackSense")?.GetComponent<AttackSense>();
    }

    public void attack() {
        if (!isAttacking) {
            Invoke(nameof(damageOpponant), timeBetweenAttacks);
        }
    }

    private void damageOpponant() {
        Rigidbody rb = Instantiate(_weapon.weapon, 
            transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        Player.Instance.health -= _weapon.getDamage();
        if (Player.Instance.health <= 0) {
            Debug.Log("Player has died");
        }
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
        Destroy(transform);
        yield return new WaitForSeconds(0.4f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
