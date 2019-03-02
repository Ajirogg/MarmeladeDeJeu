using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otage : MonoBehaviour
{
    public int panic = 0 ;
    public float stressPeriod = 5;
    private float lastStressRaise ;
    public bool isYelling = false;
    public int quitChance = 20;
    public int maxStressRaise = 5;

    private void Start()
    {
        lastStressRaise = Time.time ;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastStressRaise + stressPeriod <= Time.time) { 
            if (panic < 100)
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
        
        if (! isYelling & panic >= 50)
            isYelling = true ;

        if (panic > 100)
            panic = 100;
        
    }
    public void PanicDecrease(int decrease)
    {
        panic -= decrease ;
        if (isYelling & panic < 50)
            isYelling = false;
    }
    public void RandQuit()
    {
        int rand = Random.Range(1, ((100 / quitChance) + 1));
        print("Part ? = " + rand);
        if (rand == 100 / quitChance)
            Destroy(this.gameObject);
        lastStressRaise = Time.time;
    }
}
