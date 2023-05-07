using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int lives;
    private int score;
    private GameObject player;
    private GameObject spawn;
    private int level;

    // player stats
    private int highscore;
    private string profileName;
    private int numberOfDeaths;
    private int levelsCompleted;

    // achievments
    private bool threeLevelsNoDamage = false;
    private bool tenDeaths = false;
    private bool onTheBoard = false;
    private bool levelScore2500 = false;
    private bool TwentyBarrels = false;

    private int levelScore = 0;
    private int barrelsJumped = 0;
    private int numLevelsNoDamage = 0;




    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void loadProfile(string name, ProfileData profile){
        highscore = profile.highscore;
        profileName = profile.name;
        numberOfDeaths = profile.numberOfDeaths;
        levelsCompleted = profile.levelsCompleted;

        threeLevelsNoDamage = profile.threeLevelsNoDamage;
        tenDeaths = profile.tenDeaths;
        onTheBoard = profile.onTheBoard;
        levelScore2500 = profile.levelScore2500;
        TwentyBarrels = profile.TwentyBarrels;
    }

    public void statsUpdate(){
        GameObject.Find("UIUpdate").GetComponent<StatsUI>().UIUpdate(highscore,levelsCompleted,numberOfDeaths,profileName);
    }
   
    public void NewGame(){
        lives = 3;
        score = 0;
        LoadFirstLevel(1);
    }

    public void ChangeUI(){
        GameObject.Find("UIUpdate").GetComponent<PlayUI>().UIUpdate(score,lives);
    }

    private void LoadLevel(int index){
        level = index;

        Camera camera = Camera.main;

        if (camera != null){
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadFirstLevel(int index){
        level = index;
        LoadScene();
    }

    private void LoadScene(){
        levelScore = 0;
        barrelsJumped = 0;
        if(numLevelsNoDamage >=3){
            threeLevelsNoDamage = true;
        }
        SceneManager.LoadScene(level);
    }

    public void LevelComplete(){

        score += 1000;
        if(lives == 3){
            numLevelsNoDamage++;
        }else{
            numLevelsNoDamage = 0;
        }
        levelsCompleted++;
        Debug.Log("win");
        ChangeUI();
        int nextLevel = level + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings){
            LoadLevel(nextLevel);
        } else{
            LoadLevel(1);
            level = 1;
        }
    }

    public void BarrelPoints(){

        score += 100;
        barrelsJumped++;
        levelScore = score;

        if (barrelsJumped >= 20){
            TwentyBarrels = true;
        }
        if (levelScore >= 2500){
            levelScore2500 = true;
        }

        Debug.Log("barrel points");
        ChangeUI();

    }


    public void LevelFail(){
        
        lives--;
        numberOfDeaths++;

        if (numberOfDeaths >= 10){
            tenDeaths = true;
        }

        Debug.Log("lose");
        ChangeUI();


        if (lives <=0){

            if (score > highscore){
                highscore = score;
            }
            GameObject.Find("GameDataManager").GetComponent<GameDataManager>().writeProfileFile(profileName,highscore,numberOfDeaths,levelsCompleted,threeLevelsNoDamage,tenDeaths,onTheBoard,levelScore2500,TwentyBarrels);
            SceneManager.LoadScene(0);
        }else{
            LoadLevel(level);
        }
    }
}