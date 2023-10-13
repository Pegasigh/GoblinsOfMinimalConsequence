using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WanderRandomizer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Thread.Sleep(Random.Range(10,20));
        float posx = Random.Range(-9, 9);
        float posy = Random.Range(-5, 5);
        Vector3 newpositon = new Vector3(posx, posy, 0);
        transform.position = newpositon;
        //Debug.Log("Triggered");
    }
}
