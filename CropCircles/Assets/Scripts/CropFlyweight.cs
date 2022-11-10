using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crop
{
    public class CropFlyweight : MonoBehaviour
    {
        // holds the list of crops
        private List<Crop> flyweightCrops = new List<Crop>();
        public Transform[] spawnLocations = new Transform[42];
        public GameObject[] cropPrefabs = new GameObject[6];
        // Start is called before the first frame update
        void Start()
        {
            // create the crops
            for (int i = 0; i < spawnLocations.Length; i++)
            {
                Crop newCrop = new Crop(i/7, cropPrefabs[i/7]);
                flyweightCrops.Add(newCrop);
                
                GameObject finishedCrop = Instantiate(flyweightCrops[i].cropPrefab, spawnLocations[i].position, Quaternion.identity);

				finishedCrop.GetComponent<CropGrowthScript>().growthRate = flyweightCrops[i].regrowthRate;
				finishedCrop.GetComponent<CropGrowthScript>().name = flyweightCrops[i].name;
				finishedCrop.GetComponent<CropGrowthScript>().value = flyweightCrops[i].value;
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

