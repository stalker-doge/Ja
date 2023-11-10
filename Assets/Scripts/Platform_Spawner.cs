using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] Spawns;

    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float spawnTimer;
    [SerializeField] private int spawnOffset=50;

    // Start is called before the first frame update
    void Start()
    {


       //for (int i = 0; i < 2; i++)
       // {
       //     Vector3 randomPosition = new Vector3(
       //    Random.Range(minPos.x, maxPos.x),
       //    Random.Range(minPos.y, maxPos.y),
       //    Random.Range(minPos.z, maxPos.z)
       //    );

       //     Instantiate(Spawner, randomPosition, Quaternion.identity);
       // }

       
    }


    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnDelay )
        {
            StartCoroutine(SpawnPlatform());
            spawnTimer = 0;
        }
    }

    IEnumerator SpawnPlatform()
    {
        Vector3 position = new Vector3(GameObject.Find("Camera").transform.position.x + spawnOffset, Random.Range(-1, 20));
        Instantiate(Spawns[Random.Range(0, Spawns.Length)], position, Quaternion.identity);
        yield return new WaitForSeconds(spawnDelay);
    }
}
