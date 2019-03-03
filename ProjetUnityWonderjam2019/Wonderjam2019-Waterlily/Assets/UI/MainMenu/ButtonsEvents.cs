using System.Collections;
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
        settingsActivated = false;
        baseAlpha = GetComponent<CanvasGroup>().alpha;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsClick();
        }
    }
    
    //Surbrillance
    public void MouseEnter()
    {
        GetComponent<CanvasGroup>().alpha = targetAlpha;
    }

    public void MouseExit()
    {
        GetComponent<CanvasGroup>().alpha = baseAlpha;
    }

    //Gestion des Clics
    public void PlayClick()
    {
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

        //On montre le middlepanel
        gameObject.transform.Find("MiddlePanel").gameObject.SetActive(true);
        gameObject.transform.Find("MiddlePanel").gameObject.SetActive(true);

        //On change l'icone du bouton de retour pour icone de settings
        gameObject.transform.Find("TopRightPanel").Find("SettingsButton").Find("Image").GetComponent<Image>().sprite = spriteSettings;

        //On cache le panel de settings
        gameObject.transform.Find("SettingsMenu").gameObject.SetActive(false);
    }
}
