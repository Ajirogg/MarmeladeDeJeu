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

    private HashSet<Utilisable> ObjetsUtilisables = new HashSet<Utilisable>();

    public HashSet<Utilisable> GetObjetsUtilisablesInTrigger()
    {
        return ObjetsUtilisables;
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {

            
            if (collider.gameObject.tag == "Utilisable")
            {
                
                ObjetsUtilisables.Add(collider.gameObject.GetComponent<Utilisable>());
            }
    
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Utilisable")
        {

            ObjetsUtilisables.Remove(collider.gameObject.GetComponent<Utilisable>());
        }
    }  
}
