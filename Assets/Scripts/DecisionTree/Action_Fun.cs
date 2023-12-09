
using System.Collections;
using UnityEngine;

public class Action_Fun : Action
{


    GoblinNeeds goblinNeed;
    GameObject goblino;

    public Action_Fun(GameObject goblino)
    {
        this.goblino = goblino;
        goblinNeed = this.goblino.GetComponent<GoblinNeeds>();
    }

    //Can add more functions into these, one for kill one for dance one ofr game and the perform action just randomly selects one. 
    public override IEnumerator PerformAction()
    {
        //dances at campafire
        //target campfire


        Debug.Log("Start Wait Time");
        yield return new WaitForSeconds(3);
        Debug.Log("End Wait Time");


        goblinNeed.Play(15);

    }
}

