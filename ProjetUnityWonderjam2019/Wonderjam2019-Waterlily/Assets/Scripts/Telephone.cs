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
<<<<<<< HEAD

=======
        
>>>>>>> parent of c5770e6... Telephone et boucle d'appel
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

<<<<<<< HEAD
    public void endCall()
    {
        isRinging = false;
        timeToAnswer = Random.Range(10, 15 + 1);
        print("o revoar fdp");
    }

    public void Use()
=======
    public override void Use()
>>>>>>> parent of c5770e6... Telephone et boucle d'appel
    {
        throw new System.NotImplementedException();
    }
}
