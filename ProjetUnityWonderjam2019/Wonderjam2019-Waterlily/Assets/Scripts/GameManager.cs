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

    public GameObject questionUI;
    public ListeQuestions laListeDesQuestions = new ListeQuestions();

    public float cooldownPoliceEnervement = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //questionUI = GameObject.FindGameObjectWithTag("Question");
        
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


        if(telephone.timeLastCall + /*police.GetFrequenceAppel()*/ 10 <= Time.time && !telephone.isRinging && !telephone.isAnswering)
        {
            telephone.StartCall();
            
        }
               

        if (Time.time >= telephone.timeToAnswer + telephone.timeStartCall && telephone.isRinging)
        {
            
            telephone.endCall();
            police.AugmenterAgressivite(25);
            police.augmenterEtat();
            print("enervement maximal");
            print(telephone.isRinging);
            cooldownPoliceEnervement = 5.0f;
        }


        if (!telephone.isAnswering)
        {
            cooldownPoliceEnervement -= Time.deltaTime;
            if(cooldownPoliceEnervement <= 0)
            {
                police.AugmenterAgressivite(police.etatPolice);
                print("enervement");
                police.PrintPoliceTest();
                cooldownPoliceEnervement = 5.0f;
            }
        }

        if (telephone.isAnswering && !questionUI.GetComponent<QuestionManager>().readyToAnswer)
        {
            questionUI.GetComponent<QuestionManager>().readyToAnswer = true;
            questionUI.GetComponent<QuestionManager>().InitialiserQuestion(laListeDesQuestions.GetRandomPolice(),0, telephone);
        }

        //GAME OVER
        if (police.etatPolice == 6 || police.agressivitePolice >= 100)
        {
            throw new System.Exception("GAME OVER");
        }


    }

    public void appliquerReponse(int indice)
    {
        if(indice < 0)
        {
            indice = indice * (25 * police.etatPolice) / 100;
        }
        else
        {
            indice = indice * (25 * (6 - police.etatPolice)) / 100;
            
        }

        police.AugmenterAgressivite(-indice);

        print(police.agressivitePolice);
    }

    public void appliquerReponseOtage(int indice, Otage ota)
    {
        if (indice == 666)
        {
            foreach (Otage ots in ota.GetGroupeOtage().otages)
            {
                ots.PanicDecrease(150);
            }
            OtageLeave(ota);
        }
        else
            ota.PanicDecrease(-indice);
        
    }

    public void OtageLeave(Otage ota)
    {
        police.AugmenterAgressivite(5 * police.etatPolice);
        print("L'otage est parti de jhonny haliday ");
        ota.GetGroupeOtage().otages.Remove(ota);
        Destroy(ota);
    }

}