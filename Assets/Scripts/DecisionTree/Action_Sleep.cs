
using System.Collections;
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

        Debug.Log("SCHLUMBER TIME :)  (Slumber Action Being Performed)");


        GameObject Tent = GameObject.FindGameObjectWithTag("TentTag");

        goblino.GetComponent<Astar>().PathfindTo(Tent.transform.position);



        Debug.Log("Start Wait Time");

       new WaitForSeconds(7);

        Debug.Log("End Wait Time");

        //goblino.GetComponent<DecisionTree>().targetPos.position = Tent.transform.position;
        //    goblino.GetComponent<Astar>().PathfindTo(goblino.GetComponent<DecisionTree>().targetPos.position);



        //target to the tent
        goblinNeed.Rest();





    }


}

