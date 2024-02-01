using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportTargetBack;
    public Transform teleportTargetForward;
    public Camera mainCamera;

    public InputActionReference thrustActionLeft;
    public InputActionReference thrustActionRight;

    private bool hasTeleported;

    private float originalFOV; // To store the original FOV
    private float transitionDuration = 2f; // Duration for each transition

    PlayAudio neededScript;

    private void Start()
    {
        neededScript = GameObject.FindGameObjectWithTag("Needed").GetComponent<PlayAudio>();

        if (mainCamera != null)
        {
            originalFOV = mainCamera.fieldOfView;
        }
        else
        {
            Debug.LogError("Target camera not assigned!");
        }
    }
    private void Update()
    {

        if (thrustActionRight.action.IsPressed() && hasTeleported == false)
        {
            //TeleportForward();
            ActivateTransitionForward();
        }
        if (thrustActionLeft.action.IsPressed() && hasTeleported == true)
        {
            ActivateTransitionBack();
        }
    }

    private void TeleportForward()
        {
                transform.position = teleportTargetForward.position;
                Debug.Log("Teleporting forward");
                hasTeleported = true;
        }

    private void TeleportBack()
        {
                transform.position = teleportTargetBack.position;
                Debug.Log("Teleporting forward");
                hasTeleported = false;
        }

    private IEnumerator AdjustFOVCoroutineForward()
    {
        // Smoothly reduce FOV to 0 over one second
        float elapsedTime = 0;
        while (elapsedTime < transitionDuration)
        {
            mainCamera.fieldOfView = Mathf.Lerp(originalFOV, 0, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        // Execute your function here
        TeleportForward();
        neededScript.PlayFunctionClip();

        yield return new WaitForSeconds(1f);

        // Smoothly restore the original FOV over one second
        elapsedTime = 0;
        while (elapsedTime < transitionDuration)
        {
            mainCamera.fieldOfView = Mathf.Lerp(0, originalFOV, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.fieldOfView = originalFOV; // Ensure FOV is set to original at the end
    }

    public void ActivateTransitionForward()
    {
        StartCoroutine(AdjustFOVCoroutineForward());
    }
    private IEnumerator AdjustFOVCoroutineBack()
    {
        // Smoothly reduce FOV to 0 over one second
        float elapsedTime = 0;
        while (elapsedTime < transitionDuration)
        {
            mainCamera.fieldOfView = Mathf.Lerp(originalFOV, 0, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        // Execute your function here
        TeleportBack();
        neededScript.PlayStartClip();

        yield return new WaitForSeconds(1f);

        // Smoothly restore the original FOV over one second
        elapsedTime = 0;
        while (elapsedTime < transitionDuration)
        {
            mainCamera.fieldOfView = Mathf.Lerp(0, originalFOV, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.fieldOfView = originalFOV; // Ensure FOV is set to original at the end
    }

    public void ActivateTransitionBack()
    {
        StartCoroutine(AdjustFOVCoroutineBack());
    }
}

