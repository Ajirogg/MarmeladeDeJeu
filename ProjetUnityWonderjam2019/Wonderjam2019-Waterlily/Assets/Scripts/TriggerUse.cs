using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerUse : MonoBehaviour
{
    private GameObject curFirst;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print(FirstObject());
    }

    private HashSet<GameObject> objetsUtilisables = new HashSet<GameObject>();

    public HashSet<GameObject> ObjetsUtilisables { get => objetsUtilisables; set => objetsUtilisables = value; }

    public  GameObject FirstObject()
    {
        unGlowAll(ObjetsUtilisables);
        if (ObjetsUtilisables.Count == 0)
            return null;

        GameObject toReturn = ObjetsUtilisables.ToList()[0];
        foreach (GameObject ob in ObjetsUtilisables)
        {
            if (ob.GetComponent<GroupeOtage>() != null)
                toReturn = ob;
            else if (ob.GetComponent<Otage>() != null)
            {
                Glow(ob);
                return ob;
            }

        }
        Glow(toReturn);
        return toReturn;
    }



    void Glow(GameObject u)
    {
        if (u.GetComponent<GroupeOtage>() != null)
        {
            Glow(u.GetComponent<GroupeOtage>());
            return;
        }

        if (u.GetComponentInChildren<SpriteRenderer>() != null) //Recupere le GO où il y a le sprite
            u = u.GetComponentInChildren<SpriteRenderer>().gameObject;


        if (u.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
        {
            u.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = true;
        }
        else
        {
            SpriteGlow.SpriteGlowEffect n = u.gameObject.AddComponent<SpriteGlow.SpriteGlowEffect>();
            n.GlowBrightness = 1.38f;
        }
    }

    void Glow(GroupeOtage u)
    {
        foreach(Otage o in u.otages)
        {
            if(!o.hostageAnimator.GetBool("Died"))
                Glow(o.gameObject);
        }
    }


    void unGlowAll(HashSet<GameObject> set)
    {
        var b = GameObject.FindObjectsOfType<MonoBehaviour>();

        foreach(MonoBehaviour ob in b)
        {
            if (ob.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
            {
                ob.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = false;
            }
        }
    }

    void unGlow(GameObject go)
    {
        if (go.GetComponent<GroupeOtage>() != null)
        {
            unGlowAll(ObjetsUtilisables);
            return;
        }

        if (go.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
        {
            go.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.GetComponent<Utilisable>() != null)
        {
            if (collider.gameObject.GetComponent<Otage>() != null && collider.gameObject.GetComponent<Otage>().hostageAnimator.GetBool("Died") == true)
                return;

            ObjetsUtilisables.Add(collider.gameObject);
            curFirst = FirstObject();
        }
    }


    void PrintObjects()
    {
        foreach(GameObject o in ObjetsUtilisables)
        {
            print(o);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.GetComponent<Utilisable>() != null){
            ObjetsUtilisables.Remove(collider.gameObject);
            curFirst = FirstObject();
        }



    }
}
