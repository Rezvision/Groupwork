using System.Collections;
using UnityEngine;

public class AnimalKillerBear : MonoBehaviour
{
    public GameObject replacementPrefab; // Drag and drop the new object prefab in the Unity Editor
    public float rotationAmount = 170f; // Set the rotation amount in the Unity Editor
    public float upwardOffset = 1.0f; // Adjust the value based on how much you want the object to move up
    public GameObject objectToToggle; // Reference to the GameObject you want to turn on or off

    void Start()
    {
        objectToToggle.SetActive(false);
        StartCoroutine(ManipulateObject());

    }
    
    IEnumerator ManipulateObject()
    {
        yield return new WaitForSeconds(30f); // Wait for 30 seconds

        // Rotate the object by 90 degrees
        transform.Rotate(Vector3.back, 90f);
        //moce the object slightly higher so it does not collide with floor
        transform.Translate(Vector3.up * upwardOffset);

        yield return new WaitForSeconds(10f); // Wait for additional 10 seconds

        // Instantiate a new object in the same position
        GameObject replacementObject = Instantiate(replacementPrefab, transform.position, Quaternion.identity);
        // Set the rotation of the replacement object using a public variable
        replacementObject.transform.rotation = Quaternion.Euler(0f, rotationAmount, 0f);


        // Remove the current object
        Destroy(gameObject);
        objectToToggle.SetActive(true);
    }
}

