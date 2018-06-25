using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class HighscoreManager : MonoBehaviour {
    public static HighscoreManager Instanciate;
    [HideInInspector] public List<int> ScoreList = new List<int>();
    [HideInInspector] public bool AsignHishcore;
    public int CantHighscores;
    public string LoadingScenesName;
    public string LevelName;

    
    
    void Awake()
    {
        if (Instanciate == null)
        {
            Instanciate = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
            AsignHishcore = true;
        for (int i = 0; i < CantHighscores; i++)
        {
            ScoreList.Add(0);
        }
    }

    // Update is called once per frame
    void Update () {

        if (SceneManager.GetActiveScene().name == LoadingScenesName && !AsignHishcore)
        {
            AsignHishcore = true;
        }

        if (PlayerController.Instanciate.GameOver && AsignHishcore && SceneManager.GetActiveScene().name == LevelName)
        {
        
            ScoreList.Add(PlayerStats.Instanciate.Points);
            ScoreList.Sort();
            ScoreList.Reverse();
            AsignHishcore = false;
        }
    }
}
