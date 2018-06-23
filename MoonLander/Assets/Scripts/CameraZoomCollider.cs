using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomCollider : MonoBehaviour {
    public static CameraZoomCollider instaciate;
    [HideInInspector] public bool CameraTrigger;
    private float ExitTimer;
    public float CameraZoomOffTimer;
    void Start () {
        instaciate = this;
        CameraTrigger = false;
        ExitTimer = 0;

    }

	void Update () {
        ExitTimer += Time.deltaTime;

        if (ExitTimer > CameraZoomOffTimer)
        {
            CameraTrigger = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "LandTerrain")
        {
            CameraTrigger = true;
            ExitTimer = 0;
        }
    }
}
