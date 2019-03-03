using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyUtilisable : MonoBehaviour, Utilisable
{   

    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.tag = "Utilisable";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool Utilisable.Use()
    {
        throw new System.NotImplementedException();
        return false;
    }

    public void endCall()
    {
        throw new System.NotImplementedException();
    }
}
