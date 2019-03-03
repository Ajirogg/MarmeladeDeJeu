using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float TimeCount;
    // Start is called before the first frame update
    void Start()
    {
        TimeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;

        gameObject.GetComponent<Text>().text = ((int) (TimeCount / 60f)).ToString("D2") + " : " + ((int) (TimeCount % 60f)).ToString("D2");
    }
}
