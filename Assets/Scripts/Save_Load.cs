using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save_Load : MonoBehaviour
{

    private static Save_Load _Instance;
    public static Save_Load Instance
    {
        get
        {
            {
                if (!_Instance)
                {
                    _Instance = new GameObject().AddComponent<Save_Load>();
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
    private struct SaveData
    {
        public int winner;
    }
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Save()
    {
        SaveData data;
        data.winner = 0;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.dataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
        }
    }
    public void NewSave()
    {
        SaveData data;
        data.winner = 2;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/savefile.json", json);
    }
}