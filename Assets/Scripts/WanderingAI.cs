using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WanderingAI : MonoBehaviour
{

    Body bodyScript;
    public Vector2 bounds;
    // Start is called before the first frame update
    void Start()
    {

        if (bounds == null)
            bounds.Set(0, 0);


        bodyScript = GetComponent<Body>();
    }

    // Update is called once per frame
    void Update()
    {
        SteeringOutput result;



        bodyScript.ApplyForce(result);
    }

    Vector2 RandomWanderPoint()
    {
        

        return Vector2.up;
    }
}
