using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ScoreHandler score = collision.gameObject.GetComponent<ScoreHandler>();
            score.AddScore();
            Destroy(gameObject);
        }
    }
}
