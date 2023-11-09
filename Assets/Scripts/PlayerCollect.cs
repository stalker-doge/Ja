using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Collectible collectible = other.GetComponent<Collectible>();

        if (collectible != null)
        {
            Destroy(collectible);
        }
    }
}