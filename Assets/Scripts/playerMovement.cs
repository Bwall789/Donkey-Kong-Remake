using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float MoveSpeed = new float();
    public float JumpSpeed = new float();
    public float JumpHeight = new float();
    public bool ladder = new bool();
    public bool Jumping = new bool();
    public bool idle = new bool();

    private Rigidbody2D rb;
    private float speed = new float();

    private SpriteRenderer spriteRenderer;
    public Sprite[] runSprites;
    public Sprite climbSprite;
    private int spriteIndex;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ladder = false;
        idle = true;
        Jumping = false;
    }

    private void OnEnable(){

        InvokeRepeating(nameof(AnimateSprite), 1f/12f, 1f/12f);
    }

     private void OnDisable(){

        CancelInvoke();
    }

    void Update(){
        IsJumping();
    }


    void FixedUpdate() {
        Movement();
        LadderMovement();
    }

    void Movement(){

        var hMovement = Input.GetAxis("Horizontal");
        var vMovement = Input.GetAxis("Vertical");

        if (Mathf.Abs(rb.velocity.y) < 0.005f){
            speed = MoveSpeed;
        } else {
            speed = JumpSpeed;
        }

        PlayerDir(hMovement);
        PlayerIdle(hMovement);
    
        transform.position += new Vector3(hMovement,0.001f,0.001f) * Time.deltaTime * speed;

    }

    void LadderMovement() {

        var hMovement = Input.GetAxis("Horizontal");
        var vMovement = Input.GetAxis("Vertical");

        if (ladder == true && hMovement == 0){
            transform.position += new Vector3(0.001f,vMovement,0.001f) * Time.deltaTime * speed * 5f;
        }

        if(ladder == true && hMovement == 0 && Mathf.Abs(rb.velocity.y) > 0.005f){
            rb.gravityScale = 0;
        }else{
            rb.gravityScale = 1;
        }
    }

     void OnTriggerStay2D(Collider2D collisionDetect){
        if (collisionDetect.gameObject.tag == "Ladder"){
            ladder = true;
        }
    }

     void OnTriggerExit2D(Collider2D collisionDetect2){
        if (collisionDetect2.gameObject.tag == "Ladder"){
            ladder = false;
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
     }

    private void AnimateSprite(){
        if (ladder && Mathf.Abs(rb.velocity.y) > 0.005f && Jumping == false){
            spriteRenderer.sprite = climbSprite;
        }else if (idle == false){
            
            spriteIndex++;
            if (spriteIndex >= runSprites.Length){
                spriteIndex = 0;
            }
            spriteRenderer.sprite = runSprites[spriteIndex];
        }else{
            spriteRenderer.sprite = runSprites[0];
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
        if (hMovement > 0.005f || hMovement < -0.005f){
            idle = false;
        }else{
            idle = true;
        }
    }

    private void IsJumping(){
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f){
            Jumping = true;
            rb.AddForce(new Vector2(0.001f, JumpHeight), ForceMode2D.Impulse);
        }

        if (Jumping == true && Mathf.Abs(rb.velocity.y) < 0.001f){
            Jumping = false;
        }
    }




}
