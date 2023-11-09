using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreValue = 1;
    private float ScoreHandler;
    public float score;

    public void Collect()
    {
        ScoreManager.Instance.AddScore(scoreValue);

        Destroy(gameObject);
    }


}
