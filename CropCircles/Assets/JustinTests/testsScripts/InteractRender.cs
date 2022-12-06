using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRender : MonoBehaviour
{
    public Renderer rend;

    public bool isReady;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;

        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        // checks if interact ready is true from playerManager
        isReady = PlayerManager.interactReady;
        
        // if the player is transformed
        if(isReady)
        {
            rend.enabled = true;
        }

        else
        {
            rend.enabled = false;
        }
    }
}
