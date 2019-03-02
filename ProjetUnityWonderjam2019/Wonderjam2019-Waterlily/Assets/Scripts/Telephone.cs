using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : MonoBehaviour, Utilisable
{
    public bool isRinging;

    // Start is called before the first frame update
    void Start()
    {
        isRinging = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCall()
    {
        isRinging = true;
    }

    public void ConversationBegin()
    {
        isRinging = false;
        // Doit appeler la fonction de discussion entre police et preneur d'otages
    }

    public void Use() //Interface implementation
    {
        throw new System.NotImplementedException();
    }
}
