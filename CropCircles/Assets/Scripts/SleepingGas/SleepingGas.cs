using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingGas : MonoBehaviour
{

    private float elapsedTime;
    public float timeUntilDestroy = 10f;


    private void Update()
    {
        elapsedTime += Time.deltaTime;
        
        //Destroy game object after amount of time.
        if (elapsedTime > timeUntilDestroy)
        {
            //destroy sleeping gas
            Destroy(this.gameObject);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        //do damage over time
        if (other.gameObject.CompareTag("Player"))
        {
            //player take damage
            Debug.Log("Player is taking damage");
        }
    }
    
    
}
