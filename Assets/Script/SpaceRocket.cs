using UnityEngine;
using System.Collections;

public class SpaceRocket : MonoBehaviour
{
    public float thrust = 1000f; // Thrust force applied to the rocket
    public ParticleSystem exhaustParticles; // Reference to the exhaust particle system
    public ParticleSystem exhaustParticles1;
    public ParticleSystem exhaustParticles2;
    public ParticleSystem exhaustParticles3; // Reference to the exhaust particle system of the last engine




    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component attached to the rocket
        rb = GetComponent<Rigidbody>();

        // Start the launch sequence coroutine
        StartCoroutine(LaunchSequence());
    }

    IEnumerator LaunchSequence()
    {
        // Wait for 40 seconds
        yield return new WaitForSeconds(40f);

        // Activate the rocket
        rb.AddForce(Vector3.up * thrust);

        // Play the exhaust particle system
        exhaustParticles.Play();
        exhaustParticles1.Play();
        exhaustParticles2.Play();
        exhaustParticles3.Play();


        // Wait for another period of time before making the rocket disappear
        yield return new WaitForSeconds(10f);

        // Deactivate the rocket
        gameObject.SetActive(false);
    }
}
