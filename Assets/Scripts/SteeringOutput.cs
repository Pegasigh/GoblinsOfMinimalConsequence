using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SteeringOutput
{
    public Vector2 linearAcceleration;
    public float angularAcceleration;

    public SteeringOutput(Vector2 linearAcceleration, float angularAcceleration)
    {
        this.linearAcceleration = linearAcceleration;
        this.angularAcceleration = angularAcceleration;
    }
}