using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This line specifically needed for uGUI to work

public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    void Awake()
    {
        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        {                               
            score = PlayerPrefs.GetInt("HighScore");
        }
        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;

        // Update PlayerRefs Highscore if necessary
        if (score  > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
