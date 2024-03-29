﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsEvents : MonoBehaviour
{
    private bool settingsActivated;
    private float baseAlpha;
    public float targetAlpha = 1;

    public Sprite spriteSettings;
    public Sprite spriteRetour;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        settingsActivated = false;
        baseAlpha = 0.75f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsClick();
        }
    }
    
    //Surbrillance
    public void MouseEnter(GameObject obj)
    {
        obj.GetComponent<CanvasGroup>().alpha = targetAlpha;
    }

    public void MouseExit(GameObject obj)
    {
        obj.GetComponent<CanvasGroup>().alpha = baseAlpha;
    }

    //Gestion des Clics
    public void PlayClick()
    {
        SoundManager.instance.musicSource.Stop(); //On stop la musique actuelle
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void SettingsClick()
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

    public void CloseClick()
    {
        Application.Quit();
    }

    //Ouverture Fermeture
    private void Open()
    {
        settingsActivated = true;

        //On met en pause les VFX
        SoundManager.instance.pauseAllEFX();

        //On cache le middlepanel
        gameObject.transform.Find("MiddlePanel").gameObject.SetActive(false);

        //On change l'icone du bouton de settings pour icone de retour
        gameObject.transform.Find("TopRightPanel").Find("SettingsButton").Find("Image").GetComponent<Image>().sprite = spriteRetour;

        //On montre le panel de settings
        gameObject.transform.Find("SettingsMenu").gameObject.SetActive(true);
        gameObject.transform.Find("SettingsMenu").gameObject.GetComponent<SettingsManagement>().DisplayCurrentSettings();
    }

    private void Close()
    {
        settingsActivated = false;

        //On resume les VFX
        SoundManager.instance.resumeAllEFX();

        //On montre le middlepanel
        gameObject.transform.Find("MiddlePanel").gameObject.SetActive(true);
        gameObject.transform.Find("MiddlePanel").gameObject.SetActive(true);

        //On change l'icone du bouton de retour pour icone de settings
        gameObject.transform.Find("TopRightPanel").Find("SettingsButton").Find("Image").GetComponent<Image>().sprite = spriteSettings;

        //On cache le panel de settings
        gameObject.transform.Find("SettingsMenu").gameObject.SetActive(false);
    }
}
