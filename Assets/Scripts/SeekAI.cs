using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ArriveAI), typeof(Body))]
public class SeekAI : MonoBehaviour
{

    Body bodyScript;
    public GameObject seekTargetTransformObject;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        bodyScript = GetComponent<Body>();
        target = seekTargetTransformObject.transform;
        target.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        SteeringOutput result;
        result.linearAcceleration = target.position - transform.position;
        result.linearAcceleration.Normalize();
        result.linearAcceleration *= bodyScript.maxSpeed;

        result.angularAcceleration = 0; //can change if we want goblins to face towards target, must then do some other things

        bodyScript.AddForce(result);
    }

    public void setTarget(Vector3 pos)
    {
        target.position = pos;
    }
}
