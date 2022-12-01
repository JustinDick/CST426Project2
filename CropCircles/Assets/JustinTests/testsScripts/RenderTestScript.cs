using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTestScript : MonoBehaviour
{
    public Renderer rend;

    public bool isTransformed;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        isTransformed = false;
    }

    // Update is called once per frame
    void Update()
    {
        isTransformed = ModelChanger.hasTransformed;
        
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
