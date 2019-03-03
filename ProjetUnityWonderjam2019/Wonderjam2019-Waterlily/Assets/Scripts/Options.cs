using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : Singleton<Options>
{

    public float musicVolume;
    public float sfxVolume;

    // Start is called before the first frame update
    void Start()
    {
        musicVolume = 0.5f;
        sfxVolume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
