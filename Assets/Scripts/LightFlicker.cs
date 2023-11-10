using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float min = 0.1f;
    public float max = 1f;

    public Light m_lightSource;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(min, max);  
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            m_lightSource.gameObject.SetActive(!m_lightSource.gameObject.activeInHierarchy);
            timer = Random.Range(min, max);
        }
    }
}
