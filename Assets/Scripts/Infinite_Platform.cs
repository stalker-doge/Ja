using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinite_Platform : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
}
