using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collisionDetect){
        if (collisionDetect.gameObject.tag == "Death"){
            transform.position = new Vector3(-10.19f,-8.96f,0f);
        }
    }

}
