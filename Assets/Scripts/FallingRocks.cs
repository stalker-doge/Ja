using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    public float FallSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        //rocks falling down
        transform.Translate(Vector3.down * FallSpeed * Time.deltaTime);

        // Checking the rock is on the y axis 
        if (transform.position.y < -5f)
        {
            ResetRockPosition();
        }
        void ResetRockPosition()
        {
            // Rock will be above but on screen 
            float randomX = Random.Range(-5f, 5f);
            float maxY = 10f;
            transform.position = new Vector3(randomX, maxY, 0f);
        }
    }
 }
