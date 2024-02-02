using UnityEngine;
using System.Collections;
using TMPro;

public class TextMeshLooper : MonoBehaviour
{
    public string[] lines; // Array of lines to display
    public float delayBetweenLines = 1f; // Delay between displaying each line
    public TMP_Text textMeshPro; // Reference to the TextMesh component

    void Start()
    {
        StartCoroutine(DisplayLines());
    }

    IEnumerator DisplayLines()
    {
        // Loop through each line in the array
        for (int i = 0; i < lines.Length; i++)
        {
            // Set the text of the TextMesh to the current line
            textMeshPro.text = lines[i];

            // Wait for the specified delay before displaying the next line
            yield return new WaitForSeconds(delayBetweenLines);
        }

        // After displaying all lines, loop back to the beginning
        StartCoroutine(DisplayLines());
    }
}

