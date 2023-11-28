

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

        goblinNeed.Talk(10);


    }


}
