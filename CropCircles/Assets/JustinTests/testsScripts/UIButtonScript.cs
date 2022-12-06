using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButtonScript : MonoBehaviour
{
    public Image CowButton;
    public Image SheepButton;
    public Image ChickenButton;
    public Image PigButton;
    public Image DuckButton;
    

    private int score;

    private bool cowOn;

    private bool sheepOn;

    private bool chickenOn;

    private bool pigOn;

    private bool duckOn;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        cowOn = false;
        sheepOn = false;
        chickenOn = false;
        pigOn = false;
        duckOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        cowOn = PlayerManager.cowReady;

        if (cowOn)
        {
            CowButton.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        else
        {
            CowButton.GetComponent<Image>().color = new Color32(169,169,169,255);
        }
        
        sheepOn = PlayerManager.sheepReady;
        
        if (sheepOn)
        {
            SheepButton.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        else
        {
            SheepButton.GetComponent<Image>().color = new Color32(169,169,169,255);
        }
        
        chickenOn = PlayerManager.chickenReady;
        
        if (chickenOn)
        {
            ChickenButton.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        else
        {
            ChickenButton.GetComponent<Image>().color = new Color32(169,169,169,255);
        }
        
        pigOn = PlayerManager.pigReady;
        
        if (pigOn)
        {
            PigButton.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        else
        {
            PigButton.GetComponent<Image>().color = new Color32(169,169,169,255);
        }
        
        duckOn = PlayerManager.duckReady;
        
        if (duckOn)
        {
            DuckButton.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        else
        {
            DuckButton.GetComponent<Image>().color = new Color32(169,169,169,255);
        }
    }
}
