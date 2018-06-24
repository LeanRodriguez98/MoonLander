using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameOverPanel : MonoBehaviour {

    public GameObject BackToMainMenu;
    public Text PointsText;    
    // Use this for initialization
    void Start () {
        BackToMainMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        if (PlayerController.Instanciate.GameOver)
        {
            PointsText.text = "Points" + "\n" + PlayerStats.Instanciate.Points.ToString("0000");
            BackToMainMenu.SetActive(true);
        }
    }
}
