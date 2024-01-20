using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentOfObjectsUsingWaypoints : MonoBehaviour

{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointMovement = 0;
    [SerializeField] float speed = 1f;
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointMovement].transform.position) < 0.1f)
        {
            currentWaypointMovement++;
            if (currentWaypointMovement >= waypoints.Length)
            {
                currentWaypointMovement = 0;
            }

        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointMovement].transform.position, speed * Time.deltaTime);
    }
}
