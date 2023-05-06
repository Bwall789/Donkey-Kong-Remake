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

    private int highscore;
    private string profileName;
    private int numberOfDeaths;
    private int levelsCompleted;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void loadProfile(string name, ProfileData profile){
        highscore = profile.highscore;
        profileName = profile.name;
        numberOfDeaths = profile.numberOfDeaths;
        levelsCompleted = profile.levelsCompleted;
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
        SceneManager.LoadScene(level);
    }

    public void LevelComplete(){

        score += 1000;
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
        Debug.Log("barrel points");
        ChangeUI();

    }


    public void LevelFail(){
        
        lives--;
        Debug.Log("lose");
        ChangeUI();


        if (lives <=0){
            SceneManager.LoadScene(0);
        }else{
            LoadLevel(level);
        }
    }
}
