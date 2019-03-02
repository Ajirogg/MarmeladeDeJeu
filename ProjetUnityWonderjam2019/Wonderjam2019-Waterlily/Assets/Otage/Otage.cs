using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otage : Utilisable
{
    public int panic = 0 ;
    public float stressPeriod = 5;
    private float lastStressRaise ;
    public bool isYelling = false;
    public int quitChance = 20;
    public int maxStressRaise = 10;
    public int maxPanic = 200;
    public bool talking = false;

    private void Start()
    {
        lastStressRaise = Time.time ;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastStressRaise + stressPeriod <= Time.time && !talking) { 
            if (panic < maxPanic)
                PanicRaise();
            else 
            {
                RandQuit();
            }
        }
    }

    public void PanicRaise()
    {
        int raise = Random.Range(1, maxStressRaise + 1);
        print("Augementation + " + raise);
        panic += raise;
        lastStressRaise = Time.time;

        if (!isYelling & panic >= maxPanic/2)
        {
            isYelling = true;
            GetComponentInParent<GroupeOtage>().addYelling();
        }

        if (panic > maxPanic)
            panic = maxPanic;
        
    }
    public void PanicDecrease(int decrease)
    {
        panic -= decrease ;
        if (isYelling & panic < maxPanic/2)
            isYelling = false;
    }
    public void RandQuit()
    {
        int rand = Random.Range(1, ((100 / quitChance) + 1));
        print("Part ? = " + rand);
        if (rand == 100 / quitChance) { 
            Destroy(this.gameObject);
            GetComponentInParent<GroupeOtage>().nbOtage -=1 ;
        }
        lastStressRaise = Time.time;
    }
    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
