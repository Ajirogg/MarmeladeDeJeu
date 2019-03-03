using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ApparaitreVoiturePolice : MonoBehaviour
{
    public Animator policecaranimator;
    public Police police;
    public int policenumber = 0;
    public bool apparu;
    // Start is called before the first frame update
    void Start()
    {
        policecaranimator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ApparaitreVoiturePolice>().policenumber <= police.etatPolice)
        {
            policecaranimator.SetBool ("apparu", true);

        }

    }
}
