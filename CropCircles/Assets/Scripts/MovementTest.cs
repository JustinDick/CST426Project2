using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 42.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 4.2f);
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * 4.2f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        
    }
}
