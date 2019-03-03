using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameSettingsButtonsMenu : MonoBehaviour
{
    private bool settingsActivated;

    // Start is called before the first frame update
    void Start()
    {
        settingsActivated = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!settingsActivated)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    //Gestion des Clics
    public void HomeClick()
    {
        ScoreManager.Instance.ResetScore();
        SoundManager.instance.musicSource.Stop();
        SoundManager.instance.stopAllEFX();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void BackClick()
    {
        Close();
    }

    //Ouverture Fermeture
    private void Open()
    {
        settingsActivated = true;

        gameObject.GetComponent<SettingsManagement>().DisplayCurrentSettings();

        //On met en pause les VFX
        SoundManager.instance.pauseAllEFX();

        //On affiche le canvas des settings
        gameObject.transform.Find("MainFrame").gameObject.SetActive(true);
        gameObject.transform.Find("Blur").gameObject.SetActive(true);
        gameObject.transform.Find("Shadows").gameObject.SetActive(true);
        gameObject.transform.Find("TopRightPanel").gameObject.SetActive(true);

        //On stop le jeu
        Time.timeScale = 0.0f;
    }

    private void Close()
    {
        settingsActivated = false;

        //On resume les VFX
        SoundManager.instance.resumeAllEFX();

        //On cache le canvas des settings
        gameObject.transform.Find("MainFrame").gameObject.SetActive(false);
        gameObject.transform.Find("Blur").gameObject.SetActive(false);
        gameObject.transform.Find("Shadows").gameObject.SetActive(false);
        gameObject.transform.Find("TopRightPanel").gameObject.SetActive(false);

        //On relance le jeu
        Time.timeScale = 1.0f;
    }
}
