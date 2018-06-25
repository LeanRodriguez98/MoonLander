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
	
	void Start () {
        Position = transform.position;
        OriginalPlayerPosition = Vector3.zero;
	}
	
	
	void Update () {
        if (PlayerController.Instanciate != null)
        {
            ActualPlayerPosition = PlayerController.Instanciate.transform.position;
            DiferenceOfPosition = ActualPlayerPosition.x - OriginalPlayerPosition.x;
            Position.x += ParalaxMovementIntencity * Time.deltaTime * DiferenceOfPosition;
            OriginalPlayerPosition = PlayerController.Instanciate.transform.position;
            transform.position = Position;
        }
        
    }
}
