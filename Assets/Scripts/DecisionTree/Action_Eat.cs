
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

        //finding any campfire
        GameObject Campfire = GameObject.FindGameObjectWithTag("CampfireTag");

        //pathfinding to found campfire
        goblino.GetComponent<Astar>().PathfindTo(Campfire.transform.position + Vector3.down);

        //returning early if not yet at destination
        while (!goblino.GetComponent<Astar>().IsAtDestination()) yield return null;

        Debug.Log("eating");

        //waiting at the destination
        yield return new WaitForSeconds(1);

        //eating is done, changing hunger and village food levels
        goblinNeed.Feed(30);
        foodlvl.SubtractFood(15);

        Debug.Log("Goblin Need Hunger: " + goblinNeed.hunger);        
        Debug.Log("Eat Action COMPLETED");


    }
}
