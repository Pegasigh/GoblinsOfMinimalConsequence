using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeAI : MonoBehaviour
{
    
    Body bodyScript;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
         bodyScript = GetComponent<Body>();
    }

    // Update is called once per frame
    void Update()
    {
        SteeringOutput result;
        result.linearAcceleration = transform.position - target.position;
        result.linearAcceleration.Normalize();
        result.linearAcceleration *= bodyScript.maxSpeed;

        result.angularAcceleration = 0; //can change if we want goblins to face towards target, must then do some other things

        bodyScript.ApplyForce(result);
    }
}


