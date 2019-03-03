using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSonar : MonoBehaviour
{
    // Start is called before the first frame update
    private SimpleSonarShader_Object sonar;
    
    void Start()
    {
        if (this.GetComponent<SimpleSonarShader_Object>() != null)
            Destroy(this.GetComponent<SimpleSonarShader_Object>());

        sonar = this.gameObject.AddComponent<SimpleSonarShader_Object>();
    }

    public SimpleSonarShader_Object GetSonar()
    {
        if(sonar == null)
        {
            if (gameObject.GetComponent<SimpleSonarShader_Object>() == null)
            {
                sonar = this.gameObject.AddComponent<SimpleSonarShader_Object>();
            }                
            else
            {
                Destroy(this.GetComponent<SimpleSonarShader_Object>());
                sonar = this.gameObject.AddComponent<SimpleSonarShader_Object>();
            }
            return sonar;
        }

        return sonar;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
