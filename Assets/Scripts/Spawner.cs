using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public spawnerType type;
    public float minTime;
    public float maxTime;


    void Start()
    {
        Spawn(); 
        minTime = type.minTime;
        maxTime = type.maxTime;  
    }

    private void Spawn()
    {
        if (GameObject.Find("Mario").GetComponent<Rewindable>().spawn == true){
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
        Invoke(nameof(Spawn), Random.Range(minTime, maxTime));
    }

  
}
