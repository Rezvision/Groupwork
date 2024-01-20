using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TimeTravel : MonoBehaviour
{
    public bool isRewinding=false;
    public bool isFuture=false;
    List<pointInTime> pointsInTime;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<pointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            //isRewinding = true;
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.R)) 
        {
            StopRewind();
        }

    //    else 
    //    {
    //        isRewinding = false;
    //    }

    //    if (Input.GetKeyDown(KeyCode.F)) 
    //    {
    //        isFuture = true;
    //        //FutureTravel()
    //    }
    }

    private void FixedUpdate()
    {
        if (isRewinding) 
        {
            Rewind();

        }
        else
            Record();
        
    }

    void Rewind() 
    {   if (pointsInTime.Count > 0) 
        {
        pointInTime pointInTime = pointsInTime[0];
        transform.position = pointInTime.position;
        transform.rotation = pointInTime.rotation;  
        //transform.SetPositionAndRotation(pointsInTime.posit, pointInTime.rotation);
        pointsInTime.RemoveAt(0);
        }
    }
    void Record() 
    {
        pointsInTime.Insert(0, new pointInTime(transform.position, transform.rotation));
    }
    //public Rewind()
    public void StartRewind() 
        {
            isRewinding = true;
            rb.isKinematic = true;
        }


    public void StopRewind() 
        {
            isRewinding = false;
            rb.isKinematic = false;
        }

    //{
    //    if (!isRewinding) 
    //    {
    //    }
    //}
}

