using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crop
{
    public class CropFlyweight : MonoBehaviour
    {
        // holds the list of crops
        private List<Crop> flyweightCrops = new List<Crop>();
        public Transform[] spawnLocations = new Transform[24];
        public GameObject[] cropPrefabs = new GameObject[6];
        // Start is called before the first frame update
        void Start()
        {
            // create the crops
            for (int i = 0; i < spawnLocations.Length; i++)
            {
                //Crop newCrop = new Crop(i/5, cropPrefabs[i/5]);

                // spawn pumpkin
                if (i > 22)
                {
                    Crop newCrop = new Crop(3, cropPrefabs[5]);
                    flyweightCrops.Add(newCrop);
                }
                
                // spawn corn
                else if (i > 19)
                {
                    Crop newCrop = new Crop(1, cropPrefabs[4]);
                    flyweightCrops.Add(newCrop);
                }
                
                // spawn eggplant
                else if (i > 15)
                {
                    Crop newCrop = new Crop(2, cropPrefabs[3]);
                    flyweightCrops.Add(newCrop);
                }
                
                // spawn tomato
                else if (i > 11)
                {
                    Crop newCrop = new Crop(4, cropPrefabs[2]);
                    flyweightCrops.Add(newCrop);
                }
                
                // spawn turnip
                else if (i > 5)
                {
                    Crop newCrop = new Crop(5, cropPrefabs[1]);
                    flyweightCrops.Add(newCrop);
                }
                
                // spawn carrot
                else
                {
                    Crop newCrop = new Crop(0, cropPrefabs[0]);
                    flyweightCrops.Add(newCrop);
                }
                
                //flyweightCrops.Add(newCrop);
                
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

