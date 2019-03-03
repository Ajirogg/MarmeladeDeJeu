using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFadeDrop : MonoBehaviour
{
    RectTransform rect;

    public float timeToFade = 2f;
    public float dropLength = 25f;

    private float basePosX;
    private float basePosY;

    [ReadOnly] public float execTime;

    void Awake()
    {
        //Var
        execTime = 0f;

        //Canvas Init
        rect = GetComponent<RectTransform>();
            //Position de l'ancre
        rect.anchorMin = new Vector2(0,1);
        rect.anchorMax = new Vector2(0,1);
            //taille et position
        basePosX = Mathf.Abs(rect.anchoredPosition.x);
        basePosY = Mathf.Abs(rect.anchoredPosition.y);
    }

    public void Exec(int textNumber)
    {
        GetComponent<Text>().text = "+" + textNumber + "$";
        StartCoroutine(Exec_Func());
    }

    IEnumerator Exec_Func()
    {
        while(execTime < timeToFade)
        {
            ApplyFade();
            ApplyDrop();

            execTime += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
        yield break;
    }

    public void ApplyFade()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();
        float alpha = execTime / timeToFade;
        if (alpha >= 0)
            group.alpha = 1 - alpha;
    }

    public void ApplyDrop()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();
        float offSet = (execTime / timeToFade) * dropLength;
        if (offSet > dropLength)
            offSet = dropLength;
        rect.anchoredPosition = new Vector3(basePosX, -(basePosY + offSet), 0);
    }
}
