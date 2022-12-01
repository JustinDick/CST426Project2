using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


    public float maxHealth = 100;
    public float currentHealth = 100;

    [SerializeField] private Image healthBar;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth < 0)
        {
            Debug.Log("Player has died, restart game");
        }
    }
    
    
    
    
}
