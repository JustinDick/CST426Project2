using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
	Rigidbody animalBody;

	public GameObject animalPrefab;

	// values for movement:
    public float movement;
	
	// values for waiting:
	public float waitTimer;
		// max time to wait
	public int waitMax;

	// rotation values:
		// how much the animal will rotate total
	public float rotationAmount;
		// how much they rotate
	float rotationIncrement;
		// keeps track of current rotation
	float rotationTotal;
		// how long to rotate
	float rotationTimer;


	public bool isWaiting;

	public string name;

    // Start is called before the first frame update
    void Start()
    {
        animalBody = GetComponent<Rigidbody>();

		// wait values
		waitTimer = 0.0f;
		waitMax = Random.Range(2, 5);

		// rotating values
		rotationIncrement = 0.2f;
		rotationTotal = 0.0f;
		isWaiting = false;
    }

    // Update is called once per frame
    void Update()
    {
		// movement code
		if (!isWaiting){

			// move forward
			animalBody.velocity = transform.forward * movement;
			// increase wait timer
			waitTimer += Time.deltaTime;

			// hit the time limit
			if (waitTimer >= waitMax){
				isWaiting = true;
				// get new random rotation amount
				rotationAmount = Random.Range(-120.0f, 120.0f);
				// get a new rotation timer
				rotationTimer = Random.Range(0.5f, 4.0f);
				waitTimer = 0.0f;
				rotationTotal = 0.0f;
				
				// sets left or right based on rotation amount
				if (rotationAmount < 0){

					rotationIncrement = -0.05f;
				}

				else{

					rotationIncrement = 0.05f;
				}
			}
		}

		// rotation code
		if (isWaiting){

			// increase rotationcounter
			rotationTotal += Time.deltaTime;
			
			// rotate the animal left or right
			transform.Rotate(Vector3.up * rotationIncrement);

			// if the counter exceeds the time require
			if (rotationTotal >= rotationTimer){

				// get out of is waiting and set new max wait
				isWaiting = false;
				rotationTotal = 0.0f;
				waitMax = Random.Range(2, 5);
			}
		}
    }

	// if the animal collides with an boject
	void OnCollisionEnter(Collision collision)
    {
        isWaiting = true;
		rotationAmount = Random.Range(-120.0f, 120.0f);

		// have a higher floor on the threshold to avoid the object
		rotationTimer = Random.Range(1.7f, 3.0f);
		waitTimer = 0.0f;
		rotationTotal = 0.0f;
				

		if (rotationAmount < 0){

			rotationIncrement = -0.05f;
		}

		else{

			rotationIncrement = 0.05f;
		}
    }

	// sets speed, called by flyweight
    public void setSpeed(int speed)
    {
        movement = speed;
    }
}
