using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomCollider : MonoBehaviour {
    public static CameraZoomCollider instaciate;
    [HideInInspector] public bool CameraTrigger;
    // Use this for initialization
    void Start () {
        instaciate = this;
        CameraTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "LandTerrain")
        {           
            CameraTrigger = true;
            Debug.Log("true");
        }        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "LandTerrain")
        {
            CameraTrigger = false;
            Debug.Log("flase");
        }
    }

}
