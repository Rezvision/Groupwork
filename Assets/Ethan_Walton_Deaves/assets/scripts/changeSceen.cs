using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceen : MonoBehaviour
{
    public string scenename;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){

            SceneManager.LoadScene(scenename);

        }
    }
}
