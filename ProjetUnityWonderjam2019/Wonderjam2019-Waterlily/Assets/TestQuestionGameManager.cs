using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuestionGameManager : MonoBehaviour
{
    public ListeQuestions laListeDesQuestions = new ListeQuestions();

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Question").GetComponent<QuestionManager>().InitialiserQuestion(laListeDesQuestions.GetRandomPolice(), 0, null);
    }

}
