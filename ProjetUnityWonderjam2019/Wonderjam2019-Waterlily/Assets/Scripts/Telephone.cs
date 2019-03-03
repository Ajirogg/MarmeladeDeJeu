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
        timeToAnswer = Random.Range(10, 15 + 1);
        telephoneAnimator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCall()
    {
        SoundManager.instance.efxSonnerie.Play();
        
        isRinging = true;
        telephoneAnimator.SetBool("isRinging", isRinging);
        timeStartCall = Time.time;
        print("Gaston y a le telefon qui son");
    }

    public void ConversationBegin()
    {
        SoundManager.instance.efxSonnerie.Stop();
        SoundManager.instance.efxDialogue.clip = allo ;
        SoundManager.instance.efxDialogue.PlayDelayed(0.2f);
        isAnswering = true;
        isRinging = false;
        telephoneAnimator.SetBool("isRinging", isRinging);
        print("ALLO");
        // Doit appeler la fonction de discussion entre police et preneur d'otages
    }

    public void endCall()
    {
        timeLastCall = Time.time;
        isAnswering = false;
        isRinging = false;
        telephoneAnimator.SetBool("isRinging", isRinging);
        timeToAnswer = Random.Range(10, 15 + 1);
        print("o revoar");
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
