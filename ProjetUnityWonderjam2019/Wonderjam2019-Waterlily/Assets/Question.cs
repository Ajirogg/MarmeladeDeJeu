using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    public string stringQuestion;
    public List<Reponse> reponses;

    public Question(string stringQuestion_, List<Reponse> reponses_)
    {
        stringQuestion = stringQuestion_;
        reponses = reponses_;
    }
}
