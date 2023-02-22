using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public new Transform camera;
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;


    void OnTriggerEnter2D(Collider2D collisionDetect){
        if (collisionDetect.gameObject.tag == "cam1"){
        camera.gameObject.transform.position = target1.position;
        }

        if (collisionDetect.gameObject.tag == "cam2"){
        camera.gameObject.transform.position = target2.position;
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
