using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Police police;
    public GroupeOtage gOtage1;
    public GroupeOtage gOtage2;
    public Telephone telephone;
    public ComputerComponent ordinateur;
    public Player player;
    public AudioClip tir;
    public AudioClip ambulance;

    public GameObject questionUI;
    public ListeQuestions laListeDesQuestions = new ListeQuestions();

    public float cooldownPoliceEnervement = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //questionUI = GameObject.FindGameObjectWithTag("Question");
        SoundManager.instance.musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(telephone.timeLastCall + police.GetFrequenceAppel() <= Time.time && !telephone.isRinging && !telephone.isAnswering)
        {
            telephone.StartCall();

        }


        if (Time.time >= telephone.timeToAnswer + telephone.timeStartCall && telephone.isRinging)
        {
            SoundManager.instance.efxSonnerie.Stop();
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
                //police.PrintPoliceTest();
                cooldownPoliceEnervement = 5.0f;
            }
        }

        /*if (telephone.isAnswering && !questionUI.GetComponent<QuestionManager>().readyToAnswer)
        {
            questionUI.GetComponent<QuestionManager>().readyToAnswer = true;
            questionUI.GetComponent<QuestionManager>().InitialiserQuestion(laListeDesQuestions.GetRandomPolice(),0, telephone);
        }*/

        //GAME OVER
        if (police.etatPolice == 6 || police.agressivitePolice >= 100)
        {
            int score = ScoreManager.Instance.getScore();
            float timePlayed = GameObject.Find("UI").transform.Find("ScoreCount").transform.Find("TimerPanel").transform.Find("Text").GetComponent<TimerScript>().TimeCount;
            int hostagesAlive = gOtage1.otages.Count + gOtage2.otages.Count;
            GameObject.Find("EndScreen").gameObject.GetComponent<EndGameManager>().LauchEndGame(score, timePlayed, hostagesAlive);
        }


    }

    public void appliquerReponse(int indice, Utilisable obj)
    {
        if (obj.GetType() == telephone.GetType()) {
            appliquerReponsePolice(indice);
            print("HOP la réponse est appliquée à la police");
        }
        else if (obj.GetType() == FindObjectOfType<Otage>().GetType())
        {
            appliquerReponseOtage(indice, (Otage)obj);
            print("HOP la réponse est appliquée à l'otage");
        }
        else if (obj.GetType() == gOtage1.GetType())
        {
            appliquerReponseGroupeOtage(indice, (GroupeOtage)obj);
            print("HOP la réponse est appliquée à un groupe d'otage");
        }
        else if (obj.GetType() == ordinateur.GetType())
        {
            appliquerReponseOrdinateur(indice);
            print("HOP la réponse est appliquée à un ordinateur");
        }
    }

    public void appliquerReponsePolice(int indice)
    {
        if (indice < 0)
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

            police.augmenterEtat();
            police.AugmenterAgressivite(35);
            SoundManager.instance.efxDialogue.clip = tir;
            SoundManager.instance.efxDialogue.Play();
            SoundManager.instance.efxExterieur.clip = ambulance;
            SoundManager.instance.efxExterieur.PlayDelayed(5);
            ota.GetGroupeOtage().otages.Remove(ota);
            ota.GetGroupeOtage().subtractYelling();
            ota.Dying();
            
        }
        else if (indice > 0)
        {
            ota.PanicDecrease(indice);
        }
        else
            ota.PanicRaise(-indice);


    }

    public void appliquerReponseGroupeOtage(int indice, GroupeOtage go)
    {
        foreach (Otage ots in go.otages)
        {
            if (indice > 0)
                ots.PanicDecrease(indice);
            else
                ots.PanicRaise(-indice);
        }
    }
    public void appliquerReponseOrdinateur(int indice)
    {
        if (ordinateur.IsCurrentlyworking())
        {
            if (indice > 0)
            {
                ordinateur.ManualMine(indice);
            }
        }
        else
            ordinateur.SwitchOn();

    }
    public void OtageLeave(Otage ota)
    {
        police.AugmenterAgressivite(5 * police.etatPolice);
        ota.GetGroupeOtage().otages.Remove(ota);
        ota.GetGroupeOtage().subtractYelling();
    }

}
