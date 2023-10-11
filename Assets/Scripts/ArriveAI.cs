using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveAI : MonoBehaviour
{
    public float innerRadius;
    public float outerRadius;
    public float accelerationFactor = 0.1f;
    public float maxAcceleration = 100;

    Body bodyScript;
    public Transform target;

    private void Start()
    {
        bodyScript = GetComponent<Body>();
    }

    // Update is called once per frame
    void Update()
    {
        SteeringOutput steering;

        //finding distance to target
        Vector2 direction = (Vector2)target.position - bodyScript.position;
        float distance = direction.magnitude;

        
        //if far away
        if (distance > outerRadius)
        {
            return;
        }
        //if at target
        if (distance < innerRadius)
        {
            //counter other steering behaviours
            steering.linearAcceleration = -bodyScript.linearAcceleration - (bodyScript.linearVelocity / Time.deltaTime);
        }
        else //if between radiuses, scale speed
        {
            float targetSpeed;
            Vector2 targetVelocity;

            targetSpeed = bodyScript.maxSpeed * (distance - innerRadius) / outerRadius;
            targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;

            steering.linearAcceleration = targetVelocity - bodyScript.linearVelocity;
            steering.linearAcceleration /= accelerationFactor;

            //clipping acceleration
            if(steering.linearAcceleration.magnitude > maxAcceleration)
            {
                steering.linearAcceleration.Normalize();
                steering.linearAcceleration *= maxAcceleration;
            }
        }

        steering.angularAcceleration = 0;
        bodyScript.ApplyForce(steering);
    }
}
