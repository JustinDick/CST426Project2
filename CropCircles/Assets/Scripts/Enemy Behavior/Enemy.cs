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
        Chase,
        Attack,
        Rampage
    }
    
    
    

    //Enemey state
    public EnemyState currentEnemyState;

    private Animator enemyAnimator;
    private Rigidbody enemyRigidbody;
    private NavMeshAgent enemyNavMeshAgent;
    //enemy field of view script 
    private FieldOfView enemyFOV;
    
    
    
    

    [Header("Patrolling State")]
    public float waypointWaitTime = 3f;

    public float patrolSpeed = 2f;
    

    [Header("Chase State")] 
    public float chaseTimeOut = 8f;
    [SerializeField] private float lostPlayerTimeOut = 0f;
    public float chaseSpeed = 6f;


    [Header("Attack state")]
    [SerializeField]private Transform bulletExit;
    [SerializeField] private GameObject sleepingGas;
    private Transform playersLastKnownLocation;
    [SerializeField] private float fireElapsedTime = 0f;
    public float attackDamage = 10f;
    public float attackCooldown = 5f;
    public float attackRange = 0.5f;
    
    
    

    [Header("NavMesh variables")]
    
    public Transform[] waypoints;
    
    

    
    
    
    private void Awake()
    {
        //grab components
        enemyAnimator = GetComponent<Animator>();
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

        //stop agent
        enemyNavMeshAgent.isStopped = true;
        
        //isIdle
        enemyAnimator.SetBool("isIdle", true);
        
        while (currentEnemyState == EnemyState.Idle)
        {
            if (enemyFOV.canSeePlayer)
            {
                //If can see player start chasing.
                enemyAnimator.SetBool("isIdle", false);
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

        //make sure nav mesh is not stopped.
        enemyNavMeshAgent.isStopped = false;
        
        //Change animation
        enemyAnimator.SetBool("isPatrolling", true);
        
        enemyNavMeshAgent.speed = patrolSpeed;

        
        //choose a random waypoint
        Transform randomWaypoint = waypoints[Random.Range(0, waypoints.Length)];

        //have farmer bill go to it.
        enemyNavMeshAgent.SetDestination(randomWaypoint.position);

        //Debug.Log("I'm going to " + randomWaypoint.position);

        
        //While in patrol state
        while (currentEnemyState == EnemyState.Patrol)
        {
            
            
            //transition out of patrol state, into chase state
            if (enemyFOV.canSeePlayer)
            {
                Debug.Log("I see the player! I will begin chasing!");
                enemyAnimator.SetBool("isPatrolling", false);
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


    
    
    
    
    
    //ENEMY CHASE STATE
    public IEnumerator EnemyState_Chase()
    {
        currentEnemyState = EnemyState.Chase;
        

        enemyAnimator.SetBool("isChasing", true);
        
        Transform playerTransform = enemyFOV.playerRef.transform;

        //make sure nav mesh is not stopped.
        enemyNavMeshAgent.isStopped = true;
        
        //Change enemy speed to chase speed.
        enemyNavMeshAgent.speed = chaseSpeed;
        

        while (currentEnemyState == EnemyState.Chase)
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

                    if (enemyFOV.canSeePlayer)
                    {
                        //reset lost player
                        lostPlayerTimeOut = 0;
                        //shoot at player if can see them
                        enemyAnimator.SetBool("isChasing", false);
                        StartCoroutine(EnemyState_Attack());
                        yield break;
                    }

                    yield return null;


                    //If we don't have sight on the player for 'chaseTimeout' amount of time we go back to patrolling.
                    if (lostPlayerTimeOut >= chaseTimeOut)
                    {
                        

                        if (!enemyFOV.canSeePlayer)
                        {
                            lostPlayerTimeOut = 0f;
                            
                            //disable nav mesh to prevent enemy from moving during animation
                            enemyNavMeshAgent.isStopped = true;
                            //play roar animation
                            enemyAnimator.SetTrigger("Roar");
                            yield return new WaitForSeconds(5.5f);
                            //reactivate nav mesh so enemy can continue to move
                            enemyNavMeshAgent.isStopped = false;
                            
                            
                            enemyAnimator.SetBool("isChasing", false);
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
            if (Vector3.Distance(playerTransform.position, transform.position) <= attackRange  || enemyFOV.canSeePlayer) 
            {
                enemyAnimator.SetBool("isChasing", false);
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
        //transform.LookAt(playerTransform);

        //stop to attack
        enemyNavMeshAgent.isStopped = true;
        
        
        //Ready to fire
        if (fireElapsedTime >= attackCooldown)
        {
            enemyAnimator.SetBool("isAttacking", true);
        }
        else
        {
            //if able to fire going into firing animation, else go into reloading animation
            enemyAnimator.SetBool("isAttacking", false);
            enemyAnimator.SetBool("isReloading", true);
        }
        
        
        while (currentEnemyState == EnemyState.Attack)
        {

            transform.LookAt(playerTransform);

            //if enemy is reloading increment time until next fire
            if (enemyAnimator.GetBool("isReloading"))
            {
                fireElapsedTime += Time.deltaTime;
            }
            

            if (enemyFOV.canSeePlayer)
            {
                playersLastKnownLocation = playerTransform;
            }
            
            //player can't be seen or player has left attack range
            if (!enemyFOV.canSeePlayer || Vector3.Distance(playerTransform.position, transform.position) > attackRange)
            {
                enemyAnimator.SetBool("isReloading", false);
                enemyAnimator.SetBool("isAttacking", false);
                StartCoroutine(EnemyState_Chase());
                yield break;
            }

            //enemy's attack cooldown
            if (fireElapsedTime >= attackCooldown)
            {
                enemyAnimator.SetBool("isReloading", false);
                enemyAnimator.SetBool("isAttacking", true);
                
                
                //enemy attacks
                Debug.Log("Farmer bill has just attacked!");
            }
          
            
            
            yield return null;
        }
    }


    public void ShotGunAttack()
    {
        //spawn sleeping gas on player
        Instantiate(sleepingGas, playersLastKnownLocation.position, sleepingGas.transform.rotation);
        //timer reset
        fireElapsedTime = 0f;
        enemyAnimator.SetBool("isAttacking", false);
        enemyAnimator.SetBool("isReloading", true);
        
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
