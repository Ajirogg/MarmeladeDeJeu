using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Question laQuestion;

    public GameObject goQuestion;
    public GameObject prefabReponse;
    public List<GameObject> goReponses = new List<GameObject>();

    public List<Reponse> reponsesRandom = new List<Reponse>();

    float espacementEntreReponses = 50f;

    public bool readyToAnswer = false;

    public List<Sprite> imageUI = new List<Sprite>();

    // Start is called before the first frame update
    public void InitialiserQuestion(Question laQuestion_, int type) // 1 = Ordinateur / Autre = Bulles
    {

        laQuestion = laQuestion_;

        goQuestion = this.gameObject;

        if (type == 1)
        {
            goQuestion.GetComponent<Image>().sprite = imageUI[1];
        }

        goQuestion.GetComponentInChildren<Text>().text = laQuestion.stringQuestion;

        reponsesRandom = laQuestion.reponses;

        ShuffleListOfString(reponsesRandom);

        float positionXBase = -(((prefabReponse.GetComponent<RectTransform>().sizeDelta.x) * reponsesRandom.Count / 2) + (espacementEntreReponses * (reponsesRandom.Count - 1) / 2));
        positionXBase += prefabReponse.GetComponent<RectTransform>().sizeDelta.x / 2;
        float espacementEntrePosX = prefabReponse.GetComponent<RectTransform>().sizeDelta.x + espacementEntreReponses;

        for (int i = 0; i < reponsesRandom.Count; i++)
        {
            goReponses.Add(Instantiate(prefabReponse, goQuestion.transform));
            goReponses[i].GetComponent<RectTransform>().localPosition = new Vector3(positionXBase + espacementEntrePosX * i, -90);
            goReponses[i].GetComponentInChildren<Text>().text = reponsesRandom[i].stringReponse;

            if (type == 1)
            {
                goReponses[i].GetComponent<Image>().sprite = imageUI[1];
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShuffleListOfString(List<Reponse> anArray)
    {
        for (int i = 0; i < anArray.Count; i++)
        {
            // tirage au sort d'un index entre 0 et la valeur courante de "i"
            int randomIndex = Random.Range(0, anArray.Count);
            // intervertion des éléments situés aux index "i" et "randomIndex"
            Reponse temp = anArray[i];
            anArray[i] = anArray[randomIndex];
            anArray[randomIndex] = temp;
        }
    }

    public int Reponse(string laReponse_)
    {

        int indice = 0;
        Debug.Log("Une réponse a été faites: " + laReponse_);

        bool bienRepondu = false;

        for (int i = 0; i < reponsesRandom.Count; i++)
        {
            if (laReponse_ == reponsesRandom[i].stringReponse)
            {
                indice = reponsesRandom[i].indiceReponse;

                Color colorText;
                if (indice > 0)
                {
                    colorText = Color.green;
                }
                else if (indice < 0)
                {
                    colorText = Color.red;
                }
                else
                {
                    colorText = Color.yellow;
                }
                goReponses[i].GetComponentInChildren<Text>().color = colorText;
                StartCoroutine(FadeQuestion(0.25f, 50f, i));
                bienRepondu = true;
            }
        }

        if (!bienRepondu)
        {
            StartCoroutine(ShakeQuestion(0.25f, 25f));
        }

        return indice;

    }

    IEnumerator FadeQuestion(float fadeTime, float movementAmount, int answerChosen)
    {
        yield return new WaitForSeconds(0.5f);

        float startPositionY = goQuestion.transform.localPosition.y;
        float startPositionAnswerY = goReponses[answerChosen].transform.localPosition.y;

        float y = 0;
        for (float i = fadeTime; i > 0; i -= Time.deltaTime)
        {

            float lerpFadeAmount = (i / fadeTime);
            //Debug.Log(lerpFadeAmount);
            y += Time.deltaTime;
            float actualMovementY = (y * movementAmount / fadeTime);

            Debug.Log(actualMovementY);

            //Movement
            goQuestion.transform.localPosition = new Vector3(goQuestion.transform.localPosition.x, startPositionY - actualMovementY, goQuestion.transform.localPosition.z);
            goReponses[answerChosen].transform.localPosition = new Vector3(goReponses[answerChosen].transform.localPosition.x, startPositionAnswerY + actualMovementY*2, goReponses[answerChosen].transform.localPosition.z);


            //Fade
            Image[] listeImages = goQuestion.GetComponentsInChildren<Image>();

            for (int h = 0; h < listeImages.Length; h++)
            {
                Color c = listeImages[h].color;
                c.a = Mathf.Lerp(0, 1, lerpFadeAmount);
                listeImages[h].color = c;
            }

            Text[] listeText = goQuestion.GetComponentsInChildren<Text>();

            for (int h = 0; h < listeText.Length; h++)
            {
                Color c = listeText[h].color;
                c.a = Mathf.Lerp(0, 1, lerpFadeAmount);
                listeText[h].color = c;
            }
            yield return null;
        }
    }


    IEnumerator ShakeQuestion(float shakeTime, float movementAmount)
    {

        float startPositionX = goQuestion.transform.localPosition.x;
        float rightPositionX = goQuestion.transform.localPosition.x + movementAmount;
        float leftPositionX = goQuestion.transform.localPosition.x - movementAmount;

        float y = 0;
        for (float i = 0; i < shakeTime/4; i += Time.deltaTime)
        {
            goQuestion.transform.localPosition  = Vector3.Lerp(new Vector3(startPositionX, goQuestion.transform.localPosition.y), new Vector3(rightPositionX, goQuestion.transform.localPosition.y), i/(shakeTime/4));
            yield return null;
        }
        for (float i = 0; i < shakeTime/2; i += Time.deltaTime)
        {
            goQuestion.transform.localPosition = Vector3.Lerp(new Vector3(rightPositionX, goQuestion.transform.localPosition.y), new Vector3(leftPositionX, goQuestion.transform.localPosition.y), i / (shakeTime/2));
            yield return null;
        }
        for (float i = 0; i < shakeTime/4; i += Time.deltaTime)
        {
            goQuestion.transform.localPosition = Vector3.Lerp(new Vector3(leftPositionX, goQuestion.transform.localPosition.y), new Vector3(startPositionX, goQuestion.transform.localPosition.y), i / (shakeTime/4));
            yield return null;
        }
    }
}
