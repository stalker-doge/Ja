using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawner : MonoBehaviour
{

    public GameObject Spawner;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Spawner);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
