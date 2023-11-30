using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum personalities
{
    EVIL,
    FRIENDLY,
    LAZY,
    SLOB,
    PRODUCTIVE,
    PLAYFUL,
    COUNT
}

public class GoblinNeeds : MonoBehaviour
{
    public float hunger;
    public float fun;
    public float energy;
    public float social;

    public float needDecay = 1;

    public personalities personality;
    
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
            case personalities.EVIL:
                hunger -= 1.0f * needDecay;
                fun -= 1.0f * needDecay;
                energy -= 1.0f * needDecay;
                social -= 1.0f * needDecay;
                break;

            case personalities.FRIENDLY:
                hunger -= 1.0f * needDecay;
                fun -= 1.0f * needDecay;
                energy -= 1.0f * needDecay;
                social -= 1.5f * needDecay;
                break;

            case personalities.LAZY:
                hunger -= 1.0f * needDecay;
                fun -= 1.0f * needDecay;
                energy -= 1.5f * needDecay;
                social -= 1.0f * needDecay;
                break;

            case personalities.SLOB:
                hunger -= 1.5f * needDecay;
                fun -= 1.0f * needDecay;
                energy -= 1.0f * needDecay;
                social -= 1.0f * needDecay;
                break;

            case personalities.PRODUCTIVE:
                hunger -= 1.0f * needDecay;
                fun -= 1.0f * needDecay;
                energy -= 1.0f * needDecay;
                social -= 1.0f * needDecay;
                break;

            case personalities.PLAYFUL:
                hunger -= 1.0f * needDecay;
                fun -= 1.0f * needDecay;
                energy -= 1.0f * needDecay;
                social -= 1.0f * needDecay;
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
        energy += 50.0f;
    }
}
