using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WanderRandomizer : MonoBehaviour
{

    private void Start()
    {
        InvokeRepeating("MoveObject", 1.0f, 1.0f);
    }
    private void MoveObject()
    {
        Thread.Sleep(Random.Range(10,20));
        float posx = Random.Range(-9, 9) + 0.5f;
        float posy = Random.Range(-5, 5) + 0.5f;
        Vector3 newpositon = new Vector3(posx, posy, 0);
        transform.position = newpositon;
        //Debug.Log("Triggered");
    }
}
