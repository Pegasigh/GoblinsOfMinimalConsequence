using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveOfNewBeginnings : MonoBehaviour
{
    public GameObject goblin;

    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Hit the Cave");
            Vector3 spawnPosition = transform.position - new Vector3(-0.5f, 0.5f, 0f);
            Instantiate(goblin, spawnPosition, Quaternion.identity);
        }
    }
}
