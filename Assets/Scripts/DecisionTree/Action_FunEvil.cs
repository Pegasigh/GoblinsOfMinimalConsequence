
using UnityEngine;
public class Action_FunEvil : Action
{
    //Can add more functions into these, one for kill one for dance one ofr game and the perform action just randomly selects one. 

    public override void PerformAction()
    {
        // Randomly pick between Dance and Game

        int funActNum = Random.Range(0, 2); //Randomly selects a number between a min and max range

        if (funActNum == 0)
        {
            ActionGame();
        }
        if (funActNum == 1)
        {
            ActionDance();
        }
        if (funActNum == 2)
        {
            ActionKILL();
        }


    }

    public void ActionGame()
    {
        //target closest idle goblin. 
    }

    public void ActionDance()
    {
        //target campfire
    }

    public void ActionKILL()
    {
        //If this is picked, target closest goblin, get up to them, upon touching, DESTROY OTHER GOBLIN
    }


}
