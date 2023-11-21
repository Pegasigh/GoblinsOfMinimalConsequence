using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinNeeds : MonoBehaviour
{
    public double hunger;
    public double fun;
    public double energy;
    public double personality = 0;

    // Start is called before the first frame update
    void Start()
    {
        hunger = 100;
        fun = 100;
        energy = 100;

        personality = Random.RandomRange(1, 6);


    }

    // Update is called once per frame
    void Update()
    {
        switch (personality) 
        {
            case 1:
                //Default Personality

                hunger -= 1.0;
                fun -= 1.0;
                energy -= 1.0;

                break;
            case 2:
                //Lazy Personality

                hunger -= 1.5;
                fun -= 0.5;
                energy -= 2.5;

                break;
            case 3:
                //Playful Personality

                hunger -= 1.0;
                fun -= 2.5;
                energy -= 1.5;

                break;
            case 4:
                //Glutton Personality

                hunger -= 2.5;
                fun -= 1.0;
                energy -= 1.0;

                break;
            case 5:
                //Evil Personality

                hunger -= 1.5;
                fun -= 3.5;
                energy -= 0.1;

                break;
            case 6:
                //Energenic Personality

                hunger -= 1.5;
                fun -= 1.0;
                energy -= 0.1;

                break;
        }
        
    }

    public void Feed()
    {
        hunger += 50.0;
    }
    public void Play()
    {
        fun += 50.0;
    }
    public void Rest()
    {
        energy += 50.0;
    }
}
