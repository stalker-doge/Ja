using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{

    private static LevelHandler _Instance;
    public int playersAlive;
    public float finalScorePlayer1=0;
    public float finalScorePlayer2=0;
    public static LevelHandler Instance
    {
        get
        {
            {
                if (!_Instance)
                {
                    _Instance = new GameObject().AddComponent<LevelHandler>();
                }
                return _Instance;
            }
        }
    }

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(this);
        }
        else
        {
            _Instance = this;
        }
    }

    public int level;
    public int currentLevel;
    public int maxLevel;
    // Start is called before the first frame update
    void Start()
    {
        maxLevel = SceneManager.sceneCountInBuildSettings - 2;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        level = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void LoadNextLevel()
    {
        if (level < maxLevel)
        {
            level++;
            SceneManager.LoadScene(level);
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
    }
    public int GetCurrentLevel()
    {
        return level;
    }
    public void LoadLose()
    {
        if (playersAlive==0) 
        {
            if(Save_Load.Instance.SavePlayerScore(finalScorePlayer1, finalScorePlayer2))
            {
                SceneManager.LoadScene("Loss");

            }

        }
    }
}
