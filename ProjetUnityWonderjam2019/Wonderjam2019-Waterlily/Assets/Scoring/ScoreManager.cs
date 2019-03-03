using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    private int m_score;

    // Start is called before the first frame update
    void Start()
    {
        m_score = 0;
    }

    public int getScore()
    {
        return m_score;
    }

    private void setScore(int newScore)
    {
        int old_Score = m_score;
        m_score = newScore;
        if (m_score < 0)
            m_score = 0;
        //Notify ScoreUI TO-DO
        GameObject.FindGameObjectsWithTag("UI")[0].GetComponent<ScoreUpdater>().updateScore(m_score, m_score - old_Score);
    }

    public void addScore(int amoutToAdd)
    {
        if (amoutToAdd > 0)
            setScore(getScore() + amoutToAdd);
    }

    /*public void substractScore(int amoutToSub)
    {
        if (amoutToSub > 0)
            setScore(getScore() - amoutToSub);
    }*/
}
