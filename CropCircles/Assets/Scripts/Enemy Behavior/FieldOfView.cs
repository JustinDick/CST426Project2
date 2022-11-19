using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class FieldOfView : MonoBehaviour
{
    public float DetectionRadius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    //two layers, one for our target(player) and one for obstacles in the way.
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;


    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }


    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }


    private void FieldOfViewCheck()
    {
        //look for objects on layer 'targetMask'
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, DetectionRadius, targetMask);
        
        //if we have an object on layer 'targetMask' then we know we have a player in range since player will be the only one on the layer.
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //If within our our 'fov' range
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                //Get distance to target
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                
                //if we don't hit an obstruction object then we can see the player else player is blocked and we can't see.
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
                
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
    
    
}
