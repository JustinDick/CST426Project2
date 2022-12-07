using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CropUIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text carrotText;
    [SerializeField] private TMP_Text cornText;
    [SerializeField] private TMP_Text eggplantText;
    [SerializeField] private TMP_Text pumpkinText;
    [SerializeField] private TMP_Text tomatoText;
    [SerializeField] private TMP_Text turnipText;

    private int carrotCount;
    private int cornCount;
    private int eggplantCount;
    private int pumpkinCount;
    private int tomatoCount;
    private int turnipCount;

    void Start()
    {
        carrotCount = 0;
		cornCount = 0;
		eggplantCount = 0;
		pumpkinCount = 0;
		tomatoCount = 0;
		turnipCount = 0;
    }
    

    // Update is called once per frame
    void Update()
    {
	    /*carrotCount = PlayerManager.carrotCount;
	    cornCount = PlayerManager.cornCount;
	    eggplantCount = PlayerManager.eggplantCount;
	    pumpkinCount = PlayerManager.pumpkinCount;
	    tomatoCount = PlayerManager.tomatoCount;
	    turnipCount = PlayerManager.turnipCount;*/

	    //Debug.Log(PlayerManager.carrotCount);

	    carrotText.text = "X " + carrotCount;
        cornText.text = "X " + cornCount;
        eggplantText.text = "X " + eggplantCount;
        pumpkinText.text = "X " + pumpkinCount;
        tomatoText.text = "X " + tomatoCount;
        turnipText.text = "X " + turnipCount;
    }

    public void AddCarrot()
    {
	    carrotCount+=1;
    }

    public void AddCorn()
    {
	    cornCount+=1;
    }

    public void AddEggplant()
    {
	    eggplantCount+=1;
    }

    public void AddPumpkin()
    {
	    pumpkinCount+=1;
    }

    public void AddTomato()
    {
	    tomatoCount+=1;
    }

    public void AddTurnip()
    {
	    turnipCount+=1;
    }

    public void ResetCrops()
    {
	    carrotCount = 0;
	    cornCount = 0;
	    eggplantCount = 0;
	    pumpkinCount = 0;
	    tomatoCount = 0;
	    turnipCount = 0;
    }

    public void AddCrop(string cropName)
    {
	    Debug.Log(cropName);
	    if (cropName == "carrot")
	    {
		    Debug.Log("I Worked!");
		    carrotCount++;
		    Debug.Log(carrotCount);
	    }

	    if (cropName == "corn")
	    {
		    cornCount += 1;
	    }

	    if (cropName == "eggplant")
	    {
		    eggplantCount += 1;
	    }

	    if (cropName == "pumpkin")
	    {
		    pumpkinCount += 1;
	    }

	    if (cropName == "tomato")
	    {
		    tomatoCount += 1;
	    }

	    if (cropName == "turnip")
	    {
		    turnipCount += 1;
	    }
    }
}
