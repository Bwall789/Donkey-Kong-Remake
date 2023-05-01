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


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

   
    private void NewGame(){
        lives = 3;
        score = 0;

        LoadLevel(1);
    }

    private void LoadLevel(int index){
        level = index;
        SceneManager.LoadScene(level);
    }

    public void LevelComplete(){

        score += 1000;
        Debug.Log("win");
        int nextLevel= level + 1;

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
    }


    public void LevelFail(){
        
        lives--;
        Debug.Log("lose");

        if (lives <=0){
            //end game
        }else{
            // spawn = GameObject.Find("SpawnPoint");
            // player = GameObject.Find("Mario");
            // player.transform.position = spawn.transform.position;
            // player.GetComponent<playerMovement>().respawn();
            LoadLevel(level);
        }
    }
}
