using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListeQuestions
{
    public List<Question> questionsPolice = new List<Question>();
    public List<Question> questionsOrdinateur = new List<Question>();
    public List<Question> questionsOtageGroupe = new List<Question>();
    public List<Question> questionsOtageIndividuel = new List<Question>();

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

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Du sang !", -100),
            new Reponse("De l'argent", 50),
            new Reponse("La paix dans le monde", -25),
            new Reponse("Le plaisir", -50),
        };

        uneQuestion = new Question("Quels sont vos revendications ?", uneListeReponses);
        questionsPolice.Add(uneQuestion);

    }

    //L'indice correspond au nombre d'argent récupéré
    private void InitialisationOrdinateur()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("S4CR4T", 5000),
            new Reponse("EXIT", -25),
        };

        Question uneQuestion = new Question("//BANK-ACCOUNT NUMBER 4861-8475// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);


        uneListeReponses = new List<Reponse>
        {
            new Reponse("1CROY4BL3", 5000),
            new Reponse("EXIT", -25),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER 1145-8445// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("DEUS VULT", 3000),
            new Reponse("EXIT", -25),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER 5789-5768// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("PASSWORD", 3000),
            new Reponse("EXIT", -25),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER 5805-6049// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

    }

    //L'indice correspond à l'effet sur la barre d'agitation des otages
    private void InitialisationOtageGroupe()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("Calmez-vous!", 25),
            new Reponse("Tirer en l'air", 50),
            new Reponse("Partir", 0)
        };

        Question uneQuestion = new Question("Que faire ?", uneListeReponses);
        questionsOtageGroupe.Add(uneQuestion);


    }

    //L'indice correspond à l'effet sur la barre d'agitation de l'otage
    // ACTION SPECIALES:
    // -666 = Tuer
    private void InitialisationOtageIndividuel()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
           new Reponse("La ferme!", 25),
            new Reponse("Le tuer", 50),
            new Reponse("Partir", 0)
        };

        Question uneQuestion = new Question("Que faire ?", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);


    }

}
