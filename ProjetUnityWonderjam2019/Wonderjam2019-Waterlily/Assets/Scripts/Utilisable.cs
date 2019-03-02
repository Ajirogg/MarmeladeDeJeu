using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Utilisable : MonoBehaviour
{
    private void Awake()
    {
        gameObject.tag = "Utilisable";
        
    }
    public abstract void Use();
}
