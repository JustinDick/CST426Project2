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

    private EnemyState currentEnemyState;

    private Rigidbody enemyRigidbody;
    private NavMeshAgent enemyNavMeshAgent;
    //enemy field of view script 
    private FieldOfView enemyFOV;


    public float enemySpeed = 9f;

    [Header("NavMesh variables")]

    public Transform[] waypoints;
    private int currentWaypointIndex = 1;
    private Transform targetWaypointPosition;
    private bool goingInReverse = false;
    private bool atEndOfWaypoints = false;
    private bool currentlyMoving = true;

    
    
    
    private void Awake()
    {
        //grab components
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyFOV = GetComponent<FieldOfView>();
    }


    private void Start()
    {
        //Set first state to idle
        currentEnemyState = EnemyState.Patrol;

        //setting up waypoint
        if (waypoints.Length > 0 && waypoints[0] != null)
        {
            targetWaypointPosition = waypoints[currentWaypointIndex];

            enemyNavMeshAgent.SetDestination(targetWaypointPosition.position);
        }
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


        if (targetWaypointPosition != null)
        {
            if ((Vector3.Distance(transform.position, targetWaypointPosition.position) <= 2f) && currentlyMoving)
            {
                currentlyMoving = false;
                StartCoroutine(MoveToNextWaypoint());
            }
        }

    }

    

    IEnumerator MoveToNextWaypoint()
    {

        if (!goingInReverse)
        {
            currentWaypointIndex++;
        }
        
        if (currentWaypointIndex < waypoints.Length && !goingInReverse)
        {
            if (currentWaypointIndex == 1)
            {
                yield return new WaitForSeconds(Random.Range(2f, 4f));

                targetWaypointPosition = waypoints[currentWaypointIndex];

            }
        }
        else
        {
            if (!atEndOfWaypoints)
            {
                atEndOfWaypoints = true;
                yield return new WaitForSeconds(Random.Range(2f, 4f));
            }

            currentWaypointIndex--;
            goingInReverse = true;


            if (currentWaypointIndex == 0)
            {
                goingInReverse = false;
                atEndOfWaypoints = false;
            }

            targetWaypointPosition = waypoints[currentWaypointIndex];
        }

        
        enemyNavMeshAgent.SetDestination(targetWaypointPosition.position);
        currentlyMoving = true;
    }

    
    
    
}
