using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = UnityEngine.Input;

public class Drag : MonoBehaviour
{

    public bool dragging;
    public Transform pos;

    private Vector3 offset;

    private void Start()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
            pos.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    private void OnMouseDown()
    {
        offset = pos.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
        gameObject.tag = "Dragging";
    }

    private void OnMouseUp()
    {
        dragging = false;
        gameObject.tag = "NOTDragging";
    }
}
