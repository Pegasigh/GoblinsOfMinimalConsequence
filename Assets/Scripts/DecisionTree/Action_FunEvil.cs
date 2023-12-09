
using System.Collections;
using UnityEngine;
public class Action_FunEvil : Action
{
    //Can add more functions into these, one for kill one for dance one ofr game and the perform action just randomly selects one. 


    GoblinNeeds goblinNeed;
    GameObject goblino;

    public Action_FunEvil(GameObject goblino)
    {
        this.goblino = goblino;
        goblinNeed = this.goblino.GetComponent<GoblinNeeds>();
    }
    public override IEnumerator PerformAction()
    {
        // Randomly pick between Dance and Game

        int funActNum = Random.Range(0, 1); //Randomly selects a number between a min and max range

        if (funActNum == 0)
        {
            yield return ActionDance();
        }
        if (funActNum == 1)
        {
            yield return ActionKILL();
        }


    }

    public IEnumerator ActionDance()
    {
        //target campfire


        Debug.Log("Start Wait Time");
        yield return new WaitForSeconds(3);
        Debug.Log("End Wait Time");

        goblinNeed.Play(15);
    }

    public IEnumerator ActionKILL()
    {
        Debug.Log("Start Wait Time");
        yield return null; //doesn't wait
        Debug.Log("End Wait Time");

        goblinNeed.Play(20);
        //If this is picked, target closest goblin, get up to them, upon touching, DESTROY OTHER GOBLIN
    }

}
