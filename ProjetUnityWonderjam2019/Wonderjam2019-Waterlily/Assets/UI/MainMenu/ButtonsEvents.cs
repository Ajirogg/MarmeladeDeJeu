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
        SceneManager.LoadScene("SceneTest", LoadSceneMode.Single);
    }

    public void SettingsClick()
    {
        if (!settingsActivated)
        {
            settingsActivated = true;

            //On cache le middlepanel
            gameObject.transform.parent.parent.Find("MiddlePanel").gameObject.SetActive(false);

            //On change l'icone du bouton de settings pour icone de retour
            gameObject.transform.Find("Image").GetComponent<Image>().sprite = spriteRetour;

            //On montre le panel de settings
            gameObject.transform.parent.parent.Find("SettingsMenu").gameObject.SetActive(true);
        }
        else
        {
            settingsActivated = false;

            //On montre le middlepanel
            gameObject.transform.parent.parent.Find("MiddlePanel").gameObject.SetActive(true);

            //On change l'icone du bouton de retour pour icone de settings
            gameObject.transform.Find("Image").GetComponent<Image>().sprite = spriteSettings;

            //On cache le panel de settings
            gameObject.transform.parent.parent.Find("SettingsMenu").gameObject.SetActive(false);
        }
    }

    public void CloseClick()
    {
        Application.Quit();
    }
}
