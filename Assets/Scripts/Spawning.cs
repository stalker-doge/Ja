using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject PlatformLargePrefab;
    public GameObject PlatformSmallPrefab;
    public GameObject PlatformMediumPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBound;

    // Start is called before the first frame update
    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(PlatformWave());
    }

    private void spawnPlatform()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.transform.position.z));
        GameObject a = Instantiate(PlatformLargePrefab) as GameObject;
       //GameObject b = Instantiate(PlatformSmallPrefab) as GameObject;
        //GameObject c = Instantiate(PlatformMediumPrefab) as GameObject;
        a.transform.position = new Vector2(screenBound.x - 35, Random.Range(-screenBound.y, screenBound.y));
        //b.transform.position = new Vector2(screenBound.x + 50, Random.Range(-screenBound.y, screenBound.y));
       // c.transform.position = new Vector2(screenBound.x + 40, Random.Range(-screenBound.y, screenBound.y));
    }
    IEnumerator PlatformWave()
    {
        while (true) 
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPlatform();
        }
    }
}
