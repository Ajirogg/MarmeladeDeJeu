using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : MonoBehaviour, Utilisable
{
    public bool isRinging;
    public bool isAnswering;
    public int timeToAnswer;
    public float timeStartCall;
    public AudioClip sonnerie;
    public AudioClip allo;

    public float timeLastCall;

    public Animator telephoneAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        timeLastCall = Time.time;
        isRinging = false;
        isAnswering = false;
        timeToAnswer = Random.Range(8, 15 + 1);
        telephoneAnimator = this.GetComponentInChildren<Animator>();

        sonar = GameObject.FindObjectOfType<SimpleSonarShader_Parent>();
    }

    private SimpleSonarShader_Parent sonar;
    public void CreateRing()
    {
        if (sonar == null)
            sonar = GameObject.FindObjectOfType<SimpleSonarShader_Parent>();

        sonar.StartSonarRing(transform.position, 1);
    }
    // Update is called once per frame

    private float ringCountdown = 0.5f;
    void Update()
    {
        if (isRinging)
            ringCountdown -= Time.deltaTime;
        else
            return; 

        if (ringCountdown <=0 ){
            ringCountdown = 0.5f;
            this.CreateRing();
        }

    }

    public void StartCall()
    {
        SoundManager.instance.efxSonnerie.Play();
        
        isRinging = true;
        telephoneAnimator.SetBool("isRinging", isRinging);
        timeStartCall = Time.time;
    }

    public void ConversationBegin()
    {
        SoundManager.instance.efxSonnerie.Stop();
        SoundManager.instance.efxDialogue.clip = allo ;
        SoundManager.instance.efxDialogue.PlayDelayed(0.2f);
        isAnswering = true;
        isRinging = false;
        telephoneAnimator.SetBool("isRinging", isRinging);
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.questionUI.GetComponent<QuestionManager>().readyToAnswer = true;
        gm.questionUI.GetComponent<QuestionManager>().InitialiserQuestion(gm.laListeDesQuestions.GetRandomPolice(), 0, gm.telephone);
        // Doit appeler la fonction de discussion entre police et preneur d'otages
    }

    public void endCall()
    {
        isAnswering = false;
        isRinging = false;
        timeLastCall = Time.time;
        telephoneAnimator.SetBool("isRinging", isRinging);
        timeToAnswer = Random.Range(8, 15 + 1);
    }

    public bool Use()
    {
        if (isRinging)
        {
            ConversationBegin();
            return true;
        }

        return false;

    }
}
