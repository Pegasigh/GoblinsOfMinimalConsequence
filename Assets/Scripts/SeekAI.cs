using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAI : MonoBehaviour
{

    Body bodyScript;
    public Transform target;
    Astar astar;
    private Node currentNode;
    private Node targetNode;
    // Start is called before the first frame update
    void Start()
    {
         bodyScript = GetComponent<Body>();

        targetNode.Position = new Vector3Int(1, 1, 0);
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

        currentNode.Position = new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0);
        targetNode.Position = new Vector3Int(Mathf.FloorToInt(target.position.x), Mathf.FloorToInt(target.position.y), 0);

        astar.Algorithm(currentNode, targetNode);
    }
}
