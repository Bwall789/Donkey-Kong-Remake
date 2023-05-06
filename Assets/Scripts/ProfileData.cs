using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ProfileData{

    public int highscore;
    public string name;
    public int numberOfDeaths;
    public int levelsCompleted;

 
    public ProfileData(int scoreInt, string nameStr, int deaths, int Completed){
        highscore = scoreInt;
        name = nameStr;
        deaths = numberOfDeaths;
        Completed = levelsCompleted;
        }
 }
