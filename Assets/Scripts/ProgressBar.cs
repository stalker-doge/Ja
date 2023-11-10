using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public int maximum = 100;
    public int current;
    public Image mask;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        mask = GetComponent<Image>();
        player = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        current = (int)player.GetComponent<PlayerController>().pressure;
    }

    void GetCurrentFill()
    {
        float fillAmount =1-(float) current/(float)maximum;
        mask.fillAmount = fillAmount;
    }
}
