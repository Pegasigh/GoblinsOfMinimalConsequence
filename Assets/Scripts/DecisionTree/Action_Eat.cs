
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Eat : Action
{

    GoblinNeeds goblinNeed;
    FoodLevels foodlvl;
    GameObject goblino;

 public Action_Eat  (FoodLevels foodlvl)
    {   
        this.foodlvl = foodlvl;
        this.goblino = goblino;
        goblinNeed = this.goblino.GetComponent<GoblinNeeds>();
    }
    public override void PerformAction()
    {

        GameObject Campfire = GameObject.FindGameObjectWithTag("CampfireTag");

//        goblino.GetComponent<Astar>().PathfindTo(Campfire.transform.position);
        goblino.GetComponent<DecisionTree>().targetPos.position = Campfire.transform.position;
        goblino.GetComponent<Astar>().PathfindTo(goblino.GetComponent<DecisionTree>().targetPos.position);


        //target to the campfire
        goblinNeed.Feed(5);



    }


}
