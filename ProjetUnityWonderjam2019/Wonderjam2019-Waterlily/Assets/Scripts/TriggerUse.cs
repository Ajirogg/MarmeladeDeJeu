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
        //SetYellow(u);
        if (u.GetComponentInChildren<SpriteRenderer>() != null) //Recupere le GO où il y a le sprite
            u = u.GetComponentInChildren<SpriteRenderer>().gameObject;


        if (u.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
        {
            u.gameObject.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = true;
            SetYellow(u);


        }
        else
        {
            SpriteGlow.SpriteGlowEffect n = u.gameObject.AddComponent<SpriteGlow.SpriteGlowEffect>();
            n.GlowBrightness = 1.38f;
            SetYellow(u);
        }
    }

    void Glow(GroupeOtage u)
    {
        foreach(Otage o in u.otages)
        {
                Glow(o.gameObject);
        }
    }

    private void SetYellow(GameObject o)
    {
        if(o.GetComponent<SpriteRenderer>() != null)
            o.GetComponent<SpriteRenderer>().color = Color.yellow;
        if (o.GetComponentInChildren<SpriteRenderer>() != null)
            o.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
    }

    private void SetWhite(GameObject o)
    {
        if (o.GetComponent<SpriteRenderer>() != null)
            o.GetComponent<SpriteRenderer>().color = Color.white;
        if (o.GetComponentInChildren<SpriteRenderer>() != null)
            o.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    public void unGlowAll(HashSet<GameObject> set = null)
    {
        if (set == null)
            set = ObjetsUtilisables;

        var b = GameObject.FindObjectsOfType<MonoBehaviour>();

        foreach(MonoBehaviour ob in b)
        {
            if (ob.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
            {
                SetWhite(ob.gameObject);
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

        SetWhite(go);
        if (go.GetComponent<SpriteGlow.SpriteGlowEffect>() != null)
        {
            go.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.GetComponent<Utilisable>() != null)
        {
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
