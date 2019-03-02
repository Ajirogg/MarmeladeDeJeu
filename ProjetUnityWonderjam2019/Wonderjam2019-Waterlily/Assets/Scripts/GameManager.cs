﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Police police;
    public GroupeOtage gOtage1;
    public GroupeOtage gOtage2;
    public GroupeOtage gOtage3;
    public Telephone telephone;
    public Player player;

    public float tempsAvantAppel;

    // Start is called before the first frame update
    void Start()
    {
        tempsAvantAppel = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            police.AugmenterAgressivite(10);
            police.PrintPoliceTest();


        }
        else if (Input.GetKeyDown("e"))
        {
            police.DiminuerAgressivite(10);
            police.PrintPoliceTest();
        }

        if(tempsAvantAppel + /*police.GetFrequenceAppel()*/ 10 <= Time.time && !telephone.isRinging)
        {
            telephone.StartCall();
        }

       // if (tempsAvantAppel + /*police.GetFrequenceAppel()*/ 13 <= Time.time)
       // {
       //     telephone.ConversationBegin();
       // }

      //  if (tempsAvantAppel + /*police.GetFrequenceAppel()*/ 16 <= Time.time)
       // {
       //     telephone.endCall();
      //      tempsAvantAppel = Time.time;
       // }

        if (Time.time >= telephone.timeToAnswer + telephone.timeStartCall && telephone.isRinging)
        {
            telephone.endCall();
            police.AugmenterAgressivite(25);
            police.PrintPoliceTest();
        }



    }
}