using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreText : MonoBehaviour {
    public Text[] HighscoreTexts;

	void Start () {
        for (int i = 0; i < HighscoreTexts.Length; i++)
        {            
            HighscoreTexts[i].text = HighscoreManager.Instanciate.ScoreList[i].ToString("0000");            
        }
    }
	

	void Update () {
        
    }
}
