using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour {
    public float MinTimeOfLife;
    public float MaxTimeOfLife;
    public float MinMagnitude;
    public float MaxMagnitude;

    private float TimeOfLife;
    private AreaEffector2D Efector;
    private SpriteRenderer SpriteWind;
    private Color AlphaWind;
	void Start () {
        SpriteWind = GetComponent<SpriteRenderer>();
        Efector = GetComponent<AreaEffector2D>();
        AlphaWind.r = 255;
        AlphaWind.g = 255;
        AlphaWind.b = 255;
        AlphaWind.a = 0;
        TimeOfLife = Random.Range(MinTimeOfLife, MaxTimeOfLife + 1);
        Efector.forceMagnitude = Random.Range(-MaxTimeOfLife, -MinTimeOfLife);
	}
	
	
	void Update () {    

        if (AlphaWind.a < 1 && TimeOfLife > 0)        
            AlphaWind.a += Time.deltaTime;      
        else if (AlphaWind.a >= 1 && TimeOfLife >= 0)        
            TimeOfLife -= Time.deltaTime;
        else if (TimeOfLife <= 0 && AlphaWind.a > 0)        
            AlphaWind.a -= Time.deltaTime;
        else if (TimeOfLife <= 0 && AlphaWind.a <= 0)       
            Destroy(gameObject);
      
        SpriteWind.color = AlphaWind;

        if (GameManagerController.Instanciate.WindCheat)        
            Destroy(gameObject);
    }
   
}
