using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

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

    private Rigidbody enemyRigidbody;
    private NavMeshAgent enemyNavMeshAgent;
    //enemy field of view script 
    private FieldOfView enemyFOV;


    public float enemySpeed = 9f;

    [Header("NavMesh variables")]

    public Transform[] waypoints;
    private int currentWaypointIndex;

    
    
    
    private void Awake()
    {
        //grab components
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyFOV = GetComponent<FieldOfView>();
    }
    

    private void Update()
    {
        if (enemyFOV.canSeePlayer)
        {
            iSeeYouText.text = "I SEE YOU !!0__0!!";
        }
        else
        {
            iSeeYouText.text = "";
        }
    }

}
