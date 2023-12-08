



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
     public override void PerformAction()
    {
        //Set target to the Pond
        // if we need to edit goblin needs use goblinNeed



        GameObject Pond = GameObject.FindGameObjectWithTag("PondTag");

        goblino.GetComponent<Astar>().PathfindTo(Pond.transform.position);


        Debug.Log("Start Wait Time");

        new WaitForSeconds(5);

        Debug.Log("End Wait Time");

        //goblino.GetComponent<DecisionTree>().targetPos.position = Pond.transform.position;
        //goblino.GetComponent<Astar>().PathfindTo(goblino.GetComponent<DecisionTree>().targetPos.position);

        villageFood.AddFood(10);

    }


}
