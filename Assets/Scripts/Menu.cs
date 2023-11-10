using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    [SerializeField] TextMeshProUGUI m_TextMeshPro2;

    // Start is called before the first frame update
    void Start()
    {
        Save_Load.Instance.Load();
        m_TextMeshPro.text = "Player 1 Score: " + LevelHandler.Instance.finalScorePlayer1;
        m_TextMeshPro2.text = "Player 2 Score: " + LevelHandler.Instance.finalScorePlayer2;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController[] players=FindObjectsOfType<PlayerController>();
        if(players.Length>0)
        {
            m_TextMeshPro.text = "Player 1 Score: " + players[0].score;
            if (players.Length > 1)
            {
                m_TextMeshPro2.text = "Player 1 Score: " + players[1].score;
                m_TextMeshPro2.text = "Player 2 Score: " + players[0].score;
            }
        }

    }
}
