



using System.Collections;
using UnityEngine;

public class Action_Fish : Action
{

   
    FoodLevels villageFood;
    GoblinNeeds goblinNeed;
    GameObject goblino;

   
      
 
    public Action_Fish(FoodLevels villagefoodLvl, GameObject goblino) 
    { 
        this.goblino = goblino;
        goblinNeed = this.goblino.GetComponent<GoblinNeeds>();
        villageFood = villagefoodLvl;
    }
    public override IEnumerator PerformAction()
    {
        //Set target to the Pond
        // if we need to edit goblin needs use goblinNeed
        Debug.Log("Women want me, FISH FEAR ME! (Fishing Action being Performed)");


        GameObject Pond = GameObject.FindGameObjectWithTag("PondTag");
        goblino.GetComponent<Astar>().PathfindTo(Pond.transform.position + Vector3.down);

        yield return new WaitForSeconds(7);

        villageFood.AddFood(10);
    }
}
