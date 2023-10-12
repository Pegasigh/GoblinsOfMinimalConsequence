using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WanderRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float posx = Random.Range(-9, 9);
        float posy = Random.Range(-5, 5);
        Vector3 newpositon = new Vector3(posx, posy, 0);
        transform.position = newpositon;
        Debug.Log("Triggered");
    }
}
