using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
//    [HideInInspector]
    public float hunger;
//    [HideInInspector]
    public float fun;
//    [HideInInspector]
    public float energy;
//    [HideInInspector]
    public float social;

    public float needDecayPerSec;
    
    [HideInInspector]
    public personalities personality;
    
    // Start is called before the first frame update
    void Start()
    {
        //Set all Needs to 100% on creation
        //hunger = 100.0f;
        //fun = 100.0f;
        //energy = 100.0f;
        //social = 100.0f;

        //Give goblin a random personality
        personality = (personalities)Random.Range(0, (int)personalities.COUNT);

    }

    // Update is called once per frame
    void Update()
    {
        switch (personality) 
        {
            case personalities.EVIL:
                hunger -= 1.0f * needDecayPerSec * Time.deltaTime;
                fun -= 1.0f * needDecayPerSec * Time.deltaTime;
                energy -= 1.0f * needDecayPerSec * Time.deltaTime;
                social -= 1.0f * needDecayPerSec * Time.deltaTime;
                break;

            case personalities.FRIENDLY:
                hunger -= 1.0f * needDecayPerSec * Time.deltaTime;
                fun -= 1.0f * needDecayPerSec * Time.deltaTime;
                energy -= 1.0f * needDecayPerSec * Time.deltaTime;
                social -= 1.5f * needDecayPerSec * Time.deltaTime;
                break;

            case personalities.LAZY:
                hunger -= 1.0f * needDecayPerSec * Time.deltaTime;
                fun -= 1.0f * needDecayPerSec * Time.deltaTime;
                energy -= 1.5f * needDecayPerSec * Time.deltaTime;
                social -= 1.0f * needDecayPerSec * Time.deltaTime;
                break;

            case personalities.SLOB:
                hunger -= 1.5f * needDecayPerSec * Time.deltaTime;
                fun -= 1.0f * needDecayPerSec * Time.deltaTime;
                energy -= 1.0f * needDecayPerSec * Time.deltaTime;
                social -= 1.0f * needDecayPerSec * Time.deltaTime;
                break;

            case personalities.PRODUCTIVE:
                hunger -= 1.0f * needDecayPerSec * Time.deltaTime;
                fun -= 1.0f * needDecayPerSec * Time.deltaTime;
                energy -= 1.0f * needDecayPerSec * Time.deltaTime;
                social -= 1.0f * needDecayPerSec * Time.deltaTime;
                break;

            case personalities.PLAYFUL:
                hunger -= 1.0f * needDecayPerSec * Time.deltaTime;
                fun -= 1.0f * needDecayPerSec * Time.deltaTime;
                energy -= 1.0f * needDecayPerSec * Time.deltaTime;
                social -= 1.0f * needDecayPerSec * Time.deltaTime;
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
