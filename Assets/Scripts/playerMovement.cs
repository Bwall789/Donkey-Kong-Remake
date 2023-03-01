using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float MoveSpeed = new float();
    public float JumpSpeed = new float();
    public float JumpHeight = new float();
    public bool ladder = new bool();

    private Rigidbody2D rb;
    private float speed = new float();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ladder = false;
    }

    // Update is called once per frame
    void Update()
    {
        var hMovement = Input.GetAxis("Horizontal");
        var vMovement = Input.GetAxis("Vertical");

        
        if (Mathf.Abs(rb.velocity.y) < 0.005f){
            speed = MoveSpeed;
        }else{
            speed = JumpSpeed;
        }

        if (vMovement == 0){
            transform.position += new Vector3(hMovement,0,0) * Time.deltaTime * speed;
        }
    
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) <0.001f)
        {
        var storeSpeed = MoveSpeed;
         rb.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
        }
    
        if (ladder == true){
            vMovement = Input.GetAxis("Vertical");
            transform.position += new Vector3(0,vMovement,0) * Time.deltaTime * speed * 5;
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
