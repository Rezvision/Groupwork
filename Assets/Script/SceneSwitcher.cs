using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // Set the name of the scene to load in the Unity Editor
    private Hub hub;

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
        //hub = GameObject.FindGameObjectWithTag("hub").GetComponent<Hub>();

        //if (hub.isForest) 
        //{

        //}
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(10f); // Wait for 15 seconds

        // Load the specified scene, this removed the original scene which was not intended
        //SceneManager.LoadScene(sceneToLoad);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
    }
}
