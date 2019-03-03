using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarMaster : MonoBehaviour
{
    [SerializeField]
    public static GameObject sonarPrefab;

    public GameObject sonarPrefabEdit;

    public static GameObject CreateSonar(Vector3 pos)
    {
        GameObject o = Instantiate(sonarPrefab);
        o.transform.position = pos;

        return o; 
    }

    // Start is called before the first frame update
    void Start()
    {
        SonarMaster.sonarPrefab = sonarPrefabEdit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
