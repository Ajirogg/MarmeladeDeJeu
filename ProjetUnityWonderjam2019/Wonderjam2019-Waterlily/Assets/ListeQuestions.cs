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
            new Reponse("Oui", 5),
            new Reponse("Peut-etre", -5),
            new Reponse("Non", -10),
            new Reponse("Quels otages?", -20),
        };

        Question uneQuestion = new Question(" ''Est-ce que les otages vont bien ?''", uneListeReponses);
        questionsPolice.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Carrement", 5),
            new Reponse("Je crois", -10),
            new Reponse("Bof", -10),
            new Reponse("Les quoi?", -20),
        };
        uneQuestion = new Question(" ''Est-ce que les otages vont bien ?''", uneListeReponses);
        questionsPolice.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Ouais", 5),
            new Reponse("Euuuh", -5),
            new Reponse("Bof", -10),
            new Reponse("Le mort?", -20),
        };
        uneQuestion = new Question(" ''Est-ce que les otages vont bien ?''", uneListeReponses);
        questionsPolice.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Affirmatif", 5),
            new Reponse("Hein", -5),
            new Reponse("Negatif", -10),
            new Reponse("Mort.", -20),
        };
        uneQuestion = new Question(" ''Est-ce que les otages vont bien ?''", uneListeReponses);
        questionsPolice.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Effectivement", 5),
            new Reponse("Ben...", -5),
            new Reponse("Nan", -10),
            new Reponse("Mort.", -20),
        };
        uneQuestion = new Question(" ''Est-ce que les otages vont bien ?''", uneListeReponses);
        questionsPolice.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Pour l'instant", 5),
            new Reponse("Pas le temps", -5),
            new Reponse("...", -20),
            new Reponse("B...ien?.", -10),
        };
        uneQuestion = new Question(" ''Est-ce que les otages vont bien ?''", uneListeReponses);
        questionsPolice.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Et les otages?", 5),
            new Reponse("Oh que non", 5),
            new Reponse("...", -10),
            new Reponse("Rageux", -20),
        };
        uneQuestion = new Question(" ''Ca suffit, on rentre maintenant !''", uneListeReponses);
        questionsPolice.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Reculez!", 5),
            new Reponse("Ah bon", -5),
            new Reponse("Dommage", -20),
            new Reponse("Soyez prudents", -20),
        };
        uneQuestion = new Question(" ''Ca suffit, on rentre maintenant !''", uneListeReponses);
        questionsPolice.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Ca ira bien!", 5),
            new Reponse("M'en fous", -10),
            new Reponse("Triste", -10),
            new Reponse("Remi sans familles?", -20),
        };
        uneQuestion = new Question(" ''Ces gens ont des familles, arretez cette folie!''", uneListeReponses);
        questionsPolice.Add(uneQuestion);
    }

    //L'indice correspond au nombre d'argent récupéré
    private void InitialisationOrdinateur()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("S3CR3T", 5),
        };

        Question uneQuestion = new Question("//BANK-ACCOUNT NUMBER "+ 4444 + "-" + 5555 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("G4M3J4M", 5),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 3152 + "-" + 7946 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);


        uneListeReponses = new List<Reponse>
        {
            new Reponse("REPONSE", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 3333 + "-" + 4571 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("MIN3CR4T", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4567 + "-" + 3876 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("PRESSION", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4117 + "-" + 3346 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("EXPLORATION", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 2917 + "-" + 9341 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("ARC4D3", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 2067 + "-" + 9222 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("MULTIJOUEUR", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 2917 + "-" + 9341 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("DIALOGUE", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 2917 + "-" + 9341 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);



        uneListeReponses = new List<Reponse>
        {
            new Reponse("C4K3", 2),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 1234 + "-" + 6874 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("ROBOT", 2),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4561 + "-" +4568 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("L1NK", 2),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " +1111 + "-" + 4567 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("C4SH", 2),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 3384 + "-" + 1234 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("0101011", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 3384 + "-" + 3384 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("0101110", 4),
        };
        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 2580 + "-" + 8520 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("0101010", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4554 + "-" + 4856 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);


        uneListeReponses = new List<Reponse>
        {
            new Reponse("D34D", 2),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 1245 + "-" + 4123 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("L33T", 2),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 7645 + "-" + 1237 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("4Z3RTY", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4567 + "-" + 5467 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("KOJIMA", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4567 + "-" + 4157 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("TRUMP", 5),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 1547 + "-" + 6554 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("T3ST", 5),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 2225 + "-" + 5127 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("G1LB3RT", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 7999 + "-" + 9999 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("NEON", 2),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4556 + "-" + 9754 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("DOLLARS", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4567 + "-" + 2224 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("JULIEN", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 6528 + "-" + 3325 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("LUCAS", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4477 + "-" + 2525 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("GUILLAUME", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 6666 + "-" + 5252 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("JOAQUIM", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 6666 + "-" + 6666 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("GUILHEM", 3),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4200+ "-" + 0024 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("KILLIAN", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 1234 + "-" + 3456 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("MAXIME", 4),
        };

        uneQuestion = new Question("//BANK-ACCOUNT NUMBER " + 4757 + "-" + 4567 + "// PASSWORD???", uneListeReponses);
        questionsOrdinateur.Add(uneQuestion);
    }

    //L'indice correspond à l'effet sur la barre d'agitation des otages
    private void InitialisationOtageGroupe()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("FERMEZ-LA!", 20),
            new Reponse("Mais euuh", 0),
            new Reponse("*imite Garou*", -50),
            new Reponse("Criez encore et..", 50),
        };

        Question uneQuestion = new Question("Les otages parlent entre eux", uneListeReponses);
        questionsOtageGroupe.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("TAISEZ-VOUS!", 20),
            new Reponse("Botte", -25),
            new Reponse("Arretez svp.", 0),
            new Reponse("Euh stop la", 0),
        };

        uneQuestion = new Question("Les otages parlent entre eux", uneListeReponses);
        questionsOtageGroupe.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("VOS GUEULES!", 20),
            new Reponse("Chaussure", -25),
            new Reponse("Stop svp.", 0),
            new Reponse("Euh stop la", 0),
        };

        uneQuestion = new Question("Les otages parlent entre eux", uneListeReponses);
        questionsOtageGroupe.Add(uneQuestion);


        uneListeReponses = new List<Reponse>
        {
            new Reponse("Menacer", 20),
            new Reponse("Chaussure", -25),
            new Reponse("Stop svp.", 0),
            new Reponse("Euh stop la", 0),
        };

        uneQuestion = new Question("Les otages parlent entre eux", uneListeReponses);
        questionsOtageGroupe.Add(uneQuestion);





    }

    //L'indice correspond à l'effet sur la barre d'agitation de l'otage
    // ACTION SPECIALES:
    // -666 = Tuer
    private void InitialisationOtageIndividuel()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("TAIS-TOI", 50),
            new Reponse("Le fixer", 30),
            new Reponse("Euh arrete", -50),
            new Reponse("*Le tuer*", 666),
        };

        Question uneQuestion = new Question("L'otage vous parle", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("FERME-LA", 40),
            new Reponse("Courgette", -30),
            new Reponse("Sympa", -10),
            new Reponse("*Le tuer*", 666),
        };

        uneQuestion = new Question("L'otage vous parle", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("STOP", 40),
            new Reponse("Fichtre", -30),
            new Reponse("Pas faux", -10),
            new Reponse("*Le tuer*", 666),
        };

        uneQuestion = new Question("L'otage vous parle", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("TAIS-TOI", 0),
            new Reponse("Respire", 40),
            new Reponse("Euh arrete", -10),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage a une crise d'asthme", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Oui", -10),
            new Reponse("Souffle", 40),
            new Reponse("Arrete", 0),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage a du mal a respirer", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("FERME-LA", 0),
            new Reponse("Aider", 40),
            new Reponse("Euh", -5),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage est en train de s'etouffer", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("ARRETE", 0),
            new Reponse("Secourir", 40),
            new Reponse("???", -5),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage est en train de s'etouffer", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("STOP", 0),
            new Reponse("Assister", 40),
            new Reponse("Salut", -5),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage est en train de s'etouffer", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Ignorer", 0),
            new Reponse("Du calme", 40),
            new Reponse("Mouais", -5),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage est en train de s'etouffer", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Stop", 0),
            new Reponse("Le baffer", 40),
            new Reponse("L'ignorer", -5),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage simule un malaise", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Inutile", 0),
            new Reponse("Frapper", 40),
            new Reponse("Rigoler", -5),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage simule un malaise", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("...", 0),
            new Reponse("Le baffer", 40),
            new Reponse("Amusant", -5),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage simule un malaise", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Le frapper", 50),
            new Reponse("...", 0),
            new Reponse("Euh arrete", -20),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage vous defie du regard", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Le frapper", 50),
            new Reponse("Mmmh?", 0),
            new Reponse("Biscotte", -20),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage vous lance un regard noir", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Le taper", 50),
            new Reponse("...", 0),
            new Reponse("Stop", -10),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage vous surveille du regard", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Silence!", 50),
            new Reponse("Hein?", -10),
            new Reponse("Tais toi", -20),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage tente de negocier", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Le claquer", 50),
            new Reponse("...", 0),
            new Reponse("FERME-LA", -20),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage commence a paniquer", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("Le secouer", 50),
            new Reponse("FERME-LA", 20),
            new Reponse("...", -20),
            new Reponse("Le tuer", 666),
        };

        uneQuestion = new Question("L'otage commence a paniquer", uneListeReponses);
        questionsOtageIndividuel.Add(uneQuestion);



    }

    //L'indice correspond au nombre d'argent récupéré
    private void InitialisationFixOrdinateur()
    {
        List<Reponse> uneListeReponses = new List<Reponse>
        {
            new Reponse("Hello World", 1),
        };

        Question uneQuestion = new Question("//Avez-vous essayé de redémarrer votre box?//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);


        uneListeReponses = new List<Reponse>
        {
            new Reponse("alt + f4", 1),
        };

        uneQuestion = new Question("//L'ordinateur ne marche plus.//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("azerty", 1),
        };

        uneQuestion = new Question("//Unity a encore crashé.//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("alt + suppr", 1),
        };

        uneQuestion = new Question("//LA BASE VIRALE A ETE MISE A JOUR.//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("*taper l'ecran*", 1),
        };

        uneQuestion = new Question("//...//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("alt + suppr", 1),
        };

        uneQuestion = new Question("//Le programme ne s'est pas ferme.//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("ignorer", 1),
        };

        uneQuestion = new Question("//Erreur : Contactez l'administrateur systeme.//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("clean + build", 1),
        };

        uneQuestion = new Question("//NULL POINTER EXCEPTION.//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("magic + fix", 1),
        };

        uneQuestion = new Question("//ERROR IN SCRIPT 404 NOT FOUNDED.//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);

        uneListeReponses = new List<Reponse>
        {
            new Reponse("log in", 1),
        };

        uneQuestion = new Question("//TIME OUT : Deconnexion au serveur.//", uneListeReponses);
        questionsFixOrdinateur.Add(uneQuestion);
    }

}
