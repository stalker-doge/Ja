using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawner : MonoBehaviour
{

    public GameObject Spawner;
    public Vector3 minPos;
    public Vector3 maxPos;


    // Start is called before the first frame update
    void Start()
    {
       

       for (int i = 0; i < 2; i++)
        {
            Vector3 randomPosition = new Vector3(
           Random.Range(minPos.x, maxPos.x),
           Random.Range(minPos.y, maxPos.y),
           Random.Range(minPos.z, maxPos.z)
           );

            Instantiate(Spawner, randomPosition, Quaternion.identity);
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null)
        {
            Destroy(collision.gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
