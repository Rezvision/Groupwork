using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public bool isRewinding=false;
    public bool isFuture=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            isRewinding = true;
            //Rewind()
        }
        else 
        {
            isRewinding = false;
        }

        if (Input.GetKeyDown(KeyCode.F)) 
        {
            isFuture = true;
            //FutureTravel()
        }
    }
    //public Rewind()
    //{
    //    if (!isRewinding) 
    //    {
    //    }
    //}
}

