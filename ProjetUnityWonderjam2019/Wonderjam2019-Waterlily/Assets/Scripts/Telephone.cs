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

    private SimpleSonarShader_Object[] sonar;
    // Start is called before the first frame update
    void Start()
    {
        timeLastCall = Time.time;
        isRinging = false;
        isAnswering = false;
        timeToAnswer = Random.Range(5, 10 + 1);
        telephoneAnimator = this.GetComponentInChildren<Animator>();
        sonar = GameObject.FindObjectsOfType<SimpleSonarShader_Object>();
    }

    public void CreateRing()
    {
        foreach (SimpleSonarShader_Object o in sonar)
        {
            o.StartSonarRing(transform.position, 1);
        }
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
        // Doit appeler la fonction de discussion entre police et preneur d'otages
    }

    public void endCall()
    {
        timeLastCall = Time.time;
        isAnswering = false;
        isRinging = false;
        telephoneAnimator.SetBool("isRinging", isRinging);
        timeToAnswer = Random.Range(5, 10 + 1);
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
