using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entertrigger : MonoBehaviour
{
    public GameObject textPopUp;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        textPopUp.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        textPopUp.SetActive(false);
    }
}
