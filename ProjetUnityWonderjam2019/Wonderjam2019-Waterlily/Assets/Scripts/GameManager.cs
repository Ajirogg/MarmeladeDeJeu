using System.Collections;
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

    public float cooldownPoliceEnervement = 5.0f;
    public float tempsAvantAppel;

    // Start is called before the first frame update
    void Start()
    {
        tempsAvantAppel = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            police.AugmenterAgressivite(10);
            police.PrintPoliceTest();


        }
        else if (Input.GetKeyDown("r"))
        {
            police.DiminuerAgressivite(10);
            police.PrintPoliceTest();
        }


        if(tempsAvantAppel + /*police.GetFrequenceAppel()*/ 10 <= Time.time && !telephone.isRinging)
        {
            telephone.StartCall();
        }
               

        if (Time.time >= telephone.timeToAnswer + telephone.timeStartCall && telephone.isRinging)
        {
            telephone.endCall();
            police.AugmenterAgressivite(25);
            print("enervement maximal");
            print(telephone.isRinging);
            cooldownPoliceEnervement = 5.0f;
            tempsAvantAppel = Time.time;

        }


        if (telephone.isRinging)
        {
            cooldownPoliceEnervement -= Time.deltaTime;
            if(cooldownPoliceEnervement <= 0)
            {
                police.AugmenterAgressivite(1);
                print("enervement + 1");
                police.PrintPoliceTest();
                cooldownPoliceEnervement = 5.0f;
            }
        }



    }
}