using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public  GameObject FirstObject()
    {
        GameObject toReturn = ObjetsUtilisables.ToList()[0];
        foreach (GameObject ob in objetsUtilisables)
        {            
            if (ob.GetComponent<GroupeOtage>() != null)
                toReturn = ob;
            else if (ob.GetComponent<Otage>() != null)
                return ob;
        }
        return toReturn;
    } 

    private void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.gameObject.GetComponent<Utilisable>() != null)
        {

            ObjetsUtilisables.Add(collider.gameObject);

            if (collider.gameObject != FirstObject()) {
                if (collider.gameObject.GetComponent<GroupeOtage>() == null)
                    return;

                foreach(Otage o in collider.gameObject.GetComponent<GroupeOtage>().otages) //Glow all hostages
                {
                    if (o.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
                    {
                        o.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = true;
                    }
                    else
                    {
                        SpriteGlow.SpriteGlowEffect n = o.gameObject.AddComponent<SpriteGlow.SpriteGlowEffect>();
                        n.GlowBrightness = 1.38f;
                    }
                }
                    
            }
            // Maybe improve that ?
                

            if (collider.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
            {
                collider.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = true;
            }
            else
            {
                SpriteGlow.SpriteGlowEffect n= collider.gameObject.AddComponent<SpriteGlow.SpriteGlowEffect>();
                n.GlowBrightness = 1.38f;
            }
        }
    
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Utilisable>() != null)
        {
            ObjetsUtilisables.Remove(collider.gameObject);

            if(collider.gameObject.GetComponent<GroupeOtage>()!= null)
            {
                foreach (Otage o in collider.gameObject.GetComponent<GroupeOtage>().otages) //Glow all hostages
                {
                    if (o.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
                    {
                        o.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = false;
                    }
                }
            }

            if (collider.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
            {
                collider.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = false;
            }
        }
    }  
}
