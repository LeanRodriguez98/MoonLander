using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {
    public Text HeightText;
    public Text TimeText;
    public Text PointsText;
    public Text FuelText;
    public Text SpeedVerticalText;
    public Text SpeedHorizontalText;

    private float AuxHeight;
    private float AuxTime;
    private float AuxPoints;
    private float AuxFuel;
    private float AuxSpeedVertical;
    private float AuxSpeedHorizontal;
    private float TimeOfGame;
    private float AuxTimeOfGame;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeOfGame += Time.deltaTime;

        HeightText.text = "Height " + PlayerStats.Instanciate.Height.ToString("000");
        TimeText.text = "Time " + ((int)(TimeOfGame)).ToString();
        PointsText.text = "Points " + PlayerStats.Instanciate.Points.ToString("0000");
        FuelText.text = "Fuel " + ((int)(PlayerStats.Instanciate.Fuel)).ToString();
        SpeedVerticalText.text = "Speed ▲ " + PlayerStats.Instanciate.VerticalSpeed.ToString("000");
        SpeedHorizontalText.text = "Speed ► " +  PlayerStats.Instanciate.HorizontalSpeed.ToString("000");

    }
}
