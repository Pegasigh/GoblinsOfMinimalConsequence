
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
    public override IEnumerator PerformAction()
    {
        Debug.Log("SCHLUMBER TIME :)  (Slumber Action Being Performed)");


        GameObject Tent = GameObject.FindGameObjectWithTag("TentTag");

        goblino.GetComponent<Astar>().PathfindTo(Tent.transform.position + Vector3.left);
        Debug.Log(Tent.transform.position);

        //when we reach the location:
     

      //  goblino.GetComponent<Astar>().PathfindTo(Tent.transform.position + Vector3.down);
       



        while (!goblino.GetComponent<Astar>().IsAtDestination()) yield return null;
        Debug.Log("ON the way");



        //waiting
        yield return new WaitForSeconds(1);
        
        Debug.Log("Resting");
        Debug.Log("Goblin Need Energy: " + goblinNeed.energy);
        goblinNeed.Rest();

        
    }
}

