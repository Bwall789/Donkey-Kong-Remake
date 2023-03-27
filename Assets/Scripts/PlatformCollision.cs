using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{

    [SerializeField] private GameObject platform1;
    [SerializeField] private GameObject platform2;
    [SerializeField] private GameObject platform3;
    [SerializeField] private GameObject platform4;
    [SerializeField] private GameObject platform5;
    [SerializeField] private GameObject platform6;

    [SerializeField] private GameObject player;

    private float h1;
    private float h2;
    private float h3;
    private float h4;
    private float h5;
    private float h6;
    private float playerY;

    private int h1Layer;

    // Physics.IgnoreLayerCollision (layer1, layer2, true) Physics.IgnoreLayerCollision (layer1, layer2, false)



    // Start is called before the first frame update
    void Start()
    {
        h1 = platform1.transform.position.y;
        h2 = platform2.transform.position.y;
        h3 = platform3.transform.position.y;
        h4 = platform4.transform.position.y;
        h5 = platform5.transform.position.y;
        h6 = platform6.transform.position.y;

        h1Layer = platform1.layer;

    }

    // Update is called once per frame
    void Update()
    {

        playerY = player.transform.position.y;
    
        if (playerY > h1){
            Physics2D.IgnoreLayerCollision(h1Layer, player.layer, false);
            Debug.Log("yo");
        } else {
            Physics2D.IgnoreLayerCollision(h1Layer, player.layer, true);
        }

        if (playerY > h2){
            platform2.GetComponent<Collider2D>().enabled = true;

        } else {
            platform2.GetComponent<Collider2D>().enabled = false;
        }

        if (playerY > h3){
            platform3.GetComponent<Collider2D>().enabled = true;
            
        } else {
            platform3.GetComponent<Collider2D>().enabled = false;
        }

        if (playerY > h4){
            platform4.GetComponent<Collider2D>().enabled = true;
            
        } else {
            platform4.GetComponent<Collider2D>().enabled = false;
        }

        if (playerY > h5){
            platform5.GetComponent<Collider2D>().enabled = true;
            
        } else {
            platform5.GetComponent<Collider2D>().enabled = false;
        }

        if (playerY > h6 + 0.3){
            platform6.GetComponent<Collider2D>().enabled = true;
            
        } else {
            platform6.GetComponent<Collider2D>().enabled = false;
        }

    }
}
