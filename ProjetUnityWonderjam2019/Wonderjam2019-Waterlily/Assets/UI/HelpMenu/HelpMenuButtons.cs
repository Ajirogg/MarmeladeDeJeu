using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuButtons : MonoBehaviour
{
    private bool helpActivated;

    // Start is called before the first frame update
    void Start()
    {
        helpActivated = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (helpActivated)
            {
                Close();
            }
        }
    }

    //Gestion des Clics
    public void openHelpClick()
    {
        Open();
    }

    public void closeHelpClick()
    {
        Close();
    }

    //Ouverture Fermeture
    private void Open()
    {
        helpActivated = true;

        //On affiche le menu d'aide par dessus tout
        gameObject.transform.Find("MainPanel").gameObject.SetActive(true);
        gameObject.transform.Find("EventSystem").gameObject.SetActive(true);
        gameObject.transform.Find("Blur").gameObject.SetActive(true);
    }

    private void Close()
    {
        helpActivated = false;

        //On affiche le menu d'aide par dessus tout
        gameObject.transform.Find("MainPanel").gameObject.SetActive(false);
        gameObject.transform.Find("EventSystem").gameObject.SetActive(false);
        gameObject.transform.Find("Blur").gameObject.SetActive(false);
    }
}
