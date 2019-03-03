using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    private int m_score;
    private float m_playTime;
    private int m_hostagesAlive;

    public void LauchEndGame(int score, float playtime, int hostagesAlive)
    {
        //On récupère les infos
        m_score = score;
        m_playTime = playtime;
        m_hostagesAlive = hostagesAlive;

        //On stop tout les EFX
        SoundManager.instance.stopAllEFX();

        //On affiche les infos
        gameObject.transform.Find("Panel").Find("Content").Find("TimePanel").Find("AmountText").GetComponent<Text>().text = ((int) (m_playTime / 60f)) + " minutes " + ((int) (m_playTime % 60f)) + " secondes";
        gameObject.transform.Find("Panel").Find("Content").Find("MoneyPanel").Find("AmountText").GetComponent<Text>().text = m_score + "$";
        gameObject.transform.Find("Panel").Find("Content").Find("HostagePanel").Find("AmountText").GetComponent<Text>().text = m_hostagesAlive + " otages";

        //On arrête le jeu
        Time.timeScale = 0.0f;

        //On affiche l'écran de fin
        gameObject.transform.Find("Panel").gameObject.SetActive(true);
        gameObject.transform.Find("Shadows").gameObject.SetActive(true);
        gameObject.transform.Find("Blur").gameObject.SetActive(true);
    }

    public void HomeClick()
    {
        ScoreManager.Instance.ResetScore();
        SoundManager.instance.musicSource.Stop(); //On stop la musique
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void CloseClick()
    {
        Application.Quit();
    }
}
