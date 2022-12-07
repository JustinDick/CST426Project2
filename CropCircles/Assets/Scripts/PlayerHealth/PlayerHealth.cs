using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


    public float maxHealth = 100;
    public float currentHealth = 100;

    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject gameOverScreen;
    private bool isGameOver;



    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        currentHealth = maxHealth;
        if (healthBar == null)
        {
            healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth < 0 && !isGameOver)
        {
            //display game over screen
            gameOverScreen.SetActive(true);
            
            //set game over true
            isGameOver = true;

            StartCoroutine(GameOver());
            
            Debug.Log("Player has died, restart game");
        }
    }


    //Reloads the game scene for game over
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
    
    
    
    
}
