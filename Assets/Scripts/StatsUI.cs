using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StatsUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text deathText;
    public TMP_Text levelsText;
    public TMP_Text nameText;

    public void UIUpdate(int score, int levels, int death, string name)
    {
        scoreText.text = score.ToString();
        levelsText.text = levels.ToString();
        deathText.text = death.ToString();
        nameText.text = name;
    }
}
