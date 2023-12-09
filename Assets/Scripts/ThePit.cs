using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePit : MonoBehaviour
{
    GameObject goblin;
    string holderTag;

    private void OnTriggerStay2D(Collider2D collision)
    {
        goblin = collision.gameObject;

        if(holderTag == null)
            holderTag = goblin.tag;

        if(goblin.tag != holderTag)
        {
            Destroy(goblin);
        }
    }
}
