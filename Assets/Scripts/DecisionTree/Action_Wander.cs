
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
        //Debug.Log("Wanderer, I'm a Wanderer");
        Debug.Log("Wander Start");

        //finding a random point and refinding point if it is occupied
        Vector3 newPosition;
        do
        {
            //finding a random point
            float posx = Random.Range(-9, 9) + 0.5f;
            float posy = Random.Range(-5, 5) + 0.5f;
            newPosition = new Vector3(posx, posy, 0);
        } while (goblino.GetComponent<Astar>().PosIsOccupied(newPosition)); //recalculates while newPosition is an occupied tile

        //pathfinding to the point
        goblino.GetComponent<Astar>().PathfindTo(newPosition + Vector3.left);

        //returning early if not yet at destination
        while (!goblino.GetComponent<Astar>().IsAtDestination()) yield return null;

        //waiting at destination
        yield return new WaitForSeconds(1);

        Debug.Log("Wander End");
    }
}

