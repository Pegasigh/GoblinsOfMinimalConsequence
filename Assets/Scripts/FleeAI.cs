using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeAI : MonoBehaviour
{
    Body bodyScript;
    public Transform target;
    public float fleeRadius = 5.0f;
    public float maxSpeed = 10.0f; 
    public float decel = 0.1f; // Speed to slow down to when not fleeing

    private bool isFleeing = false;

    // first framerino
    void Start()
    {
        bodyScript = GetComponent<Body>();
    }

    
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < fleeRadius)
        {
            // If within the fleeRadius, start fleeing
            StartFleeing();
        }
        else if (isFleeing)
        {
            // If Its not in the radius. Slow down, then turn off Fleeing. 
            SlowDown();
            isFleeing = false;
        }

        if (isFleeing)
        {
            // Flee behavior
            SteeringOutput result;
            result.linearAcceleration = transform.position - target.position;
            result.linearAcceleration.Normalize();
            result.linearAcceleration *= maxSpeed;

            result.angularAcceleration = 0; // You can change this if needed

            bodyScript.AddForce(result);
        }
    }

    // Call this thingy to start fleeing
    public void StartFleeing()
    {
        isFleeing = true;
    }

    // function to slow down to a stop when not fleeing
    private void SlowDown()
    {
        Vector3 velocity = bodyScript.linearVelocity;
        if (velocity.magnitude > decel)
        {
            velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime);

        }

    }
}
