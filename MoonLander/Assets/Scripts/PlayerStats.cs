using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public static PlayerStats Instanciate;
    [HideInInspector] public int Points;
    [HideInInspector] public float HorizontalSpeed;
    [HideInInspector] public float VerticalSpeed;
    [HideInInspector] public float Height;
    public float Fuel;
    public float CombustionFuel;
    

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
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
