using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
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
        if (collisionDetect.gameObject.tag == "Win"){
            
            //set player movement to 0 speed
            // ui changes
            //victory music
            //change stage


        }
    }
}
