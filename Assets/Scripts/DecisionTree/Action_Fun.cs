
using UnityEngine;

public class Action_Fun : Action
{

    //Can add more functions into these, one for kill one for dance one ofr game and the perform action just randomly selects one. 
    public override void PerformAction()
    {
        // Randomly pick between Dance and Game

        int funActNum = Random.Range(0, 1); //Randomly selects a number between a min and max range

        if (funActNum == 0)
        {
            ActionGame();
        }
        if (funActNum == 1) 
        {
            ActionDance();
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


}

