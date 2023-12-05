using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = UnityEngine.Input;

public class Drag : MonoBehaviour
{

    public bool dragging = false;
    private Vector3 offset;
    public Transform pos;

    void Update()
    {
        if (dragging)
            pos.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    private void OnMouseDown()
    {
        offset = pos.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
