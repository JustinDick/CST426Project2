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
                int randomNum = Random.Range(0, 5);
                
                Animal newAnimal = new Animal(randomNum, animalPrefabs[randomNum]);
                flyweightAnimals.Add(newAnimal);

                int randomSpawn = Random.Range(0, 14);
                
                // instantiate the animal from the list
               //GameObject finsihedAnimal = Instantiate(flyweightAnimals[i].animalPrefab, spawnLocations[randomSpawn].position, Quaternion.identity);
                GameObject finsihedAnimal = Instantiate(flyweightAnimals[i].animalPrefab, spawnLocations[i].position, Quaternion.identity);
                
                // set the speed of the animal
                finsihedAnimal.GetComponent<AnimalMovement>().movement = flyweightAnimals[i].movementSpeed;
                
                // set model for the player to copy
                finsihedAnimal.GetComponent<AnimalMovement>().animalPrefab = flyweightAnimals[i].animalPrefab;
                
                // set the name of the animal
                finsihedAnimal.GetComponent<AnimalMovement>().name = flyweightAnimals[i].name;
            }
        }
    }
}


