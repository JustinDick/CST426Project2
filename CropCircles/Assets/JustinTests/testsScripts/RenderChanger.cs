using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderChanger : MonoBehaviour
{
    // Start is called before the first frame update
    
    // set time limit for transformation
    private float transformDuration;
    private float timer;
    public static bool hasTransformed;
    
    // booleans for specific animal transformations
    public static bool cowTransformation;
    public static bool chickenTransformation;
    public static bool sheepTransformation;
    public static bool pigTransformation;
    public static bool duckTransformation;
    
    void Start()
    {
        transformDuration = 5.0f;
        timer = 0.0f;
        hasTransformed = false;
        
        cowTransformation = false;
        chickenTransformation = false;
        sheepTransformation = false;
        pigTransformation = false;
        duckTransformation = false;
    }

    // Update is called once per frame
    void Update()
    {
        // checks if transformed
        if (hasTransformed)
        {
            timer += Time.deltaTime;

            // time limit reached on transformation
            if (timer >= transformDuration)
            {
                // reset timer and transformation
                timer = 0.0f;
                hasTransformed = false;
                cowTransformation = false;
                chickenTransformation = false;
                sheepTransformation = false;
                pigTransformation = false;
                duckTransformation = false;
            }
        }
    }
    
    public void changeShape(string name)
    {
        // if the player interacts with cow
        if (name == "cow")
        {
            hasTransformed = true;
            cowTransformation = true;
        }
        
        // if the player interacts with chicken
        if (name == "chicken")
        {
            hasTransformed = true;
            chickenTransformation = true;
        }
        
        // if the player interacts with duck
        if (name == "duck")
        {
            hasTransformed = true;
            duckTransformation = true;
        }
        
        // if the player interacts with pig
        if (name == "pig")
        {
            hasTransformed = true;
            pigTransformation = true;
        }
        
        // if the player interacts with sheep
        if (name == "sheep")
        {
            hasTransformed = true;
            sheepTransformation = true;
        }
    }
}
