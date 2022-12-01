using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // required for checking for crops
    private bool touchingCrop;
    private Collider targetCrop;

    // require for checking for animals
    private bool touchingAnimal;
    private Collider targetAnimal;
    public int score;
    
    // model manager
    public GameObject modelManager;

	// require for checking for hopper
	private bool touchingHopper;

	// holds on to animal transformations
	public static bool chickenReady;
	public static bool sheepReady;
	public static bool duckReady;
	public static bool pigReady;
	public static bool cowReady;
    
    // Start is called before the first frame update
    void Start()
    {
        touchingCrop = false;
        touchingAnimal = false;
		touchingHopper = true;
        score = 0;

		chickenReady = false;
		sheepReady = false;
		duckReady = false;
		pigReady = false;
		cowReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is able to interact with a crop
        if(Input.GetKeyDown(KeyCode.E) && touchingCrop)
        {
            // displays the name of the crop
            //Debug.Log(targetCrop.GetComponent<CropGrowthScript>().name);

            if (targetCrop.GetComponent<CropGrowthScript>().scale >= 1)
            {
                // resets the size of the crop
                targetCrop.GetComponent<CropGrowthScript>().resetSize();
                
                // add value of crop to score
                score += targetCrop.GetComponent<CropGrowthScript>().value;
            }
        }
        
        // if the player is able to interact with an animal
        if (Input.GetKeyDown(KeyCode.E) && touchingAnimal)
        {
            //modelManager.GetComponent<RenderChanger>().changeShape(targetAnimal.GetComponent<AnimalMovement>().name);
			
			// set the ability to be ready based on animal name
			if (targetAnimal.GetComponent<AnimalMovement>().name == "cow")
			{
				cowReady = true;
			}

			if (targetAnimal.GetComponent<AnimalMovement>().name == "sheep")
			{
				sheepReady = true;
			}

			if (targetAnimal.GetComponent<AnimalMovement>().name == "chicken")
			{
				chickenReady = true;
			}

			if (targetAnimal.GetComponent<AnimalMovement>().name == "duck")
			{
				duckReady = true;
			}

			if (targetAnimal.GetComponent<AnimalMovement>().name == "pig")
			{
				pigReady = true;
			}
        }

		// activate ability for chicken
		if (Input.GetKeyDown(KeyCode.Alpha1) && chickenReady)
		{
			modelManager.GetComponent<RenderChanger>().changeShape("chicken");
			chickenReady = false;
		}

		// activate ability for sheep
		if (Input.GetKeyDown(KeyCode.Alpha2) && sheepReady)
		{
			modelManager.GetComponent<RenderChanger>().changeShape("sheep");
			sheepReady = false;
		}

		// activate ability for cow
		if (Input.GetKeyDown(KeyCode.Alpha3) && cowReady)
		{
			modelManager.GetComponent<RenderChanger>().changeShape("cow");
			cowReady = false;
		}

		// activate ability for duck
		if (Input.GetKeyDown(KeyCode.Alpha4) && duckReady)
		{
			modelManager.GetComponent<RenderChanger>().changeShape("duck");
			duckReady = false;
		}

		// activate ability for pig
		if (Input.GetKeyDown(KeyCode.Alpha5) && pigReady)
		{
			modelManager.GetComponent<RenderChanger>().changeShape("pig");
			pigReady = false;
		}

		// deposit score from crops
		if (Input.GetKeyDown(KeyCode.E) && touchingHopper)
        {
            // change progress bar
			
			// reset score
			score = 0;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(score);
        }
    }
    
    private void OnTriggerEnter(Collider target)
    {
        // check if the collider was a crop
        if(target.gameObject.tag == "Crop")
        {
            touchingCrop = true;
            targetCrop = target;
        }
        
        // check if the collider was an animal
        if(target.gameObject.tag == "Animal")
        {
			Debug.Log("Found Animal");
            touchingAnimal = true;
            targetAnimal = target;
        }

		// check if the collider was the hopper
		if(target.gameObject.tag == "Hopper")
		{
			Debug.Log("Found Hopper");
			touchingHopper = true;
		}
    }
    
    void OnTriggerExit(Collider target)
    {
        // check if the collider was a crop
        if(target.gameObject.tag == "Crop")
        {
            touchingCrop = false;
        }

        if (target.gameObject.tag == "Animal")
        {
            touchingAnimal = false;
        }

		if (target.gameObject.tag == "Hopper")
        {
            touchingHopper = false;
        }
    }
}
