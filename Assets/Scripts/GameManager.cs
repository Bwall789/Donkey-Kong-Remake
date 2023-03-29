using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int lives;
    private int score;
    private GameObject player;
    private GameObject spawn;


    void Start()
    {
        NewGame();
    }

   
    private void NewGame(){
        lives = 3;
        score = 0;

        // Load level 1
    }

    public void LevelComplete(){

        score += 1000;
        Debug.Log("win");
        //Load next level or end if won
    }


    public void LevelFail(){
        
        lives--;
        Debug.Log("lose");

        if (lives <=0){
            //end game
        }else{
            spawn = GameObject.Find("SpawnPoint");
            player = GameObject.Find("Mario");
            player.transform.position = spawn.transform.position;
            player.GetComponent<playerMovement>().respawn();
        }
    }
}
