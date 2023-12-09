
using System.Collections;
using UnityEngine;

public class Action_Sleep : Action
{


    GoblinNeeds goblinNeed;
    GameObject goblino; 

    public Action_Sleep(GameObject goblino)
    {
        this.goblino = goblino;
        goblinNeed = this.goblino.GetComponent<GoblinNeeds>();
    }
    public override IEnumerator PerformAction()
    {
        Debug.Log("SCHLUMBER TIME :)  (Slumber Action Being Performed)");


        GameObject Tent = GameObject.FindGameObjectWithTag("TentTag");
        goblino.GetComponent<Astar>().PathfindTo(Tent.transform.position + Vector3.down);

        yield return new WaitForSeconds(7);
        
        goblinNeed.Rest();
    }
}

