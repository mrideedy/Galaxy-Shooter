using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Sprite [] lives;
    public Image livesImageDispay;
    public Text scoreText;
    public int score;
    public void updateLives(int currentLives)
    {
        Debug.Log("Playe Lives:" + currentLives);
        livesImageDispay.sprite = lives[currentLives];
    }

    public void updateScores()
    {
        score+= 10;
        scoreText.text = "Score: " + score;

    }
}
