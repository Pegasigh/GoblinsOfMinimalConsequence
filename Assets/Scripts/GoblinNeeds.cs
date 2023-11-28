using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum personalities
{
    DEFAULT,
    LAZY,
    PLAYFUL,
    GLUTTON,
    EVIL,
    ENERGETIC,
    COUNT
}

public class GoblinNeeds : MonoBehaviour
{
    private double hunger;
    private double fun;
    private double energy;
    private double social;

    public float needDecay = 1;

    private personalities personality;
    
    // Start is called before the first frame update
    void Start()
    {
        //Set all Needs to 100% on creation
        hunger = 100;
        fun = 100;
        energy = 100;
        social = 100;

        //Give goblin a random personality
        personality = (personalities)Random.Range(0, (int)personalities.COUNT);

    }

    // Update is called once per frame
    void Update()
    {
        switch (personality) 
        {
            case personalities.DEFAULT:
                //Default Personality

                hunger -= 1.0 * needDecay;
                fun -= 1.0 * needDecay;
                energy -= 1.0 * needDecay;
                social -= 1.0 * needDecay;

                break;
            case personalities.LAZY:
                //Lazy Personality

                hunger -= 1.5 * needDecay;
                fun -= 0.5 * needDecay;
                energy -= 2.5 * needDecay;
                social -= 1.0 * needDecay;

                break;
            case personalities.PLAYFUL:
                //Playful Personality

                hunger -= 1.0 * needDecay;
                fun -= 2.5 * needDecay;
                energy -= 1.5 * needDecay;
                social -= 1.5 * needDecay;

                break;
            case personalities.GLUTTON:
                //Glutton Personality

                hunger -= 2.5 * needDecay;
                fun -= 1.0 * needDecay;
                energy -= 1.0 * needDecay;
                social -= 0.5 * needDecay;

                break;
            case personalities.EVIL:
                //Evil Personality

                hunger -= 1.5 * needDecay;
                fun -= 3.5 * needDecay;
                energy -= 0.1 * needDecay;
                social -= 1.0 * needDecay;

                break;
            case personalities.ENERGETIC:
                //Energenic Personality

                hunger -= 1.5 * needDecay;
                fun -= 1.0 * needDecay;
                energy -= 0.1 * needDecay;
                social -= 1.0 * needDecay;

                break;
        }
        
    }

    //These are used to fulfill the needs of each goblin
    public void Feed(int value)
    {
        hunger += value;
    }

    public void Play(int value)
    {
        fun += value;
    }
    
    public void Talk(int value)
    {
        social += value;
    }
    
    public void Rest()
    {
        energy += 50.0;
    }
}
