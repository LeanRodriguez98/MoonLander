using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheatsPanel : MonoBehaviour {
    public GameObject NextLevelButton;
    public GameObject MoreFuelButton;
    public GameObject WindShichButton;
    private bool Swich;
    // Use this for initialization
    void Start () {
      
        Swich = true;
        NextLevelButton.SetActive(false);
        MoreFuelButton.SetActive(false);
        WindShichButton.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Q) && !Swich)
        {
            NextLevelButton.SetActive(false);
            MoreFuelButton.SetActive(false);
            WindShichButton.SetActive(false);
            Swich = true;

        }
        else if (Input.GetKeyDown(KeyCode.Q) && Swich)
        {
            NextLevelButton.SetActive(true);
            MoreFuelButton.SetActive(true);
            WindShichButton.SetActive(true);
            Swich = false; 
        }

        
    }
}
