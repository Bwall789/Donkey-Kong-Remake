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
    public Sprite climbSprite;
    private int spriteIndex;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ladder = false;
        check = false;
    }

    private void OnEnable(){

        InvokeRepeating(nameof(AnimateSprite), 1f/12f, 1f/12f);
    }

     private void OnDisable(){

        CancelInvoke();
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



    private void AnimateSprite(){
        if (ladder && Mathf.Abs(rb.velocity.y) > 0.005f){
            spriteRenderer.sprite = climbSprite;
        }else {
            spriteIndex++;
            if (spriteIndex >= runSprites.Length){
                spriteIndex = 0;
            }
            spriteRenderer.sprite = runSprites[spriteIndex];
        }

    }

    private void PlayerDir(float hMovement){
        if (hMovement < 0.001f){
            var targetAngles = transform.eulerAngles + 180f * Vector3.up;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 1f * Time.deltaTime);
        }
    }









}
