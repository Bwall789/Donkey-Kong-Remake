using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;

    public void UIUpdate(int score, int lives)
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }
}
