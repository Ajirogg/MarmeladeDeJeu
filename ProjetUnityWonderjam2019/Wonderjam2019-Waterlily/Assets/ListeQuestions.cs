using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListeQuestions
{
    public List<Question> questionsPolice = new List<Question>();
    public List<Question> questionsOrdinateur = new List<Question>();
    public List<Question> questionsOtageGroupe = new List<Question>();
    public List<Question> questionsOtageIndividuel = new List<Question>();
    public List<Question> questionsFixOrdinateur = new List<Question>();

    public ListeQuestions()
    {
        Initialisation();
    }

    private void Initialisation()
    {

        InitialisationPolice();
        InitialisationOrdinateur();
        InitialisationOtageGroupe();
        InitialisationOtageIndividuel();
        InitialisationFixOrdinateur();
    }

    public Question GetRandomPolice()
    {
        return questionsPolice[Random.Range(0, questionsPolice.Count)];
    }

    public Question GetRandomOrdinateur()
    {
        return questionsOrdinateur[Random.Range(0, questionsOrdinateur.Count)];
    }

    public Question GetRandomOtageGroupe()
    {
        return questionsOtageGroupe[Random.Range(0, questionsOtageGroupe.Count)];
    }

    public Question GetRandomOtageIndividuel()
    {
        return questionsOtageIndividuel[Random.Range(0, questionsOtageIndividuel.Count)];
    }

    public Question GetRandomFixOrdinateur()
    {
        return questionsFixOrdinateur[Random.Range(0, questionsFixOrdinateur.Count)];
    }

    //L'indice correspond à l'effet sur la barre de la police
    private void InitialisationPolice()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("Oui", 50),
            new Reponse("Peut-etre", -25),
            new Reponse("Non", -50),
            new Reponse("Quels otages?", -100),
        };

        Question uneQuestion = new Question("Est-ce que les otages vont bien ?", uneListeReponses);
        questionsPolice.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Carrement", 50),
            new Reponse("Je crois", -25),
            new Reponse("Bof", -50),
            new Reponse("Les quoi?", -100),
        };

        uneQuestion = new Question("Est-ce que les otages vont bien ?", uneListeReponses);
        questionsPolice.Add(uneQuestion);


    }

    //L'indice correspond au nombre d'argent récupéré
    private void InitialisationOrdinateur()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("S4CR4T", 5),
        };

        Question uneQuestion = new Question("//BANK-ACCOUNT NUMBER 4861-8475// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);


        uneListeReponses = new List<Reponse>
        {
            new Reponse("Reponse", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER 1145-8445// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);


    }

    //L'indice correspond à l'effet sur la barre d'agitation des otages
    private void InitialisationOtageGroupe()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("Calmez-vous!", 50),
            new Reponse("Peut-etre", -25),
            new Reponse("Non", -50),
            new Reponse("GROUPE D'OTAGE", -100),
        };

        Question uneQuestion = new Question("Est-ce que les otages vont bien ?", uneListeReponses);
        questionsOtageGroupe.Add(uneQuestion);


    }

    //L'indice correspond à l'effet sur la barre d'agitation de l'otage
    // ACTION SPECIALES:
    // -666 = Tuer
    private void InitialisationOtageIndividuel()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("Calmez-vous", 50),
            new Reponse("Peut-etre", -25),
            new Reponse("Non", -50),
            new Reponse("Meurs", 666),
        };

        Question uneQuestion = new Question("Est-ce que les otages vont bien ?", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);


    }

    //L'indice correspond au nombre d'argent récupéré
    private void InitialisationFixOrdinateur()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("Hello World", 1),
        };

        Question uneQuestion = new Question("Avez-vous essayé de redémarrer votre box.", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);


        uneListeReponses = new List<Reponse>
        {
            new Reponse("alt + f4", 1),
        };

        uneQuestion = new Question("This computer is broken.", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);


    }

}
