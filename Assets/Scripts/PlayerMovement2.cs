using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    
    private float speed;
    public float MoveSpeed;
    public float JumpSpeed;
    public float climbSpeed;
    public bool climbing;
    public float JumpHeight;

    private Rigidbody2D rb;
    public PlayerState currentState;

    private SpriteRenderer spriteRenderer;
    public Sprite[] runSprites;
    public Sprite climbSprite;
    public Sprite[] hammerSprites;
    private int spriteIndex;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable(){

        InvokeRepeating(nameof(AnimateSprite), 1f/12f, 1f/12f);
        currentState = GetComponent<PlayerStateController>().currentState;
    }

    private void OnDisable(){
        CancelInvoke();
    }

    void Update()
    {
        currentState = GetComponent<PlayerStateController>().currentState;
        IsJumping();
    }

    void FixedUpdate() {
        Movement();
    }


    void Movement(){

        var hMovement = Input.GetAxis("Horizontal");
        var vMovement = Input.GetAxis("Vertical");

        if (currentState == PlayerState.MOVING){
            speed = MoveSpeed;
        }else if (currentState == PlayerState.JUMPING){
            speed = JumpSpeed;
        }

        PlayerDir(hMovement);
        PlayerIdle(hMovement);

        transform.position += new Vector3(hMovement,0.001f,0.001f) * Time.deltaTime * speed;


        if (currentState == PlayerState.LADDER && hMovement == 0){
            climbing = true;
            transform.position += new Vector3(0.001f,vMovement,0.001f) * Time.deltaTime * climbSpeed;
        }else{
            climbing = false;
        }
    }

    private void IsJumping(){
        if (currentState != PlayerState.PAUSE){
            if (currentState != PlayerState.JUMPING){
                if (Input.GetButtonDown("Jump")){
                    GetComponent<PlayerStateController>().ChangePlayerState(PlayerState.JUMPING);
                    rb.AddForce(new Vector2(0.001f, JumpHeight), ForceMode2D.Impulse);
                }
            }
        }
    }
    
    private void AnimateSprite(){
        if (currentState == PlayerState.LADDER && climbing == true){
            spriteRenderer.sprite = climbSprite;
        }

        if (currentState == PlayerState.IDLE){
            spriteRenderer.sprite = runSprites[0];
        }

        if (currentState == PlayerState.MOVING){
            spriteIndex++;
            if (spriteIndex >= runSprites.Length){
                spriteIndex = 0;
            }
            spriteRenderer.sprite = runSprites[spriteIndex];
        }

        if (currentState == PlayerState.REWIND){
            spriteIndex--;
            if (spriteIndex < 0){
                spriteIndex = runSprites.Length;
            }
            spriteRenderer.sprite = runSprites[spriteIndex];
        }
        
        if (currentState == PlayerState.HAMMER){
            spriteIndex++;
            if (spriteIndex >= hammerSprites.Length){
                spriteIndex = 0;
            }
            spriteRenderer.sprite = hammerSprites[spriteIndex];
        }
    }

    private void PlayerDir(float hMovement){
        if (hMovement < -0.001f){
            spriteRenderer.flipX = true;
        }else {
            if (spriteRenderer.flipX == true && hMovement >= 0.001f){
                spriteRenderer.flipX = false;
            }
        }
    }

    private void PlayerIdle(float hMovement){
        if (currentState != PlayerState.JUMPING){
            if (hMovement < 0.05f && hMovement > -0.05){
                GetComponent<PlayerStateController>().ChangePlayerState(PlayerState.IDLE);
            }else{
                GetComponent<PlayerStateController>().ChangePlayerState(PlayerState.MOVING);
            }
        }
    }


    public void respawn(){
        spriteRenderer.flipX = false;
        enabled = true;
    }
}
