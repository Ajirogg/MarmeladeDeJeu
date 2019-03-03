using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerComponent : MonoBehaviour, Utilisable
{
    ScoreManager scoreManager;

    //Variable pour la gestion de l'activité
    private bool currentlyWorking;
    
    [ReadOnly] public float timeSinceLastFailure;
    [ReadOnly] public int failureCheckTickCount;
    [ReadOnly] public float timeSinceLastFailureCheck;
    public float failureCheckElapsingTime = 0.5f;
    public float minDelayBetweenFailures = 25f;
    public float maxDelayForMaxChanceOfFailure = 60f;
    public float maxChanceOfFailurePerTick = 0.15f;
    
    //Variables pour le scoring périodique
    [ReadOnly] public float timeSinceLastMiningTick;
    [ReadOnly] public int miningTickCount;
    [ReadOnly] public int currentMiningAmount;
    public float miningTickElapsingTime = 1.5f;
    public int miningBaseAmount = 1;
    public float miningGrowth = 1.015f;
    public float miningTickNumberToGrow = 4;

    public bool isTyping = false;
    private SimpleSonarShader_Parent sonar;
    public void CreateRing()
    {
        if (sonar == null)
            sonar = GameObject.FindObjectOfType<SimpleSonarShader_Parent>();
        sonar.StartSonarRing(transform.position, 1);        
    }

    /*Cycle de vie*/
    void Start()
    {
        scoreManager = ScoreManager.Instance;

        SwitchOn();

        miningTickCount = 0;
        timeSinceLastMiningTick = 0;
        timeSinceLastFailure = 0;
        failureCheckTickCount = 0;
        timeSinceLastFailureCheck = 0;
        currentMiningAmount = miningBaseAmount;
        sonar = GameObject.FindObjectOfType<SimpleSonarShader_Parent>();
    }

    private float ringCountdown = 1f;


    void Update()
    {
        if(IsCurrentlyworking())
            timeSinceLastFailure += Time.deltaTime;
        timeSinceLastMiningTick += Time.deltaTime;
        timeSinceLastFailureCheck += Time.deltaTime;

        if (timeSinceLastFailureCheck >= failureCheckElapsingTime)
            FailureCheck();
        if (timeSinceLastMiningTick >= miningTickElapsingTime)
            MineTick();

        if (!currentlyWorking)
            ringCountdown -= Time.deltaTime;
        else
            return;

        if (ringCountdown <= 0)
        {
            ringCountdown = 1f;
            this.CreateRing();
        }

    }

    /*Méthodes*/
        //Gestion de l'activité
    public bool IsCurrentlyworking()
    {
        return currentlyWorking;
    }

    public bool SwitchOn() {
        currentlyWorking = true;

        gameObject.GetComponentInChildren<Animator>().SetBool("IsWorking", IsCurrentlyworking());

        return IsCurrentlyworking();
    }

    public bool SwitchOff()
    {
        currentlyWorking = false;
        timeSinceLastFailure = 0;
        failureCheckTickCount = 0;

        gameObject.GetComponentInChildren<Animator>().SetBool("IsWorking", IsCurrentlyworking());

        return IsCurrentlyworking();
    }

    //Scoring Périodique
    private void MineTick()
    {
        timeSinceLastMiningTick = 0;

        if (!IsCurrentlyworking()) //Vérif état
            return;

        miningTickCount++;
        if (miningTickCount%miningTickNumberToGrow == 0)
            currentMiningAmount += miningBaseAmount * (int)(Mathf.Pow(miningGrowth, miningTickCount));

        scoreManager.addScore(currentMiningAmount);
    }

    //Scoring Spontané
    public void ManualMine(int indice)
    {
        if(IsCurrentlyworking()) //Vérif état
            scoreManager.addScore(currentMiningAmount * indice);
    }

    //Gestion de la "casse"
    private void FailureCheck()
    {
        timeSinceLastFailureCheck = 0;

        if (!IsCurrentlyworking())
            return;

        if (minDelayBetweenFailures > timeSinceLastFailure)
            return;

        //On éxécute le test
        failureCheckTickCount++;
        float chanceOfFailurePerTick = maxChanceOfFailurePerTick / ((maxDelayForMaxChanceOfFailure - minDelayBetweenFailures) / failureCheckElapsingTime);

        float actualChanceOfFailure = failureCheckTickCount * chanceOfFailurePerTick;

        if (actualChanceOfFailure > maxChanceOfFailurePerTick)
            actualChanceOfFailure = maxChanceOfFailurePerTick;

        float diceRoll = Random.Range(0f, 10000.0f);

        if ((diceRoll / 10000.0f) <= actualChanceOfFailure)
        {
            print(gameObject.name+ " : " +timeSinceLastFailure);
            SwitchOff();
        }
            
    }

    public bool Use() //interface implementation
    {
        isTyping = true;
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        gm.questionUI.GetComponent<QuestionManager>().readyToAnswer = true;

        if (this.IsCurrentlyworking())
            gm.questionUI.GetComponent<QuestionManager>().InitialiserQuestion(gm.laListeDesQuestions.GetRandomOrdinateur(), 1, this);
        else
            gm.questionUI.GetComponent<QuestionManager>().InitialiserQuestion(gm.laListeDesQuestions.GetRandomFixOrdinateur(), 1, this);



        return true;
    }

    public void endCall()
    {
        isTyping = false;
    }
}
