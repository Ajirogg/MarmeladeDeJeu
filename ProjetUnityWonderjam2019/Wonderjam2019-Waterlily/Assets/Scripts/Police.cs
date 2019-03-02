using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{

    private int etatPolice;         // Enum de l'etat de la police de 1 à 5
    private int barreEtatPolice;    // Barre progressante permettant le changement d'état de 0 à 50
    private int agressivitePolice;  // Barre de progression de l'agressivité de la police 100 = défaite



    // Start is called before the first frame update
    void Start()
    {
        etatPolice = 1;
        barreEtatPolice = 0;
        agressivitePolice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            AugmenterAgressivite(10);
            AugmenterBarreEtat(5);
            Debug.Log(agressivitePolice);
            Debug.Log(barreEtatPolice);
            Debug.Log(etatPolice);


        }
        else if (Input.GetKeyDown("e"))
        {
            DiminuerAgressivite(10);
            DiminuerBarreEtat(5);
            Debug.Log(agressivitePolice);
            Debug.Log(barreEtatPolice);
            Debug.Log(etatPolice);

        }
    }

    public void AugmenterAgressivite(int value)
    {
        agressivitePolice += value;
        if (agressivitePolice > 100)
            agressivitePolice = 100;
    }

    public void DiminuerAgressivite(int value)
    {
        agressivitePolice -= value;
        if (agressivitePolice < 0)
            agressivitePolice = 0;
    }

    public void AugmenterBarreEtat(int value)
    {
        barreEtatPolice += value;
        if (barreEtatPolice == etatPolice * 10 && etatPolice <5)
            etatPolice++;
    }

    public void DiminuerBarreEtat(int value)
    {
        barreEtatPolice -= value;
        if (barreEtatPolice < 0)
            barreEtatPolice = 0;
    }



}
