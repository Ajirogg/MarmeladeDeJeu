using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightBalayage : MonoBehaviour
{
    public Police police;
    public Vector3 positiondepart = new Vector3(-20, 0, -15);
    public float direction = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = positiondepart;
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.Translate(direction, 0, 0);        
        if (gameObject.transform.position.x == -20)
        {
            direction = -direction;
        }
        if (gameObject.transform.position.x == 20)
        {
            direction = -direction;
        }

        this.GetComponent<Light>().intensity = 1 + 7.5f * (float)police.agressivitePolice/100;
            
    }
    
}
