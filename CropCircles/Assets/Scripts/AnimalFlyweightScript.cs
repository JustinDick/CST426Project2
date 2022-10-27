using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animal
{
    public class AnimalFlyweightScript : MonoBehaviour
    {
        // holds the list of animals
        private List<Animal> flyweightAnimals = new List<Animal>();
        public Transform[] spawnLocations = new Transform[15];
        public GameObject[] animalPrefabs = new GameObject[5];

        void Start()
        {
            // create the animals
            for (int i = 0; i < 10; i++)
            {
                // make a random number
                int randomNum = Random.Range(0, 4);
                
                Animal newAnimal = new Animal(randomNum, animalPrefabs[randomNum]);
                flyweightAnimals.Add(newAnimal);


                int randomSpawn = Random.Range(0, 14);
                GameObject finsihedAnimal = Instantiate(newAnimal.animalPrefab, spawnLocations[randomSpawn].position, Quaternion.identity);
                

            }
        }
    }
}


