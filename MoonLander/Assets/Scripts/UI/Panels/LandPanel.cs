using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LandPanel : MonoBehaviour {

    public GameObject NextLevelButton;
    public Text PointsText;    

    void Start () {
            NextLevelButton.SetActive(false);

    }


    void Update () {
        if (PlayerController.Instanciate.EndLevel)
        {
            PointsText.text = "Points" + "\n" + PlayerStats.Instanciate.Points.ToString("0000");
            NextLevelButton.SetActive(true);
        }
        else
        {
            PointsText.text = "";
            NextLevelButton.SetActive(false);

        }
    }
}
