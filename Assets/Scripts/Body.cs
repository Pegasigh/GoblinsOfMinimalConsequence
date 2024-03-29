using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField]
    private Drag dragging;
    public Vector2 position;
    float rotation;
    public Vector2 linearVelocity;
    public Vector2 linearAcceleration;
    float angularVelocity;
    float angularAcceleration;
    public float maxSpeed;
    float maxAngularSpeed;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dragging.dragging)
        {
            position += (linearVelocity * Time.deltaTime) + (linearAcceleration * 0.5f * Time.deltaTime * Time.deltaTime);
            linearVelocity += linearAcceleration * Time.deltaTime;
            rotation += (angularVelocity * Time.deltaTime) + (angularAcceleration * 0.5f * Time.deltaTime * Time.deltaTime);
            angularVelocity += angularAcceleration * Time.deltaTime;

            //clipping
            if (linearVelocity.magnitude > maxSpeed)
            {
                linearVelocity = linearVelocity.normalized * maxSpeed;
            }

            if (Mathf.Abs(angularVelocity) > maxAngularSpeed)
            {
                angularVelocity = Mathf.Sign(angularVelocity) * maxAngularSpeed;
            }

            //updating the gameobject's transform
            transform.position = position;
            transform.rotation = Quaternion.EulerAngles(new Vector3(0, 0, rotation));

            //resetting accelerations
            angularAcceleration = 0;
            linearAcceleration = Vector2.zero;
        }

        if(dragging.dragging)
        {
            transform.position = dragging.pos.position;
            position = transform.position;
        }
    }

    public void AddForce(SteeringOutput steering)
    {
        linearAcceleration += steering.linearAcceleration;
        angularAcceleration += steering.angularAcceleration;
    }
}
