using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float speed = 1;
   

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x += speed;
        Camera.main.gameObject.transform.position = cameraPosition;
    }
}
