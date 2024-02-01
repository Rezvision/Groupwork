using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTransporter : MonoBehaviour
{
    public GameObject XROrigin;
    public GameObject airTransporter;

    public bool onTransporter;
    public float amountBelowTransporter;


    // Update is called once per frame
    void Update()
    {
        if (onTransporter)
        {
            XROrigin.transform.position = airTransporter.transform.position;    
            //XROrigin.transform.position = new Vector3(airTransporter.transform.position.x, airTransporter.transform.position.y - amountBelowTransporter, transform.position.z);
        }
    }

    public void Grabbed()
    {
        Debug.Log("grabbed");
        onTransporter = true;
    }

    public void Relesed()
    {
        Debug.Log("released");
        onTransporter = false;
    }

}
