using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingScenes : MonoBehaviour {
    public static LoadingScenes Instanciate;
    public string LoadingText;
    public string LoadingScenesName;

    public int LoadingSpeed;
    [HideInInspector]public int Level;
    private float Percentage;

    // Use this for initialization
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

    void Start ()
    {
        Percentage = 0;
        Level = 1;
    }
	
	// Update is called once per frame
	void Update () {
        
        UpdatePercentage();
        if (Percentage >= 100)
        {
            Percentage = 0;
            NextLevel();
        }
    }

    public void UpdatePercentage()
    {
        if (SceneManager.GetActiveScene().name == LoadingScenesName)
        {
            LoadingText = "Loading Level " + Level + " % " + ((int)Percentage).ToString("000");
            Percentage += Time.deltaTime * LoadingSpeed;
        }
    }
    public void NextLevel()
    {
        Level++;
        SceneManager.LoadScene("Level");
    }
}
