using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ProfileData{

    public int highscore;
    public string name;
    public int numberOfDeaths;
    public int levelsCompleted;

    public bool threeLevelsNoDamage = false;
    public bool tenDeaths = false;
    public bool onTheBoard = false;
    public bool levelScore2500 = false;
    public bool TwentyBarrels = false;

 
    public ProfileData(int scoreInt, string nameStr, int deaths, int Completed,bool noDamage, bool ten, bool board, bool score2500, bool barrels20){
        highscore = scoreInt;
        name = nameStr;
        deaths = numberOfDeaths;
        Completed = levelsCompleted;
        threeLevelsNoDamage = noDamage;
        tenDeaths = ten;
        onTheBoard = board;
        levelScore2500 = score2500;
        TwentyBarrels = barrels20;

        }
 }
