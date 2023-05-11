using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewindable : MonoBehaviour
{

    public bool isRewinding = false;
    public bool spawn = true;
    List<PointInTime> pointsInTime;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pointsInTime = new List<PointInTime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("backspace")){
            StartRewind();
            spawn = false;
        }

        if (Input.GetKeyUp("backspace")){
            StopRewind();
            spawn = true;
            rb.constraints = RigidbodyConstraints2D.None;
            if (this.GetComponent<playerMovement>() != null){
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    public void StartRewind(){
        rb.isKinematic = true;
        isRewinding = true;
    }

    public void StopRewind(){
        rb.isKinematic = false;
        isRewinding = false;
        ReapplyForces();

    }

    public void FixedUpdate(){
        if (isRewinding){
            Rewind();
        }else{
            Record();
        }
    }

    public void Record(){
        if (pointsInTime.Count > Mathf.Round(0.4f / Time.fixedDeltaTime)){
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }else{
            pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation, rb.velocity, rb.angularVelocity));
        }
    }


    public void Rewind(){
        if (pointsInTime.Count > 0){
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }else {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            isRewinding = false;
        }
    }

    void ReapplyForces() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
  }


}
