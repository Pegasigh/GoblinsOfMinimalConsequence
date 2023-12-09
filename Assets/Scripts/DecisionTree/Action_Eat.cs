
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Action_Eat : Action
{

    GoblinNeeds goblinNeed;
    FoodLevels foodlvl;
    GameObject goblino;

 public Action_Eat  (FoodLevels foodlvl, GameObject goblino)
    {   
        this.foodlvl = foodlvl;
        this.goblino = goblino;
        goblinNeed = this.goblino.GetComponent<GoblinNeeds>();
    }
    public override IEnumerator PerformAction()
    {
        Debug.Log("Time for lunch, Crunch MUNCH! (Eat Action being Performed)");

        GameObject Campfire = GameObject.FindGameObjectWithTag("CampfireTag");
        Debug.Log(Campfire.transform.position);
        goblino.GetComponent<Astar>().PathfindTo(Campfire.transform.position + Vector3.down);

        //when we reach the location:
        while (!goblino.GetComponent<Astar>().IsAtDestination()) yield return null;

        //waiting
        yield return new WaitForSeconds(3);

        goblinNeed.Feed(5);
        foodlvl.SubtractFood(5);
    }
}
