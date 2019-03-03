﻿using System.Collections;
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

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Escape.ToString())))
        {
            if (!settingsActivated)
                Open();
            else
                Close();
        }
    }

    //Gestion des Clics
    public void HomeClick()
    {
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
        //On affiche le canvas des settings
        gameObject.transform.Find("MainFrame").gameObject.SetActive(true);
        gameObject.transform.Find("Blur").gameObject.SetActive(true);
        gameObject.transform.Find("Shadows").gameObject.SetActive(true);
        gameObject.transform.Find("TopRightPanel").gameObject.SetActive(true);

        //On stop le jeu

    }

    private void Close()
    {
        settingsActivated = false;

        //On cache le canvas des settings
        gameObject.transform.Find("MainFrame").gameObject.SetActive(false);
        gameObject.transform.Find("Blur").gameObject.SetActive(false);
        gameObject.transform.Find("Shadows").gameObject.SetActive(false);
        gameObject.transform.Find("TopRightPanel").gameObject.SetActive(false);

        //On relance le jeu

    }
}
