using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject ScoreUI1, ScoreUI2;
    public bool isPaused;
    string text1, text2;
    static int score1, score2;

    


    // Update is called once per frame
    void Update()
    {

        
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }


        ScoreUI1.GetComponent<Text>().text = $"{score1}";
        ScoreUI2.GetComponent<Text>().text = $"{score2}";
    }

   public static  void Score(GameObject wall)
    {
        if(wall.name == "RightWall")
        {
            score1++;
        }
        else if (wall.name == "LeftWall")
        {
            score2++;
        }
    }

    public void StartGame()
    {
        isPaused = false;
    }

    public void PauseGame()
    {
        isPaused = true;
    }
    public void RestartGame()
    {
        score1 = 0;
        score2 = 0;
    }
}

