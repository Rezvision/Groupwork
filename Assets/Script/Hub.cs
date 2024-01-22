using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using TMPro;

public class Hub : MonoBehaviour
{
    public Button ForestButton; // Reference to the forest button.
    public Vector3 forestPosition = new Vector3(3f, 1f, -7f);
    public Button urbanButton;
    public Button antarticButton;
    public InputActionReference forestTrigger;
    public InputActionReference urbanTrigger;
    public InputActionReference antarticTrigger;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ForestButton.onClick.AddListener(Forest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Forest()
    {
        // Display the game over UI and appropriate message.
        player.transform.position = forestPosition; //player moved to target position /*transform.GetPositionAndRotation(out targetPosition,out Quaternion.ide);*/

    }
}   
