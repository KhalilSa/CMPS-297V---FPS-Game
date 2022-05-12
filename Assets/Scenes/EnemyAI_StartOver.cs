using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI_StartOver : MonoBehaviour
{
    enum State { Patrol, Attack, Chase, Idle, Dead }

    private NavMeshAgent agent;
    private Transform player;
    private Rigidbody rb;

    [SerializeField]
    private float turningSpeed = 100f;

    [SerializeField]
    private float sightRange = 18f;
    private SightSense sightSense;

    [SerializeField]
    private float attackRange = 8f;
    private AttackSense attackSense;
    private bool isAttacking = false;

    [SerializeField] 
    private float timeBetweenAttacks = 1.5f;
    [SerializeField]
    private float idleTime = 3f;
    [SerializeField]
    private float patrolTime = 7f;
    private bool isIdle = false;

    [SerializeField]
    LayerMask groundMask;

    [SerializeField]
    float walkPointRange = 3f;
    Vector3 walkPoint;
    bool walkPointFound;

    [SerializeField]
    private GameObject bullet;

    private Animator animator;
    [SerializeField]
    private State currentState;

    void Start()
    {
        getReferences();
        resetSenseSettings();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = getCurrentState();
        switch (currentState) {
            case State.Chase:
                chase();
                break;
            case State.Attack:
                attack();
                break;
            case State.Patrol:
                patrol();
                break;
            case State.Idle:
                idle();
                break;
            case State.Dead:
                dead();
                break;
        }
    }

    private State getCurrentState()
    {
        if (isPlayerInSightRange() && isPlayerInAttackRange())
            return State.Attack;
        else if (isPlayerInSightRange() && !isPlayerInAttackRange())
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

    private void patrol()
    {
        if (walkPointFound)
            agent.SetDestination(player.position + getNewRandomVector());
        else
            findNewWalkingPoint();

        setActiveAnimationState("isPatroling");
        isIdle = false;

        bool walkingPointReached = Vector3.Distance(transform.position, walkPoint) <= 2f;
        print(walkPointFound);
        if (walkingPointReached)
            walkPointFound = false;

    }

    private void findNewWalkingPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = transform.position + new Vector3(randomX, 0, randomZ);

        print(walkPoint);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
            walkPointFound = true;
    }

    void getReferences() {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sightSense = transform.Find("SightSense")?.GetComponent<SightSense>();
        attackSense = transform.Find("AttackSense")?.GetComponent<AttackSense>();
        animator = transform.Find("Zombie")?.GetComponent<Animator>();
    }

    void resetSenseSettings() {
        SphereCollider SSSC = transform.Find("SightSense")
            ?.GetComponent<SphereCollider>();
        SphereCollider ASSC = transform.Find("AttackSense")
            ?.GetComponent<SphereCollider>();
        SSSC.radius = sightRange;
        ASSC.radius = attackRange;
    }

    void chase() {
        agent.SetDestination(player.position);
        setActiveAnimationState("isChasing");
        facePlayer();
    }

    void attack() {
        if (!isAttacking)
        {
            isAttacking = true;
            setActiveAnimationState("isAttacking");
            StartCoroutine(nameof(damageOpponant));
        }
    }

    private IEnumerator damageOpponant()
    {
        transform.LookAt(player.position);
        rb.velocity = Vector3.zero;
        Rigidbody bulletRb = Instantiate(bullet,
            transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        Vector3 direction = player.position - transform.position;
        bulletRb.AddForce(direction * 32f, ForceMode.Impulse);
        
        // TO-DO: damage player code
        
        yield return new WaitForSeconds(timeBetweenAttacks);
        Destroy(bulletRb.gameObject);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void setActiveAnimationState(string state) {
        foreach (AnimatorControllerParameter p in animator.parameters) {
            if (p.name == state)
                animator.SetBool(p.name, true);
            else
                animator.SetBool(p.name, false);
        }
    }

    private void idle() {
        rb.velocity = Vector3.zero;
        agent.SetDestination(transform.position);
        setActiveAnimationState("isIdle");
    }

    private void resetIdleTime()
    {
        if (!isIdle)
        {
            isIdle = true;
            idleTime = Random.Range(2, 5);
        }
    }

    private void facePlayer() {
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * turningSpeed);
    }

    Vector3 getNewRandomVector() {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        return new Vector3(randomX, 0, randomZ);
    }

    void switchCurrentState(State state) {
        currentState = state;
    }

    void dead() {
        setActiveAnimationState("isDead");
    }
}
