using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : Utilisable
{
    public bool isRinging;
    public int timeToAnswer;
    public float timeStartCall;

    // Start is called before the first frame update
    void Start()
    {
        isRinging = false;
        timeToAnswer = Random.Range(10, 15 + 1);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void StartCall()
    {
        isRinging = true;
        timeStartCall = Time.time;
        print("Gaston y a le telefon qui son");
    }

    public void ConversationBegin()
    {
        isRinging = false;
        print("ALLO");
        // Doit appeler la fonction de discussion entre police et preneur d'otages
    }

    public void endCall()
    {
        isRinging = false;
        timeToAnswer = Random.Range(10, 15 + 1);
        print("o revoar fdp");
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
