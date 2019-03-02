using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private HashSet<GameObject> objetsUtilisables = new HashSet<GameObject>();

    public HashSet<GameObject> ObjetsUtilisables { get => objetsUtilisables; set => objetsUtilisables = value; }

    private void OnTriggerEnter2D(Collider2D collider)
    {

            
            if (collider.gameObject.GetComponent<Utilisable>() != null)
            {
                
                ObjetsUtilisables.Add(collider.gameObject);
            }
           
    
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Utilisable>() != null)
        {
            ObjetsUtilisables.Remove(collider.gameObject);
        }
    }  
}
