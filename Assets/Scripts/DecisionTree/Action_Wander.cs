
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

        //finding a random point
        float posx = Random.Range(-9, 9) + 0.5f;
        float posy = Random.Range(-5, 5) + 0.5f;
        Vector3 newpositon = new Vector3(posx, posy, 0);

        //pathfinding to the point
        goblino.GetComponent<Astar>().PathfindTo(newpositon + Vector3.left);

        //returning early if not yet at destination
        while (!goblino.GetComponent<Astar>().IsAtDestination()) yield return null;

        //waiting at destination
        yield return new WaitForSeconds(1);
    }
}

