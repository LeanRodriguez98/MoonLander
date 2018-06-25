using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private Vector3 OriginalPosition;
    private Vector3 PlayerPosition;
    private float OriginalCameraSize;
    private float OriginalCameraH;
    private float OriginalCameraW;
    public float ZoomCameraSize;

    // Use this for initialization
    void Start () {
        OriginalPosition = transform.position;
        PlayerPosition.z = transform.position.z;
        OriginalCameraSize = GetComponent<Camera>().orthographicSize;
        OriginalCameraH = Camera.main.orthographicSize * 2f;
        OriginalCameraW = OriginalCameraH * Camera.main.aspect;
    }
	
	// Update is called once per frame
	void Update () {
        if (CameraZoomCollider.instaciate != null)
        {
            if (CameraZoomCollider.instaciate.CameraTrigger)
            {
                PlayerPosition.x = CameraZoomCollider.instaciate.transform.position.x;
                PlayerPosition.y = CameraZoomCollider.instaciate.transform.position.y;

                GetComponent<Camera>().orthographicSize = ZoomCameraSize;
                if (PlayerPosition.x - (int)OriginalCameraW/4 <= -(int)OriginalCameraW / 2)
                {
                    PlayerPosition.x = -(int)OriginalCameraW / 4;                   
                }
                if (PlayerPosition.x + (int)OriginalCameraW/4 >= (int)OriginalCameraW/2)
                {                  
                    PlayerPosition.x = (int)OriginalCameraW/4;
                }
                if (PlayerPosition.y - (int)OriginalCameraH / 4 <= -(int)OriginalCameraH / 2)
                {
                    PlayerPosition.y = -(int)OriginalCameraH / 4;
                }
                if (PlayerPosition.y + (int)OriginalCameraH / 4 >= (int)OriginalCameraH / 2)
                {
                    PlayerPosition.y = (int)OriginalCameraH / 4;
                }
                transform.position = PlayerPosition;

            }
            else
            {
                transform.position = OriginalPosition;
                GetComponent<Camera>().orthographicSize = OriginalCameraSize;
            }
        }        

    }
}
