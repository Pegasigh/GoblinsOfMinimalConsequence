using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FloorPosition_EDITOR_ONLY : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        //floor position so we don't have to be so specific when placing in editor

        transform.position = new Vector3(Mathf.Floor(transform.position.x), Mathf.Floor(transform.position.y), transform.position.z);

    }
}
