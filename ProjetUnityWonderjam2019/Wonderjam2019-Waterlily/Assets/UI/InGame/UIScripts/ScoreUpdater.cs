using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public GameObject scoreGainNotif;

    public void updateScore (int newScore, int scoreGain)
    {
        transform.Find("ScoreCount").Find("ScorePanel").Find("Score").Find("Text").gameObject.GetComponent<Text>().text = newScore.ToString();

        GameObject newNotif = Instantiate(scoreGainNotif) as GameObject;
        newNotif.transform.SetParent(gameObject.transform.Find("ScoreCount").Find("ScorePanel"), false);
        newNotif.GetComponent<CanvasFadeDrop>().Exec(scoreGain);
    }
}
