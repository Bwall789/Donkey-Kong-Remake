using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float MoveSpeed = new float();
    public float JumpHeight = new float();

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MoveSpeed;
    
    if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) <0.001f)
    {
         rb.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
    }
    
    
    }
}
