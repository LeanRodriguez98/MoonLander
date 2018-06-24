using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour {

    public GameObject ParalaxGrid;
    public float ParalaxMovementIntencity;
    private Vector2 Position;
    private Vector3 OriginalPlayerPosition;
    private Vector2 ActualPlayerPosition;
    private float DiferenceOfPosition;
	// Use this for initialization
	void Start () {
        Position = transform.position;
        OriginalPlayerPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        ActualPlayerPosition = PlayerController.Instanciate.transform.position;       
        DiferenceOfPosition = ActualPlayerPosition.x - OriginalPlayerPosition.x;
        Position.x += ParalaxMovementIntencity * Time.deltaTime * DiferenceOfPosition;
        OriginalPlayerPosition = PlayerController.Instanciate.transform.position;      
        transform.position = Position;
    }
}
