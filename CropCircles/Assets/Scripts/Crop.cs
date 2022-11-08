using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crop
{
    public class Crop
    {
        // properties of the crops
        public float regrowthRate;
        public GameObject cropPrefab;
        public string name;

        public Crop(int CropNum, GameObject CropPrefab)
        {
            this.cropPrefab = CropPrefab;
            
            if (CropNum == 0)
            {
                setCarrot();
            }
            
            if (CropNum == 1)
            {
                setCorn();
            }
            
            if (CropNum == 2)
            {
                setEggplant();
            }
            
            if (CropNum == 3)
            {
                setPumpkin();
            }
            
            if (CropNum == 4)
            {
                setTomato();
            }
            
            if (CropNum == 5)
            {
                setTurnip();
            }
            
        }
        
        public void setCarrot()
        {
            this.regrowthRate = 1.2f;
            this.name = "carrot";
        }
        
        public void setCorn()
        {
            this.regrowthRate = 0.3f;
            this.name = "corn";
        }
        
        public void setEggplant()
        {
            this.regrowthRate = 0.8f;
            this.name = "eggplant";
        }
        
        public void setPumpkin()
        {
            this.regrowthRate = 0.5f;
            this.name = "pumpkin";
        }
        
        public void setTomato()
        {
            this.regrowthRate = 1.0f;
            this.name = "tomato";
        }
        
        public void setTurnip()
        {
            this.regrowthRate = 1.1f;
            this.name = "turnip";
        }
    }
}

