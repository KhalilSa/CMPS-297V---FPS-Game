using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    enum State { Patrol, Attack, Chase, Idle }
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Enemy enemy;
    private Rigidbody enemyRB;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private LayerMask groundMask;

    Vector3 walkPoint;
    bool walkPointFound;
    [SerializeField]
    float walkPointRange;

    float patrolTime;
    float idleTime; 

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = enemy.movementSpeed;
        enemyRB = gameObject.GetComponent<Rigidbody>();

        resetPatrolTime();
        resetIdleTime();
    }

    // Update is called once per frame
    void Update()
    {
        State state = getCurrentState();
        switch (state) {
            case State.Attack: attack(); break;
            case State.Chase: chase(); break;
            case State.Patrol: patrol(); break;
            case State.Idle: idle(); break;
        }
    }

    private State getCurrentState() {
        if (enemy.isPlayerInSightRange() && enemy.isPlayerInAttackRange())
            return State.Attack;
        if (enemy.isPlayerInSightRange() && !enemy.isPlayerInAttackRange())
            return State.Chase;
        else
        {
            idleTime -= Time.deltaTime;
            if (idleTime <= 0)
            {
                Invoke(nameof(resetIdleTime), patrolTime);
                return State.Patrol;
            }
            else
            {
                return State.Idle;
            }
        }
            
    }

    private void chase() {
        agent.SetDestination(player.transform.position);
    }

    private void attack() {
        enemy.attack();
    }

    private void idle() {
        enemyRB.velocity = Vector3.zero;
    }

    private void patrol() {
        if (walkPointFound)
            agent.SetDestination(player.transform.position);
        else
            findNewWalkingPoint();

        Vector3 path = transform.position - walkPoint;
        bool walkingPointReached = path.magnitude < 1f;
        if (walkingPointReached)
            walkPointFound = false;

    }

    private void findNewWalkingPoint() {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = enemy.transform.position + new Vector3(randomX, 0, randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
            walkPointFound = true;
    }

    private void resetPatrolTime() {
        patrolTime = Random.Range(5, 10);
    }

    private void resetIdleTime() {
        idleTime = Random.Range(2, 6);
    }
}
