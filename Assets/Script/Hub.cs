using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class Hub : MonoBehaviour
{

    public Button ForestButton; // Reference to the forest button.
    public Vector3 forestPosition = new Vector3(0.35f, 1.36f, -15f);
    //public Vector3 antarticPosition = new Vector3()
    public float playerRotationY = -20f;
    public Button urbanButton;
    public Button antarticButton;
    public InputActionReference forestTrigger;
    public InputActionReference urbanTrigger;
    public InputActionReference antarticTrigger;
    public GameObject player;
    private AudioSource clickSound;
    public bool isForest = false;
    public bool isAntartic = false;
    public bool isUrban = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ForestButton.onClick.AddListener(Forest);
        clickSound = GameObject.FindGameObjectWithTag("Button").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isForest) 
        { 
        if (forestTrigger.action.IsPressed()) // adding buttton interaction for replaybutton
        {
            Forest();
        }
        }
        //if (exitTrigger.action.IsPressed())
        //{
        //    ExitGame();
        //}

    }
    public void Forest()
    {
        // Display the game over UI and appropriate message.
        clickSound.pitch = UnityEngine.Random.Range(0.5f, 1.5f);
        clickSound.Play();
        SceneManager.LoadScene("Forest");
        //player.transform.position = forestPosition; //player moved to target position /*transform.GetPositionAndRotation(out targetPosition,out Quaternion.ide);*/
        //player.transform.rotation = Quaternion.Euler(0f, playerRotationY, 0f);
        isForest = true;

    }
}   
