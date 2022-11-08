using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropGrowthScript : MonoBehaviour
{
	// variables used for size
	public float scale;
	public float maxScale;
	public float growthRate;

	public Rigidbody cropBody;
    // Start is called before the first frame update
    void Start()
    {
        scale = 0.0f;
		maxScale = 1.0f;
		cropBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scale <= maxScale)
		{
			scale += (Time.deltaTime * 0.4f * growthRate);
			
			cropBody.transform.localScale = new Vector3 (scale, scale, scale);
		}

    }
}
