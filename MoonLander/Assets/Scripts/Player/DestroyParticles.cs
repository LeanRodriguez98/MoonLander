using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour {
    public float TimeOfLife;
	
	void Start () {
        Destroy(gameObject, TimeOfLife);
	}
	
	
}
