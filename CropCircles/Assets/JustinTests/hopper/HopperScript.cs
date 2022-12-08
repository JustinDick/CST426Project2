using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HopperScript : MonoBehaviour
{
    private int score;
    [SerializeField] private GameObject winScreen;
    private bool isGameOver;
    public Slider progressSlider;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isGameOver = false;
        progressSlider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 600 && !isGameOver)
        {
            //display win screen
            winScreen.SetActive(true);
            
            //set game over true
            isGameOver = true;

            StartCoroutine(Win());
        }

        progressSlider.value = (score / 600f);
    }

    public void AddScore(int points)
    {
        score += points;
    }
    
    //Reloads the game scene for game over
    IEnumerator Win()
    {
        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
