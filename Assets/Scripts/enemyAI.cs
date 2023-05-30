using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public Transform toes;

    public LayerMask whatIsGround, whatIsPlayer;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool canSeePlayer;

    //Sight
    RaycastHit hit;
    float maxRange = 20;

    private void Awake()
    {
        playerInAttackRange = GameObject.Find("bean_Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (Vector3.Distance(transform.position, player.position) < maxRange)
        {
            if (Physics.Raycast(transform.position, (player.position - transform.position), out hit, maxRange))
            {
                if (hit.transform == player)
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
        }

        if (playerInSightRange && !playerInAttackRange && canSeePlayer) ChasePlayer();
        else if (playerInAttackRange && playerInSightRange && canSeePlayer) AttackPlayer();
        else Invoke(nameof(Patroling), 5);
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(toes);
    }
    private void AttackPlayer()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
    }

    //Visualize Attack + Sight Range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

