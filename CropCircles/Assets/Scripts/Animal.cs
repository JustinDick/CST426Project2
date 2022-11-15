using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animal
{
    public class Animal
    {
        public float movementSpeed;
        public GameObject animalPrefab;
        public string name;
        public Animal(int AnimalNum, GameObject AnimalPrefab)
        {
            this.animalPrefab = AnimalPrefab;
            
            if (AnimalNum == 0)
            {
                setChicken();
            }
            
            if (AnimalNum == 1)
            {
                setSheep();
            }
            
            if (AnimalNum == 2)
            {
                setCow();
            }
            
            if (AnimalNum == 3)
            {
                setDuck();
            }
            
            if (AnimalNum == 4)
            {
                setPig();
            }
        }

        public void setChicken()
        {
            this.movementSpeed = 4;
            //this.animalPrefab = (GameObject)Resources.Load("prefabs/ChickenBrown", typeof(GameObject));
            this.name = "chicken";
        }

        public void setSheep()
        {
            this.movementSpeed = 2;
            //this.animalPrefab = (GameObject)Resources.Load("prefabs/SheepWhite", typeof(GameObject));
            this.name = "sheep";
        }

        public void setCow()
        {
            this.movementSpeed = 1;
            //this.animalPrefab = (GameObject)Resources.Load("prefabs/CowBIW", typeof(GameObject));
            this.name = "cow";
        }

        public void setDuck()
        {
            this.movementSpeed = 3;
            //this.animalPrefab = (GameObject)Resources.Load("prefabs/DuckWhite", typeof(GameObject));
            this.name = "duck";
        }

        public void setPig()
        {
            this.movementSpeed = 2;
            //this.animalPrefab = (GameObject)Resources.Load("prefabs/Pig", typeof(GameObject));
            this.name = "pig";
        }
    }
    
}

