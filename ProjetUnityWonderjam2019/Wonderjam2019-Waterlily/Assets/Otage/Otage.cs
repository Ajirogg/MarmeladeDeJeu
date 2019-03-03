﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otage : MonoBehaviour, Utilisable
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
            if (panic < maxPanic) { 
                int raise = Random.Range(1, maxStressRaise + 1);
                PanicRaise(raise);
            }
            else 
            {
                RandQuit();
            }
        }
    }

    public void PanicRaise(int raise)
    {
        
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
        if (isYelling & panic < maxPanic/2) { 
            isYelling = false;
            GetGroupeOtage().subtractYelling();
        }
    }
    public void RandQuit()
    {
        int rand = Random.Range(1, ((100 / quitChance) + 1));
        print("Part ? = " + rand);
        if (rand == 100 / quitChance) {

            GameObject.Find("GameManager").GetComponent<GameManager>().OtageLeave(this);
            Destroy(this.gameObject);

            
        }
        lastStressRaise = Time.time;
    }
    public bool Use() //interface implementation
    {

        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        gm.questionUI.GetComponent<QuestionManager>().readyToAnswer = true;
        gm.questionUI.GetComponent<QuestionManager>().InitialiserQuestion(gm.laListeDesQuestions.GetRandomOtageIndividuel(), 0, this);

        return true;
    }

    public void endCall()
    {
        talking = false;
    }

    public GroupeOtage GetGroupeOtage()
    {
        GroupeOtage gro = this.GetComponentInParent<GroupeOtage>();
        return gro;
    }
        
}
