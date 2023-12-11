
using System.Collections;
using UnityEngine;

public class Action_Wander : Action
{


    GoblinNeeds goblinNeed;
    GameObject goblino;

    public Action_Wander(GameObject goblino)
    {
        this.goblino = goblino;
        goblinNeed = this.goblino.GetComponent<GoblinNeeds>();
    }
    public override IEnumerator PerformAction()
    {
        Debug.Log("Wanderer, I'm a Wanderer");


        GameObject WanderPoint = GameObject.FindGameObjectWithTag("WanderPointTag");

        goblino.GetComponent<Astar>().PathfindTo(WanderPoint.transform.position + Vector3.left);
        Debug.Log(WanderPoint.transform.position);

        //when we reach the location:


        //  goblino.GetComponent<Astar>().PathfindTo(Tent.transform.position + Vector3.down);




        while (!goblino.GetComponent<Astar>().IsAtDestination()) yield return null;
        Debug.Log("ON the way");



        //waiting
        yield return new WaitForSeconds(1);



    }
}

