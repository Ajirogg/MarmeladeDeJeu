using System.Collections;
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
    
    public Animator hostageAnimator;

    private void Start()
    {
        lastStressRaise = Time.time;
        if (sonar == null)
            sonar = GameObject.FindObjectOfType<InitSonar>().GetSonar();
        sonar = GameObject.FindObjectOfType<InitSonar>().GetSonar();
    }

    private SimpleSonarShader_Object sonar;
    public void CreateRing()
    {
        sonar.StartSonarRing(transform.position, 1);
    }

    // Update is called once per frame
    private float ringCountdown = 0.8f;
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

        if (isYelling)
            ringCountdown -= Time.deltaTime;
        else
            return;

        if (ringCountdown <= 0)
        {
            ringCountdown = 0.8f;
            this.CreateRing();
        }

    }

    public void PanicRaise(int raise)
    {

        panic += raise;
        lastStressRaise = Time.time;

        if (!isYelling & panic >= maxPanic/2)
        {
            isYelling = true;
            hostageAnimator.SetBool("Yelling", isYelling);
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
            hostageAnimator.SetBool("Yelling", isYelling);
            GetGroupeOtage().subtractYelling();
        }
        if (panic < 0)
            panic = 0;
    }
    public void RandQuit()
    {
        int rand = Random.Range(1, ((100 / quitChance) + 1));
        print("Part ? = " + rand);
        if (rand == 100 / quitChance) {

            GameObject.Find("GameManager").GetComponent<GameManager>().police.augmenterEtat();
            GameObject.Find("GameManager").GetComponent<GameManager>().OtageLeave(this);
            hostageAnimator.SetBool("Escaped", true);
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            this.gameObject.GetComponent<Otage>().enabled = false;

        }
        lastStressRaise = Time.time;
    }
    public void Dying()
    {
        hostageAnimator.SetBool("Dead", true);
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        this.gameObject.GetComponent<Otage>().enabled = false;
        
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
