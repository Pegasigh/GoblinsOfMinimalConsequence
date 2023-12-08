
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
    public override void PerformAction()
    {

        Debug.Log("Time for lunch, Crunch MUNCH! (Eat Action being Performed)");

        GameObject Campfire = GameObject.FindGameObjectWithTag("CampfireTag");

        goblino.GetComponent<Astar>().PathfindTo(Campfire.transform.position);


        Debug.Log("Start Wait Time");

        new WaitForSeconds(3);

        Debug.Log("End Wait Time");


        //goblino.GetComponent<DecisionTree>().targetPos.position = Campfire.transform.position;
        //goblino.GetComponent<Astar>().PathfindTo(goblino.GetComponent<DecisionTree>().targetPos.position);


        //target to the campfire


            goblinNeed.Feed(5);
            foodlvl.SubtractFood(5);
       


    }


}
