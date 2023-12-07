

using UnityEngine;

public class Action_Socialize : Action
{



    GoblinNeeds goblinNeed;
    GameObject goblino;

    public Action_Socialize(GameObject goblino)
    {
        this.goblino = goblino;
        goblinNeed = this.goblino.GetComponent<GoblinNeeds>();
    }
    public override void PerformAction()
    {
        // Target another goblin, Initiate Interaction. 
    //    goblino.GetComponent<DecisionTree>().targetPos.position = goblin.transform.position;
    //    goblino.GetComponent<Astar>().PathfindTo(goblino.GetComponent<DecisionTree>().targetPos.position);

        goblinNeed.Talk(10);


    }


}
