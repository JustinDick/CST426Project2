using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepRender : MonoBehaviour
{
    public Renderer rend;

    public bool isTransformed;
    // Start is called before the first frame update
    void Start()
    {
        // get renderer from animal
        rend = GetComponent<Renderer>();
        rend.enabled = false;

        isTransformed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // checks is transformed from renderchanger
        isTransformed = RenderChanger.sheepTransformation;
        
        // if the player is transformed
        if(isTransformed)
        {
            rend.enabled = true;
        }

        else
        {
            rend.enabled = false;
        }
    }
}
