using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawner : MonoBehaviour
{

    public GameObject[] Spawner;
    [SerializeField] BoxCollider spawnBox;
    //public Vector3[] minPos;
    //public Vector3[] maxPos;

    [SerializeField] int numberOfSpawns;
    [SerializeField] GameObject[] Spawns;

    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        Spawns = new GameObject[numberOfSpawns*Spawner.Length];


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
        Vector3 position = new Vector3(GameObject.Find("Camera").transform.position.x + 70, Random.Range(-5, 20));
        Instantiate(Spawner[Random.Range(0, 2)], position, Quaternion.identity);
        yield return new WaitForSeconds(spawnDelay);
    }
}
