using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false, 
        endGame = false, 
        win = false;
    
    void Start()
    {
        if(gameManager == null)
            gameManager = this;

        if (timeToEnd <= 0)
            timeToEnd = 100;

        InvokeRepeating("Stopper", 2, 1);
    }

    void Update()
    {
        PauseCheck();
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} s");

        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
            EndGame();
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    
    void PauseCheck()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
            Debug.Log("You win! Reload?");
        else
            Debug.Log("You lose! Reload?");
    }
}