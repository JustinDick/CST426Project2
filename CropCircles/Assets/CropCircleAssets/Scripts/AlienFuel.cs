using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienFuel : MonoBehaviour
{
    public Slider slider;

    public int maxFuel = 100;
    public int currentFuel;

    public AlienFuel fuelBar;

    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        currentFuel = 0;
        //fuelBar.SetMaxFuel(maxFuel);
    }

    public void SetFuel(int fuel)
    {
        slider.value = fuel;
    }

    public void SetMaxFuel(int fuel)
    {
        //slider.maxValue = fuel;
        slider.value = fuel;
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    void FuelUp(int eating)
    {
        currentFuel += eating;

        fuelBar.SetFuel(currentFuel);
    }
    
    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        rb.isKinematic = false;
        coll.isTrigger = false;
    }
}
