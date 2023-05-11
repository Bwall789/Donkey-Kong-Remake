using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    public EnemyType type;
    private bool isDestructable;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = type.speed;
        isDestructable = type.destructable;
    }

    void OnCollisionEnter2D(Collision2D collisionDetect){
        if (this.GetComponent<Rewindable>().isRewinding == false){
            if (collisionDetect.gameObject.tag == "Platform"){
                rb.AddForce(collisionDetect.transform.right * speed, ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "JumpOver"){
            FindObjectOfType<GameManager>().BarrelPoints();
        }
    }





}
