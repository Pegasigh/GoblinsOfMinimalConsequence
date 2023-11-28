
using UnityEngine;

public class Action_Sleep : Action
{


    GoblinNeeds goblinNeed;
    GameObject goblino; 

    public Action_Sleep(GameObject goblino)
    {
        this.goblino = goblino;
        goblinNeed = this.goblino.GetComponent<GoblinNeeds>();
    }
    public override void PerformAction()
    {




        GameObject Tent = GameObject.FindGameObjectWithTag("TentTag");

        goblino.GetComponent<Astar>().PathfindTo(Tent.transform.position);





        //target to the tent
        goblinNeed.Rest();





    }


}

