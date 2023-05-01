using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 8f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collisionDetect){
        if (collisionDetect.gameObject.tag == "Platform"){
            rb.AddForce(collisionDetect.transform.right * speed, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "JumpOver"){
            FindObjectOfType<GameManager>().BarrelPoints();
        }
    }





}
