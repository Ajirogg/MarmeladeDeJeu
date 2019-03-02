using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    public InputField inputField;
    public GameObject Question;

    bool typingEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (typingEnabled)
            {
                if (GameObject.FindGameObjectsWithTag("Question") != null)
                {
                    GameObject goQuestion = GameObject.FindGameObjectWithTag("Question");
                    goQuestion.GetComponent<QuestionManager>().Reponse(inputField.text);
                }
            }

            typingEnabled = !typingEnabled;
            inputField.gameObject.SetActive(typingEnabled);

            if (typingEnabled)
            {
                inputField.text = "";
                inputField.Select();
                inputField.ActivateInputField();
            }
        }
    }
}
