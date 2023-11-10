using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] float speed = 0.05f;
    [SerializeField] float acceltimer;
    [SerializeField] float accel;
   

    // Update is called once per frame
    void Update()
    {
        
        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x += speed;
        Camera.main.gameObject.transform.position = cameraPosition;
        acceltimer += Time.deltaTime;
        if (acceltimer > 5)
        {
            speed += accel;
            acceltimer = 0;
        }

    }
}
