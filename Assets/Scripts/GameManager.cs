using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startGameScreen;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    public bool gameIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameIsActive = true;

        startGameScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameIsActive = false;
        gameOverScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameWon()
    {
        gameIsActive = false;
        gameWonScreen.gameObject.SetActive(true);
    }
}
