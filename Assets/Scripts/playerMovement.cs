using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float MoveSpeed = new float();
    public float JumpSpeed = new float();
    public float JumpHeight = new float();
    public bool ladder = new bool();
    public bool check = new bool();

    private Rigidbody2D rb;
    private float speed = new float();

    private SpriteRenderer spriteRenderer;
    public Sprite[] runSprites;
    public Sprite climbSpreite;
    private int spriteIndex;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ladder = false;
        check = false;
    }

    void Update() {
    
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

        transform.position += new Vector3(hMovement,0.001f,0.001f) * Time.deltaTime * speed;
    
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.005f){
            rb.AddForce(new Vector2(0.001f, JumpHeight), ForceMode2D.Impulse);
        }
    

    }

    void LadderMovement() {

        var hMovement = Input.GetAxis("Horizontal");
        var vMovement = Input.GetAxis("Vertical");

        if (ladder == true && hMovement == 0){
            transform.position += new Vector3(0.001f,vMovement,0.001f) * Time.deltaTime * speed * 5f;
        }

        if(ladder == true && hMovement == 0 && Mathf.Abs(rb.velocity.y) > 0.005f){
            check = true;
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



}
