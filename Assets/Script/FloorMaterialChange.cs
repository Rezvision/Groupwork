using System.Collections;
using UnityEngine;

public class FloorMaterialChanger : MonoBehaviour
{
    public Material newMaterial; // Drag and drop the new material in the Unity Editor


    void Start()
    {
        StartCoroutine(ChangeMaterialAfterDelay());

    }
  
    IEnumerator ChangeMaterialAfterDelay()
    {
        yield return new WaitForSeconds(40f); // Wait for 40 seconds

        Renderer floorRenderer = GetComponent<Renderer>();

        if (floorRenderer != null)
        {
            floorRenderer.material = newMaterial; // Change the material
        }
        else
        {
            Debug.LogError("Renderer component not found on the floor object.");
        }
    }
}
