using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HopperScript : MonoBehaviour
{
    private int score;
    [SerializeField] private GameObject winScreen;
    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 1 && !isGameOver)
        {
            //display win screen
            winScreen.SetActive(true);
            
            //set game over true
            isGameOver = true;

            StartCoroutine(Win());
        }
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
