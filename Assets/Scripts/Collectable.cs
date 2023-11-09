using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreValue = 1;

    public void Collect()
    {
     //   ScoreManager.Instance.AddScore(scoreValue);

        Destroy(gameObject);
    }

}
