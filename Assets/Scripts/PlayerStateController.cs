using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    IDLE = 0,
    MOVING = 1,
    JUMPING = 2,
    LADDER = 3,
    REWIND = 4,
    HAMMER = 5,
    PAUSE = 6
}


public class PlayerStateController : MonoBehaviour{

    [SerializeField] private PlayerState StartingState;
    public PlayerState currentState;
    private PlayerState heldstate;


    void Start() {
        ChangePlayerState(PlayerState.IDLE);
    }

    void pause(){
        if (Input.GetKeyDown("escape")){
            if (Time.timeScale == 1){
                heldstate = currentState;
                currentState = PlayerState.PAUSE;
                Time.timeScale = 0;
                }else{
                    Time.timeScale = 1;
                    currentState = heldstate;
            }
        }
    }

    void quit(){
        if (Input.GetKeyDown("k")){
                GameObject.Find("GameManager").GetComponent<GameManager>().LoadLevel(0);
        }
    }

    void Update(){

        pause();
        quit();
    }

    public void ChangePlayerState(PlayerState newState) {
        SendMessage("ExitState", newState, SendMessageOptions.DontRequireReceiver);
        currentState = newState;
    }


    void OnTriggerStay2D(Collider2D collisionDetect){
        if (collisionDetect.gameObject.tag == "Ladder" && currentState != PlayerState.JUMPING){
            ChangePlayerState(PlayerState.LADDER);
        }
    }

     void OnTriggerExit2D(Collider2D collisionDetect2){
        if (collisionDetect2.gameObject.tag == "Ladder"){
            ChangePlayerState(PlayerState.MOVING);
        }
    }


    void OnCollisionEnter2D(Collision2D collisionDetect3)
     {
         if (collisionDetect3.gameObject.tag == "Death"){
            enabled = false;
            FindObjectOfType<GameManager>().LevelFail();
         }

          if (collisionDetect3.gameObject.tag == "Win"){
            enabled = false;
            FindObjectOfType<GameManager>().LevelComplete();
         }

         if (collisionDetect3.gameObject.layer > 5 && collisionDetect3.gameObject.layer < 12 || collisionDetect3.gameObject.layer == 16){
            if (currentState != PlayerState.LADDER){
                ChangePlayerState(PlayerState.MOVING);
            }
         }
     }

    void OnCollisionExit2D(Collision2D collisionDetect4){
        if (collisionDetect4.gameObject.layer > 5 && collisionDetect4.gameObject.layer < 12 || collisionDetect4.gameObject.layer == 16){
            if(currentState != PlayerState.LADDER){
                currentState = PlayerState.JUMPING;
            }
        }
    }
}
