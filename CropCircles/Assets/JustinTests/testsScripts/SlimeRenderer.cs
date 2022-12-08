using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeRenderer : MonoBehaviour
{
    public Renderer rend;

    public bool isTransformed;
    
    // Start is called before the first frame update
    void Start()
    {
        // get renderer from player
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        isTransformed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // checks is transformed from renderchanger
        isTransformed = RenderChanger.hasTransformed;
        
        // if the player is transformed
        if(isTransformed)
        {
            rend.enabled = false;
        }

        else
        {
            rend.enabled = true;
        }
    }
}
