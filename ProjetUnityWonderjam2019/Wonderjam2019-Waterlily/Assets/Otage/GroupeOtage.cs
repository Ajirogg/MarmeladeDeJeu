using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupeOtage : MonoBehaviour, Utilisable
{
    public Otage otage;
    public int nbOtage = 2 ;
    public int nbYelling = 0 ;
    public List<Otage> otages = new List<Otage>();
    public int raiseYelling = 6;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
        for (int i = 0; i<nbOtage; i++) { 
            Otage ota = Instantiate(otage, new Vector3((pos.x -1 + i*2) ,pos.y,0),Quaternion.identity);
            ota.transform.parent = gameObject.transform;
            otages.Add(ota);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void addYelling()
    {
        nbYelling += 1 ;
        foreach (Otage otage in otages)
        {
            otage.maxStressRaise += raiseYelling ;
        }
    }

    public void subtractYelling()
    {
        nbYelling -= 1;
        foreach (Otage otage in otages)
        {
            otage.maxStressRaise -= raiseYelling ;
        }
    }

    public void endCall()
    {
        foreach (Otage ots in otages)
        {
            ots.talking = false;
        }
    }

    public bool Use()
    {
        foreach(Otage ots in otages)
        {
            ots.talking = true;
        }

        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        gm.questionUI.GetComponent<QuestionManager>().readyToAnswer = true;
        gm.questionUI.GetComponent<QuestionManager>().InitialiserQuestion(gm.laListeDesQuestions.GetRandomOtageGroupe(), 0, this);

        return true;
    }

}
