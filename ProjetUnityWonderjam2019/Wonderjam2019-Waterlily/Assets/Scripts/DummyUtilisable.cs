using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyUtilisable : Utilisable
{
    public override void Use()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.tag = "Utilisable";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
