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
    private int score;
    
    // model manager
    public GameObject modelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        touchingCrop = false;
        touchingAnimal = false;
        score = 0;
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
            modelManager.GetComponent<ModelChanger>().changeShape(targetAnimal.GetComponent<AnimalMovement>().name);
            Debug.Log("I worked!");
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
            touchingAnimal = true;
            targetAnimal = target;
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
    }
}
