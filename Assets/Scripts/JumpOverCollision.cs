using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverCollision : MonoBehaviour
{

     void OnCollisionEnter2D(Collision2D collisionDetect3)
     {
         if (collisionDetect3.gameObject.tag == "Death"){
            FindObjectOfType<GameManager>().BarrelPoints();
         }
     }
}
