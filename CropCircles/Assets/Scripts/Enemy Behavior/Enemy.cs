using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{


    //to be removed
    [SerializeField] private TextMeshProUGUI iSeeYouText;

    public enum EnemyState
    {
        Idle,
        Patrol,
        Chasing,
        Attack,
        Rampage
    }

    //Enemey state
    public EnemyState currentEnemyState;

    private Rigidbody enemyRigidbody;
    private NavMeshAgent enemyNavMeshAgent;
    //enemy field of view script 
    private FieldOfView enemyFOV;


    public float enemySpeed = 9f;

    

    [Header("Patrolling State")]
    public float waypointWaitTime = 3f;
    

    [Header("Chase State")] 
    public float chaseTimeOut = 5f;
    public float lostPlayerTimeOut = 0f;
    

    [Header("Attack state")] 
    public float attackDamage = 10f;
    public float attackCooldown = 5f;
    public float attackRange = 0.5f;
    
    
    

    [Header("NavMesh variables")]
    
    public Transform[] waypoints;
    
    

    
    
    
    private void Awake()
    {
        //grab components
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyFOV = GetComponent<FieldOfView>();
    }
    
    
    private void Start()
    {
        //start game with enemy patrolling
        StartCoroutine(EnemyState_Patrol());
    }
    

    private void Update()
    {
        //To be removed
        if (enemyFOV.canSeePlayer)
        {
            iSeeYouText.text = "I SEE YOU !!0__0!!";
        }
        else
        {
            iSeeYouText.text = "";
        }
        
        
        
        
        
    }


    
    
    //ENEMY IDLE STATE
    public IEnumerator EnemyState_Idle()
    {
        currentEnemyState = EnemyState.Idle;
        

        while (currentEnemyState == EnemyState.Idle)
        {
            if (enemyFOV.canSeePlayer)
            {
                //If can see player start chasing.
                StartCoroutine(EnemyState_Chase());
                yield break;
            }
            
            

            yield return null;
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    //ENEMY PATROL STATE
    public IEnumerator EnemyState_Patrol()
    {
        currentEnemyState = EnemyState.Patrol;

        
        //choose a random waypoint
        Transform randomWaypoint = waypoints[Random.Range(0, waypoints.Length)];

        //have farmer bill go to it.
        enemyNavMeshAgent.SetDestination(randomWaypoint.position);

        Debug.Log("I'm going to " + randomWaypoint.position);

        
        //While in patrol state
        while (currentEnemyState == EnemyState.Patrol)
        {
            
            
            //transition out of patrol state, into chase state
            if (enemyFOV.canSeePlayer)
            {
                Debug.Log("I see the player! I will begin chasing!");
                StartCoroutine(EnemyState_Chase());
                yield break;
            }

            //continue patrolling after reaching destination
            if (ReachedDestination())
            {
                StartCoroutine(EnemyState_Patrol());
                yield break;
            }
            
            
            //to prevent game crash we need a yield to to need condition.
            yield return null;
        }
    }


    
    
    
    
    
    
    
    
    
    
    
    
    
    
    public IEnumerator EnemyState_Chase()
    {
        currentEnemyState = EnemyState.Chasing;


        Transform playerTransform = enemyFOV.playerRef.transform;

        
        

        while (currentEnemyState == EnemyState.Chasing)
        {
            
            enemyNavMeshAgent.SetDestination(playerTransform.position);
            enemyNavMeshAgent.isStopped = false;

            if (!enemyFOV.canSeePlayer)
            {
                

                while (true)
                {
                    //as along as we can't see the player increment our timer
                    lostPlayerTimeOut += Time.deltaTime;

                    enemyNavMeshAgent.SetDestination(playerTransform.position);

                    yield return null;


                    //If we don't have sight on the player for 'chaseTimeout' amount of time we go back to patrolling.
                    if (lostPlayerTimeOut >= chaseTimeOut)
                    {
                        if (!enemyFOV.canSeePlayer)
                        {
                            lostPlayerTimeOut = 0f;
                            StartCoroutine(EnemyState_Patrol());
                            yield break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }


            }

            //if in range to attack
            if (Vector3.Distance(playerTransform.position, transform.position) <= attackRange  && enemyFOV.canSeePlayer) 
            {
                StartCoroutine(EnemyState_Attack());
                yield break;
            }
            
            
            yield return null;
        }
    }


    
    
    
    
    
    
    
    
    
    //TODO: have enemy attack the player
    public IEnumerator EnemyState_Attack()
    {
        currentEnemyState = EnemyState.Attack;
        
        
        Transform playerTransform = enemyFOV.playerRef.transform;

        enemyNavMeshAgent.isStopped = true;
        
        Debug.Log("I'm in attack mode!");

        float elaspedTime = 0f;
        
        while (currentEnemyState == EnemyState.Attack)
        {
            elaspedTime += Time.deltaTime;
            
            //player can't be seen or player has left attack range
            if (!enemyFOV.canSeePlayer || Vector3.Distance(playerTransform.position, transform.position) > attackRange)
            {
                StartCoroutine(EnemyState_Chase());
                yield break;
            }

            //player's attack cooldown
            if (elaspedTime >= attackCooldown)
            {
                //timer reset
                elaspedTime = 0f;
                
                //enemy attacks
                Debug.Log("Farmer bill has just attacked!");
            }
            
            
            yield return null;
        }
    }

    
    
    
    
    //TODO: go to random location, shoot, search through map, increase speed
    public IEnumerator EnemyState_Rampage()
    {
        currentEnemyState = EnemyState.Rampage;

        while (currentEnemyState == EnemyState.Rampage)
        {
            yield return null;
        }
    }





    public bool ReachedDestination()
    {
        if (!enemyNavMeshAgent.pathPending)
        {
            if (enemyNavMeshAgent.remainingDistance <= enemyNavMeshAgent.stoppingDistance)
            {
                if (!enemyNavMeshAgent.hasPath || enemyNavMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }

   

    
    
    
    
    
    
    

    
    
    
}
