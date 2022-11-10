using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelChanger : MonoBehaviour
{
	// list of meshes to use
	public Mesh alienMesh;
	public Mesh cowMesh;
	public Mesh chickenMesh;
	public Mesh duckMesh;
	public Mesh pigMesh;
	public Mesh sheepMesh;

	// model that will be changed
	public GameObject currentModel;
	
	// player's current mesh
	MeshFilter playerMesh;

	// set time limit for transformation
	private float transformDuration;
	private float timer;
	private bool hasTransformed;

    // Start is called before the first frame update
    void Start()
    {
        transformDuration = 5.0f;
		timer = 0.0f;
		hasTransformed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTransformed)
		{
			timer += Time.deltaTime;

			if (timer >= transformDuration)
			{
				timer = 0.0f;
				hasTransformed = false;
				playerMesh = currentModel.GetComponent<MeshFilter>();
				playerMesh.sharedMesh = alienMesh;
			}
		}
    }

    public void changeShape(string name)
    {
        // if the player interacts with cow
        if (name == "cow")
        {
			// change the mesh
			playerMesh = currentModel.GetComponent<MeshFilter>();
			playerMesh.sharedMesh = cowMesh;
			hasTransformed = true;
        }
        
		// if the player interacts with chicken
        if (name == "chicken")
        {
			// change the mesh
            playerMesh = currentModel.GetComponent<MeshFilter>();
			playerMesh.sharedMesh = chickenMesh;
			hasTransformed = true;
        }
        
		// if the player interacts with duck
        if (name == "duck")
        {
			// change the mesh
           	playerMesh = currentModel.GetComponent<MeshFilter>();
			playerMesh.sharedMesh = duckMesh;
			hasTransformed = true;
        }
        
		// if the player interacts with pig
        if (name == "pig")
        {
			// change the mesh
            playerMesh = currentModel.GetComponent<MeshFilter>();
			playerMesh.sharedMesh = pigMesh;
			hasTransformed = true;
        }
        
		// if the player interacts with sheep
        if (name == "sheep")
        {
			// change the mesh
            playerMesh = currentModel.GetComponent<MeshFilter>();
			playerMesh.sharedMesh = sheepMesh;
			hasTransformed = true;
        }
    }
}
