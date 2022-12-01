using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingGas : MonoBehaviour
{

    private float elapsedTime;
    public float timeUntilDestroy = 10f;
    public float gasDamage = 5f;
    public float gasInterval = 0.5f;
    private bool isInGas;



    public GameObject playerRef;

    private void Start()
    {
        isInGas = false;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(InGasCheck());
    }


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


    private IEnumerator InGasCheck()
    {
        while (true)
        {
            yield return new WaitForSeconds(gasInterval);
            if (isInGas)
            {
                playerRef.GetComponent<PlayerHealth>().currentHealth -= gasDamage;  
            }
            
        }
    }


   
    


    private void OnTriggerEnter(Collider other)
    {
        //while in gas do damage
        if (other.gameObject.CompareTag("Player"))
        {
            isInGas = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //step out of gas
        if (other.gameObject.CompareTag("Player"))
        {
            isInGas = false;
        }
    }
}
