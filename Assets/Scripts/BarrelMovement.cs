using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{
    private bool direction;


    void Start()
    {
        direction = true;
    }

    void FixedUpdate()
    {
        Movement();
    }


    private void Movement(){
        if(direction == true){



        }else if (direction == false){

        

        }
    }


    void OnCollisionEnter2D(Collision2D collisionDetect){
        if (collisionDetect.gameObject.tag == "Barrier"){
            Debug.Log("fuck");
            direction = !direction;
        }
    }






}
