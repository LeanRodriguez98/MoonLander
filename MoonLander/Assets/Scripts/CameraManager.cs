﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private Vector3 OriginalPosition;
    private Vector3 PlayerPosition;
    private float OriginalCameraSize;
    public float ZoomCameraSize;
	// Use this for initialization
	void Start () {
        OriginalPosition = transform.position;
        PlayerPosition.z = transform.position.z;
        OriginalCameraSize = GetComponent<Camera>().orthographicSize;

    }
	
	// Update is called once per frame
	void Update () {
        if (CameraZoomCollider.instaciate.CameraTrigger)
        {
            PlayerPosition.x = CameraZoomCollider.instaciate.transform.position.x;
            PlayerPosition.y = CameraZoomCollider.instaciate.transform.position.y;

            GetComponent<Camera>().orthographicSize = ZoomCameraSize;
            transform.position = PlayerPosition;
        }
        else
        {
            transform.position = OriginalPosition;
            GetComponent<Camera>().orthographicSize = OriginalCameraSize;
        }

    }
}